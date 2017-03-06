﻿using System;
using System.Collections.Generic;
using System.Threading;
using Spect.Net.SpectrumEmu.Keyboard;
using Spect.Net.SpectrumEmu.Ula;
using Spect.Net.Z80Emu.Core;
using ZXMAK2.Engine.Cpu.Processor;

namespace Spect.Net.SpectrumEmu.Machine
{
    /// <summary>
    /// This class represents a ZX Spectrum 48 virtual machine
    /// </summary>
    public class Spectrum48
    {
        /// <summary>
        /// Spectrum 48 Memory
        /// </summary>
        private readonly byte[] _memory;

        private readonly byte[] _controlMemory;

        /// <summary>
        /// The CPU tick at which the last frame rendering started;
        /// </summary>
        private ulong _lastFrameStartCpuTick;

        /// <summary>
        /// The last rendered ULA tact 
        /// </summary>
        private int _lastRenderedUlaTact;

        /// <summary>
        /// The Z80 CPU of the machine
        /// </summary>
        public Z80 Cpu { get; }

        /// <summary>
        /// Control CPU
        /// </summary>
        public Z80Cpu ControlCpu { get; }

        /// <summary>
        /// The clock used within the VM
        /// </summary>
        public UlaClock Clock { get; }

        /// <summary>
        /// Display parameters of the VM
        /// </summary>
        public DisplayParameters DisplayPars { get; }

        /// <summary>
        /// The ULA border device used within the VM
        /// </summary>
        public UlaBorderDevice BorderDevice { get; }

        /// <summary>
        /// The ULA device that renders the VM screen
        /// </summary>
        public UlaScreenDevice ScreenDevice { get; }

        /// <summary>
        /// The ULA device that can render the VM screen during
        /// a debugging session
        /// </summary>
        public UlaScreenDevice ShadowScreenDevice { get; }

        /// <summary>
        /// The ULA device that takes care of raising interrupts
        /// </summary>
        public UlaInterruptDevice InterruptDevice { get; }

        /// <summary>
        /// The current status of the keyboard
        /// </summary>
        public KeyboardStatus KeyboardStatus { get; }

        /// <summary>
        /// Debug info provider object
        /// </summary>
        public IDebugInfoProvider DebugInfoProvider { get; private set; }

        /// <summary>
        /// The number of frame tact at which the interrupt signal is generated
        /// </summary>
        public virtual int InterruptTact => 32;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public Spectrum48(
            IRomProvider romProvider,
            IHighResolutionClockProvider clockProvider,
            IScreenPixelRenderer pixelRenderer)
        {
            Cpu = new Z80();
            ControlCpu = new Z80Cpu();
            _memory = new byte[0x10000];
            _controlMemory = new byte[0x10000];
            InitRom(romProvider, "ZXSpectrum48.rom");
            _memory.CopyTo(_controlMemory, 0);

            Cpu.ReadMemory = ReadMemory;
            Cpu.WriteMemory = WriteMemory;
            Cpu.ReadPort = ReadPort;
            Cpu.WritePort = WritePort;

            ControlCpu.RDMEM_M1 = ReadControlMemory;
            ControlCpu.RDMEM = ReadControlMemory;
            ControlCpu.RDNOMREQ = obj => { };
            ControlCpu.NMIACK_M1 = () => { };
            ControlCpu.RDPORT = ReadControlPort;
            ControlCpu.WRMEM = WriteControlMemory;
            ControlCpu.WRNOMREQ = obj => { };
            ControlCpu.WRPORT = WriteControlPort;
            ControlCpu.INTACK_M1 = () => { };
            ControlCpu.RESET = () => { };

            Clock = new UlaClock(clockProvider);
            DisplayPars = new DisplayParameters();
            BorderDevice = new UlaBorderDevice();
            ScreenDevice = new UlaScreenDevice(DisplayPars, pixelRenderer, BorderDevice, UlaReadMemory);
            ShadowScreenDevice = new UlaScreenDevice(DisplayPars, pixelRenderer, BorderDevice, UlaReadMemory);

            // ReSharper disable once VirtualMemberCallInConstructor
            InterruptDevice = new UlaInterruptDevice(Cpu, ControlCpu, InterruptTact);
            KeyboardStatus = new KeyboardStatus();
            ResetUlaTact();
        }

        /// <summary>
        /// Resets the CPU and the ULA chip
        /// </summary>
        public void Reset()
        {
            Cpu.Reset();
            ScreenDevice.Reset();
            ResetUlaTact();
        }

        /// <summary>
        /// Gets the current frame tact according to the CPU tick count
        /// </summary>
        public int CurrentFrameTact => (int) (Cpu.Ticks - _lastFrameStartCpuTick);

        /// <summary>
        /// Resets the ULA tact to start screen rendering from the beginning
        /// </summary>
        public void ResetUlaTact()
        {
            _lastRenderedUlaTact = -1;
        }

        /// <summary>
        /// Sets the debug info provider to the specified object
        /// </summary>
        /// <param name="provider">Provider object</param>
        public void SetDebugInfoProvider(IDebugInfoProvider provider)
        {
            DebugInfoProvider = provider;
        }

        /// <summary>
        /// The main execution cycle of the Spectrum VM
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <param name="mode">Execution emulation mode</param>
        /// <param name="stepMode">Debugging execution mode</param>
        /// <return>True, if the cycle completed; false, if it has been cancelled</return>
        public bool ExecuteCycle(CancellationToken token, EmulationMode mode = EmulationMode.Continuous,
            DebugStepMode stepMode = DebugStepMode.StopAtBreakpoint)
        {
            var startCounter = Clock.GetNativeCounter();
            _lastFrameStartCpuTick = Cpu.Ticks;
            if (mode == EmulationMode.Continuous)
            {
                ResetUlaTact();
            }
            var renderedFameCount = 0;
            var executedInstructionCount = -1;

            // --- Run until cancelled
            while (!token.IsCancellationRequested)
            {
                // --- Process instructions and run ULA logic until the frame ends
                while (Cpu.IsInOpExecution || CurrentFrameTact < DisplayPars.UlaFrameTactCount)
                {
                    var pcBefore = Cpu.Registers.PC;
                    var pcControlBefore = ControlCpu.regs.PC;

                    if (!Cpu.IsInOpExecution)
                    {
                        // --- The next instruction is about to be executed
                        executedInstructionCount++;

                        // --- Check for a debugging stop point
                        if (mode == EmulationMode.Debugger)
                        {
                            if (IsDebugStop(stepMode, executedInstructionCount))
                            {
                                // --- At this point, the cycle should be stopped because of debugging reasons
                                // --- The screen should be refreshed
                                ScreenDevice.SignFrameReady();
                                return true;
                            }
                        }
                    }

                    // --- Check for interrupt signal generation
                    InterruptDevice.CheckForInterrupt(CurrentFrameTact);

                    // --- Run a single Z80 instruction
                    Cpu.ExecuteCpuCycle();
                    //try
                    //{
                    //    ControlCpu.ExecCycle();
                    //}
                    //catch (Exception ex)
                    //{
                    //    var flag = true;
                    //}

                    //if (Differs(Cpu, ControlCpu))
                    //{
                    //    var flag = true;
                    //}

                    //if (DiffersPc(Cpu, ControlCpu))
                    //{
                    //    var flag = true;
                    //}

                    if (token.IsCancellationRequested)
                    {
                        return false;
                    }

                    // --- Run a rendering cycle according to the current CPU tact count
                    var lastTact = CurrentFrameTact;
                    ScreenDevice.RenderScreen(_lastRenderedUlaTact + 1, lastTact);
                    _lastRenderedUlaTact = lastTact;

                    // --- Exit if the emulation mode specifies so
                    if (mode == EmulationMode.SingleZ80Instruction && !Cpu.IsInOpExecution
                        || mode == EmulationMode.UntilHalt && Cpu.HALTED)
                    {
                        return true;
                    }
                }

                // --- Now, the entire frame is rendered
                ScreenDevice.SignFrameReady();

                // --- Exit if the emulation mode specifies so
                if (mode == EmulationMode.UntilFrameEnds)
                {
                    return true;
                }

                // --- Wait while the real frame time comes
                var nextFrameCounter = startCounter + (renderedFameCount + 1)
                    * Clock.Frequency/(double)DisplayPars.RefreshRate;
                Clock.WaitUntil((long)nextFrameCounter, token);

                // --- Exit if the emulation mode specifies so
                if (mode == EmulationMode.UntilNextFrame)
                {
                    return true;
                }

                // --- Start a new frame and carry on
                renderedFameCount++;
                var remainingTacts = CurrentFrameTact % DisplayPars.UlaFrameTactCount;
                _lastFrameStartCpuTick = Cpu.Ticks - (ulong)remainingTacts;
                ScreenDevice.StartNewFrame();
                ScreenDevice.RenderScreen(0, remainingTacts);
                _lastRenderedUlaTact = remainingTacts;

                // --- Reset the interrupt device
                InterruptDevice.Reset();

                // --- Exit if the emulation mode specifies so
                if (mode == EmulationMode.UntilNextFrameCycle)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Differs(Z80 cpu, Z80Cpu controlCpu)
        {
            return cpu.Registers.F != controlCpu.regs.F;
        }

        private bool DiffersPc(Z80 cpu, Z80Cpu controlCpu)
        {
            return cpu.Registers.PC != controlCpu.regs.PC;
        }

        /// <summary>
        /// Use this method to refresh the shadow screen while a
        /// debugging session is paused
        /// </summary>
        public void RefreshShadowScreen()
        {
            ShadowScreenDevice.StartNewFrame();
            ShadowScreenDevice.RenderScreen(0, DisplayPars.UlaFrameTactCount - 1);
        }

        /// <summary>
        /// Checks whether the execution cycle should be stopped for debugging
        /// </summary>
        /// <param name="stepMode">Debug setp mode</param>
        /// <param name="executedInstructionCount">
        /// The count of instructions already executed in this cycle
        /// </param>
        /// <returns>True, if the execution should be stopped</returns>
        private bool IsDebugStop(DebugStepMode stepMode, int executedInstructionCount)
        {
            // --- No debug provider, no stop
            if (DebugInfoProvider == null) return false;

            // --- In Step-Into mode we always stop when we're about to
            // --- execute the next instruction
            if (stepMode == DebugStepMode.StepInto)
            {
                return executedInstructionCount > 0;
            }

            // --- In Stop-At-Breakpoint mode we stop only if a predefined
            // --- breakpoint is reached
            if (stepMode == DebugStepMode.StopAtBreakpoint
                && DebugInfoProvider.Breakpoints.Contains(Cpu.Registers.PC))
            {
                // --- We do not stop unless we executed at least one instruction
                return executedInstructionCount > 0;
            }

            // --- We're in Step-Over mode
            if (stepMode == DebugStepMode.StepOver)
            {
                if (DebugInfoProvider.ImminentBreakpoint != null)
                {
                    // --- We also stop, if an imminent breakpoint is reached, and also remove
                    // --- this breakpoint
                    if (DebugInfoProvider.ImminentBreakpoint == Cpu.Registers.PC)
                    {
                        DebugInfoProvider.ImminentBreakpoint = null;
                        return true;
                    }
                }
                else
                {
                    var imminentJustCreated = false;

                    // --- We check for a CALL-like instruction
                    var length = Cpu.GetCallInstructionLength();
                    if (length > 0)
                    {
                        // --- Its a CALL-like instraction, create an imminent breakpoint
                        DebugInfoProvider.ImminentBreakpoint = (ushort)(Cpu.Registers.PC + length);
                        imminentJustCreated = true;
                    }

                    // --- We stop, we executed at least one instruction and if there's no imminent 
                    // --- breakpoint or we've just created one
                    if (executedInstructionCount > 0
                        && (DebugInfoProvider.ImminentBreakpoint == null || imminentJustCreated))
                    {
                        return true;
                    }
                }
            }

            // --- In any other case, we carry on
            return false;
        }

        #region Memory access functions

        /// <summary>
        /// Reads a byte from the memory
        /// </summary>
        /// <param name="addr">Memory address to read</param>
        /// <returns>
        /// The byte value read from memory
        /// </returns>
        public virtual byte ReadMemory(ushort addr)
        {
            var value = _memory[addr];
            //if (addr == 0x5C3B)
            //{
            //    Follow(Cpu.Registers.PC, value, "W");
            //}
            if ((addr & 0xC000) == 0x4000)
            {
                Cpu.Delay(ScreenDevice.GetContentionValue((int)(Cpu.Ticks - _lastFrameStartCpuTick)));
            }
            return value;
        }

        /// <summary>
        /// Reads a byte from the memory
        /// </summary>
        /// <param name="addr">Memory address to read</param>
        /// <returns>
        /// The byte value read from memory
        /// </returns>
        private byte UlaReadMemory(ushort addr)
        {
            var value = _memory[(addr & 0x3FFF) + 0x4000];
            return value;
        }

        /// <summary>
        /// Writes a byte to the memory
        /// </summary>
        /// <param name="addr">Memory address</param>
        /// <param name="value">Data byte</param>
        public virtual void WriteMemory(ushort addr, byte value)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            if (addr == 0x5C3B)
            {
                Follow(Cpu.Registers.PC, value, "W");
            }
            switch (addr & 0xC000)
            {
                case 0x0000:
                    // --- ROM cannot be overwritten
                    return;
                case 0x4000:
                    // --- Handle potential memory contention delay
                    Cpu.Delay(ScreenDevice.GetContentionValue((int)(Cpu.Ticks - _lastFrameStartCpuTick)));
                    break;
            }
            _memory[addr] = value;
        }

        #endregion

        #region I/O Access functions

        /// <summary>
        /// Writes the given <paramref name="value" /> to the
        /// given port specified in <paramref name="addr"/>.
        /// </summary>
        /// <param name="addr">Port address</param>
        /// <param name="value">Value to write</param>
        protected virtual void WritePort(ushort addr, byte value)
        {
            // --- Set border value
            if ((addr & 0x0001) == 0)
            {
                BorderDevice.BorderColor = value & 0x07;
            }
        }

        /// <summary>
        /// Reads a byte from the port specified in <paramref name="addr"/>.
        /// </summary>
        /// <param name="addr">Port address</param>
        /// <returns>Value read from the port</returns>
        protected virtual byte ReadPort(ushort addr)
        {
            return (addr & 0x0001) == 0
                ? KeyboardStatus.GetLineStatus((byte)(addr >> 8))
                : (byte) 0xFF;
        }

        #endregion

        #region Control memory access functions

        /// <summary>
        /// Reads a byte from the memory
        /// </summary>
        /// <param name="addr">Memory address to read</param>
        /// <returns>
        /// The byte value read from memory
        /// </returns>
        public virtual byte ReadControlMemory(ushort addr)
        {
            var value = _controlMemory[addr];
            //if (addr == 0x5C3B)
            //{
            //    Follow(Cpu.Registers.PC, value, "W");
            //}
            if ((addr & 0xC000) == 0x4000)
            {
                Cpu.Delay(ScreenDevice.GetContentionValue((int)(Cpu.Ticks - _lastFrameStartCpuTick)));
            }
            return value;
        }

        /// <summary>
        /// Writes a byte to the memory
        /// </summary>
        /// <param name="addr">Memory address</param>
        /// <param name="value">Data byte</param>
        public virtual void WriteControlMemory(ushort addr, byte value)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (addr & 0xC000)
            {
                case 0x0000:
                    // --- ROM cannot be overwritten
                    return;
                case 0x4000:
                    // --- Handle potential memory contention delay
                    Cpu.Delay(ScreenDevice.GetContentionValue((int)(Cpu.Ticks - _lastFrameStartCpuTick)));
                    break;
            }
            _controlMemory[addr] = value;
        }

        #endregion

        #region I/O Access functions

        /// <summary>
        /// Writes the given <paramref name="value" /> to the
        /// given port specified in <paramref name="addr"/>.
        /// </summary>
        /// <param name="addr">Port address</param>
        /// <param name="value">Value to write</param>
        protected virtual void WriteControlPort(ushort addr, byte value)
        {
            // --- Set border value
            if ((addr & 0x0001) == 0)
            {
                BorderDevice.BorderColor = value & 0x07;
            }
        }

        /// <summary>
        /// Reads a byte from the port specified in <paramref name="addr"/>.
        /// </summary>
        /// <param name="addr">Port address</param>
        /// <returns>Value read from the port</returns>
        protected virtual byte ReadControlPort(ushort addr)
        {
            return (addr & 0x0001) == 0
                ? KeyboardStatus.GetLineStatus((byte)(addr >> 8))
                : (byte)0xFF;
        }

        #endregion

        #region Helper functions

        /// <summary>
        /// Loads the content of the ROM through the specified provider
        /// </summary>
        /// <param name="romProvider">ROM provider instance</param>
        /// <param name="romResourceName">ROM Resource name</param>
        /// <remarks>
        /// The content of the ROM is copied into the memory
        /// </remarks>
        public void InitRom(IRomProvider romProvider, string romResourceName)
        {
            var romBytes = romProvider.LoadRom(romResourceName);
            romBytes?.CopyTo(_memory, 0);
        }

        public List<string> Actions = new List<string>();

        public void Follow(ushort addr, byte value, string action)
        {
            Actions.Add($"{addr:X4} {action} ==> {value:X2}");
        }

        #endregion
    }
}