using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/TypeExtension")]
    public class PublicTypeExtensionTest
    {
        private const string tag = "NUITEST";
        private static TypeExtension t1;

        internal class IServiceProviderimplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            t1 = new TypeExtension();
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("TypeExtension TypeName")]
        [Property("SPEC", "Tizen.NUI.TypeExtension.TypeName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TypeExtensionTypeName()
        {
            tlog.Debug(tag, $"TypeExtensionTypeName START");

            try
            {
                string tmp = t1.TypeName;
                t1.TypeName = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TypeExtensionTypeName END (OK)");
            Assert.Pass("TypeExtensionTypeName");
        }

        [Test]
        [Category("P1")]
        [Description("TypeExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.TypeExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TypeExtensionProvideValue()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                t1.TypeName = "myTypeName";
                t1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TypeExtensionProvideValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}