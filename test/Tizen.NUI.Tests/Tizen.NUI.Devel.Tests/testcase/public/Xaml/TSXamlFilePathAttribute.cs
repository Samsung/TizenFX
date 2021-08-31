using NUnit.Framework;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlFilePathAttribute")]
    public class PublicXamlFilePathAttributeTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XamlFilePathAttribute XamlFilePathAttribute")]
        [Property("SPEC", "Tizen.NUI.XamlFilePathAttribute.XamlFilePathAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlFilePathAttributeConstructor()
        {
            tlog.Debug(tag, $"XamlFilePathAttributeConstructor START");

            var testingTarget = new XamlFilePathAttribute("myPath");
            Assert.IsNotNull(testingTarget, "null XamlFilePathAttribute");
            Assert.IsInstanceOf<XamlFilePathAttribute>(testingTarget, "Should return XamlFilePathAttribute instance.");

            testingTarget = null;
            tlog.Debug(tag, $"XamlFilePathAttributeConstructor END");
        }
    }
}