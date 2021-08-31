using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/ReferenceExtension")]
    public class PublicReferenceExtensionTest
    {
        private const string tag = "NUITEST";
        private ReferenceExtension reference;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            reference = new ReferenceExtension();
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
    }
}