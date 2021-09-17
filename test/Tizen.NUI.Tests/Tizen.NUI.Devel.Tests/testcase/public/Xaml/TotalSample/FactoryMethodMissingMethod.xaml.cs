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

		[TestFixture]
		public class Tests
		{
			[SetUp]
			public void SetUp()
			{
			}

			[Test]
			public void Throw()
			{
				Assert.Throws<XamlParseException>(() => new FactoryMethodMissingMethod());
			}
		}
	}
}
