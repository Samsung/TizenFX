using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/ViewStyle")]
    public class PublicBaseComponentsStyleViewStyleTest
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
        [Description("ViewStyle ViewStyle.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Style.ViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseComponentsStyleViewStyle()
        {
            tlog.Debug(tag, $"BaseComponentsStyleViewStyle START");
			
            var testingTarget = new ViewStyle();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ViewStyle>(testingTarget, "should be an instance of ViewStyle class!");

            try
			{
			    testingTarget.Focusable = true;
                Assert.IsTrue(testingTarget.Focusable);
			
			    testingTarget.FocusableChildren = false;
			    Assert.IsTrue(!testingTarget.FocusableChildren);

			    testingTarget.FocusableInTouch = true;
			    Assert.IsTrue(testingTarget.FocusableInTouch);

#pragma warning disable CS0618 // Type or member is obsolete
                testingTarget.Size2D = new Size2D(16, 16);
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual(16, testingTarget.Size2D.Width, "Should be equal!");
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
                testingTarget.Position2D = new Position2D(50, 50);
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual(50, testingTarget.Position2D.X, "Should be equal!");
#pragma warning restore CS0618 // Type or member is obsolete

                testingTarget.PositionX = 0.5f;
			    Assert.AreEqual(0.5f, testingTarget.PositionX, "Should be equal!");	

			    testingTarget.PositionY = 0.5f;
                Assert.AreEqual(0.5f, testingTarget.PositionY, "Should be equal!");

                using (Radian angle = new Radian(30.0f))
                {
                    using (Vector3 axis = new Vector3(1.0f, 1.0f, 0.0f))
                    {
                        testingTarget.Orientation = new Rotation(angle, axis);
                        var len = testingTarget.Orientation.Length();
                        Assert.AreEqual(1, len, "Should be equal!");
                    }
                }

#pragma warning disable CS0618 // Type or member is obsolete
                testingTarget.DrawMode = DrawModeType.Stencil;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual(DrawModeType.Stencil, testingTarget.DrawMode, "Should be equal!");
#pragma warning restore CS0618 // Type or member is obsolete

                testingTarget.WidthForHeight = true;
                Assert.IsTrue(testingTarget.WidthForHeight);
			
			    testingTarget.HeightForWidth = true;
                Assert.IsTrue(testingTarget.HeightForWidth);
			
			    testingTarget.ClippingMode = ClippingModeType.ClipChildren;
                Assert.AreEqual(ClippingModeType.ClipChildren, testingTarget.ClippingMode, "Should be equal!");	

			    testingTarget.Color =  new Selector<Color>()
                {
                    All = Color.White,
                };
                Assert.AreEqual(1, testingTarget.Color.All.G, "Should be equal!");	

			    testingTarget.BackgroundImageBorder =  new Selector<Rectangle>()
                { 
                    All = new Rectangle(40, 40, 100, 50),
                };
			    Assert.AreEqual(100, testingTarget.BackgroundImageBorder.All.Width, "Should be equal!");

                testingTarget.ImageShadow = new Selector<ImageShadow>()
                {
                    All = new ImageShadow()
                    {
                        Url = "nui_component_default_popup_shadow.png",
                        Border = new Rectangle(24, 24, 24, 24),
                        Extents = new Vector2(48, 48)
                    }
                };
                Assert.AreEqual(48, testingTarget.ImageShadow.All.Extents.X, "Should be equal!");

                testingTarget.BorderlineColorSelector = new Selector<Color>()
                {
                    Normal = Color.Red,
                    Pressed = Color.White,
                    Focused = Color.Black,
                    Selected = Color.Yellow,
                    Disabled = Color.Green,
                };
                Assert.AreEqual(1, testingTarget.BorderlineColorSelector.Pressed.G, "Should be equal!");

			    testingTarget.ThemeChangeSensitive = false;
                Assert.IsTrue(!testingTarget.ThemeChangeSensitive);

			    testingTarget.IsEnabled = false;
                Assert.IsTrue(!testingTarget.IsEnabled);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

			testingTarget.Dispose();
            tlog.Debug(tag, $"BaseComponentsStyleViewStyle END (OK)");
        }
    }
}
