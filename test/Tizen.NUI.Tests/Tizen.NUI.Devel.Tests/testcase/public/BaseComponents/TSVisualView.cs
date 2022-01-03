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
    [Description("public/BaseComponents/VisualView")]
    class TSVisualView
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
        [Description("VisualView constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualView.VisualView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualViewConstructor()
        {
            tlog.Debug(tag, $"VisualViewConstructor START");

            ViewStyle style = new ViewStyle()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };

            var testingTarget = new VisualView(style);
            Assert.IsNotNull(testingTarget, "Can't create success object VisualView");
            Assert.IsInstanceOf<VisualView>(testingTarget, "Should be an instance of VisualView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualView constructor. With CustomViewBehaviour.")]
        [Property("SPEC", "Tizen.NUI.VisualView.VisualView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualViewConstructorWithCustomViewBehaviour()
        {
            tlog.Debug(tag, $"VisualViewConstructorWithCustomViewBehaviour START");

            ViewStyle style = new ViewStyle()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };

            var testingTarget = new VisualView(CustomViewBehaviour.DisableStyleChangeSignals, style);
            Assert.IsNotNull(testingTarget, "Can't create success object VisualView");
            Assert.IsInstanceOf<VisualView>(testingTarget, "Should be an instance of VisualView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualViewConstructorWithCustomViewBehaviour END (OK)");
        }
    }
}
