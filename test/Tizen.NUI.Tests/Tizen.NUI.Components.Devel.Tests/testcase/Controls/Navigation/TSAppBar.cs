using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Navigation/AppBar")]
    class AppBarTest
    {
        private const string tag = "NUITEST";

        internal class MyAppBar : AppBar
        {
            public MyAppBar() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public void OnCreateViewStyle()
            {
                base.CreateViewStyle();
            }

            public string OnAccessibilityGetName()
            {
                return base.AccessibilityGetName();
            }

            public View OnPassFocusableViewInsideIfNeeded()
            {
                return base.PassFocusableViewInsideIfNeeded();
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
        [Description("AppBar Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.AppBar.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AppBarDispose()
        {
            tlog.Debug(tag, $"AppBarDispose START");

            var testingTarget = new MyAppBar();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AppBar>(testingTarget, "Should return AppBar instance.");

            testingTarget.AutoNavigationContent = false;
            tlog.Debug(tag, "AutoNavigationContent : " + testingTarget.AutoNavigationContent);

            testingTarget.AutoNavigationContent = false;    // if "== value", return
            testingTarget.AutoNavigationContent = true;
            tlog.Debug(tag, "AutoNavigationContent : " + testingTarget.AutoNavigationContent);

            View nc = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Cyan
            };
            testingTarget.NavigationContent = nc;
            testingTarget.NavigationContent = nc;

            View tc = new View()
            {
                Size = new Size(100, 20),
                Position = new Position(0, 0),
                BackgroundColor = Color.Green
            };
            testingTarget.TitleContent = tc;
            testingTarget.TitleContent = tc;

            List<View> actions = new List<View>();
            
            ViewStyle style1 = new ViewStyle()
            {
                BackgroundColor = Color.Red,
            };
            View action1 = new View(style1);

            ButtonStyle style2 = new ButtonStyle()
            {
                BackgroundColor = Color.Yellow,
                ItemAlignment = LinearLayout.Alignment.Center,
                ItemSpacing = new Size2D(10, 2)
            };
            tlog.Debug(tag, "ItemAlignment : " + style2.ItemAlignment);
            tlog.Debug(tag, "ItemSpacing : " + style2.ItemSpacing);
            View action2 = new Button(style2);

            actions.Add(action1);
            actions.Add(action2);

            testingTarget.Actions = actions;

            View ac = new View()
            {
                Size = new Size(100, 80),
                Position = new Position(0, 20)
            };
            testingTarget.ActionContent = ac;

            testingTarget.Actions = actions;

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Error(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AppBarDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AppBar CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.AppBar.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AppBarCreateViewStyle()
        {
            tlog.Debug(tag, $"AppBarCreateViewStyle START");

            var testingTarget = new MyAppBar();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AppBar>(testingTarget, "Should return AppBar instance.");

            try
            {
                testingTarget.OnCreateViewStyle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AppBarCreateViewStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AppBar AccessibilityGetName.")]
        [Property("SPEC", "Tizen.NUI.Components.AppBar.AccessibilityGetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AppBarAccessibilityGetName()
        {
            tlog.Debug(tag, $"AppBarAccessibilityGetName START");

            var testingTarget = new MyAppBar()
            {
                Size = new Size(200, 600),
                Focusable = true,
                Title = "AppBarTest"
            };

            var result = testingTarget.OnAccessibilityGetName();
            tlog.Debug(tag, "Title : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AppBarAccessibilityGetName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AppBar GetNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.AppBar.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AppBarGetNextFocusableView()
        {
            tlog.Debug(tag, $"AppBarGetNextFocusableView START");

            var testingTarget = new AppBar()
            {
                Size = new Size(200, 600),
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AppBar>(testingTarget, "Should return AppBar instance.");

            testingTarget.NavigationContent = new View()
            {
                Size = new Size(200, 500),
            };

            testingTarget.TitleContent = new View()
            {
                Size = new Size(200, 100),
            };

            try
            {
                testingTarget.GetNextFocusableView(testingTarget.TitleContent, View.FocusDirection.Down, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AppBarGetNextFocusableView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AppBar PassFocusableViewInsideIfNeeded.")]
        [Property("SPEC", "Tizen.NUI.Components.AppBar.PassFocusableViewInsideIfNeeded M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AppBarPassFocusableViewInsideIfNeeded()
        {
            tlog.Debug(tag, $"AppBarPassFocusableViewInsideIfNeeded START");

            var testingTarget = new MyAppBar()
            {
                Size = new Size(200, 600),
                Focusable = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AppBar>(testingTarget, "Should return AppBar instance.");

            testingTarget.NavigationContent = new View()
            {
                Size = new Size(200, 500),
            };

            testingTarget.TitleContent = new View()
            {
                Size = new Size(200, 100),
            };

            try
            {
                testingTarget.OnPassFocusableViewInsideIfNeeded();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AppBarPassFocusableViewInsideIfNeeded END (OK)");
        }
    }
}
