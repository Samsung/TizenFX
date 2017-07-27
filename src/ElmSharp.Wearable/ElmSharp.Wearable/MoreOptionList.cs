using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    class MoreOptionList : IList<MoreOptionItem>
    {
        MoreOption Owner { get; set; }

        List<MoreOptionItem> Items { get; set; }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public MoreOptionItem this[int index]
        {
            get
            {
                return Items[index];
            }

            set
            {
                Items[index] = value;
            }
        }

        public MoreOptionList(MoreOption owner)
        {
            Owner = owner;
            Items = new List<MoreOptionItem>();
        }

        public void Add(MoreOptionItem item)
        {
            item.Handle = Interop.Eext.eext_more_option_item_append(Owner);
            Items.Add(item);
        }

        public void AddFirst(MoreOptionItem item)
        {
            item.Handle = Interop.Eext.eext_more_option_item_prepend(Owner);
            Items.Insert(0, item);
        }

        public void AddLast(MoreOptionItem item)
        {
            Add(item);
        }

        public int IndexOf(MoreOptionItem item)
        {
            return Items.IndexOf(item);
        }

        public void Insert(int index, MoreOptionItem item)
        {
            if (Items.Count < index + 1 || index < 0)
                throw new ArgumentOutOfRangeException("index is not valid in the MoreOption");

            MoreOptionItem target = Items[index];
            item.Handle = Interop.Eext.eext_more_option_item_insert_after(Owner, target.Handle);
            Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            if (Items.Count < index + 1 || index < 0)
                throw new ArgumentOutOfRangeException("index is not valid in the MoreOptionList");

            MoreOptionItem item = Items[index];
            Interop.Eext.eext_more_option_item_del(item.Handle);
            item.Handle = IntPtr.Zero;
            Items.RemoveAt(index);
        }

        public void Clear()
        {
            Interop.Eext.eext_more_option_items_clear(Owner);
            foreach (MoreOptionItem item in Items)
            {
                item.Handle = IntPtr.Zero;
            }
            Items.Clear();
        }

        public bool Contains(MoreOptionItem item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(MoreOptionItem[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(MoreOptionItem item)
        {
            if (Items.Contains(item))
            {
                Interop.Eext.eext_more_option_item_del(item.Handle);
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public IEnumerator<MoreOptionItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
