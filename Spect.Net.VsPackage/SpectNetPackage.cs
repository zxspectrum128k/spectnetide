﻿using System;
using System.Runtime.InteropServices;
using EnvDTE;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.Shell;
using Spect.Net.VsPackage.Messages;
using Spect.Net.VsPackage.SpectrumEmulator;
using Spect.Net.VsPackage.Tools.Disassembly;
using Spect.Net.VsPackage.Tools.Memory;
using Spect.Net.VsPackage.Tools.RegistersTool;
using Spect.Net.VsPackage.Tools.TzxExplorer;
using Spect.Net.VsPackage.Vsx;
using Spect.Net.Wpf.SpectrumControl;

namespace Spect.Net.VsPackage
{
    /// <summary>
    /// This class provides a Visual Studio package for the Spect.NET IDE.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid("1b214806-bc31-49bd-be5d-79ac4a189f3c")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(SpectrumEmulatorToolWindow), Transient = true)]
    [ProvideToolWindow(typeof(RegistersToolWindow), Transient = true)]
    [ProvideToolWindow(typeof(DisassemblyToolWindow), Transient = true)]
    [ProvideToolWindow(typeof(MemoryToolWindow), Transient = true)]
    [ProvideToolWindow(typeof(TzxExplorerToolWindow), Transient = true)]
    public sealed class SpectNetPackage : VsxPackage
    {
        /// <summary>
        /// Command set of the package
        /// </summary>
        public const string PACKAGE_COMMAND_SET = "234580c4-8a2c-4ae1-8e4f-5bc708b188fe";

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid(PACKAGE_COMMAND_SET);

        private DTEEvents _packageDteEvents;

        public SpectrumVmViewModel SpectrumVmViewModel { get; private set; }
        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void OnInitialize()
        {
            // --- Let's create the ZX Spectrum virtual machine view model 
            // --- that is used all around in tool windows
            SpectrumVmViewModel = new SpectrumVmViewModel();

            // --- Prepare for package shutdown
            _packageDteEvents = ApplicationObject.Events.DTEEvents;
            _packageDteEvents.OnBeginShutdown += () =>
            {
                Messenger.Default.Send(new PackageShutdownMessage());
            };
        }

        /// <summary>
        /// Displays the ZX Spectrum emulator tool window
        /// </summary>
        [CommandId(0x1000)]
        [ToolWindow(typeof(SpectrumEmulatorToolWindow))]
        public class ShowSpectrumEmulatorCommand : 
            VsxShowToolWindowCommand<SpectNetPackage, SpectNetCommandSet>
        {
        }

        /// <summary>
        /// Displays the Z80 Registers tool window
        /// </summary>
        [CommandId(0x1100)]
        [ToolWindow(typeof(RegistersToolWindow))]
        public class ShowZ80RegistersCommand :
            VsxShowToolWindowCommand<SpectNetPackage, SpectNetCommandSet>
        {
        }

        /// <summary>
        /// Displays the Z80 Registers tool window
        /// </summary>
        [CommandId(0x1200)]
        [ToolWindow(typeof(DisassemblyToolWindow))]
        public class ShowZ80DisassemblyCommand :
            VsxShowToolWindowCommand<SpectNetPackage, SpectNetCommandSet>
        {
        }

        /// <summary>
        /// Displays the ZX Spectrum Memory tool window
        /// </summary>
        [CommandId(0x1300)]
        [ToolWindow(typeof(MemoryToolWindow))]
        public class ShowSpectrumMemoryCommand :
            VsxShowToolWindowCommand<SpectNetPackage, SpectNetCommandSet>
        {
        }

        /// <summary>
        /// Displays the TZX Explorer tool window
        /// </summary>
        [CommandId(0x1400)]
        [ToolWindow(typeof(TzxExplorerToolWindow))]
        public class ShowTzxExplorerCommand :
            VsxShowToolWindowCommand<SpectNetPackage, SpectNetCommandSet>
        {
        }
    }
}