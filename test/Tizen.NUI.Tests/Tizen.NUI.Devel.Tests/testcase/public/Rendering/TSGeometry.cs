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
    [Description("public/Rendering/Geometry")]
    public class PublicGeometryTest
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
        [Description("Geometry AddVertexBuffer.")]
        [Property("SPEC", "Tizen.NUI.Geometry.AddVertexBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GeometryAddVertexBuffer()
        {
            tlog.Debug(tag, $"GeometryAddVertexBuffer START");

            var testingTarget = new Geometry();
            Assert.IsNotNull(testingTarget, "Return a null object of Geometry");
            Assert.IsInstanceOf<Geometry>(testingTarget, "Should be an instance of Geometry type.");

            using (PropertyMap vertexFormat = new PropertyMap())
            {
                vertexFormat.Add("aPositionCircle", new PropertyValue((int)PropertyType.Vector2));

                using (VertexBuffer buffer = new VertexBuffer(vertexFormat))
                {
                    var result = testingTarget.AddVertexBuffer(buffer);
                    Assert.AreEqual(0, result, "Should be equal!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GeometryAddVertexBuffer END (OK)");
        }
    }
}
