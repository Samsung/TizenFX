namespace Tizen.NUI.Components
{
    internal class UngroupedItemSource : IGroupableItemSource
    {
        readonly IItemSource source;

        public UngroupedItemSource(IItemSource itemSource)
        {
            source = itemSource;
        }

        public int Count => source.Count;

        public bool HasHeader { get => source.HasHeader; set => source.HasHeader = value; }
        public bool HasFooter { get => source.HasFooter; set => source.HasFooter = value; }

        public void Dispose()
        {
            source.Dispose();
        }

        public object GetItem(int position)
        {
            return source.GetItem(position);
        }

        public int GetPosition(object item)
        {
            return source.GetPosition(item);
        }

        public bool IsFooter(int position)
        {
            return source.IsFooter(position);
        }

        public bool IsGroupFooter(int position)
        {
            return false;
        }

        public bool IsGroupHeader(int position)
        {
            return false;
        }

        public bool IsHeader(int position)
        {
            return source.IsHeader(position);
        }

        public object GetGroupParent(int position)
        {
            return null;
        }
    }
}
