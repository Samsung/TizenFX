using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/LongPressGestureDetector")]
    internal class PublicLongPressGestureDetectorTest
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
        [Description("Create a LongPressGestureDetector object.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.LongPressGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorConstructor()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorConstructor START");

            var testingTarget = new LongPressGestureDetector();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureDetectorConstructor END (OK)");
            Assert.Pass("LongPressGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LongPressGestureDetector object.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.LongPressGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorConstructorWithTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithTouchesRequired START");

            var testingTarget = new LongPressGestureDetector(7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithTouchesRequired END (OK)");
            Assert.Pass("LongPressGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LongPressGestureDetector object.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.LongPressGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorConstructorWithTouchesArea()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithTouchesArea START");

            var testingTarget = new LongPressGestureDetector(3, 7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithTouchesArea END (OK)");
            Assert.Pass("LongPressGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a LongPressGestureDetector object.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.LongPressGestureDetector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorConstructorWithLongPressGestureDetector()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithLongPressGestureDetector START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector(3, 7))
            {
                var testingTarget = new LongPressGestureDetector(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorConstructorWithLongPressGestureDetector END (OK)");
            Assert.Pass("LongPressGestureDetectorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector SetTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.SetTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorSetTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequired START");

            var testingTarget = new LongPressGestureDetector(7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            try
            {
                testingTarget.SetTouchesRequired(3);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
			
            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequired END (OK)");
            Assert.Pass("SetTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector SetTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.SetTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorSetTouchesRequiredWithTouchesArea()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequiredWithTouchesArea START");

            var testingTarget = new LongPressGestureDetector(7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            try
            {
                testingTarget.SetTouchesRequired(2, 8);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"LongPressGestureDetectorSetTouchesRequiredWithTouchesArea END (OK)");
            Assert.Pass("SetTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetMinimumTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetMinimumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetMinimumTouchesRequired()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorGetMinimumTouchesRequired START");

            var testingTarget = new LongPressGestureDetector(7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            tlog.Debug(tag, "MinimumTouchesRequired : " + testingTarget.GetMinimumTouchesRequired());

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureDetectorGetMinimumTouchesRequired END (OK)");
            Assert.Pass("GetMinimumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetMaximumTouchesRequired")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetMaximumTouchesRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetMaximumTouchesRequired()
        {
            var testingTarget = new LongPressGestureDetector(7);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

            tlog.Debug(tag, "MaximumTouchesRequired : " + testingTarget.GetMaximumTouchesRequired());

            testingTarget.Dispose();

            tlog.Debug(tag, $"LongPressGestureDetectorGetMaximumTouchesRequired END (OK)");
            Assert.Pass("GetMaximumTouchesRequired");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector GetLongPressGestureDetectorFromPtr")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.GetLongPressGestureDetectorFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorGetLongPressGestureDetectorFromPtr()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorGetLongPressGestureDetectorFromPtr START");

            using (LongPressGestureDetector detector= new LongPressGestureDetector(3))
            { 
                var testingTarget = LongPressGestureDetector.GetLongPressGestureDetectorFromPtr(LongPressGestureDetector.getCPtr(detector).Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorGetLongPressGestureDetectorFromPtr END (OK)");
            Assert.Pass("GetLongPressGestureDetectorFromPtr");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector DownCast")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDownCast()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDownCast START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector())
            {
                var testingTarget = LongPressGestureDetector.DownCast(detector);
                Assert.IsNotNull(testingTarget, "Can't create success object LongPressGestureDetector");
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorDownCast END (OK)");
            Assert.Pass("LongPressGestureDetectorDownCast");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector DetectedSignal")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.DetectedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDetectedSignal()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDetectedSignal START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector())
            {
                var testingTarget = detector.DetectedSignal();
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an instance of LongPressGestureDetectedSignal type.");

                testingTarget.Dispose();
            }
             
            tlog.Debug(tag, $"LongPressGestureDetectorDetectedSignal END (OK)");
            Assert.Pass("LongPressGestureDetectorDetectedSignal");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector getCPtr")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorgetCPtr()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorgetCPtr START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector())
            {
                var testingTarget = LongPressGestureDetector.DownCast(detector);
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                try
                {
                    LongPressGestureDetector.getCPtr(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorgetCPtr END (OK)");
            Assert.Pass("LongPressGestureDetectorgetCPtr");
        }
		
        [Test]
        [Category("P1")]
        [Description("Test Detected property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.Detected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorDetected()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorDetected START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector())
            {
                var testingTarget = LongPressGestureDetector.DownCast(detector);
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                testingTarget.Detected += OnDetected;
                testingTarget.Detected -= OnDetected;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorDetected END (OK)");
            Assert.Pass("LongPressGestureDetectorDetected");
        }		
		
        private void OnDetected(object obj, LongPressGestureDetector.DetectedEventArgs e)
        { }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetector Assign")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetector.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectorAssign()
        {
            tlog.Debug(tag, $"LongPressGestureDetectorAssign START");

            using (LongPressGestureDetector detector = new LongPressGestureDetector())
            {
                var testingTarget = detector.Assign(detector);
                Assert.IsInstanceOf<LongPressGestureDetector>(testingTarget, "Should be an instance of LongPressGestureDetector type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectorAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DetectedEventArgs View.")]
        [Property("SPEC", "Tizen.NUI.DetectedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedEventArgsView()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedEventArgsView START");

            var testingTarget = new Tizen.NUI.LongPressGestureDetector.DetectedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object DetectedEventArgs.");
            Assert.IsInstanceOf<Tizen.NUI.LongPressGestureDetector.DetectedEventArgs>(testingTarget, "Should return DetectedEventArgs instance.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                Assert.AreEqual(100, testingTarget.View.Size.Width, "Should be equal!");
            }

            testingTarget.LongPressGesture = new LongPressGesture(Gesture.StateType.Possible);
            Assert.AreEqual(Gesture.StateType.Possible, testingTarget.LongPressGesture.State, "Should be equal!");

            tlog.Debug(tag, $"LongPressGestureDetectedEventArgsView END (OK)");
        }
    }
}
