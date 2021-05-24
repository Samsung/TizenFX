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
    [Description("public/Common/Size")]
    public class PublicSizeTest
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
        [Description("Size constructor.")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeConstructor()
        {
            tlog.Debug(tag, $"SizeConstructor START");

            var testingTarget = new Size();
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should return Size instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size constructor. With 3 Float.")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeConstructorWith3Float()
        {
            tlog.Debug(tag, $"SizeConstructorWith3Float START");

            var testingTarget = new Size(100.0f, 100.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should return Size instance.");

            Assert.AreEqual(100.0f, testingTarget.Width, "The Width property of position is not correct here.");
            Assert.AreEqual(100.0f, testingTarget.Height, "The Height property of position is not correct here.");
            Assert.AreEqual(100.0f, testingTarget.Depth, "The Depth property of position is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeConstructorWith3Float END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size constructor. With Size2D.")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Size2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeConstructorWithSize2D()
        {
            tlog.Debug(tag, $"SizeConstructorWithSize2D START");

            using (Size2D size2D = new Size2D(100, 100))
            {
                var testingTarget = new Size(size2D);
                Assert.IsNotNull(testingTarget, "Can't create success object Size");
                Assert.IsInstanceOf<Size>(testingTarget, "Should return Size instance.");

                Assert.AreEqual(100.0f, testingTarget.Width, "The Width property of position is not correct here.");
                Assert.AreEqual(100.0f, testingTarget.Height, "The Height property of position is not correct here.");
                Assert.AreEqual(0.0f, testingTarget.Depth, "The Depth property of position is not correct here.");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"SizeConstructorWithSize2D END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Size Width.")]
        [Property("SPEC", "Tizen.NUI.Size.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SizeWidth()
        {
            tlog.Debug(tag, $"SizeWidth START");

            var testingTarget = new Size(100.0f, 100.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            Assert.AreEqual(100.0f, testingTarget.Width, "The Width should be 100.0f here!");

            testingTarget.Width = 200.0f;
            Assert.AreEqual(200.0f, testingTarget.Width, "The Width should be 100.0f here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size Height.")]
        [Property("SPEC", "Tizen.NUI.Size.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SizeHeight()
        {
            tlog.Debug(tag, $"SizeHeight START");

            var testingTarget = new Size(100.0f, 100.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            Assert.AreEqual(100.0f, testingTarget.Height, "The Height should be 100.0f here!");

            testingTarget.Height = 200.0f;
            Assert.AreEqual(200.0f, testingTarget.Height, "The Height should be 200.0f here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size Depth.")]
        [Property("SPEC", "Tizen.NUI.Size.Depth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SizeDepth()
        {
            tlog.Debug(tag, $"SizeDepth START");

            Size testingTarget = new Size(100.0f, 100.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            Assert.AreEqual(100.0f, testingTarget.Depth, "The Depth should be 100.0f here!");

            testingTarget.Depth = 200.0f;
            Assert.AreEqual(200.0f, testingTarget.Depth, "The Depth should be 200.0f here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeDepth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeEqualTo()
        {
            tlog.Debug(tag, $"SizeEqualTo START");

            var testingTarget = new Size(1.0f, 2.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(1.0f, 2.0f, 3.0f))
            {
                Assert.IsTrue((testingTarget.EqualTo(size)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size Equals.")]
        [Property("SPEC", "Tizen.NUI.Size.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeEquals()
        {
            tlog.Debug(tag, $"SizeEquals START");

            var testingTarget = new Size(1.0f, 2.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(1.0f, 2.0f, 3.0f))
            {
                Assert.IsTrue((testingTarget.Equals(size)), "Should be equal");
            }

            using (Size size = new Size(2.0f, 2.0f, 3.0f)) 
            {
                Assert.IsFalse((testingTarget.Equals(size)), "Should not be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeNotEqualTo()
        {
            tlog.Debug(tag, $"SizeNotEqualTo START");

            var testingTarget = new Size(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(1.0f, 2.0f, 3.0f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(size)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Size.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeGetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"SizeGetValueBySubscriptIndex START");

            var testingTarget = new Size(20.0f, 30.0f, 50.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            Assert.AreEqual(20.0f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(30.0f, testingTarget[1], "The value of index[1] is not correct!");
            Assert.AreEqual(50.0f, testingTarget[2], "The value of index[2] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeGetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size Zero.")]
        [Property("SPEC", "Tizen.NUI.Size.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeZero()
        {
            tlog.Debug(tag, $"SizeZero START");

            var testingTarget = Size.Zero;
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            Assert.AreEqual(0.0f, testingTarget.Width, "The value of Size.Zero.Width is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Height, "The value of Size.Zero.Height is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Depth, "The value of Size.Zero.Depth is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeZero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator +.")]
        [Property("SPEC", "Tizen.NUI.Size.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeAddition()
        {
            tlog.Debug(tag, $"SizeAddition START");

            var testingTarget = new Size(20.0f, 30.0f, 50.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(40.0f, 60.0f, 30.0f))
            {
                var result = testingTarget + size;
                Assert.AreEqual(60.0f, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(90.0f, result.Height, "The Height value of the size is not correct!");
                Assert.AreEqual(80.0f, result.Depth, "The Depth value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeAddition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator -.")]
        [Property("SPEC", "Tizen.NUI.Size.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeSubtraction()
        {
            tlog.Debug(tag, $"SizeSubtraction START");

            var testingTarget = new Size(40.0f, 60.0f, 60.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(20.0f, 30.0f, 50.0f))
            {
                var result = testingTarget - size;
                Assert.AreEqual(20.0f, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(30.0f, result.Height, "The Height value of the size is not correct!");
                Assert.AreEqual(10.0f, result.Depth, "The Depth value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator -.")]
        [Property("SPEC", "Tizen.NUI.Size.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeUnaryNegation()
        {
            tlog.Debug(tag, $"SizeUnaryNegation START");

            var testingTarget = new Size(20.0f, 30.0f, 50.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            var result = -testingTarget;
            Assert.AreEqual(-20.0f, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(-30.0f, result.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(-50.0f, result.Depth, "The Depth value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator *. By Size.")]
        [Property("SPEC", "Tizen.NUI.Size.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size, Size")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeMultiplyBySize()
        {
            tlog.Debug(tag, $"SizeMultiplyBySize START");

            var testingTarget = new Size(20.0f, 30.0f, 50.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(40.0f, 60.0f, 60.0f))
            {
                var result = testingTarget * size;
                Assert.AreEqual(800.0f, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(1800.0f, result.Height, "The Height value of the size is not correct!");
                Assert.AreEqual(3000.0f, result.Depth, "The Depth value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeMultiplyBySize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator *. By Float.")]
        [Property("SPEC", "Tizen.NUI.Size.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeMultiplyByFloat()
        {
            tlog.Debug(tag, $"SizeMultiplyByFloat START");

            var testingTarget = new Size(20.0f, 30.0f, 50.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            var result = testingTarget * 10.0f;
            Assert.AreEqual(200.0f, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(300.0f, result.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(500.0f, result.Depth, "The Depth value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeMultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator /. By Size.")]
        [Property("SPEC", "Tizen.NUI.Size./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeDivisionBySize()
        {
            tlog.Debug(tag, $"SizeDivisionBySize START");

            var testingTarget = new Size(40.0f, 60.0f, 60.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            using (Size size = new Size(20.0f, 30.0f, 20.0f))
            {
                var result = testingTarget / size;
                Assert.AreEqual(2.0f, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(2.0f, result.Height, "The Height value of the size is not correct!");
                Assert.AreEqual(3.0f, result.Depth, "The Depth value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeDivisionBySize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size operator /. By Float.")]
        [Property("SPEC", "Tizen.NUI.Size./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeDivisionByFloat()
        {
            tlog.Debug(tag, $"SizeDivisionByFloat START");

            var testingTarget = new Size(20.0f, 30.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            var result = testingTarget / 10.0f; 
            Assert.AreEqual(2.0f, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(3.0f, result.Height, "The Height value of the size is not correct!");
            Assert.AreEqual(2.0f, result.Depth, "The Depth value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeDivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size implicit. Vector3 to Size.")]
        [Property("SPEC", "Tizen.NUI.Size.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeImplicitToSize()
        {
            tlog.Debug(tag, $"SizeImplicitToSize START");

            Size testingTarget = null;
            using (Vector3 vector = new Vector3(10.0f, 20.0f, 30.0f))
            {
                testingTarget = vector;
                Assert.AreEqual(vector.X, testingTarget.Width, "The value of Width is not correct.");
                Assert.AreEqual(vector.Y, testingTarget.Height, "The value of Height is not correct.");
                Assert.AreEqual(vector.Z, testingTarget.Depth, "The value of Depth is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeImplicitToSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size implicit. Size To Vector3.")]
        [Property("SPEC", "Tizen.NUI.Size.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeImplicitToVector3()
        {
            tlog.Debug(tag, $"SizeImplicitToVector3 START");

            Vector3 testingTarget = null;
            using (Size size = new Size(10.0f, 20.0f, 30.0f))
            {
                testingTarget = size;
                Assert.AreEqual(size.Width, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(size.Height, testingTarget.Y, "The value of Y is not correct.");
                Assert.AreEqual(size.Depth, testingTarget.Z, "The value of Z is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeImplicitToVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size Dispose.")]
        [Property("SPEC", "Tizen.NUI.Size.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeDispose()
        {
            tlog.Debug(tag, $"SizeDispose START");

            var testingTarget = new Size();
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"SizeDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Size.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeGetHashCode()
        {
            tlog.Debug(tag, $"SizeGetHashCode START");

            var testingTarget = new Size(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Size");
            Assert.IsInstanceOf<Size>(testingTarget, "Should be an instance of Size type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeGetHashCode END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Size constructor. With Float")]
        [Property("SPEC", "Tizen.NUI.Size.Size C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SizeConstructorWithFloat()
        {
            tlog.Debug(tag, $"SizeConstructorWithFloat START");

            var testingTarget = new Size(100.0f, 100.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Size>(testingTarget, "Should return Size instance.");
            
            Assert.AreEqual(100.0f, testingTarget.Width, "The Width property of position is not correct here.");
            Assert.AreEqual(100.0f, testingTarget.Height, "The Height property of position is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SizeConstructorWithFloat END (OK)");
        }
    }
}
