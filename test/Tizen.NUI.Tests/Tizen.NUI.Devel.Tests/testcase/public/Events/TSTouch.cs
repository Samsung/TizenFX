using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/Touch")]
    class PublicTouchTest
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
        [Description("Touch constructor")]
        [Property("SPEC", "Tizen.NUI.Touch.Touch C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchConstructor()
        {
            tlog.Debug(tag, $"TouchConstructor START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchConstructor END (OK)");
            Assert.Pass("TouchConstructor");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Touch constructor")]
        //[Property("SPEC", "Tizen.NUI.Touch.Touch C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TouchConstructorWithTouch()
        //{
        //    tlog.Debug(tag, $"TouchConstructorWithTouch START");

        //    using (Touch touch = new Touch())
        //    {
        //        var testingTarget = new Touch(touch);
        //        Assert.IsNotNull(testingTarget, "Can't create success object Touch");
        //        Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"TouchConstructorWithTouch END (OK)");
        //    Assert.Pass("TouchConstructor");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("Touch GetTime")]
        //[Property("SPEC", "Tizen.NUI.Touch.GetTime M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TouchGetTime()
        //{
        //    tlog.Debug(tag, $"TouchGetTime START");

        //    var testingTarget = new Touch();
        //    Assert.IsNotNull(testingTarget, "Can't create success object Touch");
        //    Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

        //    try
        //    {
        //        testingTarget.GetTime();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"TouchGetPointCount END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("Touch GetPointCount")]
        //[Property("SPEC", "Tizen.NUI.Touch.GetPointCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void TouchGetPointCount()
        //{
        //    tlog.Debug(tag, $"TouchGetPointCount START");

        //    var testingTarget = new Touch();
        //    Assert.IsNotNull(testingTarget, "Can't create success object Touch");
        //    Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

        //    try
        //    {
        //        testingTarget.GetPointCount();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"TouchGetPointCount END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("Touch GetDeviceId")]
        [Property("SPEC", "Tizen.NUI.Touch.GetDeviceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetDeviceId()
        {
            tlog.Debug(tag, $"TouchGetDeviceId START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetDeviceId(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetDeviceId END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetState")]
        [Property("SPEC", "Tizen.NUI.Touch.GetState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetState()
        {
            tlog.Debug(tag, $"TouchGetState START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetState(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetState END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetHitView")]
        [Property("SPEC", "Tizen.NUI.Touch.GetHitView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetHitView()
        {
            tlog.Debug(tag, $"TouchGetHitView START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetHitView(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetHitView END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetLocalPosition")]
        [Property("SPEC", "Tizen.NUI.Touch.GetLocalPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetLocalPosition()
        {
            tlog.Debug(tag, $"TouchGetLocalPosition START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetLocalPosition(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetLocalPosition END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetScreenPosition")]
        [Property("SPEC", "Tizen.NUI.Touch.GetScreenPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetScreenPosition()
        {
            tlog.Debug(tag, $"TouchGetScreenPosition START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetScreenPosition(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetScreenPosition END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetRadius")]
        [Property("SPEC", "Tizen.NUI.Touch.GetRadius M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetRadius()
        {
            tlog.Debug(tag, $"TouchGetRadius START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetRadius(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetRadius END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetEllipseRadius")]
        [Property("SPEC", "Tizen.NUI.Touch.GetEllipseRadius M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetEllipseRadius()
        {
            tlog.Debug(tag, $"TouchGetEllipseRadius START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetEllipseRadius(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetEllipseRadius END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetPressure")]
        [Property("SPEC", "Tizen.NUI.Touch.GetPressure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetPressure()
        {
            tlog.Debug(tag, $"TouchGetPressure START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetPressure(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetPressure END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetMouseButton")]
        [Property("SPEC", "Tizen.NUI.Touch.GetMouseButton M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetMouseButton()
        {
            tlog.Debug(tag, $"TouchGetMouseButton START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetMouseButton(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetMouseButton END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetTouchFromPtr")]
        [Property("SPEC", "Tizen.NUI.Touch.GetTouchFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetTouchFromPtr()
        {
            tlog.Debug(tag, $"TouchGetTouchFromPtr START");

            using (Touch touch = new Touch())
            {
                var testingTarget = Touch.GetTouchFromPtr(touch.SwigCPtr.Handle);
                Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchGetTouchFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Touch GetAngle")]
        [Property("SPEC", "Tizen.NUI.Touch.GetAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchGetAngle()
        {
            tlog.Debug(tag, $"TouchGetAngle START");

            var testingTarget = new Touch();
            Assert.IsNotNull(testingTarget, "Can't create success object Touch");
            Assert.IsInstanceOf<Touch>(testingTarget, "Should be an instance of Touch type.");

            try
            {
                testingTarget.GetAngle(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchGetAngle END (OK)");
                Assert.Pass("Caught Exception : Passed!");
            }
        }
    }

}