/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// The Container is an abstract class to be inherited from by classes that desire to have views
    /// added to them.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class Container : Animatable, IResourcesProvider
    {
        /// <summary> XamlStyleProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty XamlStyleProperty = BindableProperty.Create(nameof(XamlStyle), typeof(XamlStyle), typeof(Container), default(XamlStyle), propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable).MergedStyle.Style = (XamlStyle)newvalue);

        internal BaseHandle InternalParent;
        private List<View> childViews = new List<View>();
        private MergedStyle mergedStyle = null;
        ResourceDictionary _resources;
        bool IResourcesProvider.IsResourcesCreated => _resources != null;

        internal Container(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            // No un-managed data hence no need to store a native ptr
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                if (_resources != null)
                    return _resources;
                _resources = new ResourceDictionary();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                OnPropertyChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlStyle XamlStyle
        {
            get
            {
                return (XamlStyle)GetValue(XamlStyleProperty);
            }
            set
            {
                SetValue(XamlStyleProperty, value);
            }
        }

        internal MergedStyle MergedStyle
        {
            get
            {
                if (null == mergedStyle)
                {
                    mergedStyle = new MergedStyle(GetType(), this);
                }

                return mergedStyle;
            }
        }

        /// <summary>
        /// List of children of Container.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public List<View> Children
        {
            get
            {
                return childViews;
            }
        }

        /// <summary>
        /// Gets the parent container.
        /// Read only
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container.</returns>
        /// <since_tizen> 4 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
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
        /// <since_tizen> 4 </since_tizen>
        public uint ChildCount
        {
            get
            {
                return Convert.ToUInt32(Children.Count);
            }
        }

        /// <summary>
        /// Adds a child view to this Container.
        /// </summary>
        /// <pre>This Container (the parent) has been initialized. The child view has been initialized. The child view is not the same as the parent view.</pre>
        /// <post>The child will be referenced by its parent. This means that the child will be kept alive, even if the handle passed into this method is reset or destroyed.</post>
        /// <remarks>If the child already has a parent, it will be removed from the old parent and reparented to this view. This may change child's position, color, scale, etc. as it now inherits them from this view.</remarks>
        /// <param name="view">The child view to add.</param>
        /// <since_tizen> 4 </since_tizen>
        public abstract void Add(View view);

        /// <summary>
        /// Removes a child view from this view. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <pre>This View(the parent) has been initialized. The child view is not the same as the parent view.</pre>
        /// <param name="view">The view to remove</param>
        /// <since_tizen> 4 </since_tizen>
        public abstract void Remove(View view);

        /// <summary>
        /// Retrieves the child view by the index.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The view for the given index or empty handle if children are not initialized.</returns>
        /// <since_tizen> 4 </since_tizen>
        public abstract View GetChildAt(uint index);

        /// <summary>
        /// Gets the parent of this container.
        /// </summary>
        /// <pre>The child container has been initialized.</pre>
        /// <returns>The parent container.</returns>
        /// <since_tizen> 4 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1721: Property names should not match get methods")]
        public abstract Container GetParent();

        /// <summary>
        /// Gets the number of children for this container.
        /// </summary>
        /// <pre>The container has been initialized.</pre>
        /// <returns>The number of children.</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API9, will be removed in API11. Please use ChildCount property instead!")]
        public abstract UInt32 GetChildCount();

        internal abstract View FindCurrentChildById(uint id);

        internal override void OnParentResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            if (values == null)
                return;

            if (!((IResourcesProvider)this).IsResourcesCreated || XamlResources.Count == 0)
            {
                base.OnParentResourcesChanged(values);
                return;
            }

            var innerKeys = new HashSet<string>();
            var changedResources = new List<KeyValuePair<string, object>>();
            foreach (KeyValuePair<string, object> c in XamlResources)
                innerKeys.Add(c.Key);
            foreach (KeyValuePair<string, object> value in values)
            {
                if (innerKeys.Add(value.Key))
                    changedResources.Add(value);
            }
            if (changedResources.Count != 0)
                OnResourcesChanged(changedResources);
        }

        /// <summary>
        /// Invoked whenever the binding context of the element changes. Implement this method to add class handling for this event.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnBindingContextChanged()
        {
            var gotBindingContext = false;
            object bc = null;

            for (var index = 0; index < Children.Count; index++)
            {
                Element child = Children[index];

                if (!gotBindingContext)
                {
                    bc = BindingContext;
                    gotBindingContext = true;
                }

                SetChildInheritedBindingContext(child, bc);
            }
            base.OnBindingContextChanged();
        }
    }
} // namespace Tizen.NUI
