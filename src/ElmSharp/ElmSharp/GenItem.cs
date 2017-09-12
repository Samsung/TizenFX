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
    /// Enumeration for select mode of GenItem.
    /// </summary>
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
    /// It contains genitem class and data to display data.
    /// </summary>
    public abstract class GenItem : ItemObject
    {
        internal Interop.Elementary.Elm_Tooltip_Item_Content_Cb _tooltipCb;
        GetTooltipContentDelegate _tooltipContentDelegate = null;

        /// <summary>
        /// The delegate returning the tooltip contents.
        /// </summary>
        public delegate EvasObject GetTooltipContentDelegate();

        internal GenItem(object data, GenItemClass itemClass) : base(IntPtr.Zero)
        {
            Data = data;
            ItemClass = itemClass;
            _tooltipCb = (d, obj, tooltip, item) => { return TooltipContentDelegate(); };
        }

        /// <summary>
        /// Gets the item class that defines how to display data. It returns <see cref="GenItemClass"/> type.
        /// </summary>
        public GenItemClass ItemClass { get; protected set; }

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
        /// It's a abstract property.
        /// </summary>
        public abstract GenItemSelectionMode SelectionMode { get; set; }

        public abstract string Cursor { get; set; }
        public abstract string CursorStyle { get; set; }

        public abstract bool IsUseEngineCursor { get; set; }

        /// <summary>
        /// Gets item data that is added through calling <see cref="GenGrid.Append(GenItemClass, object)"/>, <see cref="GenGrid.Prepend(GenItemClass, object)"/> or <see cref="GenGrid.InsertBefore(GenItemClass, object, GenGridItem)"/> methods.
        /// </summary>
        public object Data { get; protected set; }

        /// <summary>
        /// It's a abstract property. It's implemented by <see cref="GenGridItem.IsSelected"/> and <see cref="GenListItem.IsSelected"/>.
        /// </summary>
        public abstract bool IsSelected { get; set; }

        /// <summary>
        /// It's a abstract property. It's implemented by <see cref="GenGridItem.TooltipStyle"/> and <see cref="GenListItem.TooltipStyle"/>.
        /// </summary>
        public abstract string TooltipStyle { get; set; }

        public abstract void SetTooltipText(string tooltip);
        public abstract void UnsetTooltip();

        /// <summary>
        /// It's a abstract method. It's implemented by <see cref="GenGridItem.Update"/> and <see cref="GenListItem.Update"/>.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// The override method for delete item class and item data. It's called when the item is deleting.
        /// </summary>
        protected override void OnInvalidate()
        {
            ItemClass?.SendItemDeleted(Data);
            Data = null;
            ItemClass = null;
        }

        protected abstract void UpdateTooltipDelegate();
    }
}
