using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/KeyFrames")]
    public class InternalKeyFramesTests
    {
        private string tag = "NUITEST";

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
        [Description("Test GetKeyFrameCount. Check whether it return the right value.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.GetKeyFrameCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void GetKeyFrameCount_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            var keyFrames = new KeyFrames();
            Assert.AreEqual(0u, keyFrames.GetKeyFrameCount(), "The number of keyframes must be matched.");
            keyFrames.Add(0.0f, new Position(0.1f, 0.2f, 0.3f));
            Assert.AreEqual(1u, keyFrames.GetKeyFrameCount(), "The number of keyframes must be matched.");
            keyFrames.Add(0.5f, new Position(0.9f, 0.8f, 0.7f));
            Assert.AreEqual(2u, keyFrames.GetKeyFrameCount(), "The number of keyframes must be matched.");
            keyFrames.Add(1.0f, new Position(1.0f, 1.0f, 1.0f));
            Assert.AreEqual(3u, keyFrames.GetKeyFrameCount(), "The number of keyframes must be matched.");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetKeyFrame. Check whether it return the right value.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.GetKeyFrame M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void GetKeyFrame_GET_VALUE()
        {
            /* TEST CODE */
            var keyFrames = new KeyFrames();
            float returnProgress = -1.0f;
            PropertyValue returnValue = new PropertyValue();
            float returnValueFloat = -1.0f;

            keyFrames.GetKeyFrame(2u, out returnProgress, returnValue);
            Assert.AreEqual(false, returnValue.Get(out returnValueFloat), "The value of keyframes must not be float.");
            Assert.AreEqual(-1.0f, returnProgress, "The value of keyframes must be changed.");

            keyFrames.Add(0.0f, 2.0f);
            keyFrames.Add(0.5f, 4.0f);
            keyFrames.Add(1.0f, 7.0f);

            keyFrames.GetKeyFrame(0u, out returnProgress, returnValue);
            Assert.AreEqual(true, returnValue.Get(out returnValueFloat), "The value of keyframes must be float.");
            Assert.AreEqual(0.0f, returnProgress, "The value of keyframes must be matched.");
            Assert.AreEqual(2.0f, returnValueFloat, "The value of keyframes must be matched.");

            keyFrames.GetKeyFrame(1u, out returnProgress, returnValue);
            Assert.AreEqual(true, returnValue.Get(out returnValueFloat), "The value of keyframes must be float.");
            Assert.AreEqual(0.5f, returnProgress, "The value of keyframes must be matched.");
            Assert.AreEqual(4.0f, returnValueFloat, "The value of keyframes must be matched.");

            keyFrames.GetKeyFrame(2u, out returnProgress, returnValue);
            Assert.AreEqual(true, returnValue.Get(out returnValueFloat), "The value of keyframes must be float.");
            Assert.AreEqual(1.0f, returnProgress, "The value of keyframes must be matched.");
            Assert.AreEqual(7.0f, returnValueFloat, "The value of keyframes must be matched.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetKeyFrameValue. Check whether it setup the right value.")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.SetKeyFrameValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void SetKeyFrameValue_SET_VALUE()
        {
            /* TEST CODE */
            var keyFrames = new KeyFrames();
            float returnProgress = -1.0f;
            PropertyValue returnValue = new PropertyValue();
            float returnValueFloat = -1.0f;

            keyFrames.SetKeyFrameValue(1u, new PropertyValue(3.0f));

            keyFrames.Add(0.0f, 2.0f);
            keyFrames.Add(0.5f, 4.0f);
            keyFrames.Add(1.0f, 7.0f);

            keyFrames.GetKeyFrame(1u, out returnProgress, returnValue);
            Assert.AreEqual(true, returnValue.Get(out returnValueFloat), "The value of keyframes must be float.");
            Assert.AreEqual(0.5f, returnProgress, "The value of keyframes must be matched.");
            Assert.AreEqual(4.0f, returnValueFloat, "The value of keyframes must be matched.");

            keyFrames.SetKeyFrameValue(1u, new PropertyValue(1.0f));

            keyFrames.GetKeyFrame(1u, out returnProgress, returnValue);
            Assert.AreEqual(true, returnValue.Get(out returnValueFloat), "The value of keyframes must be float.");
            Assert.AreEqual(0.5f, returnProgress, "The value of keyframes must be matched.");
            Assert.AreEqual(1.0f, returnValueFloat, "The value of keyframes must be matched.");
        }
    }
}
