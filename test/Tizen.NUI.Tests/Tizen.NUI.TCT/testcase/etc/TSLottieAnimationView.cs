using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using L = Tizen.Log;

    [TestFixture]
    public class LottieAnimationViewTests
    {
        private string tag = "NUITEST";
        private string lottieFilePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private bool finishedCheck = false;

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Destroy()
        {
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("LottieAnimationView constructor test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.LottieAnimationView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void LottieAnimationView_INIT()
        {
            L.Debug(tag, $" LottieAnimationView_INIT() ");

            var lottie = new LottieAnimationView();
            Assert.IsNotNull(lottie, "null handle");
            Assert.IsInstanceOf<LottieAnimationView>(lottie, "should be LottieAnimationView instance.");

            var lottie2 = new LottieAnimationView(2.0f);
            Assert.IsNotNull(lottie2, "null handle");
            Assert.IsInstanceOf<LottieAnimationView>(lottie2, "should be LottieAnimationView instance.");

            var lottie3 = new LottieAnimationView(3.0f, false);
            Assert.IsNotNull(lottie3, "null handle");
            Assert.IsInstanceOf<LottieAnimationView>(lottie3, "should be LottieAnimationView instance.");

            lottie.Dispose();
            lottie2.Dispose();
            lottie3.Dispose();
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("URL test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task URL_SET_GET_VALUE()
        {
            L.Debug(tag, $" URL_SET_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            Assert.IsTrue(lottieFilePath + "/lottie.json" == lottie.URL, "should be same as previously set value");

            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("PlayState test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.PlayState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PR0")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task PlayState_GET_VALUE()
        {
            L.Debug(tag, $" PlayState_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            // PlayStateType.Invalid is impossible to check and test. the state comes from dali native but it never gives Invalid value. it is reserved enum for the future change.

            lottie.Play();
            await Task.Delay(100);
            Assert.IsTrue(lottie.PlayState == LottieAnimationView.PlayStateType.Playing, "should be same as previously set value");

            lottie.Pause();
            await Task.Delay(100);

            Assert.IsTrue(lottie.PlayState == LottieAnimationView.PlayStateType.Paused, "should be same as previously set value");

            lottie.Stop();
            await Task.Delay(100);

            Assert.IsTrue(lottie.PlayState == LottieAnimationView.PlayStateType.Stopped, "should be same as previously set value");

            // PlayStateType.Invalid is impossible to check and test. the state comes from dali native but it never gives Invalid value. it is reserved enum for the future change.
            L.Debug(tag, $"if some fail comes above, this will be not be shown!");

            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("TotalFrame test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.TotalFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task TotalFrame_GET_VALUE()
        {
            L.Debug(tag, $" TotalFrame_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            lottie.Stop();
            const int fixedTotalFrameOfLottieFile = 124; // this 124 value is fixed one, that is lottie.json file were created as 124 frames originally. obviously it varies by lottile resource file.

            L.Debug(tag, $"total frame={lottie.TotalFrame}");
            // this 124 value is fixed one, that is lottie.json file were created as 124 frames originally. obviously it varies by lottile resource file.
            Assert.IsTrue(fixedTotalFrameOfLottieFile == lottie.TotalFrame, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("CurrentFrame test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.CurrentFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task CurrentFrame_SET_GET_VALUE()
        {
            L.Debug(tag, $" CurrentFrame_SET_GET_VALUE() ");

            var lottie = new LottieAnimationView();

            lottie.URL = lottieFilePath + "/lottie.json";

            NUIApplication.GetDefaultWindow().Add(lottie);

            var current = 3;
            lottie.CurrentFrame = current;
            await Task.Delay(1000);
            Assert.IsTrue(current == lottie.CurrentFrame, "should be same as previously set value");

            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);

        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("LoopingMode test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.LoopingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task LoopingMode_SET_GET_VALUE()
        {
            L.Debug(tag, $" LoopingMode_SET_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            var loopingMode = LottieAnimationView.LoopingModeType.AutoReverse;
            lottie.LoopingMode = loopingMode;
            Assert.IsTrue(loopingMode == lottie.LoopingMode);

            loopingMode = LottieAnimationView.LoopingModeType.Restart;
            lottie.LoopingMode = loopingMode;
            Assert.IsTrue(loopingMode == lottie.LoopingMode);

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("LoopCount test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task LoopCount_SET_GET_VALUE()
        {
            L.Debug(tag, $" LoopCount_SET_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie2.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            var loopCount = -1;
            lottie.LoopCount = loopCount;
            Assert.IsTrue(loopCount == lottie.LoopCount, "should be same as previously set value");

            loopCount = 7;
            lottie.LoopCount = loopCount;
            Assert.IsTrue(loopCount == lottie.LoopCount, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("StopBehavior test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.StopBehavior A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task StopBehavior_SET_GET_VALUE()
        {
            L.Debug(tag, $" StopBehavior_SET_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            var stopBehavior = LottieAnimationView.StopBehaviorType.MaximumFrame;

            lottie.StopBehavior = stopBehavior;
            Assert.IsTrue(stopBehavior == lottie.StopBehavior, "should be same as previously set value");

            stopBehavior = LottieAnimationView.StopBehaviorType.CurrentFrame;
            lottie.StopBehavior = stopBehavior;
            Assert.IsTrue(stopBehavior == lottie.StopBehavior, "should be same as previously set value");

            stopBehavior = LottieAnimationView.StopBehaviorType.MinimumFrame;
            lottie.StopBehavior = stopBehavior;
            Assert.IsTrue(stopBehavior == lottie.StopBehavior, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("RedrawInScalingDown test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.RedrawInScalingDown A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task RedrawInScalingDown_SET_GET_VALUE()
        {
            L.Debug(tag, $" RedrawInScalingDown_SET_GET_VALUE() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            var redraw = false;

            lottie.RedrawInScalingDown = redraw;
            Assert.IsTrue(redraw == lottie.RedrawInScalingDown, "should be same as previously set value");

            redraw = true;
            lottie.RedrawInScalingDown = redraw;
            Assert.IsTrue(redraw == lottie.RedrawInScalingDown, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("SetMinMaxFrame test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.SetMinMaxFrame M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MAR")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task SetMinMaxFrame_CHECK()
        {
            L.Debug(tag, $" SetMinMaxFrame_CHECK() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            var min = 5;
            var max = 9;
            lottie.SetMinMaxFrame(min, max);
            await Task.Delay(300);

            lottie.StopBehavior = LottieAnimationView.StopBehaviorType.MinimumFrame;
            lottie.Play();
            await Task.Delay(300);
            L.Debug(tag, $"1. stop behavior ={lottie.StopBehavior} total frame={lottie.TotalFrame}");
            lottie.Stop();
            await Task.Delay(300);

            L.Debug(tag, $"2. current frame={lottie.CurrentFrame}, min={min}, max={max}");
            Assert.IsTrue(min == lottie.CurrentFrame, "should be same as previously set value");

            lottie.StopBehavior = LottieAnimationView.StopBehaviorType.MaximumFrame;
            lottie.Play();
            await Task.Delay(300);
            L.Debug(tag, $"2-1. stop behavior ={lottie.StopBehavior}");
            lottie.Stop();
            await Task.Delay(300);

            L.Debug(tag, $"3. current frame={lottie.CurrentFrame}, min={min}, max={max}");
            Assert.IsTrue(max == lottie.CurrentFrame, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");

            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Play test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task Play_CHECK()
        {
            L.Debug(tag, $" Play_CHECK() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            lottie.LoopCount = -1;
            lottie.Play();
            await Task.Delay(100);

            L.Debug(tag, $"state={lottie.PlayState}");
            Assert.IsTrue(LottieAnimationView.PlayStateType.Playing == lottie.PlayState, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Pause test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.Pause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task Pause_CHECK()
        {
            L.Debug(tag, $" Pause_CHECK() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            lottie.LoopCount = -1;
            lottie.Play();
            await Task.Delay(100);

            lottie.Pause();
            await Task.Delay(100);

            L.Debug(tag, $"state={lottie.PlayState}, delay 100ms");
            Assert.IsTrue(LottieAnimationView.PlayStateType.Paused == lottie.PlayState, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Stop test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task Stop_CHECK()
        {
            L.Debug(tag, $" Stop_CHECK() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            lottie.LoopCount = -1;
            lottie.Play();
            lottie.Stop();
            await Task.Delay(100);

            L.Debug(tag, $"state={lottie.PlayState}");
            Assert.IsTrue(LottieAnimationView.PlayStateType.Stopped == lottie.PlayState, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("GetContentInfo test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.GetContentInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task GetContentInfo_CHECK()
        {
            L.Debug(tag, $" GetContentInfo_CHECK() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            // this content info values are fixed ones, that were written in lottie.json file created as like that originally. obviously these vary by lottile resource file.
            const string firstContentInfo = ".chris-gannon-instagram-lottie";
            const int secondContentInfo = 0;
            const int thirdContentInfo = 124;

            var fixedContentInfoOfLottieFile = lottie.GetContentInfo();

            // this content info values are fixed ones, that were written in lottie.json file created as like that originally. obviously these vary by lottile resource file.
            Assert.IsTrue(fixedContentInfoOfLottieFile[0].Item1 == firstContentInfo, "should be same as previously set value");
            Assert.IsTrue(fixedContentInfoOfLottieFile[0].Item2 == secondContentInfo, "should be same as previously set value");
            Assert.IsTrue(fixedContentInfoOfLottieFile[0].Item3 == thirdContentInfo, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("Finished test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.Finished E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task Finished_CHECK_EVENT()
        {
            L.Debug(tag, $" Finished_CHECK_EVENT() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie2.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            await Task.Delay(500);

            finishedCheck = false;
            lottie.LoopCount = 1;
            lottie.Finished += Lottie_Finished;

            lottie.Play();

            L.Debug(tag, $"1. playState={lottie.PlayState}");
            var lottieFilesPlayDuration = 2000;
            await Task.Delay(lottieFilesPlayDuration);

            L.Debug(tag, $"2. playState={lottie.PlayState}");
            if (lottie.PlayState != LottieAnimationView.PlayStateType.Stopped)
            {
                L.Debug(tag, $"3. it's not yet stopped! playState={lottie.PlayState}, stop here again.");
                lottie.Stop();
                await Task.Delay(1000);
                L.Debug(tag, $"4. it's not yet stopped! playState={lottie.PlayState}, stop here again.");
            }
            Assert.IsTrue(finishedCheck, $"should be same as previously set value, state={lottie.PlayState}");

            L.Debug(tag, $"5. playState={lottie.PlayState}");

            lottie.Finished -= Lottie_Finished;
            lottie.Unparent();
            lottie.Dispose();
            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }

        private void Lottie_Finished(object sender, EventArgs e)
        {
            L.Debug(tag, $"Finished callback came!");
            finishedCheck = true;
        }

#if (EXAMPLE)
        [Test]
#endif
        [Category("P1")]
        [Description("RedrawInScalingDown animation test")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.LottieAnimationView.RedrawInScalingDown A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public async Task RedrawInScalingDown_AnimationTest()
        {
            L.Debug(tag, $" RedrawInScalingDown_AnimationTest() ");
            await Task.Delay(500);

            var lottie = new LottieAnimationView();
            var lottieRedrawTrue = new LottieAnimationView();
            await Task.Delay(500);

            lottie.URL = lottieFilePath + "/lottie.json";
            lottieRedrawTrue.URL = lottieFilePath + "/lottie.json";
            await Task.Delay(500);

            NUIApplication.GetDefaultWindow().Add(lottie);
            NUIApplication.GetDefaultWindow().Add(lottieRedrawTrue);
            await Task.Delay(500);

            lottie.Size = new Size(1000, 1000);
            lottie.Position = new Position(0, 0);
            lottie.LoopCount = -1;
            lottie.Play();

            lottieRedrawTrue.Size = new Size(1000, 1000);
            lottieRedrawTrue.Position = new Position(1000, 10);
            lottieRedrawTrue.LoopCount = -1;
            lottieRedrawTrue.Play();

            await Task.Delay(1000);

            var redraw = false;
            var redraw2 = true;
            lottie.RedrawInScalingDown = redraw;
            lottieRedrawTrue.RedrawInScalingDown = redraw2;

            for (int i = 1000; i > 100; i -= 10)
            {
                lottie.Size = new Size(i, i, 0);
                lottieRedrawTrue.Size = new Size(i, i, 0);
                await Task.Delay(100);
            }

            await Task.Delay(9000);

            Assert.IsTrue(redraw == lottie.RedrawInScalingDown, "should be same as previously set value");
            Assert.IsTrue(redraw2 == lottieRedrawTrue.RedrawInScalingDown, "should be same as previously set value");

            L.Debug(tag, $"if some fail comes above, this will be not be shown!");
            lottie.Unparent();
            lottie.Dispose();

            lottieRedrawTrue.Unparent();
            lottieRedrawTrue.Dispose();

            L.Debug(tag, $"lottie.Dispose() called");
            await Task.Delay(500);
        }
    }
}
