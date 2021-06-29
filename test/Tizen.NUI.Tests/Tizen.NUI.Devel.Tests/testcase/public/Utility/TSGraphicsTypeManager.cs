﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/GraphicsTypeManager")]
    public class PublicGraphicsTypeManagerTest
    {
        private const string tag = "NUITEST";

        internal class MyTypeConverter : Tizen.NUI.Binding.TypeConverter
        {
            public MyTypeConverter() : base()
            { }
        }

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
        [Description("GraphicsTypeManager SetTypeConverter.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeManager.SetTypeConverter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeManagerSetTypeConverter()
        {
            tlog.Debug(tag, $"GraphicsTypeManagerSetTypeConverter START");

            try
            {
                GraphicsTypeManager.Instance.SetTypeConverter(new GraphicsTypeConverter());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeManagerSetTypeConverter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeManager ConvertScriptToPixel.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeManager.ConvertScriptToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeManagerConvertScriptToPixel()
        {
            tlog.Debug(tag, $"GraphicsTypeManagerConvertScriptToPixel START");

            try
            {
                GraphicsTypeManager.Instance.ConvertScriptToPixel("160px");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeManagerConvertScriptToPixel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeManager ConvertToPixel.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeManager.ConvertToPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeManagerConvertToPixel()
        {
            tlog.Debug(tag, $"GraphicsTypeManagerConvertToPixel START");

            try
            {
                GraphicsTypeManager.Instance.ConvertToPixel(160.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeManagerConvertToPixel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeManager ConvertFromPixel.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeManager.ConvertFromPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeManagerConvertFromPixel()
        {
            tlog.Debug(tag, $"GraphicsTypeManagerConvertFromPixel START");

            try
            {
                GraphicsTypeManager.Instance.ConvertFromPixel(160.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeManagerConvertFromPixel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeManager RegisterCustomConverterForDynamicResourceBinding.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeManager.RegisterCustomConverterForDynamicResourceBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeManagerRegisterCustomConverterForDynamicResourceBinding()
        {
            tlog.Debug(tag, $"GraphicsTypeManagerRegisterCustomConverterForDynamicResourceBinding START");

            string str = "GraphicsTypeManager";
            Tizen.NUI.Binding.TypeConverter converter = new MyTypeConverter();

            try
            {
                GraphicsTypeManager.Instance.RegisterCustomConverterForDynamicResourceBinding(str.GetType(), converter);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeManagerRegisterCustomConverterForDynamicResourceBinding END (OK)");
        }
    }
}
