using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/Wheel")]
    class PublicWheelTest
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
        [Description("Wheel constructor")]
        [Property("SPEC", "Tizen.NUI.Wheel.Wheel C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelConstructor()
        {
            tlog.Debug(tag, $"WheelConstructor START");
			            
            Wheel a1 = new Wheel();
            Wheel.WheelType type = Wheel.WheelType.MouseWheel;
            Vector2 v = new Vector2(0.0f, 0.0f);
            Wheel a2 = new Wheel(type, 0, 0, v, 0, 123);
            
            a2.Dispose();
            a1.Dispose();
            
            tlog.Debug(tag, $"WheelConstructor END (OK)");
            Assert.Pass("WheelConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test Type property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelType()
        {
            tlog.Debug(tag, $"WheelType START");
            Wheel a1 = new Wheel();

            Wheel.WheelType b1 = a1.Type;
            
            tlog.Debug(tag, $"WheelType END (OK)");
            Assert.Pass("WheelType");
        }

        [Test]
        [Category("P1")]
        [Description("Test Direction property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelDirection()
        {
            tlog.Debug(tag, $"WheelDirection START");
            Wheel a1 = new Wheel();

            int b1 = a1.Direction;
            
            tlog.Debug(tag, $"WheelDirection END (OK)");
            Assert.Pass("WheelDirection");
        }

        [Test]
        [Category("P1")]
        [Description("Test Modifiers property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Modifiers A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelModifiers()
        {
            tlog.Debug(tag, $"WheelModifiers START");
            Wheel a1 = new Wheel();

            uint b1 = a1.Modifiers;
            
            tlog.Debug(tag, $"WheelModifiers END (OK)");
            Assert.Pass("WheelModifiers");
        }

        [Test]
        [Category("P1")]
        [Description("Test Point property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Point A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelPoint()
        {
            tlog.Debug(tag, $"WheelPoint START");
            Wheel a1 = new Wheel();

            Vector2 v1 = a1.Point;
            
            tlog.Debug(tag, $"WheelPoint END (OK)");
            Assert.Pass("WheelPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test Z property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelZ()
        {
            tlog.Debug(tag, $"WheelZ START");
            Wheel a1 = new Wheel();

            int b1 = a1.Z;
            
            tlog.Debug(tag, $"WheelZ END (OK)");
            Assert.Pass("WheelZ");
        }

        [Test]
        [Category("P1")]
        [Description("Test TimeStamp property.")]
        [Property("SPEC", "Tizen.NUI.Wheel.TimeStamp A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelTimeStamp()
        {
            tlog.Debug(tag, $"WheelTimeStamp START");
            Wheel a1 = new Wheel();

            uint b1 = a1.TimeStamp;
            
            tlog.Debug(tag, $"WheelTimeStamp END (OK)");
            Assert.Pass("WheelTimeStamp");
        }

        [Test]
        [Category("P1")]
        [Description("Wheel IsShiftModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsShiftModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelIsShiftModifier()
        {
            tlog.Debug(tag, $"WheelIsShiftModifier START");
            Wheel a1 = new Wheel();
            bool b1 = a1.IsShiftModifier();
            
            tlog.Debug(tag, $"WheelIsShiftModifier END (OK)");
            Assert.Pass("WheelIsShiftModifier");
        }

        [Test]
        [Category("P1")]
        [Description("Wheel IsCtrlModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsCtrlModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelIsCtrlModifier()
        {
            tlog.Debug(tag, $"WheelIsCtrlModifier START");
            Wheel a1 = new Wheel();
            bool b1 = a1.IsCtrlModifier();
            
            tlog.Debug(tag, $"WheelIsCtrlModifier END (OK)");
            Assert.Pass("WheelIsCtrlModifier");
        }

        [Test]
        [Category("P1")]
        [Description("Wheel IsAltModifier")]
        [Property("SPEC", "Tizen.NUI.Wheel.IsAltModifier M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelIsAltModifier()
        {
            tlog.Debug(tag, $"WheelIsAltModifier START");
            Wheel a1 = new Wheel();
            bool b1 = a1.IsAltModifier();
            
            tlog.Debug(tag, $"WheelIsAltModifier END (OK)");
            Assert.Pass("WheelIsAltModifier");
        }

        [Test]
        [Category("P1")]
        [Description("Wheel getCPtr")]
        [Property("SPEC", "Tizen.NUI.Wheel.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelgetCPtr()
        {
            tlog.Debug(tag, $"WheelgetCPtr START");
            Wheel a1 = new Wheel();
            global::System.Runtime.InteropServices.HandleRef b1 = Wheel.getCPtr(a1);
            
            tlog.Debug(tag, $"WheelgetCPtr END (OK)");
            Assert.Pass("WheelgetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Wheel GetWheelFromPtr")]
        [Property("SPEC", "Tizen.NUI.Wheel.GetWheelFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelGetWheelFromPtr()
        {
            tlog.Debug(tag, $"WheelGetWheelFromPtr START");
            Wheel a1 = new Wheel();

            Wheel a2 = Wheel.GetWheelFromPtr(Wheel.getCPtr(a1).Handle);

            a1.Dispose();
            
            tlog.Debug(tag, $"WheelGetWheelFromPtr END (OK)");
            Assert.Pass("WheelGetWheelFromPtr");
        }
    }

}