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

namespace ElmSharp
{
    /// <summary>
    /// The FlipSelector is a widget to show a set of text items, one at a time, with the same sheet switching style as the clock widget when one changes the current displaying sheet.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FlipSelector : Layout
    {
        SmartEvent _selected;
        SmartEvent _overflowed;
        SmartEvent _underflowed;

        /// <summary>
        /// Creates and initializes a new instance of the FlipSelector.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <since_tizen> preview </since_tizen>
        public FlipSelector(EvasObject parent) : base(parent)
        {
            _selected = new SmartEvent(this, Handle, "selected");
            _overflowed = new SmartEvent(this, Handle, "overflowed");
            _underflowed = new SmartEvent(this, Handle, "underflowed");

            _selected.On += SelectedChanged;
            _overflowed.On += OverflowedChanged;
            _underflowed.On += UnderflowedChanged;
        }

        /// <summary>
        /// Selected will be triggered when selected.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Selected;
        /// <summary>
        /// Overflowed will be triggered when overflowed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Overflowed;
        /// <summary>
        /// Underflowed will be triggered when underflowed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Underflowed;

        /// <summary>
        /// Sets or gets the interval on time updates for a user mouse button to hold on the flip selector widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Interval
        {
            get
            {
                return Interop.Elementary.elm_flipselector_first_interval_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_flipselector_first_interval_set(Handle, value);
            }
        }


        /// <summary>
        /// Gets the currently selected item in the flip selector widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem SelectedItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_selected_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        /// <summary>
        /// Gets the first item in the given flip selector widget's list of items.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem FirstItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_first_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        /// <summary>
        /// Gets the last item in the given flip selector widget's list of items.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem LastItem
        {
            get
            {
                IntPtr handle = Interop.Elementary.elm_flipselector_last_item_get(Handle);
                return ItemObject.GetItemByHandle(handle) as FlipSelectorItem;
            }
        }

        /// <summary>
        /// Appends the (text) item to the flip selector widget.
        /// </summary>
        /// <param name="text">text value</param>
        /// <returns>
        /// A handle to the item added, or null on errors.
        /// </returns>
        /// <remarks>
        /// The widget's list of labels to show will be appended with the given value. If the user wishes so, a callback function pointer can be passed, which will get called when the same item is selected.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem Append(string text)
        {
            FlipSelectorItem item = new FlipSelectorItem(text);
            item.Handle = Interop.Elementary.elm_flipselector_item_append(Handle, text, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// Prepends the (text) item to a flip selector widget.
        /// </summary>
        /// <param name="text">Prepend text</param>
        /// <returns>A handle to the item added, or null on errors.</returns>
        /// <remarks>
        /// The widget's list of labels to show will be prepended with the given value. If the user wishes so, a callback function pointer can be passed, which will get called when the same item is selected.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public FlipSelectorItem Prepend(string text)
        {
            FlipSelectorItem item = new FlipSelectorItem(text);
            item.Handle = Interop.Elementary.elm_flipselector_item_prepend(Handle, text, null, (IntPtr)item.Id);
            return item;
        }

        /// <summary>
        /// To remove the given item.
        /// </summary>
        /// <param name="item">FlipSelector's item.</param>
        /// <since_tizen> preview </since_tizen>
        public void Remove(FlipSelectorItem item)
        {
            if (item != null)
                item.Delete();
        }

        /// <summary>
        /// Programmatically select the next item of the flip selector widget.
        /// </summary>
        /// <remarks>
        /// The selection will be animated. Also, if it reaches the beginning of its list of member items, it will continue with the last one backwards.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void Next()
        {
            Interop.Elementary.elm_flipselector_flip_next(Handle);
        }

        /// <summary>
        /// Programmatically select the previous item of the flip selector widget.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Prev()
        {
            Interop.Elementary.elm_flipselector_flip_prev(Handle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_flipselector_add(parent.Handle);
        }

        void SelectedChanged(object sender, EventArgs e)
        {
            SelectedItem?.SendSelected();
            Selected?.Invoke(this, EventArgs.Empty);
        }

        void OverflowedChanged(object sender, EventArgs e)
        {
            Overflowed?.Invoke(this, e);
        }

        void UnderflowedChanged(object sender, EventArgs e)
        {
            Underflowed?.Invoke(this, e);
        }
    }
}
