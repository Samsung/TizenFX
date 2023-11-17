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
    [Description("public/Utility/SpTypeConverter ")]
    public class PublicSpTypeConverterTest
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
        [Description("SpTypeConverter Instance.")]
        [Property("SPEC", "Tizen.NUI.SpTypeConverter Instance C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SpTypeConverterInstance()
        {
            tlog.Debug(tag, $"SpTypeConverterInstance START");

            var testingTarget = SpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SpTypeConverter ");
            Assert.IsInstanceOf<SpTypeConverter>(testingTarget, "Should be an instance of SpTypeConverter  type.");

            tlog.Debug(tag, $"SpTypeConverterInstance END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SpTypeConverter ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.SpTypeConverter ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SpTypeConverterConvertScriptToPixel()
        {
            tlog.Debug(tag, $"SpTypeConverterConvertScriptToPixel START");

            var testingTarget = SpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SpTypeConverter ");
            Assert.IsInstanceOf<SpTypeConverter>(testingTarget, "Should be an instance of SpTypeConverter  type.");
            
            var result = testingTarget.ConvertScriptToPixel("100sp");
            tlog.Debug(tag, "ConvertScriptToPixel : " + result);

            tlog.Debug(tag, $"SpTypeConverterConvertScriptToPixel END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("SpTypeConverter ConvertScriptToPixel with 'dp'.")]
        [Property("SPEC", "Tizen.NUI.SpTypeConverter ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SpTypeConverterConvertScriptToPixelWithDp()
        {
            tlog.Debug(tag, $"SpTypeConverterConvertScriptToPixelWithDp START");

            var testingTarget = SpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SpTypeConverter ");
            Assert.IsInstanceOf<SpTypeConverter>(testingTarget, "Should be an instance of SpTypeConverter  type.");
            
            var result = testingTarget.ConvertScriptToPixel("100dp");
            tlog.Debug(tag, "ConvertScriptToPixelbranch : " + result);

            tlog.Debug(tag, $"SpTypeConverterConvertScriptToPixelWithDp END (OK)");
        }

		[Test]
        [Category("P1")]
        [Description("SpTypeConverter ConvertToPixel.")]
        [Property("SPEC", "Tizen.NUI.SpTypeConverter ConvertToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SpTypeConverterConvertToPixel()
        {
            tlog.Debug(tag, $"SpTypeConverterConvertToPixel START");

            var testingTarget = SpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SpTypeConverter ");
            Assert.IsInstanceOf<SpTypeConverter>(testingTarget, "Should be an instance of SpTypeConverter  type.");
            
            var result = testingTarget.ConvertToPixel(20.0f);
            tlog.Debug(tag, "ConvertToPixel : " + result);

            tlog.Debug(tag, $"SpTypeConverterConvertToPixel END (OK)");
        }		
		
		[Test]
        [Category("P1")]
        [Description("SpTypeConverter ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.SpTypeConverter ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SpTypeConverterConvertFromPixel()
        {
            tlog.Debug(tag, $"SpTypeConverterConvertFromPixel START");

            var testingTarget = SpTypeConverter.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object SpTypeConverter ");
            Assert.IsInstanceOf<SpTypeConverter >(testingTarget, "Should be an instance of SpTypeConverter  type.");
            
            var result = testingTarget.ConvertFromPixel(30.0f);
            tlog.Debug(tag, "ConvertToPixel : " + result);

            tlog.Debug(tag, $"SpTypeConverterConvertFromPixel END (OK)");
        }		
	}
}