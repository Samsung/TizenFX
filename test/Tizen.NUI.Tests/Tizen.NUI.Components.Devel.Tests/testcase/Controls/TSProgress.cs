using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Progress")]
    public class ProgressTest
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

        internal class ProgressImpl : Progress
        {
            public ProgressImpl() : base()
            { }

            public void OnEnabledImpl(bool enabled)
            {
                base.OnEnabled(enabled);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Progress OnEnabled.")]
        [Property("SPEC", "Tizen.NUI.Components.Progress.OnEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ProgressOnEnabled()
        {
            tlog.Debug(tag, $"ProgressOnEnabled START");

            var testingTarget = new ProgressImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ProgressImpl>(testingTarget, "Should return ProgressImpl instance.");

            try
            {
                testingTarget.OnEnabledImpl(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ProgressOnEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Progress OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.Progress.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ProgressOnRelayout()
        {
            tlog.Debug(tag, $"ProgressOnEnabled START");

            var testingTarget = new ProgressImpl()
            {
                Size = new Size(100, 200)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ProgressImpl>(testingTarget, "Should return ProgressImpl instance.");

            try
            {
                testingTarget.OnRelayout(new Vector2(1920, 1080), null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ProgressOnEnabled END (OK)");
        }
    }
}
