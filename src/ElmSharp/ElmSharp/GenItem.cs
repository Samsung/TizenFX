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
    /// It inherits <see cref="ItemObject"/>.
    /// A base class for <see cref="GenGridItem"/> and <see cref="GenListItem"/>.
    /// It contains genitem class and data to display data.
    /// </summary>
    public abstract class GenItem : ItemObject
    {
        internal GenItem(object data, GenItemClass itemClass) : base(IntPtr.Zero)
        {
            Data = data;
            ItemClass = itemClass;
        }

        /// <summary>
        /// Gets the item class that defines how to display data. It returns <see cref="GenItemClass"/> type.
        /// </summary>
        public GenItemClass ItemClass { get; protected set; }

        /// <summary>
        /// Gets item data that is added through calling <see cref="GenGrid.Append(GenItemClass, object)"/>, <see cref="GenGrid.Prepend(GenItemClass, object)"/> or <see cref="GenGrid.InsertBefore(GenItemClass, object, GenGridItem)"/> methods.
        /// </summary>
        public object Data { get; protected set; }

        /// <summary>
        /// It's a abstract property. It's implemented by <see cref="GenGridItem.IsSelected"/> and <see cref="GenListItem.IsSelected"/>.
        /// </summary>
        public abstract bool IsSelected { get; set; }

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
    }
}
