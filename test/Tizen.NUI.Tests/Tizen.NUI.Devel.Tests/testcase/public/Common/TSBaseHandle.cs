using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/BaseHandle")]
    public class PublicBaseHandleTest
    {
        private const string tag = "NUITEST";
        private bool flag = false;

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

        private void baseHandleEventCallback(object sender, EventArgs e)
        {
            flag = true;
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle constructor.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BaseHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleConstructor()
        {
            tlog.Debug(tag, $"BaseHandleConstructor START");

            var testingTarget = new BaseHandle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            var swigCMemOwn = testingTarget.SwigCMemOwn;
            Assert.IsTrue(swigCMemOwn);

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle constructor. With BaseHandle")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.BaseHandle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "BaseHandle")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleConstructorWithBaseHandle()
        {
            tlog.Debug(tag, $"BaseHandleConstructorWithBaseHandle START");

            BaseHandle testingTarget = null;
            using (BaseHandle view = new View())
            {
                testingTarget = new BaseHandle(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleConstructorWithBaseHandle END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("BaseHandle EqualTo.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleEqualTo()
        {
            tlog.Debug(tag, $"BaseHandleEqualTo START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            View view = new View();
            view = testingTarget;
            Assert.IsTrue(testingTarget.EqualTo(view), "Should be true!");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleNotEqualTo()
        {
            tlog.Debug(tag, $"BaseHandleNotEqualTo START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            using (View view = new View())
            {
                Assert.IsTrue(testingTarget.NotEqualTo(view), "Should be true!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle IsEqual.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.IsEqual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleIsEqual()
        {
            tlog.Debug(tag, $"BaseHandleIsEqual START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            View view = new View();
            view = testingTarget;
            Assert.IsTrue(testingTarget.IsEqual(view), "Should be true!");

            testingTarget.Dispose();
            Assert.IsFalse(testingTarget.IsEqual(view), "Should be true!");

            view.Dispose();           
            tlog.Debug(tag, $"BaseHandleIsEqual END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle GetTypeName.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetTypeName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleGetTypeName()
        {
            tlog.Debug(tag, $"BaseHandleGetTypeName START");

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            Assert.AreEqual("TextLabel", testingTarget.GetTypeName(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleGetTypeName END (OK)");
        }
        [Test]
        [Category("P2")]
        [Description("BaseHandle. Logical Not !.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.! M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleLogicalNotWithNullObject()
        {
            tlog.Debug(tag, $"BaseHandleLogicalNotWithNullObject START");

            View testingTarget = null;
            Assert.IsTrue(!testingTarget, "view should be true!");

            tlog.Debug(tag, $"BaseHandleLogicalNotWithNullObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle bool.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.bool M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleBool()
        {
            tlog.Debug(tag, $"BaseHandleBool START");

            View testingTarget = null;
            Assert.IsFalse((bool)testingTarget);

            testingTarget = new View();
            Assert.IsTrue((bool)testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleBool END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("BaseHandle Dispose.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleDispose()
        {
            tlog.Debug(tag, $"BaseHandleDispose START");

            var testingTarget = new BaseHandle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            try
            {

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BaseHandleDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle GetTypeInfo.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetTypeInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleGetTypeInfo()
        {
            tlog.Debug(tag, $"BaseHandleGetTypeInfo START");

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            TypeInfo typeInfo = TypeRegistry.Get().GetTypeInfo("TextLabel");

            try
            {
                Assert.True(testingTarget.GetTypeInfo(typeInfo), "Should be true");
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            typeInfo.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleGetTypeInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle Equals.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleEquals()
        {
            tlog.Debug(tag, $"BaseHandleEquals START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");
            
            try
            {
                using (View view = testingTarget as View)
                {
                    Assert.True(testingTarget.Equals(view), "Should be true");
                }

                using (View view = new View())
                {
                    Assert.False(testingTarget.Equals(view), "Should be false");
                }
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseHandle GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.BaseHandle.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseHandleGetHashCode()
        {
            tlog.Debug(tag, $"BaseHandleGetHashCode START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseHandle>(testingTarget, "Should return BaseHandle instance.");

            try
            {
                Assert.GreaterOrEqual(testingTarget.GetHashCode(), 0, "Should be true");
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseHandleGetHashCode END (OK)");
        }
    }
}
