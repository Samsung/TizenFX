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
    /// The Container is an abstract class.
    /// The other class inherits it to elementary, which is about displaying
    /// its widgets in a nice layout.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class Container : Widget
    {
        HashSet<EvasObject> _children = new HashSet<EvasObject>();

        /// <summary>
        /// Creates and initializes a new instance of the class, which inherit from the Container.
        /// </summary>
        /// <param name="parent">The parent is a given object, which will be attached by the Container
        /// as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        protected Container(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the Container class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected Container()
        {
        }

        /// <summary>
        /// Sets the background color of a given Container.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Gets the collection of a child EvasObject of the Container.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected IEnumerable<EvasObject> Children => _children;

        /// <summary>
        /// Add the EvasObject object as a child of the Container.
        /// </summary>
        /// <param name="obj">The EvasObject object to be added.</param>
        /// <since_tizen> preview </since_tizen>
        protected void AddChild(EvasObject obj)
        {
            _children.Add(obj);
            obj.Deleted += OnChildDeleted;
        }

        /// <summary>
        /// Removes the EvasObject object as a child of the Container.
        /// </summary>
        /// <param name="obj">The EvasObject object to be removed.</param>
        /// <since_tizen> preview </since_tizen>
        protected void RemoveChild(EvasObject obj)
        {
            _children.Remove(obj);
        }

        /// <summary>
        /// Clears all the children of the Container.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected void ClearChildren()
        {
            _children.Clear();
        }

        /// <summary>
        /// The Container callback that is invoked when a child is removed.
        /// </summary>
        /// <param name="sender">The called Container.</param>
        /// <param name="a"><see cref="EventArgs"/></param>
        void OnChildDeleted(object sender, EventArgs a)
        {
            _children.Remove((EvasObject)sender);
        }
    }
}
