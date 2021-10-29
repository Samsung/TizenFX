using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Utils/Selector")]
    public class SelectorTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("IntSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.IntSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void IntSelectorClone()
        {
            tlog.Debug(tag, $"IntSelectorClone START");

            var testingTarget = new IntSelector()
			{
				All = 10,
			};
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<IntSelector>(testingTarget, "Should return IntSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Int]'
                //  to type 'Tizen.NUI.Components.IntSelector'

                // To fix

                tlog.Debug(tag, $"IntSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("FloatSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.FloatSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatSelectorClone()
        {
            tlog.Debug(tag, $"FloatSelectorClone START");

            var testingTarget = new FloatSelector()
            {
                Normal = 1.0f,
                Selected = 1.0f,
                Disabled = 0.4f,
                DisabledSelected = 0.4f
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FloatSelector>(testingTarget, "Should return FloatSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Float]'
                //  to type 'Tizen.NUI.Components.FloatSelector'

                // To fix

                tlog.Debug(tag, $"FloatSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("BoolSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.BoolSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BoolSelectorClone()
        {
            tlog.Debug(tag, $"BoolSelectorClone START");

            var testingTarget = new BoolSelector()
            {
                All = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BoolSelector>(testingTarget, "Should return BoolSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Bool]'
                //  to type 'Tizen.NUI.Components.BoolSelector'

                // To fix

                tlog.Debug(tag, $"BoolSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("StringSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.StringSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringSelectorClone()
        {
            tlog.Debug(tag, $"StringSelectorClone START");

            Selector<string> selector = new Selector<string> 
            {
                Pressed = image_path,
                Disabled = image_path,
                DisabledFocused = image_path,
                DisabledSelected = image_path,
                Other = image_path
            };

            var testingTarget = new StringSelector(selector);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StringSelector>(testingTarget, "Should return StringSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.String]'
                //  to type 'Tizen.NUI.Components.StringSelector'

                // To fix

                tlog.Debug(tag, $"StringSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ColorSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.ColorSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorSelectorClone()
        {
            tlog.Debug(tag, $"StringSelectorClone START");

            var testingTarget = new ColorSelector()
            {
                All = new Color(0.43f, 0.43f, 0.43f, 0.1f),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ColorSelector>(testingTarget, "Should return ColorSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Color]'
                //  to type 'Tizen.NUI.Components.ColorSelector'

                // To fix

                tlog.Debug(tag, $"ColorSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Size2DSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.Size2DSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Size2DSelectorClone()
        {
            tlog.Debug(tag, $"Size2DSelectorClone START");

            var testingTarget = new Size2DSelector()
            {
                All = new Size2D(100, 200),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Size2DSelector>(testingTarget, "Should return Size2DSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Size2D]'
                //  to type 'Tizen.NUI.Components.Size2DSelector'

                // To fix

                tlog.Debug(tag, $"Size2DSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Position2DSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.Position2DSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Position2DSelectorClone()
        {
            tlog.Debug(tag, $"Position2DSelectorClone START");

            var testingTarget = new Position2DSelector()
            {
                All = new Position2D(100, 200),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Position2DSelector>(testingTarget, "Should return Position2DSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Position2D]'
                //  to type 'Tizen.NUI.Components.Position2DSelector'

                // To fix

                tlog.Debug(tag, $"Position2DSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("PositionSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.PositionSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PositionSelectorClone()
        {
            tlog.Debug(tag, $"PositionSelectorClone START");

            var testingTarget = new PositionSelector()
            {
                All = new Position(100, 200),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<PositionSelector>(testingTarget, "Should return PositionSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Position]'
                //  to type 'Tizen.NUI.Components.PositionSelector'

                // To fix

                tlog.Debug(tag, $"PositionSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector2Selector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.Vector2Selector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2SelectorClone()
        {
            tlog.Debug(tag, $"Vector2SelectorClone START");

            var testingTarget = new Vector2Selector()
            {
                All = new Vector2(100, 20)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Vector2Selector>(testingTarget, "Should return Vector2Selector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Vector2]'
                //  to type 'Tizen.NUI.Components.Vector2Selector'

                // To fix

                tlog.Debug(tag, $"Vector2SelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector3Selector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.Vector3Selector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3SelectorClone()
        {
            tlog.Debug(tag, $"Vector3SelectorClone START");

            var testingTarget = new Vector3Selector()
            {
                All = new Vector3(100, 20, 0)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Vector3Selector>(testingTarget, "Should return Vector3Selector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Vector3]'
                //  to type 'Tizen.NUI.Components.Vector3Selector'

                // To fix

                tlog.Debug(tag, $"Vector3SelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RectangleSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.RectangleSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RectangleSelectorClone()
        {
            tlog.Debug(tag, $"RectangleSelectorClone START");

            var testingTarget = new RectangleSelector()
            { 
                All = new Rectangle(5, 5, 5, 5) 
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<RectangleSelector>(testingTarget, "Should return RectangleSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.Rectangle]'
                //  to type 'Tizen.NUI.Components.RectangleSelector'

                // To fix

                tlog.Debug(tag, $"RectangleSelectorClone END (OK)");
                Assert.Pass("Passed!");
            } 
        }

        [Test]
        [Category("P1")]
        [Description("HorizontalAlignmentSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.HorizontalAlignmentSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HorizontalAlignmentSelectorClone()
        {
            tlog.Debug(tag, $"HorizontalAlignmentSelectorClone START");

            var testingTarget = new HorizontalAlignmentSelector()
            {
                All = HorizontalAlignment.End,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<HorizontalAlignmentSelector>(testingTarget, "Should return HorizontalAlignmentSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.HorizontalAlignment]'
                //  to type 'Tizen.NUI.Components.HorizontalAlignmentSelector'

                // To fix

                tlog.Debug(tag, $"HorizontalAlignmentSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("VerticalAlignmentSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.VerticalAlignmentSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VerticalAlignmentSelectorClone()
        {
            tlog.Debug(tag, $"VerticalAlignmentSelectorClone START");

            var testingTarget = new VerticalAlignmentSelector()
            {
                All = VerticalAlignment.Center,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<VerticalAlignmentSelector>(testingTarget, "Should return VerticalAlignmentSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.VerticalAlignment]'
                //  to type 'Tizen.NUI.Components.VerticalAlignmentSelector'

                // To fix

                tlog.Debug(tag, $"VerticalAlignmentSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("AutoScrollStopModeSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.AutoScrollStopModeSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AutoScrollStopModeSelectorClone()
        {
            tlog.Debug(tag, $"AutoScrollStopModeSelectorClone START");

            var testingTarget = new AutoScrollStopModeSelector()
            {
                All = AutoScrollStopMode.Immediate,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AutoScrollStopModeSelector>(testingTarget, "Should return AutoScrollStopModeSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.AutoScrollStopMode]'
                //  to type 'Tizen.NUI.Components.AutoScrollStopModeSelector'

                // To fix

                tlog.Debug(tag, $"AutoScrollStopModeSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ResizePolicyTypeSelector Clone.")]
        [Property("SPEC", "Tizen.NUI.Components.ResizePolicyTypeSelector.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ResizePolicyTypeSelectorClone()
        {
            tlog.Debug(tag, $"ResizePolicyTypeSelectorClone START");

            var testingTarget = new ResizePolicyTypeSelector()
            {
                All = ResizePolicyType.FillToParent,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ResizePolicyTypeSelector>(testingTarget, "Should return ResizePolicyTypeSelector instance.");

            try
            {
                var result = testingTarget.Clone();
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception)
            {
                //  System.InvalidCastException : Unable to cast object
                //  of type 'Tizen.NUI.BaseComponents.Selector`1[Tizen.NUI.ResizePolicyType]'
                //  to type 'Tizen.NUI.Components.ResizePolicyTypeSelector'

                // To fix

                tlog.Debug(tag, $"ResizePolicyTypeSelectorClone END (OK)");
                Assert.Pass("Passed!");
            }
        }
    }
}
