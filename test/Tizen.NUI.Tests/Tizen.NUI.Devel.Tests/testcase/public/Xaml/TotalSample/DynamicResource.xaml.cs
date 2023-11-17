using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    public partial class DynamicResource : View
    {
        public DynamicResource()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(DynamicResource));
#pragma warning restore Reflection // The code contains reflection
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
            DynamicResource layout = new DynamicResource();
            TextLabel label = layout.label0;

            Assert.AreEqual(string.Empty, label.Text, "Should be equal");

            layout.XamlResources = new ResourceDictionary {
                    {"FooBar", "FOOBAR"},
            };
            Assert.AreEqual("FOOBAR", label.Text);
        }
    }
}