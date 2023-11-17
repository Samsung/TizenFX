using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class BuiltInConversions : View
    {
        public BuiltInConversions()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BuiltInConversions));
#pragma warning restore Reflection // The code contains reflection

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
        }
    }

    [TestFixture]
    public class BuiltInConversionsTests
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
        public void BuiltInConversionsString()
        {
            var layout = new BuiltInConversions();

            Assert.AreEqual("foobar", layout.label0.Text);
            Assert.AreEqual("foobar", layout.label1.Text);

            //Issue #2122, implicit content property not trimmed
            Assert.AreEqual(string.Empty, layout.label2.Text);
        }
    }
}