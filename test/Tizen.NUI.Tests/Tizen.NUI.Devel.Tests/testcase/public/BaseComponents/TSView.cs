using global::System;
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
        [Description("View IsResourcesCreated.")]
        [Property("SPEC", "Tizen.NUI.View.IsResourcesCreated A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewIsResourcesCreated()
        {
            tlog.Debug(tag, $"ViewIsResourcesCreated START");

            var testingTarget = new MyView()
            {
                Layout = new LinearLayout(),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<View>(testingTarget, "Should return View instance.");

            var result = testingTarget.IsResourcesCreated;
            tlog.Debug(tag, "IsResourcesCreated : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewIsResourcesCreated END (OK)");
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
    }
}
