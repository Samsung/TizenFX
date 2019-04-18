﻿using System;
using System.Collections.Generic;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    [ContentProperty("Setters")]
    [ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    internal sealed class DataTrigger : TriggerBase, IValueProvider
    {
        public DataTrigger([TypeConverter(typeof(TypeTypeConverter))] [Parameter("TargetType")] Type targetType) : base(new BindingCondition(), targetType)
        {
        }

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

        public new IList<Setter> Setters
        {
            get { return base.Setters; }
        }

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
