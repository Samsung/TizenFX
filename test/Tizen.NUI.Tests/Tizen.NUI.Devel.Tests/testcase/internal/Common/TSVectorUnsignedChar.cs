using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VectorUnsignedChar")]
    public class InternalVectorUnsignedCharTest
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
        [Description("VectorUnsignedChar contructor.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.VectorUnsignedChar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharContructor()
        {
            tlog.Debug(tag, $"VectorUnsignedCharContructor START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharContructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar contructor. With VectorUnsignedChar.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.VectorUnsignedChar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharContructorWithVectorUnsignedChar()
        {
            tlog.Debug(tag, $"VectorUnsignedCharContructorWithVectorUnsignedChar START");

            using (VectorUnsignedChar vector = new VectorUnsignedChar())
            {
                var testingTarget = new VectorUnsignedChar(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
                Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorUnsignedCharContructorWithVectorUnsignedChar END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar Assign.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharAssign()
        {
            tlog.Debug(tag, $"VectorUnsignedCharAssign START");

            using (VectorUnsignedChar vector = new VectorUnsignedChar())
            {
                var testingTarget = vector.Assign(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
                Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorUnsignedCharAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar Begin.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.Begin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharBegin()
        {
            tlog.Debug(tag, $"VectorUnsignedCharBegin START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                testingTarget.Begin();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharBegin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar End.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.End M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharEnd()
        {
            tlog.Debug(tag, $"VectorUnsignedCharEnd START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                testingTarget.End();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharEnd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar PushBack.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.PushBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharPushBack()
        {
            tlog.Debug(tag, $"VectorUnsignedCharPushBack START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                testingTarget.PushBack(255);
                var result = testingTarget.ValueOfIndex(0);
                tlog.Debug(tag, "ValueOfIndex(0) : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharPushBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar Reserve.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.Reserve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharReserve()
        {
            tlog.Debug(tag, $"VectorUnsignedCharReserve START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                testingTarget.PushBack(255);
                testingTarget.Reserve(1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharReserve END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar Resize.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharResize()
        {
            tlog.Debug(tag, $"VectorUnsignedCharResize START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                testingTarget.PushBack(255);
                /** 1 parameter : uint count */
                testingTarget.Resize(1);
                /** 2 parameters : uint count, byte item */
                testingTarget.Resize(1, 111);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorUnsignedCharResize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar Swap.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.Swap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharSwap()
        {
            tlog.Debug(tag, $"VectorUnsignedCharSwap START");

            var testingTarget = new VectorUnsignedChar();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorUnsignedChar.");
            Assert.IsInstanceOf<VectorUnsignedChar>(testingTarget, "Should return VectorUnsignedChar instance.");

            try
            {
                using (VectorUnsignedChar vector = new VectorUnsignedChar())
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
            tlog.Debug(tag, $"VectorUnsignedCharSwap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorUnsignedChar BaseType.")]
        [Property("SPEC", "Tizen.NUI.VectorUnsignedChar.BaseType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorUnsignedCharBaseType()
        {
            tlog.Debug(tag, $"VectorUnsignedCharBaseType START");

            try
            {
                var result = VectorUnsignedChar.BaseType;
                tlog.Debug(tag, "BaseType : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"VectorUnsignedCharBaseType END (OK)");
        }
    }
}
