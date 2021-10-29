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
    [Description("Controls/MenuItem")]
    public class MenuItemTest
    {
        private const string tag = "NUITEST";
        
        internal class MyMenuItem : MenuItem
        {
            public MyMenuItem() : base()
            { }

            public void MyOnUpdate() 
            {
                base.OnUpdate();
            }

            public bool MyHandleControlStateOnTouch(Touch touch)
            {
                return base.HandleControlStateOnTouch(touch);
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
        [Description("MenuItem OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItem.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuItemOnUpdate()
        {
            tlog.Debug(tag, $"MenuItemOnUpdate START");

            var testingTarget = new MyMenuItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItem>(testingTarget, "Should return MenuItem instance.");

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MenuItemOnUpdate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MenuItem OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItem.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void MenuItemOnKey()
        {
            tlog.Debug(tag, $"MenuItemOnKey START");

            var testingTarget = new MyMenuItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItem>(testingTarget, "Should return MenuItem instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            tlog.Debug(tag, $"MenuItemOnKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MenuItem HandleControlStateOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItem.HandleControlStateOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuItemHandleControlStateOnTouch()
        {
            tlog.Debug(tag, $"MenuItemHandleControlStateOnTouch START");

            var testingTarget = new MyMenuItem()
            {
                Text = "MenuItem",
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItem>(testingTarget, "Should return MenuItem instance.");

            using (Touch touch = new Touch())
            {
                tlog.Debug(tag, "HandleControlStateOnTouch : " + testingTarget.MyHandleControlStateOnTouch(touch));
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MenuItemHandleControlStateOnTouch END (OK)");
        }
    }
}
