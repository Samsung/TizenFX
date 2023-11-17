using NUnit.Framework;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class SetStyleIdFromXName : View
    {
        public SetStyleIdFromXName()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(SetStyleIdFromXName));
#pragma warning restore Reflection // The code contains reflection

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
        }
    }

    [TestFixture]
    public class SetStyleIdFromXNameTests
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
        public void SetStyleId()
        {
            var layout = new SetStyleIdFromXName();
            Assert.AreEqual("label0", layout.label0.StyleId, "Should be equal!");
            Assert.AreEqual("foo", layout.label1.StyleId, "Should be equal!");
            Assert.AreEqual("bar", layout.label2.StyleId, "Should be equal!");
        }
    }
}
