using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/TabButton")]
    public class TabButtonTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyTabButton : TabButton
        {
            public MyTabButton() : base()
            { }

            public override bool OnKey(Key key)
            {
                return base.OnKey(key);
            }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public void OnCreateViewStyle()
            {
                base.CreateViewStyle();
            }

            public void OnHandleControlStateOnTouch(Touch touch)
            {
                base.HandleControlStateOnTouch(touch);
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
        [Description("TabButton constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.TabButton C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabButtonConstructor()
        {
            tlog.Debug(tag, $"TabButtonConstructor START");

            TabButtonStyle style = new TabButtonStyle()
            { 
                BackgroundColor = Color.Cyan,
            };
            var testingTarget = new TabButton(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabButtonConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabButton OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabButtonOnKey()
        {
            tlog.Debug(tag, $"TabButtonOnKey START");

            var testingTarget = new MyTabButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            testingTarget.OnDispose(DisposeTypes.Explicit);
            tlog.Debug(tag, $"TabButtonOnKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabButton CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabButtonCreateViewStyle()
        {
            tlog.Debug(tag, $"TabButtonCreateViewStyle START");

            var testingTarget = new MyTabButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");

            try
            {
                testingTarget.OnCreateViewStyle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TabButtonCreateViewStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabButton HandleControlStateOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.HandleControlStateOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabButtonHandleControlStateOnTouch()
        {
            tlog.Debug(tag, $"TabButtonHandleControlStateOnTouch START");

            var testingTarget = new MyTabButton()
            { 
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");

            try
            {
                using (Touch touch = new Touch())
                {
                    testingTarget.OnHandleControlStateOnTouch(touch);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TabButtonHandleControlStateOnTouch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabButton OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public async Task TabButtonOnRelayout()
        {
            tlog.Debug(tag, $"TabButtonOnRelayout START");

            var testingTarget = new MyTabButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");

            ViewStyle style = new ViewStyle()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan,
            };
            testingTarget.ApplyStyle(style);

            testingTarget.IconURL = image_path;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Size = new Size(50, 80);
            testingTarget.BackgroundColor = Color.Blue;

            await Task.Delay(200);
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabButtonOnRelayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabButton OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButton.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public async Task TabButtonOnRelayoutWithText()
        {
            tlog.Debug(tag, $"TabButtonOnRelayoutWithText START");

            TabButtonStyle style = new TabButtonStyle()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Cyan,
                Text = new TextLabelStyle()
                { 
                    BackgroundColor = Color.Red,
                }
            };

            var testingTarget = new MyTabButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButton>(testingTarget, "Should return TabButton instance.");
            

            testingTarget.IconURL = image_path;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Size = new Size(50, 80);
            testingTarget.BackgroundColor = Color.Blue;

            await Task.Delay(200);
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabButtonOnRelayoutWithText END (OK)");
        }
    }
}
