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
    [Description("public/Utility/PointTypeConverter  ")]
    public class PublicPointTypeConverterTest
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
        [Description("PointTypeConverter Instance.")]
        [Property("SPEC", "Tizen.NUI.PointTypeConverter Instance C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PointTypeConverterInstance()
        {
            tlog.Debug(tag, $"PointTypeConverter Instance START");

            var testingTarget = PointTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PointTypeConverter  ");
            Assert.IsInstanceOf<PointTypeConverter>(testingTarget, "Should be an instance of PointTypeConverter type.");

            tlog.Debug(tag, $"PointTypeConverterInstance END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("PointTypeConverter  ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.PointTypeConverter  ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PointTypeConverterConvertScriptToPixel()
        {
            tlog.Debug(tag, $"PointTypeConverterConvertScriptToPixel START");

            var testingTarget = PointTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PointTypeConverter ");
            Assert.IsInstanceOf<PointTypeConverter >(testingTarget, "Should be an instance of PointTypeConverter  type.");

            var result = testingTarget.ConvertScriptToPixel("100pt");
            tlog.Debug(tag, "ConvertScriptToPixel(pt)" + result);

            result = testingTarget.ConvertScriptToPixel("105px");
            tlog.Debug(tag, "ConvertScriptToPixel(px)" + result);

            tlog.Debug(tag, $"PointTypeConverterConvertScriptToPixel END (OK)");
        }


		[Test]
        [Category("P1")]
        [Description("PointTypeConverter ConvertToPixel.")]
        [Property("SPEC", "Tizen.NUI.PointTypeConverter ConvertToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PointTypeConverterConvertToPixel()
        {
            tlog.Debug(tag, $"DpTypeConverterConvertToPixel START");

            var testingTarget = PointTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PointTypeConverter ");
            Assert.IsInstanceOf<PointTypeConverter >(testingTarget, "Should be an instance of PointTypeConverter  type.");

            var result = testingTarget.ConvertToPixel(20.0f);
            tlog.Debug(tag, "ConvertToPixel : " + result);

            tlog.Debug(tag, $"PointTypeConverterConvertToPixel END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("PointTypeConverter ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.PointTypeConverter ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PointTypeConverterConvertFromPixel()
        {
            tlog.Debug(tag, $"PointTypeConverterConvertFromPixel START");

            var testingTarget = PointTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PointTypeConverter ");
            Assert.IsInstanceOf<PointTypeConverter >(testingTarget, "Should be an instance of PointTypeConverter  type.");

            var result0 = testingTarget.ConvertFromPixel(30.0f);
            tlog.Debug(tag, "ConvertFromPixel : " + result0);

            var result1 = testingTarget.ConvertDpToPoint(10.0f);
            tlog.Debug(tag, "ConvertDpToPoint : " + result1);

            var result2 = testingTarget.ConvertPointToDp(20.0f);
            tlog.Debug(tag, "ConvertPointToDp : " + result2);

            var result3 = testingTarget.ConvertSdpToPoint(10.0f);
            tlog.Debug(tag, "ConvertSdpToPoint : " + result3);

            var result4 = testingTarget.ConvertPointToSdp(20.0f);
            tlog.Debug(tag, "ConvertPointToSdp : " + result4);

            tlog.Debug(tag, $"PointTypeConverterConvertFromPixel END (OK)");
        }
	}
}