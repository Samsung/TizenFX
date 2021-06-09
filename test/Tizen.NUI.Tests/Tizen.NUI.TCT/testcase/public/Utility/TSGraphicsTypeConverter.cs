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
    [Description("public/Utility/GraphicsTypeConverter")]
    public class PublicGraphicsTypeConverterTest
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
        [Description("GraphicsTypeConverter ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeConverter.ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeConverterConvertScriptToPixel()
        {
            tlog.Debug(tag, $"GraphicsTypeConverterConvertScriptToPixel START");

            var testingTarget = new GraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object GraphicsTypeConverter");
            Assert.IsInstanceOf<GraphicsTypeConverter>(testingTarget, "Should be an instance of GraphicsTypeConverter type.");

            var result = testingTarget.ConvertScriptToPixel("160dp");
            Assert.IsNotNull(result);

            result = testingTarget.ConvertScriptToPixel("160px");
            Assert.AreEqual(160.0f, result, "Should be equal!");

            result = testingTarget.ConvertScriptToPixel("160.0f");
            Assert.AreEqual(0.0f, result, "Should be equal!");

            tlog.Debug(tag, $"GraphicsTypeConverterConvertScriptToPixel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeConverter ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeConverter.ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeConverterConvertFromPixel()
        {
            tlog.Debug(tag, $"GraphicsTypeConverterConvertFromPixel START");

            var testingTarget = new GraphicsTypeConverter();
            Assert.IsNotNull(testingTarget, "Can't create success object GraphicsTypeConverter");
            Assert.IsInstanceOf<GraphicsTypeConverter>(testingTarget, "Should be an instance of GraphicsTypeConverter type.");

            var result = testingTarget.ConvertFromPixel(160.0f);
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"GraphicsTypeConverterConvertFromPixel END (OK)");
        }
    }
}
