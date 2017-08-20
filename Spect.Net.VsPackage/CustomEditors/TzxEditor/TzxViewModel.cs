using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Command;
using Spect.Net.SpectrumEmu.Devices.Tape.Tzx;
using Spect.Net.SpectrumEmu.Mvvm;
using Spect.Net.VsPackage.Tools.BasicList;
using Spect.Net.Wpf.Providers;

namespace Spect.Net.VsPackage.CustomEditors.TzxEditor
{
    /// <summary>
    /// This class represents the view model of the TZX Explorer tool window
    /// </summary>
    public class TzxViewModel: EnhancedViewModelBase
    {
        private ObservableCollection<TzxBlockViewModelBase> _blocks;

        /// <summary>
        /// The data blocks of the TZX file
        /// </summary>
        public ObservableCollection<TzxBlockViewModelBase> Blocks
        {
            get => _blocks;
            set => Set(ref _blocks, value);
        }

        /// <summary>
        /// Gets the selected block
        /// </summary>
        public TzxBlockViewModelBase SelectedBlock => _blocks.FirstOrDefault(b => b.IsSelected);

        /// <summary>
        /// Command executed when a block is selected
        /// </summary>
        public RelayCommand BlockSelectedCommand { get; }

        public TzxViewModel()
        {
            Blocks = new ObservableCollection<TzxBlockViewModelBase>();
            BlockSelectedCommand = new RelayCommand(OnBlockSelected);

            if (!IsInDesignMode) return;

            // ReSharper disable once UseObjectOrCollectionInitializer
            var provider = new TzxEmbeddedResourceLoadContentProvider(Assembly.GetExecutingAssembly());
            provider.TapeSetName = "Pac-Man.tzx";
            ReadFrom(provider.GetTzxContent());
        }

        /// <summary>
        /// A block has been selected in the block list
        /// </summary>
        private void OnBlockSelected()
        {
            var idx = _blocks.IndexOf(SelectedBlock);
            if (idx >= 1)
            {
            }
            MessengerInstance.Send(new TzxBlockSelectedMessage(this, SelectedBlock));
        }

        /// <summary>
        /// Reads the content of the TZX file from the specified binary reader
        /// </summary>
        /// <param name="binaryReader">Reader to get the contents</param>
        public void ReadFrom(BinaryReader binaryReader)
        {
            var tzxContent = new TzxReader(binaryReader);
            tzxContent.ReadContent();

            // --- Move TZX data into the view model
            Blocks.Clear();
            Blocks.Add(new TzxHeaderBlockViewModel
            {
                MajorVersion = tzxContent.MajorVersion,
                MinorVersion = tzxContent.MinorVersion
            });

            foreach (var block in tzxContent.DataBlocks)
            {
                TzxBlockViewModelBase blockVm;
                switch (block.BlockId)
                {
                    case 0x10:
                        var spBlockVm = new TzxStandardSpeedBlockViewModel();
                        spBlockVm.FromDataBlock((TzxStandardSpeedDataBlock)block);
                        blockVm = spBlockVm;
                        if (Blocks.Count > 0)
                        {
                            var prevBlock = _blocks[Blocks.Count - 1] as TzxStandardSpeedBlockViewModel;
                            var isProgram = spBlockVm.IsProgramDataBlock =
                                prevBlock != null
                                && prevBlock.Data[0] == 0x00
                                && prevBlock.Data[1] == 0x00;
                            if (isProgram)
                            {
                                spBlockVm.ProgramList = new BasicListViewModel(spBlockVm.Data, 0x0001, 
                                    (ushort)(spBlockVm.DataLenght - 1));
                                spBlockVm.ProgramList.DecodeBasicProgram();
                            }
                        }
                        break;

                    case 0x30:
                        var txtBlock = (TzxTextDescriptionDataBlock)block;
                        blockVm = new TzxTextDescriptionBlockViewModel
                        {
                            Text = TzxDataBlockBase.ToAsciiString(txtBlock.Description)
                        };
                        break;

                    case 0x32:
                        var archvm = new TzxArchiveInfoViewModel();
                        archvm.FromDataBlock((TzxArchiveInfoDataBlock)block);
                        blockVm = archvm;
                        break;

                    default:
                        blockVm = new TzxOtherBlockViewModel
                        {
                            BlockId = block.BlockId
                        };
                        break;
                }
                Blocks.Add(blockVm);
            }
        }

        /// <summary>
        /// Reads the content of the TZX file from the specified file
        /// </summary>
        /// <param name="filename">File name to read</param>
        public virtual void ReadFrom(string filename)
        {
            var binaryReader = new BinaryReader(File.Open(filename, FileMode.Open));
            ReadFrom(binaryReader);
        }
    }
}