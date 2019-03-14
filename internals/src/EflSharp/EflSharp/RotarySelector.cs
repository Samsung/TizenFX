using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public class RotarySelectorItemEventArgs : EventArgs
            {
                public RotarySelectorItem item { get; set; }
            }

            public class RotarySelector : Efl.Ui.Layout
            {
                const string IconPartName = "selector,icon";
                const string ContentPartName = "selector,content";
                const string BgPartName = "selector,bg_image";

                const string ItemSelectedEventName = "item,selected";
                const string ItemClickedEventName = "item,clicked";

                Image _normalBgImage;

                public event EventHandler<RotarySelectorItemEventArgs> Clicked;
                public event EventHandler<RotarySelectorItemEventArgs> Selected;

                public RotarySelector(Efl.Ui.Widget parent) : base(Interop.Eext.eext_rotary_selector_add(parent.NativeHandle))
                {
                    Interop.Evas.SmartCallback _smartClicked = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        RotarySelectorItem clickedItem = new RotarySelectorItem();
                        clickedItem._handle = e;
                        Clicked?.Invoke(this, new RotarySelectorItemEventArgs { item = clickedItem});
                    });

                    Interop.Evas.SmartCallback _smartSelected = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        Selected?.Invoke(this, new RotarySelectorItemEventArgs { item = this.SelectedItem });
                    });

                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemClickedEventName, _smartClicked, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemSelectedEventName, _smartSelected, IntPtr.Zero);
                }

                public void Append(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_append(this.NativeHandle);
                }

                public void Prepend(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_prepend(this.NativeHandle);
                }

                public void InsertAfter(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                    item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_after(this.NativeHandle, targetItem.NativeHandle);
                }

                public void InsertBefore(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_before(this.NativeHandle, targetItem.NativeHandle);
                }

                public void DeleteItem(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      Interop.Eext.eext_rotary_selector_item_del(item.NativeHandle);
                }

                public void ClearItems()
                {
                    if (this.NativeHandle != null)
                      Interop.Eext.eext_rotary_selector_items_clear(this.NativeHandle);
                }

                public RotarySelectorItem SelectedItem
                {
                    get
                    {
                        RotarySelectorItem item = new RotarySelectorItem();
                        item.NativeHandle = Interop.Eext.eext_rotary_selector_selected_item_get(this.NativeHandle);
                        return item;
                    }
                    set
                    {
                        Interop.Eext.eext_rotary_selector_selected_item_set(this.NativeHandle, value.NativeHandle);
                    }
                }

                void SetPart(string partName, State state, Image img)
                {
                    if (img != null)
                        Interop.Eext.eext_rotary_selector_part_content_set(this.NativeHandle, partName, (int)state, img.NativeHandle);
                }

                public Image BackgroundImage
                {
                    get
                    {
                        return _normalBgImage;
                    }
                    set
                    {
                        _normalBgImage = value;
                        SetPart(BgPartName, State.Normal, value);
                    }
                }

                internal enum State
                {
                    Normal,
                    Pressed
                }
            }
        }
    }
}
