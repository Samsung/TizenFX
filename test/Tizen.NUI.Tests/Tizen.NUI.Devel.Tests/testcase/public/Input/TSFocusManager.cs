using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/FocusManager")]
    internal class PublicFocusManagerTest
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
        [Description("Create a FocusManager object.")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerConstructor()
        {
            tlog.Debug(tag, $"FocusManagerConstructor START");
            FocusManager a1 = new FocusManager();

            a1.Dispose();

            tlog.Debug(tag, $"FocusManagerConstructor END (OK)");
            Assert.Pass("FocusManagerConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager PreFocusChange")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerPreFocusChange()
        {
            tlog.Debug(tag, $"FocusManagerPreFocusChange START");
            FocusManager a1 = FocusManager.Instance;

            a1.PreFocusChange += A1_PreFocusChange;
            a1.PreFocusChange -= A1_PreFocusChange;

            tlog.Debug(tag, $"112");
            object o1 = new object();
            FocusManager.PreFocusChangeEventArgs e = new FocusManager.PreFocusChangeEventArgs();
            tlog.Debug(tag, $"113");
            A1_PreFocusChange(o1, e);
            tlog.Debug(tag, $"114");

            tlog.Debug(tag, $"FocusManagerPreFocusChange END (OK)");
            Assert.Pass("FocusManagerPreFocusChange");
        }

        private View A1_PreFocusChange(object o, FocusManager.PreFocusChangeEventArgs e)
        {
            View v1 = e.CurrentView;
            e.CurrentView = v1;

            View v2 = e.ProposedView;
            e.ProposedView = v2;

            View.FocusDirection b1 = e.Direction;
            e.Direction = b1;

            return v1;
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusChanged")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusChanged()
        {
            tlog.Debug(tag, $"FocusManagerFocusChanged START");
            FocusManager a1 = FocusManager.Instance;

            a1.FocusChanged += A1_FocusChanged;
            a1.FocusChanged -= A1_FocusChanged;

            object o1 = new object();
            FocusManager.FocusChangedEventArgs e = new FocusManager.FocusChangedEventArgs();
            A1_FocusChanged(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusChanged END (OK)");
            Assert.Pass("FocusManagerFocusChanged");
        }

        private void A1_FocusChanged(object sender, FocusManager.FocusChangedEventArgs e)
        {
            View v1 = e.CurrentView;
            e.CurrentView = v1;

            View v2 = e.NextView;
            e.NextView = v2;
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusGroupChanged")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusGroupChanged()
        {
            tlog.Debug(tag, $"FocusManagerFocusGroupChanged START");
            FocusManager a1 = FocusManager.Instance;

            a1.FocusGroupChanged += A1_FocusGroupChanged;
            a1.FocusGroupChanged -= A1_FocusGroupChanged;
            object o1 = new object();
            FocusManager.FocusGroupChangedEventArgs e = new FocusManager.FocusGroupChangedEventArgs();
            A1_FocusGroupChanged(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusGroupChanged END (OK)");
            Assert.Pass("FocusManagerFocusGroupChanged");
        }

        private void A1_FocusGroupChanged(object sender, FocusManager.FocusGroupChangedEventArgs e)
        {
            View v1 = e.CurrentView;
            e.CurrentView = v1;

            bool b1 = e.ForwardDirection;
            e.ForwardDirection = b1;
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusedViewActivated")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewActivated A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusedViewActivated()
        {
            tlog.Debug(tag, $"FocusManagerFocusedViewActivated START");
            FocusManager a1 = FocusManager.Instance;

            a1.FocusedViewActivated += A1_FocusedViewActivated;
            a1.FocusedViewActivated -= A1_FocusedViewActivated;
            object o1 = new object();
            FocusManager.FocusedViewActivatedEventArgs e = new FocusManager.FocusedViewActivatedEventArgs();
            A1_FocusedViewActivated(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusedViewActivated END (OK)");
            Assert.Pass("FocusManagerFocusedViewActivated");
        }

        private void A1_FocusedViewActivated(object sender, FocusManager.FocusedViewActivatedEventArgs e)
        {
            View v1 = e.View;
            e.View = v1;
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusedViewEnterKeyPressed")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusedViewEnterKeyPressed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusedViewEnterKeyPressed()
        {
            tlog.Debug(tag, $"FocusManagerFocusedViewEnterKeyPressed START");
            FocusManager a1 = FocusManager.Instance;

            a1.FocusedViewEnterKeyPressed += A1_FocusedViewEnterKeyPressed;
            a1.FocusedViewEnterKeyPressed -= A1_FocusedViewEnterKeyPressed;

            object o1 = new object();
            FocusManager.FocusedViewActivatedEventArgs e = new FocusManager.FocusedViewActivatedEventArgs();
            A1_FocusedViewEnterKeyPressed(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusedViewEnterKeyPressed END (OK)");
            Assert.Pass("FocusManagerFocusedViewEnterKeyPressed");
        }

        private void A1_FocusedViewEnterKeyPressed(object sender, FocusManager.FocusedViewActivatedEventArgs e)
        {
            View v1 = e.View;
            e.View = v1;
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusGroupLoop")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusGroupLoop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusGroupLoop()
        {
            tlog.Debug(tag, $"FocusManagerFocusGroupLoop START");
            FocusManager a1 = FocusManager.Instance;

            a1.FocusGroupLoop = true;
            bool b1 = a1.FocusGroupLoop;

            tlog.Debug(tag, $"FocusManagerFocusGroupLoop END (OK)");
            Assert.Pass("FocusManagerFocusGroupLoop");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager FocusIndicator")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusIndicator A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusIndicator()
        {
            tlog.Debug(tag, $"FocusManagerFocusIndicator START");
            View v1 = new View();
            FocusManager a1 = FocusManager.Instance;

            a1.FocusIndicator = v1;
            v1 = a1.FocusIndicator;
            v1.Dispose();

            tlog.Debug(tag, $"FocusManagerFocusIndicator END (OK)");
            Assert.Pass("FocusManagerFocusIndicator");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager Instance")]
        [Property("SPEC", "Tizen.NUI.FocusManager.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerInstance()
        {
            tlog.Debug(tag, $"FocusManagerInstance START");
            FocusManager a1 = FocusManager.Instance;
            tlog.Debug(tag, $"FocusManagerInstance END (OK)");
            Assert.Pass("FocusManagerInstance");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager SetCurrentFocusView")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerSetCurrentFocusView()
        {
            tlog.Debug(tag, $"FocusManagerSetCurrentFocusView START");

            FocusManager a1 = FocusManager.Instance;
            View v1 = new View();
            a1.SetCurrentFocusView(v1);

            tlog.Debug(tag, $"FocusManagerSetCurrentFocusView END (OK)");
            Assert.Pass("FocusManagerSetCurrentFocusView");
        }

        [Test]
        [Category("P2")]
        [Description("FocusManager SetCurrentFocusView")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerSetCurrentFocusViewWithNull()
        {
            tlog.Debug(tag, $"FocusManagerSetCurrentFocusViewWithNull START");

            var testingTarget = FocusManager.Instance;

            try
            {
                View view = null;
                testingTarget.SetCurrentFocusView(view);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, $"FocusManagerSetCurrentFocusViewWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed");
            }
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager GetCurrentFocusView")]
        [Property("SPEC", "Tizen.NUI.FocusManager.GetCurrentFocusView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerGetCurrentFocusView()
        {
            tlog.Debug(tag, $"FocusManagerGetCurrentFocusView START");

            FocusManager a1 = FocusManager.Instance;
            View v1 = a1.GetCurrentFocusView();

            tlog.Debug(tag, $"FocusManagerGetCurrentFocusView END (OK)");
            Assert.Pass("FocusManagerGetCurrentFocusView");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager MoveFocus")]
        [Property("SPEC", "Tizen.NUI.FocusManager.MoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerMoveFocus()
        {
            tlog.Debug(tag, $"FocusManagerMoveFocus START");
            FocusManager a1 = FocusManager.Instance;
            a1.MoveFocus(View.FocusDirection.Up);

            tlog.Debug(tag, $"FocusManagerMoveFocus END (OK)");
            Assert.Pass("FocusManagerMoveFocus");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager ClearFocus")]
        [Property("SPEC", "Tizen.NUI.FocusManager.ClearFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerClearFocus()
        {
            tlog.Debug(tag, $"FocusManagerClearFocus START");
            FocusManager a1 = FocusManager.Instance;
            a1.ClearFocus();

            tlog.Debug(tag, $"FocusManagerClearFocus END (OK)");
            Assert.Pass("FocusManagerClearFocus");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager MoveFocusBackward")]
        [Property("SPEC", "Tizen.NUI.FocusManager.MoveFocusBackward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerMoveFocusBackward()
        {
            tlog.Debug(tag, $"FocusManagerMoveFocusBackward START");
            FocusManager a1 = FocusManager.Instance;
            a1.MoveFocusBackward();

            tlog.Debug(tag, $"FocusManagerMoveFocusBackward END (OK)");
            Assert.Pass("FocusManagerMoveFocusBackward");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager SetAsFocusGroup")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetAsFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerSetAsFocusGroup()
        {
            tlog.Debug(tag, $"FocusManagerSetAsFocusGroup START");
            FocusManager a1 = FocusManager.Instance;
            View v1 = new View();
            a1.SetAsFocusGroup(v1, true);

            tlog.Debug(tag, $"FocusManagerSetAsFocusGroup END (OK)");
            Assert.Pass("FocusManagerSetAsFocusGroup");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager IsFocusGroup")]
        [Property("SPEC", "Tizen.NUI.FocusManager.IsFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerIsFocusGroup()
        {
            tlog.Debug(tag, $"FocusManagerIsFocusGroup START");
            FocusManager a1 = FocusManager.Instance;

            View v1 = new View();
            a1.IsFocusGroup(v1);
            v1.Dispose();

            tlog.Debug(tag, $"FocusManagerIsFocusGroup END (OK)");
            Assert.Pass("FocusManagerIsFocusGroup");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager GetFocusGroup")]
        [Property("SPEC", "Tizen.NUI.FocusManager.GetFocusGroup M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerGetFocusGroup()
        {
            tlog.Debug(tag, $"FocusManagerGetFocusGroup START");
            FocusManager a1 = FocusManager.Instance;

            View v1 = new View();
            a1.GetFocusGroup(v1);
            v1.Dispose();

            tlog.Debug(tag, $"FocusManagerGetFocusGroup END (OK)");
            Assert.Pass("FocusManagerGetFocusGroup");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager SetCustomAlgorithm")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetCustomAlgorithm M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerSetCustomAlgorithm()
        {
            tlog.Debug(tag, $"FocusManagerSetCustomAlgorithm START");

            FocusManager a1 = FocusManager.Instance;
            a1.SetCustomAlgorithm(null);

            tlog.Debug(tag, $"FocusManagerSetCustomAlgorithm END (OK)");
            Assert.Pass("FocusManagerSetCustomAlgorithm");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager Get")]
        [Property("SPEC", "Tizen.NUI.FocusManager.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerGet()
        {
            tlog.Debug(tag, $"FocusManagerGet START");

            try
            {
                FocusManager.Get();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"FocusManagerGet END (OK)");
        }
    }
}
