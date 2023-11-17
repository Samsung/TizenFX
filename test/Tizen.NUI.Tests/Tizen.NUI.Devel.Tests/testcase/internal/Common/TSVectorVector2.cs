using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VectorVector2")]
    public class InternalCommonVectorVector2Test
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
        [Description("VectorVector2 contructor.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.VectorVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Contructor()
        {
            tlog.Debug(tag, $"VectorVector2Contructor START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2Contructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 contructor. With VectorVector2.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.VectorVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2ContructorWithVectorVector2()
        {
            tlog.Debug(tag, $"VectorVector2ContructorWithVectorVector2 START");

            using (VectorVector2 vector = new VectorVector2())
            {
                var testingTarget = new VectorVector2(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
                Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorVector2ContructorWithVectorVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Assign.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Assign()
        {
            tlog.Debug(tag, $"VectorVector2Assign START");

            using (VectorVector2 vector = new VectorVector2())
            {
                var testingTarget = vector.Assign(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
                Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VectorVector2Assign END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("VectorVector2 Begin.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Begin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Begin()
        {
            tlog.Debug(tag, $"VectorVector2Begin START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            var result = testingTarget.Begin();
            tlog.Debug(tag, "Begin :" + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2Begin END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("VectorVector2 End.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.End M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2End()
        {
            tlog.Debug(tag, $"VectorVector2End START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            var result = testingTarget.End();
            tlog.Debug(tag, "End :" + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2End END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 PushBack.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.PushBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2PushBack()
        {
            tlog.Debug(tag, $"VectorVector2PushBack START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            try
            {
                testingTarget.PushBack(new Vector2());
                var result = testingTarget.ValueOfIndex(0);
                tlog.Debug(tag, "ValueOfIndex :" + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2PushBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Insert.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Insert()
        {
            tlog.Debug(tag, $"VectorVector2Insert START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            try
            {
                testingTarget.Insert(testingTarget.Begin(), new Vector2(30, 40));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2Insert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Reserve.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Reserve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Reserve()
        {
            tlog.Debug(tag, $"VectorVector2Reverse START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

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
            tlog.Debug(tag, $"VectorVector2Reserve END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Resize.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Resize()
        {
            tlog.Debug(tag, $"VectorVector2Resize START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

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
            tlog.Debug(tag, $"VectorVector2Resize END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("VectorVector2 Resize. With Vector2.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2ResizeWithVector2()
        {
            tlog.Debug(tag, $"VectorVector2ResizeWithVector2 START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            try
            {
                testingTarget.Resize(1, new Vector2());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorVector2ResizeWithVector2 END (OK)");
        }
        
        [Test]
        [Category("P1")]
        [Description("VectorVector2 Swap.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Swap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Swap()
        {
            tlog.Debug(tag, $"VectorVector2Swap START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            try
            {
                using (VectorVector2 vector = new VectorVector2())
                {
                    testingTarget.Swap(vector);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"VectorVector2Swap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Clear.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Clear()
        {
            tlog.Debug(tag, $"VectorVector2Clear START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            testingTarget.Insert(testingTarget.Begin(), new Vector2(30, 40));
            tlog.Debug(tag, "Size : " + testingTarget.Size());

            try
            {
                testingTarget.Clear();
                tlog.Debug(tag, "Size : " + testingTarget.Size());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"VectorVector2Clear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 Release.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.Release M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2Release()
        {
            tlog.Debug(tag, $"VectorVector2Release START");

            var testingTarget = new VectorVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object VectorVector2.");
            Assert.IsInstanceOf<VectorVector2>(testingTarget, "Should return VectorVector2 instance.");

            testingTarget.Insert(testingTarget.Begin(), new Vector2(30, 40));
            tlog.Debug(tag, "Size : " + testingTarget.Size());

            try
            {
                testingTarget.Release();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"VectorVector2Release END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorVector2 BaseType.")]
        [Property("SPEC", "Tizen.NUI.VectorVector2.BaseType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorVector2BaseType()
        {
            tlog.Debug(tag, $"VectorVector2BaseType START");

            try
            {
                var result = VectorVector2.BaseType;
                tlog.Debug(tag, "BaseType : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"VectorVector2BaseType END (OK)");
        }
    }
}