using DynamicData;
using Noggog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace Mutagen.Bethesda
{
    public static class PluginListings
    {
        private readonly static ModKey[] _sseImplicitMods = new ModKey[]
        {
            "Skyrim.esm",
            "Update.esm",
            "Dawnguard.esm",
            "HearthFires.esm",
            "Dragonborn.esm",
        };

        private static string GetRelativePluginsPath(GameRelease game)
        {
            return game switch
            {
                GameRelease.Oblivion => "Oblivion/Plugins.txt",
                GameRelease.SkyrimLE => "Skyrim/Plugins.txt",
                GameRelease.SkyrimSE => "Skyrim Special Edition/Plugins.txt",
                GameRelease.SkyrimVR => "Skyrim VR/Plugins.txt",
                _ => throw new NotImplementedException()
            };
        }

        public static string GetListingsPath(GameRelease game)
        {
            string pluginPath = GetRelativePluginsPath(game);
            return Path.Combine(
                Environment.GetEnvironmentVariable("LocalAppData")!,
                pluginPath);
        }

        /// <summary>
        /// Attempts to locate the path to a game's load order file
        /// </summary>
        /// <param name="game">Game to locate for</param>
        /// <param name="path">Path to load order file if it was located</param>
        /// <returns>True if file located</returns>
        public static bool TryGetListingsFile(GameRelease game, out FilePath path)
        {
            path = new FilePath(GetListingsPath(game));
            return path.Exists;
        }

        /// <summary>
        /// Parses a stream to retrieve all ModKeys in expected plugin file format
        /// </summary>
        /// <param name="stream">Stream to read from</param>
        /// <param name="game">Game type</param>
        /// <returns>List of modkeys representing a load order</returns>
        /// <exception cref="ArgumentException">Line in plugin stream is unexpected</exception>
        public static IEnumerable<LoadOrderListing> ListingsFromStream(Stream stream, GameRelease game)
        {
            using var streamReader = new StreamReader(stream);
            var enabledMarkerProcessing = HasEnabledMarkers(game);
            while (!streamReader.EndOfStream)
            {
                var str = streamReader.ReadLine().AsSpan();
                var commentIndex = str.IndexOf('#');
                if (commentIndex != -1)
                {
                    str = str.Slice(0, commentIndex);
                }
                if (MemoryExtensions.IsWhiteSpace(str) || str.Length == 0) continue;
                yield return LoadOrderListing.FromString(str, enabledMarkerProcessing);
            }
        }

        /// <summary>
        /// Parses the typical plugins file to retrieve all ModKeys in expected plugin file format,
        /// Will order mods by timestamps if applicable
        /// Will add implicit base mods if applicable
        /// </summary>
        /// <param name="game">Game type</param>
        /// <param name="dataPath">Path to game's data folder</param>
        /// <param name="throwOnMissingMods">Whether to throw and exception if mods are missing</param>
        /// <returns>Enumerable of modkeys representing a load order</returns>
        /// <exception cref="ArgumentException">Line in plugin file is unexpected</exception>
        public static IEnumerable<LoadOrderListing> ListingsFromPath(
            GameRelease game,
            DirectoryPath dataPath,
            bool throwOnMissingMods = true)
        {
            return ListingsFromPath(
                pluginTextPath: GetListingsPath(game),
                game: game,
                dataPath: dataPath,
                throwOnMissingMods: throwOnMissingMods);
        }

        /// <summary>
        /// Parses a file to retrieve all ModKeys in expected plugin file format,
        /// Will order mods by timestamps if applicable
        /// Will add implicit base mods if applicable
        /// </summary>
        /// <param name="game">Game type</param>
        /// <param name="pluginTextPath">Path of plugin list</param>
        /// <param name="dataPath">Path to game's data folder</param>
        /// <param name="throwOnMissingMods">Whether to throw and exception if mods are missing</param>
        /// <returns>Enumerable of modkeys representing a load order</returns>
        /// <exception cref="ArgumentException">Line in plugin file is unexpected</exception>
        public static IEnumerable<LoadOrderListing> ListingsFromPath(
            FilePath pluginTextPath,
            GameRelease game,
            DirectoryPath dataPath,
            bool throwOnMissingMods = true)
        {
            List<LoadOrderListing> mods;
            if (pluginTextPath.Exists)
            {
                using var stream = new FileStream(pluginTextPath.Path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mods = ListingsFromStream(stream, game).ToList();
            }
            else
            {
                mods = new List<LoadOrderListing>();
            }
            AddImplicitMods(game, dataPath, mods);
            if (mods.Count == 0)
            {
                throw new FileNotFoundException("Could not locate plugins file");
            }
            if (LoadOrder.NeedsTimestampAlignment(game.ToCategory()))
            {
                return LoadOrder.AlignToTimestamps(mods, dataPath, throwOnMissingMods: throwOnMissingMods);
            }
            else
            {
                return mods;
            }
        }

        public static IObservable<IChangeSet<LoadOrderListing>> GetLiveLoadOrder(
            GameRelease game,
            FilePath loadOrderFilePath,
            DirectoryPath dataFolderPath,
            out IObservable<ErrorResponse> state,
            bool throwOnMissingMods = true)
        {
            var results = ObservableExt.WatchFile(loadOrderFilePath.Path)
                .StartWith(Unit.Default)
                .Select(_ =>
                {
                    try
                    {
                        return GetResponse<IObservable<IChangeSet<LoadOrderListing>>>.Succeed(
                            ListingsFromPath(loadOrderFilePath, game, dataFolderPath, throwOnMissingMods: throwOnMissingMods).AsObservableChangeSet());
                    }
                    catch (Exception ex)
                    {
                        return GetResponse<IObservable<IChangeSet<LoadOrderListing>>>.Fail(ex);
                    }
                })
                .Replay(1)
                .RefCount();
            state = results
                .Select(r => (ErrorResponse)r);
            return results
                .Select(r =>
                {
                    return r.Value ?? Observable.Empty<IChangeSet<LoadOrderListing>>();
                })
                .Switch();
        }

        internal static IEnumerable<ModKey> GetImplicitMods(GameRelease release)
        {
            return release switch
            {
                GameRelease.SkyrimSE => _sseImplicitMods,
                GameRelease.SkyrimVR => _sseImplicitMods,
                _ => Enumerable.Empty<ModKey>(),
            };
        }

        internal static void AddImplicitMods(
            GameRelease release,
            DirectoryPath dataPath,
            IList<LoadOrderListing> loadOrder)
        {
            foreach (var implicitMod in GetImplicitMods(release).Reverse())
            {
                if (loadOrder.Any(x => x.ModKey == implicitMod)) continue;
                if (!File.Exists(Path.Combine(dataPath.Path, implicitMod.FileName))) continue;
                loadOrder.Insert(0, new LoadOrderListing(implicitMod, true));
            }
        }

        public static bool HasEnabledMarkers(GameRelease game)
        {
            return game switch
            {
                GameRelease.SkyrimSE => true,
                GameRelease.SkyrimVR => true,
                GameRelease.SkyrimLE => false,
                GameRelease.Oblivion => false,
                _ => throw new NotImplementedException(),
            };
        }

        public static void Write(string path, GameRelease release, IEnumerable<LoadOrderListing> loadOrder)
        {
            bool markers = HasEnabledMarkers(release);
            var loadOrderList = loadOrder.ToList();
            foreach (var implicitMod in GetImplicitMods(release))
            {
                if (loadOrderList.Count > 0
                    && loadOrderList[0].ModKey == implicitMod
                    && loadOrderList[0].Enabled)
                {
                    loadOrderList.RemoveAt(0);
                }
            }
            File.WriteAllLines(path,
                loadOrderList.Where(x =>
                {
                    return (markers || x.Enabled);
                })
                .Select(x =>
                {
                    if (x.Enabled && markers)
                    {
                        return $"*{x.ModKey.FileName}";
                    }
                    else
                    {
                        return x.ModKey.FileName;
                    }
                }));
        }
    }
}