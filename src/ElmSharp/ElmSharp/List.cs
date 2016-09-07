using System;
using System.Collections.Generic;
using System.Linq;

namespace ElmSharp
{
    public enum ListMode
    {
        Compress = 0,
        Scroll,
        Limit,
        Expand
    }

    public class ListItemEventArgs : EventArgs
    {
        public ListItem Item { get; set; }
        internal static ListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            ListItem item = ItemObject.GetItemByHandle(info) as ListItem;
            return new ListItemEventArgs() { Item = item };
        }
    }

    public class List : Layout
    {
        HashSet<ListItem> _children = new HashSet<ListItem>();
        Interop.SmartEvent<ListItemEventArgs> _selected;
        Interop.SmartEvent<ListItemEventArgs> _unselected;
        Interop.SmartEvent<ListItemEventArgs> _doubleClicked;
        Interop.SmartEvent<ListItemEventArgs> _longpressed;
        Interop.SmartEvent<ListItemEventArgs> _activated;

        public List(EvasObject parent) : base(parent)
        {
            _selected = new Interop.SmartEvent<ListItemEventArgs>(this, Handle, "selected", ListItemEventArgs.CreateFromSmartEvent);
            _unselected = new Interop.SmartEvent<ListItemEventArgs>(this, Handle, "unselected", ListItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new Interop.SmartEvent<ListItemEventArgs>(this, Handle, "clicked,double", ListItemEventArgs.CreateFromSmartEvent);
            _longpressed = new Interop.SmartEvent<ListItemEventArgs>(this, Handle, "longpressed", ListItemEventArgs.CreateFromSmartEvent);
            _activated = new Interop.SmartEvent<ListItemEventArgs>(this, Handle, "activated", ListItemEventArgs.CreateFromSmartEvent);
            _selected.On += (s, e) => { ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { ItemUnselected?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { ItemDoubleClicked?.Invoke(this, e); };
            _longpressed.On += (s, e) => { ItemLongPressed?.Invoke(this, e); };
            _activated.On += (s, e) => { ItemActivated?.Invoke(this, e); };
        }

        public ListMode Mode
        {
            get
            {
                return (ListMode)Interop.Elementary.elm_list_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_list_mode_set(Handle, (Interop.Elementary.Elm_List_Mode)value);
            }
        }

        public ListItem SelectedItem
        {
            get
            {
                IntPtr item = Interop.Elementary.elm_list_selected_item_get(Handle);
                return ItemObject.GetItemByHandle(item) as ListItem;
            }
        }

        public event EventHandler<ListItemEventArgs> ItemSelected;
        public event EventHandler<ListItemEventArgs> ItemUnselected;
        public event EventHandler<ListItemEventArgs> ItemDoubleClicked;
        public event EventHandler<ListItemEventArgs> ItemLongPressed;
        public event EventHandler<ListItemEventArgs> ItemActivated;

        public void Update()
        {
            Interop.Elementary.elm_list_go(Handle);
        }

        public ListItem Append(string label)
        {
            return Append(label, null, null);
        }

        public ListItem Append(string label, EvasObject leftIcon, EvasObject rightIcon)
        {
            ListItem item = new ListItem(label, leftIcon, rightIcon);
            item.Handle = Interop.Elementary.elm_list_item_append(Handle, label, leftIcon, rightIcon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        public ListItem Prepend(string label)
        {
            return Prepend(label, null, null);
        }

        public ListItem Prepend(string label, EvasObject leftIcon, EvasObject rigthIcon)
        {
            ListItem item = new ListItem(label, leftIcon, rigthIcon);
            item.Handle = Interop.Elementary.elm_list_item_prepend(Handle, label, leftIcon, rigthIcon, null, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        public void Clear()
        {
            Interop.Elementary.elm_list_clear(Handle);
            foreach (var item in _children)
            {
                item.Deleted -= Item_Deleted;
            }
            _children.Clear();
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_list_add(parent);
        }

        void AddInternal(ListItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((ListItem)sender);
        }
    }
}
