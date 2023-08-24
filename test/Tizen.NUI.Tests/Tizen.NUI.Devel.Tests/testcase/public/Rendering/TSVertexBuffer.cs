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
    [Description("public/Rendering/VertexBuffer")]
    public class PublicVertexBufferTest
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
        [Description("VertexBuffer constructor.")]
        [Property("SPEC", "Tizen.NUI.VertexBuffer.VertexBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VertexBufferConstructor()
        {
            tlog.Debug(tag, $"VertexBufferConstructor START");

            using (PropertyMap vertexFormat = new PropertyMap())
            {
                vertexFormat.Add("aPositionCircle", new PropertyValue((int)PropertyType.Vector2));
                
                var testingTarget = new VertexBuffer(vertexFormat);
                Assert.IsNotNull(testingTarget, "Return a null object of VertexBuffer");
                Assert.IsInstanceOf<VertexBuffer>(testingTarget, "Should be an instance of VertexBuffer type.");
				
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VertexBufferConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VertexBuffer SetData.")]
        [Property("SPEC", "Tizen.NUI.VertexBuffer.SetData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VertexBufferSetData()
        {
            tlog.Debug(tag, $"VertexBufferSetData START");

            using (PropertyMap vertexFormat = new PropertyMap())
            {
                vertexFormat.Add("aPositionCircle", new PropertyValue((int)PropertyType.Vector2));

                var testingTarget = new VertexBuffer(vertexFormat);
                Assert.IsNotNull(testingTarget, "Return a null object of VertexBuffer");
                Assert.IsInstanceOf<VertexBuffer>(testingTarget, "Should be an instance of VertexBuffer type.");

                Int32[] val = new Int32[2] { 100, 50 };
                try
                {
                    testingTarget.SetData(val);
                    var result = testingTarget.GetSize();
                    Assert.AreEqual(2, result, "Should be equal!");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VertexBufferSetData END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("VertexBuffer SetData.")]
        [Property("SPEC", "Tizen.NUI.VertexBuffer.SetData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VertexBufferSetDataNullValue()
        {
            tlog.Debug(tag, $"VertexBufferSetDataNullValue START");

            using (PropertyMap vertexFormat = new PropertyMap())
            {
                vertexFormat.Add("aPositionCircle", new PropertyValue((int)PropertyType.Vector2));

                var testingTarget = new VertexBuffer(vertexFormat);
                Assert.IsNotNull(testingTarget, "Return a null object of VertexBuffer");
                Assert.IsInstanceOf<VertexBuffer>(testingTarget, "Should be an instance of VertexBuffer type.");

                Int32[] val = null;
                try
                {
                    testingTarget.SetData(val);
                }
                catch (ArgumentNullException)
                {
                    testingTarget.Dispose();
                    tlog.Debug(tag, $"VertexBufferSetDataNullValue END (OK)");
                    Assert.Pass("Caught ArgumentNullException : Passed!");
                }
            }
        }
    }
}
