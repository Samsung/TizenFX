using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PageTurnPortraitView")]
    public class InternalPageTurnPortraitViewTest
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
        [Description("PageTurnPortraitView constructor.")]
        [Property("SPEC", "Tizen.NUI.PageTurnPortraitView.PageTurnPortraitView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnPortraitViewConstructor()
        {
            tlog.Debug(tag, $"PageTurnPortraitViewConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnPortraitView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnPortraitViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnPortraitView constructor. With PageTurnPortraitView.")]
        [Property("SPEC", "Tizen.NUI.PageTurnPortraitView.PageTurnPortraitView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnPortraitViewConstructorWithPageTurnPortraitView()
        {
            tlog.Debug(tag, $"PageTurnPortraitViewConstructorWithPageTurnPortraitView START");

            using (View view = new View())
            {
                using (PageTurnPortraitView portraitView = new PageTurnPortraitView(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new PageTurnPortraitView(portraitView);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"PageTurnPortraitViewConstructorWithPageTurnPortraitView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnPortraitView getCPtr.")]
        [Property("SPEC", "Tizen.NUI.PageTurnPortraitView.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnPortraitViewGetCPtr()
        {
            tlog.Debug(tag, $"PageTurnPortraitViewGetCPtr START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnPortraitView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

                try
                {
                    PageTurnPortraitView.getCPtr(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnPortraitViewGetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnPortraitView DownCast.")]
        [Property("SPEC", "Tizen.NUI.PageTurnPortraitView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnPortraitViewDownCast()
        {
            tlog.Debug(tag, $"PageTurnPortraitViewDownCast START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnPortraitView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

                try
                {
                    PageTurnPortraitView.DownCast(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnPortraitViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnPortraitView Assign.")]
        [Property("SPEC", "Tizen.NUI.PageTurnPortraitView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnPortraitViewAssign()
        {
            tlog.Debug(tag, $"PageTurnPortraitViewAssign START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnPortraitView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

                try
                {
                    testingTarget.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnPortraitViewAssign END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("PageTurnPortraitView constructor.")]
        //[Property("SPEC", "Tizen.NUI.PageTurnPortraitView.PageTurnPortraitView C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void PageTurnPortraitViewConstructor()
        //{
        //    tlog.Debug(tag, $"PageTurnPortraitViewConstructor START");

        //    using (View view = new View())
        //    {
        //        using (PageFactory pageFactory = new PageFactory(view.SwigCPtr.Handle, false))
        //        {
        //            using (Vector2 pageSize = new Vector2(100, 50))
        //            {
        //                var testingTarget = new PageTurnPortraitView(pageFactory, pageSize);
        //                Assert.IsNotNull(testingTarget, "Should be not null!");
        //                Assert.IsInstanceOf<PageTurnPortraitView>(testingTarget, "Should be an Instance of PageTurnPortraitView!");

        //                testingTarget.Dispose();
        //            }
        //        }
        //    }

        //    tlog.Debug(tag, $"PageTurnPortraitViewConstructor END (OK)");
        //}
    }
}
