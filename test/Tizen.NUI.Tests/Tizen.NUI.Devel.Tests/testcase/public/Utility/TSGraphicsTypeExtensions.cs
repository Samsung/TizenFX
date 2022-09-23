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
    [Description("public/Utility/GraphicsTypeExtensions")]
    public class PublicGraphicsTypeExtensionsTest
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
        [Description("GraphicsTypeExtensions DpToPx.")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.DpToPx M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsDpToPx()
        {
			try
			{
			    float temp0 = GraphicsTypeExtensions.DpToPx(10.0f);
                tlog.Debug(tag, "DpToPx : " + temp0);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    float temp1 = GraphicsTypeExtensions.SpToPx(20.0f);
                tlog.Debug(tag, "SpToPx : " + temp1);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    float temp2 = GraphicsTypeExtensions.PxToDp(20.0f);
                tlog.Debug(tag, "PxToPx : " + temp2);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    float temp3 = GraphicsTypeExtensions.PxToSp(10.0f);
                tlog.Debug(tag, "PxToSp : " + temp3);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    int temp4 = GraphicsTypeExtensions.DpToPx(20);
                tlog.Debug(tag, "DpToPx : " + temp4);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    int temp5 = GraphicsTypeExtensions.SpToPx(30);
                tlog.Debug(tag, "SpToPx : " + temp5);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    int temp6 = GraphicsTypeExtensions.PxToDp(10);
                tlog.Debug(tag, "PxToDp : " + temp6);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			
			try
			{
			    int temp7 = GraphicsTypeExtensions.PxToSp(20);
                tlog.Debug(tag, "PxToSp : " + temp7);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
			  
            tlog.Debug(tag, $"GraphicsTypeExtensionsDpToPx END (OK)");
        }
	}
}
