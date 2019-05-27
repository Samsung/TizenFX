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

            /// <summary>
            /// The MoreOption is a widget composed of the toggle (cue button) and more option view that can change a visibility through the toggle.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class MoreOption : Efl.Ui.Layout
            {
                const string IconPartName = "selector,icon";
                const string ContentPartName = "selector,content";
                const string BgPartName = "selector,bg_image";

                const string ItemSelectedEventName = "item,selected";
                const string ItemClickedEventName = "item,clicked";

                readonly List<MoreOptionItem> Items = new List<MoreOptionItem>();

                /// <summary>
                /// Clicked will be triggered when the user selects the already selected item again or selects a selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<MoreOptionItemEventArgs> Clicked;

                /// <summary>
                /// Selected will be triggered when the user selects an item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<MoreOptionItemEventArgs> Selected;

                private Interop.Evas.SmartCallback smartClicked;
                private Interop.Evas.SmartCallback smartSelected;

                /// <summary>
                /// Creates and initializes a new instance of the MoreOption class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new MoreOption will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public MoreOption(Efl.Ui.Widget parent) : base(Interop.Eext.eext_more_option_add(parent.NativeHandle))
                {
                    smartClicked = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        MoreOptionItem clickedItem = FindItemByNativeHandle(e);
                        if (clickedItem != null)
                            Clicked?.Invoke(this, new MoreOptionItemEventArgs { item = clickedItem });
                    });

                    smartSelected = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        MoreOptionItem selectedItem = FindItemByNativeHandle(e);
                        if (selectedItem != null)
                            Selected?.Invoke(this, new MoreOptionItemEventArgs { item = selectedItem });
                    });

                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemClickedEventName, smartClicked, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemSelectedEventName, smartSelected, IntPtr.Zero);
                }

                private MoreOptionItem FindItemByNativeHandle(IntPtr handle)
                {
                    foreach (MoreOptionItem item in Items)
                    {
                        if (item.NativeHandle == handle)
                            return item;
                    }

                    return null;
                }

                /// <summary>
                /// Sets or gets the edit mode of more option.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool EditMode
                {
                    get
                    {
                        return Interop.Eext.eext_more_option_editing_enabled_get(this.NativeHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_more_option_editing_enabled_set(this.NativeHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the add item mode of more option.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool AddItemMode
                {
                    get
                    {
                        return Interop.Eext.eext_more_option_add_item_enabled_get(this.NativeHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_more_option_add_item_enabled_set(this.NativeHandle, value);
                    }
                }

                /// <summary>
                /// Appends a more option item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Append(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        Items.Add(item);
                        item.NativeHandle = Interop.Eext.eext_more_option_item_append(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Prepends a more option item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void PrependItem(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        Items.Insert(0, item);
                        item.NativeHandle = Interop.Eext.eext_more_option_item_prepend(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Inserts a more option item after the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertAfter(MoreOptionItem targetItem, MoreOptionItem item)
                {
                    if (item.NativeHandle != null && targetItem != null)
                    {
                        if (!Items.Contains(targetItem)) return;
                        Items.Insert(Items.IndexOf(targetItem) + 1, item);
                        item.NativeHandle = Interop.Eext.eext_more_option_item_insert_after(this.NativeHandle, targetItem.NativeHandle);
                    }
                }

                /// <summary>
                /// Inserts a more option item before the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertBefore(MoreOptionItem targetItem, MoreOptionItem item)
                {
                    if (item.NativeHandle != null && targetItem != null)
                    {
                        if (!Items.Contains(targetItem)) return;
                        Items.Insert(Items.IndexOf(targetItem), item);
                        item.NativeHandle = Interop.Eext.eext_more_option_item_insert_before(this.NativeHandle, targetItem.NativeHandle);
                    }
                }

                /// <summary>
                /// Delete a more option item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void DeleteItem(MoreOptionItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        if (!Items.Contains(item)) return;
                        Items.Remove(item);
                        Interop.Eext.eext_more_option_item_del(item.NativeHandle);
                    }
                }

                /// <summary>
                /// Clears all items of more option.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void ClearItems()
                {
                    if (this.NativeHandle != null)
                    {
                        Items.Clear();
                        Interop.Eext.eext_more_option_items_clear(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Sets or gets the direction of more option.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Sets or gets the visibility of the more option view.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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

                /// <summary>
                /// Enumeration for the more option direction types.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
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
