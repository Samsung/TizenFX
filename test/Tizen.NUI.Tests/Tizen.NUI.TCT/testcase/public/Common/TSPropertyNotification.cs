using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyNotification")]
    class PublicPropertyNotificationTest
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
        [Description("PropertyNotification constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.PropertyNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationConstructor()
        {
            tlog.Debug(tag, $"PropertyNotificationConstructor START");

            var testintTarget = new Tizen.NUI.PropertyNotification();
            Assert.IsNotNull(testintTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testintTarget, "should be an instance of PropertyNotification class!");

            testintTarget.Dispose();
            tlog.Debug(tag, $"PropertyNotificationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification constructor. With PropertyNotification instance")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.PropertyNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "PropertyNotification")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationConstructorWithPropertyNotification()
        {
            tlog.Debug(tag, $"PropertyNotificationConstructorWithPropertyNotification START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            var dummy = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(dummy, "should be an instance of PropertyNotification class!");

            var testingTarget = new Tizen.NUI.PropertyNotification(dummy);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.Dispose();
            dummy.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationConstructorWithPropertyNotification END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification GetTarget")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetTarget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationGetTarget()
        {
            tlog.Debug(tag, $"PropertyNotificationGetTarget START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            var testingTarget = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            var result = testingTarget.GetTarget();
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<Animatable>(result, "should be an instance of Animatable class!");

            result.Dispose();
            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationGetTarget END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification GetCondition")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetCondition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationGetCondition()
        {
            tlog.Debug(tag, $"PropertyNotificationGetCondition START");

            var dummyView = new View();
            Assert.IsNotNull(dummyView, "should not be null.");
            Assert.IsInstanceOf<View>(dummyView, "should be an instance of View class!");

            var dummycondition = PropertyCondition.GreaterThan(100.0f);
            Assert.IsNotNull(dummycondition, "should not be null.");
            Assert.IsInstanceOf<PropertyCondition>(dummycondition, "should be an instance of PropertyCondition class!");

            var dummyNotification = dummyView.AddPropertyNotification("PositionX", dummycondition);
            Assert.IsNotNull(dummyNotification, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(dummyNotification, "should be an instance of PropertyNotification class!");

            var result = dummyNotification.GetCondition();
            Assert.IsNotNull(result, "should not be null.");
            Assert.IsInstanceOf<PropertyCondition>(result, "should be an instance of PropertyCondition class!");

            Assert.IsTrue(result == dummycondition);

            result.Dispose();
            dummyNotification.Dispose();
            dummycondition.Dispose();
            dummyView.Dispose();
            tlog.Debug(tag, $"PropertyNotificationGetCondition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification GetTargetProperty")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetTargetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationGetTargetProperty()
        {
            tlog.Debug(tag, $"PropertyNotificationGetTargetProperty START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            var testingTarget = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            Assert.AreEqual(13, testingTarget.GetTargetProperty(), "Retrive testingTarget.GetTargetProperty() should equal to 13.");

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationGetTargetProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification GetNotifyMode")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetNotifyMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationGetNotifyMode()
        {
            tlog.Debug(tag, $"PropertyNotificationGetNotifyMode START");

            View view = new View();
            var testingTarget = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            var result = testingTarget.GetNotifyMode();
            Assert.IsNotNull(result, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification.NotifyMode>(result, "should be an instance of PropertyNotification.NotifyMode class!");
            Assert.IsTrue(PropertyNotification.NotifyMode.NotifyOnTrue == result);

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationGetNotifyMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification SetNotifyMode")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.SetNotifyMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationSetNotifyMode()
        {
            tlog.Debug(tag, $"PropertyNotificationSetNotifyMode START");

            View view = new View();
            var testingTarget = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            var result = testingTarget.GetNotifyMode();
            Assert.IsNotNull(result, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification.NotifyMode>(result, "should be an instance of PropertyNotification.NotifyMode class!");
            Assert.IsTrue(PropertyNotification.NotifyMode.NotifyOnChanged == result);

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationSetNotifyMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification GetNotifyResult.")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.GetNotifyResult M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationGetNotifyResult()
        {
            tlog.Debug(tag, $"PropertyNotificationGetNotifyResult START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            var testingTarget = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            testingTarget.Notified += (obj, e) =>
            {
                tlog.Fatal("TCT", "Notified!");
            };
            view.Position = new Position(0.0f, 0.0f, 0.0f);
            Assert.AreEqual(false, testingTarget.GetNotifyResult(), "Should be equal!");

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationGetNotifyResult END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification Notified")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Notified E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task PropertyNotificationNotified()
        {
            tlog.Debug(tag, $"PropertyNotificationNotified START");

            View view = new View();
            Window.Instance.Add(view);
            var testingTarget = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            bool flag = false;
            testingTarget.Notified += (obj, e) =>
            {
                flag = true;
            };

            view.Position = new Position(300.0f, 0.0f, 0.0f);
            await Task.Delay(200);
            Assert.AreEqual(true, flag, "Should be equal!");

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationNotified END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification Dispose")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationDispose()
        {
            tlog.Debug(tag, $"PropertyNotificationDispose START");

            var testingTarget = new PropertyNotification();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PropertyNotificationDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification DownCast")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationDownCast()
        {
            tlog.Debug(tag, $"PropertyNotificationDownCast START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            Window.Instance.Add(view);
            var testingTarget = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            var result = PropertyNotification.DownCast(testingTarget);
            Assert.IsNotNull(result, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(result, "should be an instance of PropertyNotification class!");

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification NotifySignal")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifySignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task PropertyNotificationNotifySignal()
        {
            tlog.Debug(tag, $"PropertyNotificationNotifySignal START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            Window.Instance.Add(view);
            var testingTarget = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnChanged);
            bool flag = false;
            testingTarget.Notified += (obj, e) =>
            {
                flag = true;
            };
            view.Position = new Position(300.0f, 0.0f, 0.0f);
            await Task.Delay(200);

            var result = testingTarget.NotifySignal();
            Assert.IsNotNull(result, "Should be not null");
            Assert.IsInstanceOf<PropertyNotifySignal>(result, "Should be an instance of propertyNotifySignal");

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationNotifySignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification Assign")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationAssign()
        {
            tlog.Debug(tag, $"PropertyNotificationAssign START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");
            Window.Instance.Add(view);

            var dummy1 = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(dummy1, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(dummy1, "should be an instance of PropertyNotification class!");

            var dummy2 = view.AddPropertyNotification("positionY", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(dummy2, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(dummy2, "should be an instance of PropertyNotification class!");

            var testingTarget = dummy2.Assign(dummy1);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            testingTarget.Dispose();
            dummy2.Dispose();
            dummy1.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationAssign END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("PropertyNotification Assign, negative")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationAssignNegative()
        {
            tlog.Debug(tag, $"PropertyNotificationAssignNegative START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");
            Window.Instance.Add(view);

            var testingTarget = view.AddPropertyNotification("positionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(testingTarget, "should be an instance of PropertyNotification class!");

            try
            {
                testingTarget.Assign(null);
                Assert.Fail("Should throw the System.ArgumentNullException!");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true);
            }

            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"PropertyNotificationAssignNegative END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification.NotifyEventArgs constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifyEventArgs.NotifyEventArgs C")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationNotifyEventArgsContructor()
        {
            tlog.Debug(tag, $"PropertyNotificationNotifyEventArgsContructor START");

            var testingTarget = new PropertyNotification.NotifyEventArgs();
            Assert.NotNull(testingTarget, "Should be not null");
            Assert.IsInstanceOf<PropertyNotification.NotifyEventArgs>(testingTarget, "Should be an instance of PropertyNotification.PropertyNotificationNotifyEventArgs");

            tlog.Debug(tag, $"PropertyNotificationNotifyEventArgsContructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyNotification.NotifyEventArgs GetTargetProperty")]
        [Property("SPEC", "Tizen.NUI.PropertyNotification.NotifyEventArgs.PropertyNotification A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyNotificationNotifyEventArgsGetTargetProperty()
        {
            tlog.Debug(tag, $"PropertyNotificationNotifyEventArgsGetTargetProperty START");

            var view = new View();
            Assert.IsNotNull(view, "should not be null.");
            Assert.IsInstanceOf<View>(view, "should be an instance of View class!");

            var dummy = view.AddPropertyNotification("PositionX", PropertyCondition.GreaterThan(100.0f));
            Assert.IsNotNull(dummy, "should not be null.");
            Assert.IsInstanceOf<PropertyNotification>(dummy, "should be an instance of PropertyNotification class!");

            var testingTarget = new PropertyNotification.NotifyEventArgs();
            Assert.NotNull(testingTarget, "Should be not null");
            Assert.IsInstanceOf<PropertyNotification.NotifyEventArgs>(testingTarget, "Should be an instance of PropertyNotification.PropertyNotificationNotifyEventArgs");

            testingTarget.PropertyNotification = dummy;
            Assert.AreEqual(13, testingTarget.PropertyNotification.GetTargetProperty(), "Should be equal!");

            dummy.Dispose();
            view.Dispose();

            tlog.Debug(tag, $"PropertyNotificationNotifyEventArgsGetTargetProperty END (OK)");
        }
    }
}
