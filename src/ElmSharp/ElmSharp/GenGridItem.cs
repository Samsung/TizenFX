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
    /// It inherits <see cref="GenItem"/>.
    /// A instance to the gengrid item added.
    /// It contains Update() method to update a gengrid item which is given.
    /// </summary>
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
        /// Gets or sets the style of given gengrid item's tooltip.
        /// </summary>
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
        /// Gets or sets gengrid item's row position, relative to the whole gengrid's grid area.
        /// </summary>
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
        /// Gets or sets gengrid item's column position, relative to the whole gengrid's grid area.
        /// </summary>
        public int Column
        {
            get
            {
                int row, column;
                Interop.Elementary.elm_gengrid_item_pos_get(Handle, out row, out column);
                return column;
            }
        }

        public override void SetTooltipText(string tooltip)
        {
            Interop.Elementary.elm_gengrid_item_tooltip_text_set(Handle, tooltip);
        }

        public override void UnsetTooltip()
        {
            Interop.Elementary.elm_gengrid_item_tooltip_unset(Handle);
        }

        /// <summary>
        /// Updates the content of a given gengrid item.
        /// This updates an item by calling all the genitem class functions again to get the content, text, and states.
        /// Use this when the original item data has changed and you want the changes to reflect.
        /// </summary>
        /// <remarks>
        /// <see cref="GenGrid.UpdateRealizedItems"/> to update the contents of all the realized items.
        /// </remarks>
        public override void Update()
        {
            Interop.Elementary.elm_gengrid_item_update(Handle);
        }

        protected override void UpdateTooltipDelegate()
        {
            Interop.Elementary.elm_gengrid_item_tooltip_content_cb_set(Handle,
                TooltipContentDelegate != null ? _tooltipCb : null,
                IntPtr.Zero,
                null);
        }
    }
}