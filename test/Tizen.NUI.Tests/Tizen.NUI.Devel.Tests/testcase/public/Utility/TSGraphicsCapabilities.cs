using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/GraphicsCapabilities")]
    public class PublicGraphicsCapabilitiesTest
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
        [Description("GraphicsCapabilities IsBlendEquationSupported.")]
        [Property("SPEC", "Tizen.NUI.GraphicsCapabilities.IsBlendEquationSupported M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsCapabilitiesIsBlendEquationSupported()
        {
            tlog.Debug(tag, $"GraphicsCapabilitiesIsBlendEquationSupported START");

            try
            {
                GraphicsCapabilities.IsBlendEquationSupported(BlendEquationType.Color);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsCapabilitiesIsBlendEquationSupported END (OK)");
        }
    }
}
