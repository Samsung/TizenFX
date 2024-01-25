using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyCondition")]
    class PublicPropertyConditionTest
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
        [Description("PropertyCondition constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.PropertyCondition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionConstructor()
        {
            tlog.Debug(tag, $"PropertyConditionConstructor START");

            var testingTarget = new Tizen.NUI.PropertyCondition();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition GetArgumentCount")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GetArgumentCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionGetArgumentCount()
        {
            tlog.Debug(tag, $"PropertyConditionGetArgumentCount START");

            var testingTarget = PropertyCondition.LessThan(100);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(1, testingTarget.GetArgumentCount(), $"Should be 1");
            Assert.AreEqual(100, testingTarget.GetArgument(0), $"Should be 100");
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionGetArgumentCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition GetArgument")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GetArgument M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionGetArgument()
        {
            tlog.Debug(tag, $"PropertyConditionGetArgument START");

            var testingTarget = PropertyCondition.GreaterThan(100);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(1, testingTarget.GetArgumentCount(), $"Should be 1");
            Assert.AreEqual(100, testingTarget.GetArgument(0), $"Should be 100");
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionGetArgument END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition LessThan")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.LessThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionLessThan()
        {
            tlog.Debug(tag, $"PropertyConditionLessThan START");
			
            var testingTarget = PropertyCondition.LessThan(50);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(1, testingTarget.GetArgumentCount(), $"Should be 1");
            Assert.AreEqual(50, testingTarget.GetArgument(0), $"Should be 50");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionLessThan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition GreaterThan")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.GreaterThan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionGreaterThan()
        {
            tlog.Debug(tag, $"PropertyConditionGreaterThan START");

            var testingTarget = PropertyCondition.GreaterThan(50);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(1, testingTarget.GetArgumentCount(), $"Should be 1");
            Assert.AreEqual(50, testingTarget.GetArgument(0), $"Should be 50");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionGreaterThan END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("PropertyCondition Inside")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Inside M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionInside()
        {
            tlog.Debug(tag, $"PropertyConditionInside START");

            var testingTarget = PropertyCondition.Inside(50, 100);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionInside END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition Outside")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Outside M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionOutside()
        {
            tlog.Debug(tag, $"PropertyConditionOutside START");
            
            var testingTarget = PropertyCondition.Outside(50, 100);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(2, testingTarget.GetArgumentCount(), $"Should be 2");
            Assert.AreEqual(50, testingTarget.GetArgument(0), $"Should be 50");
            Assert.AreEqual(100, testingTarget.GetArgument(1), $"Should be 100");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionOutside END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition Step")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Step M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionStep()
        {
            tlog.Debug(tag, $"PropertyConditionStep START");

            var testingTarget = PropertyCondition.Step(50);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(3, testingTarget.GetArgumentCount(), $"Should be 3");
            Assert.AreEqual(0, testingTarget.GetArgument(0), $"Should be 0");
            Assert.AreEqual(0.02f, testingTarget.GetArgument(1), $"Should be 0.02");
            Assert.AreEqual(0, testingTarget.GetArgument(2), $"Should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionStep END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition Step. With two strings parameters")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Step M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionStepWithTwoStringParameters()
        {
            tlog.Debug(tag, $"PropertyConditionStepWithTwoStringParameters START");

            var testingTarget = PropertyCondition.Step(50, 100);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(3, testingTarget.GetArgumentCount(), $"Should be 3");
            Assert.AreEqual(100, testingTarget.GetArgument(0), $"Should be 100");
            Assert.AreEqual(0.02f, testingTarget.GetArgument(1), $"Should be 0.02");
            Assert.AreEqual(0, testingTarget.GetArgument(2), $"Should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyConditionStepWithTwoStringParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyCondition Dispose")]
        [Property("SPEC", "Tizen.NUI.PropertyCondition.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyConditionDispose()
        {
            tlog.Debug(tag, $"PropertyConditionDispose START");

            PropertyCondition testingTarget = new PropertyCondition();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyCondition>(testingTarget, "should be an instance of testing target class!");
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PropertyConditionDispose END (OK)");
        }
    }
}
