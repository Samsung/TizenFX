using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Tizen.NUI.Window;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/Window")]
    internal class PublicWindowTest
    {
        private const string tag = "NUITEST";
        private Window win = null;
        private Rectangle rec = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            rec = new Rectangle(0, 0, 2, 2);
            win = new Window(rec);
        }

        [TearDown]
        public void Destroy()
        {
            rec.Dispose();
            if (win != null)
            {
                win.Destroy();
                win = null;
            }

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Window WindowPositionSize")]
        [Property("SPEC", "Tizen.NUI.Window.WindowPositionSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowWindowPositionSize()
        {
            tlog.Debug(tag, $"WindowWindowPositionSize START");

            try
            {
                using (Rectangle size = new Rectangle(1, 2, 3, 4))
                {
                    win.WindowPositionSize = size;
                    tlog.Debug(tag, "WindowPositionSize : " + win.WindowPositionSize);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowWindowPositionSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window GetLayer")]
        [Property("SPEC", "Tizen.NUI.Window.GetLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetLayer()
        {
            tlog.Debug(tag, $"WindowGetLayer START");
            
            try
            {
                win.GetLayer(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"WindowGetLayer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window GetCurrentOrientation")]
        [Property("SPEC", "Tizen.NUI.Window.GetCurrentOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetCurrentOrientation()
        {
            tlog.Debug(tag, $"WindowGetCurrentOrientation START");
            
            try
            {
                win.GetCurrentOrientation();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetCurrentOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window SetAvailableOrientations")]
        [Property("SPEC", "Tizen.NUI.Window.SetAvailableOrientations M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetAvailableOrientations()
        {
            tlog.Debug(tag, $"WindowSetAvailableOrientations START");
            try
            {
                List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();

                list.Add(Window.WindowOrientation.Landscape);
                list.Add(Window.WindowOrientation.LandscapeInverse);
                list.Add(Window.WindowOrientation.NoOrientationPreference);
                list.Add(Window.WindowOrientation.Portrait);
                list.Add(Window.WindowOrientation.PortraitInverse);

                win.SetAvailableOrientations(list);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"WindowSetAvailableOrientations END (OK)");
            Assert.Pass("WindowSetAvailableOrientations");
        }

        [Test]
        [Category("P2")]
        [Description("Window SetAvailableOrientations")]
        [Property("SPEC", "Tizen.NUI.Window.SetAvailableOrientations M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetAvailableOrientationsWithNullList()
        {
            tlog.Debug(tag, $"WindowSetAvailableOrientationsWithNullList START");

            List<Window.WindowOrientation> list = null;

            try
            {
                win.SetAvailableOrientations(list);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetAvailableOrientationsWithNullList END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window GetNativeId")]
        [Property("SPEC", "Tizen.NUI.Window.GetNativeId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetNativeId()
        {
            tlog.Debug(tag, $"WindowGetNativeId START");
            
            try
            {
                win.GetNativeId();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetNativeId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window GetNativeHandle")]
        [Property("SPEC", "Tizen.NUI.Window.GetNativeHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetNativeHandle()
        {
            tlog.Debug(tag, $"WindowGetNativeHandle START");
            
            try
            {
                win.GetNativeHandle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetNativeHandle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window Add")]
        [Property("SPEC", "Tizen.NUI.Window.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAdd()
        {
            tlog.Debug(tag, $"WindowAdd START");

            try
            {
                Layer layer = null;
                win.Add(layer);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowAdd END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window Remove")]
        [Property("SPEC", "Tizen.NUI.Window.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRemove()
        {
            tlog.Debug(tag, $"WindowRemove START");

            try
            {
                Layer layer = null;
                win.Remove(layer);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowRemove END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window GetRenderTaskList")]
        [Property("SPEC", "Tizen.NUI.Window.GetRenderTaskList M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetRenderTaskList()
        {
            tlog.Debug(tag, $"WindowGetRenderTaskList START");
            try
            {
                win.GetRenderTaskList();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetRenderTaskList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window SetWindowSize")]
        [Property("SPEC", "Tizen.NUI.Window.SetWindowSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetWindowSize()
        {
            tlog.Debug(tag, $"WindowSetWindowSize START");

            try
            {
                Size2D s1 = null;
                win.SetWindowSize(s1);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetWindowSize END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window SetPosition")]
        [Property("SPEC", "Tizen.NUI.Window.SetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetPosition()
        {
            tlog.Debug(tag, $"WindowSetPosition START");

            try
            {
                Position2D p1 = null;
                win.SetPosition(p1);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetPosition END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window SetPositionSize")]
        [Property("SPEC", "Tizen.NUI.Window.SetPositionSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetPositionSize()
        {
            tlog.Debug(tag, $"WindowSetPositionSize START");
            try
            {
                Rectangle r1 = new Rectangle(0, 0, 20, 20);
                win.SetPositionSize(r1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"WindowSetPositionSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window AddFrameUpdateCallback")]
        [Property("SPEC", "Tizen.NUI.Window.AddFrameUpdateCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddFrameUpdateCallback()
        {
            tlog.Debug(tag, $"WindowAddFrameUpdateCallback START");
            try
            {
                FrameUpdateCallbackInterface f1 = new FrameUpdateCallbackInterface();
                win.AddFrameUpdateCallback(f1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowAddFrameUpdateCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window RemoveFrameUpdateCallback")]
        [Property("SPEC", "Tizen.NUI.Window.RemoveFrameUpdateCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRemoveFrameUpdateCallback()
        {
            tlog.Debug(tag, $"WindowRemoveFrameUpdateCallback START");
            try
            {
                FrameUpdateCallbackInterface f1 = new FrameUpdateCallbackInterface();
                win.RemoveFrameUpdateCallback(f1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowRemoveFrameUpdateCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window AddFrameRenderedCallback")]
        [Property("SPEC", "Tizen.NUI.Window.AddFrameRenderedCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddFrameRenderedCallback()
        {
            tlog.Debug(tag, $"WindowAddFrameRenderedCallback START");
            
            try
            {
                FrameCallbackType f1 = null;
                win.AddFrameRenderedCallback(f1, 1);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowAddFrameRenderedCallback END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window AddFramePresentedCallback")]
        [Property("SPEC", "Tizen.NUI.Window.AddFramePresentedCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddFramePresentedCallback()
        {
            tlog.Debug(tag, $"WindowAddFramePresentedCallback START");
            
            try
            {
                FrameCallbackType f1 = null;
                win.AddFramePresentedCallback(f1, 1);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowAddFramePresentedCallback END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window Get")]
        [Property("SPEC", "Tizen.NUI.Window.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGet()
        {
            tlog.Debug(tag, $"WindowGet START");

            using (NUI.BaseComponents.View view = new NUI.BaseComponents.View() { Color = Color.Cyan })
            {
                NUIApplication.GetDefaultWindow().Add(view);
                
                try
                {
                    var result = Window.Get(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                NUIApplication.GetDefaultWindow().Remove(view);
            }

            tlog.Debug(tag, $"WindowGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window EnableFloatingMode")]
        [Property("SPEC", "Tizen.NUI.Window.EnableFloatingMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowEnableFloatingMode()
        {
            tlog.Debug(tag, $"WindowEnableFloatingMode START");

            try
            {
                Window.Instance.EnableFloatingMode(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            tlog.Debug(tag, $"WindowEnableFloatingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window RequestMoveToServer")]
        [Property("SPEC", "Tizen.NUI.Window.RequestMoveToServer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRequestMoveToServer()
        {
            tlog.Debug(tag, $"WindowRequestMoveToServer START");

            try
            {
                Window.Instance.RequestMoveToServer();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowRequestMoveToServer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window RequestResizeToServer")]
        [Property("SPEC", "Tizen.NUI.Window.RequestResizeToServer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRequestResizeToServer()
        {
            tlog.Debug(tag, $"WindowRequestResizeToServer START");

            try
            {
                Window.Instance.RequestResizeToServer(ResizeDirection.Top);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowRequestResizeToServer END (OK)");
        }
    }
}
