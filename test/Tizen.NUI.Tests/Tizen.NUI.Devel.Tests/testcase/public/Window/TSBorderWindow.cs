using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.Window;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/ BorderWindow.cs")]
    internal class PublicBorderWindowTest
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
        [Description("Window EnableBorder")]
        [Property("SPEC", "Tizen.NUI.Window.EnableBorder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "RM")]
        public void BorderWindowEnableBorder()
        {
            tlog.Debug(tag, $"WindowBorderDestroy START");

            try
            {
                  var testingTarget = new Window();
                  testingTarget.EnableBorder(null, null);
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BorderWindowEnableBorder END (OK)");
        }
	}
}
