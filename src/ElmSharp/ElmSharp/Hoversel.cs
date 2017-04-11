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

namespace ElmSharp
{
    /// <summary>
    /// The HoverselItemEventArgs is an HoverselItem's EventArgs
    /// </summary>
    public class HoverselItemEventArgs : EventArgs
    {
        /// <summary>
        /// Hoversel's Item
        /// </summary>
        public HoverselItem Item { get; set; }

        internal static HoverselItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            HoverselItem item = ItemObject.GetItemByHandle(info) as HoverselItem;
            return new HoverselItemEventArgs() { Item = item };
        }
    }

    /// <summary>
    /// The hoversel is a button that pops up a list of items.
    /// </summary>
    public class Hoversel : Layout
    {
        SmartEvent _dismissed;
        SmartEvent<HoverselItemEventArgs> _selected;
        Interop.Evas.SmartCallback _onItemSelected;

        /// <summary>
        /// Creates and initializes a new instance of the Hoversel class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by Hoversel as a child. It's <see cref="EvasObject"/> type.</param>
        public Hoversel(EvasObject parent) : base(parent)
        {
            _dismissed = new SmartEvent(this, "dismissed");
            _dismissed.On += (sender, e) =>
            {
                Dismissed?.Invoke(this, EventArgs.Empty);
            };
            _selected = new SmartEvent<HoverselItemEventArgs>(this, RealHandle, "selected", HoverselItemEventArgs.CreateFromSmartEvent);
            _selected.On += (s, e) =>
            {
                if (e.Item != null) ItemSelected?.Invoke(this, e);
            };
            _onItemSelected = (data, obj, info) =>
            {
                HoverselItem item = ItemObject.GetItemById((int)data) as HoverselItem;
                item?.SendItemSelected();
            };
        }

        /// <summary>
        /// Dismissed will be triggered when Hoversel Dismissed
        /// </summary>
        public event EventHandler Dismissed;

        /// <summary>
        /// ItemSelected will be triggered when Hoversel's Item Selected
        /// </summary>
        public event EventHandler<HoverselItemEventArgs> ItemSelected;

        /// <summary>
        /// Gets or sets the status to control whether the hoversel should expand horizontally.
        /// </summary>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_hoversel_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets the hover parent.
        /// </summary>
        public IntPtr HoverParent
        {
            get
            {
                return Interop.Elementary.elm_hoversel_hover_parent_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_hover_parent_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets the flag of whether the hoversel is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return Interop.Elementary.elm_hoversel_expanded_get(RealHandle);
            }
        }

        /// <summary>
        /// Gets or sets the status of whether update icon and text of hoversel same to those of selected item automatically.
        /// </summary>
        public bool AutoUpdate
        {
            get
            {
                return Interop.Elementary.elm_hoversel_auto_update_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_auto_update_set(RealHandle, value);
            }
        }

        /// <summary>
        /// This triggers the hoversel popup from code, the same as if the user had clicked the button.
        /// </summary>
        public void HoverBegin()
        {
            Interop.Elementary.elm_hoversel_hover_begin(RealHandle);
        }

        /// <summary>
        /// This dismisses the hoversel popup as if the user had clicked outside the hover.
        /// </summary>
        public void HoverEnd()
        {
            Interop.Elementary.elm_hoversel_hover_end(RealHandle);
        }

        /// <summary>
        /// This will remove all the children items from the hoversel.
        /// </summary>
        public void Clear()
        {
            Interop.Elementary.elm_hoversel_clear(RealHandle);
        }

        /// <summary>
        /// Add an item to the hoversel button.
        /// This adds an item to the hoversel to show when it is clicked.
        /// </summary>
        /// <param name="label">Item's label</param>
        /// <returns>A handle to the added item.</returns>
        public HoverselItem AddItem(string label)
        {
            HoverselItem item = new HoverselItem();
            item.Label = label;
            item.Handle = Interop.Elementary.elm_hoversel_item_add(RealHandle, label, null, 0, _onItemSelected, (IntPtr)item.Id);
            return item;
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_hoversel_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
