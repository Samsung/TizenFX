using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public partial class UIElement
    {
        public static readonly BindableProperty IntPProperty = BindableProperty.Create(nameof(IntP), typeof(int), typeof(UIElement), 0, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0;
        }));

        public static readonly BindableProperty LongPProperty = BindableProperty.Create("LongP", typeof(long), typeof(UIElement), 0L, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0;
        }));

        public static readonly BindableProperty UIntPProperty = BindableProperty.Create("UIntP", typeof(uint), typeof(UIElement), 0u, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0;
        }));

        public static readonly BindableProperty ULongPProperty = BindableProperty.Create("ULongP", typeof(ulong), typeof(UIElement), 0uL, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0;
        }));

        public static readonly BindableProperty StringPProperty = BindableProperty.Create(nameof(StringP), typeof(string), typeof(UIElement), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            (bindable as UIElement).stringP = newValue as string;
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return (bindable as UIElement).stringP;
        }));

        public static readonly BindableProperty FloatPProperty = BindableProperty.Create("FloatP", typeof(float), typeof(UIElement), 0.0f, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0.0f;
        }));

        public static readonly BindableProperty DoublePProperty = BindableProperty.Create("Double", typeof(double), typeof(UIElement), 0.0, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0.0f;
        }));

        public static readonly BindableProperty ViewPProperty = BindableProperty.Create("ViewP", typeof(View), typeof(UIElement), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return new View();
        }));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(UIElement), null, propertyChanged: (bo, o, n) => ((UIElement)bo).OnCommandChanged());

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(UIElement), null,
            propertyChanged: (bindable, oldvalue, newvalue) => ((UIElement)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));
    }
}
