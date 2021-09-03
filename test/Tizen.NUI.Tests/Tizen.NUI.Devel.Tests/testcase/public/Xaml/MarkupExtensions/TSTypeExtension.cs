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
        private TypeExtension tExtension;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            tExtension = new TypeExtension();
        }

        [TearDown]
        public void Destroy()
        {
            tExtension = null;
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
                var name = tExtension.TypeName;
                tExtension.TypeName = name;
                Assert.AreEqual(name, tExtension.TypeName, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TypeExtensionTypeName END");
        }

        [Test]
        [Category("P2")]
        [Description("TypeExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.TypeExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeExtensionProvideValue()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue START");

            try
            {
                tExtension.TypeName = this.GetType().ToString();
                var type = tExtension.ProvideValue(new IServiceProviderImpl());
                tlog.Error(tag, "Type : " + type);
            }
            catch (ArgumentException e)     // typeResolver is null
            {
                tlog.Error(tag, e.Message.ToString());
                tlog.Debug(tag, $"TypeExtensionProvideValue END");
                Assert.Pass("Caught Exception : Passed!");
            }
        }
    }
}