using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class FindByName : View
    {
        public FindByName()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(FindByName));
#pragma warning restore Reflection // The code contains reflection
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
            FindByName page = new FindByName();
            Assert.AreSame(page, page.root);
        }
    }
}