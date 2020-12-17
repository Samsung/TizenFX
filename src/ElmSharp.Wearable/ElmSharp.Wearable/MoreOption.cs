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

namespace ElmSharp.Wearable
{
    /// <summary>
    /// The MoreOption is a widget composed of the toggle (cue button) and more option view that can change a visibility through the toggle.
    /// Inherits Layout
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class MoreOption : Layout
    {
        /// <summary>
        /// Sets or gets the list of the more option item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public IList<MoreOptionItem> Items { get; private set; }

        /// <summary>
        /// Selected will be triggered when the user selects an item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MoreOptionItemEventArgs> Selected;
        /// <summary>
        /// Clicked will be triggered when the user selects the already selected item again or selects a selector.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<MoreOptionItemEventArgs> Clicked;
        /// <summary>
        /// Opened will be triggered when the more option view is shown.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Opened;
        /// <summary>
        /// Closed will be triggered when the more option view is hidden.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Closed;

        SmartEvent<PointerEventArgs> _selectedEvent;
        SmartEvent<PointerEventArgs> _clickedEvent;
        SmartEvent _openedEvent;
        SmartEvent _closedEvent;

        /// <summary>
        /// Creates and initializes a new instance of the MoreOption class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by the MoreOption as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public MoreOption(EvasObject parent) : base(parent)
        {
            Items = new MoreOptionList(this);

            _selectedEvent = new SmartEvent<PointerEventArgs>(this, "item,selected", (d, o, info) => new PointerEventArgs { Pointer = info });
            _clickedEvent = new SmartEvent<PointerEventArgs>(this, "item,clicked", (d, o, info) => new PointerEventArgs { Pointer = info });
            _openedEvent = new SmartEvent(this, "more,option,opened");
            _closedEvent = new SmartEvent(this, "more,option,closed");

            _selectedEvent.On += (s, e) =>
            {
                MoreOptionItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Selected?.Invoke(this, new MoreOptionItemEventArgs() { Item = selected });
            };

            _clickedEvent.On += (s, e) =>
            {
                MoreOptionItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Clicked?.Invoke(this, new MoreOptionItemEventArgs() { Item = selected });
            };

            _openedEvent.On += (s, e) => Opened?.Invoke(this, EventArgs.Empty);
            _closedEvent.On += (s, e) => Closed?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Eext.eext_more_option_add(parent);
        }

        /// <summary>
        /// Sets or gets the direction of more option.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public MoreOptionDirection Direction
        {
            get
            {
                int dir = Interop.Eext.eext_more_option_direction_get(this);
                return (MoreOptionDirection)dir;
            }

            set
            {
                Interop.Eext.eext_more_option_direction_set(this, (int)value);
            }
        }

        /// <summary>
        /// Sets or gets the visibility of the more option view.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsOpened
        {
            get
            {
                return Interop.Eext.eext_more_option_opened_get(this);
            }

            set
            {
                Interop.Eext.eext_more_option_opened_set(this, value);
            }
        }
    }

    /// <summary>
    /// Enumeration for the more option direction types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum MoreOptionDirection
    {
        /// <summary>
        /// Top direction.
        /// </summary>
        Top,
        /// <summary>
        /// Bottom direction.
        /// </summary>
        Bottom,
        /// <summary>
        /// Left direction.
        /// </summary>
        Left,
        /// <summary>
        /// Right direction.
        /// </summary>
        Right
    }
}
