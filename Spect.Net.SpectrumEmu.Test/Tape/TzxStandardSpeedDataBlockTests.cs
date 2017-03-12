﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Spect.Net.SpectrumEmu.Tape;
using Spect.Net.SpectrumEmu.Tape.Tzx;
using Spect.Net.SpectrumEmu.Test.Helpers;

// ReSharper disable PossibleNullReferenceException

namespace Spect.Net.SpectrumEmu.Test.Tape
{
    [TestClass]
    public class TzxStandardSpeedDataBlockTests
    {
        [TestMethod]
        public void FirstPilotPulseGenerationWorks()
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;

            const ulong START = 123456789ul;
            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);
            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;

            // --- Act/Assert
            for (ulong pos = 0; pos < PILOT_PL; pos += 50)
            {
                var earBit = block.GetEarBit(START + pos);
                earBit.ShouldBeTrue();
                block.PlayPhase.ShouldBe(PlayPhase.Pilot);
            }
        }

        [TestMethod]
        public void SecondPilotPulseGenerationWorks()
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;

            const ulong START = 123456789ul;
            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);

            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;

            // --- Skip EAR bits of the first pluse
            for (ulong pos = 0; pos < PILOT_PL; pos += 50)
            {
                block.GetEarBit(START + pos);
            }

            // --- Act/Assert
            for (ulong pos = PILOT_PL; pos < 2 * PILOT_PL; pos += 50)
            {
                var earBit = block.GetEarBit(START + pos);
                earBit.ShouldBeFalse();
                block.PlayPhase.ShouldBe(PlayPhase.Pilot);
            }
        }

        [TestMethod]
        public void InternalPilotPulseGenerationWorksAsExpected()
        {
            TestPilotPulsePlayback(872);
            TestPilotPulsePlayback(1011);
            TestPilotPulsePlayback(3024);
            TestPilotPulsePlayback(8001);
        }

        [TestMethod]
        public void LastPilotPulseGenerationWorksAsExpected()
        {
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            TestPilotPulsePlayback(HEADER_PILOT_COUNT);
        }

        [TestMethod]
        public void FirstSyncPulseGenerationWorksAsExpected()
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            const int SYNC_1_PL = TzxStandardSpeedDataBlock.SYNC_1_PL;
            const ulong PILOT_END = PILOT_PL * HEADER_PILOT_COUNT;
            const ulong START = 123456789ul;

            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);

            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;

            // --- Skip all pilot pulses
            for (ulong pos = 0; pos < PILOT_END; pos += 50)
            {
                block.GetEarBit(START + pos);
            }

            // --- Act/Assert
            for (var pos = PILOT_END + 50; pos < PILOT_END + SYNC_1_PL; pos += 50)
            {
                var earBit = block.GetEarBit(START + pos);
                earBit.ShouldBeFalse();
                block.PlayPhase.ShouldBe(PlayPhase.Sync);
            }
        }

        [TestMethod]
        public void SecondSyncPulseGenerationWorksAsExpected()
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            const int SYNC_1_PL = TzxStandardSpeedDataBlock.SYNC_1_PL;
            const int SYNC_2_PL = TzxStandardSpeedDataBlock.SYNC_2_PL;
            const ulong PILOT_END = PILOT_PL * HEADER_PILOT_COUNT;
            const ulong START = 123456789ul;

            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);

            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;

            // --- Skip all pilot pulses + the first sync pulse
            for (ulong pos = 0; pos < PILOT_END + SYNC_1_PL; pos += 50)
            {
                block.GetEarBit(START + pos);
            }

            // --- Act/Assert
            for (var pos = PILOT_END + SYNC_1_PL + 50; pos < PILOT_END + SYNC_1_PL + SYNC_2_PL; pos += 50)
            {
                var earBit = block.GetEarBit(START + pos);
                earBit.ShouldBeTrue();
                block.PlayPhase.ShouldBe(PlayPhase.Sync);
            }
        }

        [TestMethod]
        public void SecondSyncPulseGenerationMovesToData()
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            const int SYNC_1_PL = TzxStandardSpeedDataBlock.SYNC_1_PL;
            const int SYNC_2_PL = TzxStandardSpeedDataBlock.SYNC_2_PL;
            const ulong PILOT_END = PILOT_PL * HEADER_PILOT_COUNT;
            const ulong START = 123456789ul;
            var block = ReadAndPositionToDataSection();

            // --- Act
            var earBit = block.GetEarBit(START + PILOT_END + SYNC_1_PL + SYNC_2_PL + 50);

            // --- Assert
            earBit.ShouldBeFalse();
            block.PlayPhase.ShouldBe(PlayPhase.Data);
        }

        [TestMethod]
        public void HeaderBytePulseGenerationWorksAsExpected()
        {
            // --- Arrange
            const ulong START = 123456789ul;
            var block = ReadAndPositionToByte(START, 0);
            
            // --- Act
            var byte0 = ReadNextByte(block);

            // --- Assert
            byte0.ShouldBe((byte)0);
        }

        [TestMethod]
        public void AllHeaderBytesPlaybackWorksAsExpected()
        {
            // --- Arrange
            const ulong START = 123456789ul;
            var block = ReadAndPositionToByte(START, 0);

            // --- Act/Assert
            for (var i = 0; i < block.DataLenght; i++)
            {
                var dataByte = ReadNextByte(block);
                dataByte.ShouldBe(block.Data[i]);
            }
            block.PlayPhase.ShouldBe(PlayPhase.Pause);
        }

        [TestMethod]
        public void BlockPausePlaybackWorksAsExpected()
        {
            // --- Arrange
            const int PAUSE_MS = TzxStandardSpeedDataBlock.PAUSE_MS;
            const ulong START = 123456789ul;

            var block = ReadAndPositionToByte(START, 0);
            for (var i = 0; i < block.DataLenght; i++)
            {
                ReadNextByte(block);
            }
            var nextTact = block.LastTact;
            
            // --- Act/Assert
            for (var pos = nextTact; pos < nextTact + (ulong) PAUSE_MS * block.PauseAfter; pos += 50)
            {
                block.GetEarBit(pos).ShouldBeTrue();
            }
            block.GetEarBit(block.LastTact + 100).ShouldBeTrue();
            block.PlayPhase.ShouldBe(PlayPhase.Completed);
        }

        #region Helper methods

        /// <summary>
        /// Tests a pilot pulse
        /// </summary>
        /// <param name="pulseIndex">The index of the pilor pulse</param>
        private void TestPilotPulsePlayback(int pulseIndex)
        {
            // --- Arrange
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const ulong START = 123456789ul;

            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);

            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;
            var prevPulseEnd = (ulong) (PILOT_PL * (pulseIndex - 1));

            // --- Skip EAR bits of the previous pulses
            for (ulong pos = 0; pos < prevPulseEnd; pos += 50)
            {
                block.GetEarBit(START + pos);
            }

            // --- Act/Assert
            for (var pos = prevPulseEnd + 50; pos < prevPulseEnd + PILOT_PL; pos += 50)
            {
                var earBit = block.GetEarBit(START + pos);
                earBit.ShouldBe(pulseIndex % 2 == 1);
                block.PlayPhase.ShouldBe(PlayPhase.Pilot);
            }
        }

        /// <summary>
        /// Reads nad positions a standard speed data block to its data area
        /// </summary>
        /// <returns>Standard speed data block</returns>
        private static TzxStandardSpeedDataBlock ReadAndPositionToDataSection()
        {
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            const int SYNC_1_PL = TzxStandardSpeedDataBlock.SYNC_1_PL;
            const int SYNC_2_PL = TzxStandardSpeedDataBlock.SYNC_2_PL;
            const ulong PILOT_END = PILOT_PL * HEADER_PILOT_COUNT;
            const ulong START = 123456789ul;

            var tzxReader = TzxHelper.GetResourceReader("JetSetWilly.tzx");
            var player = new TzxPlayer(tzxReader);
            player.ReadContent();
            player.InitPlay(START);

            // --- This is a standard ROM header data block
            var block = player.CurrentBlock as TzxStandardSpeedDataBlock;

            // --- Skip all pilot pulses + the first sync pulse
            for (ulong pos = 0; pos < PILOT_END + SYNC_1_PL; pos += 50)
            {
                block.GetEarBit(START + pos);
            }
            // --- Skip the second sync pulse
            for (var pos = PILOT_END + SYNC_1_PL + 50; pos < PILOT_END + SYNC_1_PL + SYNC_2_PL; pos += 50)
            {
                block.GetEarBit(START + pos);
            }
            return block;
        }

        /// <summary>
        /// Reads and positions a standard speed data block to the specified byte index in its data area
        /// </summary>
        /// <param name="start">Start tact</param>
        /// <param name="byteIndex">Byte index to position</param>
        /// <returns>Standard speed data block</returns>
        private static TzxStandardSpeedDataBlock ReadAndPositionToByte(ulong start, int byteIndex)
        {
            const int PILOT_PL = TzxStandardSpeedDataBlock.PILOT_PL;
            const int HEADER_PILOT_COUNT = TzxStandardSpeedDataBlock.HEADER_PILOT_COUNT;
            const int SYNC_1_PL = TzxStandardSpeedDataBlock.SYNC_1_PL;
            const int SYNC_2_PL = TzxStandardSpeedDataBlock.SYNC_2_PL;
            const ulong PILOT_END = PILOT_PL * HEADER_PILOT_COUNT;
            const int BIT_0_PL = TzxStandardSpeedDataBlock.BIT_0_PL;
            const int BIT_1_PL = TzxStandardSpeedDataBlock.BIT_1_PL;
            const ulong DATA_STARTS = PILOT_END + SYNC_1_PL + SYNC_2_PL;

            var block = ReadAndPositionToDataSection();
            var length = 0;
            for (var i = 0; i < byteIndex; i++)
            {
                var bits = block.Data[i];
                for (var j = 0; j < 8; j++)
                {
                    length += 2 * ((bits & (1 << j)) == 0 ? BIT_0_PL : BIT_1_PL);
                }
            }
            for (var pos = DATA_STARTS; pos < DATA_STARTS + (ulong)length; pos += 50)
            {
                block.GetEarBit(start + pos);
            }
            return block;
        }

        /// <summary>
        /// Reads the data byte from the current playback position
        /// </summary>
        /// <param name="block">Block to play back</param>
        /// <returns>Byte read</returns>
        private static byte ReadNextByte(TzxStandardSpeedDataBlock block)
        {
            const int BIT_0_PL = TzxStandardSpeedDataBlock.BIT_0_PL;
            const int BIT_1_PL = TzxStandardSpeedDataBlock.BIT_1_PL;
            const int STEP = 50;

            var nextTact = block.LastTact + STEP;
            byte bits = 0x00;
            for (var i = 0; i < 8; i++)
            {
                // --- Wait for the high EAR bit
                var samplesLow = 0;
                while (!block.GetEarBit(nextTact))
                {
                    samplesLow++;
                    nextTact += STEP;
                }

                // --- Wait for the low EAR bit
                var samplesHigh = 0;
                while (block.GetEarBit(nextTact) && samplesHigh < BIT_1_PL/STEP + 2)
                {
                    samplesHigh++;
                    nextTact += STEP;
                }

                bits <<= 1;
                if (samplesLow > (BIT_0_PL + BIT_1_PL) / 2 / STEP
                    && samplesHigh > (BIT_0_PL + BIT_1_PL) / 2 / STEP)
                {
                    bits++;
                }
            }
            return bits;
        }

        #endregion
    }
}
