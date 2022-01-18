using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RenderTask")]
    public class InternalRenderTaskTest
    {
        private const string tag = "NUITEST";
        private string arrowImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "arrow.png";

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
        [Description("RenderTask constructor.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.RenderTask C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskConstructor()
        {
            tlog.Debug(tag, $"RenderTaskConstructor START");

            var testingTarget = new RenderTask();
            Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
            Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RenderTaskConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask constructor. With RenderTask;")]
        [Property("SPEC", "Tizen.NUI.RenderTask.RenderTask C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskConstructorWithRenderTask()
        {
            tlog.Debug(tag, $"RenderTaskConstructorWithRenderTask START");

            using (Animatable ani = new Animatable())
            {
                using (RenderTask task = new RenderTask(ani.SwigCPtr.Handle, false)) 
                {
                    try
                    {
                        var testingTarget = new RenderTask(task);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            tlog.Debug(tag, $"RenderTaskConstructorWithRenderTask END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask GetRenderTaskFromPtr.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.GetRenderTaskFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskGetRenderTaskFromPtr()
        {
            tlog.Debug(tag, $"RenderTaskGetRenderTaskFromPtr START");

            using (Animatable ani = new Animatable())
            {
                using (RenderTask task = new RenderTask(ani.SwigCPtr.Handle, false))
                {
                    try
                    {
                        var testingTarget = RenderTask.GetRenderTaskFromPtr(task.SwigCPtr.Handle);
                        Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                        Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            tlog.Debug(tag, $"RenderTaskGetRenderTaskFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultScreenToFrameBufferFunction()
        {
            tlog.Debug(tag, $"RenderTaskDefaultScreenToFrameBufferFunction START");

            try
            {
                var result = RenderTask.DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION;
                tlog.Debug(tag, "DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultScreenToFrameBufferFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask FULLSCREEN_FRAMEBUFFER_FUNCTION.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.FULLSCREEN_FRAMEBUFFER_FUNCTION A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskFullScreenFrameBufferFunction()
        {
            tlog.Debug(tag, $"RenderTaskFullScreenFrameBufferFunction START");

            try
            {
                var result = RenderTask.FULLSCREEN_FRAMEBUFFER_FUNCTION;
                tlog.Debug(tag, "FULLSCREEN_FRAMEBUFFER_FUNCTION : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskFullScreenFrameBufferFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_EXCLUSIVE.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_EXCLUSIVE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultExclusive()
        {
            tlog.Debug(tag, $"RenderTaskDefaultExclusive START");

            try
            {
                var result = RenderTask.DEFAULT_EXCLUSIVE;
                tlog.Debug(tag, "DEFAULT_EXCLUSIVE : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultExclusive END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_INPUT_ENABLED.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_INPUT_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultInputEnabled()
        {
            tlog.Debug(tag, $"RenderTaskDefaultExclusive START");

            try
            {
                var result = RenderTask.DEFAULT_INPUT_ENABLED;
                tlog.Debug(tag, "DEFAULT_INPUT_ENABLED : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultInputEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_CLEAR_COLOR.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_CLEAR_COLOR A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultClearColor()
        {
            tlog.Debug(tag, $"RenderTaskDefaultClearColor START");

            try
            {
                var result = RenderTask.DEFAULT_CLEAR_COLOR;
                tlog.Debug(tag, "DEFAULT_CLEAR_COLOR : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultClearColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_CLEAR_ENABLED.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_CLEAR_ENABLED A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultClearEnabled()
        {
            tlog.Debug(tag, $"RenderTaskDefaultClearEnabled START");

            try
            {
                var result = RenderTask.DEFAULT_CLEAR_ENABLED;
                tlog.Debug(tag, "DEFAULT_CLEAR_ENABLED : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultClearEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_CULL_MODE.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_CULL_MODE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultCullMode()
        {
            tlog.Debug(tag, $"RenderTaskDefaultCullMode START");

            try
            {
                var result = RenderTask.DEFAULT_CULL_MODE;
                tlog.Debug(tag, "DEFAULT_CULL_MODE : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultCullMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DEFAULT_REFRESH_RATE.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DEFAULT_REFRESH_RATE A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDefaultRefreshRate()
        {
            tlog.Debug(tag, $"RenderTaskDefaultRefreshRate START");

            try
            {
                var result = RenderTask.DEFAULT_REFRESH_RATE;
                tlog.Debug(tag, "DEFAULT_REFRESH_RATE : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"RenderTaskDefaultRefreshRate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask DownCast.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDownCast()
        {
            tlog.Debug(tag, $"RenderTaskDownCast START");

            using (Animatable ani = new Animatable())
            {
                try
                {
                    RenderTask.DownCast(ani);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"RenderTaskDownCast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("RenderTask DownCast. With null handle.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskDownCastWithNullHandle()
        {
            tlog.Debug(tag, $"RenderTaskDownCastWithNullHandle START");

            try
            {
                RenderTask.DownCast(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"RenderTaskDownCastWithNullHandle END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask Assign.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskAssign()
        {
            tlog.Debug(tag, $"RenderTaskAssign START");

            using (Animatable ani = new Animatable())
            {
                using (RenderTask task = new RenderTask(ani.SwigCPtr.Handle, false))
                {
                    var testingTarget = task.Assign(task);
                    Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                    Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"RenderTaskAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetExclusive.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetExclusive M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetExclusive()
        {
            tlog.Debug(tag, $"RenderTaskSetExclusive START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = RenderTask.GetRenderTaskFromPtr(view.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetExclusive(false);

                    var result = testingTarget.IsExclusive();
                    tlog.Debug(tag, "IsExclusive : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetExclusive END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetInputEnabled.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetInputEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetInputEnabled()
        {
            tlog.Debug(tag, $"RenderTaskSetInputEnabled START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetInputEnabled(true);

                    var result = testingTarget.GetInputEnabled();
                    tlog.Debug(tag, "InputEnabled : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetInputEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetFrameBuffer.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetFrameBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetFrameBuffer()
        {
            tlog.Debug(tag, $"RenderTaskSetFrameBuffer START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = new RenderTask(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (FrameBuffer buffer = new FrameBuffer(1, 2, 3))
                {
                    try
                    {
                        testingTarget.SetFrameBuffer(buffer);

                        var result = testingTarget.GetFrameBuffer();
                        tlog.Debug(tag, "FrameBuffer : " + result);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception :  Failed!");
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetFrameBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetScreenToFrameBufferFunction.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetScreenToFrameBufferFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetScreenToFrameBufferFunction()
        {
            tlog.Debug(tag, $"RenderTaskSetScreenToFrameBufferFunction START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (FrameBuffer buffer = new FrameBuffer(1, 2, 3))
                {
                    try
                    {
                        testingTarget.SetScreenToFrameBufferFunction(new SWIGTYPE_p_f_r_Dali__Vector2__bool(buffer.SwigCPtr.Handle));

                        var result = testingTarget.GetScreenToFrameBufferFunction();
                        tlog.Debug(tag, "ScreenToFrameBufferFunction : " + result);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception :  Failed!");
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetScreenToFrameBufferFunction END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("RenderTask SetScreenToFrameBufferMappingView.")]
        //[Property("SPEC", "Tizen.NUI.RenderTask.SetScreenToFrameBufferMappingView M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void RenderTaskSetScreenToFrameBufferMappingView()
        //{
        //    tlog.Debug(tag, $"RenderTaskSetScreenToFrameBufferMappingView START");

        //    using (View view = new View() { Size = new Size(100, 50) })
        //    {
        //        var testingTarget = new RenderTask(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
        //        Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

        //        try
        //        {
        //            testingTarget.SetScreenToFrameBufferMappingView(view);

        //            var result = testingTarget.GetScreenToFrameBufferMappingView();
        //            tlog.Debug(tag, "ScreenToFrameBufferMappingView : " + result);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception :  Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"RenderTaskSetScreenToFrameBufferMappingView END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("RenderTask SetViewportPosition.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetViewportPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetViewportPosition()
        {
            tlog.Debug(tag, $"RenderTaskSetViewportPosition START");

            using (Animatable ani = new Animatable())
            {
                ani.RegisterProperty("ArrowImage", new PropertyValue(arrowImage), Tizen.NUI.PropertyAccessMode.ReadWrite);
                
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetViewportPosition(new Vector2(100, 50));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetViewportPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetViewportSize.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetViewportSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSetViewportSize()
        {
            tlog.Debug(tag, $"RenderTaskSetViewportSize START");

            using (Animatable ani = new Animatable())
            {
                ani.RegisterProperty("ArrowImage", new PropertyValue(arrowImage), Tizen.NUI.PropertyAccessMode.ReadWrite);

                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetViewportSize(new Vector2(50, 100));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetViewportSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetClearColor.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetClearColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskSetClearColor()
        {
            tlog.Debug(tag, $"RenderTaskSetClearColor START");

            using (Animatable ani = new Animatable())
            {
                ani.RegisterProperty("ArrowImage", new PropertyValue(arrowImage), Tizen.NUI.PropertyAccessMode.ReadWrite);

                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetClearColor(new Vector4(1.0f, 1.0f, 1.0f, 1.0f));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetClearColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetClearEnabled.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetClearEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskSetClearEnabled()
        {
            tlog.Debug(tag, $"RenderTaskSetClearEnabled START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetClearEnabled(true);
                    var result = testingTarget.GetClearEnabled();
                    tlog.Debug(tag, "ClearEnabled : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetClearEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetCullMode.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetCullMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskSetCullMode()
        {
            tlog.Debug(tag, $"RenderTaskSetCullMode START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetCullMode(true);
                    var result = testingTarget.GetCullMode();
                    tlog.Debug(tag, "CullMode : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetCullMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask SetRefreshRate.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.SetRefreshRate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskSetRefreshRate()
        {
            tlog.Debug(tag, $"RenderTaskSetRefreshRate START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.SetRefreshRate(100);
                    var result = testingTarget.GetRefreshRate();
                    tlog.Debug(tag, "RefreshRate : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception :  Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskSetRefreshRate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask ViewportToLocal.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.ViewportToLocal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskViewportToLocal()
        {
            tlog.Debug(tag, $"RenderTaskViewportToLocal START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (View view = new View())
                {
                    var result = testingTarget.ViewportToLocal(view, 0.3f, 0.5f, out float localX, out float localY);
                    tlog.Debug(tag, "WorldToViewport : " + result);
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskViewportToLocal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask FinishedSignal.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.FinishedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskFinishedSignal()
        {
            tlog.Debug(tag, $"RenderTaskFinishedSignal START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                try
                {
                    testingTarget.FinishedSignal();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
                
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskFinishedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask ViewportPosition.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.ViewportPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskViewportPosition()
        {
            tlog.Debug(tag, $"RenderTaskViewportPosition START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (Vector2 position = new Vector2(100, 150))
                {
                    testingTarget.ViewportPosition = position;
                    tlog.Debug(tag, "ViewportPosition :" + testingTarget.ViewportPosition);
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskViewportPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask ViewportSize.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.ViewportSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskViewportSize()
        {
            tlog.Debug(tag, $"RenderTaskViewportSize START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (Vector2 size = new Vector2(100, 150))
                {
                    testingTarget.ViewportSize = size;
                    tlog.Debug(tag, "ViewportSize :" + testingTarget.ViewportSize);
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskViewportSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask ClearColor.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.ClearColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskClearColor()
        {
            tlog.Debug(tag, $"RenderTaskClearColor START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                using (Vector4 color = new Vector4(0.3f, 0.5f, 0.8f, 1.0f))
                {
                    testingTarget.ClearColor = color;
                    tlog.Debug(tag, "ClearColor :" + testingTarget.ClearColor);
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskClearColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTask RequiresSync.")]
        [Property("SPEC", "Tizen.NUI.RenderTask.RequiresSync A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RenderTaskRequiresSync()
        {
            tlog.Debug(tag, $"RenderTaskRequiresSync START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new RenderTask(ani.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
                Assert.IsInstanceOf<RenderTask>(testingTarget, "Should return RenderTask instance.");

                testingTarget.RequiresSync = true;
                tlog.Debug(tag, "RequiresSync :" + testingTarget.RequiresSync);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RenderTaskRequiresSync END (OK)");
        }
    }
}
