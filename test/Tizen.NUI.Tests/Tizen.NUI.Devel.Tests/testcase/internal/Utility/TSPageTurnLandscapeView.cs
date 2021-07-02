using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PageTurnLandscapeView")]
    public class InternalPageTurnLandscapeViewTest
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
        [Description("PageTurnLandscapeView constructor.")]
        [Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.PageTurnLandscapeView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnLandscapeViewConstructor()
        {
            tlog.Debug(tag, $"PageTurnLandscapeViewConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnLandscapeView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnLandscapeViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnLandscapeView constructor. With PageTurnLandscapeView.")]
        [Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.PageTurnLandscapeView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnLandscapeViewConstructorWithPageTurnLandscapeView()
        {
            tlog.Debug(tag, $"PageTurnLandscapeViewConstructorWithPageTurnLandscapeView START");

            using (View view = new View())
            {
                using (PageTurnLandscapeView landscapeView = new PageTurnLandscapeView(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new PageTurnLandscapeView(landscapeView);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"PageTurnLandscapeViewConstructorWithPageTurnLandscapeView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnLandscapeView getCPtr.")]
        [Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnLandscapeViewGetCPtr()
        {
            tlog.Debug(tag, $"PageTurnLandscapeViewGetCPtr START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnLandscapeView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

                try
                {
                    PageTurnLandscapeView.getCPtr(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnLandscapeViewGetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnLandscapeView DownCast.")]
        [Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnLandscapeViewDownCast()
        {
            tlog.Debug(tag, $"PageTurnLandscapeViewDownCast START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnLandscapeView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

                try
                {
                    PageTurnLandscapeView.DownCast(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnLandscapeViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnLandscapeView Assign.")]
        [Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnLandscapeViewAssign()
        {
            tlog.Debug(tag, $"PageTurnLandscapeViewAssign START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnLandscapeView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

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

            tlog.Debug(tag, $"PageTurnLandscapeViewAssign END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("PageTurnLandscapeView constructor.")]
        //[Property("SPEC", "Tizen.NUI.PageTurnLandscapeView.PageTurnLandscapeView C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void PageTurnLandscapeViewConstructor()
        //{
        //    tlog.Debug(tag, $"PageTurnLandscapeViewConstructor START");

        //    using (View view = new View())
        //    {
        //        using (PageFactory pageFactory = new PageFactory(view.SwigCPtr.Handle, true))
        //        {
        //            using (Vector2 pageSize = new Vector2(100, 50))
        //            {
        //                var testingTarget = new PageTurnLandscapeView(pageFactory, pageSize);
        //                Assert.IsNotNull(testingTarget, "Should be not null!");
        //                Assert.IsInstanceOf<PageTurnLandscapeView>(testingTarget, "Should be an Instance of PageTurnLandscapeView!");

        //                testingTarget.Dispose();
        //            }
        //        }
        //    }

        //    tlog.Debug(tag, $"PageTurnLandscapeViewConstructor END (OK)");
        //}
    }
}
