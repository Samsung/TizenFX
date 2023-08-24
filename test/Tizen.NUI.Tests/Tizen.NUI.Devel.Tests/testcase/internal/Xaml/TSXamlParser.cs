using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/XamlParser")]
    public class InternalXamlParserTest
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
        [Description("XamlParser GetElementTypeExtension")]
        [Property("SPEC", "Tizen.NUI.Xaml.XamlParser.GetElementTypeExtension M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetElementTypeExtension()
        {
            tlog.Debug(tag, $"GetElementTypeExtension START");

            try
            {
                var xt = new XmlType("http://tizen.org/Tizen.NUI/2018/XAML", "View", null);
                var t = XamlParser.GetElementTypeExtension(xt, null, typeof(UIElement).Assembly);
                Assert.IsNull(t, "Should be null");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"GetElementTypeExtension END");
        }

    }
}