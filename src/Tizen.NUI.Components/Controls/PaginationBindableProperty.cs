using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Pagination
    {
        /// <summary>
        /// LastIndicatorImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LastIndicatorImageUrlProperty = BindableProperty.Create(nameof(LastIndicatorImageUrl), typeof(Tizen.NUI.BaseComponents.Selector<string>), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalLastIndicatorImageUrl = newValue as Selector<string>;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.InternalLastIndicatorImageUrl;
        });

        /// <summary>
        /// IndicatorCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorCountProperty = BindableProperty.Create(nameof(IndicatorCount), typeof(int), typeof(Pagination), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalIndicatorCount = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorCount;
        });

        /// <summary>
        /// IndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorColorProperty = BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalIndicatorColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.InternalIndicatorColor;
        });

        /// <summary>
        /// SelectedIndicatorColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndicatorColorProperty = BindableProperty.Create(nameof(SelectedIndicatorColor), typeof(Color), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalSelectedIndicatorColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndicatorColor;
        });

        /// <summary>
        /// SelectedIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(Pagination), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.InternalSelectedIndex = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.InternalSelectedIndex;
        });
    }
}
