using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.BindablePropertiesAccessModifiers.xaml",
    "testcase.public.Xaml.TotalSample.BindablePropertiesAccessModifiers.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.BindablePropertiesAccessModifiers))]

namespace Tizen.NUI.Devel.Tests
{
	public class AccessModifiersControl : View
	{
		public static BindableProperty PublicFooProperty = BindableProperty.Create("PublicFoo",
			typeof(string),
			typeof(AccessModifiersControl),
			"");

		public string PublicFoo
		{
			get => (string)GetValue(PublicFooProperty);
			set => SetValue(PublicFooProperty, value);
		}

		internal static BindableProperty InternalBarProperty = BindableProperty.Create("InternalBar",
			typeof(string),
			typeof(AccessModifiersControl),
			"");

		public string InternalBar
		{
			get => (string)GetValue(InternalBarProperty);
			set => SetValue(InternalBarProperty, value);
		}
	}

    [Tizen.NUI.Xaml.XamlFilePathAttribute("testcase\\public\\Xaml\\TotalSample\\BindablePropertiesAccessModifiers.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class BindablePropertiesAccessModifiers : View
	{
		internal class Data
		{
			public string Foo => "Foo";
			public string Bar => "Bar";
		}

        public AccessModifiersControl AMC;

        public BindablePropertiesAccessModifiers()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BindablePropertiesAccessModifiers));
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