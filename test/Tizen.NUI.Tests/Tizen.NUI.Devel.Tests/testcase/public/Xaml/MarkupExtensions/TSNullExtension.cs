using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/NullExtension")]
    public class PublicNullExtensionTest
    {
        private const string tag = "NUITEST";

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

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
        [Description("NullExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.NullExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NullExtensionProvideValue()
        {
            tlog.Debug(tag, $"NullExtensionProvideValue START");

            try
            {
                var testingTarget = new NullExtension();
                Assert.IsNotNull(testingTarget, "null NullExtension");

                testingTarget.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NullExtensionProvideValue END");
        }
    }
}