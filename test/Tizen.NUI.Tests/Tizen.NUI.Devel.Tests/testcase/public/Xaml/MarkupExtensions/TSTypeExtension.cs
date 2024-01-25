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

        internal class IXamlTypeResolverImpl : IXamlTypeResolver
        {
            Type IXamlTypeResolver.Resolve(string qualifiedTypeName, IServiceProvider serviceProvider)
            {
                return typeof(string);
            }

            bool IXamlTypeResolver.TryResolve(string qualifiedTypeName, out Type type)
            {
                type = typeof(string);
                return true;
            }
        }

        internal class IServiceProviderImpl2 : IServiceProvider
        {
            public object GetService(Type serviceType) { return new IXamlTypeResolverImpl(); }
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
        [Property("SPEC", "Tizen.NUI.Xaml.TypeExtension.TypeName A")]
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
        [Property("SPEC", "Tizen.NUI.Xaml.TypeExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeExtensionProvideValue()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue START");

            tExtension.TypeName = this.GetType().ToString();
            Assert.Throws<ArgumentException>(() => tExtension.ProvideValue(new IServiceProviderImpl()));
            tlog.Debug(tag, $"TypeExtensionProvideValue END");
        }

        [Test]
        [Category("P2")]
        [Description("TypeExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeExtensionProvideValue2()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue2 START");
            Assert.Throws<InvalidOperationException>(() => tExtension.ProvideValue(null));
            tlog.Debug(tag, $"TypeExtensionProvideValue2 END");
        }

        [Test]
        [Category("P2")]
        [Description("TypeExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeExtensionProvideValue3()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue3 START");
            tExtension.TypeName = this.GetType().ToString();
            Assert.Throws<ArgumentNullException>(() => tExtension.ProvideValue(null));
            tlog.Debug(tag, $"TypeExtensionProvideValue3 END");
        }

        [Test]
        [Category("P1")]
        [Description("TypeExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.TypeExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void TypeExtensionProvideValue4()
        {
            tlog.Debug(tag, $"TypeExtensionProvideValue4 START");

            try
            {
                tExtension.TypeName = this.GetType().ToString();
                var ret = tExtension.ProvideValue(new IServiceProviderImpl2());
                Assert.IsNotNull(ret, "Should not be null");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"TypeExtensionProvideValue4 END");
        }
    }
}