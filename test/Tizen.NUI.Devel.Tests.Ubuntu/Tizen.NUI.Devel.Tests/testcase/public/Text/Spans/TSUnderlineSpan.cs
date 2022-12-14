using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text/Spans")]
    public class PublicUnderlineSpanTest
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
        [Description("UnderlineSpan Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanCreate()
        {
            tlog.Debug(tag, $"UnderlineSpanCreate START");

            var testingTarget = UnderlineSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"UnderlineSpanCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan CreateSolidLine.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.CreateSolidLine M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanCreateSolidLine()
        {
            tlog.Debug(tag, $"UnderlineSpanCreateSolidLine START");

            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"UnderlineSpanCreateSolidLine END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan CreateDoubleLine.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.CreateDoubleLine M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanCreateDoubleLine()
        {
            tlog.Debug(tag, $"UnderlineSpanCreateDoubleLine START");

            var testingTarget = UnderlineSpan.CreateDoubleLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"UnderlineSpanCreateDoubleLine END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan CreateDashedLine.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.CreateDashedLine M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanCreateDashedLine()
        {
            tlog.Debug(tag, $"UnderlineSpanCreateDashedLine START");

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"UnderlineSpanCreateDashedLine END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Type.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanType()
        {
            tlog.Debug(tag, $"UnderlineSpanType START");


            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                Assert.AreEqual( UnderlineType.Solid, testingTarget.Type, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Color.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanColor()
        {
            tlog.Debug(tag, $"UnderlineSpanColor START");

            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.Color;
                Assert.AreEqual(true, TestUtils.CheckColor(Color.Green, result), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Height.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHeight()
        {
            tlog.Debug(tag, $"UnderlineSpanHeight START");

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                Assert.AreEqual( 5.0f, testingTarget.Height, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan DashGap.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.DashGap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanDashGap()
        {
            tlog.Debug(tag, $"UnderlineSpanDashGap START");

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                Assert.AreEqual( 4.0f, testingTarget.DashGap, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanDashGap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan DashWidth.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.DashWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanDashWidth()
        {
            tlog.Debug(tag, $"UnderlineSpanDashWidth START");

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                Assert.AreEqual( 3.0f, testingTarget.DashWidth, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanDashWidth END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("UnderlineSpan HasType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.HasType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHasType()
        {
            tlog.Debug(tag, $"UnderlineSpanHasType START");

            var expected = true;

            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.HasType;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHasType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan HasColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.HasColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHasColor()
        {
            tlog.Debug(tag, $"UnderlineSpanHasColor START");

            var expected = true;

            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.HasColor;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHasColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan HasHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.HasHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHasHeight()
        {
            tlog.Debug(tag, $"UnderlineSpanHasHeight START");

            var expected = true;

            var testingTarget = UnderlineSpan.CreateSolidLine(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.HasHeight;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHasHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan HasDashGap.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.HasDashGap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHasDashGap()
        {
            tlog.Debug(tag, $"UnderlineSpanHasDashGap START");

            var expected = true;

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.HasDashGap;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHasDashGap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan HasDashWidth.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.HasDashWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanHasDashWidth()
        {
            tlog.Debug(tag, $"UnderlineSpanHasDashWidth START");

            var expected = true;

            var testingTarget = UnderlineSpan.CreateDashedLine(Color.Green, 5.0f, 4.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.HasDashWidth;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanHasDashWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanDispose()
        {
            tlog.Debug(tag, $"UnderlineSpanDispose START");

            var testingTarget = UnderlineSpan.Create( );
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"UnderlineSpanDispose END (OK)");
        }
    }
}