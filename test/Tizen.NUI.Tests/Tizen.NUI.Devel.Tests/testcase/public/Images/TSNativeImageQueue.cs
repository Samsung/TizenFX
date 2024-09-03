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
    [Description("public/Images/NativeImageQueue")]
    public class PublicNativeImageQueueTest
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
        [Description("NativeImageQueue constructor.")]
        [Property("SPEC", "Tizen.NUI.NativeImageQueue.NativeImageQueue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void NativeImageQueueConstructor()
        {
            tlog.Debug(tag, $"NativeImageQueueConstructor START");

            try
			{
                var testingTarget = new NativeImageQueue(100, 50, NativeImageQueue.ColorFormat.BGRA8888);
                Assert.IsNotNull(testingTarget, "Can't create success object NativeImageQueue");
                Assert.IsInstanceOf<NativeImageQueue>(testingTarget, "Should be an instance of NativeImageQueue type.");
            
                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"NativeImageQueueConstructor END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("NativeImageQueue GenerateUrl.")]
        [Property("SPEC", "Tizen.NUI.NativeImageQueue.GenerateUrl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageQueueGenerateUrl()
        {
            tlog.Debug(tag, $"NativeImageQueueGenerateUrl START");

            try
			{
                var testingTarget = new NativeImageQueue(100, 50, NativeImageQueue.ColorFormat.BGRA8888);
                Assert.IsNotNull(testingTarget, "Can't create success object NativeImageQueue");
                Assert.IsInstanceOf<NativeImageQueue>(testingTarget, "Should be an instance of NativeImageQueue type.");

                var result = testingTarget.GenerateUrl();
                Assert.IsInstanceOf<ImageUrl>(result, "Should be an instance of ImageUrl type.");

                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            tlog.Debug(tag, $"NativeImageQueueGenerateUrl END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("NativeImageQueue CanDequeueBuffer.")]
        [Property("SPEC", "Tizen.NUI.NativeImageQueue.CanDequeueBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageQueueCanDequeueBuffer()
        {
            tlog.Debug(tag, $"NativeImageQueueCanDequeueBuffer START");

            try
			{
                var testingTarget = new NativeImageQueue(100, 50, NativeImageQueue.ColorFormat.BGRA8888);
                Assert.IsNotNull(testingTarget, "Can't create success object NativeImageQueue");
                Assert.IsInstanceOf<NativeImageQueue>(testingTarget, "Should be an instance of NativeImageQueue type.");
          
                var result = testingTarget.CanDequeueBuffer();
                tlog.Debug(tag, "CanDequeueBuffer : " + result);           

                testingTarget.Dispose();
			}
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            tlog.Debug(tag, $"NativeImageQueueCanDequeueBuffer END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("NativeImageQueue DequeueBuffer.")]
        [Property("SPEC", "Tizen.NUI.NativeImageQueue.DequeueBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void NativeImageQueueDequeueBuffer()
        {
            tlog.Debug(tag, $"NativeImageQueueDequeueBuffer START");

            var testingTarget = new NativeImageQueue(100, 50, NativeImageQueue.ColorFormat.BGRA8888);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageQueue");
            Assert.IsInstanceOf<NativeImageQueue>(testingTarget, "Should be an instance of NativeImageQueue type.");

            try
            {
                int width = 4, height = 2, stride = 4;
                testingTarget.DequeueBuffer(ref width, ref height, ref stride);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"NativeImageQueueDequeueBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageQueue EnqueueBuffer.")]
        [Property("SPEC", "Tizen.NUI.NativeImageQueue.EnqueueBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void NativeImageQueueEnqueueBuffer()
        {
            tlog.Debug(tag, $"NativeImageQueueEnqueueBuffer START");

            var testingTarget = new NativeImageQueue(100, 50, NativeImageQueue.ColorFormat.BGRA8888);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageQueue");
            Assert.IsInstanceOf<NativeImageQueue>(testingTarget, "Should be an instance of NativeImageQueue type.");

            try
            {
                if (testingTarget.CanDequeueBuffer())
                {
                    int width = 4, height = 2, stride = 4;
                    var buffer = testingTarget.DequeueBuffer(ref width, ref height, ref stride);
                    testingTarget.EnqueueBuffer(buffer);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageQueueEnqueueBuffer END (OK)");
        }
    }
}