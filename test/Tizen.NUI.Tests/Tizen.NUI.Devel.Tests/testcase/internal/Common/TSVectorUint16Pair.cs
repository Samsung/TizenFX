using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VectorUint16Pair")]
    public class InternalVectorUint16PairTest
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
        [Description("VectorUint16Pair contructor.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.VectorUint16Pair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PairContructor()
        {
            tlog.Debug(tag, $"VectorUint16PairContructor START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16PairContructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair contructor. With VectorUint16Pair.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.VectorUint16Pair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PairContructorWithVectorUint16Pair()
        {
            tlog.Debug(tag, $"VectorUint16PairContructorWithVectorUint16Pair START");

            using (VectorUint16Pair vector = new VectorUint16Pair())
            {
                var testingTarget = new VectorUint16Pair(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
                Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorUint16PairContructorWithVectorUint16Pair END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Assign.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PairAssign()
        {
            tlog.Debug(tag, $"VectorUint16PairAssign START");

            using (VectorUint16Pair vector = new VectorUint16Pair())
            {
                var testingTarget = vector.Assign(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
                Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorUint16PairAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Begin.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Begin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PairBegin()
        {
            tlog.Debug(tag, $"VectorUint16PairBegin START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            var result = testingTarget.Begin();
            tlog.Debug(tag, "Begin :" + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16PairBegin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair End.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.End M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PairEnd()
        {
            tlog.Debug(tag, $"VectorUint16PairEnd START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            var result = testingTarget.End();
            tlog.Debug(tag, "End :" + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16PairEnd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair PushBack.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.PushBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16PushBack()
        {
            tlog.Debug(tag, $"VectorUint16PairPushBack START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                testingTarget.PushBack(new Uint16Pair());
                var result = testingTarget.ValueOfIndex(0);
                tlog.Debug(tag, "ValueOfIndex :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16PairPushBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Insert.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16Insert()
        {
            tlog.Debug(tag, $"VectorUint16Insert START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                testingTarget.Insert(testingTarget.Begin(), new Uint16Pair(30, 40));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16Insert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Reserve.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Reserve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16Reserve()
        {
            tlog.Debug(tag, $"VectorUint16Reverse START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                testingTarget.Reserve(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16Reserve END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Resize.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16Resize()
        {
            tlog.Debug(tag, $"VectorUint16Resize START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                testingTarget.Resize(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16Resize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Resize. With Uint16Pair.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16ResizeWithUint16Pair()
        {
            tlog.Debug(tag, $"VectorUint16ResizeWithUint16Pair START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                testingTarget.Resize(1, new Uint16Pair());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUint16ResizeWithUint16Pair END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair Swap.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.Swap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16Swap()
        {
            tlog.Debug(tag, $"VectorUint16Swap START");

            var testingTarget = new VectorUint16Pair();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUint16Pair.");
            Assert.IsInstanceOf<VectorUint16Pair>(testingTarget, "Should return VectorUint16Pair instance.");

            try
            {
                using (VectorUint16Pair vector = new VectorUint16Pair())
                {
                    testingTarget.Swap(vector);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Clear();
            testingTarget.Release();
            tlog.Debug(tag, $"VectorUint16Swap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUint16Pair BaseType.")]
        [Property("SPEC", "Tizen.NUI.VectorUint16Pair.BaseType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUint16BaseType()
        {
            tlog.Debug(tag, $"VectorUint16BaseType START");

            try
            {
                var result = VectorUint16Pair.BaseType;
                tlog.Debug(tag, "BaseType : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"VectorUint16BaseType END (OK)");
        }
    }
}
