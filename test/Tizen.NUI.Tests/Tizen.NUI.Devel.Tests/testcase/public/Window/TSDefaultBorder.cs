using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/ DefaultBorder.cs")]
    internal class PublicDefaultBorderTest
    {
        private const string tag = "NUITEST";

        internal class IBorderInterfaceImpl : IBorderInterface
        {
            public uint BorderLineThickness => 2;

            public uint TouchThickness => 2;

            public float BorderHeight => 3;

            public Size2D MinSize => new Size2D(1, 1);

            public Size2D MaxSize => new Size2D(5, 5);

            public Window BorderWindow
            {
                get => Window.Instance;
                set => this.BorderWindow = Window.Instance;
            }

            public bool OverlayMode => true;

            public Window.BorderResizePolicyType ResizePolicy => Window.BorderResizePolicyType.Free;

            public void CreateBorderView(View borderView) { }

            public bool CreateBottomBorderView(View bottomView) { return true; }

            public bool CreateTopBorderView(View topView) { return true; }

            public void Dispose() { }

            public void OnCreated(View borderView) { }

            public void OnMaximize(bool isMaximized) { }

            public void OnMinimize(bool isMinimized) { }

            public void OnOverlayMode(bool enabled) { }

            public void OnRequestResize() { }

            public void OnResized(int width, int height) { }

            public void OnMoved(int x, int y) { }
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
        [Description("Create a DefaultBorder object.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.contructor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderConstructor()
        {
            tlog.Debug(tag, $"DefaultBorderConstructor START");

            var testingTarget = new DefaultBorder();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"DefaultBorderConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultBorder MaxSize  ")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.MaxSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DefaultBorderMaxSize()
        {
            tlog.Debug(tag, $"DefaultBorderMaxSize START");

            var testingTarget = new DefaultBorder();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<DefaultBorder>(testingTarget, "Should return DefaultBorder instance.");

            testingTarget.MaxSize = new Size2D(100, 100);
            Assert.AreEqual(100, testingTarget.MaxSize.Width, "Should be equal!");
            Assert.AreEqual(100, testingTarget.MaxSize.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultBorderMaxSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("  DefaultBorder CreateTopBorderView.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.CreateTopBorderView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderCreateTopBorderViewtopView()
        {
            tlog.Debug(tag, $"DefaultBorderCreateTopBorderViewtopView START");

            using (View topView = new View() { Size = new Size(Window.Instance.WindowSize.Width, 10) })
            {
                var testingTarget = new DefaultBorder();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.CreateTopBorderView(topView);
                tlog.Debug(tag, "CreateTopBorderView : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"DefaultBorderCreateTopBorderViewtopView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("  DefaultBorder  CreateBottomBorderView.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.CreateBottomBorderView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderCreateTopBorderViewbottomView()
        {
            tlog.Debug(tag, $"DefaultBorderCreateBottomBorderViewbottomView START");

            using (View bottomView = new View() { Size = new Size(Window.Instance.WindowSize.Width, 10) })
            {
                var testingTarget = new DefaultBorder();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.CreateBottomBorderView(bottomView);
                tlog.Debug(tag, "CreateBottomBorderView : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"DefaultBorderCreateBottomBorderViewbottomView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("  DefaultBorder  CreateBorderView.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.CreateBorderView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderCreateBorderView()
        {
            tlog.Debug(tag, $"DefaultBorderCreateBorderView START");

            using (View borderView = new View())
            {
				var testingTarget = new DefaultBorder();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    testingTarget.CreateBorderView(borderView);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }
			
            tlog.Debug(tag, $"DefaultBorderCreateBorderView END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("  DefaultBorder  CreateBorderView1.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.CreateBorderView1 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderCreateBorderView1()
        {
            tlog.Debug(tag, $"DefaultBorderCreateBorderView1 START");

            var testingTarget = new DefaultBorder();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.CreateBorderView(null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultBorderCreateBorderView END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("DefaultBorder  OnResized.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.OnResized M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderOnResized()
        {
            tlog.Debug(tag, $"DefaultBorderOnResized START");

            var testingTarget = new DefaultBorder();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.OnResized(50, 50);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultBorderOnResized END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultBorder  OnOverlayMode.")]
        [Property("SPEC", "Tizen.NUI.DefaultBorder.OnOverlayMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DefaultBorderOnOverlayMode()
        {
            tlog.Debug(tag, $"DefaultBorderOnOverlayMode START");

            var testingTarget = new DefaultBorder();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultBorder>(testingTarget, "should be an instance of testing target class!");

            using (View view = new View())
            {
                testingTarget.CreateBorderView(view);
                testingTarget.OverlayMode = true;

                try
                {
                    testingTarget.OnOverlayMode(true);
                    testingTarget.OnOverlayMode(false);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultBorderOnOverlayMode END (OK)");
        }
	}
}