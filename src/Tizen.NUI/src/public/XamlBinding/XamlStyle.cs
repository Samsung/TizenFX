using System;
using System.Collections.Generic;
using System.Reflection;
using Tizen.NUI.StyleSheets;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Setters")]
    public sealed class XamlStyle : IStyle
    {
        internal const string StyleClassPrefix = "Tizen.NUI.Binding.StyleClass.";

		const int CleanupTrigger = 128;
		int cleanupThreshold = CleanupTrigger;

        readonly BindableProperty basedOnResourceProperty = BindableProperty.CreateAttached("BasedOnResource", typeof(XamlStyle), typeof(XamlStyle), default(XamlStyle),
            propertyChanged: OnBasedOnResourceChanged);

        readonly List<WeakReference<BindableObject>> targets = new List<WeakReference<BindableObject>>(4);

        XamlStyle basedOnStyle;

        string baseResourceKey;

        IList<Behavior> behaviors;

        IList<TriggerBase> triggers;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlStyle([TypeConverter(typeof(TypeTypeConverter))][Parameter("TargetType")] Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            TargetType = targetType;
            Setters = new List<Setter>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ApplyToDerivedTypes { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlStyle BasedOn
        {
            get { return basedOnStyle; }
            set
            {
                if (basedOnStyle == value)
                    return;
                if (!ValidateBasedOn(value))
                    throw new ArgumentException("BasedOn.TargetType is not compatible with TargetType");
                XamlStyle oldValue = basedOnStyle;
                basedOnStyle = value;
                BasedOnChanged(oldValue, value);
                if (value != null)
                    BaseResourceKey = null;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BaseResourceKey
        {
            get { return baseResourceKey; }
            set
            {
                if (baseResourceKey == value)
                    return;
                baseResourceKey = value;
                //update all DynamicResources
                foreach (WeakReference<BindableObject> bindableWr in targets)
                {
                    BindableObject target;
                    if (!bindableWr.TryGetTarget(out target))
                        continue;
                    target.RemoveDynamicResource(basedOnResourceProperty);
                    if (value != null)
                        target.SetDynamicResource(basedOnResourceProperty, value);
                }
                if (value != null)
                    BasedOn = null;
            }
        }

        internal IList<Behavior> Behaviors
        {
            get { return behaviors ?? (behaviors = new AttachedCollection<Behavior>()); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanCascade { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Class { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<Setter> Setters { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerBase> Triggers
        {
            get { return triggers ?? (triggers = new AttachedCollection<TriggerBase>()); }
        }

        void IStyle.Apply(BindableObject bindable)
        {
            targets.Add(new WeakReference<BindableObject>(bindable));
            if (BaseResourceKey != null)
                bindable.SetDynamicResource(basedOnResourceProperty, BaseResourceKey);
            ApplyCore(bindable, BasedOn ?? GetBasedOnResource(bindable));
            CleanUpWeakReferences();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type TargetType { get; }

        void IStyle.UnApply(BindableObject bindable)
        {
            UnApplyCore(bindable, BasedOn ?? GetBasedOnResource(bindable));
            bindable.RemoveDynamicResource(basedOnResourceProperty);
            targets.RemoveAll(wr =>
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
            foreach (WeakReference<BindableObject> bindableRef in targets)
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
            return (XamlStyle)bindable.GetValue(basedOnResourceProperty);
        }

        static void OnBasedOnResourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            XamlStyle style = (bindable as View).XamlStyle;
            if (style == null)
                return;
            style.UnApplyCore(bindable, (XamlStyle)oldValue);
            style.ApplyCore(bindable, (XamlStyle)newValue);
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

		void CleanUpWeakReferences()
		{
			if (targets.Count < cleanupThreshold)
			{
				return;
			}

			targets.RemoveAll(t => !t.TryGetTarget(out _));
			cleanupThreshold = targets.Count + CleanupTrigger;
		}
	}
}
