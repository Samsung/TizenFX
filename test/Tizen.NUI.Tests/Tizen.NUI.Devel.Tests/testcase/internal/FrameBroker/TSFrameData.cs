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
    [Description("internal/FrameBroker/FrameData")]
    public class InternalFrameDataTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("FrameData constructor.")]
        [Property("SPEC", "Tizen.NUI.FrameData.FrameData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataConstructor()
        {
            tlog.Debug(tag, $"FrameDataConstructor START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));
                
                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");
            }

            tlog.Debug(tag, $"FrameDataConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData DirectionForward.")]
        [Property("SPEC", "Tizen.NUI.FrameData.DirectionForward A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataDirectionForward()
        {
            tlog.Debug(tag, $"FrameDataDirectionForward START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));
                
                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.DirectionForward;
                    tlog.Debug(tag, "DirectionForward : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }                  
            }

            tlog.Debug(tag, $"FrameDataDirectionForward END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData TbmSurface.")]
        [Property("SPEC", "Tizen.NUI.FrameData.TbmSurface A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataTbmSurface()
        {
            tlog.Debug(tag, $"FrameDataTbmSurface START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.TbmSurface;
                    tlog.Debug(tag, "TbmSurface : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataTbmSurface END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData Fd.")]
        [Property("SPEC", "Tizen.NUI.FrameData.Fd A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataFd()
        {
            tlog.Debug(tag, $"FrameDataFd START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.Fd;
                    tlog.Debug(tag, "Fd : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataFd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData Size.")]
        [Property("SPEC", "Tizen.NUI.FrameData.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataSize()
        {
            tlog.Debug(tag, $"FrameDataSize START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.Size;
                    tlog.Debug(tag, "Size : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData FilePath.")]
        [Property("SPEC", "Tizen.NUI.FrameData.FilePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataFilePath()
        {
            tlog.Debug(tag, $"FrameDataFilePath START");

            using (ImageView image = new ImageView())
            {
                image.ResourceUrl = path;

                var testingTarget = new FrameData(image.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.FilePath;
                    tlog.Debug(tag, "FilePath : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataFilePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData FileGroup.")]
        [Property("SPEC", "Tizen.NUI.FrameData.FileGroup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataFileGroup()
        {
            tlog.Debug(tag, $"FrameDataFileGroup START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.FileGroup;
                    tlog.Debug(tag, "FileGroup : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataFileGroup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData Type.")]
        [Property("SPEC", "Tizen.NUI.FrameData.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataType()
        {
            tlog.Debug(tag, $"FrameDataType START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.Type;
                    tlog.Debug(tag, "Type : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData PositionX.")]
        [Property("SPEC", "Tizen.NUI.FrameData.PositionX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataPositionX()
        {
            tlog.Debug(tag, $"FrameDataPositionX START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.PositionX;
                    tlog.Debug(tag, "PositionX : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataPositionX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameData PositionY.")]
        [Property("SPEC", "Tizen.NUI.FrameData.PositionY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameDataPositionY()
        {
            tlog.Debug(tag, $"FrameDataPositionY START");

            using (Animation ani = new Animation(300))
            {
                ani.SetDefaultAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSquare));

                var testingTarget = new FrameData(ani.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object FrameData");
                Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

                try
                {
                    var result = testingTarget.PositionY;
                    tlog.Debug(tag, "PositionY : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FrameDataPositionY END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("FrameData Extra.")]
        //[Property("SPEC", "Tizen.NUI.FrameData.Extra A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void FrameDataExtra()
        //{
        //    tlog.Debug(tag, $"FrameDataExtra START");

        //    using (ImageView image = new ImageView())
        //    {
        //        image.ResourceUrl = path;
        //        image.backgroundExtraData = new BackgroundExtraData();

        //        var testingTarget = new FrameData(image.SwigCPtr.Handle);
        //        Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
        //        Assert.IsInstanceOf<FrameData>(testingTarget, "Should be an instance of FrameData type.");

        //        try
        //        {
        //            var result = testingTarget.Extra;
        //            tlog.Debug(tag, "Extra : " + result);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed!");
        //        }
        //    }

        //    tlog.Debug(tag, $"FrameDataExtra END (OK)");
        //}
    }
}
