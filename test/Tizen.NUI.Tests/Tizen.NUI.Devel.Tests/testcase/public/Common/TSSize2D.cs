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
    [Description("public/Common/Size2D")]
    public class PublicSize2DTest
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
        [Description("Size2D constructor.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Size2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DConstructor()
        {
            tlog.Debug(tag, $"Size2DConstructorWithInteger START");

            var testingTarget = new Size2D();
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DConstructorWithInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D constructor. With Integer.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Size2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DConstructorWithInteger()
        {
            tlog.Debug(tag, $"Size2DConstructorWithInteger START");

            var testingTarget = new Size2D(100, 100);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            Assert.AreEqual(100, testingTarget.Height, "The Height property of position is not correct here.");
            Assert.AreEqual(100, testingTarget.Width, "The Width property of position is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DConstructorWithInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D Width.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Size2DWidth()
        {
            tlog.Debug(tag, $"Size2DWidth START");

            var testingTarget = new Size2D(100, 100);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            Assert.AreEqual(100, testingTarget.Width, "The Width should be 100.0f here!");

            testingTarget.Width = 200;
            Assert.AreEqual(200, testingTarget.Width, "The Width should be 200.0f here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D Height.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Size2DHeight()
        {
            tlog.Debug(tag, $"Size2DHeight START");

            var testingTarget = new Size2D(100, 100);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            Assert.AreEqual(100.0f, testingTarget.Height, "The Height should be 100.0f here!");

            testingTarget.Height = 200;
            Assert.AreEqual(200, testingTarget.Height, "The Height should be 200.0f here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size2D.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DEqualTo()
        {
            tlog.Debug(tag, $"Size2DNotEqualTo START");

            var testingTarget = new Size2D(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(1, 2))
            {
                Assert.IsTrue((testingTarget.EqualTo(size)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Size2D.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DNotEqualTo()
        {
            tlog.Debug(tag, $"Size2DNotEqualTo START");

            var testingTarget = new Size2D(10, 20);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(1, 2))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(size)), "Should be equal");
            }
                
            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator +.")]
        [Property("SPEC", "Tizen.NUI.Size2D.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DAddition()
        {
            tlog.Debug(tag, $"Size2DAddition START");

            var testingTarget = new Size2D(2, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(4, 6))
            {
                var result = testingTarget + size;
                Assert.AreEqual(6, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(9, result.Height, "The Height value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DAddition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator -.")]
        [Property("SPEC", "Tizen.NUI.Size2D.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DSubtraction()
        {
            tlog.Debug(tag, $"Size2DSubtraction START");

            var testingTarget = new Size2D(4, 6);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(2, 3))
            {
                var result = testingTarget - size;
                Assert.AreEqual(2, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(3, result.Height, "The Height value of the size is not correct!");
            }
               
            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator -.")]
        [Property("SPEC", "Tizen.NUI.Size2D.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DUnaryNegation()
        {
            tlog.Debug(tag, $"Size2DUnaryNegation START");

            var testingTarget = new Size2D(2, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            var result = -testingTarget;
            Assert.AreEqual(-2, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(-3, result.Height, "The Height value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator *. By Size2D.")]
        [Property("SPEC", "Tizen.NUI.Size2D.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, Size2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DMultiplyBySize2D()
        {
            tlog.Debug(tag, $"Size2DMultiplyBySize2D START");

            var testingTarget = new Size2D(2, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(4, 6))
            {
                var result = testingTarget * size;
                Assert.AreEqual(8, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(18, result.Height, "The Height value of the size is not correct!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DMultiplyBySize2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator *. By Integer.")]
        [Property("SPEC", "Tizen.NUI.Size2D.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DMultiplyByInteger()
        {
            tlog.Debug(tag, $"Size2DMultiplyByInteger START");

            var testingTarget = new Size2D(2, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            var result = testingTarget * 2;
            Assert.AreEqual(4, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(6, result.Height, "The Height value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DMultiplyByInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator /. By Size2D.")]
        [Property("SPEC", "Tizen.NUI.Size2D./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, Size2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DDivisionBySize2D()
        {
            tlog.Debug(tag, $"Size2DDivisionBySize2D START");

            var testingTarget = new Size2D(4, 6);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(2, 3))
            {
                var result = testingTarget / size;
                Assert.AreEqual(2, result.Width, "The Width value of the size is not correct!");
                Assert.AreEqual(2, result.Height, "The Height value of the size is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DDivisionBySize2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D operator /. By Integer.")]
        [Property("SPEC", "Tizen.NUI.Size2D./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DDivisionByInteger()
        {
            tlog.Debug(tag, $"Size2DDivisionByInteger START");

            var testingTarget = new Size2D(4, 6);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            var result = testingTarget / 2;
            Assert.AreEqual(2, result.Width, "The Width value of the size is not correct!");
            Assert.AreEqual(3, result.Height, "The Height value of the size is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DDivisionByInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Size2D.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DGetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"Size2DGetValueBySubscriptIndex START");

            var testingTarget = new Size2D(100, 300);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            Assert.AreEqual(100, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(300, testingTarget[1], "The value of index[1] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DGetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D Equals.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DEquals()
        {
            tlog.Debug(tag, $"Size2DEquals START");

            var testingTarget = new Size2D(1, 1);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            using (Size2D size = new Size2D(1, 1))
            {
                var result = testingTarget.Equals(size);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D implicit. Vector2 to Size2D.")]
        [Property("SPEC", "Tizen.NUI.Size2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DImplicitToSize2D()
        {
            tlog.Debug(tag, $"Size2DImplicitToSize2D START");

            Size2D testingTarget = null;
            using (Vector2 vector = new Vector2(10, 20))
            {
                testingTarget = vector;
                Assert.AreEqual(vector.X, testingTarget.Width, "The value of Width is not correct.");
                Assert.AreEqual(vector.Y, testingTarget.Height, "The value of Height is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DImplicitToSize2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D implicit. Size2D to Vector2.")]
        [Property("SPEC", "Tizen.NUI.Size2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Size2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DImplicitToVector2()
        {
            tlog.Debug(tag, $"Size2DImplicitToVector2 START");

            Vector2 testingTarget = null;
            using (Size2D size = new Size2D(10, 20))
            {
                testingTarget = size;
                Assert.AreEqual(size.Width, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(size.Height, testingTarget.Y, "The value of Y is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DImplicitToVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Size2D.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DGetHashCode()
        {
            tlog.Debug(tag, $"Size2DGetHashCode START");

            var testingTarget = new Size2D(10, 20);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should be an instance of Size2D type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Size2DGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D Clone.")]
        [Property("SPEC", "Tizen.NUI.Size2D.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DClone()
        {
            tlog.Debug(tag, $"Size2DClone START");

            using (Size2D size2d = new Size2D(100, 50))
            {
                try
                {
                    size2d.Clone();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }
            }

            tlog.Debug(tag, $"Size2DClone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Size2D GetSize2DFromPtr.")]
        [Property("SPEC", "Tizen.NUI.Size2D.GetSize2DFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DGetSize2DFromPtr()
        {
            tlog.Debug(tag, $"Size2DGetSize2DFromPtr START");

            using (Size size = new Size(100, 50))
            {
                var testingTarget = Size2D.GetSize2DFromPtr(size.SwigCPtr.Handle);
                Assert.AreEqual(100, testingTarget.Width, "Should be equal!");
                Assert.AreEqual(50, testingTarget.Height, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Size2DGetSize2DFromPtr END (OK)");
        }
    }
}
