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
    [Description("Controls/Navigation/Navigator")]
    public class NavigationNavigatorTest
    {
        private const string tag = "NUITEST";

        internal class MyPage : Page { }

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
        [Description("PoppedEventArgs Page.")]
        [Property("SPEC", "Tizen.NUI.Components.PoppedEventArgs.Page A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PoppedEventArgsPage()
        {
            tlog.Debug(tag, $"PoppedEventArgsPage START");

            var testingTarget = new PoppedEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<PoppedEventArgs>(testingTarget, "Should return PoppedEventArgs instance.");

            tlog.Debug(tag, "Page : " + testingTarget.Page);

            tlog.Debug(tag, $"PoppedEventArgsPage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Navigator Transition.")]
        [Property("SPEC", "Tizen.NUI.Components.Navigator.Transition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NavigatorTransition()
        {
            tlog.Debug(tag, $"NavigatorTransition START");

            var testingTarget = new Navigator();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Navigator>(testingTarget, "Should return Navigator instance.");

            Transition ts = new Transition()
            {
                AlphaFunction = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn),
                TimePeriod = new TimePeriod(300)
            };

            testingTarget.Transition = ts;
            tlog.Debug(tag, "AppearingTransition : " + testingTarget.Transition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NavigatorTransition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Navigator PushWithTransition.")]
        [Property("SPEC", "Tizen.NUI.Components.Navigator.PushWithTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NavigatorPushWithTransition()
        {
            tlog.Debug(tag, $"NavigatorPushWithTransition START");

            var testingTarget = new Navigator()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Navigator>(testingTarget, "Should return Navigator instance.");

            Window.Instance.Add(testingTarget);

            var page1 = CreateFirstPage(testingTarget);
            var page2 = CreateSecondPage(testingTarget);
            testingTarget.Pop();
            var page3 = CreateThirdPage(testingTarget);
            var page4 = CreateFourthPage(testingTarget);

            Transition ts = new Transition()
            {
                AlphaFunction = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn),
                TimePeriod = new TimePeriod(300)
            };

            testingTarget.Transition = ts;
            tlog.Debug(tag, "Transition : " + testingTarget.Transition);

            try
            {
                testingTarget.PushWithTransition(page1);
                testingTarget.PopWithTransition();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            Window.Instance.Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NavigatorPushWithTransition END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Navigator PushWithTransition.")]
        [Property("SPEC", "Tizen.NUI.Components.Navigator.PushWithTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NavigatorPushWithTransitionWithNullPage()
        {
            tlog.Debug(tag, $"NavigatorPushWithTransitionWithNullPage START");

            var testingTarget = new Navigator()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Navigator>(testingTarget, "Should return Navigator instance.");

            Window.Instance.Add(testingTarget);

            Transition ts = new Transition()
            {
                AlphaFunction = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn),
                TimePeriod = new TimePeriod(300)
            };

            testingTarget.Transition = ts;

            MyPage page = null;

            try
            {
                testingTarget.PushWithTransition(page);
            }
            catch (ArgumentNullException)
            {
                Window.Instance.Remove(testingTarget);
                testingTarget.Dispose();
                tlog.Debug(tag, $"NavigatorPushWithTransitionWithNullPage END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        private Page CreateFirstPage(Navigator navigator)
        {
            var button = new Button()
            {
                Text = "First Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var page = new MyPage();
            page.Add(button);
            page.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("First Page is appearing!");
            };
            page.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("First Page is disappearing!");
            };

            navigator.Push(page);
            
            return page;
        }

        private Page CreateSecondPage(Navigator navigator)
        {
            var button = new Button()
            {
                Text = "Second Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var page = new MyPage();
            page.Add(button);
            page.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Second Page is appearing!");
            };
            page.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Second Page is disappearing!");
            };

            navigator.Push(page);

            return page;
        }

        private Page CreateThirdPage(Navigator navigator)
        {
            var button = new Button()
            {
                Text = "Third Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var page = new DialogPage();
            page.Add(button);
            page.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Third Page is appearing!");
            };
            page.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Third Page is disappearing!");
            };

            navigator.Push(page);

            return page;
        }

        private Page CreateFourthPage(Navigator navigator)
        {
            var button = new Button()
            {
                Text = "Fourth Page",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var page = new DialogPage();
            page.Add(button);
            page.Appearing += (object sender, PageAppearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Third Page is appearing!");
            };
            page.Disappearing += (object sender, PageDisappearingEventArgs e) =>
            {
                global::System.Console.WriteLine("Third Page is disappearing!");
            };

            navigator.Push(page);

            return page;
        }
    }
}
