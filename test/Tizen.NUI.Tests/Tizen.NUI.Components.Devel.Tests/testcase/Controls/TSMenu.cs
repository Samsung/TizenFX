using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Menu")]
    public class MenuTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyMenu : Menu
        {
            public MyMenu() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public View MyContent
            {
                get
                { 
                    return base.Content; 
                }
                set 
                {
                    base.Add(value);
                }
            }

            public View MyScrim
            {
                get
                {
                    return base.Scrim;
                }
                set
                {
                    base.Add(value);
                }
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
        [Description("Menu Scrim.")]
        [Property("SPEC", "Tizen.NUI.Components.Menu.Scrim M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuScrim()
        {
            tlog.Debug(tag, $"MenuScrim START");

            var testingTarget = new MyMenu();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Menu>(testingTarget, "Should return Menu instance.");

            View scrim = new View()
            {
                BackgroundColor = Color.Red,
            };
            testingTarget.MyScrim = scrim;
            testingTarget.MyScrim = scrim;

            testingTarget.Dispose();
            tlog.Debug(tag, $"MenuScrim END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Menu GetRootView.")]
        [Property("SPEC", "Tizen.NUI.Components.Menu.GetRootView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuGetRootView()
        {
            tlog.Debug(tag, $"MenuGetRootView START");

            var testingTarget = new MyMenu()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Menu>(testingTarget, "Should return Menu instance.");

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.HorizontalPositionToAnchor = Menu.RelativePosition.Start;
            tlog.Debug(tag, "HorizontalPositionToAnchor :" + testingTarget.HorizontalPositionToAnchor);

            testingTarget.VerticalPositionToAnchor = Menu.RelativePosition.Center;
            tlog.Debug(tag, "HorizontalPositionToAnchor :" + testingTarget.HorizontalPositionToAnchor);

            List<MenuItem> items = new List<MenuItem>();
            MenuItem item = new MenuItem();
            items.Add(item);
            items.Add(item);
            testingTarget.Items = items;

            MenuItem item2 = new MenuItem();
            items.Add(item2);
            testingTarget.Items = items;

            View content = new View()
            {
                Size = new Size2D(100, 30),
            };
            testingTarget.MyContent = content;

            View anchor1 = new View()
            {
                Size = new Size(100, 30),
                BackgroundColor = Color.Cyan
            };
            testingTarget.Anchor = anchor1;

            testingTarget.HorizontalPositionToAnchor = Menu.RelativePosition.Center;
            tlog.Debug(tag, "HorizontalPositionToAnchor :" + testingTarget.HorizontalPositionToAnchor);

            testingTarget.VerticalPositionToAnchor = Menu.RelativePosition.Start;
            tlog.Debug(tag, "HorizontalPositionToAnchor :" + testingTarget.HorizontalPositionToAnchor);

            View anchor2 = new View()
            {
                Size = new Size(100, 30),
                BackgroundColor = Color.Black
            };
            testingTarget.Anchor = anchor2;

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.OnDispose(DisposeTypes.Explicit);
            tlog.Debug(tag, $"MenuGetRootView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Menu OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.Menu.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task MenuOnRelayout()
        {
            tlog.Debug(tag, $"MenuOnRelayout START");

            var testingTarget = new MyMenu()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Menu>(testingTarget, "Should return Menu instance.");

            View content = new View()
            {
                Size = new Size2D(100, 30),
            };
            testingTarget.MyContent = content;

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Size = new Size(50, 80);
            testingTarget.BackgroundColor = Color.Blue;

            await Task.Delay(200);
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"MenuOnRelayout END (OK)");
        }
    }
}
