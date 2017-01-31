﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Spect.Net.Z80Emu.Test.Helpers;
// ReSharper disable ArgumentsStyleStringLiteral

namespace Spect.Net.Z80Emu.Test.Core
{
    [TestClass]
    public class StandardOpTests0xE0
    {
        /// <summary>
        /// RET PO: 0xE0
        /// </summary>
        [TestMethod]
        public void RET_PO_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x2A,       // LD A,2AH
                0xCD, 0x06, 0x00, // CALL 0006H
                0x76,             // HALT
                0x87,             // ADD A
                0xE0,             // RET PO
                0x3E, 0x24,       // LD A,24H
                0xC9              // RET
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x54);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0006);
            m.Cpu.Ticks.ShouldBe(43ul);
        }

        /// <summary>
        /// POP HL: 0xE1
        /// </summary>
        [TestMethod]
        public void POP_HL_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x01, 0x52, 0x23, // LD BC,2352H
                0xC5,             // PUSH BC
                0xE1              // POP HL
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.HL.ShouldBe((ushort)0x2352);
            m.ShouldKeepRegisters(except: "HL, BC");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(31ul);
        }

        /// <summary>
        /// JP PO,NN: 0xE2
        /// </summary>
        [TestMethod]
        public void JP_PO_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x2A,       // LD A,2AH
                0x87,             // ADD A
                0xE2, 0x07, 0x00, // JP PO,0007H
                0x76,             // HALT
                0x3E, 0xAA,       // LD A,AAH
                0x76              // HALT
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0xAA);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x000A);
            m.Cpu.Ticks.ShouldBe(32ul);
        }

        /// <summary>
        /// CALL PO: 0xE4
        /// </summary>
        [TestMethod]
        public void CALL_PO_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x2A,       // LD A,2AH
                0x87,             // ADD A
                0xE4, 0x07, 0x00, // CALL PO,0007H
                0x76,             // HALT
                0x3E, 0x24,       // LD A,24H
                0xC9              // RET
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x24);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0007);
            m.Cpu.Ticks.ShouldBe(49ul);
        }

        /// <summary>
        /// PUSH HL: 0xE5
        /// </summary>
        [TestMethod]
        public void PUSH_HL_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilEnd);
            m.InitCode(new byte[]
            {
                0x21, 0x52, 0x23, // LD HL,2352H
                0xE5,             // PUSH HL
                0xC1              // POP BC
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.BC.ShouldBe((ushort)0x2352);
            m.ShouldKeepRegisters(except: "HL, BC");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0005);
            m.Cpu.Ticks.ShouldBe(31ul);
        }

        /// <summary>
        /// RET PE: 0xE8
        /// </summary>
        [TestMethod]
        public void RET_PE_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x88,       // LD A,88H
                0xCD, 0x06, 0x00, // CALL 0006H
                0x76,             // HALT
                0x87,             // ADD A
                0xE8,             // RET PE
                0x3E, 0x24,       // LD A,24H
                0xC9              // RET
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x10);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0006);
            m.Cpu.Ticks.ShouldBe(43ul);
        }

        /// <summary>
        /// JP PE,NN: 0xEA
        /// </summary>
        [TestMethod]
        public void JP_PE_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x88,       // LD A,88H
                0x87,             // ADD A
                0xEA, 0x07, 0x00, // JP PE,0007H
                0x76,             // HALT
                0x3E, 0xAA,       // LD A,AAH
                0x76              // HALT
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0xAA);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory();

            regs.PC.ShouldBe((ushort)0x000A);
            m.Cpu.Ticks.ShouldBe(32ul);
        }

        /// <summary>
        /// CALL PE: 0xEC
        /// </summary>
        [TestMethod]
        public void CALL_PE_WorksAsExpected()
        {
            // --- Arrange
            var m = new Z80TestMachine(RunMode.UntilHalt);
            m.InitCode(new byte[]
            {
                0x3E, 0x88,       // LD A,88H
                0x87,             // ADD A
                0xEC, 0x07, 0x00, // CALL PE,0007H
                0x76,             // HALT
                0x3E, 0x24,       // LD A,24H
                0xC9              // RET
            });

            // --- Act
            m.Run();

            // --- Assert
            var regs = m.Cpu.Registers;

            regs.A.ShouldBe((byte)0x24);
            m.ShouldKeepRegisters(except: "AF");
            m.ShouldKeepMemory(except: "FFFE-FFFF");

            regs.PC.ShouldBe((ushort)0x0007);
            m.Cpu.Ticks.ShouldBe(49ul);
        }

    }
}