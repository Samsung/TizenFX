using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Navigation/ContentPage")]
    public class ContentPageTest
    {
        private const string tag = "NUITEST";

        internal class MyContentPage : ContentPage
        {
            public MyContentPage() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
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
        [Description("ContentPage constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ContentPage.ContentPage C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ContentPageConstructor()
        {
            tlog.Debug(tag, $"ContentPageConstructor START");

            var testingTarget = new MyContentPage();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ContentPage>(testingTarget, "Should return ContentPage instance.");

            AppBar bar = new AppBar()
            { 
                Title = "AppBar",
            };
            testingTarget.AppBar = bar;
            tlog.Debug(tag, "AppBar : " + testingTarget.AppBar);

            testingTarget.AppBar = bar;

            AppBar bar2 = new AppBar()
            { 
                Title = "AppBar2",
            };
            testingTarget.AppBar = bar2;
            tlog.Debug(tag, "AppBar : " + testingTarget.AppBar);

            View content = new View()
            { 
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan,
            };
            testingTarget.Content = content;
            tlog.Debug(tag, "Content : " + testingTarget.Content);

            testingTarget.Content = content;

            View content2 = new View()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };
            testingTarget.Content = content2;
            tlog.Debug(tag, "Content : " + testingTarget.Content);

            testingTarget.OnDispose(DisposeTypes.Explicit);
            tlog.Debug(tag, $"ContentPageConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ContentPage OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.ContentPage.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task ContentPageOnRelayout()
        {
            tlog.Debug(tag, $"ContentPageOnRelayout START");

            var testingTarget = new MyContentPage()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ContentPage>(testingTarget, "Should return ContentPage instance.");

            AppBar bar = new AppBar()
            {
                Title = "AppBar",
                Size = new Size(100, 20)
            };
            testingTarget.AppBar = bar;
            tlog.Debug(tag, "AppBar : " + testingTarget.AppBar);

            testingTarget.AppBar = bar;

            testingTarget.AppBar.WidthSpecification = LayoutParamPolicies.MatchParent;
            testingTarget.AppBar.HeightSpecification = LayoutParamPolicies.MatchParent;

            View content = new View()
            { 
                Size = new Size(100, 180)
            };
            testingTarget.Content = content;

            testingTarget.Content.WidthSpecification = LayoutParamPolicies.MatchParent;
            testingTarget.Content.HeightSpecification = LayoutParamPolicies.MatchParent;

            testingTarget.Size = new Size(200, 400);

            await Task.Delay(200);

            testingTarget.OnDispose(DisposeTypes.Explicit);
            tlog.Debug(tag, $"ContentPageOnRelayout END (OK)");
        }
    }
}
