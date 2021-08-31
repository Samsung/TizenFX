using NUnit.Framework;
using System;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/StaticResourceExtension")]
    public class PublicStaticResourceExtensionTest
    {
        private const string tag = "NUITEST";
        private StaticResourceExtension staticRes;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            staticRes = new StaticResourceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            staticRes = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("StaticResourceExtension Key")]
        [Property("SPEC", "Tizen.NUI.StaticResourceExtension.Key A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StaticResourceExtensionKey()
        {
            tlog.Debug(tag, $"StaticResourceExtensionKey START");
            try
            {
                string key = staticRes.Key;
                staticRes.Key = key;
                Assert.AreEqual(key, staticRes.Key, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"StaticResourceExtensionKey END");
        }
    }
}