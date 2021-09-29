using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.DuplicateXArgumentsElements.xaml",
    "testcase.public.Xaml.TotalSample.DuplicateXArgumentsElements.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.DuplicateXArgumentsElements))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\DuplicateXArgumentsElements.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class DuplicateXArgumentsElements : BindableObject
	{
		public DuplicateXArgumentsElements()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DuplicateXArgumentsElements));
        }

		
	}

	[TestFixture]
	public class DuplicateXArgumentsElementsTests
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
		public void DuplicateXArgumentsElementsTest()
		{
			Assert.Throws<ArgumentException>(() => new DuplicateXArgumentsElements());
		}
	}
}
