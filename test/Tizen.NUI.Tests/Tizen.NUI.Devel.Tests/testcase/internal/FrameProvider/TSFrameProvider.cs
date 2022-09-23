using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.Applications;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/FrameProvider/FrameProvider")]
    public class InternalFrameProviderTest
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
        [Description("FrameProvider FrameProvider.")]
        [Property("SPEC", "Tizen.NUI.FrameProvider.FrameProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameProviderWithWindow()
        {
            tlog.Debug(tag, $"FrameProviderWithWindow START");

            var testingTarget = new FrameProvider(Window.Instance);
            Assert.IsNotNull(testingTarget, "Can't create success object FrameProvider");
            Assert.IsInstanceOf<FrameProvider>(testingTarget, "Should be an instance of FrameProvider type.");

            testingTarget.Dispose();
            
            tlog.Debug(tag, $"FrameProviderWithWindow END (OK)");            
        }
	}
}