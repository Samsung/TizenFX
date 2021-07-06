using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Any")]
    public class InternalAnyTest
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
        [Description("Any constructor.")]
        [Property("SPEC", "Tizen.NUI.Any.Any C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyConstructor()
        {
            tlog.Debug(tag, $"AnyConstructor START");

            var testingTarget = new Any();
            Assert.IsNotNull(testingTarget, "Can't create success object Any");
            Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any constructor. With Any.")]
        [Property("SPEC", "Tizen.NUI.Any.Any C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyConstructorWithAny()
        {
            tlog.Debug(tag, $"AnyConstructorWithAny START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyConstructorWithAny END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any Assign.")]
        [Property("SPEC", "Tizen.NUI.Any.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyAssign()
        {
            tlog.Debug(tag, $"AnyAssign START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
                    any.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyAssign END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Any AssertAlways.")]
        //[Property("SPEC", "Tizen.NUI.Any.AssertAlways M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AnyAssertAlways()
        //{
        //    tlog.Debug(tag, $"AnyAssertAlways START");

        //    try
        //    {
        //        Any.AssertAlways("This is the test for Any class.");
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }
           
        //    tlog.Debug(tag, $"AnyAssertAlways END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("Any GetType.")]
        [Property("SPEC", "Tizen.NUI.Any.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyGetType()
        {
            tlog.Debug(tag, $"AnyGetType START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
                    testingTarget.GetType();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any Empty.")]
        [Property("SPEC", "Tizen.NUI.Any.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyEmpty()
        {
            tlog.Debug(tag, $"AnyEmpty START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
                    var result = testingTarget.Empty();
                    tlog.Debug(tag, "result :" + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase constructor.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.AnyContainerBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBaseConstructor()
        {
            tlog.Debug(tag, $"AnyContainerBaseConstructor START");

            SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
            SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
            SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);

            var testingTarget = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);
            Assert.IsNotNull(testingTarget, "Can't create success object AnyContainerBase");
            Assert.IsInstanceOf<Any.AnyContainerBase>(testingTarget, "Should be an instance of AnyContainerBase type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyContainerBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase GetType.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBaseGetType()
        {
            tlog.Debug(tag, $"AnyContainerBaseGetType START");

            SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
            SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
            SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);

            var testingTarget = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);
            Assert.IsNotNull(testingTarget, "Can't create success object AnyContainerBase");
            Assert.IsInstanceOf<Any.AnyContainerBase>(testingTarget, "Should be an instance of AnyContainerBase type.");

            try
            {
                testingTarget.GetType();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyContainerBaseGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase mType.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.mType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBasemType()
        {
            tlog.Debug(tag, $"AnyContainerBasemType START");

            SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
            SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
            SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);

            var testingTarget = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);
            Assert.IsNotNull(testingTarget, "Can't create success object AnyContainerBase");
            Assert.IsInstanceOf<Any.AnyContainerBase>(testingTarget, "Should be an instance of AnyContainerBase type.");

            tlog.Debug(tag, "mType : " + testingTarget.mType);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyContainerBasemType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase mCloneFunc.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.mCloneFunc A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBasemCloneFunc()
        {
            tlog.Debug(tag, $"AnyContainerBasemCloneFunc START");

            SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
            SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
            SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);

            var testingTarget = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);
            Assert.IsNotNull(testingTarget, "Can't create success object AnyContainerBase");
            Assert.IsInstanceOf<Any.AnyContainerBase>(testingTarget, "Should be an instance of AnyContainerBase type.");

            tlog.Debug(tag, "mType : " + testingTarget.mCloneFunc);

            testingTarget.mCloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new TextLabel().SwigCPtr.Handle);
            tlog.Debug(tag, "mType : " + testingTarget.mCloneFunc);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyContainerBasemCloneFunc END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase mDeleteFunc.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.mDeleteFunc A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBasemDeleteFunc()
        {
            tlog.Debug(tag, $"AnyContainerBasemDeleteFunc START");

            SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
            SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
            SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);

            var testingTarget = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);
            Assert.IsNotNull(testingTarget, "Can't create success object AnyContainerBase");
            Assert.IsInstanceOf<Any.AnyContainerBase>(testingTarget, "Should be an instance of AnyContainerBase type.");

            tlog.Debug(tag, "mType : " + testingTarget.mDeleteFunc);

            testingTarget.mDeleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new ImageView().SwigCPtr.Handle);
            tlog.Debug(tag, "mType : " + testingTarget.mDeleteFunc);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyContainerBasemDeleteFunc END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any.AnyContainerBase mContainer.")]
        [Property("SPEC", "Tizen.NUI.Any.AnyContainerBase.mContainer A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyContainerBasemContainer()
        {
            tlog.Debug(tag, $"AnyContainerBasemContainer START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                tlog.Debug(tag, "mContainer : " + testingTarget.mContainer);

                SWIGTYPE_p_std__type_info type = new SWIGTYPE_p_std__type_info(new View().SwigCPtr.Handle);
                SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc = new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(new ImageView().SwigCPtr.Handle);
                SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc = new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(new TextLabel().SwigCPtr.Handle);
                Any.AnyContainerBase container = new Any.AnyContainerBase(type, cloneFunc, deleteFunc);

                try
                {
                    testingTarget.mContainer = container;
                    tlog.Debug(tag, "mContainer : " + testingTarget.mContainer);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AnyContainerBasemContainer END (OK)");
        }
    }
}
