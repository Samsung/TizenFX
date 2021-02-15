using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Setters")]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class DataTrigger : TriggerBase, IValueProvider
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTrigger([TypeConverter(typeof(TypeTypeConverter))][Parameter("TargetType")] Type targetType) : base(new BindingCondition(), targetType)
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingBase Binding
        {
            get { return ((BindingCondition)Condition).Binding; }
            set
            {
                if (((BindingCondition)Condition).Binding == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Binding once the Trigger has been applied.");
                OnPropertyChanging();
                ((BindingCondition)Condition).Binding = value;
                OnPropertyChanged();
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<Setter> Setters
        {
            get { return base.Setters; }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API9, will be removed in API11. Please use GetValue() instead!")]
        public object Value
        {
            get { return ((BindingCondition)Condition).Value; }
            set
            {
                if (((BindingCondition)Condition).Value == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");
                OnPropertyChanging();
                ((BindingCondition)Condition).Value = value;
                OnPropertyChanged();
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }
    }
}
