using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.BaseComponents.View;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/SelectButton")]
    public class SelectButtonTest
    {
        private const string tag = "NUITEST";
        private void OnSelectedChanged(object sender, SelectedChangedEventArgs e) { }

        internal class MySelectButton : SelectButton
        {
            public MySelectButton() : base()
            { }

            public SelectGroup MySelectGroup
            {
                get
                {
                    return base.ItemGroup;
                }
                set
                {
                    base.ItemGroup = value;
                }
            }

            public void MyHandleControlStateOnTouch(Touch touch)
            {
                base.HandleControlStateOnTouch(touch);
            }

            public void MyOnControlStateChanged(ControlStateChangedEventArgs args)
            {
                base.OnControlStateChanged(args);
            }
        }

        internal class SelectGroupImpl : SelectGroup
        {
            public SelectGroupImpl() : base()
            { 
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
        [Description("SelectButton Index.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.Index M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectButtonIndex()
        {
            tlog.Debug(tag, $"SelectButtonIndex START");

            var testingTarget = new MySelectButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectButton>(testingTarget, "Should return SelectButton instance.");

            testingTarget.MySelectGroup = new SelectGroupImpl();
            tlog.Debug(tag, "Index : " + testingTarget.Index);

            tlog.Debug(tag, $"SelectButtonIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectButton OnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.OnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectOnTouch()
        {
            tlog.Debug(tag, $"SelectOnTouch START");

            var testingTarget = new MySelectButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectButton>(testingTarget, "Should return SelectButton instance.");

            using (Touch touch = new Touch())
            {
                var result = testingTarget.OnTouch(touch);
                tlog.Debug(tag, "OnTouch : " + result);
            }

            tlog.Debug(tag, $"SelectOnTouch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectButton HandleControlStateOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.HandleControlStateOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectButtonHandleControlStateOnTouch()
        {
            tlog.Debug(tag, $"SelectButtonHandleControlStateOnTouch START");

            var testingTarget = new MySelectButton()
            { 
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectButton>(testingTarget, "Should return SelectButton instance.");

            using (Touch touch = new Touch())
            {
                try
                {
                    testingTarget.MyHandleControlStateOnTouch(touch);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"SelectButtonHandleControlStateOnTouch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectButton OnControlStateChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.OnControlStateChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectButtonOnControlStateChanged()
        {
            tlog.Debug(tag, $"SelectButtonOnControlStateChanged START");

            var testingTarget = new MySelectButton()
            {
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectButton>(testingTarget, "Should return SelectButton instance.");

            Key key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            testingTarget.OnKey(key);

            testingTarget.SelectedChanged += OnSelectedChanged;

            try
            {
                ControlStateChangedEventArgs args = new ControlStateChangedEventArgs(ControlState.Selected, ControlState.Normal);
                testingTarget.MyOnControlStateChanged(args);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.SelectedChanged -= OnSelectedChanged;

            testingTarget.Dispose();
            tlog.Debug(tag, $"SelectButtonOnControlStateChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectButton OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectButton.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectButtonOnKey()
        {
            tlog.Debug(tag, $"SelectButtonOnKey START");

            var testingTarget = new MySelectButton()
            {
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectButton>(testingTarget, "Should return SelectButton instance.");

            Key key = null;
            var result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            try
            {
                key = new Key()
                {
                    State = Key.StateType.Down,
                };
                testingTarget.OnKey(key);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SelectButtonOnKey END (OK)");
        }
    }
}
