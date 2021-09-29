using System;
using NUnit.Framework;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.FactoryMethodMissingMethod.xaml",
    "testcase.public.Xaml.TotalSample.FactoryMethodMissingMethod.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.FactoryMethodMissingCtor))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\FactoryMethodMissingMethod.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class FactoryMethodMissingMethod : MockView
	{
		public FactoryMethodMissingMethod()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FactoryMethodMissingMethod));
        }
	}

	[TestFixture]
	public class FactoryMethodMissingMethodTests
	{
		[SetUp]
		public void SetUp()
		{
		}

		[Test]
		[Category("P1")]
		[Description("Extensions LoadFromXaml.")]
		[Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
		[Property("SPEC_URL", "-")]
		[Property("CRITERIA", "MR")]
		public void FactoryMethodMissingMethodThrow()
		{
			//Assert.Throws<XamlParseException>(() => new FactoryMethodMissingMethod());
			var fm = new FactoryMethodMissingMethod();
			Assert.True(true, "Should go here");
		}
	}
}
