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
    [Description("public/Utility/Capture")]
    class PublicCaptureTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string jpg_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "arrow.jpg";

        private delegate bool dummyCallback(IntPtr captureSignal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }


        internal class MyCapture : Capture
        {
            public MyCapture() : base()
            { }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
            }
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
        [Description("Capture constructor.")]
        [Property("SPEC", "Tizen.NUI.Capture.Capture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureConstructor()
        {
            tlog.Debug(tag, $"CaptureConstructor START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture Dispose.")]
        [Property("SPEC", "Tizen.NUI.Capture.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureDispose()
        {
            tlog.Debug(tag, $"CaptureDispose START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            /** disposed is true */
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"CaptureDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture SetImageQuality.")]
        [Property("SPEC", "Tizen.NUI.Capture.SetImageQuality M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureSetImageQuality()
        {
            tlog.Debug(tag, $"CaptureSetImageQuality START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            try
            {
                testingTarget.SetImageQuality(30);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureSetImageQuality END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Capture SetImageQuality. With invalid operation.")]
        [Property("SPEC", "Tizen.NUI.Capture.SetImageQuality M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureSetImageQualityWithInvalidOperation()
        {
            tlog.Debug(tag, $"CaptureSetImageQualityWithInvalidOperation START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            try
            {
                testingTarget.SetImageQuality(120);
            }
            catch (InvalidOperationException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"CaptureSetImageQualityWithInvalidOperation END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Dispose. Capture is disposed.")]
        [Property("SPEC", "Tizen.NUI.Capture.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureDisposeWithDisposedInstance()
        {
            tlog.Debug(tag, $"CaptureDisposeWithDisposedInstance START");

            var testingTarget = new MyCapture();
            Assert.IsNotNull(testingTarget, "Can't create success object MyCapture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of MyCapture type.");

            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"CaptureDisposeWithDisposedInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture Start.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStart()
        {
            tlog.Debug(tag, $"CaptureStart START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    try
                    {
                        testingTarget.Start(container, size, path);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureStart END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start. Size is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartWithNullSize()
        {
            tlog.Debug(tag, $"CaptureStartWithNullSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                try
                {
                    testingTarget.Start(container, null, path);
                }
                catch (ArgumentNullException e)
                {
                    testingTarget.Dispose();
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"CaptureStartWithNullSize END (OK)");
                    Assert.Pass("Caught ArgumentNullException: Passed!");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start. Size is invalid.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartWithInvalidSize()
        {
            tlog.Debug(tag, $"CaptureStartWithInvalidSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(0, 0))
                {
                    try
                    {
                        testingTarget.Start(container, size, path);
                    }
                    catch (InvalidOperationException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartWithInvalidSize END (OK)");
                        Assert.Pass("Caught InvalidOperationException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start. path is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartWithNullPath()
        {
            tlog.Debug(tag, $"CaptureStartWithNullPath START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    try
                    {
                        testingTarget.Start(container, size, null);
                    }
                    catch (ArgumentNullException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartWithNullPath END (OK)");
                        Assert.Pass("Caught ArgumentNullException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Capture Start include Color.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeColor()
        {
            tlog.Debug(tag, $"CaptureStartIncludeColor START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, path, color);
                        }
                        catch (Exception e)
                        {
                            tlog.Debug(tag, e.Message.ToString());
                            Assert.Fail("Caught Exception: Failed!");
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureStartIncludeColor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include Color. Color is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeColorWithNullColor()
        {
            tlog.Debug(tag, $"CaptureStartIncludeColorWithNullColor START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    try
                    {
                        testingTarget.Start(container, size, path, null);
                    }
                    catch (ArgumentNullException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartIncludeColorWithNullColor END (OK)");
                        Assert.Pass("Caught ArgumentNullException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include color. Size is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeColorWithNullSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludeColorWithNullSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Color color = Color.Cyan)
                {
                    try
                    {
                        testingTarget.Start(container, null, path, color);
                    }
                    catch (ArgumentNullException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartIncludeColorWithNullSize END (OK)");
                        Assert.Pass("Caught ArgumentNullException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include color. Path is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeColorWithNullPath()
        {
            tlog.Debug(tag, $"CaptureStartIncludeColorWithNullPath START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, null, color);
                        }
                        catch (ArgumentNullException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludeColorWithNullPath END (OK)");
                            Assert.Pass("Caught ArgumentNullException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include color. Size is invalid.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeColorWithInvalidSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludeColorWithInvalidSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(0, 0))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, path, color);
                        }
                        catch (InvalidOperationException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludeColorWithInvalidSize END (OK)");
                            Assert.Pass("Caught InvalidOperationException: Passed!");
                        }
                    }
                }
            }
        }

        //[Test]
        //[Category("P1")]
        //[Description("Capture Start include quality.")]
        //[Property("SPEC", "Tizen.NUI.Capture.Start M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void CaptureStartIncludeQuality()
        //{
        //    tlog.Debug(tag, $"CaptureStartIncludeQuality START");

        //    var testingTarget = new Capture();
        //    Assert.IsNotNull(testingTarget, "Can't create success object Capture");
        //    Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

        //    using (Container container = new View())
        //    {
        //        using (Size size = new Size(100, 80))
        //        {
        //            using (Color color = Color.Cyan)
        //            {
        //                try
        //                {
        //                    testingTarget.Start(container, size, jpg_path, color, 30);
        //                }
        //                catch (Exception e)
        //                {
        //                    tlog.Debug(tag, e.Message.ToString());
        //                    Assert.Fail("Caught Exception: Failed!");
        //                }
        //            }
        //        }
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"CaptureStartIncludeQuality END (OK)");
        //}

        [Test]
        [Category("P2")]
        [Description("Capture Start include quality. Color is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeQualityWithNullColor()
        {
            tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullColor START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    try
                    {
                        testingTarget.Start(container, size, jpg_path, null, 30);
                    }
                    catch (ArgumentNullException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullColor END (OK)");
                        Assert.Pass("Caught ArgumentNullException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include quality. Size is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeQualityWithNullSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Color color = Color.Cyan)
                {
                    try
                    {
                        testingTarget.Start(container, null, jpg_path, color, 30);
                    }
                    catch (ArgumentNullException e)
                    {
                        testingTarget.Dispose();
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullSize END (OK)");
                        Assert.Pass("Caught ArgumentNullException: Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include quality. Path is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeQualityWithNullPath()
        {
            tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullPath START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, null, color, 30);
                        }
                        catch (ArgumentNullException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludeQualityWithNullPath END (OK)");
                            Assert.Pass("Caught ArgumentNullException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include quality. Quality is invalid.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeQualityWithInvalidQuality()
        {
            tlog.Debug(tag, $"CaptureStartIncludeQualityWithInvalidQuality START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, jpg_path, color, 130);
                        }
                        catch (InvalidOperationException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludeQualityWithInvalidQuality END (OK)");
                            Assert.Pass("Caught InvalidOperationException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include quality. Size is invalid.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludeQualityWithInvalidSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludeQualityWithInvalidSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(0, 0))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, size, path, color, 30);
                        }
                        catch (InvalidOperationException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludeQualityWithInvalidSize END (OK)");
                            Assert.Pass("Caught InvalidOperationException: Passed!");
                        }
                    }
                }
            }
        }

        //[Test]
        //[Category("P1")]
        //[Description("Capture Start include position.")]
        //[Property("SPEC", "Tizen.NUI.Capture.Start M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void CaptureStartIncludePosition()
        //{
        //    tlog.Debug(tag, $"CaptureStartIncludePosition START");

        //    var testingTarget = new Capture();
        //    Assert.IsNotNull(testingTarget, "Can't create success object Capture");
        //    Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

        //    using (Container container = new View())
        //    {
        //        using (Position position = new Position(50, 100))
        //        {
        //            using (Size size = new Size(100, 80))
        //            {
        //                using (Color color = Color.Cyan)
        //                {
        //                    try
        //                    {
        //                        testingTarget.Start(container, position, size, path, color);
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        tlog.Debug(tag, e.Message.ToString());
        //                        Assert.Fail("Caught Exception: Failed!");
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"CaptureStartIncludePosition END (OK)");
        //}

        [Test]
        [Category("P2")]
        [Description("Capture Start include position. Position is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludePositionWithNullPosition()
        {
            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullPosition START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Size size = new Size(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, null, size, path, color);
                        }
                        catch (ArgumentNullException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullPosition END (OK)");
                            Assert.Pass("Caught ArgumentNullException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include position. Size is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludePositionWithNullSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Position position = new Position(100, 80))
                {
                    using (Color color = Color.Cyan)
                    {
                        try
                        {
                            testingTarget.Start(container, position, null, path, color);
                        }
                        catch (ArgumentNullException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullSize END (OK)");
                            Assert.Pass("Caught ArgumentNullException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include position. Color is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludePositionWithNullColor()
        {
            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullColor START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Position position = new Position(50, 100))
                {
                    using (Size size = new Size(100, 80))
                    {
                        try
                        {
                            testingTarget.Start(container, position, size, path, null);
                        }
                        catch (ArgumentNullException e)
                        {
                            testingTarget.Dispose();
                            tlog.Debug(tag, e.Message.ToString());
                            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullColor END (OK)");
                            Assert.Pass("Caught ArgumentNullException: Passed!");
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include position. Color is null.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludePositionWithNullPath()
        {
            tlog.Debug(tag, $"CaptureStartIncludePositionWithNullPath START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Position position = new Position(50, 100))
                {
                    using (Size size = new Size(100, 80))
                    {
                        using (Color color = Color.Cyan)
                        {
                            try
                            {
                                testingTarget.Start(container, position, size, null, color);
                            }
                            catch (ArgumentNullException e)
                            {
                                testingTarget.Dispose();
                                tlog.Debug(tag, e.Message.ToString());
                                tlog.Debug(tag, $"CaptureStartIncludePositionWithNullPath END (OK)");
                                Assert.Pass("Caught ArgumentNullException: Passed!");
                            }
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Capture Start include position. Size is invalid.")]
        [Property("SPEC", "Tizen.NUI.Capture.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureStartIncludePositionWithInvalidSize()
        {
            tlog.Debug(tag, $"CaptureStartIncludePositionWithInvalidSize START");

            var testingTarget = new Capture();
            Assert.IsNotNull(testingTarget, "Can't create success object Capture");
            Assert.IsInstanceOf<Capture>(testingTarget, "Should be an instance of Capture type.");

            using (Container container = new View())
            {
                using (Position position = new Position(50, 100))
                {
                    using (Size size = new Size(0, 0))
                    {
                        using (Color color = Color.Cyan)
                        {
                            try
                            {
                                testingTarget.Start(container, position, size, path, color);
                            }
                            catch (InvalidOperationException e)
                            {
                                testingTarget.Dispose();
                                tlog.Debug(tag, e.Message.ToString());
                                tlog.Debug(tag, $"CaptureStartIncludePositionWithInvalidSize END (OK)");
                                Assert.Pass("Caught InvalidOperationException: Passed!");
                            }
                        }
                    }
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Capture Finished.")]
        [Property("SPEC", "Tizen.NUI.Capture.Finished M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureFinished()
        {
            tlog.Debug(tag, $"CaptureFinished START");

            var testingTarget = new MyCapture();
            Assert.IsNotNull(testingTarget, "Can't create success object MyCapture");
            Assert.IsInstanceOf<MyCapture>(testingTarget, "Should be an instance of MyCapture type.");

            testingTarget.Finished += OnFinishedEvent;
            testingTarget.Finished -= OnFinishedEvent;

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureFinished END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture GetNativeImageSource.")]
        [Property("SPEC", "Tizen.NUI.Capture.GetNativeImageSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureGetNativeImageSource()
        {
            tlog.Debug(tag, $"CaptureGetNativeImageSource START");

            var testingTarget = new MyCapture();
            Assert.IsNotNull(testingTarget, "Can't create success object MyCapture");
            Assert.IsInstanceOf<MyCapture>(testingTarget, "Should be an instance of MyCapture type.");

            var result = testingTarget.GetNativeImageSource();
            Assert.IsNotNull(result, "Can't create success object NativeImageSource ");
            Assert.IsInstanceOf<NativeImageSource>(result, "Should be an instance of NativeImageSource  type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CaptureGetNativeImageSource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture.CaptureFinishedEventArgs  Success.")]
        [Property("SPEC", "Tizen.NUI.Capture.CaptureFinishedEventArgs.Success A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureCaptureFinishedEventArgsSuccess()
        {
            tlog.Debug(tag, $"CaptureCaptureFinishedEventArgsSuccess START");

            var testingTarget = new CaptureFinishedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object CaptureFinishedEventArgs");
            Assert.IsInstanceOf<CaptureFinishedEventArgs>(testingTarget, "Should be an instance of CaptureFinishedEventArgs type.");

            Assert.AreEqual(false, testingTarget.Success, "Should be equal!");

            testingTarget.Success = true;
            Assert.AreEqual(true, testingTarget.Success, "Should be equal!");

            tlog.Debug(tag, $"CaptureCaptureFinishedEventArgsSuccess END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture.CaptureSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.Capture.CaptureSignal.CaptureSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureCaptureSignalConstructor()
        {
            tlog.Debug(tag, $"CaptureCaptureSignalConstructor START");

            using (Capture capture = new Capture())
            {
                var testingTarget = new CaptureSignal(capture.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object CaptureSignal");
                Assert.IsInstanceOf<CaptureSignal>(testingTarget, "Should be an instance of CaptureSignal type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CaptureCaptureSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture.CaptureSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.Capture.CaptureSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureCaptureSignalEmpty()
        {
            tlog.Debug(tag, $"CaptureCaptureSignalEmpty START");

            using (Capture capture = new Capture())
            {
                var testingTarget = new CaptureSignal(capture.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object CaptureSignal");
                Assert.IsInstanceOf<CaptureSignal>(testingTarget, "Should be an instance of CaptureSignal type.");

                var result = testingTarget.Empty();
                Assert.IsTrue(result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CaptureCaptureSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture.CaptureSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.Capture.CaptureSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureCaptureSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"CaptureCaptureSignalGetConnectionCount START");

            using (Capture capture = new Capture())
            {
                var testingTarget = new CaptureSignal(capture.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object CaptureSignal");
                Assert.IsInstanceOf<CaptureSignal>(testingTarget, "Should be an instance of CaptureSignal type.");

                var result = testingTarget.GetConnectionCount();
                Assert.AreEqual(0, result, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CaptureCaptureSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Capture.CaptureSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.Capture.CaptureSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CaptureCaptureSignalEmit()
        {
            tlog.Debug(tag, $"CaptureCaptureSignalEmit START");

            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (Capture capture = new Capture())
            {
                var testingTarget = new CaptureSignal(capture.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object CaptureSignal");
                Assert.IsInstanceOf<CaptureSignal>(testingTarget, "Should be an instance of CaptureSignal type.");

                testingTarget.Emit(capture, true);
                
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CaptureCaptureSignalEmit END (OK)");
        }

        private void OnFinishedEvent(object sender, CaptureFinishedEventArgs e)
        {
            // Do not implementation
        }
    }
}
