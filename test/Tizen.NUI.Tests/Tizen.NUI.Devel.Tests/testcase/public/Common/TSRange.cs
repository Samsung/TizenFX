using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Range")]
    public class PublicRangeTest
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
        [Description("Range Create.")]
        [Property("SPEC", "Tizen.NUI.Range.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void RangeCreate()
        {
            tlog.Debug(tag, $"RangeCreate START");

            var testingTarget = Range.Create(4,5);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Range>(testingTarget, "Should return Range instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"RangeCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Range RangeStartIndex.")]
        [Property("SPEC", "Tizen.NUI.Range.RangeStartIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void RangeStartIndex()
        {
            tlog.Debug(tag, $"RangeStartIndex START");

            uint expected = 10;

            var testingTarget = Range.Create(10,27);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Range>(testingTarget, "Should return Range instance.");

            try
            {
                var result = testingTarget.StartIndex;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RangeStartIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Range RangeEndIndex.")]
        [Property("SPEC", "Tizen.NUI.Range.RangeEndIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void RangeEndIndex()
        {
            tlog.Debug(tag, $"RangeEndIndex START");

            uint expected = 27;

            var testingTarget = Range.Create(10,27);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Range>(testingTarget, "Should return Range instance.");

            try
            {
                var result = testingTarget.EndIndex;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RangeEndIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Range RangeNumberOfIndices.")]
        [Property("SPEC", "Tizen.NUI.Range.RangeNumberOfIndices A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void RangeNumberOfIndices()
        {
            tlog.Debug(tag, $"RangeNumberOfIndices START");

            uint expected = 18;

            var testingTarget = Range.Create(10,27);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Range>(testingTarget, "Should return Range instance.");

            try
            {
                var result = testingTarget.NumberOfIndices;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RangeNumberOfIndices END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Range Dispose.")]
        [Property("SPEC", "Tizen.NUI.Range.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void RangeDispose()
        {
            tlog.Debug(tag, $"RangeDispose START");

            var testingTarget = Range.Create(10,27);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Range>(testingTarget, "Should return Range instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RangeDispose END (OK)");
        }
    }
}