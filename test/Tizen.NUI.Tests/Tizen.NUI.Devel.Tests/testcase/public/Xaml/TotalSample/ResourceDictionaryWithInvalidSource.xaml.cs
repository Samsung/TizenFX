using System;
using System.IO;
using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.ResourceDictionaryWithInvalidSource.xaml",
    "testcase.public.Xaml.TotalSample.ResourceDictionaryWithInvalidSource.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.ResourceDictionaryWithInvalidSource))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\ResourceDictionaryWithInvalidSource.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class ResourceDictionaryWithInvalidSource : View
	{
		public ResourceDictionaryWithInvalidSource()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(ResourceDictionaryWithInvalidSource));
        }
	}

	[TestFixture]
	public class Tests
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
		public void InvalidSourceThrows()
		{
			Assert.Throws<FileNotFoundException>(() => new ResourceDictionaryWithInvalidSource());
		}
	}
}