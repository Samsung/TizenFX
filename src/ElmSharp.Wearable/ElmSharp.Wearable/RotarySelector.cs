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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The RotarySelector is a widget to display a selector and multiple items surrounding the selector.
    /// An item can be selected by the Rotary event or user item click.
    /// Inherits <see cref="Layout"/>.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class RotarySelector : Layout
    {
        const string IconPartName = "selector,icon";
        const string ContentPartName = "selector,content";
        const string BgPartName = "selector,bg_image";

        const string ItemSelectedEventName = "item,selected";
        const string ItemClickedEventName = "item,clicked";

        /// <summary>
        /// Selected will be triggered when selecting an item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<RotarySelectorItemEventArgs> Selected;

        /// <summary>
        /// Clicked will be triggered when selecting again the already selected item or selecting a selector.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<RotarySelectorItemEventArgs> Clicked;

        SmartEvent<PointerEventArgs> _selectedEvent;
        SmartEvent<PointerEventArgs> _clickedEvent;
        Image _normalBgImage;

        /// <summary>
        /// Gets the rotary selector item list of a rotary selector object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IList<RotarySelectorItem> Items { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the Rotary Selector class.
        /// </summary>
        /// <param name="parent">The parent of the new Rotary Selector instance.</param>
        /// <since_tizen> preview </since_tizen>
        public RotarySelector(EvasObject parent) : base(parent)
        {
            Items = new RotarySelectorList(this);

            _selectedEvent = new SmartEvent<PointerEventArgs>(this, "item,selected", (d, o, info) => new PointerEventArgs { Pointer = info });
            _clickedEvent = new SmartEvent<PointerEventArgs>(this, "item,clicked", (d, o, info) => new PointerEventArgs { Pointer = info });
            _selectedEvent.On += (s, e) =>
            {
                RotarySelectorItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Selected?.Invoke(this, new RotarySelectorItemEventArgs { Item = selected });
            };

            _clickedEvent.On += (s, e) =>
            {
                RotarySelectorItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Clicked?.Invoke(this, new RotarySelectorItemEventArgs { Item = selected });
            };
        }

        /// <summary>
        /// Sets or gets the selected item of a rotary selector object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public RotarySelectorItem SelectedItem
        {
            get
            {
                IntPtr selectedPtr = Interop.Eext.eext_rotary_selector_selected_item_get(this);
                if (selectedPtr == IntPtr.Zero) return null;
                RotarySelectorItem item = Items.FirstOrDefault(i => i.Handle == selectedPtr);
                return item;
            }

            set
            {
                if (!Items.Contains(value)) return;
                Interop.Eext.eext_rotary_selector_selected_item_set(this, value.Handle);
            }
        }

        void setPart(ref Image prop, string partName, State state, Image img)
        {
            if (prop == img) return;
            prop = img;
            if (this != null)
            {
                Interop.Eext.eext_rotary_selector_part_content_set(this, partName, (int)state, prop);
            }
        }
        void setPart(ref Color prop, string partName, State state, Color color)
        {
            if (prop == color) return;
            if (this != null)
            {
                Interop.Eext.eext_rotary_selector_part_color_set(this, partName, (int)state, color.R, color.G, color.B, color.A);
            }
        }

        /// <summary>
        /// Sets or gets the background image of a rotary selector object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Image BackgroundImage { set => setPart(ref _normalBgImage, BgPartName, State.Normal, value); get => _normalBgImage; }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr ptr = Interop.Eext.eext_rotary_selector_add(parent);
            Interop.Eext.eext_rotary_object_event_activated_set(ptr, true);
            return ptr;
        }

        internal enum State
        {
            Normal,
            Pressed
        }
    }
}
