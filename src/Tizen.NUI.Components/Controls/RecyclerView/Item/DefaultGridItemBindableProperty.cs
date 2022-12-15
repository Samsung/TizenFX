using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultGridItem
    {
        /// <summary>
        /// BadgeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BadgeProperty = BindableProperty.Create(nameof(Badge), typeof(View), typeof(DefaultGridItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultGridItem)bindable;
            if (newValue != null)
            {
                instance.InternalBadge = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalBadge;
        });

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DefaultGridItem), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultGridItem)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalText;
        });


        /// <summary>
        /// ImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(DefaultGridItem), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultGridItem)bindable;
            if (newValue != null)
            {
                instance.InternalImageUrl = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalImageUrl;
        });

        /// <summary>
        /// LabelOrientationTypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelOrientationTypeProperty = BindableProperty.Create(nameof(LabelOrientationType), typeof(Tizen.NUI.Components.DefaultGridItem.LabelOrientation), typeof(DefaultGridItem), default(LabelOrientation), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultGridItem)bindable;
            if (newValue != null)
            {
                instance.InternalLabelOrientationType = (Tizen.NUI.Components.DefaultGridItem.LabelOrientation)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultGridItem)bindable;
            return instance.InternalLabelOrientationType;
        });
    }
}
