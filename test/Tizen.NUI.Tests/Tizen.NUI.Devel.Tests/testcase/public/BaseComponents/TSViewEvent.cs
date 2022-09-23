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
    [Description("public/BaseComponents/ViewEvent")]
    public class PublicViewEventTest
    {
        private const string tag = "NUITEST";

        private bool OnKeyEvent(object source, View.KeyEventArgs e)
        {
            return true;
        }

        private bool OnInterceptTouchEvent(object source, View.TouchEventArgs e)
        {
            return true;
        }

        private bool OnWheelEvent(object source, View.WheelEventArgs e)
        {
            return true;
        }

        private bool OnHoverEvent(object source, View.HoverEventArgs e)
        {
            return true;
        }

        private bool OnTouchEvent(object source, View.TouchEventArgs e)
        {
            return true;
        }

        private void OnBackgroundResourceLoaded(object sender, View.BackgroundResourceLoadedEventArgs e) { }

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
        [Description("ViewEvent KeyEvent.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.KeyEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventKeyEvent()
        {
            tlog.Debug(tag, $"ViewEventKeyEvent START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.KeyEvent += OnKeyEvent;
            testingTarget.KeyEvent -= OnKeyEvent;

            testingTarget.InterceptTouchEvent += OnInterceptTouchEvent;
            testingTarget.InterceptTouchEvent -= OnInterceptTouchEvent;

            testingTarget.TouchEvent += OnTouchEvent;
            testingTarget.TouchEvent -= OnTouchEvent;

            testingTarget.HoverEvent += OnHoverEvent;
            testingTarget.HoverEvent -= OnHoverEvent;

            testingTarget.WheelEvent += OnWheelEvent;
            testingTarget.WheelEvent -= OnWheelEvent;

            testingTarget.BackgroundResourceLoaded += OnBackgroundResourceLoaded;
            testingTarget.BackgroundResourceLoaded -= OnBackgroundResourceLoaded;

            tlog.Debug(tag, $"ViewEventKeyEvent END (OK)");
        }
		
        [Test]
        [Category("P1")]
        [Description("ViewEvent InterceptTouchSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.InterceptTouchSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventInterceptTouchSignal()
        {
            tlog.Debug(tag, $"ViewEventInterceptTouchSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.InterceptTouchSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventInterceptTouchSignal END (OK)");
        }		
		
        [Test]
        [Category("P1")]
        [Description("ViewEvent TouchSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.TouchSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventTouchSignal()
        {
            tlog.Debug(tag, $"ViewEventTouchSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.TouchSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventTouchSignal END (OK)");
        }		
		
        [Test]
        [Category("P1")]
        [Description("ViewEvent HoveredSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.HoveredSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventHoveredSignal()
        {
            tlog.Debug(tag, $"ViewEventHoveredSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.HoveredSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventHoveredSignal END (OK)");
        }			
		
        [Test]
        [Category("P1")]
        [Description("ViewEvent WheelEventSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.WheelEventSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventWheelEventSignal()
        {
            tlog.Debug(tag, $"ViewEventWheelEventSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.WheelEventSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventWheelEventSignal END (OK)");
        }		

        [Test]
        [Category("P1")]
        [Description("ViewEvent OffWindowSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.OffWindowSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventOffWindowSignal()
        {
            tlog.Debug(tag, $"ViewEventOffWindowSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.OffWindowSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventOffWindowSignal END (OK)");
        }			

        [Test]
        [Category("P1")]
        [Description("ViewEvent OnRelayoutSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.OnRelayoutSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventOnRelayoutSignal()
        {
            tlog.Debug(tag, $"ViewEventOnRelayoutSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.OnRelayoutSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventOnRelayoutSignal END (OK)");
        }	

        [Test]
        [Category("P1")]
        [Description("ViewEvent ResourcesLoadedSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.ResourcesLoadedSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventResourcesLoadedSignal()
        {
            tlog.Debug(tag, $"ViewEventResourcesLoadedSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.ResourcesLoadedSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventResourcesLoadedSignal END (OK)");
        }
	
        [Test]
        [Category("P1")]
        [Description("ViewEvent KeyEventSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.KeyEventSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventKeyEventSignal()
        {
            tlog.Debug(tag, $"ViewEventKeyEventSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.KeyEventSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventKeyEventSignal END (OK)");
        }	
	
	
        [Test]
        [Category("P1")]
        [Description("ViewEvent KeyInputFocusGainedSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.KeyInputFocusGainedSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventKeyInputFocusGainedSignal()
        {
            tlog.Debug(tag, $"ViewEventKeyInputFocusGainedSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.KeyInputFocusGainedSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventKeyInputFocusGainedSignal END (OK)");
        }	

        [Test]
        [Category("P1")]
        [Description("ViewEvent KeyInputFocusLostSignal.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.KeyInputFocusLostSignal A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventKeyKeyInputFocusLostSignal()
        {
            tlog.Debug(tag, $"ViewEventKeyKeyInputFocusLostSignal START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            
            try
			{
                testingTarget.KeyInputFocusLostSignal();
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ViewEventKeyKeyInputFocusLostSignal END (OK)");
        }
    }
}
