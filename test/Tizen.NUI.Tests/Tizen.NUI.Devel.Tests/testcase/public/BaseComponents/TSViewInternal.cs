using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ViewInternal")]
    public class PublicViewInternalTest
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
        [Description("View ControlStatePropagation.")]
        [Property("SPEC", "Tizen.NUI.View.ControlStatePropagation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewControlStatePropagation()
        {
            tlog.Debug(tag, $"ViewControlStatePropagation START");

            var testingTarget = new Tizen.NUI.BaseComponents.View.ThemeData();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.View.ThemeData>(testingTarget, "Should be an instance of ThemeData type.");

            testingTarget.ControlStatePropagation = false;
            tlog.Debug(tag, "ControlStatePropagation : " + testingTarget.ControlStatePropagation);

            testingTarget.ThemeChangeSensitive = false;
            tlog.Debug(tag, "ThemeChangeSensitive : " + testingTarget.ThemeChangeSensitive);

            testingTarget.ThemeApplied = false;
            tlog.Debug(tag, "ThemeApplied : " + testingTarget.ThemeApplied);

            testingTarget.ListeningThemeChangeEvent = false;
            tlog.Debug(tag, "ListeningThemeChangeEvent : " + testingTarget.ListeningThemeChangeEvent);

            tlog.Debug(tag, $"ViewControlStatePropagation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View ColorMode.")]
        [Property("SPEC", "Tizen.NUI.View.ColorMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewColorMode()
        {
            tlog.Debug(tag, $"ViewColorMode START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.ColorMode = ColorMode.UseOwnColor;
            tlog.Debug(tag, "ColorMode : " + testingTarget.ColorMode);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewColorMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SuggestedMinimumWidth.")]
        [Property("SPEC", "Tizen.NUI.View.SuggestedMinimumWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSuggestedMinimumWidth()
        {
            tlog.Debug(tag, $"ViewSuggestedMinimumWidth START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var width = testingTarget.SuggestedMinimumWidth;
            tlog.Debug(tag, "SuggestedMinimumWidth : " + width);

            var height = testingTarget.SuggestedMinimumHeight;
            tlog.Debug(tag, "SuggestedMinimumHeight : " + height);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSuggestedMinimumWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View WorldPositionX.")]
        [Property("SPEC", "Tizen.NUI.View.WorldPositionX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewWorldPosition()
        {
            tlog.Debug(tag, $"ViewWorldPosition START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            tlog.Debug(tag, "ViewWorldPositionX : " + testingTarget.WorldPositionX);
            tlog.Debug(tag, "ViewWorldPositionY : " + testingTarget.WorldPositionY);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewWorldPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View ParentOrigin.")]
        [Property("SPEC", "Tizen.NUI.View.ParentOrigin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewParentOrigin()
        {
            tlog.Debug(tag, $"ViewParentOrigin START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.ParentOriginX = 0.3f;
            tlog.Debug(tag, "ParentOriginX : " + testingTarget.ParentOriginX);

            testingTarget.ParentOriginY = 0.4f;
            tlog.Debug(tag, "ParentOriginY : " + testingTarget.ParentOriginY);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewParentOrigin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View PivotPoint.")]
        [Property("SPEC", "Tizen.NUI.View.PivotPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewPivotPoint()
        {
            tlog.Debug(tag, $"ViewPivotPoint START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.PivotPointX = 0.3f;
            tlog.Debug(tag, "PivotPointX : " + testingTarget.PivotPointX);

            testingTarget.PivotPointY = 0.4f;
            tlog.Debug(tag, "PivotPointY : " + testingTarget.PivotPointY);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewPivotPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View WorldMatrix.")]
        [Property("SPEC", "Tizen.NUI.View.WorldMatrix A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewWorldMatrix()
        {
            tlog.Debug(tag, $"ViewWorldMatrix START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewWorldMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View Raise.")]
        [Property("SPEC", "Tizen.NUI.View.Raise M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewRaise()
        {
            tlog.Debug(tag, $"ViewRaise START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            View child = new View()
            {
                Size = new Size(20, 30)
            };
            testingTarget.Add(child);

            try
            {
                child.Raise();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            child.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewRaise END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View Lower.")]
        [Property("SPEC", "Tizen.NUI.View.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewLower()
        {
            tlog.Debug(tag, $"ViewLower START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            View child = new View()
            {
                Size = new Size(20, 30)
            };
            testingTarget.Add(child);

            try
            {
                child.Lower();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            child.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewLower END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View RaiseAbove.")]
        [Property("SPEC", "Tizen.NUI.View.RaiseAbove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewRaiseAbove()
        {
            tlog.Debug(tag, $"ViewRaiseAbove START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            View child = new View()
            {
                Size = new Size(20, 30)
            };
            testingTarget.Add(child);

            try
            {
                child.RaiseAbove(testingTarget);
                testingTarget.LowerBelow(child);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            child.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewRaiseAbove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetName.")]
        [Property("SPEC", "Tizen.NUI.View.GetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetName()
        {
            tlog.Debug(tag, $"ViewGetName START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            tlog.Debug(tag, "IsRoot : " + testingTarget.IsRoot());
            tlog.Debug(tag, "OnWindow : " + testingTarget.OnWindow());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View FindChildById.")]
        [Property("SPEC", "Tizen.NUI.View.FindChildById M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewFindChildById()
        {
            tlog.Debug(tag, $"ViewFindChildById START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            View child = new View()
            {
                Size = new Size(20, 30)
            };
            testingTarget.Add(child);

            var result = testingTarget.FindCurrentChildById(child.ID);
            tlog.Debug(tag, "Find child by Id : " + result);

            child.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewFindChildById END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetAnchorPoint.")]
        [Property("SPEC", "Tizen.NUI.View.SetAnchorPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetAnchorPoint()
        {
            tlog.Debug(tag, $"ViewSetAnchorPoint START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Vector3 vec = new Vector3(0.1f, 0.5f, 0.9f))
            {
                testingTarget.SetAnchorPoint(vec);
                var result = testingTarget.GetCurrentAnchorPoint();
                tlog.Debug(tag, "Current anchor PointX : " + result.X);
                tlog.Debug(tag, "Current anchor PointY : " + result.Y);
                tlog.Debug(tag, "Current anchor PointZ : " + result.Z);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetAnchorPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetSize.")]
        [Property("SPEC", "Tizen.NUI.View.SetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetSize()
        {
            tlog.Debug(tag, $"ViewSetSize START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                Size2D size = null;
                testingTarget.SetSize(80.0f, 50.0f);
                size = testingTarget.GetCurrentSize();
                tlog.Debug(tag, "GetCurrentSize : " + size);

                testingTarget.SetSize(80.0f, 50.0f, 30.0f);
                size = testingTarget.GetCurrentSize();
                tlog.Debug(tag, "GetCurrentSize : " + size);
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetCurrentWorldPosition.")]
        [Property("SPEC", "Tizen.NUI.View.GetCurrentWorldPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetCurrentWorldPosition()
        {
            tlog.Debug(tag, $"ViewGetCurrentWorldPosition START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.Position = new Position(0.1f, 0.5f, 0.9f);

            try
            {
                var result = testingTarget.GetCurrentWorldPosition();
                tlog.Debug(tag, "Get current world position : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetCurrentWorldPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetOrientation.")]
        [Property("SPEC", "Tizen.NUI.View.SetOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetOrientation()
        {
            tlog.Debug(tag, $"ViewSetOrientation START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Degree degree = new Degree(0.3f))
            {
                using (Vector3 axis = new Vector3(0.1f, 0.3f, 0.5f))
                {
                    testingTarget.SetOrientation(degree, axis);
                    var result = testingTarget.GetCurrentOrientation();
                    tlog.Debug(tag, "GetCurrentOrientation : " + result);
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetVisible.")]
        [Property("SPEC", "Tizen.NUI.View.SetVisible M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetVisible()
        {
            tlog.Debug(tag, $"ViewSetVisible START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetVisible(true);
            var result = testingTarget.IsVisible();
            tlog.Debug(tag, "IsVisible : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetVisible END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetOpacity.")]
        [Property("SPEC", "Tizen.NUI.View.SetOpacity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetOpacity()
        {
            tlog.Debug(tag, $"ViewSetOpacity START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetOpacity(0.8f);
            var result = testingTarget.GetCurrentOpacity();
            tlog.Debug(tag, "Current opacity : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetOpacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetCurrentColor.")]
        [Property("SPEC", "Tizen.NUI.View.GetCurrentColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetCurrentColor()
        {
            tlog.Debug(tag, $"ViewGetCurrentColor START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var result = testingTarget.GetCurrentColor();
            tlog.Debug(tag, "Current color : " + result);
            tlog.Debug(tag, "Color mode : " + testingTarget.GetColorMode());
            tlog.Debug(tag, "Current world color : " + testingTarget.GetCurrentWorldColor());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetCurrentColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetFocusableInTouch.")]
        [Property("SPEC", "Tizen.NUI.View.SetFocusableInTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetFocusableInTouch()
        {
            tlog.Debug(tag, $"ViewSetFocusableInTouch START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetFocusableInTouch(true);
            var result = testingTarget.IsFocusableInTouch();
            tlog.Debug(tag, "IsFocusableInTouch : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetFocusableInTouch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetResizePolicy.")]
        [Property("SPEC", "Tizen.NUI.View.SetResizePolicy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetResizePolicy()
        {
            tlog.Debug(tag, $"ViewSetResizePolicy START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.SetResizePolicy(ResizePolicyType.FillToParent, DimensionType.Height);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            var result = testingTarget.GetResizePolicy(DimensionType.Height);
            tlog.Debug(tag, "GetResizePolicy : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetResizePolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetPtrfromView.")]
        [Property("SPEC", "Tizen.NUI.View.GetPtrfromView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetPtrfromView()
        {
            tlog.Debug(tag, $"ViewGetPtrfromView START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var result = testingTarget.GetPtrfromView();
            tlog.Debug(tag, "GetPtrfromView : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetPtrfromView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetPinchGestureDetector.")]
        [Property("SPEC", "Tizen.NUI.View.GetPinchGestureDetector M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetPinchGestureDetector()
        {
            tlog.Debug(tag, $"ViewGetPinchGestureDetector START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var pinch = testingTarget.GetPinchGestureDetector();
            tlog.Debug(tag, "GetPinchGestureDetector : " + pinch);

            var pan = testingTarget.GetPanGestureDetector();
            tlog.Debug(tag, "GetPanGestureDetector : " + pan);

            var tap = testingTarget.GetTapGestureDetector();
            tlog.Debug(tag, "GetTapGestureDetector : " + tap);

            var lpress = testingTarget.GetLongPressGestureDetector();
            tlog.Debug(tag, "GetLongPressGestureDetector : " + lpress);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetPinchGestureDetector END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetKeyboardFocusable.")]
        [Property("SPEC", "Tizen.NUI.View.SetKeyboardFocusable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetKeyboardFocusable()
        {
            tlog.Debug(tag, $"ViewSetKeyboardFocusable START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetKeyboardFocusable(true);
            var result = testingTarget.IsKeyboardFocusable();
            tlog.Debug(tag, "IsKeyboardFocusable : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetKeyboardFocusable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetHierarchyDepth.")]
        [Property("SPEC", "Tizen.NUI.View.GetHierarchyDepth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetHierarchyDepth()
        {
            tlog.Debug(tag, $"ViewGetHierarchyDepth START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var depth = testingTarget.GetHierarchyDepth();
            tlog.Debug(tag, "GetHierarchyDepth : " + depth);

            var count = testingTarget.GetRendererCount();
            tlog.Debug(tag, "GetRendererCount : " + count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetKeyboardFocusable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View ResetLayout.")]
        [Property("SPEC", "Tizen.NUI.View.ResetLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResetLayout()
        {
            tlog.Debug(tag, $"ViewResetLayout START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
                Layout = new LinearLayout()
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.ResetLayout();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewResetLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetBackgroundResourceStatus.")]
        [Property("SPEC", "Tizen.NUI.View.GetBackgroundResourceStatus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetBackgroundResourceStatus()
        {
            tlog.Debug(tag, $"ViewGetBackgroundResourceStatus START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
                Layout = new LinearLayout()
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.GetBackgroundResourceStatus();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetBackgroundResourceStatus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetThemeApplied.")]
        [Property("SPEC", "Tizen.NUI.View.SetThemeApplied M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetThemeApplied()
        {
            tlog.Debug(tag, $"ViewSetThemeApplied START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            try
            {
                testingTarget.SetThemeApplied();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetThemeApplied END (OK)");
        }
    }
}
