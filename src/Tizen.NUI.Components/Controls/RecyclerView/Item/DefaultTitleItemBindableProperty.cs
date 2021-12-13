using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultTitleItem
    {
        /// <summary>
        /// IconProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(View), typeof(DefaultTitleItem), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultTitleItem)bindable;
            if (newValue != null)
            {
                instance.InternalIcon = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalIcon;
        });

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DefaultTitleItem), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DefaultTitleItem)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalText;
        });
    }
}
