using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/NativeBinding/NDalic")]
    public class InternalNDalicTest
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
        [Description("NDalic int_to_uint.")]
        [Property("SPEC", "Tizen.NUI.NDalic.int_to_uint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicIntToUint()
        {
            tlog.Debug(tag, $"NDalicIntToUint START");

            var result = NDalic.int_to_uint(1);
            tlog.Debug(tag, "int_to_uint : " + result);

            tlog.Debug(tag, $"NDalicIntToUint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic DaliAssertMessage.")]
        [Property("SPEC", "Tizen.NUI.NDalic.DaliAssertMessage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicDaliAssertMessage()
        {
            tlog.Debug(tag, $"NDalicDaliAssertMessage START");

            try
            {
                NDalic.DaliAssertMessage("true", " arg > 0");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NDalicDaliAssertMessage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Min.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Min M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicMin()
        {
            tlog.Debug(tag, $"NDalicMin START");

            Vector2 dummy1 = new Vector2(0.3f, 0.5f);
            Vector2 dummy2 = new Vector2(0.5f, 0.9f);

            tlog.Debug(tag, "Min : " + NDalic.Min(dummy1, dummy2));
            tlog.Debug(tag, "Max : " + NDalic.Max(dummy1, dummy2));

            dummy1.Dispose();
            dummy2.Dispose();
            tlog.Debug(tag, $"NDalicMin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Clamp.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicClamp()
        {
            tlog.Debug(tag, $"NDalicClamp START");

            using (Vector2 vec = new Vector2(0.3f, 0.5f))
            {
                NDalic.Clamp(vec, 0.0f, 1.0f);
            }

            tlog.Debug(tag, $"NDalicClamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Min.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Min M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicVector3Min()
        {
            tlog.Debug(tag, $"NDalicVector3Min START");

            Vector3 dummy1 = new Vector3(0.3f, 0.5f, 1.0f);
            Vector3 dummy2 = new Vector3(0.5f, 0.9f, 1.0f);

            tlog.Debug(tag, "Min : " + NDalic.Min(dummy1, dummy2));
            tlog.Debug(tag, "Max : " + NDalic.Max(dummy1, dummy2));

            dummy1.Dispose();
            dummy2.Dispose();
            tlog.Debug(tag, $"NDalicVector3Min END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Clamp.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicVector3Clamp()
        {
            tlog.Debug(tag, $"NDalicVector3Clamp START");

            using (Vector3 vec = new Vector3(0.3f, 0.5f, 1.0f))
            {
                NDalic.Clamp(vec, 0.0f, 1.0f);
            }

            tlog.Debug(tag, $"NDalicVector3Clamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Min.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Min M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicVector4Min()
        {
            tlog.Debug(tag, $"NDalicVector4Min START");

            Vector4 dummy1 = new Vector4(0.0f, 0.3f, 0.5f, 1.0f);
            Vector4 dummy2 = new Vector4(0.0f, 0.5f, 0.9f, 1.0f);

            tlog.Debug(tag, "Min : " + NDalic.Min(dummy1, dummy2));
            tlog.Debug(tag, "Max : " + NDalic.Max(dummy1, dummy2));

            dummy1.Dispose();
            dummy2.Dispose();
            tlog.Debug(tag, $"NDalicVector4Min END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Clamp.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicVector4Clamp()
        {
            tlog.Debug(tag, $"NDalicVector4Clamp START");

            using (Vector4 vec = new Vector4(0.0f, 0.3f, 0.5f, 1.0f))
            {
                NDalic.Clamp(vec, 0.0f, 1.0f);
            }

            tlog.Debug(tag, $"NDalicVector4Clamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic EqualTo.")]
        [Property("SPEC", "Tizen.NUI.NDalic.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicEqualTo()
        {
            tlog.Debug(tag, $"NDalicEqualTo START");

            AngleAxis lhs = new AngleAxis();
            AngleAxis rhs = new AngleAxis();

            var result = NDalic.EqualTo(lhs, rhs);
            tlog.Debug(tag, "EqualTo : " + result);

            tlog.Debug(tag, $"NDalicEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic EqualsZero.")]
        [Property("SPEC", "Tizen.NUI.NDalic.EqualsZero M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicEqualsZero()
        {
            tlog.Debug(tag, $"NDalicEqualsZero START");

            var result = NDalic.EqualsZero(0.0f);
            tlog.Debug(tag, "EqualsZero : " + result);

            tlog.Debug(tag, $"NDalicEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Equals.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicEquals()
        {
            tlog.Debug(tag, $"NDalicEquals START");

            bool result = false;
            result = NDalic.Equals(0.3f, 0.3f);
            tlog.Debug(tag, "Equals : " + result);

            // with epsilon
            result = NDalic.Equals(0.5f, 0.9f, 0.3f);
            tlog.Debug(tag, "Equals : " + result);

            tlog.Debug(tag, $"NDalicEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Round.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Round M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicRound()
        {
            tlog.Debug(tag, $"NDalicRound START");

            var result = NDalic.Round(0.3f, 1);
            tlog.Debug(tag, "Round : " + result);

            tlog.Debug(tag, $"NDalicRound END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic WrapInDomain.")]
        [Property("SPEC", "Tizen.NUI.NDalic.WrapInDomain M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicWrapInDomain()
        {
            tlog.Debug(tag, $"NDalicWrapInDomain START");

            var result = NDalic.WrapInDomain(0.3f, 0.0f, 1.0f);
            tlog.Debug(tag, "WrapInDomain : " + result);

            tlog.Debug(tag, $"NDalicWrapInDomain END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic ShortestDistanceInDomain.")]
        [Property("SPEC", "Tizen.NUI.NDalic.ShortestDistanceInDomain M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicShortestDistanceInDomain()
        {
            tlog.Debug(tag, $"NDalicShortestDistanceInDomain START");

            var result = NDalic.ShortestDistanceInDomain(0.1f, 0.3f, 0.0f, 1.0f);
            tlog.Debug(tag, "WrapInDomain : " + result);

            tlog.Debug(tag, $"NDalicShortestDistanceInDomain END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic WEIGHT.")]
        [Property("SPEC", "Tizen.NUI.NDalic.WEIGHT M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicWEIGHT()
        {
            tlog.Debug(tag, $"NDalicWEIGHT START");

            var result = NDalic.WEIGHT;
            tlog.Debug(tag, "WEIGHT : " + result);

            tlog.Debug(tag, $"NDalicWEIGHT END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic MACHINE_EPSILON_n.")]
        [Property("SPEC", "Tizen.NUI.NDalic.MACHINE_EPSILON_n M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicMACHINE_EPSILON_n()
        {
            tlog.Debug(tag, $"NDalicMACHINE_EPSILON_n START");

            float result = 0.0f;
            result = NDalic.MACHINE_EPSILON_0;
            tlog.Debug(tag, "MACHINE_EPSILON_0 : " + result);

            result = NDalic.MACHINE_EPSILON_1;
            tlog.Debug(tag, "MACHINE_EPSILON_1 : " + result);

            result = NDalic.MACHINE_EPSILON_10;
            tlog.Debug(tag, "MACHINE_EPSILON_10 : " + result);

            result = NDalic.MACHINE_EPSILON_100;
            tlog.Debug(tag, "MACHINE_EPSILON_100 : " + result);

            result = NDalic.MACHINE_EPSILON_1000;
            tlog.Debug(tag, "MACHINE_EPSILON_1000 : " + result);

            result = NDalic.MACHINE_EPSILON_10000;
            tlog.Debug(tag, "MACHINE_EPSILON_10000 : " + result);

            tlog.Debug(tag, $"NDalicMACHINE_EPSILON_n END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic X_VALID_PIXEL_FORMAT.")]
        [Property("SPEC", "Tizen.NUI.NDalic.X_VALID_PIXEL_FORMAT M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicX_VALID_PIXEL_FORMAT()
        {
            tlog.Debug(tag, $"NDalicX_VALID_PIXEL_FORMAT START");

            PixelFormat result = PixelFormat.BGR8888;
            result = NDalic.FIRST_VALID_PIXEL_FORMAT;
            tlog.Debug(tag, "FIRST_VALID_PIXEL_FORMAT : " + result);

            result = NDalic.LAST_VALID_PIXEL_FORMAT;
            tlog.Debug(tag, "LAST_VALID_PIXEL_FORMAT : " + result);

            tlog.Debug(tag, $"NDalicX_VALID_PIXEL_FORMAT END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic HasAlpha.")]
        [Property("SPEC", "Tizen.NUI.NDalic.HasAlpha M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicHasAlpha()
        {
            tlog.Debug(tag, $"NDalicHasAlpha START");

            var result = NDalic.HasAlpha(PixelFormat.A8);
            tlog.Debug(tag, "FIRST_VALID_PIXEL_FORMAT : " + result);

            tlog.Debug(tag, $"NDalicHasAlpha END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetBytesPerPixel.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetBytesPerPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetBytesPerPixel()
        {
            tlog.Debug(tag, $"NDalicGetBytesPerPixel START");

            var result = NDalic.GetBytesPerPixel(PixelFormat.A8);
            tlog.Debug(tag, "FIRST_VALID_PIXEL_FORMAT : " + result);

            tlog.Debug(tag, $"NDalicGetBytesPerPixel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic POSITIVE_X.")]
        [Property("SPEC", "Tizen.NUI.NDalic.POSITIVE_X M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicPOSITIVE_X()
        {
            tlog.Debug(tag, $"NDalicPOSITIVE_X START");

            var result = NDalic.POSITIVE_X;
            tlog.Debug(tag, "POSITIVE_X : " + result);

            tlog.Debug(tag, $"NDalicPOSITIVE_X END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic NEGATIVE_X.")]
        [Property("SPEC", "Tizen.NUI.NDalic.NEGATIVE_X M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicNEGATIVE_X()
        {
            tlog.Debug(tag, $"NDalicNEGATIVE_X START");

            var result = NDalic.NEGATIVE_X;
            tlog.Debug(tag, "NEGATIVE_X : " + result);

            tlog.Debug(tag, $"NDalicNEGATIVE_X END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic POSITIVE_Y.")]
        [Property("SPEC", "Tizen.NUI.NDalic.POSITIVE_Y M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicPOSITIVE_Y()
        {
            tlog.Debug(tag, $"NDalicPOSITIVE_Y START");

            uint result = 0;
            result = NDalic.POSITIVE_Y;
            tlog.Debug(tag, "POSITIVE_Y : " + result);

            result = NDalic.NEGATIVE_Y;
            tlog.Debug(tag, "NEGATIVE_Y : " + result);

            tlog.Debug(tag, $"NDalicPOSITIVE_Y END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic POSITIVE_Z.")]
        [Property("SPEC", "Tizen.NUI.NDalic.POSITIVE_Z M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicPOSITIVE_Z()
        {
            tlog.Debug(tag, $"NDalicPOSITIVE_Z START");

            uint result = 0;
            result = NDalic.POSITIVE_Z;
            tlog.Debug(tag, "POSITIVE_Z : " + result);

            result = NDalic.NEGATIVE_Z;
            tlog.Debug(tag, "NEGATIVE_Z : " + result);

            tlog.Debug(tag, $"NDalicPOSITIVE_Z END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Raise.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicRaise()
        {
            tlog.Debug(tag, $"NDalicRaise START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    NDalic.Raise(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }
            }

            tlog.Debug(tag, $"NDalicRaise END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic Lower.")]
        [Property("SPEC", "Tizen.NUI.NDalic.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicLower()
        {
            tlog.Debug(tag, $"NDalicLower START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    NDalic.Lower(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }
            }

            tlog.Debug(tag, $"NDalicLower END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic RaiseToTop.")]
        [Property("SPEC", "Tizen.NUI.NDalic.RaiseToTop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicRaiseToTop()
        {
            tlog.Debug(tag, $"NDalicRaiseToTop START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    NDalic.RaiseToTop(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }
            }

            tlog.Debug(tag, $"NDalicRaiseToTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic LowerToBottom.")]
        [Property("SPEC", "Tizen.NUI.NDalic.LowerToBottom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicLowerToBottom()
        {
            tlog.Debug(tag, $"NDalicLowerToBottom START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    NDalic.LowerToBottom(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }
            }

            tlog.Debug(tag, $"NDalicLowerToBottom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic RaiseAbove.")]
        [Property("SPEC", "Tizen.NUI.NDalic.RaiseAbove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicRaiseAbove()
        {
            tlog.Debug(tag, $"NDalicRaiseAbove START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                using (View target = new View() { Size = new Size(100, 50) })
                {
                    try
                    {
                        NDalic.RaiseAbove(view, target);
                        NDalic.LowerBelow(target, view);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed");
                    }
                }
            }

            tlog.Debug(tag, $"NDalicRaiseAbove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetImplementation.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetImplementation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetImplementation()
        {
            tlog.Debug(tag, $"NDalicGetImplementation START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                try
                {
                    NDalic.GetImplementation(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }
            }

            tlog.Debug(tag, $"NDalicGetImplementation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic NewItemLayout.")]
        [Property("SPEC", "Tizen.NUI.NDalic.NewItemLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicNewItemLayout()
        {
            tlog.Debug(tag, $"NDalicNewItemLayout START");

            var result = NDalic.NewItemLayout(DefaultItemLayoutType.GRID);
            tlog.Debug(tag, "New item layout :" + result);

            tlog.Debug(tag, $"NDalicNewItemLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetAlphaOffsetAndMask.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetAlphaOffsetAndMask M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetAlphaOffsetAndMask()
        {
            tlog.Debug(tag, $"NDalicGetAlphaOffsetAndMask START");

            intp dummy1 = new intp();
            dummy1.assign(1);

            intp dummy2 = new intp();
            dummy2.assign(10);

            try
            {
                NDalic.GetAlphaOffsetAndMask(PixelFormat.BGR8888, dummy1.cast(), dummy2.cast());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            dummy1.Dispose();
            dummy2.Dispose();
            tlog.Debug(tag, $"NDalicGetAlphaOffsetAndMask END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetRangedEpsilon.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetRangedEpsilon M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetRangedEpsilon()
        {
            tlog.Debug(tag, $"NDalicGetRangedEpsilon START");

            var result = NDalic.GetRangedEpsilon(0.3f, 1.0f);
            tlog.Debug(tag, "Get ranged epsilon : " + result);

            tlog.Debug(tag, $"NDalicGetRangedEpsilon END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic IsPowerOfTwo.")]
        [Property("SPEC", "Tizen.NUI.NDalic.IsPowerOfTwo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicIsPowerOfTwo()
        {
            tlog.Debug(tag, $"NDalicIsPowerOfTwo START");

            var result = NDalic.IsPowerOfTwo(1);
            tlog.Debug(tag, "Is power of two : " + result);

            tlog.Debug(tag, $"NDalicIsPowerOfTwo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic NextPowerOfTwo.")]
        [Property("SPEC", "Tizen.NUI.NDalic.NextPowerOfTwo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicNextPowerOfTwo()
        {
            tlog.Debug(tag, $"NDalicNextPowerOfTwo START");

            var result = NDalic.NextPowerOfTwo(1);
            tlog.Debug(tag, "Next power of two : " + result);

            tlog.Debug(tag, $"NDalicNextPowerOfTwo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetName.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetName()
        {
            tlog.Debug(tag, $"NDalicGetName START");

            var result = NDalic.GetName(PropertyType.Float);
            tlog.Debug(tag, "Get name : " + result);

            tlog.Debug(tag, $"NDalicGetName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic c.")]
        [Property("SPEC", "Tizen.NUI.NDalic.c M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicC()
        {
            tlog.Debug(tag, $"NDalicC START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var result = NDalic.c(view);
                tlog.Debug(tag, "BaseObject  : " + result);
            }

            tlog.Debug(tag, $"NDalicC END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NDalic GetDeviceClass.")]
        [Property("SPEC", "Tizen.NUI.NDalic.GetDeviceClass M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NDalicGetDeviceClass()
        {
            tlog.Debug(tag, $"NDalicGetDeviceClass START");

            using (Key key = new Key())
            {
                var type = NDalic.GetDeviceClass(key);
                tlog.Debug(tag, "Get device class type : " + type);
            }

            tlog.Debug(tag, $"NDalicGetDeviceClass END (OK)");
        }
    }
}
