using System;
using System.ComponentModel;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class BindingCondition : Condition, IValueProvider
    {
        readonly BindableProperty _boundProperty;

        BindingBase _binding;
        object _triggerValue;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingCondition()
        {
            _boundProperty = BindableProperty.CreateAttached("Bound", typeof(object), typeof(BindingCondition), null, propertyChanged: OnBoundPropertyChanged);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingBase Binding
        {
            get { return _binding; }
            set
            {
                if (_binding == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Binding once the Condition has been applied.");
                _binding = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Value
        {
            get { return _triggerValue; }
            set
            {
                if (_triggerValue == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Condition has been applied.");
                _triggerValue = value;
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }

        internal override bool GetState(BindableObject bindable)
        {
            object newValue = bindable.GetValue(_boundProperty);
            return EqualsToValue(newValue);
        }

        internal override void SetUp(BindableObject bindable)
        {
            if (Binding != null)
                bindable.SetBinding(_boundProperty, Binding.Clone());
        }

        internal override void TearDown(BindableObject bindable)
        {
            bindable.RemoveBinding(_boundProperty);
            bindable.ClearValue(_boundProperty);
        }

        static IValueConverterProvider s_valueConverter = DependencyService.Get<IValueConverterProvider>();

        bool EqualsToValue(object other)
        {
            if ((other == Value) || (other != null && other.Equals(Value)))
                return true;

            object converted = null;
            if (s_valueConverter != null)
                converted = s_valueConverter.Convert(Value, other != null ? other.GetType() : typeof(object), null, null);
            else
                return false;

            return (other == converted) || (other != null && other.Equals(converted));
        }

        void OnBoundPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool oldState = EqualsToValue(oldValue);
            bool newState = EqualsToValue(newValue);

            if (newState == oldState)
                return;

            if (ConditionChanged != null)
                ConditionChanged(bindable, oldState, newState);
        }
    }
}
