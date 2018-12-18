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
    /// Enumeration for the ContextPopup direction types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ContextPopupDirection
    {
        /// <summary>
        /// The ContextPopup appears below the clicked area.
        /// /// </summary>
        Down,
        /// <summary>
        /// The ContextPopup appears to the right of the clicked area.
        /// </summary>
        Right,
        /// <summary>
        /// The ContextPopup appears to the left of the clicked area.
        /// </summary>
        Left,
        /// <summary>
        /// The ContextPopup appears above the clicked area.
        /// </summary>
        Up,
        /// <summary>
        /// The ContextPopup does not determine it's direction yet.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// It inherits <see cref="Layout"/>.
    /// The ContextPopup is a widget that when shown, pops up a list of items.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ContextPopup : Layout
    {
        HashSet<ContextPopupItem> _children = new HashSet<ContextPopupItem>();
        SmartEvent _dismissed;
        Interop.Evas.SmartCallback _onSelected;

        /// <summary>
        /// Creates and initializes a new instance of the ContextPopup class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by ContextPopup
        /// as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public ContextPopup(EvasObject parent) : base(parent)
        {
            _dismissed = new SmartEvent(this, this.RealHandle, "dismissed");
            _dismissed.On += (sender, e) =>
            {
                Dismissed?.Invoke(this, EventArgs.Empty);
            };
            _onSelected = (data, obj, info) =>
            {
                ContextPopupItem item = ItemObject.GetItemById((int)data) as ContextPopupItem;
                item?.SendSelected();
            };
        }

        /// <summary>
        /// Dismissed is raised when the ContextPopup item is dismissed.
        /// </summary>
        /// <remarks>
        /// Outside of ContextPopup is clicked or it's parent area is changed or the language is changed, and then ContextPopup is dismissed.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Dismissed;

        /// <summary>
        /// Gets the current direction of a ContextPopup.
        /// </summary>
        /// <remarks>
        /// Once the ContextPopup shows up, the direction would be determined.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public ContextPopupDirection Direction
        {
            get
            {
                return (ContextPopupDirection)Interop.Elementary.elm_ctxpopup_direction_get(RealHandle);
            }
        }

        /// <summary>
        /// Gets or sets the value of the current ContextPopup object's orientation.
        /// True for horizontal mode, False for vertical mode (or errors).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_ctxpopup_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_ctxpopup_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Gets or sets whether the ContextPopup hides automatically
        /// or not when the parent of the ContextPopup is resized.
        /// </summary>
        /// <remarks>
        /// Default value of AutoHide is False.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public bool AutoHide
        {
            get
            {
                return !Interop.Elementary.elm_ctxpopup_auto_hide_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_ctxpopup_auto_hide_disabled_set(RealHandle, !value);
            }
        }

        /// <summary>
        /// Clears all the items in a given ContextPopup object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_ctxpopup_clear(Handle);
        }

        /// <summary>
        /// Sets the direction priority of a ContextPopup.
        /// </summary>
        /// <param name="first">1st priority of the direction.</param>
        /// <param name="second">2nd priority of the direction.</param>
        /// <param name="third">3th priority of the direction.</param>
        /// <param name="fourth">4th priority of the direction.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetDirectionPriorty(ContextPopupDirection first, ContextPopupDirection second, ContextPopupDirection third, ContextPopupDirection fourth)
        {
            Interop.Elementary.elm_ctxpopup_direction_priority_set(RealHandle, (int)first, (int)second, (int)third, (int)fourth);
        }

        /// <summary>
        /// Gets the direction priority of a ContextPopup.
        /// </summary>
        /// <param name="first">1st priority of the direction to be returned.</param>
        /// <param name="second">2nd priority of the direction to be returned.</param>
        /// <param name="third">2nd priority of the direction to be returned.</param>
        /// <param name="fourth">4th priority of the direction to be returned.</param>
        /// <since_tizen> preview </since_tizen>
        public void GetDirectionPriority(out ContextPopupDirection first, out ContextPopupDirection second, out ContextPopupDirection third, out ContextPopupDirection fourth)
        {
            int firstOut, secondOut, thirdOut, fourthOut;
            Interop.Elementary.elm_ctxpopup_direction_priority_get(Handle, out firstOut, out secondOut, out thirdOut, out fourthOut);
            first = (ContextPopupDirection)firstOut;
            second = (ContextPopupDirection)secondOut;
            third = (ContextPopupDirection)thirdOut;
            fourth = (ContextPopupDirection)fourthOut;
        }

        /// <summary>
        /// Adds a new item to a ContextPopup object with the label.
        /// </summary>
        /// <param name="label">Label of the new item.</param>
        /// <returns>
        /// A ContextPopupItem added, or null on errors.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public ContextPopupItem Append(string label)
        {
            return Append(label, null);
        }

        /// <summary>
        /// Adds a new item to a ContextPopup object with the label and icon.
        /// </summary>
        /// <param name="label">Label of the new item.</param>
        /// <param name="icon">Icon to be set on the new item.</param>
        /// <returns>A ContextPopupItem added, or null on errors.</returns>
        /// <since_tizen> preview </since_tizen>
        public ContextPopupItem Append(string label, EvasObject icon)
        {
            ContextPopupItem item = new ContextPopupItem(label, icon);
            item.Handle = Interop.Elementary.elm_ctxpopup_item_append(RealHandle, label, icon, _onSelected, (IntPtr)item.Id);
            AddInternal(item);
            return item;
        }

        /// <summary>
        /// Dismisses a ContextPopup object. The ContextPopup will be hidden and the "clicked" signal will be emitted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dismiss()
        {
            Interop.Elementary.elm_ctxpopup_dismiss(RealHandle);
        }

        /// <summary>
        /// Gets the possibility that the direction would be available.
        /// </summary>
        /// <param name="direction">A direction that the user wants to check.</param>
        /// <returns>
        /// Get false if you cannot put it in the direction. Get true if it's possible.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public bool IsAvailableDirection(ContextPopupDirection direction)
        {
            return Interop.Elementary.elm_ctxpopup_direction_available_get(RealHandle, (int)direction);
        }

        /// <summary>
        /// Gets the Alpha of a default Color class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }

            set
            {
                Console.WriteLine("ContextPopup instance doesn't support to set Opacity.");
            }
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_ctxpopup_add(parent.Handle);
        }

        void AddInternal(ContextPopupItem item)
        {
            _children.Add(item);
            item.Deleted += Item_Deleted;
        }

        void Item_Deleted(object sender, EventArgs e)
        {
            _children.Remove((ContextPopupItem)sender);
        }
    }
}
