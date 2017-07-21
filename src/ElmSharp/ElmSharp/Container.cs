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
    /// It inherits <see cref="Widget"/>.
    /// The Container is a abstract class.
    /// Other class inherits it to Elementary is about displaying
    /// its widgets in a nice layout.
    /// </summary>
    public abstract class Container : Widget
    {
        HashSet<EvasObject> _children = new HashSet<EvasObject>();

        /// <summary>
        /// Creates and initializes a new instance of class which inherit from Container.
        /// </summary>
        /// <param name="parent">The parent is a given object which will be attached by Container
        /// as a child.It's <see cref="EvasObject"/> type.</param>
        public Container(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets the background color of a given Container.
        /// </summary>
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

        protected IEnumerable<EvasObject> Children => _children;

        protected void AddChild(EvasObject obj)
        {
            _children.Add(obj);
            obj.Deleted += OnChildDeleted;
        }

        protected void RemoveChild(EvasObject obj)
        {
            _children.Remove(obj);
        }

        protected void ClearChildren()
        {
            _children.Clear();
        }

        void OnChildDeleted(object sender, EventArgs a)
        {
            _children.Remove((EvasObject)sender);
        }
    }
}
