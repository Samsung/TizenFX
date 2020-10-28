using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {

            /// <summary>
            /// The event argument of Rotary Selector.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class RotarySelectorItemEventArgs : EventArgs
            {
                public RotarySelectorItem item { get; set; }
            }

            /// <summary>
            /// The RotarySelector is a widget to display a selector and multiple items surrounding the selector.
            /// An item can be selected by the Rotary event or user item click.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class RotarySelector : Efl.Ui.Layout
            {
                const string IconPartName = "selector,icon";
                const string ContentPartName = "selector,content";
                const string BgPartName = "selector,bg_image";

                const string ItemSelectedEventName = "item,selected";
                const string ItemClickedEventName = "item,clicked";

                Image _normalBgImage;

                /// <summary>
                /// Clicked will be triggered when selecting again the already selected item or selecting a selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemEventArgs> Clicked;

                /// <summary>
                /// Selected will be triggered when selecting an item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemEventArgs> Selected;

                private Interop.Evas.SmartCallback smartClicked;
                private Interop.Evas.SmartCallback smartSelected;

                /// <summary>
                /// Creates and initializes a new instance of the RotarySelector class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new RotarySelector will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public RotarySelector(Efl.Ui.Widget parent) : base(Interop.Eext.eext_rotary_selector_add(parent.NativeHandle))
                {
                    smartClicked = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        RotarySelectorItem clickedItem = new RotarySelectorItem();
                        clickedItem._handle = e;
                        Clicked?.Invoke(this, new RotarySelectorItemEventArgs { item = clickedItem});
                    });

                    smartSelected = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        Selected?.Invoke(this, new RotarySelectorItemEventArgs { item = this.SelectedItem });
                    });

                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemClickedEventName, smartClicked, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemSelectedEventName, smartSelected, IntPtr.Zero);
                }

                /// <summary>
                /// Appends a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Append(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_append(this.NativeHandle);
                }

                /// <summary>
                /// Prepends a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Prepend(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_prepend(this.NativeHandle);
                }

                /// <summary>
                /// Inserts a rotary selector item after the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertAfter(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                    item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_after(this.NativeHandle, targetItem.NativeHandle);
                }

                /// <summary>
                /// Inserts a rotary selector item before the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertBefore(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_before(this.NativeHandle, targetItem.NativeHandle);
                }

                /// <summary>
                /// Delete a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void DeleteItem(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                      Interop.Eext.eext_rotary_selector_item_del(item.NativeHandle);
                }

                /// <summary>
                /// Clears all items of rotary selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void ClearItems()
                {
                    if (this.NativeHandle != null)
                      Interop.Eext.eext_rotary_selector_items_clear(this.NativeHandle);
                }

                /// <summary>
                /// Sets or gets the selected item of a rotary selector object.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the background image of a rotary selector object.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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
