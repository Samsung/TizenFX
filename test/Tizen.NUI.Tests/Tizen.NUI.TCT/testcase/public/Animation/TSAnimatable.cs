using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/Animatable")]
    public class PublicAnimatableTest
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
        [Description("Animatable constructor")]
        [Property("SPEC", "Tizen.NUI.Animatable.Animatable C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableConstructor()
        {
            tlog.Debug(tag, $"AnimatableConstructor START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of Animatable class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable GetPropertyName")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetPropertyName()
        {
            tlog.Debug(tag, $"AnimatableGetPropertyName START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of ImageView class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var index = testingTarget.GetPropertyIndex("dummy");
            var result = testingTarget.GetPropertyName(index);
            Assert.AreEqual("dummy", result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableGetPropertyName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable GetPropertyIndex")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetPropertyIndex()
        {
            tlog.Debug(tag, $"AnimatableGetPropertyIndex START");

            var view = new ImageView();
            Assert.IsNotNull(view, "should be not null");
            Assert.IsInstanceOf<ImageView>(view, "should be an instance of ImageView class!");

            int index = view.GetPropertyIndex("image");
            Assert.IsTrue(10001001 == index);

            view.Dispose();
            tlog.Debug(tag, $"AnimatableGetPropertyIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable IsPropertyWritable")]
        [Property("SPEC", "Tizen.NUI.Animatable.IsPropertyWritable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetIsPropertyWritable()
        {
            tlog.Debug(tag, $"AnimatableGetIsPropertyWritable START");

            var view = new ImageView();
            Assert.IsNotNull(view, "should be not null");
            Assert.IsInstanceOf<ImageView>(view, "should be an instance of ImageView class!");

            int index = view.GetPropertyIndex("image");
            Assert.IsTrue(10001001 == index);

            var result = view.IsPropertyWritable(index);
            Assert.IsTrue(result);

            view.Dispose();
            tlog.Debug(tag, $"AnimatableGetIsPropertyWritable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable IsPropertyAnimatable")]
        [Property("SPEC", "Tizen.NUI.Animatable.IsPropertyAnimatable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetIsPropertyAnimatable()
        {
            tlog.Debug(tag, $"AnimatableGetIsPropertyAnimatable START");

            var view = new ImageView();
            Assert.IsNotNull(view, "should be not null");
            Assert.IsInstanceOf<ImageView>(view, "should be an instance of ImageView class!");

            int index = view.GetPropertyIndex("image");
            Assert.IsTrue(10001001 == index);

            var result = view.IsPropertyAnimatable(index);
            Assert.IsFalse(result);

            view.Dispose();
            tlog.Debug(tag, $"AnimatableGetIsPropertyAnimatable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable GetPropertyType")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetPropertyType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetGetPropertyType()
        {
            tlog.Debug(tag, $"AnimatableGetGetPropertyType START");

            var view = new ImageView();
            Assert.IsNotNull(view, "should be not null");
            Assert.IsInstanceOf<ImageView>(view, "should be an instance of ImageView class!");

            int index = view.GetPropertyIndex("image");
            Assert.IsTrue(10001001 == index);

            var result = view.GetPropertyType(index);
            Assert.AreEqual(PropertyType.Map, result, "should be eaqual.");

            view.Dispose();
            tlog.Debug(tag, $"AnimatableGetGetPropertyType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable SetProperty")]
        [Property("SPEC", "Tizen.NUI.Animatable.SetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableSetProperty()
        {
            tlog.Debug(tag, $"AnimatableSetProperty START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of ImageView class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var index = testingTarget.GetPropertyIndex("dummy");
            testingTarget.SetProperty(index, new PropertyValue(8));
            testingTarget.GetProperty(index).Get(out int result);
            Assert.AreEqual(8, result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableSetProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable RegisterProperty")]
        [Property("SPEC", "Tizen.NUI.Animatable.RegisterProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableRegisterProperty()
        {
            tlog.Debug(tag, $"AnimatableRegisterProperty START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of ImageView class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var index = testingTarget.GetPropertyIndex("dummy");
            testingTarget.GetProperty(index).Get(out int result);
            Assert.AreEqual(6, result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableRegisterProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable RegisterProperty. With accessMode")]
        [Property("SPEC", "Tizen.NUI.Animatable.RegisterProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableRegisterPropertyWithAccessMode()
        {
            tlog.Debug(tag, $"AnimatableRegisterPropertyWithAccessMode START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of ImageView class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6), PropertyAccessMode.Animatable);
            var index = testingTarget.GetPropertyIndex("dummy");
            testingTarget.GetProperty(index).Get(out int result);
            Assert.AreEqual(6, result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableRegisterPropertyWithAccessMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable GetProperty")]
        [Property("SPEC", "Tizen.NUI.Animatable.GetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableGetProperty()
        {
            tlog.Debug(tag, $"AnimatableGetProperty START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of ImageView class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6), PropertyAccessMode.Animatable);
            var index = testingTarget.GetPropertyIndex("dummy");
            testingTarget.GetProperty(index).Get(out int result);
            Assert.AreEqual(6, result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableGetProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable AddPropertyNotification")]
        [Property("SPEC", "Tizen.NUI.Animatable.AddPropertyNotification M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableAddPropertyNotification()
        {
            tlog.Debug(tag, $"AnimatableAddPropertyNotification START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of Animatable class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var result = testingTarget.AddPropertyNotification("dummy", PropertyCondition.GreaterThan(5));
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<PropertyNotification>(result, "should be an instance of PropertyNotification class!");

            result.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableAddPropertyNotification END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable RemovePropertyNotification")]
        [Property("SPEC", "Tizen.NUI.Animatable.RemovePropertyNotification M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableRemovePropertyNotification()
        {
            tlog.Debug(tag, $"AnimatableRemovePropertyNotification START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of Animatable class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var dummy = testingTarget.AddPropertyNotification("dummy", PropertyCondition.GreaterThan(5));
            Assert.IsNotNull(dummy, "should be not null");
            Assert.IsInstanceOf<PropertyNotification>(dummy, "should be an instance of PropertyNotification class!");

            try
            {
                testingTarget.RemovePropertyNotification(dummy);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableRemovePropertyNotification END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Animatable RemovePropertyNotifications")]
        [Property("SPEC", "Tizen.NUI.Animatable.RemovePropertyNotifications M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatableRemovePropertyNotifications()
        {
            tlog.Debug(tag, $"AnimatableRemovePropertyNotifications START");

            var testingTarget = new Animatable();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Animatable>(testingTarget, "should be an instance of Animatable class!");

            testingTarget.RegisterProperty("dummy", new PropertyValue(6));
            var dummy = testingTarget.AddPropertyNotification("dummy", PropertyCondition.GreaterThan(5));
            Assert.IsNotNull(dummy, "should be not null");
            Assert.IsInstanceOf<PropertyNotification>(dummy, "should be an instance of PropertyNotification class!");

            var dummy2 = testingTarget.AddPropertyNotification("dummy", PropertyCondition.LessThan(10));
            Assert.IsNotNull(dummy2, "should be not null");
            Assert.IsInstanceOf<PropertyNotification>(dummy2, "should be an instance of PropertyNotification class!");

            try
            {
                testingTarget.RemovePropertyNotifications();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatableRemovePropertyNotifications END (OK)");
        }
    }
}
