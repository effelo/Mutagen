﻿using Noggog;
using Noggog.Notifying;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda
{
    public class EDIDLink<T> : FormIDLink<T>, IEDIDLink<T>
       where T : class, IMajorRecord
    {
        public static readonly RecordType UNLINKED = new RecordType("\0\0\0\0");
        private IDisposable edidSub;
        public RecordType EDID { get; private set; } = UNLINKED;

        public EDIDLink()
            : base()
        {
        }

        public EDIDLink(RecordType unlinkedEDID)
            : this()
        {
            this.EDID = unlinkedEDID;
        }

        public EDIDLink(FormKey unlinkedForm)
            : base(unlinkedForm)
        {
        }

        public override void Set(T value)
        {
            HandleItemChange(new Change<T>(this.Item, value));
            base.Set(value);
        }

        public void Set(IEDIDLink<T> link)
        {
            if (link.Linked)
            {
                this.Set(link.Item);
            }
            else
            {
                this.EDID = link.EDID;
            }
        }

        private void HandleItemChange(Change<T> change)
        {
            this.EDID = EDIDLink<T>.UNLINKED;
            this.edidSub?.Dispose();
            this.edidSub = change.New?.WhenAny(x => x.EditorID)
                .Subscribe(UpdateUnlinked);
        }

        private void UpdateUnlinked(string change)
        {
            this.EDID = new RecordType(change);
        }

        public void SetIfSucceeded(TryGet<RecordType> item)
        {
            if (item.Failed) return;
            Set(item.Value);
        }

        public void Set(RecordType item)
        {
            this.EDID = item;
        }

        public void SetIfSuccessful(TryGet<string> item)
        {
            if (!item.Succeeded) return;
            Set(item.Value);
        }

        public void Set(string item)
        {
            this.EDID = new RecordType(item);
        }

        public void SetIfSucceededOrDefault(TryGet<RecordType> item)
        {
            if (item.Failed)
            {
                this.Unset();
                return;
            }
            this.EDID = item.Value;
        }

        public void SetIfSuccessfulOrDefault(TryGet<string> item)
        {
            if (!item.Succeeded)
            {
                this.Unset();
                return;
            }
            this.EDID = new RecordType(item.Value);
        }

        private static bool TryLinkToMod<M>(
            IEDIDLink<T> link,
            M mod)
            where M : IMod
        {
            if (string.IsNullOrWhiteSpace(link.EDID.Type)) return false;
            var group = mod.GetGroup<T>();
            foreach (var rec in group.Items)
            {
                if (link.EDID.Type.Equals(rec.EditorID))
                {
                    link.Item = rec;
                    return true;
                }
            }
            return false;
        }

        public static bool TryLink<M>(
            IEDIDLink<T> link,
            ModList<M> modList, 
            M sourceMod)
            where M : IMod
        {
#if DEBUG
            link.AttemptedLink = true;
#endif
            if (TryLinkToMod(link, sourceMod)) return true;
            if (modList == null) return false;
            foreach (var listing in modList)
            {
                if (!listing.Loaded) return false;
                if (TryLinkToMod(link, listing.Mod)) return true;
            }
            return false;
        }

        public override bool Link<M>(ModList<M> modList, M sourceMod)
        {
            if (this.UnlinkedForm.HasValue)
            {
                return base.Link(modList, sourceMod);
            }
            return TryLink(this, modList, sourceMod);
        }
    }
}