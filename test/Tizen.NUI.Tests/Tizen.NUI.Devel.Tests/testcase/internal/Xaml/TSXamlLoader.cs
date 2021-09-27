using NUnit.Framework;
using System;
using System.IO;
using System.Xml;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/XamlLoader")]
    public class InternalXamlLoaderTest
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
        [Description("XamlLoader XamlFileProvider")]
        [Property("SPEC", "Tizen.NUI.Xaml.Internals.XamlLoader.XamlFileProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void XamlFileProvider()
        {
            tlog.Debug(tag, $"XamlFileProvider START");

            try
            {
                var mode = Xaml.Internals.XamlLoader.XamlFileProvider;
                Xaml.Internals.XamlLoader.XamlFileProvider = mode;
                Assert.AreEqual(mode, Xaml.Internals.XamlLoader.XamlFileProvider, "Should be equal");

                Xaml.Internals.XamlLoader.DoNotThrowOnExceptions = true;
                Assert.AreEqual(true, Xaml.Internals.XamlLoader.DoNotThrowOnExceptions, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlFileProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlLoader Create")]
        [Property("SPEC", "Tizen.NUI.Xaml.XamlLoader.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Create()
        {
            tlog.Debug(tag, $"Create START");

            try
            {
                string content = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                             "\r\n<View x:Class=\"Tizen.NUI.Devel.Tests.TotalSample\"" +
                             "\r\n        xmlns=\"http://tizen.org/Tizen.NUI/2018/XAML\"" +
                             "\r\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" >" +
                             "\r\n" +
                             "\r\n  <View Size=\"100,100\"  BackgroundColor=\"Red\" />" +
                             "\r\n</View>";
                using var textReader = new StringReader(content);
                using var reader = XmlReader.Create(textReader);
                var view = XamlLoader.Create(reader);
                Assert.IsNotNull(view, "Should not be null");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"Create END");
        }
    }
}