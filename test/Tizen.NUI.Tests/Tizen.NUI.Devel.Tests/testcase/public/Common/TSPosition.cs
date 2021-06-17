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
    [Description("public/Common/Position")]
    public class PublicPositionTest
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
        [Description("Position constructor.")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionConstructor()
        {
            tlog.Debug(tag, $"PositionConstructor START");

            var testingTarget = new Position();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position constructor. With X,Y,Z values.")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionConstructorWithXYZ()
        {
            tlog.Debug(tag, $"PositionConstructorWithXYZ START");

            var testingTarget = new Position(0.5f, 0.5f, 0.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(0.5f, testingTarget.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.Y, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionConstructorWithXYZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position constructor. With Position2D instance.")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Position2D")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionConstructorWithPosition2D()
        {
            tlog.Debug(tag, $"PositionConstructorWithPosition2D START");

            Position2D position2D = new Position2D(50, 50);

            var testingTarget = new Position(position2D);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(50.0f, testingTarget.X, "Should be equal!");
            Assert.AreEqual(50.0f, testingTarget.Y, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionConstructorWithPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position X.")]
        [Property("SPEC", "Tizen.NUI.Position.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PositionX()
        {
            tlog.Debug(tag, $"PositionX START");

            var testingTarget = new Position(0.5f, 0.5f, 0.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(0.5f, testingTarget.X, "Should be equal!");

            testingTarget.X = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.X, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position Y.")]
        [Property("SPEC", "Tizen.NUI.Position.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PositionY()
        {
            tlog.Debug(tag, $"PositionY START");

            var testingTarget = new Position(0.5f, 0.5f, 0.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(0.5f, testingTarget.Y, "Should be equal!");

            testingTarget.Y = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position Z.")]
        [Property("SPEC", "Tizen.NUI.Position.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PositionZ()
        {
            tlog.Debug(tag, $"PositionZ START");

            var testingTarget = new Position(0.5f, 0.5f, 0.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should be equal!");

            Assert.AreEqual(0.5f, testingTarget.Z, "Should be equal!");

            testingTarget.Z = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginTop.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginTop()
        {
            tlog.Debug(tag, $"PositionParentOriginTop START");

            var result = Position.ParentOriginTop;
            Assert.AreEqual(0.0f, result, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginBottom.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginBottom()
        {
            tlog.Debug(tag, $"PositionParentOriginBottom START");

            var result = Position.ParentOriginBottom;
            Assert.AreEqual(1.0f, result, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginBottom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginLeft()
        {
            tlog.Debug(tag, $"PositionParentOriginLeft START");

            var result = Position.ParentOriginLeft;
            Assert.AreEqual(0.0f, result, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginRight.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginRight()
        {
            tlog.Debug(tag, $"PositionParentOriginRight START");

            var result = Position.ParentOriginRight;
            Assert.AreEqual(1.0f, result, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginMiddle.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginMiddle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginMiddle()
        {
            tlog.Debug(tag, $"PositionParentOriginMiddle START");

            var result = Position.ParentOriginMiddle;
            Assert.AreEqual(0.5f, result, "The value of ParentOriginMiddle is not correct.");

            tlog.Debug(tag, $"PositionParentOriginMiddle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginTopLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginTopLeft()
        {
            tlog.Debug(tag, $"PositionParentOriginTopLeft START");

            Assert.AreEqual(0.0f, Position.ParentOriginTopLeft.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.ParentOriginTopLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginTopLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginTopLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginTopCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginTopCenter()
        {
            tlog.Debug(tag, $"PositionParentOriginTopCenter START");

            Assert.AreEqual(0.5f, Position.ParentOriginTopCenter.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.ParentOriginTopCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginTopCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginTopCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginTopRight.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginTopRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginTopRight()
        {
            tlog.Debug(tag, $"PositionParentOriginTopRight START");

            Assert.AreEqual(1.0f, Position.ParentOriginTopRight.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.ParentOriginTopRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginTopRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginTopRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginCenterLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenterLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginCenterLeft()
        {
            tlog.Debug(tag, $"PositionParentOriginCenterLeft START");

            Assert.AreEqual(0.0f, Position.ParentOriginCenterLeft.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginCenterLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginCenter()
        {
            tlog.Debug(tag, $"PositionParentOriginCenter START");

            Assert.AreEqual(0.5f, Position.ParentOriginCenter.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginCenterRight.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginCenterRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginCenterRight()
        {
            tlog.Debug(tag, $"PositionParentOriginCenterRight START");

            Assert.AreEqual(1.0f, Position.ParentOriginCenterRight.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginCenterRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginCenterRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginBottomLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginBottomLeft()
        {
            tlog.Debug(tag, $"PositionParentOriginBottomLeft START");

            Assert.AreEqual(0.0f, Position.ParentOriginBottomLeft.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginBottomLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginBottomCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginBottomCenter()
        {
            tlog.Debug(tag, $"PositionParentOriginBottomCenter START");

            Assert.AreEqual(0.5f, Position.ParentOriginBottomCenter.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginBottomCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position ParentOriginBottomRight.")]
        [Property("SPEC", "Tizen.NUI.Position.ParentOriginBottomRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionParentOriginBottomRight()
        {
            tlog.Debug(tag, $"PositionParentOriginBottomRight START");

            Assert.AreEqual(1.0f, Position.ParentOriginBottomRight.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.ParentOriginBottomRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.ParentOriginBottomRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionParentOriginBottomRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointTop.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointTop()
        {
            tlog.Debug(tag, $"PositionPivotPointTop START");

            Assert.AreEqual(0.0f, Position.PivotPointTop, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointBottom.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointBottom()
        {
            tlog.Debug(tag, $"PositionPivotPointBottom START");

            Assert.AreEqual(1.0f, Position.PivotPointBottom, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointBottom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointLeft()
        {
            tlog.Debug(tag, $"PositionPivotPointLeft START");

            Assert.AreEqual(0.0f, Position.PivotPointLeft, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointRight.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointRight()
        {
            tlog.Debug(tag, $"PositionPivotPointRight START");

            Assert.AreEqual(1.0f, Position.PivotPointRight, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointMiddle.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointMiddle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointMiddle()
        {
            tlog.Debug(tag, $"PositionPivotPointMiddle START");

            Assert.AreEqual(0.5f, Position.PivotPointMiddle, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointMiddle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointTopLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointTopLeft()
        {
            tlog.Debug(tag, $"PositionPivotPointTopLeft START");

            Assert.AreEqual(0.0f, Position.PivotPointTopLeft.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.PivotPointTopLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointTopLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointTopLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointTopCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointTopCenter()
        {
            tlog.Debug(tag, $"PositionPivotPointTopCenter START");

            Assert.AreEqual(0.5f, Position.PivotPointTopCenter.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.PivotPointTopCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointTopCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointTopCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointTopRight.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointTopRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointTopRight()
        {
            tlog.Debug(tag, $"PositionPivotPointTopRight START");

            Assert.AreEqual(1.0f, Position.PivotPointTopRight.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.PivotPointTopRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointTopRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointTopRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointCenterLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenterLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointCenterLeft()
        {
            tlog.Debug(tag, $"PositionPivotPointCenterLeft START");

            Assert.AreEqual(0.0f, Position.PivotPointCenterLeft.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenterLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenterLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointCenterLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointCenter()
        {
            tlog.Debug(tag, $"PositionPivotPointCenter START");

            Assert.AreEqual(0.5f, Position.PivotPointCenter.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointCenterRight.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointCenterRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointCenterRight()
        {
            tlog.Debug(tag, $"PositionPivotPointCenterRight START");

            Assert.AreEqual(1.0f, Position.PivotPointCenterRight.X, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenterRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointCenterRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointCenterRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointBottomLeft.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointBottomLeft()
        {
            tlog.Debug(tag, $"PositionPivotPointBottomLeft START");

            Assert.AreEqual(0.0f, Position.PivotPointBottomLeft.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.PivotPointBottomLeft.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointBottomLeft.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointBottomLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointBottomCenter.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomCenter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PositionPivotPointBottomCenter()
        {
            tlog.Debug(tag, $"PositionPivotPointBottomCenter START");

            Assert.AreEqual(0.5f, Position.PivotPointBottomCenter.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.PivotPointBottomCenter.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointBottomCenter.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointBottomCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position PivotPointBottomRight.")]
        [Property("SPEC", "Tizen.NUI.Position.PivotPointBottomRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionPivotPointBottomRight()
        {
            tlog.Debug(tag, $"PositionPivotPointBottomRight START");

            Assert.AreEqual(1.0f, Position.PivotPointBottomRight.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.PivotPointBottomRight.Y, "Should be equal!");
            Assert.AreEqual(0.5f, Position.PivotPointBottomRight.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionPivotPointBottomRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Position.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionGetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"PositionGetValueBySubscriptIndex START");

            var testingTarget = new Position(100.0f, 200.0f, 300.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(100.0f, testingTarget[0], "Should be equal!");
            Assert.AreEqual(200.0f, testingTarget[1], "Should be equal!");
            Assert.AreEqual(300.0f, testingTarget[2], "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionGetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position One.")]
        [Property("SPEC", "Tizen.NUI.Position.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionOne()
        {
            tlog.Debug(tag, $"PositionOne START");

            Assert.AreEqual(1.0f, Position.One.X, "Should be equal!");
            Assert.AreEqual(1.0f, Position.One.Y, "Should be equal!");
            Assert.AreEqual(1.0f, Position.One.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionOne END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position Zero.")]
        [Property("SPEC", "Tizen.NUI.Position.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionZero()
        {
            tlog.Debug(tag, $"PositionZero START");

            Assert.AreEqual(0.0f, Position.Zero.X, "Should be equal!");
            Assert.AreEqual(0.0f, Position.Zero.Y, "Should be equal!");
            Assert.AreEqual(0.0f, Position.Zero.Z, "Should be equal!");

            tlog.Debug(tag, $"PositionZero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionEqualTo()
        {
            tlog.Debug(tag, $"PositionEqualTo START");

            var testingTarget = new Position(1.0f, 2.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (var position = new Position(1.0f, 2.0f, 3.0f))
            {
                Assert.IsTrue((testingTarget.EqualTo(position)), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Position.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionNotEqualTo()
        {
            tlog.Debug(tag, $"PositionNotEqualTo START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 2.0f, 3.0f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(position)), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator +.")]
        [Property("SPEC", "Tizen.NUI.Position.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionAddition()
        {
            tlog.Debug(tag, $"PositionAddition START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget + position;
                Assert.AreEqual(11.0f, result.X, "Should be equal!");
                Assert.AreEqual(22.0f, result.Y, "Should be equal!");
                Assert.AreEqual(33.0f, result.Z, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionAddition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator -.")]
        [Property("SPEC", "Tizen.NUI.Position.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionSubtraction()
        {
            tlog.Debug(tag, $"PositionSubtraction START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget - position;
                Assert.AreEqual(9.0f, result.X, "Should be equal!");
                Assert.AreEqual(18.0f, result.Y, "Should be equal!");
                Assert.AreEqual(27.0f, result.Z, "Should be equal!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator -.")]
        [Property("SPEC", "Tizen.NUI.Position.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionUnaryNegation()
        {
            tlog.Debug(tag, $"PositionUnaryNegation START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            var result = -testingTarget;
            Assert.AreEqual(-10.0f, result.X, "Should be equal!");
            Assert.AreEqual(-20.0f, result.Y, "Should be equal!");
            Assert.AreEqual(-30.0f, result.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator *.")]
        [Property("SPEC", "Tizen.NUI.Position.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionMultiply()
        {
            tlog.Debug(tag, $"PositionMultiply START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget * position;
                Assert.AreEqual(10.0f, result.X, "Should be equal!");
                Assert.AreEqual(40.0f, result.Y, "Should be equal!");
                Assert.AreEqual(90.0f, result.Z, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionMultiply END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator *.")]
        [Property("SPEC", "Tizen.NUI.Position.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionMultiplyWithFloat()
        {
            tlog.Debug(tag, $"PositionMultiplyWithFloat START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            var result = testingTarget * 2.0f;
            Assert.AreEqual(20.0f, result.X, "Should be equal!");
            Assert.AreEqual(40.0f, result.Y, "Should be equal!");
            Assert.AreEqual(60.0f, result.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionMultiplyWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator /.")]
        [Property("SPEC", "Tizen.NUI.Position./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionDivision()
        {
            tlog.Debug(tag, $"PositionDivision START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget / position;
                Assert.AreEqual(10.0f, result.X, "Should be equal!");
                Assert.AreEqual(10.0f, result.Y, "Should be equal!");
                Assert.AreEqual(10.0f, result.Z, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionDivision END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position operator /.")]
        [Property("SPEC", "Tizen.NUI.Position./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionDivisionByFloat()
        {
            tlog.Debug(tag, $"PositionDivisionByFloat START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            var result = testingTarget / 10;
            Assert.AreEqual(1.0f, result.X, "Should be equal!");
            Assert.AreEqual(2.0f, result.Y, "Should be equal!");
            Assert.AreEqual(3.0f, result.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionDivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position Equals.")]
        [Property("SPEC", "Tizen.NUI.Position.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionEquals()
        {
            tlog.Debug(tag, $"PositionEquals START");

            var testingTarget = new Position(1.0f, 1.0f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            using (Position position = new Position(1.0f, 1.0f, 1.0f))
            {
                var flag = testingTarget.Equals(position);
                Assert.IsTrue(flag, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position implicit. Convert Vector3 to Position.")]
        [Property("SPEC", "Tizen.NUI.Position.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionImplicitConvertVector3ToPosition()
        {
            tlog.Debug(tag, $"PositionImplicitConvertVector3ToPosition START");

            Position testingTarget = null;
            using (Vector3 vector = new Vector3(10.0f, 20.0f, 30.0f))
            {
                testingTarget = vector;
                Assert.AreEqual(testingTarget.X, vector.X, "Should be equal!");
                Assert.AreEqual(testingTarget.Y, vector.Y, "Should be equal!");
                Assert.AreEqual(testingTarget.Z, vector.Z, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionImplicitConvertVector3ToPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position implicit. Convert Position to Vector3.")]
        [Property("SPEC", "Tizen.NUI.Position.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionImplicitConvertPositionToVector3()
        {
            tlog.Debug(tag, $"PositionImplicitConvertPositionToVector3 START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Vector3 vector = testingTarget;
            Assert.AreEqual(testingTarget.X, vector.X, "The value of X is not correct.");
            Assert.AreEqual(testingTarget.Y, vector.Y, "The value of Y is not correct.");
            Assert.AreEqual(testingTarget.Z, vector.Z, "The value of Z is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionImplicitConvertPositionToVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Position.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionGetHashCode()
        {
            tlog.Debug(tag, $"PositionGetHashCode START");

            var testingTarget = new Position(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            var hash = testingTarget.GetHashCode();
            Assert.IsTrue(hash >= Int32.MinValue && hash <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Position constructor. With two float values.")]
        [Property("SPEC", "Tizen.NUI.Position.Position C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionConstructorWithXY()
        {
            tlog.Debug(tag, $"PositionConstructorWithXY START");

            var testingTarget = new Position(0.5f, 0.5f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position>(testingTarget, "Should return Position instance.");

            Assert.AreEqual(0.5f, testingTarget.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PositionConstructorWithXY END (OK)");
        }
    }
}
