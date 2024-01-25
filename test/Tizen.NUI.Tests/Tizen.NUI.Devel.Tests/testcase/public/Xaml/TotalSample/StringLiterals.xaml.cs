using NUnit.Framework;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;


namespace Tizen.NUI.Devel.Tests
{
    public partial class StringLiterals : View
    {
        public StringLiterals()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(StringLiterals));
#pragma warning restore Reflection // The code contains reflection

            label0 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label0");
            label1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label1");
            label2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label2");
            label3 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<TextLabel>(this, "label3");
        }
    }

    [TestFixture]
    public class StringLiteralsTests
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
        public void EscapedStringsAreTreatedAsLiterals()
        {
            var layout = new StringLiterals();
            Assert.AreEqual("Foo", layout.label0.Text);
            Assert.AreEqual("{Foo}", layout.label1.Text);
            Assert.AreEqual(string.Empty, layout.label2.Text);
            Assert.AreEqual("Foo", layout.label3.Text);
        }
    }
}