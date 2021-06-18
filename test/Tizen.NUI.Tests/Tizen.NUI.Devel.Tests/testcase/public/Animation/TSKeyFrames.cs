using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/KeyFrames")]
    public class PublicKeyFramesTest
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
        [Description("KeyFrames constructor")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.KeyFrames C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesConstructor()
        {
            tlog.Debug(tag, $"KeyFramesConstructor START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyFrames Add. Add a key frame with object value ")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesAddWithObject()
        {
            tlog.Debug(tag, $"KeyFramesAddWithObject START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            Position pos = new Position(10.0f, 20.0f, 30.0f);
            testingTarget.Add(0.3f, pos);

            var result = testingTarget.GetType().ToString();
            Assert.IsTrue("Vector3" == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesAddWithObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyFrames Add. Add a key frame with object value and alpha function")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesAddWithObjectAndAlphaFunc()
        {
            tlog.Debug(tag, $"KeyFramesAddWithObjectAndAlphaFunc START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            Position pos = new Position(10.0f, 20.0f, 30.0f);
            AlphaFunction linear = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
            try
            {
                testingTarget.Add(0.3f, pos, linear);
                Assert.IsTrue("Vector3" == testingTarget.GetType().ToString());
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            pos.Dispose();
            linear.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesAddWithObjectAndAlphaFunc END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyFrames GetType")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesGetType()
        {
            tlog.Debug(tag, $"KeyFramesGetType START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            Color color = Color.Yellow;
            testingTarget.Add(0.3f, color);

            var result = testingTarget.GetType().ToString();
            Assert.IsTrue("Vector4" == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyFrames Add. Add a key frame with property value ")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesAddWithPropertyValue()
        {
            tlog.Debug(tag, $"KeyFramesAddWithPropertyValue START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            PropertyValue dummy = new PropertyValue(true);
            testingTarget.Add(0.3f, dummy);

            var result = testingTarget.GetType().ToString();
            Assert.IsTrue("Boolean" == result);

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesAddWithPropertyValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyFrames Add. Add a key frame with object property and alpha function")]
        [Property("SPEC", "Tizen.NUI.KeyFrames.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyFramesAddWithPropertyValueAndAlphaFunc()
        {
            tlog.Debug(tag, $"KeyFramesAddWithPropertyValueAndAlphaFunc START");

            var testingTarget = new KeyFrames();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<KeyFrames>(testingTarget, "should be an instance of KeyFrames class!");

            PropertyValue dummy = new PropertyValue(true);
            AlphaFunction ease = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut);
            try
            {
                testingTarget.Add(0.3f, dummy, ease);
                Assert.IsTrue("Boolean" == testingTarget.GetType().ToString());
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            dummy.Dispose();
            ease.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyFramesAddWithPropertyValueAndAlphaFunc END (OK)");
        }
    }
}
