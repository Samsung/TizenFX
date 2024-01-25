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
    [Description("public/Utility/DpTypeConverter  ")]
    public class PublicDpTypeConverter 
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
        [Description("DpTypeConverter  ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.DpTypeConverter  ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DpTypeConverterConvertScriptToPixel()
        {
            tlog.Debug(tag, $"DpTypeConverterConvertScriptToPixel START");

            try
			{
                var testingTarget = DpTypeConverter.Instance;
                Assert.IsNotNull(testingTarget, "Can't create success object DpTypeConverter ");
                Assert.IsInstanceOf<DpTypeConverter>(testingTarget, "Should be an instance of DpTypeConverter type.");
            
                var result = testingTarget.ConvertScriptToPixel("100dp");
                tlog.Debug(tag, "ConvertScriptToPixel(dp) : " + result);

                result = testingTarget.ConvertScriptToPixel("100px");
                tlog.Debug(tag, "ConvertScriptToPixel(px) : " + result);
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DpTypeConverterConvertScriptToPixel END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("DpTypeConverter ConvertToPixel.")]
        [Property("SPEC", "Tizen.NUI.DpTypeConverter ConvertToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DpTypeConverterConvertToPixel()
        {
            tlog.Debug(tag, $"DpTypeConverterConvertToPixel START");

            try
            {
                var testingTarget = DpTypeConverter.Instance;
                Assert.IsNotNull(testingTarget, "Can't create success object DpTypeConverter ");
                Assert.IsInstanceOf<DpTypeConverter>(testingTarget, "Should be an instance of DpTypeConverter type.");

                var result = testingTarget.ConvertToPixel(20.0f);
                tlog.Debug(tag, "ConvertToPixel : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DpTypeConverterConvertToPixel END (OK)");
        }		
		
		[Test]
        [Category("P1")]
        [Description("DpTypeConverter ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.DpTypeConverter ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DpTypeConverterConvertFromPixel()
        {
            tlog.Debug(tag, $"DpTypeConverterConvertFromPixel START");

            try
            {
                var testingTarget = DpTypeConverter.Instance;
                Assert.IsNotNull(testingTarget, "Can't create success object DpTypeConverter ");
                Assert.IsInstanceOf<DpTypeConverter>(testingTarget, "Should be an instance of DpTypeConverter type.");

                var result = testingTarget.ConvertFromPixel(30.0f);
                tlog.Debug(tag, "ConvertFromPixel : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DpTypeConverterConvertFromPixel END (OK)");
        }	
	}
}