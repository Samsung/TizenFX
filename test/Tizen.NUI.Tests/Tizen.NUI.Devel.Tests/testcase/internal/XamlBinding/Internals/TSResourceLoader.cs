using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/ResourceLoader")]
    public class InternalResourceLoaderTest
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
        [Description("ResourceLoader constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.Internals.ResourceLoader.ResourceProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ResourceProvider()
        {
            tlog.Debug(tag, $"ResourceProvider START");
            try
            {
                var testingTarget = ResourceLoader.ResourceProvider;
                Assert.IsNotNull(testingTarget, "Should not be null.");
                ResourceLoader.ResourceProvider = testingTarget;
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"ResourceProvider END");
        }
    }
}
