using System;

namespace Tizen.NUI.Components
{
    internal sealed class EmptySource : IItemSource
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
