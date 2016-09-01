using System;
namespace ElmSharp
{
    public class IndexItem : ItemObject
    {
        public IndexItem(string text) : base(IntPtr.Zero)
        {
            Text = text;
        }

        public event EventHandler Selected;
        public string Text { get; private set; }

        public void Select(bool selected)
        {
            Interop.Elementary.elm_index_item_selected_set(Handle, selected);
        }
        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

    }
}
