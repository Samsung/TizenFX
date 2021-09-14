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
    [Description("public/Common/Color")]
    public class PublicColorTest
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
        [Description("Color constructor.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructor()
        {
            tlog.Debug(tag, $"ColorConstructor START");

            var testingTarget = new Color();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color constructor. With RGBA component.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithRGBAComponent()
        {
            tlog.Debug(tag, $"ColorConstructorWithRGBAComponent START");

            var testingTarget = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.5f, testingTarget.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, testingTarget.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Black is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructorWithRGBAComponent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color constructor. With array.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithArray()
        {
            tlog.Debug(tag, $"ColorConstructorWithArray START");

            float[] array = new float[4] { 0.5f, 0.5f, 0.5f, 1.0f };

            var testingTarget = new Color(array);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");
            
            Assert.AreEqual(0.5f, testingTarget.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.5f, testingTarget.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, testingTarget.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Black is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructorWithArray END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Color constructor. With invalid value.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithInvalidValue()
        {
            tlog.Debug(tag, $"ColorConstructorWithInvalidValue START");

            float[] array = new float[4] { 0.5f, 2.0f, 0.5f, 1.0f };

            var testingTarget = new Color(array);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.R, "The R property of Black is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.5f, testingTarget.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Black is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructorWithInvalidValue END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Color constructor. With null array.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithNullArray()
        {
            tlog.Debug(tag, $"ColorConstructorWithNullArray START");

            float[] array = null;

            try
            {
                var testingTarget = new Color(array);
                Assert.Fail("Should return argument exception");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ColorConstructorWithNullArray END (OK)");
                Assert.Pass("ArgumentException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Color constructor. With string.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithString()
        {
            tlog.Debug(tag, $"ColorConstructorWithString START");

            // Start with "#" && length is 8 
            var testingTarget = new Tizen.NUI.Color("#C3CAD2FF");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            // Start with "#" && length is 3
            testingTarget = new Color("#047");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            // isRGBA && length is 4
            testingTarget = new Color("RGBA(30,15,240,110)");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            // isRGB && length is 3
            testingTarget = new Color("RGB(0,4,7)");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructorWithString END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Color constructor. String is null.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithNullString()
        {
            tlog.Debug(tag, $"ColorConstructorWithNullString START");

            string textColor = null;

            try
            {
                new Color(textColor);
                Assert.Fail("Should return argument exception");
            }
            catch (ArgumentException) 
            {
                tlog.Debug(tag, $"ColorConstructorWithNullString END (OK)");
                Assert.Pass("ArgumentException: passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Color constructor. With System.Drawing.Color instance.")]
        [Property("SPEC", "Tizen.NUI.Color.Color C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorConstructorWithSystemDrawingColorInstance()
        {
            tlog.Debug(tag, $"ColorConstructorWithSystemDrawingColorInstance START");

            global::System.Drawing.Color color = global::System.Drawing.Color.FromArgb(255, 0, 0);
            
            var testingTarget = new Color(color);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorConstructorWithSystemDrawingColorInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color R.")]
        [Property("SPEC", "Tizen.NUI.Color.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorR()
        {
            tlog.Debug(tag, $"ColorR START");

            var testingTarget = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.R, "The R property of color is not correct.");

            testingTarget.R = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.R, "The R property of color is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorR END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color G.")]
        [Property("SPEC", "Tizen.NUI.Color.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorG()
        {
            tlog.Debug(tag, $"ColorG START");

            var testingTarget = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.G, "The G property of color is not correct.");

            testingTarget.G = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.G, "The G property of color is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorG END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color B.")]
        [Property("SPEC", "Tizen.NUI.Color.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorB()
        {
            tlog.Debug(tag, $"ColorB START");

            var testingTarget = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.B, "The B property of color is not correct.");

            testingTarget.B = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.B, "The B property of color is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorB END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color A.")]
        [Property("SPEC", "Tizen.NUI.Color.A A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorA()
        {
            tlog.Debug(tag, $"ColorA START");

            var testingTarget = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(1.0f, testingTarget.A, "The A property of color is not correct.");

            testingTarget.A = 0.4f;
            Assert.AreEqual(0.4f, testingTarget.A, "The A property of color is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorA END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color AliceBlue.")]
        [Property("SPEC", "Tizen.NUI.Color.AliceBlue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorAliceBlue()
        {
            tlog.Debug(tag, $"ColorAliceBlue START");

            var testingTarget = Color.AliceBlue;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorAliceBlue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Aqua.")]
        [Property("SPEC", "Tizen.NUI.Color.Aqua A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorAqua()
        {
            tlog.Debug(tag, $"ColorAqua START");

            var testingTarget = Color.Aqua;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorAqua END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Azure.")]
        [Property("SPEC", "Tizen.NUI.Color.Azure A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorAzure()
        {
            tlog.Debug(tag, $"ColorAzure START");

            var testingTarget = Color.Azure;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorAzure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Beige.")]
        [Property("SPEC", "Tizen.NUI.Color.Beige A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorBeige()
        {
            tlog.Debug(tag, $"ColorBeige START");

            var testingTarget = Color.Beige;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorBeige END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Black.")]
        [Property("SPEC", "Tizen.NUI.Color.Black A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorBlack()
        {
            tlog.Debug(tag, $"ColorBlack START");

            var testingTarget = Color.Black;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R property of Black is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.G, "The G property of Black is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.B, "The B property of Black is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Black is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorBlack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Blue.")]
        [Property("SPEC", "Tizen.NUI.Color.Blue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorBlue()
        {
            tlog.Debug(tag, $"ColorBlue START");

            var testingTarget = Color.Blue;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R property of Blue is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.G, "The G property of Blue is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.B, "The B property of Blue is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Blue is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorBlue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Chocolate.")]
        [Property("SPEC", "Tizen.NUI.Color.Chocolate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorChocolate()
        {
            tlog.Debug(tag, $"ColorChocolate START");

            var testingTarget = Color.Chocolate;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorChocolate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Cornsilk.")]
        [Property("SPEC", "Tizen.NUI.Color.Cornsilk A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCornsilk()
        {
            tlog.Debug(tag, $"ColorCornsilk START");

            var testingTarget = Color.Cornsilk;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorCornsilk END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Crimson.")]
        [Property("SPEC", "Tizen.NUI.Color.Crimson A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCrimson()
        {
            tlog.Debug(tag, $"ColorCrimson START");

            var testingTarget = Color.Crimson;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorCrimson END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Cyan.")]
        [Property("SPEC", "Tizen.NUI.Color.Cyan A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCyan()
        {
            tlog.Debug(tag, $"ColorCyan START");

            var testingTarget = Color.Cyan;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.G, "The G property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.B, "The B property of Cyan is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Cyan is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorCyan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color DarkGray.")]
        [Property("SPEC", "Tizen.NUI.Color.DarkGray A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDarkGray()
        {
            tlog.Debug(tag, $"ColorDarkGray START");

            var testingTarget = Color.DarkGray;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.6627451f, testingTarget.R, "The R property of DarkGray is not correct here.");
            Assert.AreEqual(0.6627451f, testingTarget.G, "The G property of DarkGray is not correct here.");
            Assert.AreEqual(0.6627451f, testingTarget.B, "The B property of DarkGray is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of DarkGray is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorDarkGray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color DarkGreen.")]
        [Property("SPEC", "Tizen.NUI.Color.DarkGreen A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDarkGreen()
        {
            tlog.Debug(tag, $"ColorDarkGreen START");

            var testingTarget = Color.DarkGreen;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorDarkGreen END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color DarkOrange.")]
        [Property("SPEC", "Tizen.NUI.Color.DarkOrange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDarkOrange()
        {
            tlog.Debug(tag, $"ColorDarkOrange START");

            var testingTarget = Color.DarkOrange;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorDarkOrange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color DarkOrchid.")]
        [Property("SPEC", "Tizen.NUI.Color.DarkOrchid A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDarkOrchid()
        {
            tlog.Debug(tag, $"ColorDarkOrchid START");

            var testingTarget = Color.DarkOrchid;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorDarkOrchid END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color White.")]
        [Property("SPEC", "Tizen.NUI.Color.White A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorWhite()
        {
            tlog.Debug(tag, $"ColorWhite START");

            var testingTarget = Color.White;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(1.0f, testingTarget.R, "The R property of White is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.G, "The G property of White is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.B, "The B property of White is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of White is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorWhite END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Red.")]
        [Property("SPEC", "Tizen.NUI.Color.Red A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorRed()
        {
            tlog.Debug(tag, $"ColorRed START");

            var testingTarget = Color.Red;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(1.0f, testingTarget.R, "The R property of Red is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.G, "The G property of Red is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.B, "The B property of Red is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Red is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorRed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Green.")]
        [Property("SPEC", "Tizen.NUI.Color.Green A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorGreen()
        {
            tlog.Debug(tag, $"ColorGreen START");

            var testingTarget = Color.Green;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R property of Green is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.G, "The G property of Green is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.B, "The B property of Green is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Green is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorGreen END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Yellow.")]
        [Property("SPEC", "Tizen.NUI.Color.Yellow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorYellow()
        {
            tlog.Debug(tag, $"ColorYellow START");

            var testingTarget = Color.Yellow;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(1.0f, testingTarget.R, "The R property of Yellow is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.G, "The G property of Yellow is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.B, "The B property of Yellow is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Yellow is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorYellow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Magenta.")]
        [Property("SPEC", "Tizen.NUI.Color.Magenta A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorMagenta()
        {
            tlog.Debug(tag, $"ColorMagenta START");

            var testingTarget = Color.Magenta;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(1.0f, testingTarget.R, "The R property of Magenta is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.G, "The G property of Magenta is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.B, "The B property of Magenta is not correct here.");
            Assert.AreEqual(1.0f, testingTarget.A, "The A property of Magenta is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorMagenta END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Transparent.")]
        [Property("SPEC", "Tizen.NUI.Color.Transparent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorTransparent()
        {
            tlog.Debug(tag, $"ColorTransparent START");

            var testingTarget = Color.Transparent;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.G, "The G property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.B, "The B property of Transparent is not correct here.");
            Assert.AreEqual(0.0f, testingTarget.A, "The A property of Transparent is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorTransparent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color this[uint index]. Get value by subscript.")]
        [Property("SPEC", "Tizen.NUI.Color.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorGetValueBySubscript()
        {
            tlog.Debug(tag, $"ColorGetValueBySubscript START");

            var testingTarget = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.1f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.2f, testingTarget[1], "The value of index[1] is not correct!");
            Assert.AreEqual(0.3f, testingTarget[2], "The value of index[2] is not correct!");
            Assert.AreEqual(0.4f, testingTarget[3], "The value of index[3] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorGetValueBySubscript END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color operator +.")]
        [Property("SPEC", "Tizen.NUI.Color.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorAddition()
        {
            tlog.Debug(tag, $"ColorAddition START");

            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.4f, 0.3f, 0.5f, 0.6f);

            var testingTarget = color1 + color2;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.5f, testingTarget.R, "The R value of the color is not correct!");
            Assert.AreEqual(0.5f, testingTarget.G, "The G value of the color is not correct!");
            Assert.AreEqual(0.8f, testingTarget.B, "The B value of the color is not correct!");
            Assert.AreEqual(1.0f, testingTarget.A, "The A value of the color is not correct!");

            color1.Dispose();
            color2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorAddition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color operator -.")]
        [Property("SPEC", "Tizen.NUI.Color.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorSubtraction()
        {
            tlog.Debug(tag, $"ColorSubtraction START");

            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Color color2 = new Color(0.4f, 0.3f, 0.5f, 0.6f);

            var testingTarget = color2 - color1;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.Less(Math.Abs(0.3f - testingTarget.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.1f - testingTarget.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - testingTarget.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - testingTarget.A), 0.001f, "The A value of the color is not correct!");

            color1.Dispose();
            color2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Unary Negation.")]
        [Property("SPEC", "Tizen.NUI.Color.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUnaryNegation()
        {
            tlog.Debug(tag, $"ColorUnaryNegation START");

            Color color = new Color(0.1f, 0.2f, 0.3f, 0.4f);

            var testingTarget = -color;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.0f, testingTarget.R, "The R value of the color is not correct!");
            Assert.AreEqual(0.0f, testingTarget.G, "The G value of the color is not correct!");
            Assert.AreEqual(0.0f, testingTarget.B, "The B value of the color is not correct!");
            Assert.AreEqual(0.0f, testingTarget.A, "The A value of the color is not correct!");

            color.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color operator *.")]
        [Property("SPEC", "Tizen.NUI.Color.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorMultiply()
        {
            tlog.Debug(tag, $"ColorMultiply START");

            Color color1 = new Color(0.1f, 0.2f, 0.3f, 0.1f);
            Color color2 = new Color(0.4f, 0.3f, 0.2f, 0.6f);

            var testingTarget = color2 * color1;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0.04f, testingTarget.R, 0.00001, "The R value of the color is not correct!");
            Assert.AreEqual(0.06f, testingTarget.G, 0.00001, "The G value of the color is not correct!");
            Assert.AreEqual(0.06f, testingTarget.B, 0.00001, "The B value of the color is not correct!");
            Assert.AreEqual(0.06f, testingTarget.A, 0.00001, "The A value of the color is not correct!");

            color1.Dispose();
            color2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorMultiply END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color operator *. By float.")]
        [Property("SPEC", "Tizen.NUI.Color.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorMultiplyByFloat()
        {
            tlog.Debug(tag, $"ColorMultiplyByFloat START");

            Color color = new Color(0.1f, 0.2f, 0.3f, 0.1f);

            var testingTarget = color * 2.0f;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.Less(Math.Abs(0.2f - testingTarget.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.4f - testingTarget.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.6f - testingTarget.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - testingTarget.A), 0.001f, "The A value of the color is not correct!");

            color.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorMultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color operator /.")]
        [Property("SPEC", "Tizen.NUI.Color./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDivision()
        {
            tlog.Debug(tag, $"ColorDivision START");

            Color color1 = new Color(0.2f, 0.2f, 0.3f, 0.1f);
            Color color2 = new Color(0.04f, 0.06f, 0.06f, 0.06f);

            Color testingTarget = color2 / color1;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.Less(Math.Abs(0.2f - testingTarget.R), 0.001f, "The R value of the color is not correct!");
            Assert.Less(Math.Abs(0.3f - testingTarget.G), 0.001f, "The G value of the color is not correct!");
            Assert.Less(Math.Abs(0.2f - testingTarget.B), 0.001f, "The B value of the color is not correct!");
            Assert.Less(Math.Abs(0.6f - testingTarget.A), 0.001f, "The A value of the color is not correct!");

            color1.Dispose();
            color2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorDivision END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Color operator /. By float")]
        //[Property("SPEC", "Tizen.NUI.Color./ M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ColorDivisionByFloat ()
        //{
        //    tlog.Debug(tag, $"ColorDivisionByFloat START");

        //    using (Color color = new Color(0.2f, 0.2f, 0.4f, 0.6f))
        //    {
        //        var testingTarget = color / 2.0f;
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

        //        Assert.AreEqual(0.1f, testingTarget.R, "The R value of the color is not correct!");
        //        Assert.AreEqual(0.1f, testingTarget.G, "The G value of the color is not correct!");
        //        Assert.AreEqual(0.2f, testingTarget.B, "The B value of the color is not correct!");
        //        Assert.AreEqual(0.3f, testingTarget.A, "The A value of the color is not correct!");

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"ColorDivisionByFloat END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("Color EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Color.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorEqualTo()
        {
            tlog.Debug(tag, $"ColorEqualTo START");

            var testingTarget = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            using (Color color = new Color(0.1f, 0.2f, 0.3f, 0.4f))
            {
                Assert.IsTrue((testingTarget.EqualTo(color)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Color.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorNotEqualTo()
        {
            tlog.Debug(tag, $"ColorNotEqualTo START");

            var testingTarget = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            using (Color color = new Color(0.4f, 0.3f, 0.2f, 0.1f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(color)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color implicit. Vector4 to color.")]
        [Property("SPEC", "Tizen.NUI.Color.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorImplicitConvertFromVector4()
        {
            tlog.Debug(tag, $"ColorImplicitConvertFromVector4 START");

            Color testingTarget = null;
            using (Vector4 vector = new Vector4(0.1f, 0.2f, 0.3f, 0.4f))
            {
                testingTarget = vector;
                Assert.AreEqual(testingTarget.R, vector.R, "The value of R is not correct.");
                Assert.AreEqual(testingTarget.G, vector.G, "The value of G is not correct.");
                Assert.AreEqual(testingTarget.B, vector.B, "The value of B is not correct.");
                Assert.AreEqual(testingTarget.A, vector.A, "The value of A is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorImplicitConvertFromVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color implicit. Color to vector4.")]
        [Property("SPEC", "Tizen.NUI.Color.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorImplicitConvertToVector4()
        {
            tlog.Debug(tag, $"ColorImplicitConvertToVector4 START");

            Vector4 testingTarget = null;
            using (Color color = new Color(0.1f, 0.2f, 0.3f, 0.4f))
            {
                testingTarget = color;
                Assert.AreEqual(color.R, testingTarget.R, "The value of R is not correct.");
                Assert.AreEqual(color.G, testingTarget.G, "The value of G is not correct.");
                Assert.AreEqual(color.B, testingTarget.B, "The value of B is not correct.");
                Assert.AreEqual(color.A, testingTarget.A, "The value of A is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorImplicitConvertToVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Color.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorGetHashCode()
        {
            tlog.Debug(tag, $"ColorGetHashCode START");

            var testingTarget = new Color(0.1f, 0.3f, 0.4f, 0.8f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            Assert.AreEqual(0, testingTarget.GetHashCode());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Equals.")]
        [Property("SPEC", "Tizen.NUI.Color.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorEquals()
        {
            tlog.Debug(tag, $"ColorEquals START");

            var testingTarget = new Color(0.1f, 0.3f, 0.4f, 0.8f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            using (Size size = new Size(20, 30))
            {
                var result = testingTarget.Equals(size);
                Assert.IsFalse(result);
            }

            using (Color color = testingTarget)
            {
                var result = testingTarget.Equals(color);
                Assert.IsTrue(result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorEquals END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Color Equals. With null object")]
        [Property("SPEC", "Tizen.NUI.Color.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorEqualsWithNullObject()
        {
            tlog.Debug(tag, $"ColorEqualsWithNullObject START");

            var testingTarget = new Color(0.1f, 0.3f, 0.4f, 0.8f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            var result = testingTarget.Equals(null);
            Assert.IsFalse(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorEqualsWithNullObject END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Color GetColorFromPtr.")]
        [Property("SPEC", "Tizen.NUI.Color.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorGetColorFromPtr()
        {
            tlog.Debug(tag, $"ColorGetColorFromPtr START");

            using (Color color = Color.Cyan)
            {
                global::System.IntPtr cPtr = (global::System.IntPtr)Color.getCPtr(color);

                var testingTarget = Color.GetColorFromPtr(cPtr);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ColorGetColorFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Color Dispose.")]
        [Property("SPEC", "Tizen.NUI.Color.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorDispose()
        {
            tlog.Debug(tag, $"ColorDispose START");

            var testingTarget = new Color();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Color>(testingTarget, "Should return Color instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ColorDispose END (OK)");
        }
    }
}
