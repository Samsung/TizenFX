using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/ReferenceExtension")]
    public class PublicReferenceExtensionTest
    {
        private const string tag = "NUITEST";
        private Tizen.NUI.Xaml.ReferenceExtension reference;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        internal class IServiceProviderImpl2 : IServiceProvider
        {
            public object GetService(Type serviceType) { return new NameScopeProvider() { NameScope = new NameScope() { } }; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            reference = new Tizen.NUI.Xaml.ReferenceExtension();
        }

        [TearDown]
        public void Destroy()
        {
            reference = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ReferenceExtension Name")]
        [Property("SPEC", "Tizen.NUI.ReferenceExtension.Name A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ReferenceExtensionName()
        {
            tlog.Debug(tag, $"ReferenceExtensionName START");

            try
            {
                var name = reference.Name;
                reference.Name = name;
                Assert.AreEqual(name, reference.Name, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ReferenceExtensionName END");
        }

        [Test]
        [Category("P2")]
        [Description("ReferenceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.ReferenceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReferenceExtensionProvideValue()
        {
            tlog.Debug(tag, $"ReferenceExtensionProvideValue START");
            Assert.Throws<ArgumentException>(() => reference.ProvideValue(new IServiceProviderImpl()));
            tlog.Debug(tag, $"ReferenceExtensionProvideValue END");
        }

        [Test]
        [Category("P2")]
        [Description("ReferenceExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.ReferenceExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ReferenceExtensionProvideValue2()
        {
            tlog.Debug(tag, $"ReferenceExtensionProvideValue2 START");
            Assert.Throws<ArgumentNullException>(() => reference.ProvideValue(null));
            tlog.Debug(tag, $"ReferenceExtensionProvideValue2 END");
        }
    }
}