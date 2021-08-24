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
    [Description("public/Utility/ScrollViewPagePathEffect")]
    public class PublicScrollViewPagePathEffectTest
    {
        private const string tag = "NUITEST";

        internal class MyScrollViewPagePathEffect : ScrollViewPagePathEffect
        {
            private static Path path = new Path();
            private static Vector3 forward = new Vector3(2, 4, 6);
            private static int inputPropertyIndex = 1;
            private static Vector3 pageSize = new Vector3(6, 8, 10);
            private static uint pageCount = 5;

            public MyScrollViewPagePathEffect() : base(path, forward, inputPropertyIndex, pageSize, pageCount)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
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
        [Description("ScrollViewPagePathEffect constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewPagePathEffect.ScrollViewPagePathEffect C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewPagePathEffectConstructor()
        {
            tlog.Debug(tag, $"ScrollViewPagePathEffectConstructor START");

            using (Path path = new Path())
            {
                using (Vector3 forword = new Vector3(2, 4, 6))
                {
                    using (Vector3 pageSize = new Vector3(6, 8, 10))
                    {
                        var testingTarget = new ScrollViewPagePathEffect(path, forword, 1, pageSize, 5);
                        Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewPagePathEffect");
                        Assert.IsInstanceOf<ScrollViewPagePathEffect>(testingTarget, "Should be an instance of ScrollViewPagePathEffect type.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"ScrollViewPagePathEffectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewPagePathEffect DownCast.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewPagePathEffect.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewPagePathEffectDownCast()
        {
            tlog.Debug(tag, $"ScrollViewPagePathEffectDownCast START");

            using (Path path = new Path())
            {
                using (Vector3 forword = new Vector3(2, 4, 6))
                {
                    using (Vector3 pageSize = new Vector3(6, 8, 10))
                    {
                        var testingTarget = new ScrollViewPagePathEffect(path, forword, 1, pageSize, 5);
                        Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewPagePathEffect");
                        Assert.IsInstanceOf<ScrollViewPagePathEffect>(testingTarget, "Should be an instance of ScrollViewPagePathEffect type.");

                        var result = ScrollViewPagePathEffect.DownCast(testingTarget);
                        Assert.IsNotNull(result, "Can't create success object ScrollViewPagePathEffect");
                        Assert.IsInstanceOf<ScrollViewPagePathEffect>(result, "Should be an instance of ScrollViewPagePathEffect type.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"ScrollViewPagePathEffectDownCast END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ScrollViewPagePathEffect ApplyToPage.")]
        //[Property("SPEC", "Tizen.NUI.ScrollViewPagePathEffect.ApplyToPage M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ScrollViewPagePathEffectApplyToPage()
        //{
        //    tlog.Debug(tag, $"ScrollViewPagePathEffectApplyToPage START");

        //    using (Path path = new Path())
        //    {
        //        using (Vector3 forword = new Vector3(2, 4, 6))
        //        {
        //            using (Vector3 pageSize = new Vector3(6, 8, 10))
        //            {
        //                var testingTarget = new ScrollViewPagePathEffect(path, forword, 1, pageSize, 5);
        //                Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewPagePathEffect");
        //                Assert.IsInstanceOf<ScrollViewPagePathEffect>(testingTarget, "Should be an instance of ScrollViewPagePathEffect type.");

        //                try
        //                {
        //                    using (View view = new View())
        //                    {
        //                        testingTarget.ApplyToPage(view, 2);
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    tlog.Debug(tag, e.Message.ToString());
        //                    Assert.Fail("Caught Exception: Failed!");
        //                }

        //                testingTarget.Dispose();
        //            }
        //        }
        //    }

        //    tlog.Debug(tag, $"ScrollViewPagePathEffectApplyToPage END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("ScrollViewPagePathEffect ReleaseSwigCPtr.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewPagePathEffect.ReleaseSwigCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewPagePathEffectReleaseSwigCPtr()
        {
            tlog.Debug(tag, $"ScrollViewPagePathEffectReleaseSwigCPtr START");

            var testingTarget = new MyScrollViewPagePathEffect();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollViewPagePathEffect");
            Assert.IsInstanceOf<ScrollViewPagePathEffect>(testingTarget, "Should be an instance of ScrollViewPagePathEffect type.");

            try
            {
                testingTarget.OnReleaseSwigCPtr(testingTarget.SwigCPtr);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ScrollViewPagePathEffectReleaseSwigCPtr END (OK)");
        }
    }
}
