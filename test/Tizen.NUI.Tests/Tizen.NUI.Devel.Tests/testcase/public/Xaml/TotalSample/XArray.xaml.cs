using NUnit.Framework;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.XArray.xaml",
    "testcase.public.Xaml.TotalSample.XArray.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.XArray))]

namespace Tizen.NUI.Devel.Tests
{
	[ContentProperty ("Content")]
	public class MockBindableForArray : View
	{
		public object Content { get; set; }
	}

    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\XArray.xaml")]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class XArray : MockBindableForArray
	{	
		public XArray ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(XArray));
        }

	}


	[TestFixture]
	public class XArrayTests
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
		public void SupportsXArray()
		{
			var layout = new XArray();
			var array = layout.Content;
			Assert.NotNull(array);
			Assert.That(array, Is.TypeOf<string[]>());
			Assert.AreEqual(2, ((string[])layout.Content).Length);
			Assert.AreEqual("Hello", ((string[])layout.Content)[0]);
			Assert.AreEqual("World", ((string[])layout.Content)[1]);
		}
	}
}