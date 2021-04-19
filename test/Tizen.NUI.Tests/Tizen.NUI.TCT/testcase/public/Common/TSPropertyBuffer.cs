using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyBuffer")]
    class PublicPropertyBufferTest
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
        [Description("PropertyBuffer constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.PropertyBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyBufferConstructor()
        {
            tlog.Debug(tag, $"PropertyBufferConstructor START");

            PropertyMap buffer = new PropertyMap();
            Assert.IsNotNull(buffer, "should be not null");
            Assert.IsInstanceOf<PropertyMap>(buffer, "should be an instance of PropertyMap class!");
            buffer.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            buffer.Add("aValue", new PropertyValue((int)PropertyType.Float));

            var testingTarget = new PropertyBuffer(buffer);
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyBuffer");
            Assert.IsInstanceOf<PropertyBuffer>(testingTarget, "Should be an instance of PropertyBuffer class!");

            testingTarget.Dispose();
            buffer.Dispose();
            tlog.Debug(tag, $"PropertyBufferConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyBuffer GetSize")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.GetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyBufferGetSize()
        {
            tlog.Debug(tag, $"PropertyBufferGetSize START");

            PropertyMap buffer = new PropertyMap();
            Assert.IsNotNull(buffer, "should be not null");
            Assert.IsInstanceOf<PropertyMap>(buffer, "should be an instance of PropertyMap class!");
            buffer.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            buffer.Add("aValue", new PropertyValue((int)PropertyType.Float));

            var testingTarget = new PropertyBuffer(buffer);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyBuffer>(testingTarget, "Should be an instance of PropertyBuffer class!");
            Assert.AreEqual(0, testingTarget.GetSize(), "Should be Equal.");

            testingTarget.Dispose();
            buffer.Dispose();
            tlog.Debug(tag, $"PropertyBufferGetSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyBuffer SetData")]
        [Property("SPEC", "Tizen.NUI.PropertyBuffer.SetData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyBufferSetData()
        {
            tlog.Debug(tag, $"PropertyBufferSetData START");

            PropertyMap buffer = new PropertyMap();
            Assert.IsNotNull(buffer, "should be not null");
            Assert.IsInstanceOf<PropertyMap>(buffer, "should be an instance of PropertyMap class!");
            buffer.Add("aIndex", new PropertyValue((int)PropertyType.Float));
            buffer.Add("aValue", new PropertyValue((int)PropertyType.Float));

            var testingTarget = new PropertyBuffer(buffer);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<PropertyBuffer>(testingTarget, "Should be an instance of PropertyBuffer class!");
            try
            {
                global::System.IntPtr data = new global::System.IntPtr();
                testingTarget.SetData(data, 0);
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            Assert.AreEqual(0, testingTarget.GetSize(), "Should be Equal.");

            testingTarget.Dispose();
            buffer.Dispose();
            tlog.Debug(tag, $"PropertyBufferSetData END (OK)");
        }
    }
}
