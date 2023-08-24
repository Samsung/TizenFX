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

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions PtToSp. with float")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.PtToSp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionswithfloat()
        {
            try
			{
			    float temp8 = GraphicsTypeExtensions.PtToSp(7.2f);
                tlog.Debug(tag, "PtToSp : " + temp8);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
			    float temp9 = GraphicsTypeExtensions.SpToPt(7.2f);
                tlog.Debug(tag, "SpToPt : " + temp9);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
			    float temp10 = GraphicsTypeExtensions.PtToDp(7.2f);
                tlog.Debug(tag, "PtToDp : " + temp10);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
			    float temp11 = GraphicsTypeExtensions.DpToPt(7.2f);
                tlog.Debug(tag, "DpToPt : " + temp11);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
			    float temp12 = GraphicsTypeExtensions.PtToPx(7.2f);
                tlog.Debug(tag, "PtToPx : " + temp12);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }  

            try
			{
			    float temp13 = GraphicsTypeExtensions.PxToPt(7.2f);
                tlog.Debug(tag, "PxToPt : " + temp13);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeExtensionswithfloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions PxToPt. with Extents ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.PxToPt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithExtents()
        {
            try
			{
                var sp = new Extents(1, 2, 3, 4);
			    var temp14 = GraphicsTypeExtensions.SpToPx(sp);
                tlog.Debug(tag, "SpToPx : " + temp14);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
                var dp = new Extents(1, 2, 3, 4);
			    var temp15 = GraphicsTypeExtensions.DpToPx(dp);
                tlog.Debug(tag, "DpToPx : " + temp15);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
                var pixel = new Extents(1, 2, 3, 4);
			    var temp16 = GraphicsTypeExtensions.PxToSp(pixel);
                tlog.Debug(tag, "PxToSp : " + temp16);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            try
			{
                var pixel = new Extents(1, 2, 3, 4);
			    var temp17 = GraphicsTypeExtensions.PxToDp(pixel);
                tlog.Debug(tag, "PxToDp : " + temp17);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithExtents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions PxToPt. with Rectangle ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.PxToPt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithRectangle()
        {
            try
			{
                var sp = new Rectangle(5, 6, 100, 200);
			    var rectangle1 = GraphicsTypeExtensions.SpToPx(sp);
                tlog.Debug(tag, "SpToPx : " + rectangle1);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }            

            try
			{
                var dp = new Rectangle(5, 6, 100, 200);
			    var rectangle2 = GraphicsTypeExtensions.DpToPx(dp);
                tlog.Debug(tag, "DpToPx : " + rectangle2);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
                var pixel = new Rectangle(5, 6, 100, 200);
			    var rectangle3 = GraphicsTypeExtensions.PxToSp(pixel);
                tlog.Debug(tag, "PxToSp : " + rectangle3);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }  

            try
			{
                var pixel = new Rectangle(5, 6, 100, 200);
			    var rectangle4 = GraphicsTypeExtensions.PxToDp(pixel);
                tlog.Debug(tag, "PxToDp : " + rectangle4);
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithRectangle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions SpToPx. with Position2D ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.PxToPt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithPosition2D()
        {
            var sp = new Position2D(2, 3);

            try
			{
			    var position2D1 = GraphicsTypeExtensions.SpToPx(sp);
                tlog.Debug(tag, "SpToPx : Position2D SpToPx" );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var position2D2 = GraphicsTypeExtensions.DpToPx(sp);
                tlog.Debug(tag, "DpToPx : Position2D  DpToPx");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var position2D3 = GraphicsTypeExtensions.PxToSp(sp);
                tlog.Debug(tag, "PxToSp : Position2D PxToSp");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var position2D4 = GraphicsTypeExtensions.PxToDp(sp);
                tlog.Debug(tag, "PxToDp : Position2D PxToDp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            sp.Dispose();
            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions SpToPx. with Position ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.SpToPx M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithPosition()
        {
            var sp = new Position(5.0f, 5.0f, 0.5f);
            try
			{
			    var position1 = GraphicsTypeExtensions.SpToPx(sp);
                tlog.Debug(tag, "SpToPx : Position SpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var position2 = GraphicsTypeExtensions.DpToPx(sp);
                tlog.Debug(tag, "DpToPx : Position DpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }     

            try
			{
			    var position3 = GraphicsTypeExtensions.PxToSp(sp);
                tlog.Debug(tag, "PxToSp : Position PxToSp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }      

            try
			{
			    var position4 = GraphicsTypeExtensions.PxToDp(sp);
                tlog.Debug(tag, "PxToDp : Position PxToSp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            sp.Dispose();                          
            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions SpToPx. with Size2D ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.SpToPx M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithSize2D()
        {
            var dp = new Size2D(100, 100);

            try
			{
			    var size2D1 = GraphicsTypeExtensions.SpToPx(dp);
                tlog.Debug(tag, "SpToPx : Size2D SpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }    

            try
			{
			    var size2D1 = GraphicsTypeExtensions.DpToPx(dp);
                tlog.Debug(tag, "DpToPx : Size2D DpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }   

            try
			{
			    var size2D1 = GraphicsTypeExtensions.PxToSp(dp);
                tlog.Debug(tag, "PxToSp : Size2D PxToSp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var size2D1 = GraphicsTypeExtensions.PxToDp(dp);
                tlog.Debug(tag, "PxToDp : Size2D PxToDp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            dp.Dispose();                                       
            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithSize2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GraphicsTypeExtensions SpToPx. with Size ")]
        [Property("SPEC", "Tizen.NUI.GraphicsTypeExtensions.SpToPx M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GraphicsTypeExtensionsPxToPtwithSize()
        {
            var sp = new Size(100.0f, 100.0f, 100.0f);

            try
			{
			    var size1 = GraphicsTypeExtensions.SpToPx(sp);
                tlog.Debug(tag, "SpToPx : Size SpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }              

            try
			{
			    var size2 = GraphicsTypeExtensions.DpToPx(sp);
                tlog.Debug(tag, "DpToPx : Size DpToPx " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            } 

            try
			{
			    var size3 = GraphicsTypeExtensions.PxToSp(sp);
                tlog.Debug(tag, "PxToSp : Size PxToSp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }  

            try
			{
			    var size4 = GraphicsTypeExtensions.PxToDp(sp);
                tlog.Debug(tag, "PxToDp : Size PxToDp " );
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
            
            sp.Dispose();                                       
            tlog.Debug(tag, $"GraphicsTypeExtensionsPxToPtwithSize END (OK)");            
        }
	}
}
