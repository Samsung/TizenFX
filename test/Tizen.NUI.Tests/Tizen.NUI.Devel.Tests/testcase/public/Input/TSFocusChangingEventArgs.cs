using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/FocusChangingEventArgs")]
    internal class PublicFocusChangingEventArgsTest
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
        [Description("Create a FocusChangingEventArgs object.")]
        [Property("SPEC", "Tizen.NUI.FocusChangingEventArgs.FocusChangingEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangingEventArgsConstructor()
        {
            tlog.Debug(tag, $"FocusChangingEventArgsConstructor START");
            
            var testingTarget = new FocusChangingEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusChangingEventArgs>(testingTarget, "Should be an instance of FocusChangingEventArgs type.");

            tlog.Debug(tag, $"FocusChangingEventArgsConstructor END (OK)");
        }		
		
	    [Test]
        [Category("P1")]
        [Description("FocusChangingEventArgs Current")]
        [Property("SPEC", "Tizen.NUI.Input.FocusChangingEventArgs Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void InputFocusChangingEventArgsCurrent()
        {
            tlog.Debug(tag, $"InputFocusChangingEventArgsCurrent START");

            var testingTarget = new FocusChangingEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusChangingEventArgs>(testingTarget, "Should be an instance of FocusChangingEventArgs type.");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                testingTarget.Current = view;

                var result = testingTarget.Current;
                Assert.AreEqual(100, result.Size.Width, "Should be equal!");
                Assert.AreEqual(200, result.Size.Height, "Should be equal!");
            }
            
            tlog.Debug(tag, $"InputFocusChangingEventArgsCurrent END (OK)");
        }
		
	    [Test]
        [Category("P1")]
        [Description("FocusChangingEventArgs Proposed")]
        [Property("SPEC", "Tizen.NUI.Input.FocusChangingEventArgs Proposed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void InputFocusChangingEventArgsProposed()
        {
            tlog.Debug(tag, $"InputFocusChangingEventArgsProposed START");

            var testingTarget = new FocusChangingEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusChangingEventArgs>(testingTarget, "Should be an instance of FocusChangingEventArgs type.");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                testingTarget.Proposed = view;

                var result = testingTarget.Proposed;
                Assert.AreEqual(100, result.Size.Width, "Should be equal!");
                Assert.AreEqual(200, result.Size.Height, "Should be equal!");
            }

            tlog.Debug(tag, $"InputFocusChangingEventArgsProposed END (OK)");
        }		
		
	    [Test]
        [Category("P1")]
        [Description("FocusChangingEventArgs Direction")]
        [Property("SPEC", "Tizen.NUI.Input.FocusChangingEventArgs Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void InputFocusChangingEventArgsDirection()
        {
            tlog.Debug(tag, $"InputFocusChangingEventArgsDirection START");

            var testingTarget = new FocusChangingEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusChangingEventArgs>(testingTarget, "Should be an instance of FocusChangingEventArgs type.");

            testingTarget.Direction = View.FocusDirection.Down;
            tlog.Debug(tag, "Direction : " + testingTarget.Direction);

            tlog.Debug(tag, $"InputFocusChangingEventArgsDirection END (OK)");
        }		
	}
}