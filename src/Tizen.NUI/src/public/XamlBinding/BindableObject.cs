﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Provides a mechanism by which application developers can propagate changes that are made to data in one object to another, by enabling validation, type coercion, and an event system.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BindableObject : INotifyPropertyChanged, IDynamicResourceHandler
    {
        /// <summary>
        /// Implements the bound property whose interface is provided by the BindingContext property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BindingContextProperty =
            BindableProperty.Create("BindingContext", typeof(object), typeof(BindableObject), default(object),
                                    BindingMode.OneWay, null, BindingContextPropertyChanged, null, null, BindingContextPropertyBindingChanging);

        readonly List<BindablePropertyContext> _properties = new List<BindablePropertyContext>(4);

        bool _applying;
        object _inheritedContext;

        /// <summary>
        /// Gets or sets object that contains the properties that will be targeted by the bound properties that belong to this BindableObject.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object BindingContext
        {
            get { return _inheritedContext ?? GetValue(BindingContextProperty); }
            set { SetValue(BindingContextProperty, value); }
        }

        void IDynamicResourceHandler.SetDynamicResource(BindableProperty property, string key)
        {
            SetDynamicResource(property, key, false);
        }

        /// <summary>
        /// Raised when a property has changed.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event PropertyChangedEventHandler PropertyChanged;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CopyFrom(BindableObject that)
        {
            if (null != that)
            {
                Dictionary<string, BindableProperty> nameToBindableProperty1;
                Type type1 = this.GetType();
                BindableProperty.GetBindablePropertysOfType(type1, out nameToBindableProperty1);

                Dictionary<string, BindableProperty> nameToBindableProperty2;
                Type type2 = that.GetType();
                BindableProperty.GetBindablePropertysOfType(type2, out nameToBindableProperty2);

                if (null != nameToBindableProperty1)
                {
                    foreach (KeyValuePair<string, BindableProperty> keyValuePair in nameToBindableProperty1)
                    {
                        BindableProperty bindableProperty;
                        nameToBindableProperty2.TryGetValue(keyValuePair.Key, out bindableProperty);

                        if (null != bindableProperty)
                        {
                            object value = that.GetValue(bindableProperty);

                            if (null != value)
                            {
                                SetValue(keyValuePair.Value, value);
                            }
                        }
                    }
                }
            }
        }

        internal void ListenPropertyChange(BindableProperty bindableProperty, PropertyChangedEventHandler eventHandler)
        {
            PropertyChangedListener propertyChangedListener;
            BindablePropertyChangedEventDict.TryGetValue(bindableProperty.PropertyName, out propertyChangedListener);

            if (null == propertyChangedListener)
            {
                propertyChangedListener = new PropertyChangedListener();
                BindablePropertyChangedEventDict.Add(bindableProperty.PropertyName, propertyChangedListener);
            }

            propertyChangedListener.RegisterListnerHandler(eventHandler);
        }

        internal void RemovePropertyChangeListener(BindableProperty bindableProperty, PropertyChangedEventHandler propertyChangedEventHandler)
        {
            PropertyChangedListener propertyChangedListener;
            BindablePropertyChangedEventDict.TryGetValue(bindableProperty.PropertyName, out propertyChangedListener);

            if (null != propertyChangedListener)
            {
                propertyChangedListener.UnRegisterListnerHandler(propertyChangedEventHandler);

                if (0 == propertyChangedListener.ListenerCount)
                {
                    BindablePropertyChangedEventDict.Remove(bindableProperty.PropertyName);
                }
            }
        }

        private class PropertyChangedListener
        {
            internal void PropertyHasChanged(string propertyName)
            {
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }

            internal void RegisterListnerHandler(PropertyChangedEventHandler propertyChangedEventHandler)
            {
                PropertyChanged += propertyChangedEventHandler;
                listenerCount++;
            }

            internal void UnRegisterListnerHandler(PropertyChangedEventHandler propertyChangedEventHandler)
            {
                PropertyChanged -= propertyChangedEventHandler;
                listenerCount--;
            }

            private int listenerCount = 0;
            internal int ListenerCount
            {
                get
                {
                    return listenerCount;
                }
            }

            private event PropertyChangedEventHandler PropertyChanged;
        }

        private Dictionary<string, PropertyChangedListener> BindablePropertyChangedEventDict = new Dictionary<string, PropertyChangedListener>();

        /// <summary>
        /// Raised whenever the BindingContext property changes.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler BindingContextChanged;

        internal void ClearValue(BindableProperty property, bool fromStyle)
        {
            ClearValue(property, fromStyle: fromStyle, checkAccess: true);
        }

        /// <summary>
        /// Clears any value set by Tizen.NUI.Xaml.BindableObject.SetValue.
        /// </summary>
        /// <param name="property">The BindableProperty to clear</param>
        internal void ClearValue(BindableProperty property)
        {
            ClearValue(property, fromStyle: false, checkAccess: true);
        }

        /// <summary>
        /// Clears any value set by Tizen.NUI.Xaml.BindableObject.SetValue for the property that is identified by propertyKey.
        /// </summary>
        /// <param name="propertyKey">The BindablePropertyKey that identifies the BindableProperty to clear.</param>
        internal void ClearValue(BindablePropertyKey propertyKey)
        {
            if (propertyKey == null)
                throw new ArgumentNullException("propertyKey");

            ClearValue(propertyKey.BindableProperty, fromStyle:false, checkAccess: false);
        }

        /// <summary>
        /// Return true if the target property exists and has been set.
        /// </summary>
        /// <param name="targetProperty">The target property</param>
        /// <returns>return true if the target property exists and has been set</returns>
        internal bool IsSet(BindableProperty targetProperty)
        {
            if (targetProperty == null)
                throw new ArgumentNullException(nameof(targetProperty));

            var bpcontext = GetContext(targetProperty);
            return bpcontext != null
                && (bpcontext.Attributes & BindableContextAttributes.IsDefaultValue) == 0;
        }

        /// <summary>
        /// Returns the value that is contained the BindableProperty.
        /// </summary>
        /// <param name="property">The BindableProperty for which to get the value.</param>
        /// <returns>The value that is contained the BindableProperty</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object GetValue(BindableProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            BindablePropertyContext context = property.DefaultValueCreator != null ? GetOrCreateContext(property) : GetContext(property);

            if (context == null)
                return property.DefaultValue;

            return context.Value;
        }

        /// <summary>
        /// Raised when a property is about to change.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Removes a previously set binding.
        /// </summary>
        /// <param name="property">The BindableProperty from which to remove bindings.</param>
        internal void RemoveBinding(BindableProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            BindablePropertyContext context = GetContext(property);
            if (context == null || context.Binding == null)
                return;

            RemoveBinding(property, context);
        }

        /// <summary>
        /// Assigns a binding to a property.
        /// </summary>
        /// <param name="targetProperty">The BindableProperty on which to set a binding.</param>
        /// <param name="binding">The binding to set.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBinding(BindableProperty targetProperty, BindingBase binding)
        {
            SetBinding(targetProperty, binding, false);
        }

        private bool isCreateByXaml = false;
        /// Only used by the IL of xaml, will never changed to not hidden.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool IsCreateByXaml
        {
            get
            {
                return isCreateByXaml;
            }
            set
            {
                isCreateByXaml = value;
            }
        }

        /// <summary>
        /// Sets the value of the specified property.
        /// </summary>
        /// <param name="property">The BindableProperty on which to assign a value.</param>
        /// <param name="value">The value to set.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValue(BindableProperty property, object value)
        {
            if (true == isCreateByXaml)
            {
                SetValue(property, value, false, true);
            }
            else
            {
                property.PropertyChanged?.Invoke(this, null, value);

                OnPropertyChanged(property.PropertyName);

                if (BindablePropertyChangedEventDict.ContainsKey(property.PropertyName))
                {
                    BindablePropertyChangedEventDict[property.PropertyName].PropertyHasChanged(property.PropertyName);
                }
            }
        }

        internal void SetValueAndForceSendChangeSignal(BindableProperty property, object value)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            if (true == isCreateByXaml)
            {
                if (property.IsReadOnly)
                    throw new InvalidOperationException(string.Format("The BindableProperty \"{0}\" is readonly.", property.PropertyName));

                SetValueCore(property, value, SetValueFlags.ClearOneWayBindings | SetValueFlags.ClearDynamicResource,
                    SetValuePrivateFlags.ManuallySet | SetValuePrivateFlags.CheckAccess, true);
            }
            else
            {
                property.PropertyChanged?.Invoke(this, null, value);
            }
        }

        /// <summary>
        /// Sets the value of the propertyKey.
        /// </summary>
        /// <param name="propertyKey">The BindablePropertyKey on which to assign a value.</param>
        /// <param name="value">The value to set.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetValue(BindablePropertyKey propertyKey, object value)
        {
            if (propertyKey == null)
                throw new ArgumentNullException("propertyKey");

            SetValue(propertyKey.BindableProperty, value, false, false);
        }

        /// <summary>
        /// Set the inherited context to a neated element.
        /// </summary>
        /// <param name="bindable">The object on which to set the inherited binding context.</param>
        /// <param name="value">The inherited context to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetInheritedBindingContext(BindableObject bindable, object value)
        {
            BindablePropertyContext bpContext = bindable.GetContext(BindingContextProperty);
            if (bpContext != null && ((bpContext.Attributes & BindableContextAttributes.IsManuallySet) != 0))
                return;

            object oldContext = bindable._inheritedContext;

            if (ReferenceEquals(oldContext, value))
                return;

            if (bpContext != null && oldContext == null)
                oldContext = bpContext.Value;

            if (bpContext != null && bpContext.Binding != null)
            {
                bpContext.Binding.Context = value;
                bindable._inheritedContext = null;
            }
            else
            {
                bindable._inheritedContext = value;
            }

            bindable.ApplyBindings(skipBindingContext:false, fromBindingContextChanged:true);
            bindable.OnBindingContextChanged();
        }

        /// <summary>
        /// Apply the bindings to BindingContext.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void ApplyBindings()
        {
            ApplyBindings(skipBindingContext: false, fromBindingContextChanged: false);
        }

        /// <summary>
        /// Override this method to execute an action when the BindingContext changes.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnBindingContextChanged()
        {
            BindingContextChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Call this method from a child class to notify that a change happened on a property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Call this method from a child class to notify that a change is going to happen on a property.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
            => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        /// <summary>
        /// Unapplies all previously set bindings.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UnapplyBindings()
        {
            for (int i = 0, _propertiesCount = _properties.Count; i < _propertiesCount; i++) {
                BindablePropertyContext context = _properties [i];
                if (context.Binding == null)
                    continue;

                context.Binding.Unapply();
            }
        }

        internal bool GetIsBound(BindableProperty targetProperty)
        {
            if (targetProperty == null)
                throw new ArgumentNullException("targetProperty");

            BindablePropertyContext bpcontext = GetContext(targetProperty);
            return bpcontext != null && bpcontext.Binding != null;
        }

        /// <summary>
        /// Returns the value that is contained the BindableProperty.
        /// </summary>
        /// <param name="property0">The BindableProperty instance.</param>
        /// <param name="property1">The BindableProperty instance.</param>
        /// <returns>The value that is contained the BindableProperty</returns>
        internal object[] GetValues(BindableProperty property0, BindableProperty property1)
        {
            var values = new object[2];

            for (var i = 0; i < _properties.Count; i++)
            {
                BindablePropertyContext context = _properties[i];

                if (ReferenceEquals(context.Property, property0))
                {
                    values[0] = context.Value;
                    property0 = null;
                }
                else if (ReferenceEquals(context.Property, property1))
                {
                    values[1] = context.Value;
                    property1 = null;
                }

                if (property0 == null && property1 == null)
                    return values;
            }

            if (!ReferenceEquals(property0, null))
                values[0] = property0.DefaultValueCreator == null ? property0.DefaultValue : CreateAndAddContext(property0).Value;
            if (!ReferenceEquals(property1, null))
                values[1] = property1.DefaultValueCreator == null ? property1.DefaultValue : CreateAndAddContext(property1).Value;

            return values;
        }

        /// <summary>
        /// Returns the value that is contained the BindableProperty.
        /// </summary>
        /// <param name="property0">The BindableProperty instance.</param>
        /// <param name="property1">The BindableProperty instance.</param>
        /// <param name="property2">The BindableProperty instance.</param>
        /// <returns>The value that is contained the BindableProperty</returns>
        internal object[] GetValues(BindableProperty property0, BindableProperty property1, BindableProperty property2)
        {
            var values = new object[3];

            for (var i = 0; i < _properties.Count; i++)
            {
                BindablePropertyContext context = _properties[i];

                if (ReferenceEquals(context.Property, property0))
                {
                    values[0] = context.Value;
                    property0 = null;
                }
                else if (ReferenceEquals(context.Property, property1))
                {
                    values[1] = context.Value;
                    property1 = null;
                }
                else if (ReferenceEquals(context.Property, property2))
                {
                    values[2] = context.Value;
                    property2 = null;
                }

                if (property0 == null && property1 == null && property2 == null)
                    return values;
            }

            if (!ReferenceEquals(property0, null))
                values[0] = property0.DefaultValueCreator == null ? property0.DefaultValue : CreateAndAddContext(property0).Value;
            if (!ReferenceEquals(property1, null))
                values[1] = property1.DefaultValueCreator == null ? property1.DefaultValue : CreateAndAddContext(property1).Value;
            if (!ReferenceEquals(property2, null))
                values[2] = property2.DefaultValueCreator == null ? property2.DefaultValue : CreateAndAddContext(property2).Value;

            return values;
        }

        /// <summary>
        /// Returns the value that is contained the BindableProperty.
        /// </summary>
        /// <param name="properties">The array of the BindableProperty instances</param>
        /// <returns>The values that is contained the BindableProperty instances.</returns>
        internal object[] GetValues(params BindableProperty[] properties)
        {
            var values = new object[properties.Length];
            for (var i = 0; i < _properties.Count; i++) {
                var context = _properties[i];
                var index = properties.IndexOf(context.Property);
                if (index < 0)
                    continue;
                values[index] = context.Value;
            }
            for (var i = 0; i < values.Length; i++) {
                if (!ReferenceEquals(values[i], null))
                    continue;
                values[i] = properties[i].DefaultValueCreator == null ? properties[i].DefaultValue : CreateAndAddContext(properties[i]).Value;
            }
            return values;
        }

        internal virtual void OnRemoveDynamicResource(BindableProperty property)
        {
        }

        internal virtual void OnSetDynamicResource(BindableProperty property, string key)
        {
        }

        internal void RemoveDynamicResource(BindableProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            OnRemoveDynamicResource(property);
            BindablePropertyContext context = GetOrCreateContext(property);
            context.Attributes &= ~BindableContextAttributes.IsDynamicResource;
        }

        internal void SetBinding(BindableProperty targetProperty, BindingBase binding, bool fromStyle)
        {
            if (targetProperty == null)
                throw new ArgumentNullException("targetProperty");
            if (binding == null)
                throw new ArgumentNullException("binding");

            if (fromStyle && !CanBeSetFromStyle(targetProperty))
                return;

            var context = GetOrCreateContext(targetProperty);
            if (fromStyle)
                context.Attributes |= BindableContextAttributes.IsSetFromStyle;
            else
                context.Attributes &= ~BindableContextAttributes.IsSetFromStyle;

            if (context.Binding != null)
                context.Binding.Unapply();

            BindingBase oldBinding = context.Binding;
            context.Binding = binding;

            targetProperty.BindingChanging?.Invoke(this, oldBinding, binding);

            binding.Apply(BindingContext, this, targetProperty);
        }

        bool CanBeSetFromStyle(BindableProperty property)
        {
            var context = GetContext(property);
            if (context == null)
                return true;
            if ((context.Attributes & BindableContextAttributes.IsSetFromStyle) == BindableContextAttributes.IsSetFromStyle)
                return true;
            if ((context.Attributes & BindableContextAttributes.IsDefaultValue) == BindableContextAttributes.IsDefaultValue)
                return true;
            if ((context.Attributes & BindableContextAttributes.IsDefaultValueCreated) == BindableContextAttributes.IsDefaultValueCreated)
                return true;
            return false;
        }

        internal void SetDynamicResource(BindableProperty property, string key)
        {
            SetDynamicResource(property, key, false);
        }

        internal void SetDynamicResource(BindableProperty property, string key, bool fromStyle)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if (fromStyle && !CanBeSetFromStyle(property))
                return;

            var context = GetOrCreateContext(property);

            context.Attributes |= BindableContextAttributes.IsDynamicResource;
            if (fromStyle)
                context.Attributes |= BindableContextAttributes.IsSetFromStyle;
            else
                context.Attributes &= ~BindableContextAttributes.IsSetFromStyle;

            OnSetDynamicResource(property, key);
        }

        internal void SetValue(BindableProperty property, object value, bool fromStyle)
        {
            SetValue(property, value, fromStyle, true);
        }

        internal void SetValueCore(BindablePropertyKey propertyKey, object value, SetValueFlags attributes = SetValueFlags.None)
        {
            SetValueCore(propertyKey.BindableProperty, value, attributes, SetValuePrivateFlags.None, false);
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        /// <param name="property">The BindableProperty on which to assign a value.</param>
        /// <param name="value">The value to set</param>
        /// <param name="attributes">The set value flag</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetValueCore(BindableProperty property, object value, SetValueFlags attributes = SetValueFlags.None)
        {
            SetValueCore(property, value, attributes, SetValuePrivateFlags.Default, false);
        }

        internal void SetValueCore(BindableProperty property, object value, SetValueFlags attributes, SetValuePrivateFlags privateAttributes, bool forceSendChangeSignal)
        {
            bool checkAccess = (privateAttributes & SetValuePrivateFlags.CheckAccess) != 0;
            bool manuallySet = (privateAttributes & SetValuePrivateFlags.ManuallySet) != 0;
            bool silent = (privateAttributes & SetValuePrivateFlags.Silent) != 0;
            bool fromStyle = (privateAttributes & SetValuePrivateFlags.FromStyle) != 0;
            bool converted = (privateAttributes & SetValuePrivateFlags.Converted) != 0;

            if (property == null)
                throw new ArgumentNullException("property");
            if (checkAccess && property.IsReadOnly)
            {
                Debug.WriteLine("Can not set the BindableProperty \"{0}\" because it is readonly.", property.PropertyName);
                return;
            }

            if (!converted && !property.TryConvert(ref value))
            {
                Console.WriteLine("SetValue", "Can not convert {0} to type '{1}'", value, property.ReturnType);
                return;
            }

            if (property.ValidateValue != null && !property.ValidateValue(this, value))
                throw new ArgumentException("Value was an invalid value for " + property.PropertyName, "value");

            if (property.CoerceValue != null)
                value = property.CoerceValue(this, value);

            BindablePropertyContext context = GetOrCreateContext(property);
            if (manuallySet) {
                context.Attributes |= BindableContextAttributes.IsManuallySet;
                context.Attributes &= ~BindableContextAttributes.IsSetFromStyle;
            } else
                context.Attributes &= ~BindableContextAttributes.IsManuallySet;

            if (fromStyle)
                context.Attributes |= BindableContextAttributes.IsSetFromStyle;
            // else omitted on purpose

            bool currentlyApplying = _applying;

            if ((context.Attributes & BindableContextAttributes.IsBeingSet) != 0)
            {
                Queue<SetValueArgs> delayQueue = context.DelayedSetters;
                if (delayQueue == null)
                    context.DelayedSetters = delayQueue = new Queue<SetValueArgs>();

                delayQueue.Enqueue(new SetValueArgs(property, context, value, currentlyApplying, attributes));
            }
            else
            {
                context.Attributes |= BindableContextAttributes.IsBeingSet;
                SetValueActual(property, context, value, currentlyApplying, forceSendChangeSignal, attributes, silent);

                Queue<SetValueArgs> delayQueue = context.DelayedSetters;
                if (delayQueue != null)
                {
                    while (delayQueue.Count > 0)
                    {
                        SetValueArgs s = delayQueue.Dequeue();
                        SetValueActual(s.Property, s.Context, s.Value, s.CurrentlyApplying, forceSendChangeSignal, s.Attributes);
                    }

                    context.DelayedSetters = null;
                }

                context.Attributes &= ~BindableContextAttributes.IsBeingSet;
            }
        }

        internal void ApplyBindings(bool skipBindingContext, bool fromBindingContextChanged)
        {
            var prop = _properties.ToArray();
            for (int i = 0, propLength = prop.Length; i < propLength; i++) {
                BindablePropertyContext context = prop [i];
                BindingBase binding = context.Binding;
                if (binding == null)
                    continue;

                if (skipBindingContext && ReferenceEquals(context.Property, BindingContextProperty))
                    continue;

                binding.Unapply(fromBindingContextChanged: fromBindingContextChanged);
                binding.Apply(BindingContext, this, context.Property, fromBindingContextChanged: fromBindingContextChanged);
            }
        }

        static void BindingContextPropertyBindingChanging(BindableObject bindable, BindingBase oldBindingBase, BindingBase newBindingBase)
        {
            object context = bindable._inheritedContext;
            var oldBinding = oldBindingBase as Binding;
            var newBinding = newBindingBase as Binding;

            if (context == null && oldBinding != null)
                context = oldBinding.Context;
            if (context != null && newBinding != null)
                newBinding.Context = context;
        }

        static void BindingContextPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            bindable._inheritedContext = null;
            bindable.ApplyBindings(skipBindingContext: true, fromBindingContextChanged:true);
            bindable.OnBindingContextChanged();
        }

        void ClearValue(BindableProperty property, bool fromStyle, bool checkAccess)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (checkAccess && property.IsReadOnly)
                throw new InvalidOperationException(string.Format("The BindableProperty \"{0}\" is readonly.", property.PropertyName));

            BindablePropertyContext bpcontext = GetContext(property);
            if (bpcontext == null)
                return;

            if (fromStyle && !CanBeSetFromStyle(property))
                return;

            object original = bpcontext.Value;

            object newValue = property.GetDefaultValue(this);

            bool same = Equals(original, newValue);
            if (!same)
            {
                property.PropertyChanging?.Invoke(this, original, newValue);

                OnPropertyChanging(property.PropertyName);
            }

            bpcontext.Attributes &= ~BindableContextAttributes.IsManuallySet;
            bpcontext.Value = newValue;
            if (property.DefaultValueCreator == null)
                bpcontext.Attributes |= BindableContextAttributes.IsDefaultValue;
            else
                bpcontext.Attributes |= BindableContextAttributes.IsDefaultValueCreated;

            if (!same)
            {
                OnPropertyChanged(property.PropertyName);
                property.PropertyChanged?.Invoke(this, original, newValue);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        BindablePropertyContext CreateAndAddContext(BindableProperty property)
        {
            var context = new BindablePropertyContext { Property = property, Value = property.DefaultValueCreator != null ? property.DefaultValueCreator(this) : property.DefaultValue };

            if (property.DefaultValueCreator == null)
                context.Attributes = BindableContextAttributes.IsDefaultValue;
            else
                context.Attributes = BindableContextAttributes.IsDefaultValueCreated;

            _properties.Add(context);
            return context;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        BindablePropertyContext GetContext(BindableProperty property)
        {
            List<BindablePropertyContext> properties = _properties;

            for (var i = 0; i < properties.Count; i++)
            {
                BindablePropertyContext context = properties[i];
                if (ReferenceEquals(context.Property, property))
                    return context;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        BindablePropertyContext GetOrCreateContext(BindableProperty property)
        {
            BindablePropertyContext context = GetContext(property);
            if (context == null)
            {
                context = CreateAndAddContext(property);
            }
            else if (property.DefaultValueCreator != null )
            {
                context.Value = property.DefaultValueCreator(this); //Update Value from dali
            }//added by xb.teng

            return context;
        }

        void RemoveBinding(BindableProperty property, BindablePropertyContext context)
        {
            context.Binding.Unapply();

            property.BindingChanging?.Invoke(this, context.Binding, null);

            context.Binding = null;
        }

        void SetValue(BindableProperty property, object value, bool fromStyle, bool checkAccess)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            if (checkAccess && property.IsReadOnly)
                throw new InvalidOperationException(string.Format("The BindableProperty \"{0}\" is readonly.", property.PropertyName));

            if (fromStyle && !CanBeSetFromStyle(property))
                return;

            SetValueCore(property, value, SetValueFlags.ClearOneWayBindings | SetValueFlags.ClearDynamicResource,
                (fromStyle ? SetValuePrivateFlags.FromStyle : SetValuePrivateFlags.ManuallySet) | (checkAccess ? SetValuePrivateFlags.CheckAccess : 0),
                false);
        }

        void SetValueActual(BindableProperty property, BindablePropertyContext context, object value, bool currentlyApplying, bool forceSendChangeSignal, SetValueFlags attributes, bool silent = false)
        {
            object original = context.Value;
            bool raiseOnEqual = (attributes & SetValueFlags.RaiseOnEqual) != 0;
            bool clearDynamicResources = (attributes & SetValueFlags.ClearDynamicResource) != 0;
            bool clearOneWayBindings = (attributes & SetValueFlags.ClearOneWayBindings) != 0;
            bool clearTwoWayBindings = (attributes & SetValueFlags.ClearTwoWayBindings) != 0;

            bool same = ReferenceEquals(context.Property, BindingContextProperty) ? ReferenceEquals(value, original) : Equals(value, original);
            if (!silent && (!same || raiseOnEqual))
            {
                property.PropertyChanging?.Invoke(this, original, value);

                OnPropertyChanging(property.PropertyName);
            }

            if (!same || raiseOnEqual)
            {
                context.Value = value;
            }

            context.Attributes &= ~BindableContextAttributes.IsDefaultValue;
            context.Attributes &= ~BindableContextAttributes.IsDefaultValueCreated;

            if ((context.Attributes & BindableContextAttributes.IsDynamicResource) != 0 && clearDynamicResources)
                RemoveDynamicResource(property);

            BindingBase binding = context.Binding;
            if (binding != null)
            {
                if (clearOneWayBindings && binding.GetRealizedMode(property) == BindingMode.OneWay || clearTwoWayBindings && binding.GetRealizedMode(property) == BindingMode.TwoWay)
                {
                    RemoveBinding(property, context);
                    binding = null;
                }
            }

            if (!silent)
            {
                if ((!same || raiseOnEqual))
                {
                    property.PropertyChanged?.Invoke(this, original, value);

                    if (binding != null && !currentlyApplying)
                    {
                        _applying = true;
                        binding.Apply(true);
                        _applying = false;
                    }

                    OnPropertyChanged(property.PropertyName);
                }
                else if (true == same && true == forceSendChangeSignal)
                {
                    if (binding != null && !currentlyApplying)
                    {
                        _applying = true;
                        binding.Apply(true);
                        _applying = false;
                    }

                    OnPropertyChanged(property.PropertyName);
                }
            }
        }

        [Flags]
        enum BindableContextAttributes
        {
            IsManuallySet = 1 << 0,
            IsBeingSet = 1 << 1,
            IsDynamicResource = 1 << 2,
            IsSetFromStyle = 1 << 3,
            IsDefaultValue = 1 << 4,
            IsDefaultValueCreated = 1 << 5,
        }

        class BindablePropertyContext
        {
            public BindableContextAttributes Attributes;
            public BindingBase Binding;
            public Queue<SetValueArgs> DelayedSetters;
            public BindableProperty Property;
            public object Value;
        }

        [Flags]
        internal enum SetValuePrivateFlags
        {
            None = 0,
            CheckAccess = 1 << 0,
            Silent = 1 << 1,
            ManuallySet = 1 << 2,
            FromStyle = 1 << 3,
            Converted = 1 << 4,
            Default = CheckAccess
        }

        class SetValueArgs
        {
            public readonly SetValueFlags Attributes;
            public readonly BindablePropertyContext Context;
            public readonly bool CurrentlyApplying;
            public readonly BindableProperty Property;
            public readonly object Value;

            public SetValueArgs(BindableProperty property, BindablePropertyContext context, object value, bool currentlyApplying, SetValueFlags attributes)
            {
                Property = property;
                Context = context;
                Value = value;
                CurrentlyApplying = currentlyApplying;
                Attributes = attributes;
            }
        }
    }
}

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// SetValueFlags. For internal use.
    /// </summary>
    [Flags]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SetValueFlags
    {
        /// <summary>
        /// None.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        None = 0,

        /// <summary>
        /// Clear OneWay bindings.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        ClearOneWayBindings = 1 << 0,

        /// <summary>
        /// Clear TwoWay bindings.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        ClearTwoWayBindings = 1 << 1,

        /// <summary>
        /// Clear dynamic resource.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        ClearDynamicResource = 1 << 2,

        /// <summary>
        /// Raise or equal.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RaiseOnEqual = 1 << 3
    }
}
