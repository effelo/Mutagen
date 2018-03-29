﻿using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda
{
    public class ModList<Mod> : IEnumerable<ModListing<Mod>>
        where Mod : IMod
    {
        private readonly List<ModListing<Mod>> _modsByLoadOrder = new List<ModListing<Mod>>();

        public bool TryGetListing(ModKey key, out (ModID Index, ModListing<Mod> Listing) result)
        {
            for (int i = 0; i < _modsByLoadOrder.Count; i++)
            {
                var item = _modsByLoadOrder[i];
                if (item.Key.Equals(key))
                {
                    result = (new ModID((byte)i), _modsByLoadOrder[i]);
                    return true;
                }
            }
            result = default(ValueTuple<ModID, ModListing<Mod>>);
            return false;
        }

        public bool TryGetMod(ModKey key, out (ModID Index, Mod Mod) result)
        {
            if (!this.TryGetListing(key, out var listing)
                || !listing.Listing.Loaded)
            {
                result = default((ModID, Mod));
                return false;
            }
            result = (listing.Index, listing.Listing.Mod);
            return true;
        }

        public bool TryGetIndex(ModID index, out ModListing<Mod> result)
        {
            if (!_modsByLoadOrder.InRange(index.ID))
            {
                result = default(ModListing<Mod>);
                return false;
            }
            result = _modsByLoadOrder[index.ID];
            return result != null;
        }

        public void Add(ModKey key, Mod mod)
        {
            if (this.Contains(key))
            {
                throw new ArgumentException("Mod was already present on the mod list.");
            }
            _modsByLoadOrder.Add(
                new ModListing<Mod>(key, mod));
        }

        public void Add(ModKey key, Mod mod, byte index)
        {
            if (this.Contains(key))
            {
                throw new ArgumentException("Mod was already present on the mod list.");
            }
            _modsByLoadOrder.Insert(index, new ModListing<Mod>(key, mod));
        }

        public bool Contains(ModKey mod)
        {
            return IndexOf(mod) != -1;
        }

        public int IndexOf(ModKey mod)
        {
            for (int i = 0; i < _modsByLoadOrder.Count; i++)
            {
                if (_modsByLoadOrder[i].Key.Equals(mod))
                {
                    return i;
                }
            }
            return -1;
        }

        private void Link()
        {
            foreach (var listing in this._modsByLoadOrder)
            {
                if (!listing.Loaded) continue;
                foreach (var link in listing.Mod.Links)
                {
                    if (link.Linked) continue;
                    link.Link(this, listing.Mod);
                }
            }
        }

        public void Clear()
        {
            this._modsByLoadOrder.Clear();
        }

        public void Import(
            DirectoryPath dataFolder,
            List<ModKey> loadOrder,
            Func<FilePath, TryGet<Mod>> importer)
        {
            this.Clear();
            foreach (var item in loadOrder)
            {
                FilePath modPath = dataFolder.GetFile(item.FileName);
                if (modPath.Exists)
                {
                    var mod = importer(modPath);
                    if (mod.Succeeded)
                    {
                        this._modsByLoadOrder.Add(
                            new ModListing<Mod>(
                                item,
                                mod.Value));
                        continue;
                    }
                }
                this._modsByLoadOrder.Add(
                    new ModListing<Mod>(item));
            }
        }

        public IEnumerator<ModListing<Mod>> GetEnumerator()
        {
            return _modsByLoadOrder.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
