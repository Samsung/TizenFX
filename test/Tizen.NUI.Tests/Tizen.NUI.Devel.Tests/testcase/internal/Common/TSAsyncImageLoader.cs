using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/AsyncImageLoader")]
    public class InternalAsyncImageLoaderTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
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
        [Description("AsyncImageLoader constructor.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.AsyncImageLoader C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderConstructor()
        {
            tlog.Debug(tag, $"AsyncImageLoaderConstructor START");

            var testingTarget = new AsyncImageLoader();
            Assert.IsNotNull(testingTarget, "Can't create success object AsyncImageLoader");
            Assert.IsInstanceOf<AsyncImageLoader>(testingTarget, "Should be an instance of AsyncImageLoader type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AsyncImageLoaderConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader constructor. With AsyncImageLoader.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.AsyncImageLoader C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderConstructorWithAsyncImageLoader()
        {
            tlog.Debug(tag, $"AsyncImageLoaderConstructorWithAsyncImageLoader START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                var testingTarget = new AsyncImageLoader(loader);
                Assert.IsNotNull(testingTarget, "Can't create success object AsyncImageLoader");
                Assert.IsInstanceOf<AsyncImageLoader>(testingTarget, "Should be an instance of AsyncImageLoader type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AsyncImageLoaderConstructorWithAsyncImageLoader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader Assign.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderAssign()
        {
            tlog.Debug(tag, $"AsyncImageLoaderAssign START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                var testingTarget = new AsyncImageLoader(loader);
                Assert.IsNotNull(testingTarget, "Can't create success object AsyncImageLoader");
                Assert.IsInstanceOf<AsyncImageLoader>(testingTarget, "Should be an instance of AsyncImageLoader type.");

                try
                {
                    testingTarget.Assign(loader);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AsyncImageLoaderAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader DownCast.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderDownCast()
        {
            tlog.Debug(tag, $"AsyncImageLoaderDownCast START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    AsyncImageLoader.DownCast(loader);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader Load.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderLoad()
        {
            tlog.Debug(tag, $"AsyncImageLoaderLoad START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.Load(url);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderLoad END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader Load. With dimensions.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderLoadWithDimensions()
        {
            tlog.Debug(tag, $"AsyncImageLoaderLoadWithDimensions START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.Load(url, new Uint16Pair(100, 80));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderLoadWithDimensions END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader Load. With fittingMode.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderLoadWithFittingMode()
        {
            tlog.Debug(tag, $"AsyncImageLoaderLoadWithFittingMode START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.Load(url, new Uint16Pair(100, 80), FittingModeType.Center, SamplingModeType.Linear, false);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderLoadWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader Cancel.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.Cancel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderCancel()
        {
            tlog.Debug(tag, $"AsyncImageLoaderCancel START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.Load(url, new Uint16Pair(100, 80), FittingModeType.Center, SamplingModeType.Linear, false);
                    loader.Cancel(0);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderCancel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader CancelAll.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.CancelAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderCancelAll()
        {
            tlog.Debug(tag, $"AsyncImageLoaderCancelAll START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.Load(url, new Uint16Pair(100, 80), FittingModeType.Center, SamplingModeType.Linear, false);
                    loader.CancelAll();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderCancelAll END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AsyncImageLoader ImageLoadedSignal.")]
        [Property("SPEC", "Tizen.NUI.AsyncImageLoader.ImageLoadedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AsyncImageLoaderImageLoadedSignal()
        {
            tlog.Debug(tag, $"AsyncImageLoaderImageLoadedSignal START");

            using (AsyncImageLoader loader = new AsyncImageLoader())
            {
                try
                {
                    loader.ImageLoadedSignal();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"AsyncImageLoaderImageLoadedSignal END (OK)");
        }
    }
}
