using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Setters")]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    public sealed class Trigger : TriggerBase, IValueProvider
    {
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Trigger([TypeConverter(typeof(TypeTypeConverter))][Parameter("TargetType")] Type targetType) : base(new XamlPropertyCondition(), targetType)
        {
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindableProperty Property
        {
            get { return ((XamlPropertyCondition)Condition).Property; }
            set
            {
                if (((XamlPropertyCondition)Condition).Property == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Property once the Trigger has been applied.");
                OnPropertyChanging();
                ((XamlPropertyCondition)Condition).Property = value;
                OnPropertyChanged();
            }
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<Setter> Setters
        {
            get { return base.Setters; }
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API9, will be removed in API11. Please use GetValue() instead!")]
        public object Value
        {
            get { return ((XamlPropertyCondition)Condition).Value; }
            set
            {
                if (((XamlPropertyCondition)Condition).Value == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");
                OnPropertyChanging();
                ((XamlPropertyCondition)Condition).Value = value;
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
