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
    public abstract class Container : Widget
    {
        HashSet<EvasObject> _children = new HashSet<EvasObject>();

        public Container(EvasObject parent) : base(parent)
        {
        }

        public override Color BackgroundColor
        {
            set
            {
                if (value.IsDefault)
                {
                    SetPartColor("bg", Color.Transparent);
                }
                else
                {
                    SetPartColor("bg", value);
                }
                _backgroundColor = value;
            }
        }

        internal void AddChild(EvasObject obj)
        {
            _children.Add(obj);
            obj.Deleted += OnChildDeleted;
        }

        internal void RemoveChild(EvasObject obj)
        {
            _children.Remove(obj);
        }

        internal void ClearChildren()
        {
            _children.Clear();
        }

        void OnChildDeleted(object sender, EventArgs a)
        {
            _children.Remove((EvasObject)sender);
        }
    }
}
