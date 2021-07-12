using NUnit.Framework;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlFilePathAttribute")]
    internal class PublicXamlFilePathAttributeTest
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

            XamlFilePathAttribute x1 = new XamlFilePathAttribute("myPath");

            tlog.Debug(tag, $"XamlFilePathAttributeConstructor END (OK)");
            Assert.Pass("XamlFilePathAttributeConstructor");
        }
    }
}