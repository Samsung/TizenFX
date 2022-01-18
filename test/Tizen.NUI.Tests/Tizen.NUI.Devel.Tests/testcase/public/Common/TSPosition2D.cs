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
    [Description("public/Common/Position2D")]
    public class PublicPosition2DTest
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
        [Description("Position2D constructor.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DConstructor()
        {
            tlog.Debug(tag, $"Position2DConstructor START");

            var testingTarget = new Position2D();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D constructor. With Integer.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DConstructorWithInteger()
        {
            tlog.Debug(tag, $"Position2DConstructorWithInteger START");

            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");
            
            Assert.AreEqual(2, testingTarget.X, "The X property of position is not correct here.");
            Assert.AreEqual(3, testingTarget.Y, "The Y property of position is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DConstructorWithInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D constructor. With Position.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Position2D C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Position")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DConstructorWithPosition()
        {
            tlog.Debug(tag, $"Position2DConstructorWithPosition START");

            using (Position position = new Position(5.0f, 5.0f, 0.5f))
            {
                var testingTarget = new Position2D(position);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

                Assert.AreEqual(5.0f, testingTarget.X, "The X property of position is not correct here.");
                Assert.AreEqual(5.0f, testingTarget.Y, "The Y property of position is not correct here.");

                testingTarget.Dispose();
            }
            
            tlog.Debug(tag, $"Position2DConstructorWithPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D X.")]
        [Property("SPEC", "Tizen.NUI.Position2D.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Position2DX()
        {
            tlog.Debug(tag, $"Position2DX START");
            
            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            Assert.AreEqual(2, testingTarget.X, "The X property of position is not correct here.");

            testingTarget.X = 3;
            Assert.AreEqual(3, testingTarget.X, "The X property of position is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DX END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Position2D Y.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Position2DY()
        {
            tlog.Debug(tag, $"Position2DY START");

            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");
            
            Assert.AreEqual(3, testingTarget.Y, "The Y property of position is not correct here.");

            testingTarget.Y = 2;
            Assert.AreEqual(2, testingTarget.Y, "The Y property of position is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position2D.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DEqualTo()
        {
            tlog.Debug(tag, $"Position2DEqualTo START");

            var testingTarget = new Position2D(1, 2);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(1, 2))
            {
                Assert.IsTrue((testingTarget.EqualTo(position)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position2D.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DNotEqualTo()
        {
            tlog.Debug(tag, $"Position2DNotEqualTo START");

            var testingTarget = new Position2D(10, 20);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(1, 2))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(position)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator +.")]
        [Property("SPEC", "Tizen.NUI.Position2D.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DAddition()
        {
            tlog.Debug(tag, $"Position2DNotEqualTo START");

            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(4, 6))
            {
                var result = testingTarget + position;
                Assert.AreEqual(6, result.X, "The X value of the position is not correct!");
                Assert.AreEqual(9, result.Y, "The Y value of the position is not correct!");
            }
           
            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D ConvertFromString.")]
        [Property("SPEC", "Tizen.NUI.Position2D.ConvertFromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DConvertFromString()
        {
            tlog.Debug(tag, $"Position2DConvertFromString START");
            
            var testingTarget = Position2D.ConvertFromString("2,3");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");
            
            Assert.AreEqual(2, testingTarget.X, "The value of the position2 is not correct!");
            Assert.AreEqual(3, testingTarget.Y, "The value of the position2 is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DConvertFromString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator -.")]
        [Property("SPEC", "Tizen.NUI.Position2D.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DSubtraction()
        {
            tlog.Debug(tag, $"Position2DSubtraction START");

            var testingTarget = new Position2D(4, 6);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(2, 3))
            {
                var result = testingTarget - position;
                Assert.AreEqual(2, result.X, "The X value of the position is not correct!");
                Assert.AreEqual(3, result.Y, "The Y value of the position is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator -.")]
        [Property("SPEC", "Tizen.NUI.Position2D.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DUnaryNegation()
        {
            tlog.Debug(tag, $"Position2DUnaryNegation START");

            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            var result = -testingTarget;
            Assert.AreEqual(-2, result.X, "The X value of the position is not correct!");
            Assert.AreEqual(-3, result.Y, "The Y value of the position is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator *.")]
        [Property("SPEC", "Tizen.NUI.Position2D.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, Position2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DMultiplyByPosition2D()
        {
            tlog.Debug(tag, $"Position2DMultiplyByPosition2D START");

            var testingTarget = new Position2D(4, 6);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(2, 3))
            {
                var result = testingTarget * position;
                Assert.AreEqual(8, result.X, "The X value of the position is not correct!");
                Assert.AreEqual(18, result.Y, "The Y value of the position is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DMultiplyByPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator *.")]
        [Property("SPEC", "Tizen.NUI.Position2D.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DMultiplyByInteger()
        {
            tlog.Debug(tag, $"Position2DMultiplyByInteger START");

            var testingTarget = new Position2D(2, 3);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            var result = testingTarget * 10;
            Assert.AreEqual(20, result.X, "The X value of the position is not correct!");
            Assert.AreEqual(30, result.Y, "The Y value of the position is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DMultiplyByInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator /.")]
        [Property("SPEC", "Tizen.NUI.Position2D./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, Position2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DDivisionByPosition2D()
        {
            tlog.Debug(tag, $"Position2DDivisionByPosition2D START");

            var testingTarget = new Position2D(4, 6);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(2, 3))
            {
                var result = testingTarget / position;
                Assert.AreEqual(2, result.X, "The X value of the position is not correct!");
                Assert.AreEqual(2, result.Y, "The Y value of the position is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DDivisionByPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D operator /.")]
        [Property("SPEC", "Tizen.NUI.Position2D./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D, int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DDivisionByInteger()
        {
            tlog.Debug(tag, $"Position2DDivisionByInteger START");

            var testingTarget = new Position2D(20, 30);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            var result = testingTarget / 10;
            Assert.AreEqual(2, result.X, "The X value of the position is not correct!");
            Assert.AreEqual(3, result.Y, "The Y value of the position is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DDivisionByInteger END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Position2D.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DGetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"Position2DGetValueBySubscriptIndex START");

            var testingTarget = new Position2D(100, 300);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            Assert.AreEqual(100, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(300, testingTarget[1], "The value of index[1] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DGetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D Equals.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DEquals()
        {
            tlog.Debug(tag, $"Position2DEquals START");

            var testingTarget = new Position2D(1, 1);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            using (Position2D position = new Position2D(1, 1))
            {
                var result = testingTarget.Equals(position);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D implicit Vector2.")]
        [Property("SPEC", "Tizen.NUI.Position2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DimplicitConvertVector2()
        {
            tlog.Debug(tag, $"Position2DimplicitConvertVector2 START");

            Position2D testingTarget = null;
            using (Vector2 vector = new Vector2(10, 20))
            {
                testingTarget = vector;
                Assert.AreEqual(testingTarget.X, vector.X, "The value of X is not correct.");
                Assert.AreEqual(testingTarget.Y, vector.Y, "The value of Y is not correct.");
            }

            testingTarget.Dispose();    
            tlog.Debug(tag, $"Position2DimplicitConvertVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D implicit Position2D.")]
        [Property("SPEC", "Tizen.NUI.Position2D.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Position2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DImplicitConvertPosition2D()
        {
            tlog.Debug(tag, $"Position2DImplicitConvertPosition2D START");

            Vector2 testingTarget = null;
            using (Position2D position = new Position2D(10, 20))
            {
                testingTarget = position;
                Assert.AreEqual(testingTarget.X, position.X, "The value of X is not correct.");
                Assert.AreEqual(testingTarget.Y, position.Y, "The value of Y is not correct.");
            }

            testingTarget.Dispose();    
            tlog.Debug(tag, $"Position2DImplicitConvertPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D implicit string.")]
        [Property("SPEC", "Tizen.NUI.Position2D.Implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DImplicitConvertString()
        {
            tlog.Debug(tag, $"Position2DImplicitConvertString START");

            string position = "10, 20";

            Position2D testingTarget = position;
            Assert.AreEqual(testingTarget.X, 10, "The value of X is not correct.");
            Assert.AreEqual(testingTarget.Y, 20, "The value of Y is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DImplicitConvertString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position2D GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Position2D.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DGetHashCode()
        {
            tlog.Debug(tag, $"Position2DGetHashCode START");

            var testingTarget = new Position2D(10, 20);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2D>(testingTarget, "Should return Position2D instance.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Position2DGetHashCode END (OK)");
        }
    }
}
