using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/InputMethodOptions")]
    public class InternalInputMethodOptionsTest
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
        [Description("InputMethodOptions constructor")]
        [Property("SPEC", "Tizen.NUI.InputMethodOptions.InputMethodOptions C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodOptionsConstructor()
        {
            tlog.Debug(tag, $"InputMethodOptionsConstructor START");

            var testingTarget = new InputMethodOptions();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<InputMethodOptions>(testingTarget, "should be an instance of InputMethodOptions class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"InputMethodOptionsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodOptions IsPassword")]
        [Property("SPEC", "Tizen.NUI.InputMethodOptions.IsPassword M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodOptionsIsPassword()
        {
            tlog.Debug(tag, $"InputMethodOptionsIsPassword START");

            var testingTarget = new InputMethodOptions();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<InputMethodOptions>(testingTarget, "should be an instance of InputMethodOptions class!");

            tlog.Debug(tag, testingTarget.IsPassword().ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"InputMethodOptionsIsPassword END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodOptions ApplyProperty")]
        [Property("SPEC", "Tizen.NUI.InputMethodOptions.ApplyProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodOptionsApplyProperty()
        {
            tlog.Debug(tag, $"InputMethodOptionsApplyProperty START");

            var testingTarget = new InputMethodOptions();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<InputMethodOptions>(testingTarget, "should be an instance of InputMethodOptions class!");

            using (PropertyMap settings = new PropertyMap())
            {
                settings.Add("IsTextPredictionAllowed", new PropertyValue(false));

                try
                {
                    testingTarget.ApplyProperty(settings);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"InputMethodOptionsApplyProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("InputMethodOptions RetrieveProperty")]
        [Property("SPEC", "Tizen.NUI.InputMethodOptions.RetrieveProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void InputMethodOptionsRetrieveProperty()
        {
            tlog.Debug(tag, $"InputMethodOptionsRetrieveProperty START");

            var testingTarget = new InputMethodOptions();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<InputMethodOptions>(testingTarget, "should be an instance of InputMethodOptions class!");

            using (PropertyMap settings = new PropertyMap())
            {
                settings.Add("IsTextPredictionAllowed", new PropertyValue(false));

                try
                {
                    testingTarget.RetrieveProperty(settings);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"InputMethodOptionsRetrieveProperty END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("InputMethodOptions CompareAndSet")]
        //[Property("SPEC", "Tizen.NUI.InputMethodOptions.CompareAndSet M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void InputMethodOptionsCompareAndSet()
        //{
        //    tlog.Debug(tag, $"InputMethodOptionsCompareAndSet START");

        //    var testingTarget = new InputMethodOptions();
        //    Assert.IsNotNull(testingTarget, "should be not null");
        //    Assert.IsInstanceOf<InputMethodOptions>(testingTarget, "should be an instance of InputMethodOptions class!");

        //    var result = testingTarget.CompareAndSet(InputMethod.CategoryType.ActionButtonTitle, testingTarget, new SWIGTYPE_p_int(testingTarget.SwigCPtr.Handle));
        //    tlog.Debug(tag, result.ToString());

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"InputMethodOptionsCompareAndSet END (OK)");
        //}
    }
}
