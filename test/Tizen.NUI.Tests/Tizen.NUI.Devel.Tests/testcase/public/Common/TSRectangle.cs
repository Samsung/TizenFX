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
    [Description("public/Common/Rectangle")]
    public class PublicRectangleTest
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
        [Description("Rectangle operator ==.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.operator == M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleOperatorEquals()
        {
            tlog.Debug(tag, $"RectangleOperatorEquals START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            using (Rectangle rectangle = new Rectangle(5, 6, 100, 200))
            {
                var result = (testingTarget == rectangle);
                Assert.IsTrue(result, "this two Rectangle is not equal");
            }

            using (Rectangle rectangle = new Rectangle(5, 6, 200, 200))
            {
                var result = (testingTarget == rectangle);
                Assert.IsFalse(result, "this two Rectangle is equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleOperatorEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle operator !=.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.operator != M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleOperatorNotEquals()
        {
            tlog.Debug(tag, $"RectangleOperatorNotEquals START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            using (Rectangle rectangle = new Rectangle(5, 6, 100, 200))
            {
                var result = (testingTarget != rectangle);
                Assert.IsFalse(result, "this two Rectangle is not equal");
            }

            using (Rectangle rectangle = new Rectangle(5, 6, 200, 200))
            {
                var result = (testingTarget != rectangle);
                Assert.IsTrue(result, "this two Rectangle is equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleOperatorNotEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle X.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RectangleX()
        {
            tlog.Debug(tag, $"RectangleX START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            Assert.AreEqual(5, testingTarget.X, "The X value of the Rectangle is not correct!");
            testingTarget.X = 10;
            Assert.AreEqual(10, testingTarget.X, "The X value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Y.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RectangleY()
        {
            tlog.Debug(tag, $"RectangleY START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            Assert.AreEqual(6, testingTarget.Y, "The Y value of the Rectangle is not correct!");
            
            testingTarget.Y = 10;
            Assert.AreEqual(10, testingTarget.Y, "The Y value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Width.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RectangleWidth()
        {
            tlog.Debug(tag, $"RectangleWidth START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            Assert.AreEqual(100, testingTarget.Width, "The Width value of the Rectangle is not correct!");
            
            testingTarget.Width = 150;
            Assert.AreEqual(150, testingTarget.Width, "The Width value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Height.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RectangleHeight()
        {
            tlog.Debug(tag, $"RectangleHeight START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            Assert.AreEqual(200, testingTarget.Height, "The Height value of the Rectangle is not correct!");

            testingTarget.Height = 250;
            Assert.AreEqual(250, testingTarget.Height, "The Height value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle constructor.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Rectangle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleConstructor()
        {
            tlog.Debug(tag, $"RectangleConstructor START");

            var testingTarget = new Rectangle();
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle constructor. With Integer.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Rectangle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int, int, int, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleConstructorWithInteger()
        {
            tlog.Debug(tag, $"RectangleConstructorWithInteger START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should return Rectangle instance.");

            Assert.AreEqual(2, testingTarget.X, "The X value of the Rectangle is not correct!");
            Assert.AreEqual(3, testingTarget.Y, "The Y value of the Rectangle is not correct!");
            Assert.AreEqual(100, testingTarget.Width, "The Width value of the Rectangle is not correct!");
            Assert.AreEqual(200, testingTarget.Height, "The Height value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleConstructorWithInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Set.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleSet()
        {
            tlog.Debug(tag, $"RectangleSet START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(2, testingTarget.X, "The X value of the Rectangle is not correct!");
            Assert.AreEqual(3, testingTarget.Y, "The Y value of the Rectangle is not correct!");
            Assert.AreEqual(100, testingTarget.Width, "The Width value of the Rectangle is not correct!");
            Assert.AreEqual(200, testingTarget.Height, "The Height value of the Rectangle is not correct!");

            testingTarget.Set(5, 6, 300, 400);
            Assert.AreEqual(5, testingTarget.X, "Set function does not work, The X value of the Rectangle is not correct!");
            Assert.AreEqual(6, testingTarget.Y, "Set function does not work, The Y value of the Rectangle is not correct!");
            Assert.AreEqual(300, testingTarget.Width, "Set function does not work, The Width value of the Rectangle is not correct!");
            Assert.AreEqual(400, testingTarget.Height, "Set function does not work, The Height value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle IsEmpty.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.IsEmpty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleIsEmpty()
        {
            tlog.Debug(tag, $"RectangleIsEmpty START");

            var testingTarget = new Rectangle();
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(true, testingTarget.IsEmpty(), "Rectangle is not empty");

            using (Rectangle rectangle = new Rectangle(2, 3, 100, 200))
            {
                Assert.AreEqual(false, rectangle.IsEmpty(), "Rectangle is empty");
            }

            using (Rectangle rectangle = new Rectangle(2, 3, 100, 0))
            {
                Assert.AreEqual(true, rectangle.IsEmpty(), "Rectangle is not empty");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleIsEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Left.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Left M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleLeft()
        {
            tlog.Debug(tag, $"RectangleLeft START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(2, testingTarget.Left(), "The Left value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Right.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Right M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleRight()
        {
            tlog.Debug(tag, $"RectangleRight START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(102, testingTarget.Right(), "The Right value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Top.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Top M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleTop()
        {
            tlog.Debug(tag, $"RectangleTop START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(3, testingTarget.Top(), "The Top value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Bottom.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Bottom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleBottom()
        {
            tlog.Debug(tag, $"RectangleBottom START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(203, testingTarget.Bottom(), "The Bottom value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleBottom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Area.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Area M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleArea()
        {
            tlog.Debug(tag, $"RectangleArea START");

            var testingTarget = new Rectangle(2, 3, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.AreEqual(20000, testingTarget.Area(), "The Area value of the Rectangle is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleArea END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Intersects.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Intersects M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleIntersects()
        {
            tlog.Debug(tag, $"RectangleIntersects START");

            var testingTarget = new Rectangle(10, 20, 200, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            using (Rectangle rectangle = new Rectangle(10, 120, 200, 200))
            {
                Assert.IsTrue(testingTarget.Intersects(rectangle), "testingTarget does not Intersect rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(10, -80, 200, 200))
            {
                Assert.IsTrue(testingTarget.Intersects(rectangle), "testingTarget does not Intersect rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(110, 20, 200, 200))
            {
                Assert.IsTrue(testingTarget.Intersects(rectangle), "testingTarget does not Intersect rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(-90, 20, 200, 200))
            {
                Assert.IsTrue(testingTarget.Intersects(rectangle), "testingTarget does not Intersect rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(1000, 1200, 10, 10))
            {
                Assert.IsFalse(testingTarget.Intersects(rectangle), "testingTarget Intersect rectangle.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleIntersects END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Contains.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleContains()
        {
            tlog.Debug(tag, $"RectangleContains START");

            var testingTarget = new Rectangle(10, 20, 200, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            Assert.IsTrue(testingTarget.Contains(testingTarget), "testingTarget does not Contains testingTarget.");

            using (Rectangle rectangle = new Rectangle(10, 120, 200, 200))
            {
                Assert.IsFalse(testingTarget.Contains(rectangle), "testingTarget Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(10, -80, 200, 200))
            {
                Assert.IsFalse(testingTarget.Contains(rectangle), "testingTarget Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(110, 20, 200, 200))
            {
                Assert.IsFalse(testingTarget.Contains(rectangle), "testingTarget Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(-90, 20, 200, 200))
            {
                Assert.IsFalse(testingTarget.Contains(rectangle), "testingTarget Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(1000, 1200, 10, 10))
            {
                Assert.IsFalse(testingTarget.Contains(rectangle), "testingTarget Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(50, 70, 50, 50))
            {
                Assert.IsTrue(testingTarget.Contains(rectangle), "testingTarget does not Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(10, 20, 100, 100))
            {
                Assert.IsTrue(testingTarget.Contains(rectangle), "testingTarget does not Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(110, 20, 100, 100))
            {
                Assert.IsTrue(testingTarget.Contains(rectangle), "testingTarget does not Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(110, 120, 100, 100))
            {
                Assert.IsTrue(testingTarget.Contains(rectangle), "testingTarget does not Contains rectangle.");
            }

            using (Rectangle rectangle = new Rectangle(10, 120, 100, 100))
            {
                Assert.IsTrue(testingTarget.Contains(rectangle), "testingTarget does not Contains rectangle.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleContains END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle Equals.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleEquals()
        {
            tlog.Debug(tag, $"RectangleEquals START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");

            using (Rectangle rectangle = new Rectangle(5, 6, 100, 200))
            {
                var result = testingTarget.Equals(rectangle);
                Assert.IsTrue(result, "Should be true!");
            }

            using (Rectangle rectangle = new Rectangle(50, 60, 100, 200))
            {
                var result = testingTarget.Equals(rectangle);
                Assert.IsFalse(result, "Should be true!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rectangle GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Rectangle.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleGetHashCode()
        {
            tlog.Debug(tag, $"RectangleGetHashCode START");

            var testingTarget = new Rectangle(5, 6, 100, 200);
            Assert.IsNotNull(testingTarget, "Can't create success object Rectangle");
            Assert.IsInstanceOf<Rectangle>(testingTarget, "Should be an instance of Rectangle type.");
            
            Assert.GreaterOrEqual(testingTarget.GetHashCode(), 0, "Should be true");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RectangleGetHashCode END (OK)");
        }
    }
}
