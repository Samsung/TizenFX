using System;
using System.Collections.Generic;
using System.Reflection;
using Tizen.NUI.StyleSheets;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Setters")]
    public sealed class XamlStyle : IStyle
    {
        internal const string StyleClassPrefix = "Tizen.NUI.Binding.StyleClass.";

        readonly BindableProperty _basedOnResourceProperty = BindableProperty.CreateAttached("BasedOnResource", typeof(XamlStyle), typeof(XamlStyle), default(XamlStyle),
            propertyChanged: OnBasedOnResourceChanged);

        readonly List<WeakReference<BindableObject>> _targets = new List<WeakReference<BindableObject>>(4);

        XamlStyle _basedOnStyle;

        string _baseResourceKey;

        IList<Behavior> _behaviors;

        IList<TriggerBase> _triggers;

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlStyle([TypeConverter(typeof(TypeTypeConverter))][Parameter("TargetType")] Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            TargetType = targetType;
            Setters = new List<Setter>();
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ApplyToDerivedTypes { get; set; }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlStyle BasedOn
        {
            get { return _basedOnStyle; }
            set
            {
                if (_basedOnStyle == value)
                    return;
                if (!ValidateBasedOn(value))
                    throw new ArgumentException("BasedOn.TargetType is not compatible with TargetType");
                XamlStyle oldValue = _basedOnStyle;
                _basedOnStyle = value;
                BasedOnChanged(oldValue, value);
                if (value != null)
                    BaseResourceKey = null;
            }
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BaseResourceKey
        {
            get { return _baseResourceKey; }
            set
            {
                if (_baseResourceKey == value)
                    return;
                _baseResourceKey = value;
                //update all DynamicResources
                foreach (WeakReference<BindableObject> bindableWr in _targets)
                {
                    BindableObject target;
                    if (!bindableWr.TryGetTarget(out target))
                        continue;
                    target.RemoveDynamicResource(_basedOnResourceProperty);
                    if (value != null)
                        target.SetDynamicResource(_basedOnResourceProperty, value);
                }
                if (value != null)
                    BasedOn = null;
            }
        }

        internal IList<Behavior> Behaviors
        {
            get { return _behaviors ?? (_behaviors = new AttachedCollection<Behavior>()); }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanCascade { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Class { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<Setter> Setters { get; }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerBase> Triggers
        {
            get { return _triggers ?? (_triggers = new AttachedCollection<TriggerBase>()); }
        }

        void IStyle.Apply(BindableObject bindable)
        {
            _targets.Add(new WeakReference<BindableObject>(bindable));
            if (BaseResourceKey != null)
                bindable.SetDynamicResource(_basedOnResourceProperty, BaseResourceKey);
            ApplyCore(bindable, BasedOn ?? GetBasedOnResource(bindable));
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type TargetType { get; }

        void IStyle.UnApply(BindableObject bindable)
        {
            UnApplyCore(bindable, BasedOn ?? GetBasedOnResource(bindable));
            bindable.RemoveDynamicResource(_basedOnResourceProperty);
            _targets.RemoveAll(wr =>
            {
                BindableObject target;
                return wr.TryGetTarget(out target) && target == bindable;
            });
        }

        internal bool CanBeAppliedTo(Type targetType)
        {
            if (TargetType == targetType)
                return true;
            if (!ApplyToDerivedTypes)
                return false;
            do
            {
                targetType = targetType.GetTypeInfo().BaseType;
                if (TargetType == targetType)
                    return true;
            } while (targetType != typeof(Element));
            return false;
        }

        void ApplyCore(BindableObject bindable, XamlStyle basedOn)
        {
            if (basedOn != null)
                ((IStyle)basedOn).Apply(bindable);

            foreach (Setter setter in Setters)
                setter.Apply(bindable, true);
            ((AttachedCollection<Behavior>)Behaviors).AttachTo(bindable);
            ((AttachedCollection<TriggerBase>)Triggers).AttachTo(bindable);
        }

        void BasedOnChanged(XamlStyle oldValue, XamlStyle newValue)
        {
            foreach (WeakReference<BindableObject> bindableRef in _targets)
            {
                BindableObject bindable;
                if (!bindableRef.TryGetTarget(out bindable))
                    continue;

                UnApplyCore(bindable, oldValue);
                ApplyCore(bindable, newValue);
            }
        }

        XamlStyle GetBasedOnResource(BindableObject bindable)
        {
            return (XamlStyle)bindable.GetValue(_basedOnResourceProperty);
        }

        static void OnBasedOnResourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Style style = (bindable as /*VisualElement*/BaseHandle).Style;
            // if (style == null)
            // 	return;
            // style.UnApplyCore(bindable, (Style)oldValue);
            // style.ApplyCore(bindable, (Style)newValue);
        }

        void UnApplyCore(BindableObject bindable, XamlStyle basedOn)
        {
            ((AttachedCollection<TriggerBase>)Triggers).DetachFrom(bindable);
            ((AttachedCollection<Behavior>)Behaviors).DetachFrom(bindable);
            foreach (Setter setter in Setters)
                setter.UnApply(bindable, true);

            if (basedOn != null)
                ((IStyle)basedOn).UnApply(bindable);
        }

        bool ValidateBasedOn(XamlStyle value)
        {
            if (value == null)
                return true;
            return value.TargetType.IsAssignableFrom(TargetType);
        }
    }
}
