using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public enum GenGridSelectionMode
    {
        Default = 0,
        Always,
        None,
        DisplayOnly,
    }

    public class GenGridItemEventArgs : EventArgs
    {
        public GenGridItem Item { get; set; }

        internal static GenGridItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            GenGridItem item = ItemObject.GetItemByHandle(info) as GenGridItem;
            return new GenGridItemEventArgs() { Item = item };
        }
    }

    public class GenGrid : Layout
    {
        HashSet<GenGridItem> _children = new HashSet<GenGridItem>();

        Interop.SmartEvent<GenGridItemEventArgs> _selected;
        Interop.SmartEvent<GenGridItemEventArgs> _unselected;
        Interop.SmartEvent<GenGridItemEventArgs> _activated;
        Interop.SmartEvent<GenGridItemEventArgs> _pressed;
        Interop.SmartEvent<GenGridItemEventArgs> _released;
        Interop.SmartEvent<GenGridItemEventArgs> _doubleClicked;
        Interop.SmartEvent<GenGridItemEventArgs> _realized;
        Interop.SmartEvent<GenGridItemEventArgs> _unrealized;
        Interop.SmartEvent<GenGridItemEventArgs> _longpressed;

        public GenGrid(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        public event EventHandler<GenGridItemEventArgs> ItemSelected;
        public event EventHandler<GenGridItemEventArgs> ItemUnselected;
        public event EventHandler<GenGridItemEventArgs> ItemPressed;
        public event EventHandler<GenGridItemEventArgs> ItemReleased;
        public event EventHandler<GenGridItemEventArgs> ItemActivated;
        public event EventHandler<GenGridItemEventArgs> ItemDoubleClicked;
        public event EventHandler<GenGridItemEventArgs> ItemRealized;
        public event EventHandler<GenGridItemEventArgs> ItemUnrealized;
        public event EventHandler<GenGridItemEventArgs> ItemLongPressed;

        public double ItemAlignmentX
        {
            get
            {
                double align;
                Interop.Elementary.elm_gengrid_align_get(Handle, out align, IntPtr.Zero);
                return align;
            }
            set
            {
                double aligny = ItemAlignmentY;
                Interop.Elementary.elm_gengrid_align_set(Handle, value, aligny);
            }
        }

        public double ItemAlignmentY
        {
            get
            {
                double align;
                Interop.Elementary.elm_gengrid_align_get(Handle, IntPtr.Zero, out align);
                return align;
            }
            set
            {
                double alignx = ItemAlignmentX;
                Interop.Elementary.elm_gengrid_align_set(Handle, alignx, value);
            }
        }

        public bool FillItems
        {
            get
            {
                return Interop.Elementary.elm_gengrid_filled_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_filled_set(Handle, value);
            }
        }

        public bool MultipleSelection
        {
            get
            {
                return Interop.Elementary.elm_gengrid_multi_select_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_multi_select_set(Handle, value);
            }
        }

        public int ItemWidth
        {
            get
            {
                int width;
                Interop.Elementary.elm_gengrid_item_size_get(Handle, out width, IntPtr.Zero);
                return width;
            }
            set
            {
                int height = ItemHeight;
                Interop.Elementary.elm_gengrid_item_size_set(Handle, value, height);

            }
        }

        public int ItemHeight
        {
            get
            {
                int height;
                Interop.Elementary.elm_gengrid_item_size_get(Handle, IntPtr.Zero, out height);
                return height;
            }
            set
            {
                int width = ItemWidth;
                Interop.Elementary.elm_gengrid_item_size_set(Handle, width, value);
            }
        }

        public GenGridSelectionMode SelectionMode
        {
            get
            {
                return (GenGridSelectionMode)Interop.Elementary.elm_gengrid_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_select_mode_set(Handle, (int)value);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_gengrid_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_horizontal_set(Handle, value);
            }
        }

        public GenGridItem Append(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_append(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem Prepend(GenItemClass itemClass, object data)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_prepend(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public GenGridItem InsertBefore(GenItemClass itemClass, object data, GenGridItem before)
        {
            GenGridItem item = new GenGridItem(data, itemClass);
            IntPtr handle = Interop.Elementary.elm_gengrid_item_insert_before(Handle, itemClass.UnmanagedPtr, (IntPtr)item.Id, before, null, (IntPtr)item.Id);
            item.Handle = handle;
            AddInternal(item);
            return item;
        }

        public void ScrollTo(GenGridItem item, ScrollToPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Elementary.elm_gengrid_item_bring_in(item.Handle, (int)position);
            }
            else
            {
                Interop.Elementary.elm_gengrid_item_show(item.Handle, (int)position);
            }
        }

        public void UpdateRealizedItems()
        {
            Interop.Elementary.elm_gengrid_realized_items_update(Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_gengrid_add(parent);
        }

        void InitializeSmartEvent()
        {
            _selected = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "selected", GenGridItemEventArgs.CreateFromSmartEvent);
            _unselected = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "unselected", GenGridItemEventArgs.CreateFromSmartEvent);
            _activated = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "activated", GenGridItemEventArgs.CreateFromSmartEvent);
            _pressed = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "pressed", GenGridItemEventArgs.CreateFromSmartEvent);
            _released = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "released", GenGridItemEventArgs.CreateFromSmartEvent);
            _doubleClicked = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "clicked,double", GenGridItemEventArgs.CreateFromSmartEvent);
            _realized = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "realized", GenGridItemEventArgs.CreateFromSmartEvent);
            _unrealized = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "unrealized", GenGridItemEventArgs.CreateFromSmartEvent);
            _longpressed = new Interop.SmartEvent<GenGridItemEventArgs>(this, Handle, "longpressed", GenGridItemEventArgs.CreateFromSmartEvent);

            _selected.On += (s, e) => { ItemSelected?.Invoke(this, e); };
            _unselected.On += (s, e) => { ItemUnselected?.Invoke(this, e); };
            _activated.On += (s, e) => { ItemActivated?.Invoke(this, e); };
            _pressed.On += (s, e) => { ItemPressed?.Invoke(this, e); };
            _released.On += (s, e) => { ItemReleased?.Invoke(this, e); };
            _doubleClicked.On += (s, e) => { ItemDoubleClicked?.Invoke(this, e); };
            _realized.On += (s, e) => { ItemRealized?.Invoke(this, e); };
            _unrealized.On += (s, e) => { ItemUnrealized?.Invoke(this, e); };
            _longpressed.On += (s, e) => { ItemLongPressed?.Invoke(this, e); };

        }

        void AddInternal(GenGridItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((GenGridItem)sender);
        }
    }
}
