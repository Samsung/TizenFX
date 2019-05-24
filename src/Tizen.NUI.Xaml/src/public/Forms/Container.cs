/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Xaml.Forms
{
    /// <summary>
    /// The Container is an abstract class to be inherited from by classes that desire to have views
    /// added to them.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Container : BaseHandle
    {
        internal Container(Tizen.NUI.Container nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// <summary>
        /// Gets the parent container.
        /// Read only
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Container Parent
        {
            get
            {
                return GetParent();
            }
        }

        /// <summary>
        /// Gets the number of children for this container.
        /// Read only
        /// </summary>
        /// <pre>The container has been initialized.</pre>
        /// <returns>The number of children.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }

        /// <summary>
        /// Adds a child view to this Container.
        /// </summary>
        /// <pre>This Container (the parent) has been initialized. The child view has been initialized. The child view is not the same as the parent view.</pre>
        /// <post>The child will be referenced by its parent. This means that the child will be kept alive, even if the handle passed into this method is reset or destroyed.</post>
        /// <remarks>If the child already has a parent, it will be removed from the old parent and reparented to this view. This may change child's position, color, scale, etc. as it now inherits them from this view.</remarks>
        /// <param name="view">The child view to add.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Add(View view);

        /// <summary>
        /// Removes a child view from this view. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <pre>This View(the parent) has been initialized. The child view is not the same as the parent view.</pre>
        /// <param name="view">The view to remove</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Remove(View view);

        /// <summary>
        /// Retrieves the child view by the index.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The view for the given index or empty handle if children are not initialized.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract View GetChildAt(uint index);

        /// <summary>
        /// Gets the parent of this container.
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract Container GetParent();

        /// <summary>
        /// Gets the number of children for this container.
        /// </summary>
        /// <pre>The container has been initialized.</pre>
        /// <returns>The number of children.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract UInt32 GetChildCount();
    }
} // namespace Tizen.NUI
