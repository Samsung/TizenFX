using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    internal sealed class CustomGroupItemSource : IGroupableItemSource
    {
        public CustomGroupItemSource(object parent)
        {
            this.parent = parent as CollectionView;
        }

        public int Count => 0;

        public bool HasHeader { get; set; } = true;
        public bool HasFooter { get; set; } = true;

        public void Dispose()
        {

        }

        public bool IsHeader(int index)
        {
            return HasHeader && index == 0;
        }

        public bool IsFooter(int index)
        {
            if (!HasFooter)
            {
                return false;
            }

            if (HasHeader)
            {
                return index == 1;
            }

            return index == 0;
        }

        public int GetPosition(object item)
        {
            return Position;
        }

        internal int Position
        {
            set;
            get;
        }

        public object GetItem(int position)
        {
            throw new IndexOutOfRangeException("IItemSource is empty");
        }

        public bool IsGroupHeader(int position)
        {
            return null != parent.Header;
        }

        public bool IsGroupFooter(int position)
        {
            return position == FooterIndex;
        }

        internal int FooterIndex
        {
            get;
            set;
        } = -1;

        public object GetGroupParent(int position)
        {
            return parent;
        }

        private CollectionView parent;
    }

    internal sealed class CustomEmptySource : IItemSource
    {
        public int Count => 0;

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }

        public void Dispose()
        {

        }

        public bool IsHeader(int index)
        {
            return HasHeader && index == 0;
        }

        public bool IsFooter(int index)
        {
            if (!HasFooter)
            {
                return false;
            }

            if (HasHeader)
            {
                return index == 1;
            }

            return index == 0;
        }

        public int GetPosition(object item)
        {
            return -1;
        }

        public object GetItem(int position)
        {
            throw new IndexOutOfRangeException("IItemSource is empty");
        }
    }
}
