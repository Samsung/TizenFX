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
    }
}