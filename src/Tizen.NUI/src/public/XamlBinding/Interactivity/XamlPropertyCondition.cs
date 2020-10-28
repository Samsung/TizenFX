using System;
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ProvideCompiled("Tizen.NUI.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class XamlPropertyCondition : Condition, IValueProvider
    {
        readonly BindableProperty _stateProperty;

        BindableProperty _property;
        object _triggerValue;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlPropertyCondition()
        {
            _stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindableProperty Property
        {
            get { return _property; }
            set
            {
                if (_property == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Property once the Trigger has been applied.");
                _property = value;

                //convert the value
                if (_property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => _property.DeclaringType.GetRuntimeProperty(_property.PropertyName);
                    Value = s_valueConverter.Convert(Value, _property.ReturnType, minforetriever, null);
                }
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
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");

                //convert the value
                if (_property != null && s_valueConverter != null)
                {
                    Func<MemberInfo> minforetriever = () => _property.DeclaringType.GetRuntimeProperty(_property.PropertyName);
                    _triggerValue = s_valueConverter.Convert(value, _property.ReturnType, minforetriever, null);
                }
                else
                {
                    _triggerValue = value;
                }
                
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }

        internal override bool GetState(BindableObject bindable)
        {
            return (bool)bindable.GetValue(_stateProperty);
        }

        static IValueConverterProvider s_valueConverter = DependencyService.Get<IValueConverterProvider>();

        internal override void SetUp(BindableObject bindable)
        {
            object newvalue = bindable.GetValue(Property);
            bool newState = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            bindable.SetValue(_stateProperty, newState);
            bindable.PropertyChanged += OnAttachedObjectPropertyChanged;
        }

        internal override void TearDown(BindableObject bindable)
        {
            bindable.ClearValue(_stateProperty);
            bindable.PropertyChanged -= OnAttachedObjectPropertyChanged;
        }

        void OnAttachedObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var bindable = (BindableObject)sender;
            var oldState = (bool)bindable.GetValue(_stateProperty);

            if (Property == null)
                return;
            if (e.PropertyName != Property.PropertyName)
                return;
            object newvalue = bindable.GetValue(Property);
            bool newstate = (newvalue == Value) || (newvalue != null && newvalue.Equals(Value));
            if (oldState != newstate)
                bindable.SetValue(_stateProperty, newstate);
        }

        void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)oldValue == (bool)newValue)
                return;

            ConditionChanged?.Invoke(bindable, (bool)oldValue, (bool)newValue);
        }
    }
}
