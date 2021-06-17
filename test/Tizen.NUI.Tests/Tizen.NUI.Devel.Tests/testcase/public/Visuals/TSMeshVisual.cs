using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/MeshVisual")]
    public class PublicMeshVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyMeshVisual : MeshVisual
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
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
        [Description("MeshVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.MeshVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualConstructor()
        {
            tlog.Debug(tag, $"MeshVisualConstructor START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual ObjectURL.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ObjectURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualObjectURL()
        {
            tlog.Debug(tag, $"MeshVisualObjectURL START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            string url = "ObjectURL";
            testingTarget.ObjectURL = url;
            Assert.AreEqual(url, testingTarget.ObjectURL, "Retrieved ObjectURL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualObjectURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual MaterialtURL.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.MaterialtURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualMaterialtURL()
        {
            tlog.Debug(tag, $"MeshVisualMaterialtURL START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            string url = "MaterialtURL";
            testingTarget.MaterialtURL = url;
            Assert.AreEqual(url, testingTarget.MaterialtURL, "Retrieved MaterialtURL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualMaterialtURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual TexturesPath.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.TexturesPath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualTexturesPath()
        {
            tlog.Debug(tag, $"MeshVisualTexturesPath START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            string url = "TexturesPath";
            testingTarget.TexturesPath = url;
            Assert.AreEqual(url, testingTarget.TexturesPath, "Retrieved TexturesPath should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualTexturesPath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual ShadingMode.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ShadingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualShadingMode()
        {
            tlog.Debug(tag, $"MeshVisualShadingMode START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            testingTarget.ShadingMode = MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting;
            Assert.AreEqual(MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting, testingTarget.ShadingMode, "Retrieved ShadingMode should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualShadingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual UseMipmapping.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.UseMipmapping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualUseMipmapping()
        {
            tlog.Debug(tag, $"MeshVisualUseMipmapping START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            testingTarget.UseMipmapping = true;
            Assert.AreEqual(true, testingTarget.UseMipmapping, "Retrieved UseMipmapping should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualUseMipmapping END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual UseSoftNormals.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.UseSoftNormals A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualUseSoftNormals()
        {
            tlog.Debug(tag, $"MeshVisualUseSoftNormals START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            testingTarget.UseSoftNormals = true;
            Assert.AreEqual(true, testingTarget.UseSoftNormals, "Retrieved UseSoftNormals should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualUseSoftNormals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual LightPosition.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualLightPosition()
        {
            tlog.Debug(tag, $"MeshVisualLightPosition START");

            var testingTarget = new MeshVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object MeshVisual");
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");

            using (Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f)) 
            {
                testingTarget.LightPosition = vector3;
                Assert.AreEqual(1.0f, testingTarget.LightPosition.X, "Retrieved LightPosition.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.LightPosition.Y, "Retrieved LightPosition.Y should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.LightPosition.Z, "Retrieved LightPosition.Z should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualLightPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeshVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.MeshVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeshVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"MeshVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyMeshVisual()
            {
                ObjectURL = "ObjectURL",
                MaterialtURL = "MaterialtURL",
                TexturesPath = "TexturesPath",
                ShadingMode = MeshVisualShadingModeValue.TexturedWithDetailedSpecularLighting,
                UseMipmapping = true,
                UseSoftNormals = true,
                LightPosition = new Vector3(1.0f, 1.0f, 1.0f)
            };
            Assert.IsInstanceOf<MeshVisual>(testingTarget, "Should be an instance of MeshVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MeshVisualComposingPropertyMap END (OK)");
        }
    }
}
