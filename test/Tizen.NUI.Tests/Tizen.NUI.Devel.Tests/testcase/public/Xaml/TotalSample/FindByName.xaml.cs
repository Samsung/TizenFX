using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

[assembly: XamlResourceId("Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.FindByName.xaml",
    "testcase.public.Xaml.TotalSample.FindByName.xaml",
    typeof(global::Tizen.NUI.Devel.Tests.FindByName))]

namespace Tizen.NUI.Devel.Tests
{
    [XamlFilePath("testcase\\public\\Xaml\\TotalSample\\FindByName.xaml")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindByName : View
	{
        public FindByName root;
        public TextLabel label0;

        public FindByName ()
		{
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FindByName));
            root = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<FindByName>(this, "root");
            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
        }

	}


	[TestFixture]
	public class FindByNameTests
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
		public void TestRootName()
		{
			var page = new FindByName();
			Assert.AreSame(page, page.root);
		}
	}
}