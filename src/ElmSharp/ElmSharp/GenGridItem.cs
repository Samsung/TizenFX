/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// It inherits <see cref="GenItem"/>.
    /// An instance to the gengrid item is added.
    /// It contains the Update() method to update a gengrid item which is given.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenGridItem : GenItem
    {
        internal GenGridItem(object data, GenItemClass itemClass) : base(data, itemClass)
        {
        }

        /// <summary>
        /// Gets or sets whether a given gengrid item is selected.
        /// If one gengrid item is selected, any other previously selected items get unselected in favor of this new one.
        /// </summary>
        /// <remarks>
        /// If true, it is selected.
        /// If false, it is unselected.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_gengrid_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_selected_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the cursor to be shown when the mouse is over the gengrid item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Cursor
        {
            get
            {
                return Interop.Elementary.elm_gengrid_item_cursor_get(Handle);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Interop.Elementary.elm_gengrid_item_cursor_set(Handle, value);
                }
                else
                {
                    Interop.Elementary.elm_gengrid_item_cursor_unset(Handle);
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
                return Interop.Elementary.elm_gengrid_item_cursor_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_cursor_style_set(Handle, value);
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
                return Interop.Elementary.elm_gengrid_item_cursor_engine_only_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_cursor_engine_only_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets, or sets the style of the given gengrid item's tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override string TooltipStyle
        {
            get
            {
                return Interop.Elementary.elm_gengrid_item_tooltip_style_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_tooltip_style_set(Handle, value);
            }
        }

        /// <summary>
        /// Gets the gengrid item's select mode.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override GenItemSelectionMode SelectionMode
        {
            get
            {
                return (GenItemSelectionMode)Interop.Elementary.elm_gengrid_item_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gengrid_item_select_mode_set(Handle, (Interop.Elementary.Elm_Object_Select_Mode)value);
            }
        }

        /// <summary>
        /// Gets or sets the gengrid item's row position, relative to the whole gengrid's grid area.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Row
        {
            get
            {
                int row, column;
                Interop.Elementary.elm_gengrid_item_pos_get(Handle, out row, out column);
                return row;
            }
        }

        /// <summary>
        /// Gets or sets the gengrid item's column position, relative to the whole gengrid's grid area.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Column
        {
            get
            {
                int row, column;
                Interop.Elementary.elm_gengrid_item_pos_get(Handle, out row, out column);
                return column;
            }
        }

        /// <summary>
        /// Sets the text to be shown in the gengrid item.
        /// </summary>
        /// <param name="tooltip">The text to set.</param>
        /// <since_tizen> preview </since_tizen>
        public override void SetTooltipText(string tooltip)
        {
            Interop.Elementary.elm_gengrid_item_tooltip_text_set(Handle, tooltip);
        }

        /// <summary>
        /// Unsets the tooltip from item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override void UnsetTooltip()
        {
            Interop.Elementary.elm_gengrid_item_tooltip_unset(Handle);
        }

        /// <summary>
        /// Updates the content of a given gengrid item.
        /// This updates an item by calling all the GenItem class functions again to get the content, text, and states.
        /// Use this when the original item data has changed and you want the changes to reflect.
        /// </summary>
        /// <remarks>
        /// <see cref="GenGrid.UpdateRealizedItems"/> to update the contents of all the realized items.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public override void Update()
        {
            Interop.Elementary.elm_gengrid_item_update(Handle);
        }

        /// <summary>
        /// Sets the content to be shown in the tooltip item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void UpdateTooltipDelegate()
        {
            Interop.Elementary.elm_gengrid_item_tooltip_content_cb_set(Handle,
                TooltipContentDelegate != null ? _tooltipCb : null,
                IntPtr.Zero,
                null);
        }
    }
}