
using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ViewPublicMethods")]
    public class PublicBaseComponentsViewPublicMethodsTest
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
        [Description("View.AnimateBackgroundColor method")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ViewAnimateBackgroundColor()
        {
            tlog.Debug(tag, $"ViewAnimateBackgroundColor START");

            var view = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            Assert.IsNotNull(view, "should be not null");

            var animation = view.AnimateBackgroundColor(new Color(0, 0, 0, 1), 0, 300);

            Assert.IsNotNull(animation, "should be not null");

            view.Unparent();
            view.Dispose();
            tlog.Debug(tag, $"ViewAnimateBackgroundColor END (OK)");
        }

        [Test]
        [Description("View.AnimateColor method")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ViewAnimateColor()
        {
            tlog.Debug(tag, $"ViewAnimateColor START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            Assert.IsNotNull(view, "should be not null");

            var animation = view.AnimateColor("background", new Color(0, 0, 0, 1), 0, 200);

            Assert.IsNotNull(animation, "should be not null");

            view.Unparent();
            view.Dispose();
            tlog.Debug(tag, $"ViewAnimateColor END (OK)");
        }

        [Test]
        [Description("View.Add method, child null")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ViewAddArgumentNull()
        {
            tlog.Debug(tag, $"ViewAddArgumentNull START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            Assert.IsNotNull(view, "should be not null");

            try
            {
                view.Add(null);
            }
            catch (Exception e)
            {
                tlog.Fatal(tag, $"Exception occured, e={e}");
                Assert.Fail("No Exception required!");
            }
            finally
            {
                view.Unparent();
                view.Dispose();
                tlog.Debug(tag, $"ViewAddArgumentNull END (OK)");
            }
        }

        [Test]
        [Description("View.HasFocus method")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ViewHasFocus()
        {
            tlog.Debug(tag, $"ViewHasFocus START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            Assert.IsNotNull(view, "should be not null");

            Assert.IsFalse(view.HasFocus(), "should be false!");
            tlog.Debug(tag, $"ViewHasFocus END (OK)");
        }

        [Test]
        [Description("View.RotateBy method")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewRotateBy()
        {
            tlog.Debug(tag, $"ViewRotateBy START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            try
            {
                using (Degree degree = new Degree(0.3f))
                {
                    using (Vector3 axis = new Vector3(1.0f, 1.0f, 0.0f))
                    {
                        view.RotateBy(degree, axis);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            NUIApplication.GetDefaultWindow().Remove(view);
            view.Dispose();
            tlog.Debug(tag, $"ViewRotateBy END (OK)");
        }

        [Test]
        [Description("View.RotateBy method")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewRotateByRadian()
        {
            tlog.Debug(tag, $"ViewRotateByRadian START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            try
            {
                using (Radian angle = new Radian(0.3f))
                {
                    using (Vector3 axis = new Vector3(1.0f, 1.0f, 0.0f))
                    {
                        view.RotateBy(angle, axis);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            NUIApplication.GetDefaultWindow().Remove(view);
            view.Dispose();
            tlog.Debug(tag, $"ViewRotateByRadian END (OK)");
        }

        [Test]
        [Description("View.Rotation method")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewRotateByRotation()
        {
            tlog.Debug(tag, $"ViewRotateByRotation START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            try
            {
                using (Radian angle = new Radian(0.3f))
                {
                    using (Vector3 axis = new Vector3(1.0f, 1.0f, 0.0f))
                    {
                        using (Rotation relativeRotation = new Rotation(angle, axis))
                        {
                            view.RotateBy(relativeRotation);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            NUIApplication.GetDefaultWindow().Remove(view);
            view.Dispose();
            tlog.Debug(tag, $"ViewRotateByRotation END (OK)");
        }

        [Test]
        [Description("View.ScaleBy method")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewScaleBy()
        {
            tlog.Debug(tag, $"ViewScaleBy START");

            var view = new View()
            {
                Size = new Size2D(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                BackgroundColor = Color.Azure,
                Focusable = true,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            try
            {
                using (Vector3 relativeScale = new Vector3(1.0f, 1.0f, 0.0f))
                {
                    view.ScaleBy(relativeScale);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            NUIApplication.GetDefaultWindow().Remove(view);
            view.Dispose();
            tlog.Debug(tag, $"ViewScaleBy END (OK)");
        }
    }
}
