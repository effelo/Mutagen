using BenchmarkDotNet.Attributes;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Oblivion;
using Mutagen.Bethesda.Oblivion.Internals;
using Mutagen.Bethesda.Preprocessing;
using Noggog;
using Noggog.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Tests.Benchmarks
{
    [MemoryDiagnoser]
    public class OblivionBinaryTranslation
    {
        public static TestingSettings Settings;
        public static OblivionMod Mod;
        public static TempFolder TempFolder;
        public static ModKey ModKey;
        public static string DataPath;
        public static string OutputPath;
        public static MemoryStream DataOutput;
        public static BinaryWriteParameters WriteParametersNoCheck = new BinaryWriteParameters()
        {
            MasterFlagSync = BinaryWriteParameters.MasterFlagSyncOption.NoCheck,
            MastersListSync = BinaryWriteParameters.MastersListSyncOption.NoCheck,
        };

        [GlobalSetup]
        public async Task Setup()
        {
            // Load Settings
            System.Console.WriteLine("Running in directory: " + Directory.GetCurrentDirectory());
            FilePath settingsPath = "../../../../TestingSettings.xml";
            System.Console.WriteLine("Settings path: " + settingsPath);
            Settings = TestingSettings.CreateFromXml(settingsPath.Path);
            System.Console.WriteLine("Target settings: " + Settings.ToString());

            // Setup folders and paths
            TempFolder = new TempFolder(deleteAfter: true);
            DataPath = Path.Combine(TempFolder.Dir.Path, "Oblivion.esm");
            using (var decompress = File.OpenWrite(DataPath))
            {
                ModDecompressor.Decompress(
                    () => File.OpenRead(Path.Combine(Settings.DataFolderLocations.Oblivion, "Oblivion.esm")),
                    decompress,
                    GameMode.Oblivion);
            }
            OutputPath = Path.Combine(TempFolder.Dir.Path, "OblivionOut.esm");

            // Setup
            Mod = OblivionMod.CreateFromBinary(
                DataPath,
                ModKey);

            DataOutput = new MemoryStream(new byte[new FileInfo(DataPath).Length]);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            TempFolder.Dispose();
        }

        [Benchmark]
        public async Task CreateBinary()
        {
            OblivionMod.CreateFromBinary(
                DataPath,
                ModKey);
        }

        [Benchmark]
        public void CreateAndWriteBinaryOverlayToDisk()
        {
            var bytes = File.ReadAllBytes(DataPath);
            var mod = OblivionModBinaryOverlay.OblivionModFactory(
                new MemorySlice<byte>(bytes),
                ModKey);
            mod.WriteToBinary(OutputPath, WriteParametersNoCheck);
        }

        [Benchmark]
        public void CreateAndWriteBinaryOverlayToMemory()
        {
            var bytes = File.ReadAllBytes(DataPath);
            var mod = OblivionModBinaryOverlay.OblivionModFactory(
                new MemorySlice<byte>(bytes),
                ModKey);
            DataOutput.Position = 0;
            mod.WriteToBinary(DataOutput, WriteParametersNoCheck);
        }

        [Benchmark]
        public void CreateAndWriteBinaryOverlayParallelToDisk()
        {
            var bytes = File.ReadAllBytes(DataPath);
            var mod = OblivionModBinaryOverlay.OblivionModFactory(
                new MemorySlice<byte>(bytes),
                ModKey);
            mod.WriteToBinaryParallel(OutputPath, WriteParametersNoCheck);
        }

        [Benchmark]
        public void CreateAndWriteBinaryOverlayParallelToMemory()
        {
            var bytes = File.ReadAllBytes(DataPath);
            var mod = OblivionModBinaryOverlay.OblivionModFactory(
                new MemorySlice<byte>(bytes),
                ModKey);
            DataOutput.Position = 0;
            mod.WriteToBinaryParallel(DataOutput, WriteParametersNoCheck);
        }

        [Benchmark]
        public void WriteBinaryToDisk()
        {
            Mod.WriteToBinary(OutputPath, WriteParametersNoCheck);
        }

        [Benchmark]
        public void WriteBinaryToMemory()
        {
            DataOutput.Position = 0;
            Mod.WriteToBinary(DataOutput, WriteParametersNoCheck);
        }

        [Benchmark]
        public void WriteBinaryParallelToDisk()
        {
            Mod.WriteToBinaryParallel(OutputPath, WriteParametersNoCheck);
        }

        [Benchmark]
        public void WriteBinaryParallelToMemory()
        {
            DataOutput.Position = 0;
            Mod.WriteToBinaryParallel(DataOutput, WriteParametersNoCheck);
        }
    }
}
