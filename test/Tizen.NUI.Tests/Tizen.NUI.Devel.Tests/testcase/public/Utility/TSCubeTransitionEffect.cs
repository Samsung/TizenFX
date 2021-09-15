using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/CubeTransitionEffect")]
    class PublicCubeTransitionEffectTest
    {
        private const string tag = "NUITEST";
        private string currentpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string targetpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        private bool OnTransitionCompletedFlag = false;

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
        [Description("CubeTransitionEffect SetTransitionDuration / GetTransitionDuration.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.SetTransitionDuration / GetTransitionDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectTransitionDuration()
        {
            tlog.Debug(tag, $"CubeTransitionEffectTransitionDuration START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.SetTransitionDuration(1.5f);

            var result = testingTarget.GetTransitionDuration();
            Assert.AreEqual(1.5f, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectTransitionDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect SetCubeDisplacement / GetCubeDisplacement.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.SetCubeDisplacement / GetCubeDisplacement M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectCubeDisplacement()
        {
            tlog.Debug(tag, $"CubeTransitionEffectCubeDisplacement START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.SetCubeDisplacement(70.0f);

            var result = testingTarget.GetCubeDisplacement();
            Assert.AreEqual(70.0f, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectCubeDisplacement END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect IsTransitioning.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.IsTransitioning M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectIsTransitioning()
        {
            tlog.Debug(tag, $"CubeTransitionEffectIsTransitioning START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            var result = testingTarget.IsTransitioning();
            Assert.AreEqual(false, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectIsTransitioning END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect SetCurrentTexture.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.SetCurrentTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectSetCurrentTexture()
        {
            tlog.Debug(tag, $"CubeTransitionEffectSetCurrentTexture START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            try
            {
                testingTarget.SetCurrentTexture(LoadStageFillingTexture(currentpath));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectSetCurrentTexture END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect SetTargetTexture.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.SetTargetTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectSetTargetTexture()
        {
            tlog.Debug(tag, $"CubeTransitionEffectSetTargetTexture START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            try
            {
                testingTarget.SetTargetTexture(LoadStageFillingTexture(targetpath));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectSetTargetTexture END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect StartTransition.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.StartTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectStartTransition()
        {
            tlog.Debug(tag, $"CubeTransitionEffectStartTransition START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.SetTransitionDuration(1.5f);

            testingTarget.SetCurrentTexture(LoadStageFillingTexture(currentpath));
            testingTarget.SetTargetTexture(LoadStageFillingTexture(targetpath));

            try
            {
                testingTarget.StartTransition(true);
                testingTarget.PauseTransition();
                testingTarget.ResumeTransition();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget?.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectStartTransition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffect TransitionCompleted.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffect.TransitionCompleted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectTransitionCompleted()
        {
            tlog.Debug(tag, $"CubeTransitionEffectTransitionCompleted START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            try
            {
                testingTarget.TransitionCompleted += OnCubeEffectCompleted;
                testingTarget.TransitionCompleted -= OnCubeEffectCompleted;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectTransitionCompleted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffectSignal  GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffectSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"CubeTransitionEffectSignalGetConnectionCount START");

            var testingTarget = new CubeTransitionEffectSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffectSignal");
            Assert.IsInstanceOf<CubeTransitionEffectSignal>(testingTarget, "Should be an instance of CubeTransitionEffectSignal type.");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionEffectSignal  Emit.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionEffectSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionEffectSignalEmit()
        {
            tlog.Debug(tag, $"CubeTransitionEffectSignalEmit START");

            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new CubeTransitionEffectSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffectSignal");
            Assert.IsInstanceOf<CubeTransitionEffectSignal>(testingTarget, "Should be an instance of CubeTransitionEffectSignal type.");

            using (CubeTransitionEffect effect =  new CubeTransitionCrossEffect(10, 8))
            { 
                testingTarget.Emit(effect); 
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionEffectSignalEmit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionWaveEffect constructor.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionWaveEffect.CubeTransitionWaveEffect C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionWaveEffectConstructor()
        {
            tlog.Debug(tag, $"CubeTransitionWaveEffectConstructor START");

            var testingTarget = new CubeTransitionWaveEffect(20, 10);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionWaveEffectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionCrossEffect constructor.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionCrossEffect.CubeTransitionCrossEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionCrossEffectConstructor()
        {
            tlog.Debug(tag, $"CubeTransitionCrossEffectConstructor START");

            var testingTarget = new CubeTransitionCrossEffect(10, 8);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionCrossEffectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CubeTransitionFoldEffect constructor.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionFoldEffect.CubeTransitionFoldEffect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CubeTransitionFoldEffectConstructor()
        {
            tlog.Debug(tag, $"CubeTransitionFoldEffectConstructor START");

            var testingTarget = new CubeTransitionFoldEffect(10, 8);
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<CubeTransitionEffect>(testingTarget, "Should be an instance of CubeTransitionEffect type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CubeTransitionFoldEffectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionCompletedEventArgs CubeTransitionEffect.")]
        [Property("SPEC", "Tizen.NUI.CubeTransitionFoldEffect.TransitionCompletedEventArgs CubeTransitionEffect A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionCompletedEventArgsCubeTransitionEffect()
        {
            tlog.Debug(tag, $"TransitionCompletedEventArgsCubeTransitionEffect START");

            var testingTarget = new Tizen.NUI.CubeTransitionEffect.TransitionCompletedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object CubeTransitionEffect");
            Assert.IsInstanceOf<Tizen.NUI.CubeTransitionEffect.TransitionCompletedEventArgs>(testingTarget, "Should be an instance of TransitionCompletedEventArgs type.");

            using (CubeTransitionWaveEffect effect = new CubeTransitionWaveEffect(20, 10))
            {
                testingTarget.CubeTransitionEffect = effect;
                tlog.Debug(tag, "CubeTransitionEffect : " + testingTarget.CubeTransitionEffect);
            }

            using (Texture texture = new Texture(new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Bits16)))
            {
                testingTarget.CubeTransitonTexture = texture;
                tlog.Debug(tag, "CubeTransitonTexture : " + testingTarget.CubeTransitonTexture);
            }

            tlog.Debug(tag, $"TransitionCompletedEventArgsCubeTransitionEffect END (OK)");
        }

        private void OnCubeEffectCompleted(object sender, CubeTransitionEffect.TransitionCompletedEventArgs args)
        {
            OnTransitionCompletedFlag = true;
        }

        private Texture LoadStageFillingTexture(string filepath)
        {
            Size2D dimensions = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height);
            PixelBuffer pb = ImageLoading.LoadImageFromFile(filepath, dimensions, FittingModeType.ScaleToFill);
            PixelData pd = PixelBuffer.Convert(pb);

            Texture texture = new Texture(TextureType.TEXTURE_2D, pd.GetPixelFormat(), pd.GetWidth(), pd.GetHeight());
            texture.Upload(pd);

            return texture;
        }
    }
}
