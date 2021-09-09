using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PageTurnView")]
    public class InternalPageTurnViewTest
    {
        private const string tag = "NUITEST";
        private View view = null;
        private PageTurnView pageTurnView = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            View view = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan
            };
            view.OnWindowSignal();
            pageTurnView = new PageTurnView(view.SwigCPtr.Handle, false);
        }

        [TearDown]
        public void Destroy()
        {
            view.Dispose();
            view = null;
            pageTurnView.Dispose();
            pageTurnView = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView constructor")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageTurnView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewConstructorWithPageTurnView()
        {
            tlog.Debug(tag, $"PageTurnViewConstructorWithPageTurnView START");

            var testingTarget = new PageTurnView(pageTurnView);
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnView");
            Assert.IsInstanceOf<PageTurnView>(testingTarget, "Should be an instance of PageTurnView!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewConstructorWithPageTurnView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView Assign")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewAssign()
        {
            tlog.Debug(tag, $"PageTurnViewAssign START");

            var testingTarget = pageTurnView.Assign(pageTurnView);
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnView");
            Assert.IsInstanceOf<PageTurnView>(testingTarget, "Should be an instance of PageTurnView!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView DownCast")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewDownCast()
        {
            tlog.Debug(tag, $"PageTurnViewDownCast START");

            try
            {
                PageTurnView.DownCast(pageTurnView);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"PageTurnViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView GetPageTurnViewFromPtr")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.GetPageTurnViewFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewGetPageTurnViewFromPtr()
        {
            tlog.Debug(tag, $"PageTurnViewGetPageTurnViewFromPtr START");

            var testingTarget = PageTurnView.GetPageTurnViewFromPtr(pageTurnView.SwigCPtr.Handle);
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnView");
            Assert.IsInstanceOf<PageTurnView>(testingTarget, "Should be an instance of PageTurnView!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewGetPageTurnViewFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PageTurnStartedSignal")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageTurnStartedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPageTurnStartedSignal()
        {
            tlog.Debug(tag, $"PageTurnViewPageTurnStartedSignal START");

            var testingTarget = pageTurnView.PageTurnStartedSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnSignal");
            Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an instance of PageTurnSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewPageTurnStartedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PageTurnFinishedSignal")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageTurnFinishedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPageTurnFinishedSignal()
        {
            tlog.Debug(tag, $"PageTurnViewPageTurnFinishedSignal START");

            var testingTarget = pageTurnView.PageTurnFinishedSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnSignal");
            Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an instance of PageTurnSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewPageTurnFinishedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PagePanStartedSignal")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PagePanStartedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPagePanStartedSignal()
        {
            tlog.Debug(tag, $"PageTurnViewPagePanStartedSignal START");

            var testingTarget = pageTurnView.PagePanStartedSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object PagePanSignal");
            Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an instance of PagePanSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewPagePanStartedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PagePanFinishedSignal")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PagePanFinishedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPagePanFinishedSignal()
        {
            tlog.Debug(tag, $"PageTurnViewPagePanFinishedSignal START");

            var testingTarget = pageTurnView.PagePanFinishedSignal();
            Assert.IsNotNull(testingTarget, "Can't create success object PagePanSignal");
            Assert.IsInstanceOf<PagePanSignal>(testingTarget, "Should be an instance of PagePanSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageTurnViewPagePanFinishedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PageSize")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPageSize()
        {
            tlog.Debug(tag, $"PageTurnViewPageSize START");

            pageTurnView.PageSize = new Vector2(100, 50);
            tlog.Debug(tag, "PageSize : " + pageTurnView.PageSize);

            tlog.Debug(tag, $"PageTurnViewPageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView CurrentPageId")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.CurrentPageId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewCurrentPageId()
        {
            tlog.Debug(tag, $"PageTurnViewCurrentPageId START");

            pageTurnView.CurrentPageId = 1;
            tlog.Debug(tag, "CurrentPageId : " + pageTurnView.CurrentPageId);

            tlog.Debug(tag, $"PageTurnViewCurrentPageId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView SpineShadow")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.SpineShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewSpineShadow()
        {
            tlog.Debug(tag, $"PageTurnViewSpineShadow START");

            pageTurnView.SpineShadow = new Vector2(100, 50);
            tlog.Debug(tag, "SpineShadow : " + pageTurnView.SpineShadow);

            tlog.Debug(tag, $"PageTurnViewSpineShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PagePanStartedEventArgs")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PagePanStartedEventArgs A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPagePanStartedEventArgs()
        {
            tlog.Debug(tag, $"PageTurnViewPagePanStartedEventArgs START");

            var testingTarget = new PageTurnView.PagePanStartedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PagePanStartedEventArgs");
            Assert.IsInstanceOf<PageTurnView.PagePanStartedEventArgs>(testingTarget, "Should be an instance of PagePanStartedEventArgs!");

            testingTarget.PageTurnView = pageTurnView;
            tlog.Debug(tag, "pageTurnView : " + testingTarget.PageTurnView);

            tlog.Debug(tag, $"PageTurnViewPagePanStartedEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PagePanFinishedEventArgs ")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PagePanFinishedEventArgs  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPagePanFinishedEventArgs()
        {
            tlog.Debug(tag, $"PageTurnViewPagePanFinishedEventArgs  START");

            var testingTarget = new PageTurnView.PagePanFinishedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PagePanFinishedEventArgs");
            Assert.IsInstanceOf<PageTurnView.PagePanFinishedEventArgs>(testingTarget, "Should be an instance of PagePanFinishedEventArgs !");

            testingTarget.PageTurnView = pageTurnView;
            tlog.Debug(tag, "pageTurnView : " + testingTarget.PageTurnView);

            tlog.Debug(tag, $"PageTurnViewPagePanFinishedEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PageTurnStartedEventArgs ")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageTurnStartedEventArgs  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPageTurnStartedEventArgs()
        {
            tlog.Debug(tag, $"PageTurnViewPageTurnStartedEventArgs  START");

            var testingTarget = new PageTurnView.PageTurnStartedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnStartedEventArgs");
            Assert.IsInstanceOf<PageTurnView.PageTurnStartedEventArgs>(testingTarget, "Should be an instance of PageTurnStartedEventArgs !");

            testingTarget.PageTurnView = pageTurnView;
            tlog.Debug(tag, "pageTurnView : " + testingTarget.PageTurnView);

            testingTarget.PageIndex = 1;
            tlog.Debug(tag, "PageIndex : " + testingTarget.PageIndex);

            testingTarget.IsTurningForward = true;
            tlog.Debug(tag, "IsTurningForward : " + testingTarget.IsTurningForward);

            tlog.Debug(tag, $"PageTurnViewPageTurnStartedEventArgs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnView PageTurnFinishedEventArgs  ")]
        [Property("SPEC", "Tizen.NUI.PageTurnView.PageTurnFinishedEventArgs   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnViewPageTurnFinishedEventArgs()
        {
            tlog.Debug(tag, $"PageTurnViewPageTurnFinishedEventArgs   START");

            var testingTarget = new PageTurnView.PageTurnFinishedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object PageTurnFinishedEventArgs ");
            Assert.IsInstanceOf<PageTurnView.PageTurnFinishedEventArgs>(testingTarget, "Should be an instance of PageTurnFinishedEventArgs  !");

            testingTarget.PageTurnView = pageTurnView;
            tlog.Debug(tag, "pageTurnView : " + testingTarget.PageTurnView);

            testingTarget.PageIndex = 1;
            tlog.Debug(tag, "PageIndex : " + testingTarget.PageIndex);

            testingTarget.IsTurningForward = true;
            tlog.Debug(tag, "IsTurningForward : " + testingTarget.IsTurningForward);

            tlog.Debug(tag, $"PageTurnViewPageTurnFinishedEventArgs  END (OK)");
        }

        private void OnPagePanStarted(object source, PageTurnView.PagePanStartedEventArgs e) { }
        private void OnPagePanFinished(object source, PageTurnView.PagePanFinishedEventArgs e) { }
        private void OnPageTurnFinished(object source, PageTurnView.PageTurnFinishedEventArgs e) { }
        private void OnPageTurnStarted(object source, PageTurnView.PageTurnStartedEventArgs e) { }
    }
}
