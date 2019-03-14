using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class MoreOptionItemEventArgs : EventArgs
            {
                public MoreOptionItem item { get; set; }
            }

            public class MoreOption : Efl.Ui.Layout
            {
                const string IconPartName = "selector,icon";
                const string ContentPartName = "selector,content";
                const string BgPartName = "selector,bg_image";

                const string ItemSelectedEventName = "item,selected";
                const string ItemClickedEventName = "item,clicked";

                public event EventHandler<MoreOptionItemEventArgs> Clicked;
                public event EventHandler<MoreOptionItemEventArgs> Selected;

                public MoreOption(Efl.Ui.Widget parent) : base(Interop.Eext.eext_more_option_add(parent.NativeHandle))
                {
                    Interop.Evas.SmartCallback _smartClicked = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        MoreOptionItem clickedItem = new MoreOptionItem();
                        clickedItem._handle = e;
                        Clicked?.Invoke(this, new MoreOptionItemEventArgs { item = clickedItem });
                    });

                    Interop.Evas.SmartCallback _smartSelected = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        MoreOptionItem selectedItem = new MoreOptionItem();
                        selectedItem._handle = e;
                        Selected?.Invoke(this, new MoreOptionItemEventArgs { item = selectedItem });
                    });

                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemClickedEventName, _smartClicked, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemSelectedEventName, _smartSelected, IntPtr.Zero);
                }

                public void Append(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_more_option_item_append(this.NativeHandle);
                }

                public void PrependItem(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_more_option_item_prepend(this.NativeHandle);
                }

                public void InsertAfter(MoreOptionItem targetItem, MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_more_option_item_insert_after(this.NativeHandle, targetItem.NativeHandle);
                }

                public void InsertBefore(MoreOptionItem targetItem, MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_more_option_item_insert_before(this.NativeHandle, targetItem.NativeHandle);
                }

                public void DeleteItem(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                      Interop.Eext.eext_more_option_item_del(item.NativeHandle);
                }

                public void ClearItems()
                {
                    if (this.NativeHandle != null)
                      Interop.Eext.eext_more_option_items_clear(this.NativeHandle);
                }

                public MoreOptionDirection Direction
                {
                    get
                    {
                        int dir = Interop.Eext.eext_more_option_direction_get(this.NativeHandle);
                        return (MoreOptionDirection)dir;
                    }

                    set
                    {
                        Interop.Eext.eext_more_option_direction_set(this.NativeHandle, (int)value);
                    }
                }

                public bool IsOpened
                {
                    get
                    {
                        return Interop.Eext.eext_more_option_opened_get(this.NativeHandle);
                    }

                    set
                    {
                        Interop.Eext.eext_more_option_opened_set(this.NativeHandle, value);
                    }
                }

                public enum MoreOptionDirection
                {
                    Top,
                    Bottom,
                    Left,
                    Right
                }
            }
        }
    }
}
