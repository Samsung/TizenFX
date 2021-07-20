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
        private static Window myWin;
        [SetUp]
        public void Init()
        {
            Rectangle r1 = new Rectangle(0, 0, 20, 20);
            myWin = new Window(r1);
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            if (myWin != null)
            {
                myWin.Destroy();
                myWin = null;
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
                myWin.WindowPositionSize = new Rectangle(1, 2, 3, 4);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowWindowPositionSize END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Window DEFAULT_BACKGROUND_COLOR")]
        //[Property("SPEC", "Tizen.NUI.Window.DEFAULT_BACKGROUND_COLOR A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void WindowDEFAULT_BACKGROUND_COLOR()
        //{
        //    tlog.Debug(tag, $"WindowDEFAULT_BACKGROUND_COLOR START");
        //    try
        //    {
        //        Vector4 v1 = Window.DEFAULT_BACKGROUND_COLOR;
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());

        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"WindowDEFAULT_BACKGROUND_COLOR END (OK)");
        //    Assert.Pass("WindowDEFAULT_BACKGROUND_COLOR");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("Window DEBUG_BACKGROUND_COLOR")]
        //[Property("SPEC", "Tizen.NUI.Window.DEBUG_BACKGROUND_COLOR A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void WindowDEBUG_BACKGROUND_COLOR()
        //{
        //    tlog.Debug(tag, $"WindowDEBUG_BACKGROUND_COLOR START");
        //    try
        //    {
        //        Vector4 v1 = Window.DEBUG_BACKGROUND_COLOR;
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());

        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"WindowDEBUG_BACKGROUND_COLOR END (OK)");
        //    Assert.Pass("WindowDEBUG_BACKGROUND_COLOR");
        //}

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
                myWin.GetLayer(0);
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
                myWin.GetCurrentOrientation();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetCurrentOrientation END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Window SetAvailableOrientations")]
        //[Property("SPEC", "Tizen.NUI.Window.SetAvailableOrientations M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void WindowSetAvailableOrientations()
        //{
        //    tlog.Debug(tag, $"WindowSetAvailableOrientations START");
        //    try
        //    {
        //        List<Window.WindowOrientation> l1 = new List<Window.WindowOrientation>();

        //        l1.Add(Window.WindowOrientation.Landscape);
        //        l1.Add(Window.WindowOrientation.LandscapeInverse);
        //        l1.Add(Window.WindowOrientation.NoOrientationPreference);
        //        l1.Add(Window.WindowOrientation.Portrait);
        //        l1.Add(Window.WindowOrientation.PortraitInverse);

        //        myWin.SetAvailableOrientations(l1);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"WindowSetAvailableOrientations END (OK)");
        //    Assert.Pass("WindowSetAvailableOrientations");
        //}

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
                myWin.GetNativeId();
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
                myWin.GetNativeHandle();
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
                myWin.Add(layer);
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
                myWin.Remove(layer);
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
                myWin.GetRenderTaskList();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetRenderTaskList END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Window GetObjectRegistry")]
        //[Property("SPEC", "Tizen.NUI.Window.GetObjectRegistry M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void WindowGetObjectRegistry()
        //{
        //    tlog.Debug(tag, $"WindowGetObjectRegistry START");
        //    try
        //    {
        //        myWin.GetObjectRegistry();
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());

        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"WindowGetObjectRegistry END (OK)");
        //    Assert.Pass("WindowGetObjectRegistry");
        //}

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
                myWin.SetWindowSize(s1);
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
                myWin.SetPosition(p1);
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
                myWin.SetPositionSize(r1);
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
                myWin.AddFrameUpdateCallback(f1);
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
                myWin.RemoveFrameUpdateCallback(f1);
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
                myWin.AddFrameRenderedCallback(f1, 1);
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
                myWin.AddFramePresentedCallback(f1, 1);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowAddFramePresentedCallback END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
    }
}