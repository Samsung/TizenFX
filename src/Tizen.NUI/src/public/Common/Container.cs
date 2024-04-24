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
using System.Linq;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

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
        public static BindableProperty XamlStyleProperty = null;
        internal static void SetInternalXamlStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((View)bindable).MergedStyle.Style = (XamlStyle)newValue;
        }
        internal static object GetInternalXamlStyleProperty(BindableObject bindable)
        {
            return ((View)bindable).MergedStyle.Style;
        }

        internal BaseHandle InternalParent;
        private List<View> childViews = new List<View>();
        private MergedStyle mergedStyle = null;
        ResourceDictionary _resources;
        bool IResourcesProvider.IsResourcesCreated => _resources != null;

        static internal new void Preload()
        {
            Animatable.Preload();
        }

        static Container()
        {
            if (NUIApplication.IsUsingXaml)
            {
                XamlStyleProperty = BindableProperty.Create(nameof(XamlStyle), typeof(XamlStyle), typeof(Container), default(XamlStyle),
                    propertyChanged: SetInternalXamlStyleProperty, defaultValueCreator: GetInternalXamlStyleProperty);
            }
        }

        internal Container(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
            // No un-managed data hence no need to store a native ptr
        }

        internal Container(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (XamlStyle)GetValue(XamlStyleProperty);
                }
                else
                {
                    return (XamlStyle)GetInternalXamlStyleProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(XamlStyleProperty, value);
                }
                else
                {
                    SetInternalXamlStyleProperty(this, null, value);
                }
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
        /// Copy all properties, bindings.
        /// Copy children without xName from other container, copy all properties, bindings of children with xName.
        /// </summary>
        /// <param name="other"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyAndKeepXNameInstance(Container other)
        {
            CopyFrom(other);

            var nameScopeOfOther = NameScope.GetNameScope(other) as NameScope;
            var nameScope = NameScope.GetNameScope(this) as NameScope;

            if (null == nameScopeOfOther)
            {
                if (null != nameScope)
                {
                    return;
                }
            }
            else if (!nameScopeOfOther.Equal(nameScope))
            {
                return;
            }

            var xNameToElementsOfOther = nameScopeOfOther?.NameToElement;
            var xNameToElements = nameScope?.NameToElement;

            if (null != xNameToElements)
            {
                foreach (var pair in xNameToElements)
                {
                    if (pair.Value is View view)
                    {
                        view.Parent?.Remove(view);
                    }
                }
            }

            for (int i = Children.Count - 1; i >= 0; i--)
            {
                var child = GetChildAt((uint)i);
                Remove(child);

                child.DisposeIncludeChildren();
            }

            CopyChildren(other);

            if (null != xNameToElementsOfOther)
            {
                foreach (var pair in xNameToElementsOfOther)
                {
                    if (pair.Value is View view)
                    {
                        var parent = view.Parent;

                        if (null != parent)
                        {
                            if ((null != xNameToElements) && (xNameToElements[pair.Key] is View holdedXElements))
                            {
                                holdedXElements.CopyBindingRelationShip(view);
                                holdedXElements.CopyFrom(view);

                                parent.ReplaceChild(view, holdedXElements);
                            }
                        }
                    }
                }
            }

            ReplaceBindingElementInWholeTree(xNameToElementsOfOther, xNameToElements);

            if (null != xNameToElementsOfOther)
            {
                foreach (var pair in xNameToElementsOfOther)
                {
                    if (pair.Value is View view)
                    {
                        view.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Dispose itself and all children recursively.
        /// We can call this even itself is disposed.
        /// </summary>
        /// <remarks>
        /// Note that Container.DisposeIncludeChildren() disposed only if it created by xaml.
        /// </remarks>
        /// <remarks>
        /// This is a hidden API(inhouse API) only for internal purpose.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DisposeRecursively()
        {
            // To avoid useless "OnChildRemoved" callback invoke, Dispose itself before children.
            if (!Disposed && !IsDisposeQueued)
            {
                Dispose();
            }

            // Copy child referecen to avoid Children changed during DisposeRecursively();
            var copiedChildren = childViews.ToList();

            // Make sure that itself don't have children anymore.
            childViews?.Clear();

            foreach (View child in copiedChildren)
            {
                child?.DisposeRecursively();
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
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ChildCount property instead.")]
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

        private void DisposeIncludeChildren()
        {
            foreach (var child in Children)
            {
                child.DisposeIncludeChildren();
            }

            if (IsCreateByXaml)
            {
                Dispose();
                ClearBinding();
            }
        }

        private void CopyChildren(Container other)
        {
            var childrenOfOtherView = new List<View>();

            foreach (var child in other.Children)
            {
                childrenOfOtherView.Add(child);
            }

            foreach (var child in childrenOfOtherView)
            {
                Add(child);
            }
        }

        private void ReplaceChild(View child, View newChild)
        {
            int indexOfView = Children.FindIndex((View v) => { return v == child; });

            var childrenNeedtoReAdd = new Stack<View>();

            for (int i = Children.Count - 1; i > indexOfView; i--)
            {
                childrenNeedtoReAdd.Push(Children[i]);
                Remove(Children[i]);
            }

            Remove(child);

            childrenNeedtoReAdd.Push(newChild);

            while (0 < childrenNeedtoReAdd.Count)
            {
                Add(childrenNeedtoReAdd.Pop());
            }
        }

        private void ReplaceBindingElementInWholeTree(Dictionary<string, object> oldNameScope, Dictionary<string, object> newNameScope)
        {
            if (IsCreateByXaml)
            {
                ReplaceBindingElement(oldNameScope, newNameScope);

                foreach (var child in Children)
                {
                    child.ReplaceBindingElementInWholeTree(oldNameScope, newNameScope);
                }
            }
        }
    }
} // namespace Tizen.NUI
