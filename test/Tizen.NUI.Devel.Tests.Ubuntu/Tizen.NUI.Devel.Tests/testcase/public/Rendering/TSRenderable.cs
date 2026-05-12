using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Rendering/Renderable")]
    public class RenderableTest
    {
        private const string tag = "NUITEST";
        private const int testSize = 100;
        private const int testPosition = 100;

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
        [Description("Create Renderable instance test")]
        [Property("SPEC", "Tizen.NUI.Renderable.Renderable")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Renderable_CREATE_INSTANCE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();
            Assert.IsNotNull(renderable, "Renderable instance should not be null");
            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.Color")]
        [Property("SPEC", "Tizen.NUI.Renderable.Color")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Color_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set Color value
            Color testColor = new Color(0.5f, 0.3f, 0.7f, 0.8f);
            renderable.Color = testColor;

            // Get Color value and verify
            Color retrievedColor = renderable.Color;
            Assert.AreEqual(0.5f, retrievedColor.R, "Color R component should be 0.5f");
            Assert.AreEqual(0.3f, retrievedColor.G, "Color G component should be 0.3f");
            Assert.AreEqual(0.7f, retrievedColor.B, "Color B component should be 0.7f");
            Assert.AreEqual(0.8f, retrievedColor.A, "Color A component should be 0.8f");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.ColorRed")]
        [Property("SPEC", "Tizen.NUI.Renderable.ColorRed")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorRed_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set ColorRed value
            renderable.ColorRed = 0.6f;

            Assert.AreEqual(0.6f, renderable.ColorRed, "ColorRed should be 0.6f");

            // Verify that Color property reflects the change
            Color retrievedColor = renderable.Color;
            Assert.AreEqual(0.6f, retrievedColor.R, "Color R component should be 0.6f");

            // Set Color and verify ColorRed is updated
            renderable.Color = new Color(0.2f, 0.4f, 0.6f, 0.8f);
            Assert.AreEqual(0.2f, renderable.ColorRed, "ColorRed should be updated to 0.2f when Color is set");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.ColorGreen")]
        [Property("SPEC", "Tizen.NUI.Renderable.ColorGreen")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorGreen_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set ColorGreen value
            renderable.ColorGreen = 0.6f;

            Assert.AreEqual(0.6f, renderable.ColorGreen, "ColorGreen should be 0.6f");

            // Verify that Color property reflects the change
            Color retrievedColor = renderable.Color;
            Assert.AreEqual(0.6f, retrievedColor.G, "Color G component should be 0.6f");

            // Set Color and verify ColorGreen is updated
            renderable.Color = new Color(0.2f, 0.4f, 0.6f, 0.8f);
            Assert.AreEqual(0.4f, renderable.ColorGreen, "ColorGreen should be updated to 0.4f when Color is set");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.ColorBlue")]
        [Property("SPEC", "Tizen.NUI.Renderable.ColorBlue")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorBlue_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set ColorBlue value
            renderable.ColorBlue = 0.6f;

            Assert.AreEqual(0.6f, renderable.ColorBlue, "ColorBlue should be 0.6f");

            // Verify that Color property reflects the change
            Color retrievedColor = renderable.Color;
            Assert.AreEqual(0.6f, retrievedColor.B, "Color B component should be 0.6f");

            // Set Color and verify ColorBlue is updated
            renderable.Color = new Color(0.2f, 0.4f, 0.6f, 0.8f);
            Assert.AreEqual(0.6f, renderable.ColorBlue, "ColorBlue should be updated to 0.6f when Color is set");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.Opacity")]
        [Property("SPEC", "Tizen.NUI.Renderable.Opacity")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Opacity_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set Opacity value
            renderable.Opacity = 0.6f;

            Assert.AreEqual(0.6f, renderable.Opacity, "Opacity should be 0.6f");

            // Verify that Color property reflects the change
            Color retrievedColor = renderable.Color;
            Assert.AreEqual(0.6f, retrievedColor.A, "Color A component (Opacity) should be 0.6f");

            // Set Color and verify Opacity is updated
            renderable.Color = new Color(0.2f, 0.4f, 0.6f, 0.8f);
            Assert.AreEqual(0.8f, renderable.Opacity, "Opacity should be updated to 0.8f when Color is set");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Test mutual exclusivity of Color and individual color components")]
        [Property("SPEC", "Tizen.NUI.Renderable.Color")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Color_MUTUAL_EXCLUSIVITY_WITH_COMPONENTS()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Set Color first
            renderable.Color = new Color(0.5f, 0.5f, 0.5f, 0.5f);

            // Modify individual components
            renderable.ColorRed = 0.1f;
            Assert.AreEqual(0.1f, renderable.Color.R, "Color.R should be updated when ColorRed is set");

            renderable.ColorGreen = 0.2f;
            Assert.AreEqual(0.2f, renderable.Color.G, "Color.G should be updated when ColorGreen is set");

            renderable.ColorBlue = 0.3f;
            Assert.AreEqual(0.3f, renderable.Color.B, "Color.B should be updated when ColorBlue is set");

            renderable.Opacity = 0.4f;
            Assert.AreEqual(0.4f, renderable.Color.A, "Color.A should be updated when Opacity is set");

            // Verify all components are correct
            Color finalColor = renderable.Color;
            Assert.AreEqual(0.1f, finalColor.R, "Final R component should be 0.1f");
            Assert.AreEqual(0.2f, finalColor.G, "Final G component should be 0.2f");
            Assert.AreEqual(0.3f, finalColor.B, "Final B component should be 0.3f");
            Assert.AreEqual(0.4f, finalColor.A, "Final A component should be 0.4f");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.DepthIndex")]
        [Property("SPEC", "Tizen.NUI.Renderable.DepthIndex")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void DepthIndex_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.DepthIndex = 5;
            Assert.AreEqual(5, renderable.DepthIndex, "DepthIndex should be 5");

            renderable.DepthIndex = -3;
            Assert.AreEqual(-3, renderable.DepthIndex, "DepthIndex should be -3");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.FaceCullingMode")]
        [Property("SPEC", "Tizen.NUI.Renderable.FaceCullingMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void FaceCullingMode_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.FaceCullingMode = FaceCullingMode.Back;
            Assert.AreEqual(FaceCullingMode.Back, renderable.FaceCullingMode, "FaceCullingMode should be Back");

            renderable.FaceCullingMode = FaceCullingMode.Front;
            Assert.AreEqual(FaceCullingMode.Front, renderable.FaceCullingMode, "FaceCullingMode should be Front");

            renderable.FaceCullingMode = FaceCullingMode.None;
            Assert.AreEqual(FaceCullingMode.None, renderable.FaceCullingMode, "FaceCullingMode should be None");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendMode")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendMode_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendMode = BlendMode.On;
            Assert.AreEqual(BlendMode.On, renderable.BlendMode, "BlendMode should be On");

            renderable.BlendMode = BlendMode.Off;
            Assert.AreEqual(BlendMode.Off, renderable.BlendMode, "BlendMode should be Off");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendEquationRgb")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendEquationRgb")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendEquationRgb_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendEquationRgb = BlendEquation.Add;
            Assert.AreEqual(BlendEquation.Add, renderable.BlendEquationRgb, "BlendEquationRgb should be Add");

            renderable.BlendEquationRgb = BlendEquation.Subtract;
            Assert.AreEqual(BlendEquation.Subtract, renderable.BlendEquationRgb, "BlendEquationRgb should be Subtract");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendEquationAlpha")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendEquationAlpha")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendEquationAlpha_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendEquationAlpha = BlendEquation.Add;
            Assert.AreEqual(BlendEquation.Add, renderable.BlendEquationAlpha, "BlendEquationAlpha should be Add");

            renderable.BlendEquationAlpha = BlendEquation.ReverseSubtract;
            Assert.AreEqual(BlendEquation.ReverseSubtract, renderable.BlendEquationAlpha, "BlendEquationAlpha should be ReverseSubtract");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendFactorSrcRgb")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendFactorSrcRgb")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendFactorSrcRgb_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendFactorSrcRgb = BlendFactor.SourceAlpha;
            Assert.AreEqual(BlendFactor.SourceAlpha, renderable.BlendFactorSrcRgb, "BlendFactorSrcRgb should be SourceAlpha");

            renderable.BlendFactorSrcRgb = BlendFactor.One;
            Assert.AreEqual(BlendFactor.One, renderable.BlendFactorSrcRgb, "BlendFactorSrcRgb should be One");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendFactorDestRgb")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendFactorDestRgb")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendFactorDestRgb_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendFactorDestRgb = BlendFactor.OneMinusSourceAlpha;
            Assert.AreEqual(BlendFactor.OneMinusSourceAlpha, renderable.BlendFactorDestRgb, "BlendFactorDestRgb should be OneMinusSourceAlpha");

            renderable.BlendFactorDestRgb = BlendFactor.Zero;
            Assert.AreEqual(BlendFactor.Zero, renderable.BlendFactorDestRgb, "BlendFactorDestRgb should be Zero");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendFactorSrcAlpha")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendFactorSrcAlpha")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendFactorSrcAlpha_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendFactorSrcAlpha = BlendFactor.SourceAlpha;
            Assert.AreEqual(BlendFactor.SourceAlpha, renderable.BlendFactorSrcAlpha, "BlendFactorSrcAlpha should be SourceAlpha");

            renderable.BlendFactorSrcAlpha = BlendFactor.DestinationAlpha;
            Assert.AreEqual(BlendFactor.DestinationAlpha, renderable.BlendFactorSrcAlpha, "BlendFactorSrcAlpha should be DestinationAlpha");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendFactorDestAlpha")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendFactorDestAlpha")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendFactorDestAlpha_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendFactorDestAlpha = BlendFactor.OneMinusDestinationAlpha;
            Assert.AreEqual(BlendFactor.OneMinusDestinationAlpha, renderable.BlendFactorDestAlpha, "BlendFactorDestAlpha should be OneMinusDestinationAlpha");

            renderable.BlendFactorDestAlpha = BlendFactor.One;
            Assert.AreEqual(BlendFactor.One, renderable.BlendFactorDestAlpha, "BlendFactorDestAlpha should be One");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendColor")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendColor")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendColor_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            Vector4 blendColor = new Vector4(0.5f, 0.6f, 0.7f, 0.8f);
            renderable.BlendColor = blendColor;

            Vector4 retrievedColor = renderable.BlendColor;
            Assert.AreEqual(0.5f, retrievedColor.X, "BlendColor X should be 0.5f");
            Assert.AreEqual(0.6f, retrievedColor.Y, "BlendColor Y should be 0.6f");
            Assert.AreEqual(0.7f, retrievedColor.Z, "BlendColor Z should be 0.7f");
            Assert.AreEqual(0.8f, retrievedColor.W, "BlendColor W should be 0.8f");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.BlendPreMultipliedAlpha")]
        [Property("SPEC", "Tizen.NUI.Renderable.BlendPreMultipliedAlpha")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void BlendPreMultipliedAlpha_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.BlendPreMultipliedAlpha = true;
            Assert.AreEqual(true, renderable.BlendPreMultipliedAlpha, "BlendPreMultipliedAlpha should be true");

            renderable.BlendPreMultipliedAlpha = false;
            Assert.AreEqual(false, renderable.BlendPreMultipliedAlpha, "BlendPreMultipliedAlpha should be false");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.FirstIndex")]
        [Property("SPEC", "Tizen.NUI.Renderable.FirstIndex")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void FirstIndex_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.FirstIndex = 10;
            Assert.AreEqual(10, renderable.FirstIndex, "FirstIndex should be 10");

            renderable.FirstIndex = 0;
            Assert.AreEqual(0, renderable.FirstIndex, "FirstIndex should be 0");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.IndexCount")]
        [Property("SPEC", "Tizen.NUI.Renderable.IndexCount")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void IndexCount_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.IndexCount = 100;
            Assert.AreEqual(100, renderable.IndexCount, "IndexCount should be 100");

            renderable.IndexCount = 50;
            Assert.AreEqual(50, renderable.IndexCount, "IndexCount should be 50");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.DepthWriteMode")]
        [Property("SPEC", "Tizen.NUI.Renderable.DepthWriteMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void DepthWriteMode_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.DepthWriteMode = DepthWriteMode.On;
            Assert.AreEqual(DepthWriteMode.On, renderable.DepthWriteMode, "DepthWriteMode should be On");

            renderable.DepthWriteMode = DepthWriteMode.Off;
            Assert.AreEqual(DepthWriteMode.Off, renderable.DepthWriteMode, "DepthWriteMode should be Off");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.DepthFunction")]
        [Property("SPEC", "Tizen.NUI.Renderable.DepthFunction")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void DepthFunction_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.DepthFunction = DepthFunction.Less;
            Assert.AreEqual(DepthFunction.Less, renderable.DepthFunction, "DepthFunction should be Less");

            renderable.DepthFunction = DepthFunction.LessEqual;
            Assert.AreEqual(DepthFunction.LessEqual, renderable.DepthFunction, "DepthFunction should be LessEqual");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.DepthTestMode")]
        [Property("SPEC", "Tizen.NUI.Renderable.DepthTestMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void DepthTestMode_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.DepthTestMode = DepthTestMode.On;
            Assert.AreEqual(DepthTestMode.On, renderable.DepthTestMode, "DepthTestMode should be On");

            renderable.DepthTestMode = DepthTestMode.Off;
            Assert.AreEqual(DepthTestMode.Off, renderable.DepthTestMode, "DepthTestMode should be Off");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.RenderMode")]
        [Property("SPEC", "Tizen.NUI.Renderable.RenderMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void RenderMode_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.RenderMode = RenderMode.None;
            Assert.AreEqual(RenderMode.None, renderable.RenderMode, "RenderMode should be None");

            renderable.RenderMode = RenderMode.ColorStencil;
            Assert.AreEqual(RenderMode.ColorStencil, renderable.RenderMode, "RenderMode should be ColorStencil");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilFunction")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilFunction")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilFunction_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilFunction = StencilFunction.Equal;
            Assert.AreEqual(StencilFunction.Equal, renderable.StencilFunction, "StencilFunction should be Equal");

            renderable.StencilFunction = StencilFunction.Always;
            Assert.AreEqual(StencilFunction.Always, renderable.StencilFunction, "StencilFunction should be Always");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilFunctionMask")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilFunctionMask")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilFunctionMask_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilFunctionMask = 0xFF;
            Assert.AreEqual(0xFF, renderable.StencilFunctionMask, "StencilFunctionMask should be 0xFF");

            renderable.StencilFunctionMask = 0x0F;
            Assert.AreEqual(0x0F, renderable.StencilFunctionMask, "StencilFunctionMask should be 0x0F");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilFunctionReference")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilFunctionReference")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilFunctionReference_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilFunctionReference = 1;
            Assert.AreEqual(1, renderable.StencilFunctionReference, "StencilFunctionReference should be 1");

            renderable.StencilFunctionReference = 5;
            Assert.AreEqual(5, renderable.StencilFunctionReference, "StencilFunctionReference should be 5");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilMask")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilMask")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilMask_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilMask = 0xFF;
            Assert.AreEqual(0xFF, renderable.StencilMask, "StencilMask should be 0xFF");

            renderable.StencilMask = 0x00;
            Assert.AreEqual(0x00, renderable.StencilMask, "StencilMask should be 0x00");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilOperationOnFail")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilOperationOnFail")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilOperationOnFail_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilOperationOnFail = StencilOperation.Keep;
            Assert.AreEqual(StencilOperation.Keep, renderable.StencilOperationOnFail, "StencilOperationOnFail should be Keep");

            renderable.StencilOperationOnFail = StencilOperation.Replace;
            Assert.AreEqual(StencilOperation.Replace, renderable.StencilOperationOnFail, "StencilOperationOnFail should be Replace");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilOperationOnZFail")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilOperationOnZFail")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilOperationOnZFail_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilOperationOnZFail = StencilOperation.Increment;
            Assert.AreEqual(StencilOperation.Increment, renderable.StencilOperationOnZFail, "StencilOperationOnZFail should be Increment");

            renderable.StencilOperationOnZFail = StencilOperation.Decrement;
            Assert.AreEqual(StencilOperation.Decrement, renderable.StencilOperationOnZFail, "StencilOperationOnZFail should be Decrement");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.StencilOperationOnZPass")]
        [Property("SPEC", "Tizen.NUI.Renderable.StencilOperationOnZPass")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StencilOperationOnZPass_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            renderable.StencilOperationOnZPass = StencilOperation.Zero;
            Assert.AreEqual(StencilOperation.Zero, renderable.StencilOperationOnZPass, "StencilOperationOnZPass should be Zero");

            renderable.StencilOperationOnZPass = StencilOperation.Invert;
            Assert.AreEqual(StencilOperation.Invert, renderable.StencilOperationOnZPass, "StencilOperationOnZPass should be Invert");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.UpdateArea")]
        [Property("SPEC", "Tizen.NUI.Renderable.UpdateArea")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void UpdateArea_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            UIExtents updateArea = new UIExtents(10, 20, 30, 40);
            renderable.UpdateArea = updateArea;

            UIExtents retrievedArea = renderable.UpdateArea;
            Assert.AreEqual(10.0f, retrievedArea.Start, "UpdateArea Start should be 10");
            Assert.AreEqual(20.0f, retrievedArea.End, "UpdateArea End should be 20");
            Assert.AreEqual(30.0f, retrievedArea.Top, "UpdateArea Top should be 30");
            Assert.AreEqual(40.0f, retrievedArea.Bottom, "UpdateArea Bottom should be 40");

            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.Geometry")]
        [Property("SPEC", "Tizen.NUI.Renderable.Geometry")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Geometry_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Create a simple geometry
            Geometry geometry = new Geometry();
            renderable.Geometry = geometry;

            Geometry retrievedGeometry = renderable.Geometry;
            Assert.IsNotNull(retrievedGeometry, "Geometry should not be null");

            geometry.Dispose();
            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.Shader")]
        [Property("SPEC", "Tizen.NUI.Renderable.Shader")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Shader_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Create a simple shader
            Shader shader = new Shader("vert", "frag", "name");
            renderable.Shader = shader;

            Shader retrievedShader = renderable.Shader;
            Assert.IsNotNull(retrievedShader, "Shader should not be null");

            shader.Dispose();
            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get and Set value test for Renderable.TextureSet")]
        [Property("SPEC", "Tizen.NUI.Renderable.TextureSet")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void TextureSet_GET_SET_VALUE()
        {
            /* TEST CODE */
            Renderable renderable = new Renderable();

            // Create a simple texture set
            TextureSet textureSet = new TextureSet();
            renderable.TextureSet = textureSet;

            TextureSet retrievedTextureSet = renderable.TextureSet;
            Assert.IsNotNull(retrievedTextureSet, "TextureSet should not be null");

            textureSet.Dispose();
            renderable.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for Renderable.AliveCount")]
        [Property("SPEC", "Tizen.NUI.Renderable.AliveCount")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void AliveCount_GET_VALUE()
        {
            /* TEST CODE */
            int initialCount = Renderable.AliveCount;

            Renderable renderable1 = new Renderable();
            Assert.AreEqual(initialCount + 1, Renderable.AliveCount, "AliveCount should increase by 1 after creating Renderable");

            Renderable renderable2 = new Renderable();
            Assert.AreEqual(initialCount + 2, Renderable.AliveCount, "AliveCount should increase by 2 after creating 2 Renderables");

            renderable1.Dispose();
            Assert.AreEqual(initialCount + 1, Renderable.AliveCount, "AliveCount should decrease by 1 after disposing one Renderable");

            renderable2.Dispose();
            Assert.AreEqual(initialCount, Renderable.AliveCount, "AliveCount should return to initial value after disposing all Renderables");
        }
    }
}