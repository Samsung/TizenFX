using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/VideoView ")]
    public class PublicBaseComponentsVideoViewTest
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
        [Description("VideoView  constructor.")]
        [Property("SPEC", "Tizen.NUI.VideoView .VideoView  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewConstructor()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewConstructor START");

            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");
            
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewConstructor END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("VideoView  Finished.")]
        [Property("SPEC", "Tizen.NUI.VideoView .Finished  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewFinished()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewFinished START");
            
            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");
            
			    testingTarget.Finished += OnFinished;
			    testingTarget.Finished -= OnFinished;
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewFinished END (OK)");
        }		

		[Test]
        [Category("P1")]
        [Description("VideoView  FinishedSignal.")]
        [Property("SPEC", "Tizen.NUI.VideoView .FinishedSignal  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewFinishedSignal()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewFinishedSignal START");
            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");
            
			    testingTarget.FinishedSignal();
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewFinishedSignal END (OK)");
        }


		[Test]
        [Category("P1")]
        [Description("VideoView  Underlay.")]
        [Property("SPEC", "Tizen.NUI.VideoView .Underlay  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewUnderlay()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewUnderlay START");
            
            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");

                testingTarget.Underlay = true;
			    var result = testingTarget.Underlay;
                Assert.IsTrue(testingTarget.Underlay);
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            
            tlog.Debug(tag, $"publicBaseComponentsVideoViewUnderlay END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("VideoView  Volume.")]
        [Property("SPEC", "Tizen.NUI.VideoView .Volume  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewVolume()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewVolume START");

            try
            {
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");

                PropertyMap volumeMap = new PropertyMap();
                volumeMap.Add("left", new PropertyValue(50.0f));
                volumeMap.Add("right", new PropertyValue(60.0f));

                testingTarget.Volume = volumeMap;

                var resultMap = testingTarget.Volume;
                var result = resultMap.Find(-1, "volumeRight").Get(out float value);
                Assert.IsTrue(result);

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewVolume END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("VideoView Muted.")]
        [Property("SPEC", "Tizen.NUI.VideoView .Muted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewMuted()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewMuted START");

            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");

                testingTarget.Muted = true;
                tlog.Debug(tag, "Muted : " + testingTarget.Muted);
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: Failed!");
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewMuted END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("VideoView  Looping.")]
        [Property("SPEC", "Tizen.NUI.VideoView .Looping  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewLooping()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewLooping START");

            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");

                testingTarget.Looping = true;
                tlog.Debug(tag, "Looping : " + testingTarget.Looping);
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: Failed!");
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewLooping END (OK)");
        }		
		
		[Test]
        [Category("P1")]
        [Description("VideoView  NativeHandle.")]
        [Property("SPEC", "Tizen.NUI.VideoView .NativeHandle  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentsVideoViewNativeHandle()
        {
            tlog.Debug(tag, $"publicBaseComponentsVideoViewNativeHandle START");

            try
			{
                var testingTarget = new VideoView();
                Assert.IsNotNull(testingTarget, "Can't create success object VideoView ");
                Assert.IsInstanceOf<VideoView>(testingTarget, "Should be an instance of VideoView  type.");
            
			    var result = testingTarget.NativeHandle;
                Assert.IsInstanceOf<SafeHandle>(result, "Should be an instance of SafeHandle");
			
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"publicBaseComponentsVideoViewNativeHandle END (OK)");
        }				
		
		public void OnFinished(object sender, VideoView.FinishedEventArgs e) { }
	}
}