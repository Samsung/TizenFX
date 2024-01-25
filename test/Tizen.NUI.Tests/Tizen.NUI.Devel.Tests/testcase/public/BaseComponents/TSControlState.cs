using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ControlState")]
    public class PublicControlStateTest
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
        [Category("P2")]
        [Description("ControlState Create. Parameter is null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateWithNullString()
        {
            tlog.Debug(tag, $"ControlStateCreateWithNullString START");

            try
            {
                string str = null;
                ControlState.Create(str);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ControlStateCreateWithNullString END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ControlState Create. Parameter is empty.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateWithEmptyString()
        {
            tlog.Debug(tag, $"ControlStateCreateWithEmptyString START");

            try
            {
                string str = " ";
                ControlState.Create(str);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ControlStateCreateWithEmptyString END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ControlState Create. State is added.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateWithAddedState()
        {
            tlog.Debug(tag, $"ControlStateCreateWithAddedState START");

            var testingTarget = ControlState.Create("Focused");
            Assert.IsNotNull(testingTarget);
            Assert.AreEqual(ControlState.Focused, testingTarget, "Should be equal!");

            tlog.Debug(tag, $"ControlStateCreateWithAddedState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Create. StateList length is 0.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateStateListLengthEqualZero()
        {
            tlog.Debug(tag, $"ControlStateCreateStateListLengthEqualZero START");

            ControlState[] states = new ControlState[0];
            var testingTarget = ControlState.Create(states);
            Assert.IsNotNull(testingTarget);
            Assert.AreEqual("Normal", testingTarget.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateCreateStateListLengthEqualZero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Create. StateList length is 1.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateStateListLengthEqualOne()
        {
            tlog.Debug(tag, $"ControlStateCreateStateListLengthEqualOne START");

            ControlState[] states = new ControlState[1];
            states[0] = ControlState.Other;
            var testingTarget = ControlState.Create(states);
            Assert.IsNotNull(testingTarget);
            Assert.AreEqual("Other", testingTarget.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateCreateStateListLengthEqualOne END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Create. StateList length greater than 1.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateStateListLengthGreaterThanOne()
        {
            tlog.Debug(tag, $"ControlStateCreateStateListLengthGreaterThanOne START");

            ControlState[] states = new ControlState[5];
            states[0] = ControlState.Normal;
            states[1] = ControlState.Selected;
            states[2] = ControlState.Focused;
            states[3] = ControlState.Pressed;
            states[4] = ControlState.Disabled;
            var testingTarget = ControlState.Create(states);
            Assert.IsNotNull(testingTarget);
            Assert.AreEqual("Selected, Focused, Pressed, Disabled", testingTarget.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateCreateStateListLengthGreaterThanOne END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Create. StateList contain All.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateCreateStateListContainAll()
        {
            tlog.Debug(tag, $"ControlStateCreateStateListContainAll START");

            ControlState[] states = new ControlState[5];
            states[0] = ControlState.Normal;
            states[1] = ControlState.Selected;
            states[2] = ControlState.All;
            states[3] = ControlState.Pressed;
            states[4] = ControlState.Disabled;
            var testingTarget = ControlState.Create(states);
            Assert.IsNotNull(testingTarget);
            Assert.AreEqual("All", testingTarget.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateCreateStateListContainAll END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Contains.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateContains()
        {
            tlog.Debug(tag, $"ControlStateContains START");

            ControlState[] states = new ControlState[5];
            states[0] = ControlState.Normal;
            states[1] = ControlState.Selected;
            states[2] = ControlState.Focused;
            states[3] = ControlState.Pressed;
            states[4] = ControlState.Disabled;
            var testingTarget = ControlState.Create(states);

            Assert.AreEqual(false, testingTarget.Contains(ControlState.All), "Should be equal!");
            Assert.AreEqual(true, testingTarget.Contains(ControlState.Selected), "Should be equal!");

            tlog.Debug(tag, $"ControlStateContains END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState Contains. IsCombined is false.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateContainsWithFalseIsCombined()
        {
            tlog.Debug(tag, $"ControlStateContainsWithFalseIsCombined START");

            ControlState[] states = new ControlState[1];
            states[0] = ControlState.Normal;
            var testingTarget = ControlState.Create(states);

            Assert.AreEqual(true, testingTarget.Contains(ControlState.Normal), "Should be equal!");
            
            tlog.Debug(tag, $"ControlStateContainsWithFalseIsCombined END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ControlState Contains. State is null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateContainsWithNullState()
        {
            tlog.Debug(tag, $"ControlStateContainsWithNullState START");

            ControlState state = ControlState.Create("Focused");

            try
            {
                state.Contains(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ControlStateContainsWithNullState END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ControlState ==. Both null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.== M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateEquivalentWithBothNullVaule()
        {
            tlog.Debug(tag, $"ControlStateEquivalentWithBothNullVaule START");

            Assert.True(null == null);

            tlog.Debug(tag, $"ControlStateEquivalentWithBothNullVaule END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ControlState ==. Right null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.== M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateEquivalentWithOneNullValue()
        {
            tlog.Debug(tag, $"ControlStateEquivalentWithOneNullValue START");

            Assert.False(null == ControlState.Focused);
            Assert.True(null != ControlState.Focused);

            tlog.Debug(tag, $"ControlStateEquivalentWithOneNullValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState subtraction.")]
        [Property("SPEC", "Tizen.NUI.ControlState.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateSubtraction()
        {
            tlog.Debug(tag, $"ControlStateSubtraction START");

            var result = ControlState.Focused - ControlState.Focused;
            Assert.AreEqual("Normal", result.ToString(), "Should be equal!");

            result = ControlState.Focused - ControlState.Pressed;
            Assert.AreEqual("Focused", result.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlState subtraction. IsCombined")]
        [Property("SPEC", "Tizen.NUI.ControlState.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateSubtractionWithTrueIsCombined()
        {
            tlog.Debug(tag, $"ControlStateSubtractionWithTrueIsCombined START");

            ControlState[] states1 = new ControlState[2];
            states1[0] = ControlState.Selected;
            states1[1] = ControlState.Focused;
            var testingTarget1 = ControlState.Create(states1);

            ControlState[] states2 = new ControlState[2];
            states2[0] = ControlState.Pressed;
            states2[1] = ControlState.Focused;
            var testingTarget2 = ControlState.Create(states2);

            var result = testingTarget1 - testingTarget2;
            Assert.AreEqual("Selected", result.ToString(), "Should be equal!");

            ControlState[] states3 = new ControlState[2];
            states3[0] = ControlState.Selected;
            states3[1] = ControlState.Focused;
            var testingTarget3 = ControlState.Create(states3);

            ControlState[] states4 = new ControlState[2];
            states4[0] = ControlState.Pressed;
            states4[1] = ControlState.Disabled;
            var testingTarget4 = ControlState.Create(states4);

            result = testingTarget3 - testingTarget4;
            Assert.AreEqual("Selected, Focused", result.ToString(), "Should be equal!");

            tlog.Debug(tag, $"ControlStateSubtractionWithTrueIsCombined END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ControlState subtraction. lhs is null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateSubtractionWithNullFirstParameter()
        {
            tlog.Debug(tag, $"ControlStateSubtractionWithNullFirstParameter START");

            try
            {
                var result = null - ControlState.Normal;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ControlStateSubtractionWithNullFirstParameter END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ControlState subtraction. rhs is null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStateSubtractionWithNullSecondParameter()
        {
            tlog.Debug(tag, $"ControlStateSubtractionWithNullSecondParameter START");

            try
            {
                var result = ControlState.Normal - null;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ControlStateSubtractionWithNullSecondParameter END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }
    }
}
