using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VectorBase")]
    public class InternalVectorBaseTest
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
        [Description("VectorBase constructor.")]
        [Property("SPEC", "Tizen.NUI.VectorBase.VectorBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBaseConstructor()
        {
            tlog.Debug(tag, $"VectorBaseConstructor START");

            using (View view = new View())
            {
                var testingTarget = new VectorBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VectorBase>(testingTarget, "Should be an Instance of VectorBase!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBase Capacity.")]
        [Property("SPEC", "Tizen.NUI.VectorBase.Capacity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBaseCapacity()
        {
            tlog.Debug(tag, $"VectorBaseCapacity START");

            using (View view = new View())
            {
                var testingTarget = new VectorBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VectorBase>(testingTarget, "Should be an Instance of VectorBase!");

                try
                {
                    var result = testingTarget.Capacity();
                    tlog.Debug(tag, "Capacity : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorBaseCapacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBase Count.")]
        [Property("SPEC", "Tizen.NUI.VectorBase.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBaseCount()
        {
            tlog.Debug(tag, $"VectorBaseCount START");

            using (View view = new View())
            {
                var testingTarget = new VectorBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VectorBase>(testingTarget, "Should be an Instance of VectorBase!");

                try
                {
                    var result = testingTarget.Count();
                    tlog.Debug(tag, "Count : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorBaseCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBase Size.")]
        [Property("SPEC", "Tizen.NUI.VectorBase.Size M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBaseSize()
        {
            tlog.Debug(tag, $"VectorBaseSize START");

            using (View view = new View())
            {
                var testingTarget = new VectorBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VectorBase>(testingTarget, "Should be an Instance of VectorBase!");

                try
                {
                    var result = testingTarget.Size();
                    tlog.Debug(tag, "Size : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorBaseSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBase Empty.")]
        [Property("SPEC", "Tizen.NUI.VectorBase.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBaseEmpty()
        {
            tlog.Debug(tag, $"VectorBaseEmpty START");

            using (View view = new View())
            {
                var testingTarget = new VectorBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VectorBase>(testingTarget, "Should be an Instance of VectorBase!");

                try
                {
                    var result = testingTarget.Empty();
                    tlog.Debug(tag, "Empty : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorBaseEmpty END (OK)");
        }
    }
}
