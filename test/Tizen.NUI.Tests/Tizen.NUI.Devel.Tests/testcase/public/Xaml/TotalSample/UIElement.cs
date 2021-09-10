using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    public class UIElement : View, IResourcesProvider
    {
        public static readonly BindableProperty IntPProperty = BindableProperty.Create(nameof(IntP), typeof(int), typeof(UIElement), 0, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
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

        public static readonly BindableProperty FloatPProperty = BindableProperty.Create(nameof(FloatP), typeof(float), typeof(UIElement), 0.0f, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            return 0.0f;
        }));

        public UIElement()
        {

        }

        public UIElement(int p)
        {

        }

        public UIElement(int[] p)
        {

        }

        public enum TestEnum
        {
            V1,
            V2
        }

        public UIElement(TestEnum p)
        {

        }

        public class TestNestType
        {
            public TestNestType(int p = 0)
            {

            }
        }

        public UIElement(TestNestType p)
        {

        }

        public UIElement(UIElement p)
        {

        }

        public static UIElement FactoryMethod(int p1, string p2, float p3)
        {
            return new UIElement();
        }

        public int IntP
        {
            get
            {
                return (int)GetValue(IntPProperty);
            }
            set
            {
                SetValue(IntPProperty, value);
            }
        }

        private string stringP;
        public string StringP
        {
            get
            {
                return (string)GetValue(StringPProperty);
            }
            set
            {
                SetValue(StringPProperty, value);
            }
        }

        public float FloatP
        {
            get
            {
                return (float)GetValue(FloatPProperty);
            }
            set
            {
                SetValue(FloatPProperty, value);
            }
        }
    }
}
