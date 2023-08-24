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
            
            var testingTarget = new FocusManager();
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FocusManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager PreFocusChange")]
        [Property("SPEC", "Tizen.NUI.FocusManager.PreFocusChange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FocusManagerPreFocusChange()
        {
            tlog.Debug(tag, $"FocusManagerPreFocusChange START");

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.PreFocusChange += OnPreFocusChange;
            testingTarget.PreFocusChange -= OnPreFocusChange;

            object o1 = new object();
            FocusManager.PreFocusChangeEventArgs e = new FocusManager.PreFocusChangeEventArgs();
            OnPreFocusChange(o1, e);

            tlog.Debug(tag, $"FocusManagerPreFocusChange END (OK)");
        }

        [Obsolete]
        private View OnPreFocusChange(object o, FocusManager.PreFocusChangeEventArgs e)
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
        [Description("FocusManager FocusChanging")]
        [Property("SPEC", "Tizen.NUI.FocusManager.FocusChanging A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerFocusChanging()
        {
            tlog.Debug(tag, $"FocusManagerFocusChanging START");
            
            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
			{
                testingTarget.FocusChanging += OnFocusChanging;
                testingTarget.FocusChanging -= OnFocusChanging;
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
            
            tlog.Debug(tag, $"FocusManagerFocusChanging END (OK)");
        }		
		
		public void OnFocusChanging(object sender, FocusChangingEventArgs e) { }
		
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.FocusChanged += OnFocusChanged;
            testingTarget.FocusChanged -= OnFocusChanged;

            object o1 = new object();
            FocusManager.FocusChangedEventArgs e = new FocusManager.FocusChangedEventArgs();
            OnFocusChanged(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusChanged END (OK)");
        }

        private void OnFocusChanged(object sender, FocusManager.FocusChangedEventArgs e)
        {
            View v1 = e.Previous;
            e.Previous = v1;

            View v2 = e.Current;
            e.Current = v2;
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.FocusGroupChanged += OnFocusGroupChanged;
            testingTarget.FocusGroupChanged -= OnFocusGroupChanged;
            
            object o1 = new object();
            FocusManager.FocusGroupChangedEventArgs e = new FocusManager.FocusGroupChangedEventArgs();
            OnFocusGroupChanged(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusGroupChanged END (OK)");
        }

        private void OnFocusGroupChanged(object sender, FocusManager.FocusGroupChangedEventArgs e)
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.FocusedViewActivated += OnFocusedViewActivated;
            testingTarget.FocusedViewActivated -= OnFocusedViewActivated;

            object o1 = new object();
            FocusManager.FocusedViewActivatedEventArgs e = new FocusManager.FocusedViewActivatedEventArgs();
            OnFocusedViewActivated(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusedViewActivated END (OK)");
        }

        private void OnFocusedViewActivated(object sender, FocusManager.FocusedViewActivatedEventArgs e)
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
        [Obsolete]
        public void FocusManagerFocusedViewEnterKeyPressed()
        {
            tlog.Debug(tag, $"FocusManagerFocusedViewEnterKeyPressed START");

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.FocusedViewEnterKeyPressed += OnFocusedViewEnterKeyPressed;
            testingTarget.FocusedViewEnterKeyPressed -= OnFocusedViewEnterKeyPressed;

            object o1 = new object();
            FocusManager.FocusedViewActivatedEventArgs e = new FocusManager.FocusedViewActivatedEventArgs();
            OnFocusedViewEnterKeyPressed(o1, e);

            tlog.Debug(tag, $"FocusManagerFocusedViewEnterKeyPressed END (OK)");
        }

        private void OnFocusedViewEnterKeyPressed(object sender, FocusManager.FocusedViewActivatedEventArgs e)
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            testingTarget.FocusGroupLoop = true;
            Assert.AreEqual(true, testingTarget.FocusGroupLoop, "Should be equal!");

            tlog.Debug(tag, $"FocusManagerFocusGroupLoop END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            using (View view = new View())
            {
                testingTarget.FocusIndicator = view;
                Assert.AreEqual(view, testingTarget.FocusIndicator, "Should be equal!");
            }

            tlog.Debug(tag, $"FocusManagerFocusIndicator END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            using (View view = new View())
            {
                try
                {
                    testingTarget.SetCurrentFocusView(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
            
            tlog.Debug(tag, $"FocusManagerSetCurrentFocusView END (OK)");
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
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                View view = null;
                testingTarget.SetCurrentFocusView(view);
            }
            catch (ArgumentNullException)
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                testingTarget.GetCurrentFocusView();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FocusManagerGetCurrentFocusView END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                testingTarget.MoveFocus(View.FocusDirection.Up);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FocusManagerMoveFocus END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                testingTarget.SetCurrentFocusView(view);

                try
                {
                    testingTarget.ClearFocus();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FocusManagerClearFocus END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                testingTarget.MoveFocusBackward();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FocusManagerMoveFocusBackward END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            using (View v1 = new View())
            {
                try
                {
                    testingTarget.SetAsFocusGroup(v1, true);
                    Assert.IsTrue(testingTarget.IsFocusGroup(v1));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FocusManagerSetAsFocusGroup END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            using (View v1 = new View())
            {
                try
                {
                    testingTarget.GetFocusGroup(v1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"FocusManagerGetFocusGroup END (OK)");
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

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                testingTarget.SetCustomAlgorithm(null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"FocusManagerSetCustomAlgorithm END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager EnableDefaultAlgorithm")]
        [Property("SPEC", "Tizen.NUI.FocusManager.EnableDefaultAlgorithm M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerEnableDefaultAlgorithm()
        {
            tlog.Debug(tag, $"FocusManagerEnableDefaultAlgorithm START");

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
			{
                testingTarget.EnableDefaultAlgorithm(true);
                var result = testingTarget.IsDefaultAlgorithmEnabled();
                Assert.AreEqual(true, result, "Should be equal!");
            }
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught exception : Failed!");
            }

            tlog.Debug(tag, $"FocusManagerEnableDefaultAlgorithm END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusManager SetFocusFinderRootView")]
        [Property("SPEC", "Tizen.NUI.FocusManager.SetFocusFinderRootView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerSetFocusFinderRootView()
        {
            tlog.Debug(tag, $"FocusManagerSetFocusFinderRootView START");
            
            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
			{
                using (View view = new View())
                {
                    testingTarget.SetFocusFinderRootView(view);
                    testingTarget.ResetFocusFinderRootView();
                }
            }
			catch(Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
			
            tlog.Debug(tag, $"FocusManagerSetFocusFinderRootView END (OK)");
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
		
		
        [Test]
        [Category("P1")]
        [Description("FocusManager GetFocusIndicatorView")]
        [Property("SPEC", "Tizen.NUI.FocusManager.GetFocusIndicatorView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusManagerGetFocusIndicatorView()
        {
            tlog.Debug(tag, $"FocusManagerGetFocusIndicatorView START");

            var testingTarget = FocusManager.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<FocusManager>(testingTarget, "Should be an instance of FocusManager type.");

            try
            {
                testingTarget.GetFocusIndicatorView();
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"FocusManagerGetFocusIndicatorView END (OK)");
        }		
    }
}
