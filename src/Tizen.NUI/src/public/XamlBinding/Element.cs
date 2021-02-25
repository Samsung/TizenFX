/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Provides the base class for all Tizen.NUI.Binding hierarchal elements. This class contains all the methods and properties required to represent an element in the Tizen.NUI.Binding hierarchy.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract partial class Element : BindableObject, IElement, INameScope, IElementController
    {
        internal static readonly ReadOnlyCollection<Element> EmptyChildren = new ReadOnlyCollection<Element>(System.Array.Empty<Element>());

        /// <summary>
        /// Identifies the ClassId bindable property.
        /// </summary>
        internal static readonly BindableProperty ClassIdProperty = BindableProperty.Create(nameof(ClassId), typeof(string), typeof(Tizen.NUI.BaseComponents.View), null);

        string automationId;

        IList<BindableObject> bindableResources;

        List<Action<object, ResourcesChangedEventArgs>> changeHandlers;

        Dictionary<BindableProperty, string> dynamicResources;

        Guid? id;

        Element parentOverride;

        string styleId;

        /// <summary>
        /// Gets or sets a value that allows the automation framework to find and interact with this element.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AutomationId
        {
            get { return automationId; }
            set
            {
                if (automationId != null)
                    throw new InvalidOperationException("AutomationId may only be set one time");
                automationId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value used to identify a collection of semantically similar elements.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ClassId
        {
            get { return (string)GetValue(ClassIdProperty); }
            set { SetValue(ClassIdProperty, value); }
        }

        /// <summary>
        /// Gets a value that can be used to uniquely identify an element through the run of an application.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid Id
        {
            get
            {
                if (!id.HasValue)
                    id = Guid.NewGuid();
                return id.Value;
            }
        }

        /// <summary>
        /// Gets the element which is the closest ancestor of this element that is a BaseHandle.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ParentView is obsolete as of version 2.1.0. Please use Parent instead.")]
        public BaseHandle ParentView
        {
            get
            {
                Element parent = Parent;
                while (parent != null)
                {
                    var parentView = parent as BaseHandle;
                    if (parentView != null)
                        return parentView;
                    parent = parent.RealParent;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets or sets a user defined value to uniquely identify the element.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StyleId
        {
            get { return styleId; }
            set
            {
                if (styleId == value)
                    return;

                OnPropertyChanging();
                styleId = value;
                OnPropertyChanged();
            }
        }

        internal virtual ReadOnlyCollection<Element> LogicalChildrenInternal => EmptyChildren;

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<Element> LogicalChildren => LogicalChildrenInternal;

        internal bool Owned { get; set; }

        internal Element ParentOverride
        {
            get { return parentOverride; }
            set
            {
                if (parentOverride == value)
                    return;

                bool emitChange = Parent != value;

                if (emitChange)
                    OnPropertyChanging(nameof(Parent));

                parentOverride = value;

                if (emitChange)
                    OnPropertyChanged(nameof(Parent));
            }
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Element RealParent { get; private set; }

        Dictionary<BindableProperty, string> DynamicResources
        {
            get { return dynamicResources ?? (dynamicResources = new Dictionary<BindableProperty, string>()); }
        }

        void IElement.AddResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged)
        {
            changeHandlers = changeHandlers ?? new List<Action<object, ResourcesChangedEventArgs>>(2);
            changeHandlers.Add(onchanged);
        }

        /// <summary>
        /// Gets or sets the parent element of the element.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Element Parent
        {
            get { return parentOverride ?? RealParent; }
            set
            {
                if (RealParent == value)
                    return;

                OnPropertyChanging();

                if (RealParent != null)
                    ((IElement)RealParent).RemoveResourcesChangedListener(OnParentResourcesChanged);
                RealParent = value;
                if (RealParent != null)
                {
                    OnParentResourcesChanged(RealParent?.GetMergedResources());
                    ((IElement)RealParent).AddResourcesChangedListener(OnParentResourcesChanged);
                }

                object context = value != null ? value.BindingContext : null;
                if (value != null)
                {
                    value.SetChildInheritedBindingContext(this, context);
                }
                else
                {
                    SetInheritedBindingContext(this, null);
                }

                OnParentSet();

                OnPropertyChanged();
            }
        }

        void IElement.RemoveResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged)
        {
            if (changeHandlers == null)
                return;
            changeHandlers.Remove(onchanged);
        }

        //void IElementController.SetValueFromRenderer(BindableProperty property, object value) => SetValueFromRenderer(property, value);

        /// <summary>
        /// Sets the value of the specified property.
        /// </summary>
        /// <param name="property">The BindableProperty on which to assign a value.</param>
        /// <param name="value">The value to set.</param>
        internal void SetValueFromRenderer(BindableProperty property, object value)
        {
            SetValueCore(property, value);
        }

        /// <summary>
        /// Sets the value of the propertyKey.
        /// </summary>
        /// <param name="property">The BindablePropertyKey on which to assign a value.</param>
        /// <param name="value">The value to set.</param>
        internal void SetValueFromRenderer(BindablePropertyKey property, object value)
        {
            SetValueCore(property, value);
        }

        object INameScope.FindByName(string name)
        {
            INameScope namescope = GetNameScope();
            if (namescope == null)
            {
                return null;
            }
            else
            {
                return namescope.FindByName(name);
            }
        }

        void INameScope.RegisterName(string name, object scopedElement)
        {
            INameScope namescope = GetNameScope();
            if (namescope == null)
                throw new InvalidOperationException("this element is not in a namescope");
            namescope.RegisterName(name, scopedElement);
        }

        [Obsolete]
        void INameScope.RegisterName(string name, object scopedElement, IXmlLineInfo xmlLineInfo)
        {
            INameScope namescope = GetNameScope();
            if (namescope == null)
                throw new InvalidOperationException("this element is not in a namescope");
            namescope.RegisterName(name, scopedElement, xmlLineInfo);
        }

        void INameScope.UnregisterName(string name)
        {
            INameScope namescope = GetNameScope();
            if (namescope == null)
                throw new InvalidOperationException("this element is not in a namescope");
            namescope.UnregisterName(name);
        }

        internal event EventHandler<ElementEventArgs> ChildAdded;

        internal event EventHandler<ElementEventArgs> ChildRemoved;

        internal event EventHandler<ElementEventArgs> DescendantAdded;

        internal event EventHandler<ElementEventArgs> DescendantRemoved;

        /// <summary>
        /// Removes a previously set dynamic resource.
        /// </summary>
        /// <param name="property">The BindableProperty from which to remove the DynamicResource.</param>
        internal new void RemoveDynamicResource(BindableProperty property)
        {
            base.RemoveDynamicResource(property);
        }

        /// <summary>
        /// Sets the BindableProperty property of this element to be updated via the DynamicResource with the provided key.
        /// </summary>
        /// <param name="property">The BindableProperty.</param>
        /// <param name="key">The key of the DynamicResource</param>
        internal new void SetDynamicResource(BindableProperty property, string key)
        {
            base.SetDynamicResource(property, key);
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

            for (var index = 0; index < LogicalChildrenInternal.Count; index++)
            {
                Element child = LogicalChildrenInternal[index];

                if (!gotBindingContext)
                {
                    bc = BindingContext;
                    gotBindingContext = true;
                }

                SetChildInheritedBindingContext(child, bc);
            }

            if (bindableResources != null)
                foreach (BindableObject item in bindableResources)
                {
                    SetInheritedBindingContext(item, BindingContext);
                }

            base.OnBindingContextChanged();
        }

        /// <summary>
        /// Invoked whenever the ChildAdded event needs to be emitted.Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="child">The element that was added.</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnChildAdded(Element child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }

            child.Parent = this;

            child.ApplyBindings(skipBindingContext: false, fromBindingContextChanged: true);

            ChildAdded?.Invoke(this, new ElementEventArgs(child));

            OnDescendantAdded(child);
            foreach (Element element in child.Descendants())
                OnDescendantAdded(element);
        }

        /// <summary>
        /// Invoked whenever the ChildRemoved event needs to be emitted.Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="child">The element that was removed.</param>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnChildRemoved(Element child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }

            child.Parent = null;

            ChildRemoved?.Invoke(child, new ElementEventArgs(child));

            OnDescendantRemoved(child);
            foreach (Element element in child.Descendants())
                OnDescendantRemoved(element);
        }

        /// <summary>
        /// Invoked whenever the Parent of an element is set.Implement this method in order to add behavior when the element is added to a parent.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnParentSet()
        {
            ParentSet?.Invoke(this, EventArgs.Empty);
            // ApplyStyleSheetsOnParentSet();
        }

        /// <summary>
        /// Method that is called when a bound property is changed.
        /// </summary>
        /// <param name="propertyName">The name of the bound property that changed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        /// <returns>the elements</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<Element> Descendants()
        {
            var queue = new Queue<Element>(16);
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                ReadOnlyCollection<Element> children = queue.Dequeue().LogicalChildrenInternal;
                for (var i = 0; i < children.Count; i++)
                {
                    Element child = children[i];
                    yield return child;
                    queue.Enqueue(child);
                }
            }
        }

        internal virtual void OnParentResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            // if (e == ResourcesChangedEventArgs.StyleSheets)
            // 	// ApplyStyleSheetsOnParentSet();
            // else
            // 	OnParentResourcesChanged(e.Values);
        }

        internal virtual void OnParentResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            OnResourcesChanged(values);
        }

        internal override void OnRemoveDynamicResource(BindableProperty property)
        {
            DynamicResources.Remove(property);

            if (DynamicResources.Count == 0)
                dynamicResources = null;
            base.OnRemoveDynamicResource(property);
        }

        internal virtual void OnResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            OnResourcesChanged(e.Values);
        }

        internal void OnResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            if (values == null)
                return;
            if (changeHandlers != null)
                foreach (Action<object, ResourcesChangedEventArgs> handler in changeHandlers)
                    handler(this, new ResourcesChangedEventArgs(values));
            if (dynamicResources == null)
                return;
            if (bindableResources == null)
                bindableResources = new List<BindableObject>();
            foreach (KeyValuePair<string, object> value in values)
            {
                List<BindableProperty> changedResources = null;
                foreach (KeyValuePair<BindableProperty, string> dynR in DynamicResources)
                {
                    // when the DynamicResource bound to a BindableProperty is
                    // changing then the BindableProperty needs to be refreshed;
                    // The .Value is the name of DynamicResouce to which the BindableProperty is bound.
                    // The .Key is the name of the DynamicResource whose value is changing.
                    if (dynR.Value != value.Key)
                        continue;
                    changedResources = changedResources ?? new List<BindableProperty>();
                    changedResources.Add(dynR.Key);
                }
                if (changedResources == null)
                    continue;
                foreach (BindableProperty changedResource in changedResources)
                    OnResourceChanged(changedResource, value.Value);

                var bindableObject = value.Value as BindableObject;
                if (bindableObject != null && (bindableObject as Element)?.Parent == null)
                {
                    if (!bindableResources.Contains(bindableObject))
                        bindableResources.Add(bindableObject);
                    SetInheritedBindingContext(bindableObject, BindingContext);
                }
            }
        }

        internal override void OnSetDynamicResource(BindableProperty property, string key)
        {
            base.OnSetDynamicResource(property, key);
            DynamicResources[property] = key;
            object value;
            if (this.TryGetResource(key, out value))
                OnResourceChanged(property, value);

            Tizen.NUI.Application.AddResourceChangedCallback(this, (this as Element).OnResourcesChanged);
        }

        internal event EventHandler ParentSet;

        internal virtual void SetChildInheritedBindingContext(Element child, object context)
        {
            SetInheritedBindingContext(child, context);
        }

        internal IEnumerable<Element> VisibleDescendants()
        {
            var queue = new Queue<Element>(16);
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                ReadOnlyCollection<Element> children = queue.Dequeue().LogicalChildrenInternal;
                for (var i = 0; i < children.Count; i++)
                {
                    var child = children[i] as BaseHandle;
                    if (child == null)
                    {
                        continue;
                    }
                    yield return child;
                    queue.Enqueue(child);
                }
            }
        }

        INameScope GetNameScope()
        {
            INameScope namescope = NameScope.GetNameScope(this);
            Element p = RealParent;
            while (namescope == null && p != null)
            {
                namescope = NameScope.GetNameScope(p);
                p = p.RealParent;
            }
            return namescope;
        }

        void OnDescendantAdded(Element child)
        {
            DescendantAdded?.Invoke(this, new ElementEventArgs(child));

            if (RealParent != null)
                RealParent.OnDescendantAdded(child);
        }

        void OnDescendantRemoved(Element child)
        {
            DescendantRemoved?.Invoke(this, new ElementEventArgs(child));

            if (RealParent != null)
                RealParent.OnDescendantRemoved(child);
        }

        void OnResourceChanged(BindableProperty property, object value)
        {
            SetValueCore(property, value, SetValueFlags.ClearOneWayBindings | SetValueFlags.ClearTwoWayBindings);
        }
    }
}
