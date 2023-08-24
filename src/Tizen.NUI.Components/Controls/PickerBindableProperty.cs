using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Picker
    {
        /// <summary>
        /// CurrentValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(int), typeof(Picker), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Picker)bindable;
            if (newValue != null)
            {
                instance.InternalCurrentValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Picker)bindable;
            return instance.InternalCurrentValue;
        });

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(Picker), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Picker)bindable;
            if (newValue != null)
            {
                instance.InternalMaxValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Picker)bindable;
            return instance.InternalMaxValue;
        });

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(Picker), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Picker)bindable;
            if (newValue != null)
            {
                instance.InternalMinValue = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Picker)bindable;
            return instance.InternalMinValue;
        });
    }
}
