using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.DuplicatePropertyElements.xaml",
    "testcase.public.Xaml.TotalSample.DuplicatePropertyElements.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.DuplicatePropertyElements))]

namespace Tizen.NUI.Devel.Tests
{
    [Tizen.NUI.Xaml.XamlFilePathAttribute("testcase\\public\\Xaml\\TotalSample\\DuplicatePropertyElements.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class DuplicatePropertyElements : BindableObject
	{
		public DuplicatePropertyElements()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DuplicatePropertyElements));
        }
	}

	[TestFixture]
	public class DuplicatePropertyElementsTests
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
		public void ThrowXamlParseException()
		{
			Assert.Throws<ArgumentException>(() => new DuplicatePropertyElements());
		}
	}
}
