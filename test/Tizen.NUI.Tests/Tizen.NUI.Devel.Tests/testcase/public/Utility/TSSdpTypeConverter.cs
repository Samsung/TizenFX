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
    [Description("public/Utility/SdpTypeConverter ")]
    public class PublicSdpTypeConverterTest
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
        [Description("SdpTypeConverter Instance.")]
        [Property("SPEC", "Tizen.NUI.SdpTypeConverter Instance C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SdpTypeConverterInstance()
        {
            tlog.Debug(tag, $"SdpTypeConverterInstance START");

            var testingTarget = SdpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SdpTypeConverter ");
            Assert.IsInstanceOf<SdpTypeConverter>(testingTarget, "Should be an instance of SdpTypeConverter  type.");

            tlog.Debug(tag, $"SdpTypeConverterInstance END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SdpTypeConverter ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.SdpTypeConverter ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SdpTypeConverterConvertScriptToPixel()
        {
            tlog.Debug(tag, $"SdpTypeConverterConvertScriptToPixel START");

            var testingTarget = SdpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SdpTypeConverter ");
            Assert.IsInstanceOf<SdpTypeConverter>(testingTarget, "Should be an instance of SdpTypeConverter  type.");

            var result = testingTarget.ConvertScriptToPixel("100sdp");
            tlog.Debug(tag, "ConvertScriptToPixel : " + result);

            tlog.Debug(tag, $"SdpTypeConverterConvertScriptToPixel END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SdpTypeConverter ConvertScriptToPixel with 'dp'.")]
        [Property("SPEC", "Tizen.NUI.SdpTypeConverter ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SdpTypeConverterConvertScriptToPixelWithDp()
        {
            tlog.Debug(tag, $"SdpTypeConverterConvertScriptToPixelWithDp START");

            var testingTarget = SdpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SdpTypeConverter ");
            Assert.IsInstanceOf<SdpTypeConverter>(testingTarget, "Should be an instance of SdpTypeConverter  type.");

            var result = testingTarget.ConvertScriptToPixel("100dp");
            tlog.Debug(tag, "ConvertScriptToPixelbranch : " + result);

            tlog.Debug(tag, $"SdpTypeConverterConvertScriptToPixelWithDp END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SdpTypeConverter ConvertToPixel.")]
        [Property("SPEC", "Tizen.NUI.SdpTypeConverter ConvertToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SdpTypeConverterConvertToPixel()
        {
            tlog.Debug(tag, $"SdpTypeConverterConvertToPixel START");

            var testingTarget = SdpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SdpTypeConverter ");
            Assert.IsInstanceOf<SdpTypeConverter>(testingTarget, "Should be an instance of SdpTypeConverter  type.");

            var result = testingTarget.ConvertToPixel(20.0f);
            tlog.Debug(tag, "ConvertToPixel : " + result);

            tlog.Debug(tag, $"SdpTypeConverterConvertToPixel END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SdpTypeConverter ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.SdpTypeConverter ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SdpTypeConverterConvertFromPixel()
        {
            tlog.Debug(tag, $"SdpTypeConverterConvertFromPixel START");

            var testingTarget = SdpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SdpTypeConverter ");
            Assert.IsInstanceOf<SdpTypeConverter >(testingTarget, "Should be an instance of SdpTypeConverter  type.");

            var result = testingTarget.ConvertFromPixel(30.0f);
            tlog.Debug(tag, "ConvertToPixel : " + result);

            tlog.Debug(tag, $"SdpTypeConverterConvertFromPixel END (OK)");
        }
	}
}