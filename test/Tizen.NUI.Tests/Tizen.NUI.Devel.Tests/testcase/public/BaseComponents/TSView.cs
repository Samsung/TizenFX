﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/View")]
    public class InternalViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyView : View
        {
            public MyView() : base()
            { }

            public void OnControlState(ControlState state)
            {
                this.ControlState = state;
            }
        }

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
        [Description("View constructor.")]
        [Property("SPEC", "Tizen.NUI.View.View C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewConstructor()
        {
            tlog.Debug(tag, $"ViewConstructor START");

            ViewStyle style = new ViewStyle()
            { 
                Color = Color.Cyan,
            };

            var testingTarget = new View(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            tlog.Debug(tag, "Culled : " + testingTarget.Culled);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View constructor.")]
        [Property("SPEC", "Tizen.NUI.View.View C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewConstructorWhetherShown()
        {
            tlog.Debug(tag, $"ViewConstructorWhetherShown START");

            var testingTarget = new View(true);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewConstructorWhetherShown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View LayoutSet.")]
        [Property("SPEC", "Tizen.NUI.View.LayoutSet A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLayoutSet()
        {
            tlog.Debug(tag, $"ViewLayoutSet START");

            var testingTarget = new View()
            {
                Layout = new LinearLayout(),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            var result = testingTarget.LayoutSet;
            tlog.Debug(tag, "LayoutSet : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewLayoutSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View ControlState.")]
        [Property("SPEC", "Tizen.NUI.View.ControlState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewControlState()
        {
            tlog.Debug(tag, $"ViewControlState START");

            var testingTarget = new MyView()
            {
                Layout = new LinearLayout(),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            var result = testingTarget.LayoutSet;
            tlog.Debug(tag, "LayoutSet : " + result);

            testingTarget.OnControlState(ControlState.Disabled);
            tlog.Debug(tag, "LayoutSet : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewControlState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View KeyInputFocus.")]
        [Property("SPEC", "Tizen.NUI.View.KeyInputFocus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewKeyInputFocus()
        {
            tlog.Debug(tag, $"ViewKeyInputFocus START");

            var testingTarget = new MyView()
            {
                Layout = new LinearLayout(),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            var result = testingTarget.KeyInputFocus;
            tlog.Debug(tag, "KeyInputFocus : " + result);

            testingTarget.KeyInputFocus = true;
            tlog.Debug(tag, "KeyInputFocus : " + testingTarget.KeyInputFocus);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewKeyInputFocus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View BackgroundImageBorder.")]
        [Property("SPEC", "Tizen.NUI.View.BackgroundImageBorder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewBackgroundImageBorder()
        {
            tlog.Debug(tag, $"ViewBackgroundImageBorder START");

            var testingTarget = new View()
            {
                Layout = new LinearLayout(),
                BackgroundImage = url,
                BackgroundImageBorder = new Rectangle(2, 2, 2, 2)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            var result = testingTarget.BackgroundImageBorder;
            tlog.Debug(tag, "BackgroundImageBorder : " + result);

            testingTarget.BackgroundImageBorder = new Rectangle(3, 3, 3, 3);
            tlog.Debug(tag, "BackgroundImageBorder : " + testingTarget.BackgroundImageBorder);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewBackgroundImageBorder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View BorderlineWidth.")]
        [Property("SPEC", "Tizen.NUI.View.BorderlineWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewBorderlineWidth()
        {
            tlog.Debug(tag, $"ViewBorderlineWidth START");

            var testingTarget = new View()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            testingTarget.BorderlineWidth = 2.0f;
            tlog.Debug(tag, "BorderlineWidth : " + testingTarget.BorderlineWidth);

            testingTarget.BorderlineColor = Color.Red;
            tlog.Debug(tag, "BorderlineColor : " + testingTarget.BorderlineColor);

            testingTarget.BorderlineOffset = 0.3f;
            tlog.Debug(tag, "BorderlineOffset : " + testingTarget.BorderlineOffset);

            testingTarget.TooltipText = "tooltipText";
            tlog.Debug(tag, "TooltipText : " + testingTarget.TooltipText);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewBorderlineWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View FocusableChildren.")]
        [Property("SPEC", "Tizen.NUI.View.FocusableChildren A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewFocusableChildren()
        {
            tlog.Debug(tag, $"ViewFocusableChildren START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
            };
            NUIApplication.GetDefaultWindow().Add(view);

            var child = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };

            view.Add(child);

            tlog.Debug(tag, "FocusableChildren : " + view.FocusableChildren);
            view.FocusableChildren = false;
            tlog.Debug(tag, "FocusableChildren : " + view.FocusableChildren);

            view.FocusableInTouch = true;
            tlog.Debug(tag, "FocusableInTouch : " + view.FocusableInTouch);

            NUIApplication.GetDefaultWindow().Remove(view);
            view.Dispose();
            tlog.Debug(tag, $"ViewFocusableChildren END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("View SetDefaultGrabTouchAfterLeave.")]
        [Property("SPEC", "Tizen.NUI.View.SetDefaultGrabTouchAfterLeave A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseComponentsViewSetDefaultGrabTouchAfterLeave()
        {
            tlog.Debug(tag, $"BaseComponentsViewSetDefaultGrabTouchAfterLeave START");

            try
			{
			    View.SetDefaultGrabTouchAfterLeave(true);
                View.SetDefaultAllowOnlyOwnTouch(true);
			}
			catch (Exception e)
            {
                tlog.Info(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BaseComponentsViewSetDefaultGrabTouchAfterLeave END (OK)");
        }
    }
}
