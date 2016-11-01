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
    public abstract class GenItem : ItemObject
    {
        internal GenItem(object data, GenItemClass itemClass) : base(IntPtr.Zero)
        {
            Data = data;
            ItemClass = itemClass;
        }

        public GenItemClass ItemClass { get; protected set; }
        public object Data { get; protected set; }
        public abstract bool IsSelected { get; set; }
        public abstract void Update();
        protected override void OnInvalidate()
        {
            ItemClass?.SendItemDeleted(Data);
            Data = null;
            ItemClass = null;
        }
    }
}
