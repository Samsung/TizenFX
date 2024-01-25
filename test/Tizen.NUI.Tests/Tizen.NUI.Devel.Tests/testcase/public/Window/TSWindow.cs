using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Tizen.NUI.Window;
using System.Reflection;
using Tizen.NUI.BaseComponents;

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

            rec = new Rectangle(0, 0, 100, 200);
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
                win.WindowPositionSize = rec;
                tlog.Debug(tag, "WindowPositionSize : " + win.WindowPositionSize);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowWindowPositionSize END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Window WindowPositionSize, with null.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowPositionSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowWindowPositionSizeWithNull()
        {
            tlog.Debug(tag, $"WindowWindowPositionSizeWithNull START");

            try
            {
                Rectangle pointSize = null;
                win.WindowPositionSize = pointSize;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowWindowPositionSizeWithNull END (OK)");
                Assert.Pass("Caught Exception : Failed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window WindowPosition")]
        [Property("SPEC", "Tizen.NUI.Window.WindowPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowWindowPosition()
        {
            tlog.Debug(tag, $"WindowWindowPosition START");

            tlog.Debug(tag, "WindowPosition : X , " + win.WindowPosition.X);
            tlog.Debug(tag, "WindowPosition : Y , " + win.WindowPosition.Y);
           
            using ( Position2D pos = new Position2D(100, 200))
            {
                win.WindowPosition = pos;
                tlog.Debug(tag, "WindowPosition : X , " + pos.X);
                tlog.Debug(tag, "WindowPosition : Y , " + pos.Y);
            }
            
            tlog.Debug(tag, $"WindowWindowPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window WindowPosition, with null.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowWindowPositionWithNull()
        {
            tlog.Debug(tag, $"WindowWindowPositionWithNull START");

            try
            {
                Position2D pos = null;
                win.WindowPosition = pos;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowWindowPositionWithNull END (OK)");
                Assert.Pass("Caught ArgumentNUllException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window Title")]
        [Property("SPEC", "Tizen.NUI.Window.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowTitle()
        {
            tlog.Debug(tag, $"WindowTitle START");

            win.Title = "title";
            tlog.Debug(tag, "Title : " + win.Title);

            tlog.Debug(tag, $"WindowTitle END (OK)");
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
                win.GetNativeId();
                win.GetCurrentOrientation();
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
        [Description("Window SetAcceptFocus")]
        [Property("SPEC", "Tizen.NUI.Window.SetAcceptFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetAcceptFocus()
        {
            tlog.Debug(tag, $"WindowSetAcceptFocus START");

            win.SetAcceptFocus(true);
            Assert.IsTrue(win.IsFocusAcceptable());

            tlog.Debug(tag, $"WindowSetAcceptFocus END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window Show")]
        [Property("SPEC", "Tizen.NUI.Window.Show M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowShow()
        {
            tlog.Debug(tag, $"WindowShow START");

            try
            { 
                win.Show();
                win.Hide();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowShow END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window AddAuxiliaryHint")]
        [Property("SPEC", "Tizen.NUI.Window.AddAuxiliaryHint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddAuxiliaryHint()
        {
            tlog.Debug(tag, $"WindowAddAuxiliaryHint START");

            try
            {    
                var id1 = win.AddAuxiliaryHint("wm.policy.win.resize_aspect_ratio", "0");
                tlog.Debug(tag, "Auxiliary hint1 : " + id1);

                var id2 = win.AddAuxiliaryHint("wm.policy.win.reset_audio_volume", "1");
                tlog.Debug(tag, "Auxiliary hint2 : " + id2);

                var cnt = win.GetSupportedAuxiliaryHintCount();
                tlog.Debug(tag, "GetSupportedAuxiliaryHintCount : " + cnt);

                win.GetSupportedAuxiliaryHint(1);
                win.RemoveAuxiliaryHint(id1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowAddAuxiliaryHint END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetAuxiliaryHintValue")]
        [Property("SPEC", "Tizen.NUI.Window.SetAuxiliaryHintValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetAuxiliaryHintValue()
        {
            tlog.Debug(tag, $"WindowSetAuxiliaryHintValue START");

            try
            {
                var id0 = win.AddAuxiliaryHint("wm.policy.win.resize_aspect_ratio", "0");
                tlog.Debug(tag, "Auxiliary hint : " + id0);

                win.SetAuxiliaryHintValue(id0, "1");
                var result =  win.GetAuxiliaryHintValue(id0);
                Assert.AreEqual("1", result, "Should be equal!");

                var id1 = win.GetAuxiliaryHintId("wm.policy.win.resize_aspect_ratio");
                Assert.AreEqual(id0, id1, "Should be equal!");
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetAuxiliaryHintValue END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetOpaqueState")]
        [Property("SPEC", "Tizen.NUI.Window.SetOpaqueState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetOpaqueState()
        {
            tlog.Debug(tag, $"WindowSetOpaqueState START");

            win.SetOpaqueState(true);
            Assert.IsTrue(win.IsOpaqueState());

            tlog.Debug(tag, $"WindowSetOpaqueState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window SetBrightness")]
        [Property("SPEC", "Tizen.NUI.Window.SetBrightness M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetBrightness()
        {
            tlog.Debug(tag, $"WindowSetBrightness START");

            try
            {
                var result = win.SetBrightness(50);
                tlog.Debug(tag, "SetBrightness : " + result);
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetBrightness END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window SetClass")]
        [Property("SPEC", "Tizen.NUI.Window.SetClass M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetClass()
        {
            tlog.Debug(tag, $"WindowSetClass START");

            try
            {   
                win.SetClass("windowTitle", "");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
        }
		
		[Test]
        [Category("P1")]
        [Description("Window Raise")]
        [Property("SPEC", "Tizen.NUI.Window.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRaise()
        {
            tlog.Debug(tag, $"WindowRaise START");

            try
            {
                win.Raise();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowRaise END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window Lower")]
        [Property("SPEC", "Tizen.NUI.Window.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowLower()
        {
            tlog.Debug(tag, $"WindowLower START");

            try
            {    
                win.Lower();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowLower END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window Activate")]
        [Property("SPEC", "Tizen.NUI.Window.Activate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowActivate()
        {
            tlog.Debug(tag, $"WindowActivate START");

            try
            { 
                win.Activate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowActivate END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window KeepRendering")]
        [Property("SPEC", "Tizen.NUI.Window.KeepRendering M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowKeepRendering()
        {
            tlog.Debug(tag, $"WindowKeepRendering START");

            try
            {
                win.KeepRendering(3000);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowKeepRendering END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GrabKeyTopmost")]
        [Property("SPEC", "Tizen.NUI.Window.GrabKeyTopmost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGrabKeyTopmost()
        {
            tlog.Debug(tag, $"WindowGrabKeyTopmost START");

            try
            {
                win.GrabKeyTopmost(50);
                win.UngrabKeyTopmost(50);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGrabKeyTopmost END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GrabKey")]
        [Property("SPEC", "Tizen.NUI.Window.GrabKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGrabKey()
        {
            tlog.Debug(tag, $"WindowGrabKey START");

            try
            {
                win.GrabKey(50, KeyGrabMode.Shared);
                win.UngrabKey(50);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowUngrabKey END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetKeyboardRepeatInfo")]
        [Property("SPEC", "Tizen.NUI.Window.SetKeyboardRepeatInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetKeyboardRepeatInfo()
        {
            tlog.Debug(tag, $"WindowSetKeyboardRepeatInfo START");

            try
            {
                win.SetKeyboardRepeatInfo(50.0f, 0.3f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetKeyboardRepeatInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window AddLayer")]
        [Property("SPEC", "Tizen.NUI.Window.AddLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddLayer()
        {
            tlog.Debug(tag, $"WindowAddLayer START");

            try
            {
                using (Layer layer = new Layer())
                {
                    win.AddLayer(layer);
                    tlog.Debug(tag, "GetLayerCount : " + win.GetLayerCount());
                    win.RemoveLayer(layer);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowAddLayer END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Window AddLayer, layer is null.")]
        [Property("SPEC", "Tizen.NUI.Window.AddLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddLayerWithNull()
        {
            tlog.Debug(tag, $"WindowAddLayerWithNull START");

            try
            {
                Layer layer = null;
                win.AddLayer(layer);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowAddLayerWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Window RemoveLayer, layer is null.")]
        [Property("SPEC", "Tizen.NUI.Window.RemoveLayer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowRemoveLayerWithNull()
        {
            tlog.Debug(tag, $"WindowRemoveLayerWithNull START");

            try
            {
                Layer layer = null;
                win.RemoveLayer(layer);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowRemoveLayerWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window FeedKey")]
        [Property("SPEC", "Tizen.NUI.Window.FeedKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowFeedKey()
        {
            tlog.Debug(tag, $"WindowFeedKey START");

            try
            {
                using (Key key = new Key() {  })
                {
                    win.FeedKey(key);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowFeedKey END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetTransparency")]
        [Property("SPEC", "Tizen.NUI.Window.SetTransparency M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetTransparency()
        {
            tlog.Debug(tag, $"WindowSetTransparency START");

            try
            {
                win.SetTransparency(true);	
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetTransparency END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window ObjectDump")]
        [Property("SPEC", "Tizen.NUI.Window.ObjectDump M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowObjectDump()
        {
            tlog.Debug(tag, $"WindowObjectDump START");

            try
            {
                using (View view = new View())
                {
                    win.GetRootLayer().Add(view);
                    win.ObjectDump();
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowObjectDump END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Window GetPreferredOrientation")]
        [Property("SPEC", "Tizen.NUI.Window.GetPreferredOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetPreferredOrientation()
        {
            tlog.Debug(tag, $"WindowGetPreferredOrientation START");

            try
            {
                var orientation = Window.WindowOrientation.Portrait;
                Window.Instance.AddAvailableOrientation(orientation);

                orientation = Window.WindowOrientation.LandscapeInverse;
                Window.Instance.SetPreferredOrientation(orientation);

                var result = Window.Instance.GetPreferredOrientation();
                Assert.AreEqual(Window.WindowOrientation.LandscapeInverse, result, "Should be equal!");

                Window.Instance.RemoveAvailableOrientation(orientation);
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetPreferredOrientation END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Window SetMimimumSize")]
        [Property("SPEC", "Tizen.NUI.Window.SetMimimumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetMimimumSizeWithNull()
        {
            tlog.Debug(tag, $"WindowSetMimimumSizeWithNull START");

            try
            {
                Size2D size = null;
                win.SetMimimumSize(size);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetMimimumSizeWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Window SetMimimumSize")]
        [Property("SPEC", "Tizen.NUI.Window.SetMimimumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetMimimumSize()
        {
            tlog.Debug(tag, $"WindowSetMimimumSize START");

            try
            {
                using (Size2D size = new Size2D(100, 200))
                {
                    win.SetMimimumSize(size);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetMimimumSize START");
        }

        [Test]
        [Category("P1")]
        [Description("Window IsMinimized")]
        [Property("SPEC", "Tizen.NUI.Window.IsMinimized M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowIsMinimized()
        {
            tlog.Debug(tag, $"WindowIsMinimized START");

            try
            {
                var result = win.IsMinimized();
                tlog.Debug(tag, "IsMinimized : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowIsMinimized END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window IsWindowRotating")]
        [Property("SPEC", "Tizen.NUI.Window.IsWindowRotating M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowIsWindowRotating()
        {
            tlog.Debug(tag, $"WindowIsWindowRotating START");

            try
            {
                var result = win.IsWindowRotating();
                tlog.Debug(tag, "IsWindowRotating : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowIsWindowRotating END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GetLastKeyEvent")]
        [Property("SPEC", "Tizen.NUI.Window.GetLastKeyEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetLastKeyEvent()
        {
            tlog.Debug(tag, $"WindowGetLastKeyEvent START");

            try
            {
                var result = win.GetLastKeyEvent();
                Assert.IsInstanceOf<Key>(result, "Should be an Instance of Key !");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetLastKeyEvent END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GetLastTouchEvent")]
        [Property("SPEC", "Tizen.NUI.Window.GetLastTouchEvent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetLastTouchEvent()
        {
            tlog.Debug(tag, $"WindowGetLastTouchEvent START");

            try
            {
                win.GetLastTouchEvent();	
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetLastTouchEvent END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("Window FindLayerByID")]
        [Property("SPEC", "Tizen.NUI.Window.FindLayerByID M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowFindLayerByID()
        {
            tlog.Debug(tag, $"WindowFindLayerByID START");

            try
            {
                using (Layer layer = new Layer())
                {
                    win.Add(layer);
                    win.FindLayerByID(layer.GetId());
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowFindLayerByID END (OK)");
        }
	
		[Test]
        [Category("P1")]
        [Description("Window NativeHandle")]
        [Property("SPEC", "Tizen.NUI.Window.NativeHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowNativeHandle()
        {
            tlog.Debug(tag, $"WindowNativeHandle START");

            var testingTarget = NUIApplication.GetDefaultWindow();
            Assert.IsNotNull(testingTarget, "Can't create success object Window.");
            Assert.IsInstanceOf<Window>(testingTarget, "Should return Window instance.");

            var handle = testingTarget.NativeHandle;
            tlog.Debug(tag, "IsInvalid : " + handle.IsInvalid);

            tlog.Debug(tag, $"WindowFindLayerByID END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("Window SetMaximumSize, with null.")]
        [Property("SPEC", "Tizen.NUI.Window.SetMaximumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetMaximumSizewithNull()
        {
            tlog.Debug(tag, $"WindowSetMaximumSizewithNull START");

            try
            {
                Size2D size = null;
                win.SetMaximumSize(size);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowSetMaximumSizewithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetMaximumSize")]
        [Property("SPEC", "Tizen.NUI.Window.SetMaximumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetMaximumSize()
        {
            tlog.Debug(tag, $"WindowSetMaximumSize START");

            try
            {
                using (Size2D size = new Size2D(50, 50))
                {
                    win.SetMaximumSize(size);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());                
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetMaximumSize END (OK)");
        }		

		[Test]
        [Category("P1")]
        [Description("Window Maximize")]
        [Property("SPEC", "Tizen.NUI.Window.Maximize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowMaximize()
        {
            tlog.Debug(tag, $"WindowMaximize START");

            try
            {
                win.Maximize(true);
                Assert.IsTrue(win.IsMaximized());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowMaximize END (OK)");
        }


		[Test]
        [Category("P1")]
        [Description("Window Minimize")]
        [Property("SPEC", "Tizen.NUI.Window.Minimize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowMinimize()
        {
            tlog.Debug(tag, $"WindowMinimize START");

            try
            {
                win.Minimize(true);
                Assert.IsTrue(win.IsMinimized());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowMinimize END (OK)");
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
        [Description("Window WindowSize")]
        [Property("SPEC", "Tizen.NUI.Window.WindowSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowWindowSize()
        {
            tlog.Debug(tag, $"WindowWindowSize START");

            try
            {
                Size2D s1 = new Size2D(100, 200);
                win.WindowSize = s1;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetWindowSize END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Window WindowSize, with null.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowWindowSizeWithNull()
        {
            tlog.Debug(tag, $"WindowWindowSizeWithNull START");

            try
            {
                Size2D size = null;
                win.WindowSize = size;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"WindowWindowSizeWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
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
                FrameUpdateCallbackInterface callback = new FrameUpdateCallbackInterface();
                win.AddFrameUpdateCallback(callback);
                win.RemoveFrameUpdateCallback(callback);
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
        [Description("Window AddFrameRenderedCallback")]
        [Property("SPEC", "Tizen.NUI.Window.AddFrameRenderedCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAddFrameRenderedCallback()
        {
            tlog.Debug(tag, $"WindowAddFrameRenderedCallback START");
            
            try
            {
                FrameCallbackType callback = null;
                win.AddFrameRenderedCallback(callback, 1);
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
                FrameCallbackType callback = null;
                win.AddFramePresentedCallback(callback, 1);
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
        [Description("Window IsVisible")]
        [Property("SPEC", "Tizen.NUI.Window.IsVisible M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowIsVisible()
        {
            tlog.Debug(tag, $"WindowIsVisible START");

            try
            {   
                win.IsVisible();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowIsVisible END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GetNotificationLevel")]
        [Property("SPEC", "Tizen.NUI.Window.GetNotificationLevel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetNotificationLevel()
        {
            tlog.Debug(tag, $"WindowGetNotificationLevel START");

            try
            {
                win.SetNotificationLevel(NotificationLevel.Medium);
                var result = win.GetNotificationLevel();
                tlog.Error(tag, "NotificationLevel : " + result);
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught ArgumentNullException : Failed!");
            }

            tlog.Debug(tag, $"WindowGetNotificationLevel END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window SetInputRegion")]
        [Property("SPEC", "Tizen.NUI.Window.SetInputRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetInputRegion()
        {
            tlog.Debug(tag, $"WindowSetInputRegion START");

            try
            {
                Window.Instance.SetInputRegion(rec);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetInputRegion END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window GetScreenOffMode")]
        [Property("SPEC", "Tizen.NUI.Window.GetScreenOffMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetScreenOffMode()
        {
            tlog.Debug(tag, $"WindowGetScreenOffMode START");

            try
            {
                win.SetScreenOffMode(ScreenOffMode.Timout);
                var result = win.GetScreenOffMode();
                Assert.AreEqual(ScreenOffMode.Timout, result, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetScreenOffMode END (OK)");
        }		
		
		[Test]
        [Category("P1")]
        [Description("Window GetKeyboardRepeatInfo")]
        [Property("SPEC", "Tizen.NUI.Window.GetKeyboardRepeatInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetKeyboardRepeatInfo()
        {
            tlog.Debug(tag, $"WindowGetKeyboardRepeatInfo START");

            try
            {
                win.SetKeyboardRepeatInfo(1.0f, 0.3f);
                win.GetKeyboardRepeatInfo(out float rate, out float delay);
                Assert.AreEqual(1.0f, rate, "Should be equal!");
                Assert.AreEqual(0.3f, delay, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetKeyboardRepeatInfo END (OK)");
        }				
		
		[Test]
        [Category("P1")]
        [Description("Window FeedTouch ")]
        [Property("SPEC", "Tizen.NUI.Window.FeedTouch  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowFeedTouch()
        {
            tlog.Debug(tag, $"WindowFeedTouch  START");

            try
            {
                TouchPoint touchPoint = new TouchPoint(1, TouchPoint.StateType.Started, 500.0f, 600.0f);
                win.FeedTouch (touchPoint, 30);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowFeedTouch END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window FeedWheel ")]
        [Property("SPEC", "Tizen.NUI.Window.FeedWheel  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowFeedWheel()
        {
            tlog.Debug(tag, $"WindowFeedWheel  START");

            try
            {
                Wheel  wheelEvent = new Wheel();
                win.FeedWheel(wheelEvent);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowFeedWheel  END (OK)");
        }		

		[Test]
        [Category("P1")]
        [Description("Window SetParent ")]
        [Property("SPEC", "Tizen.NUI.Window.SetParent  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowSetParent()
        {
            tlog.Debug(tag, $"WindowSetParent  START");

            try
            {
                win.SetParent(Window.Instance, false);
                Assert.AreEqual(Window.Instance, win.GetParent(), "Should be equal!");

                win.Unparent();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowSetParent  END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("Window GetLayerCount ")]
        [Property("SPEC", "Tizen.NUI.Window.GetLayerCount  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetLayerCount()
        {
            tlog.Debug(tag, $"WindowGetLayerCount  START");

            try
            {
                var result = win.GetLayerCount();
                Assert.AreEqual(0, result, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetLayerCount  END (OK)");
        }		
		
		[Test]
        [Category("P1")]
        [Description("Window BackgroundColor ")]
        [Property("SPEC", "Tizen.NUI.Window.BackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void WindowBackgroundColor()
        {
            tlog.Debug(tag, $"WindowBackgroundColor  START");

            try
            {
                win.BackgroundColor = new Vector4(1.0f, 0.3f, 0.8f, 0.0f);
                Assert.AreEqual(1.0f, win.BackgroundColor.R, "Should be equal!");
                Assert.AreEqual(0.3f, win.BackgroundColor.G, "Should be equal!");
                Assert.AreEqual(0.8f, win.BackgroundColor.B, "Should be equal!");
                Assert.AreEqual(0.0f, win.BackgroundColor.A, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowBackgroundColor  END (OK)");
        }	

		[Test]
        [Category("P1")]
        [Description("Window GetDpi ")]
        [Property("SPEC", "Tizen.NUI.Window.GetDpi  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetDpi()
        {
            tlog.Debug(tag, $"WindowGetDpi  START");

            try
            {
                Window.Instance.GetDpi();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetDpi  END (OK)");
        }	

		[Test]
        [Category("P1")]
        [Description("Window GetRenderingBehavior ")]
        [Property("SPEC", "Tizen.NUI.Window.GetRenderingBehavior  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowGetRenderingBehavior()
        {
            tlog.Debug(tag, $"WindowGetRenderingBehavior  START");

            try
            {
                Window.Instance.GetRenderingBehavior();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowGetRenderingBehavior  END (OK)");
        }		

		[Test]
        [Category("P1")]
        [Description("Window IncludeInputRegion")]
        [Property("SPEC", "Tizen.NUI.Window.IncludeInputRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowIncludeInputRegion()
        {
            tlog.Debug(tag, $"WindowIncludeInputRegion START");

            try
            {
                Window.Instance.IncludeInputRegion(rec);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            tlog.Debug(tag, $"WindowIncludeInputRegion END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("Window ExcludeInputRegion")]
        [Property("SPEC", "Tizen.NUI.Window.ExcludeInputRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowExcludeInputRegion()
        {
            tlog.Debug(tag, $"WindowExcludeInputRegion START");

            try
            {
                Window.Instance.ExcludeInputRegion(rec);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            tlog.Debug(tag, $"WindowExcludeInputRegion END (OK)");
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

        [Test]
        [Category("P1")]
        [Description("Window SetFullScreen")]
        [Property("SPEC", "Tizen.NUI.Window.SetFullScreen M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void SetFullScreen()
        {
            tlog.Debug(tag, $"SetFullScreen START");

            try
            {
                win.SetFullScreen(true);
                Assert.IsTrue(win.GetFullScreen());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"SetFullScreen END (OK)");
        }
    }
}
