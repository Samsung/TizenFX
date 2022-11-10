using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    public class AccessModifiersControl : View
    {
        public static BindableProperty PublicFooProperty = BindableProperty.Create("PublicFoo",
#pragma warning disable Reflection // The code contains reflection
            typeof(string),
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            typeof(AccessModifiersControl),
#pragma warning restore Reflection // The code contains reflection
            "");

        public string PublicFoo
        {
            get => (string)GetValue(PublicFooProperty);
            set => SetValue(PublicFooProperty, value);
        }

        internal static BindableProperty InternalBarProperty = BindableProperty.Create("InternalBar",
#pragma warning disable Reflection // The code contains reflection
            typeof(string),
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            typeof(AccessModifiersControl),
#pragma warning restore Reflection // The code contains reflection
            "");

        public string InternalBar
        {
            get => (string)GetValue(InternalBarProperty);
            set => SetValue(InternalBarProperty, value);
        }
    }

    public partial class BindablePropertiesAccessModifiers : View
    {
        internal class Data
        {
            public string Foo => "Foo";
            public string Bar => "Bar";
        }

        public BindablePropertiesAccessModifiers()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BindablePropertiesAccessModifiers));
#pragma warning restore Reflection // The code contains reflection
            AMC = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Devel.Tests.AccessModifiersControl>(this, "AMC");
        }

        public BindablePropertiesAccessModifiers(bool useCompiledXaml)
        {
            //this stub will be replaced at compile time
        }
    }

    [TestFixture]
    public class BindablePropertiesAccessModifiersTest
    {
        [SetUp]
        public void Setup()
        {
            //Device.PlatformServices = new MockPlatformServices();
        }

        [TearDown]
        public void TearDown()
        {
            //Device.PlatformServices = null;
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void BindablePropertiesAccessModifiersBindProperties()
        {
            var page = new BindablePropertiesAccessModifiers();
            page.BindingContext = new BindablePropertiesAccessModifiers.Data();
            Assert.AreEqual("Bar", page.AMC.GetValue(AccessModifiersControl.InternalBarProperty));
            Assert.AreEqual("Foo", page.AMC.GetValue(AccessModifiersControl.PublicFooProperty));
        }
    }
}