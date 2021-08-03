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
    [Description("public/BaseComponents/AnimatedVectorImageView")]
    public class PublicAnimatedVectorImageViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyAnimatedVectorImageView : AnimatedVectorImageView
        {
            public MyAnimatedVectorImageView()
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
        [Description("AnimatedVectorImageView constructor.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.AnimatedVectorImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewConstructor()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewConstructor START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView constructor. With scale.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.AnimatedVectorImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewConstructorWithScale()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewConstructorWithScale START");

            var testingTarget = new AnimatedVectorImageView(0.3f);
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewConstructorWithScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView Dispose.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewDispose()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewDispose START");

            var testingTarget = new MyAnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"AnimatedVectorImageViewDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView ResourceUrl.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.ResourceUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewResourceUrl()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewResourceUrl START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.ResourceUrl = url;
            Assert.AreEqual(url, testingTarget.ResourceUrl, "Should be equal");

            /** Set same url */
            try
            {
                testingTarget.ResourceUrl = url;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewResourceUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView RepeatCount.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.RepeatCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewRepeatCount()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewRepeatCount START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            Assert.AreEqual(0, testingTarget.RepeatCount, "Should be equal");

            testingTarget.RepeatCount = 2;
            Assert.AreEqual(2, testingTarget.RepeatCount, "Should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewRepeatCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView TotalFrame.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.TotalFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewTotalFrame()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewTotalFrame START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                var result = testingTarget.TotalFrame;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewTotalFrame END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("AnimatedVectorImageView CurrentFrame.")]
        //[Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.CurrentFrame A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AnimatedVectorImageViewCurrentFrame()
        //{
        //    tlog.Debug(tag, $"AnimatedVectorImageViewCurrentFrame START");

        //    var testingTarget = new AnimatedVectorImageView();
        //    Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
        //    Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

        //    testingTarget.ResourceUrl = url;
        //    NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

        //    try
        //    {
        //        testingTarget.CurrentFrame = 200;
        //        var result = testingTarget.CurrentFrame;

        //        /** value < 0 */
        //        testingTarget.CurrentFrame = -3;
        //        Assert.AreEqual(0, testingTarget.CurrentFrame, "Should be equal!");
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"AnimatedVectorImageViewCurrentFrame END (OK)");
        //}

        [Test]
        [Category("P2")]
        [Description("AnimatedVectorImageView CurrentFrame. ResourceUrl is null.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.CurrentFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewCurrentFrameNotSetResourceUrl()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewCurrentFrameNotSetResourceUrl START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                testingTarget.CurrentFrame = 3;
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimatedVectorImageViewCurrentFrameNotSetResourceUrl END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView RepeatMode.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.RepeatMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewRepeatMode()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewRepeatMode START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.RepeatMode = AnimatedVectorImageView.RepeatModes.Reverse;
            Assert.AreEqual(AnimatedVectorImageView.RepeatModes.Reverse, testingTarget.RepeatMode, "Should be equal!");

            testingTarget.RepeatMode = AnimatedVectorImageView.RepeatModes.Restart;
            Assert.AreEqual(AnimatedVectorImageView.RepeatModes.Restart, testingTarget.RepeatMode, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewRepeatMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView AnimationState.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.AnimationState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewAnimationState()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewAnimationState START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.ResourceUrl = url;
            
            testingTarget.Play();
            tlog.Debug(tag, "AnimationState : " + testingTarget.AnimationState);

            testingTarget.Pause();
            tlog.Debug(tag, "AnimationState : " + testingTarget.AnimationState);

            testingTarget.Play();
            tlog.Debug(tag, "AnimationState : " + testingTarget.AnimationState);

            testingTarget.Stop();
            tlog.Debug(tag, "AnimationState : " + testingTarget.AnimationState);

            try
            {
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewAnimationState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView SetMinAndMaxFrame.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.SetMinAndMaxFrame M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewSetMinAndMaxFrame()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinAndMaxFrame START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                testingTarget.SetMinAndMaxFrame(1, 10);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            /** minimumFrame > maximumFrame */
            try
            {
                testingTarget.SetMinAndMaxFrame(10, 1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinAndMaxFrame END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView SetMinMaxFrame.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.SetMinMaxFrame M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewSetMinMaxFrame()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinMaxFrame START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                testingTarget.SetMinMaxFrame(1, 10);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinMaxFrame END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView SetMinMaxFrameByMarker.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.SetMinMaxFrameByMarker M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewSetMinMaxFrameByMarker()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinMaxFrameByMarker START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            string maker = "startframe: 1; endframe: 10";

            try
            {
                testingTarget.SetMinMaxFrameByMarker(maker, null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewSetMinMaxFrameByMarker END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("AnimatedVectorImageView Play. ResourceUrl is null.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewPlay()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewPlay START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            try
            {
                testingTarget.Play();
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"AnimatedVectorImageViewPlay END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView Stop. EndAction is Cancel.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewStopAsCancel()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsCancel START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.ResourceUrl = url;

            testingTarget.Play();

            try
            {
                testingTarget.Stop(AnimatedVectorImageView.EndActions.Cancel);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsCancel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView Stop. EndAction is Discard.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewStopAsDiscard()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsDiscard START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.ResourceUrl = url;

            testingTarget.Play();

            try
            {
                testingTarget.Stop(AnimatedVectorImageView.EndActions.Discard);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsDiscard END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedVectorImageView Stop. EndAction is StopFinal.")]
        [Property("SPEC", "Tizen.NUI.AnimatedVectorImageView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedVectorImageViewStopAsStopFinal()
        {
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsStopFinal START");

            var testingTarget = new AnimatedVectorImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedVectorImageView");
            Assert.IsInstanceOf<AnimatedVectorImageView>(testingTarget, "Should be an instance of AnimatedVectorImageView type.");

            testingTarget.ResourceUrl = url;

            testingTarget.Play();

            try
            {
                testingTarget.Stop(AnimatedVectorImageView.EndActions.StopFinal);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedVectorImageViewStopAsStopFinal END (OK)");
        }
    }
}
