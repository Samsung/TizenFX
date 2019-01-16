/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;

namespace ElmSharp
{
    /// <summary>
    /// The type of the item's part types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Flags]
    public enum GenListItemFieldType
    {
        /// <summary>
        /// All item's parts.
        /// </summary>
        All = 0,

        /// <summary>
        /// The Text part type.
        /// </summary>
        Text = (1 << 0),

        /// <summary>
        /// The Content part type.
        /// </summary>
        Content = (1 << 1),

        /// <summary>
        /// The State part type.
        /// </summary>
        State = (1 << 2),

        /// <summary>
        /// No part type.
        /// </summary>
        None = (1 << 3)
    };

    /// <summary>
    /// It inherits <see cref="GenItem"/>.
    /// A instance to the genlist item is added.
    /// It contains the Update() method to update a genlist item which is given.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenListItem : GenItem
    {
        internal GenListItem(object data, GenItemClass itemClass) : base(data, itemClass)
        {
        }

        internal GenListItem(EvasObject parent, object data, GenItemClass itemClass) : base(parent, data, itemClass)
        {
        }

        /// <summary>
        /// Gets or sets whether a given genlist item is selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_selected_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets whether a given genlist item is expanded.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsExpanded
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_expanded_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_expanded_set(Handle, value);
            }
        }

        /// <summary>
        /// Updates the content of an item.
        /// This updates an item by calling all <see cref="GenItemClass"/> again to get the content, text, and states.
        /// Use this when the original item data has changed and the changes are desired to reflect.
        /// To update the already realized items, use <see cref="GenList.UpdateRealizedItems"/>.
        /// </summary>
        /// <seealso cref="GenList.UpdateRealizedItems"/>
        /// <since_tizen> preview </since_tizen>
        public override void Update()
        {
            Interop.Elementary.elm_genlist_item_update(Handle);
        }

        /// <summary>
        /// Updates the part of an item.
        /// This updates an item's part by calling the item's fetching functions again to get the contents, texts, and states.
        /// Use this when the original item data has changed and the changes are desired to be reflected.
        /// To update an item's all property, use <see cref="GenList.UpdateRealizedItems"/>.
        /// </summary>
        /// <param name="part">The part could be "elm.text", "elm.swalllow.icon", "elm.swallow.end", "elm.swallow.content", and so on. It is also used for globbing to match '*', '?', and '.'. It can be used for updating multi-fields.</param>
        /// <param name="type">The type of the item's part type.</param>
        /// <seealso cref="GenList.UpdateRealizedItems"/>
        /// <since_tizen> preview </since_tizen>
        public void UpdateField(string part, GenListItemFieldType type)
        {
            Interop.Elementary.elm_genlist_item_fields_update(Handle, part, (uint)type);
        }

        /// <summary>
        /// Demotes an item to the end of the list.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void DemoteItem()
        {
            Interop.Elementary.elm_genlist_item_demote(Handle);
        }

        /// <summary>
        /// Gets or sets the genlist item's select mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override GenItemSelectionMode SelectionMode
        {
            get
            {
                return (GenItemSelectionMode)Interop.Elementary.elm_genlist_item_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_select_mode_set(Handle, (Interop.Elementary.Elm_Object_Select_Mode)value);
            }
        }

        /// <summary>
        /// Gets the next item in a genlist widget's internal list of items.
        /// </summary>
        /// <seealso cref="Previous"/>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Next
        {
            get
            {
                IntPtr next = Interop.Elementary.elm_genlist_item_next_get(Handle);
                if (next == IntPtr.Zero)
                    return null;
                else
                    return GetItemByHandle(next) as GenListItem;
            }
        }

        /// <summary>
        /// Gets the previous item in a genlist widget's internal list of items.
        /// </summary>
        /// <seealso cref="Next"/>
        /// <since_tizen> preview </since_tizen>
        public GenListItem Previous
        {
            get
            {
                IntPtr prev = Interop.Elementary.elm_genlist_item_prev_get(Handle);
                if (prev == IntPtr.Zero)
                    return null;
                else
                    return GetItemByHandle(prev) as GenListItem;
            }
        }

        /// <summary>
        /// Sets or gets the content to be shown in the tooltip item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Cursor
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_cursor_get(Handle);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Interop.Elementary.elm_genlist_item_cursor_set(Handle, value);
                }
                else
                {
                    Interop.Elementary.elm_genlist_item_cursor_unset(Handle);
                }
            }
        }

        /// <summary>
        /// Sets or gets the style for this item cursor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string CursorStyle
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_cursor_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_cursor_style_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the cursor engine only usage for this item cursor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsUseEngineCursor
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_cursor_engine_only_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_cursor_engine_only_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets the text to be shown in the genlist item.
        /// </summary>
        /// <param name="tooltip">The text to set in the content.</param>
        /// <since_tizen> preview </since_tizen>
        public override void SetTooltipText(string tooltip)
        {
            Interop.Elementary.elm_genlist_item_tooltip_text_set(Handle, tooltip);
        }

        /// <summary>
        /// Unsets the tooltip from the item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override void UnsetTooltip()
        {
            Interop.Elementary.elm_genlist_item_tooltip_unset(Handle);
        }

        /// <summary>
        /// Gets or sets the style of the given genlist item's tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override string TooltipStyle
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_tooltip_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_tooltip_style_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the disable size restrictions on an object's tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsTooltipWindowMode
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_tooltip_window_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_tooltip_window_mode_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets the index of the item. It is only valid, once displayed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Index
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_index_get(Handle);
            }
        }

        /// <summary>
        /// Gets the depth of the expanded item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int ExpandedItemDepth
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_expanded_depth_get(Handle);
            }
        }

        /// <summary>
        /// Remove all the subitems (children) of the given item.
        /// </summary>
        /// <remarks>
        /// This removes the items that are the children (and their descendants) of the given item.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void ClearSubitems()
        {
            Interop.Elementary.elm_genlist_item_subitems_clear(Handle);
        }

        /// <summary>
        /// Updates the item class of the item.
        /// This sets another class of the item, changing the way that it is displayed. After changing the item class, <see cref="Update"/> is called on the item.
        /// </summary>
        /// <param name="itemClass">The item class for the item.</param>
        /// <param name="data">The data for the item.</param>
        /// <since_tizen> preview </since_tizen>
        public void UpdateItemClass(GenItemClass itemClass, object data)
        {
            Data = data;
            ItemClass = itemClass;
            Interop.Elementary.elm_genlist_item_item_class_update((IntPtr)Handle, itemClass.UnmanagedPtr);
        }

        /// <summary>
        /// Sets the content to be shown in the tooltip item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void UpdateTooltipDelegate()
        {
            Interop.Elementary.elm_genlist_item_tooltip_content_cb_set(Handle,
                TooltipContentDelegate != null ? _tooltipCb : null,
                IntPtr.Zero,
                null);
        }
    }
}