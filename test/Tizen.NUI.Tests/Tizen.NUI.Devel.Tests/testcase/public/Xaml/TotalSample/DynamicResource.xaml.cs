using System;
using System.Collections.Generic;

using NUnit.Framework;

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.DynamicResource.xaml",
    "testcase.public.Xaml.TotalSample.DynamicResource.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.DynamicResource))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\DynamicResource.xaml")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicResource : View
	{
        public TextLabel label0;

		public DynamicResource ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DynamicResource));
            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
        }
	}

	[TestFixture]
	public class DynamicResourceTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		[Category("P1")]
		[Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void TestDynamicResources()
		{
			var layout = new DynamicResource();
			var label = layout.label0;

			Assert.AreEqual(string.Empty, label.Text, "Should be equal");

			layout.XamlResources = new ResourceDictionary {
					{"FooBar", "FOOBAR"},
				};
			Assert.AreEqual(string.Empty, label.Text);
		}
	}
}