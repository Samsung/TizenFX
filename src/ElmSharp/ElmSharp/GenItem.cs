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
    /// Enumeration for the selection modes of GenItem.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum GenItemSelectionMode
    {
        /// <summary>
        /// Default select mode.
        /// </summary>
        Default,

        /// <summary>
        /// Always select mode.
        /// </summary>
        Always,

        /// <summary>
        /// No select mode.
        /// </summary>
        None,

        /// <summary>
        /// No select mode with no finger size rule.
        /// </summary>
        DisplayOnly
    }

    /// <summary>
    /// It inherits <see cref="ItemObject"/>.
    /// A base class for <see cref="GenGridItem"/> and <see cref="GenListItem"/>.
    /// It contains the GenItem class and data to display the data.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class GenItem : ItemObject
    {
        internal Interop.Elementary.Elm_Tooltip_Item_Content_Cb _tooltipCb;
        GetTooltipContentDelegate _tooltipContentDelegate = null;

        /// <summary>
        /// The delegate returning the tooltip contents.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public delegate EvasObject GetTooltipContentDelegate();

        internal GenItem(EvasObject parent, object data, GenItemClass itemClass) : base(parent, IntPtr.Zero)
        {
            Data = data;
            ItemClass = itemClass;
            _tooltipCb = (d, obj, tooltip, item) => { return TooltipContentDelegate(); };
        }

        /// <summary>
        /// Gets the item class that defines how to display data. It returns <see cref="GenItemClass"/> type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GenItemClass ItemClass { get; protected set; }

        /// <summary>
        /// Sets or gets the tooltip content delegate.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GetTooltipContentDelegate TooltipContentDelegate
        {
            get
            {
                return _tooltipContentDelegate;
            }
            set
            {
                _tooltipContentDelegate = value;
                UpdateTooltipDelegate();
            }
        }

        /// <summary>
        /// It's an abstract property.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract GenItemSelectionMode SelectionMode { get; set; }

        /// <summary>
        /// Sets or gets the cursor to be shown when the mouse is over the gengrid item.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract string Cursor { get; set; }

        /// <summary>
        /// Sets or gets the style for this item cursor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract string CursorStyle { get; set; }

        /// <summary>
        /// Sets or gets the cursor engine only usage for this item cursor.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract bool IsUseEngineCursor { get; set; }

        /// <summary>
        /// Gets the item data that is added through calling <see cref="GenGrid.Append(GenItemClass, object)"/>, <see cref="GenGrid.Prepend(GenItemClass, object)"/>, or <see cref="GenGrid.InsertBefore(GenItemClass, object, GenGridItem)"/> methods.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public object Data { get; protected set; }

        /// <summary>
        /// It's an abstract property. It's implemented by <see cref="GenGridItem.IsSelected"/> and <see cref="GenListItem.IsSelected"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract bool IsSelected { get; set; }

        /// <summary>
        /// It's an abstract property. It's implemented by <see cref="GenGridItem.TooltipStyle"/> and <see cref="GenListItem.TooltipStyle"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract string TooltipStyle { get; set; }

        /// <summary>
        /// Sets the tooltip text.
        /// </summary>
        /// <param name="tooltip">The text to set.</param>
        /// <since_tizen> preview </since_tizen>
        public abstract void SetTooltipText(string tooltip);

        /// <summary>
        /// Unsets the tooltip.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract void UnsetTooltip();

        /// <summary>
        /// It's an abstract method. It's implemented by <see cref="GenGridItem.Update"/> and <see cref="GenListItem.Update"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public abstract void Update();

        /// <summary>
        /// The override method for deleting the item class and item data. It's called when the item is deleted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnInvalidate()
        {
            ItemClass?.SendItemDeleted(Data);
            Data = null;
            ItemClass = null;
        }

        /// <summary>
        /// Abstract method for updating the tooltip content.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected abstract void UpdateTooltipDelegate();
    }
}