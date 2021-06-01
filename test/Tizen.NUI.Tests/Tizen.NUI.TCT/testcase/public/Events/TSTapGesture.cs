using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/TapGesture")]
    class PublicTapGestureTest
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
        [Description("TapGesture constructor")]
        [Property("SPEC", "Tizen.NUI.TapGesture.TapGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureConstructor()
        {
            tlog.Debug(tag, $"TapGestureConstructor START");
            
            TapGesture a1 = new TapGesture();
            
            a1.Dispose();

            
            tlog.Debug(tag, $"TapGestureConstructor END (OK)");
            Assert.Pass("TapGestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfTaps property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTaps A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureNumberOfTaps()
        {
            tlog.Debug(tag, $"TapGestureNumberOfTaps START");
            TapGesture a1 = new TapGesture();

            uint b1 = a1.NumberOfTaps;
            
            tlog.Debug(tag, $"TapGestureNumberOfTaps END (OK)");
            Assert.Pass("TapGestureNumberOfTaps");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfTouches property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureNumberOfTouches()
        {
            tlog.Debug(tag, $"TapGestureNumberOfTouches START");
            TapGesture a1 = new TapGesture();

            uint b1 = a1.NumberOfTouches;
            
            tlog.Debug(tag, $"TapGestureNumberOfTouches END (OK)");
            Assert.Pass("TapGestureNumberOfTouches");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenPoint property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.ScreenPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureScreenPoint()
        {
            tlog.Debug(tag, $"TapGestureScreenPoint START");
            TapGesture a1 = new TapGesture();

            Vector2 v1 = a1.ScreenPoint;
            
            tlog.Debug(tag, $"TapGestureScreenPoint END (OK)");
            Assert.Pass("TapGestureScreenPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalPoint property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.LocalPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureLocalPoint()
        {
            tlog.Debug(tag, $"TapGestureLocalPoint START");
            TapGesture a1 = new TapGesture();

            Vector2 v1 = a1.LocalPoint;
            
            tlog.Debug(tag, $"TapGestureLocalPoint END (OK)");
            Assert.Pass("TapGestureLocalPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test getCPtr property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.getCPtr A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGesturegetCPtr()
        {
            tlog.Debug(tag, $"TapGesturegetCPtr START");
            TapGesture a1 = new TapGesture();

            global::System.Runtime.InteropServices.HandleRef p1 = TapGesture.getCPtr(a1);
            
            tlog.Debug(tag, $"TapGesturegetCPtr END (OK)");
            Assert.Pass("TapGesturegetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetTapGestureFromPtr property.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.GetTapGestureFromPtr A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureGetTapGestureFromPtr()
        {
            tlog.Debug(tag, $"TapGestureGetTapGestureFromPtr START");
            TapGesture a1 = new TapGesture();
			
            TapGesture a2 = TapGesture.GetTapGestureFromPtr(TapGesture.getCPtr(a1).Handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"TapGestureGetTapGestureFromPtr END (OK)");
            Assert.Pass("TapGestureGetTapGestureFromPtr");
        }
    }

}