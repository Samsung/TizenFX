using System;
using System.Collections.Generic;

namespace ElmSharp
{
    public enum GenListItemType
    {
        Normal = 0,
        Tree = (1 << 0),
        Group = (1 << 1),
    }

    public enum GenListMode
    {
        Compress = 0,
        Scroll,
        Limit,
        Expand
    }

    public class GenListItemEventArgs : EventArgs
    {
        public GenListItem Item { get; set; }

        internal static GenListItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenListItem item = ItemObject.GetItemByHandle(info) as GenListItem;
            return new GenListItemEventArgs() { Item = item };
        }
    }

    public enum ScrollToPosition
    {
        None = 0,   // Scrolls to nowhere
        In = (1 << 0),   // Scrolls to the nearest viewport
        Top = (1 << 1),   // Scrolls to the top of the viewport
        Middle = (1 << 2),   // Scrolls to the middle of the viewport
        Bottom = (1 << 3)   // Scrolls to the bottom of the viewport
    }

    public class GenList : Layout
    {
        HashSet<GenListItem> _children = new HashSet<GenListItem>();

        Interop.SmartEvent<GenListItemEventArgs> _selected;
        Interop.SmartEvent<GenListItemEventArgs> _unselected;
        Interop.SmartEvent<GenListItemEventArgs> _activated;
        Interop.SmartEvent<GenListItemEventArgs> _pressed;
        Interop.SmartEvent<GenListItemEventArgs> _released;
        Interop.SmartEvent<GenListItemEventArgs> _doubleClicked;
        Interop.SmartEvent<GenListItemEventArgs> _expanded;
        Interop.SmartEvent<GenListItemEventArgs> _realized;
        Interop.SmartEvent<GenListItemEventArgs> _unrealized;
        Interop.SmartEvent<GenListItemEventArgs> _longpressed;

        public GenList(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        public bool Homogeneous
        {
            get
            {
                return Interop.Elementary.elm_genlist_homogeneous_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_homogeneous_set(Handle, value);
            }
        }

        public GenListMode ListMode
        {
            get
            {
                return (GenListMode)Interop.Elementary.elm_genlist_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_mode_set(Handle, (int)value);
            }
        }

        public event EventHandler<GenListItemEventArgs> ItemSelected;
        public event EventHandler<GenListItemEventArgs> ItemUnselected;
        public event EventHandler<GenListItemEventArgs> ItemPressed;
        public event EventHandler<GenListItemEventArgs> ItemReleased;
        public event EventHandler<GenListItemEventArgs> ItemActivated;
        public event EventHandler<GenListItemEventArgs> ItemDoubleClicked;
        public event EventHandler<GenListItemEventArgs> ItemExpanded;
        public event EventHandler<GenListItemEventArgs> ItemRealized;
        public event EventHandler<GenListItemEventArgs> ItemUnrealized;
        public event EventHandler<GenListItemEventArgs> ItemLongPressed;

        public GenListItem Append(GenItemClass itemClass, object data)
        {
            return Append(itemClass, data, GenListItemType.Normal);
        }

        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Append(itemClass, data, type, null);
        }

        public GenListItem Append(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_genlist_item_append(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenListItem Prepend(GenItemClass itemClass, object data)
        {
            return Prepend(itemClass, data, GenListItemType.Normal);
        }

        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type)
        {
            return Prepend(itemClass, data, type, null);
        }

        public GenListItem Prepend(GenItemClass itemClass, object data, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_genlist_item_prepend(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, parent, (int)type, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before)
        {
            return InsertBefore(itemClass, data, before, GenListItemType.Normal);
        }
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type)
        {
            return InsertBefore(itemClass, data, before, type, null);
        }
        public GenListItem InsertBefore(GenItemClass itemClass, object data, GenListItem before, GenListItemType type, GenListItem parent)
        {
            GenListItem item = new GenListItem(data, itemClass);
            // insert before the `before` list item
            IntPtr handle = Interop.Elementary.elm_genlist_item_insert_before(
                Handle, // genlist handle
                itemClass.UnmanagedPtr, // item class
                (IntPtr)item.Id, // data
                parent, // parent
                before, // before
                (int)type, // item type
                null, // select callback
                (IntPtr)item.Id); // callback data
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public void ScrollTo(GenListItem item, ScrollToPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_genlist_item_bring_in(item.Handle, (Interop.Elementary.Elm_Genlist_Item_Scrollto_Type)position);
            }
            else
            {
                Interop.Elementary.elm_genlist_item_show(item.Handle, (Interop.Elementary.Elm_Genlist_Item_Scrollto_Type)position);
            }
        }

        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_genlist_realized_items_update(Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_genlist_add(parent);
        }

        void InitializeSmartEvent()
        {
            _selected = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "selected", GenListItemEventArgs.CreateFromSmartEvent);
            _unselected = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "unselected", GenListItemEventArgs.CreateFromSmartEvent);
            _activated = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "activated", GenListItemEventArgs.CreateFromSmartEvent);
            _pressed = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "pressed", GenListItemEventArgs.CreateFromSmartEvent);
            _released = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "released", GenListItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "clicked,double", GenListItemEventArgs.CreateFromSmartEvent);
            _expanded = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "expanded", GenListItemEventArgs.CreateFromSmartEvent);
            _realized = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "realized", GenListItemEventArgs.CreateFromSmartEvent);
            _unrealized = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "unrealized", GenListItemEventArgs.CreateFromSmartEvent);
            _longpressed = new Interop.SmartEvent<GenListItemEventArgs>(this, Handle, "longpressed", GenListItemEventArgs.CreateFromSmartEvent);

            _selected.On += (s, e) => { ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { ItemUnselected?.Invoke(this, e); };
            _activated.On += (s, e) => { ItemActivated?.Invoke(this, e); };
            _pressed.On += (s, e) => { ItemPressed?.Invoke(this, e); };
            _released.On += (s, e) => { ItemReleased?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { ItemDoubleClicked?.Invoke(this, e); };
            _expanded.On += (s, e) => { ItemExpanded?.Invoke(this, e); };
            _realized.On += (s, e) => { ItemRealized?.Invoke(this, e); };
            _unrealized.On += (s, e) => { ItemUnrealized?.Invoke(this, e); };
            _longpressed.On += (s, e) => { ItemLongPressed?.Invoke(this, e); };

        }

        void AddInternal(GenListItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((GenListItem)sender);
        }
    }
}
