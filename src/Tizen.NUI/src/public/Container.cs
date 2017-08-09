/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    ///
    /// Container is an abstract class to be inherited from by classes that desire to have Views
    /// added to them.
    ///
    /// </summary>

    public abstract class Container : Animatable
    {

        internal Container(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            // No un-managed data hence no need to store a native ptr
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            base.Dispose(type);
        }


        /// <summary>
        /// Adds a child view to this Container.
        /// </summary>
        /// <pre>This Container(the parent) has been initialized. The child view has been initialized. The child view is not the same as the parent view.</pre>
        /// <post>The child will be referenced by its parent. This means that the child will be kept alive, even if the handle passed into this method is reset or destroyed.</post>
        /// <remarks>If the child already has a parent, it will be removed from old parent and reparented to this view. This may change child's position, color, scale etc as it now inherits them from this view.</remarks>
        /// <param name="view">The child view to add</param>
        public abstract void Add( View view );

        /// <summary>
        /// Removes a child View from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <pre>This View(the parent) has been initialized. The child view is not the same as the parent view.</pre>
        /// <param name="child">The child</param>
        public abstract void Remove( View view );

        /// <summary>
        /// Retrieves child view by index.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve</param>
        /// <returns>The view for the given index or empty handle if children not initialized</returns>
        public abstract View GetChildAt( uint index );

        /// <summary>
        /// Get the parent of this container
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container</returns>
        protected abstract Container GetParent();

        /// <summary>
        /// Get the number of children for this container
        /// </summary>
        /// <pre>The container has been initialized.</pre>
        /// <returns>number of children</returns>
        protected abstract UInt32 GetChildCount();

        /// <summary>
        /// Get the parent Container
        /// Read only
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container</returns>
        public Container Parent
        {
            get
            {
                return GetParent();
            }
        }

        /// <summary>
        /// Get the number of children for this container
        /// Read only
        /// </summary>
        /// <pre>The container has been initialized.</pre>
        /// <returns>number of children</returns>
        public uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }
    }
} // namespace Tizen.NUI