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
            /// The event argument of Rotary Selector Reorder.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class RotarySelectorItemReorderedEventArgs : RotarySelectorItemEventArgs
            {
                public int NewIndex { get; internal set; }

                public int OldIndex { get; internal set; }
            }

            /// <summary>
            /// The event argument of Rotary Selector editing state.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            public class RotarySelectorEditingEventArgs : EventArgs
            {
                public bool editing { get; internal set; }
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
                const string ItemDeletedEventName = "item,deleted";
                const string ItemReorderedEventName = "item,reordered";
                const string EditingEnterEventName = "editing,entered";
                const string EditingLeaveEventName = "editing,exited";

                Image _normalBgImage;

                readonly List<RotarySelectorItem> Items = new List<RotarySelectorItem>();

                /// <summary>
                /// Clicked will be triggered when selecting again the already selected item or selecting a selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemEventArgs> ClickedEvent;

                /// <summary>
                /// Selected will be triggered when selecting an item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemEventArgs> SelectedEvent;

                /// <summary>
                /// Triggered when the user deleted the item
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemEventArgs> Deleted;

                /// <summary>
                /// Triggered when the user reordered the item
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorItemReorderedEventArgs> Reordered;

                /// <summary>
                /// Editing will be triggered when entering and leaving the editing state.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public event EventHandler<RotarySelectorEditingEventArgs> EditingStateChanged;

                private Interop.Evas.SmartCallback smartClicked;
                private Interop.Evas.SmartCallback smartSelected;
                private Interop.Evas.SmartCallback smartDeleted;
                private Interop.Evas.SmartCallback smartReordered;
                private Interop.Evas.SmartCallback smartEditingEnter;
                private Interop.Evas.SmartCallback smartEditingLeave;

                /// <summary>
                /// Creates and initializes a new instance of the RotarySelector class.
                /// </summary>
                /// <param name="parent">The Efl.Ui.Widget to which the new RotarySelector will be attached as a child.</param>
                /// <since_tizen> 6 </since_tizen>
                public RotarySelector(Efl.Object parent) : base(new Efl.Eo.Globals.WrappingHandle(Interop.Eext.eext_rotary_selector_add(parent.NativeHandle)))
                {
                    smartClicked = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        RotarySelectorItem clickedItem = FindItemByNativeHandle(e);
                        if (clickedItem != null)
                            ClickedEvent?.Invoke(this, new RotarySelectorItemEventArgs { item = clickedItem});
                    });

                    smartSelected = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        RotarySelectorItem selectedItem = FindItemByNativeHandle(e);
                        if (selectedItem != null)
                            SelectedEvent?.Invoke(this, new RotarySelectorItemEventArgs { item = selectedItem });
                    });

                    smartDeleted = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        RotarySelectorItem deletedItem = FindItemByNativeHandle(e);
                        if (deletedItem != null)
                            Deleted?.Invoke(this, new RotarySelectorItemEventArgs { item = deletedItem });
                        Items.Remove(deletedItem);
                    });

                    smartReordered = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        var items_list = Interop.Eext.eext_rotary_selector_items_get(this.NativeHandle);
                        int idx = Eina.ListNativeFunctions.eina_list_data_idx(items_list, e);
                        RotarySelectorItem reorderedItem = FindItemByNativeHandle(e);
                        if (reorderedItem != null)
                            Reordered?.Invoke(this, new RotarySelectorItemReorderedEventArgs
                            { item = reorderedItem, OldIndex = Items.IndexOf(reorderedItem), NewIndex = idx });
                        UpdateListOrder(reorderedItem, idx);
                    });

                    smartEditingEnter = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        EditingStateChanged?.Invoke(this, new RotarySelectorEditingEventArgs { editing = true});
                    });

                    smartEditingLeave = new Interop.Evas.SmartCallback((d, o, e) =>
                    {
                        EditingStateChanged?.Invoke(this, new RotarySelectorEditingEventArgs { editing = false });
                    });

                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemClickedEventName, smartClicked, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemSelectedEventName, smartSelected, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemDeletedEventName, smartDeleted, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, ItemReorderedEventName, smartReordered, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, EditingEnterEventName, smartEditingEnter, IntPtr.Zero);
                    Interop.Evas.evas_object_smart_callback_add(this.NativeHandle, EditingLeaveEventName, smartEditingLeave, IntPtr.Zero);
                }

                private void UpdateListOrder(RotarySelectorItem reorderedItem, int currentIdx)
                {
                    Items.Remove(reorderedItem);
                    Items.Insert(currentIdx, reorderedItem);
                }

                private RotarySelectorItem FindItemByNativeHandle(IntPtr handle)
                {
                    foreach(RotarySelectorItem item in Items)
                    {
                        if (item.NativeHandle == handle)
                            return item;
                    }

                    return null;
                }

                /// <summary>
                /// Sets or gets the edit mode of rotary selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool EditMode
                {
                    get
                    {
                        return Interop.Eext.eext_rotary_selector_editing_enabled_get(this.NativeHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_rotary_selector_editing_enabled_set(this.NativeHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the add item mode of rotary selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public bool AddItemMode
                {
                    get
                    {
                        return Interop.Eext.eext_rotary_selector_add_item_enabled_get(this.NativeHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_rotary_selector_add_item_enabled_set(this.NativeHandle, value);
                    }
                }

                /// <summary>
                /// Appends a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Append(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        Items.Add(item);
                        item.NativeHandle = Interop.Eext.eext_rotary_selector_item_append(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Prepends a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void Prepend(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        Items.Insert(0, item);
                        item.NativeHandle = Interop.Eext.eext_rotary_selector_item_prepend(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Inserts a rotary selector item after the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertAfter(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null && targetItem != null)
                    {
                        if (!Items.Contains(targetItem)) return;
                        Items.Insert(Items.IndexOf(targetItem) + 1, item);
                        item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_after(this.NativeHandle, targetItem.NativeHandle);
                    }
                }

                /// <summary>
                /// Inserts a rotary selector item before the target item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void InsertBefore(RotarySelectorItem targetItem, RotarySelectorItem item)
                {
                    if (item.NativeHandle != null && targetItem != null)
                    {
                        if (!Items.Contains(targetItem)) return;
                        Items.Insert(Items.IndexOf(targetItem), item);
                        item.NativeHandle = Interop.Eext.eext_rotary_selector_item_insert_before(this.NativeHandle, targetItem.NativeHandle);
                    }
                }

                /// <summary>
                /// Delete a rotary selector item.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void DeleteItem(RotarySelectorItem item)
                {
                    if (item.NativeHandle != null)
                    {
                        if (!Items.Contains(item)) return;
                        Items.Remove(item);
                        Interop.Eext.eext_rotary_selector_item_del(item.NativeHandle);
                    }
                }

                /// <summary>
                /// Clears all items of rotary selector.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public void ClearItems()
                {
                    if (this.NativeHandle != null)
                    {
                        Items.Clear();
                        Interop.Eext.eext_rotary_selector_items_clear(this.NativeHandle);
                    }
                }

                /// <summary>
                /// Sets or gets the selected item of a rotary selector object.
                /// </summary>
                /// <since_tizen> 6 </since_tizen>
                public RotarySelectorItem SelectedItem
                {
                    get
                    {
                        IntPtr nativeHandle = Interop.Eext.eext_rotary_selector_selected_item_get(this.NativeHandle);
                        RotarySelectorItem item = FindItemByNativeHandle(nativeHandle);
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
