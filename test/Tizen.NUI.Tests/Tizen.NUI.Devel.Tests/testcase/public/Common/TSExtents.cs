using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Extents")]
    class PublicExtensionsTest
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
        [Description("Extents constructor")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsConstructor()
        {
            tlog.Debug(tag, $"ExtentsConstructor START");

            var testingTarget = new Extents();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents constructor. With four UInt16 parameters")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsConstructorWithUInt16Parameters()
        {
            tlog.Debug(tag, $"ExtentsConstructorWithUInt16Parameters START");

            var testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(1, testingTarget.Start, "Retrieved extents.Start should be equal to 1");
            Assert.AreEqual(2, testingTarget.End, "Retrieved extents.End should be equal to 2");
            Assert.AreEqual(3, testingTarget.Top, "Retrieved extents.Top should be equal to 3");
            Assert.AreEqual(4, testingTarget.Bottom, "Retrieved extents.Bottom should be equal 4");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsConstructorWithUInt16Parameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents constructor Extents instance")]
        [Property("SPEC", "Tizen.NUI.Extents.Extents C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsConstructorWithExtents()
        {
            tlog.Debug(tag, $"ExtentsConstructorWithExtents START");

            var testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");

            var result = new Extents(testingTarget);
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<Extents>(result, "should be an instance of Extents class!");

            Assert.AreEqual(1, result.Start, "Retrieved extents.Start should be equal to 1");
            Assert.AreEqual(2, result.End, "Retrieved extents.End should be equal to 2");
            Assert.AreEqual(3, result.Top, "Retrieved extents.Top should be equal to 3");
            Assert.AreEqual(4, result.Bottom, "Retrieved extents.Bottom should be equal to 4");

            result.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsConstructorWithExtents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents EqualTo")]
        [Property("SPEC", "Tizen.NUI.Extents.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsEqualTo()
        {
            tlog.Debug(tag, $"ExtentsEqualTo START");

            Extents testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget;
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<Extents>(result, "should be an instance of Extents class!");

            Assert.IsTrue((testingTarget.EqualTo(result)), "Should be equal");

            result.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents NotEqualTo")]
        [Property("SPEC", "Tizen.NUI.Extents.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsNotEqualTo()
        {
            tlog.Debug(tag, $"ExtentsNotEqualTo START");

            Extents testingTarget1 = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget1, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget1, "should be an instance of Extents class!");

            Extents testingTarget2 = new Extents(2, 3, 4, 5);
            Assert.IsNotNull(testingTarget2, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget2, "should be an instance of Extents class!");

            Assert.IsTrue((testingTarget1.NotEqualTo(testingTarget2)), "Should be not equal");

            testingTarget2.Dispose();
            testingTarget1.Dispose();
            tlog.Debug(tag, $"ExtentsNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents Start")]
        [Property("SPEC", "Tizen.NUI.Extents.Start A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsStart()
        {
            tlog.Debug(tag, $"ExtentsStart START");

            var testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(1, testingTarget.Start, "testingTarget.Start should be equal to the set value!");
            
            testingTarget.Start = 5;
            Assert.AreEqual(5, testingTarget.Start, "testingTarget.Start should be equal to the set value!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsStart END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents End")]
        [Property("SPEC", "Tizen.NUI.Extents.End A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsEnd()
        {
            tlog.Debug(tag, $"ExtentsEnd START");

            var testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(2, testingTarget.End, "extents.End should be equal to 2!");
            
            testingTarget.End = 5;
            Assert.AreEqual(5, testingTarget.End, "extents.End should be equal to 5!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsEnd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents Top")]
        [Property("SPEC", "Tizen.NUI.Extents.Top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsTop()
        {
            tlog.Debug(tag, $"ExtentsTop START");

            Extents testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(3, testingTarget.Top, "extents.Top should be equal to 3!");
            
            testingTarget.Top = 5;
            Assert.AreEqual(5, testingTarget.Top, "extents.Top should be equal to 5!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extents Bottom")]
        [Property("SPEC", "Tizen.NUI.Extents.Bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtentsBottom()
        {
            tlog.Debug(tag, $"ExtentsBottom START");

            Extents testingTarget = new Extents(1, 2, 3, 4);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Extents>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(4, testingTarget.Bottom, "extents.Bottom should be equal to 4!");
            
            testingTarget.Bottom = 5;
            Assert.AreEqual(5, testingTarget.Bottom, "extents.Bottom should be equal to 4!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ExtentsBottom END (OK)");
        }
    }
}
