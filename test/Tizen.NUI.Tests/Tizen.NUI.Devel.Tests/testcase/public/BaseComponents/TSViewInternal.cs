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
            tlog.Debug(tag, "ViewWorldPositionZ : " + testingTarget.WorldPositionZ);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewWorldPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View FocusState.")]
        [Property("SPEC", "Tizen.NUI.View.FocusState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewFocusState()
        {
            tlog.Debug(tag, $"ViewFocusState START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            FocusManager.Instance.SetCurrentFocusView(testingTarget);
            tlog.Debug(tag, "FocusState : " + testingTarget.FocusState);

            testingTarget.FocusState = false;
            tlog.Debug(tag, "FocusState : " + testingTarget.FocusState);

            FocusManager.Instance.ClearFocus();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewFocusState END (OK)");
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

            testingTarget.ParentOriginZ = 0.5f;
            tlog.Debug(tag, "ParentOriginZ : " + testingTarget.ParentOriginZ);

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

            testingTarget.PivotPointZ = 0.5f;
            tlog.Debug(tag, "PivotPointZ : " + testingTarget.PivotPointZ);

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

            var result = testingTarget.WorldMatrix;
            tlog.Debug(tag, "WorldMatrix : " + testingTarget.WorldMatrix);

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
            tlog.Debug(tag, "GetName : " + testingTarget.GetName());

            testingTarget.SetName("grandpa");
            tlog.Debug(tag, "GetName : " + testingTarget.GetName());

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
        [Description("View SetParentOrigin.")]
        [Property("SPEC", "Tizen.NUI.View.SetParentOrigin M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetParentOrigin()
        {
            tlog.Debug(tag, $"ViewSetParentOrigin START");

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
                testingTarget.SetParentOrigin(vec);
                var result = testingTarget.GetCurrentParentOrigin();
                tlog.Debug(tag, "Current parent originX : " + result.X);
                tlog.Debug(tag, "Current parent originY : " + result.Y);
                tlog.Debug(tag, "Current parent originZ : " + result.Z);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetParentOrigin END (OK)");
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
        [Description("View SetSize.")]
        [Property("SPEC", "Tizen.NUI.View.SetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetSizeWithVector2()
        {
            tlog.Debug(tag, $"ViewSetSizeWithVector2 START");

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
                using (Vector2 vec = new Vector2(80.0f, 50.0f))
                {
                    testingTarget.SetSize(vec);
                }
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetSizeWithVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetSize.")]
        [Property("SPEC", "Tizen.NUI.View.SetSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetSizeWithVector3()
        {
            tlog.Debug(tag, $"ViewSetSizeWithVector3 START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            tlog.Debug(tag, "GetCurrentSizeFloat : " + testingTarget.GetCurrentSizeFloat());
            tlog.Debug(tag, "GetNaturalSize : " + testingTarget.GetNaturalSize());

            try
            {
                using (Vector3 vec = new Vector3(80.0f, 50.0f, 30.0f))
                {
                    testingTarget.SetSize(vec);
                    testingTarget.GetTargetSize();
                }
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetSizeWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetPosition.")]
        [Property("SPEC", "Tizen.NUI.View.SetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetPosition()
        {
            tlog.Debug(tag, $"ViewSetPosition START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetX(0.1f);
            testingTarget.SetY(0.5f);
            testingTarget.SetZ(0.9f);

            try
            {
                Position pos = null;
                testingTarget.SetPosition(0.2f, 0.6f);
                pos = testingTarget.GetCurrentPosition();
                tlog.Debug(tag, "GetCurrentPosition : " + pos);

                testingTarget.SetPosition(0.2f, 0.6f, 1.0f);
                pos = testingTarget.GetCurrentPosition();
                tlog.Debug(tag, "GetCurrentPosition : " + pos);

                using (Vector3 vec = new Vector3(0.3f, 0.7f, 0.4f))
                {
                    testingTarget.SetPosition(vec);
                    pos = testingTarget.GetCurrentPosition();
                    tlog.Debug(tag, "GetCurrentPosition : " + pos);
                }
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View TranslateBy.")]
        [Property("SPEC", "Tizen.NUI.View.TranslateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewTranslateBy()
        {
            tlog.Debug(tag, $"ViewTranslateBy START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetX(0.1f);
            testingTarget.SetY(0.5f);
            testingTarget.SetZ(0.9f);

            try
            {
                using (Vector3 distance = new Vector3(0.3f, 0.7f, 0.4f))
                {
                    testingTarget.TranslateBy(distance);
                }
            }
            catch (Exception e)
            {
                tlog.Debug("tag", e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewTranslateBy END (OK)");
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

            testingTarget.SetX(0.1f);
            testingTarget.SetY(0.5f);
            testingTarget.SetZ(0.9f);

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
        [Description("View SetInheritPosition.")]
        [Property("SPEC", "Tizen.NUI.View.SetInheritPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetInheritPosition()
        {
            tlog.Debug(tag, $"ViewSetInheritPosition START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetInheritPosition(true);
            var result = testingTarget.IsPositionInherited();
            tlog.Debug(tag, "Is position inheirted : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetInheritPosition END (OK)");
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
                    tlog.Debug(tag, "GetCurrentWorldOrientation : " + testingTarget.GetCurrentWorldOrientation());
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetOrientation.")]
        [Property("SPEC", "Tizen.NUI.View.SetOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetOrientationWithRadian()
        {
            tlog.Debug(tag, $"ViewSetOrientationWithRadian START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Radian radian = new Radian(0.5f))
            {
                using (Vector3 axis = new Vector3(0.1f, 0.3f, 0.5f))
                {
                    testingTarget.SetOrientation(radian, axis);
                    var result = testingTarget.GetCurrentOrientation();
                    tlog.Debug(tag, "Get current orientation : " + result);
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetOrientationWithRadian END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetOrientation.")]
        [Property("SPEC", "Tizen.NUI.View.SetOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetOrientationWithRotation()
        {
            tlog.Debug(tag, $"ViewSetOrientationWithRotation START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Radian radian = new Radian(0.5f))
            {
                using (Vector3 axis = new Vector3(0.1f, 0.3f, 0.5f))
                {
                    using (Rotation rotation = new Rotation(radian, axis))
                    {
                        testingTarget.SetOrientation(rotation);
                        var result = testingTarget.GetCurrentOrientation();
                        tlog.Debug(tag, "Get current orientation : " + result);
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetOrientationWithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetInheritOrientation.")]
        [Property("SPEC", "Tizen.NUI.View.SetInheritOrientation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetInheritOrientation()
        {
            tlog.Debug(tag, $"ViewSetInheritOrientation START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetInheritOrientation(true);
            var result = testingTarget.IsOrientationInherited();
            tlog.Debug(tag, "Is orientation inheirted : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetInheritOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetScale.")]
        [Property("SPEC", "Tizen.NUI.View.SetScale M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetScale()
        {
            tlog.Debug(tag, $"ViewSetScale START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            Vector3 result = null;
            testingTarget.SetScale(0.3f);
            result = testingTarget.GetCurrentScale();
            tlog.Debug(tag, "Get current scale : " + result);

            testingTarget.SetScale(0.3f, 0.5f, 0.8f);
            result = testingTarget.GetCurrentScale();
            tlog.Debug(tag, "Get current scale : " + result);

            using (Vector3 scale = new Vector3(0.5f, 0.9f, 0.0f))
            {
                testingTarget.SetScale(scale);
                result = testingTarget.GetCurrentScale();
                tlog.Debug(tag, "Get current scale : " + result);
            }

            result = testingTarget.GetCurrentWorldScale();
            tlog.Debug(tag, "Get current world scale : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetInheritScale.")]
        [Property("SPEC", "Tizen.NUI.View.SetInheritScale M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetInheritScale()
        {
            tlog.Debug(tag, $"ViewSetInheritScale START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetInheritScale(true);
            var result = testingTarget.IsScaleInherited();
            tlog.Debug(tag, "Is scale inheirted : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetInheritScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View GetCurrentWorldMatrix.")]
        [Property("SPEC", "Tizen.NUI.View.GetCurrentWorldMatrix M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetCurrentWorldMatrix()
        {
            tlog.Debug(tag, $"ViewGetCurrentWorldMatrix START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var result = testingTarget.GetCurrentWorldMatrix();
            tlog.Debug(tag, "Current world matrix : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetCurrentWorldMatrix END (OK)");
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
        [Description("View SetDrawMode.")]
        [Property("SPEC", "Tizen.NUI.View.SetDrawMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetDrawMode()
        {
            tlog.Debug(tag, $"ViewSetDrawMode START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.SetDrawMode(DrawModeType.Stencil);
            var result = testingTarget.GetDrawMode();
            tlog.Debug(tag, "Draw mode : " + result);
            

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetDrawMode END (OK)");
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
        [Description("View GetSizeModeFactor.")]
        [Property("SPEC", "Tizen.NUI.View.GetSizeModeFactor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewGetSizeModeFactor()
        {
            tlog.Debug(tag, $"ViewGetSizeModeFactor START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var result = testingTarget.GetSizeModeFactor();
            tlog.Debug(tag, "GetSizeModeFactor : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewGetSizeModeFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetMinimumSize.")]
        [Property("SPEC", "Tizen.NUI.View.SetMinimumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetMinimumSize()
        {
            tlog.Debug(tag, $"ViewSetMinimumSize START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Vector2 vec = new Vector2(10.0f, 20.0f))
            {
                testingTarget.SetMinimumSize(vec);
                var result = testingTarget.GetMinimumSize();
                tlog.Debug(tag, "GetMinimumSize : " + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetMinimumSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View SetMaximumSize.")]
        [Property("SPEC", "Tizen.NUI.View.SetMaximumSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetMaximumSize()
        {
            tlog.Debug(tag, $"ViewSetMaximumSize START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            using (Vector2 vec = new Vector2(120.0f, 200.0f))
            {
                testingTarget.SetMaximumSize(vec);
                var result = testingTarget.GetMaximumSize();
                tlog.Debug(tag, "GetMaximumSize : " + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewSetMaximumSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View IsTopLevelView.")]
        [Property("SPEC", "Tizen.NUI.View.IsTopLevelView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewIsTopLevelView()
        {
            tlog.Debug(tag, $"ViewIsTopLevelView START");

            var testingTarget = new View()
            {
                Name = "parent",
                Size = new Size(100.0f, 50.0f),
                Color = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            var result = testingTarget.IsTopLevelView();
            tlog.Debug(tag, "IsTopLevelView : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewIsTopLevelView END (OK)");
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
        [Description("View SetKeyInputFocus.")]
        [Property("SPEC", "Tizen.NUI.View.SetKeyInputFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSetKeyInputFocus()
        {
            tlog.Debug(tag, $"ViewSetKeyInputFocus START");

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
                testingTarget.SetKeyInputFocus();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearKeyInputFocus();
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
