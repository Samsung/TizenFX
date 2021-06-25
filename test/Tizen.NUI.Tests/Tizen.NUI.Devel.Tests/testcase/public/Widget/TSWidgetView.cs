using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Widget/WidgetView")]
    public class PublicWidgetViewTest
    {
        private const string tag = "NUITEST";
        private ImageView imageView = null;
        private WidgetView widgetView = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            imageView = new ImageView();
            widgetView = new WidgetView(imageView.SwigCPtr.Handle, false);
            tlog.Debug(tag, " widgetView.Id : " + widgetView.Id.ToString());
        }

        [TearDown]
        public void Destroy()
        {
            imageView?.Dispose();
            imageView = null;

            widgetView?.Dispose();
            widgetView = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView Constructor.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetView C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewConstructor()
        //{
        //    tlog.Debug(tag, $"WidgetViewConstructor START");

        //    try
        //    {
        //        var testingTarget = new WidgetView(widget.Id.ToString(), "WidgetView", 100, 200, 50.0f);
        //        Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //        Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //        testingTarget.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    tlog.Debug(tag, $"WidgetViewConstructor END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WidgetView Constructor. With WidgetView")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewConstructorWithWidgetView()
        {
            tlog.Debug(tag, $"WidgetViewConstructorWithWidgetView START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewConstructorWithWidgetView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetAddedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetAddedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetAddedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetAddedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetAddedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetAddedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetDeletedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetDeletedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetDeletedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetDeletedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetDeletedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetDeletedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetCreationAbortedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetCreationAbortedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetCreationAbortedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetCreationAbortedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetCreationAbortedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetCreationAbortedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetContentUpdatedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetContentUpdatedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetContentUpdatedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetContentUpdatedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetContentUpdatedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetContentUpdatedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetUpdatePeriodChangedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetUpdatePeriodChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetUpdatePeriodChangedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetUpdatePeriodChangedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetUpdatePeriodChangedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetUpdatePeriodChangedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetFaultedSignal.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetFaultedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetFaultedSignal()
        {
            tlog.Debug(tag, $"WidgetViewWidgetFaultedSignal START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.WidgetFaultedSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetFaultedSignal END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetAdded.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetAdded A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetAdded()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetAdded START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetAdded += MyOnWidgetAdded;
        //        testingTarget.WidgetAdded -= MyOnWidgetAdded;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetAdded END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetContentUpdated.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetContentUpdated A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetContentUpdated()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetContentUpdated START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetContentUpdated += MyOnWidgetContentUpdated;
        //        testingTarget.WidgetContentUpdated -= MyOnWidgetContentUpdated;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetContentUpdated END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetDeleted.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetDeleted A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetDeleted()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetDeleted START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetDeleted += MyOnWidgetDeleted;
        //        testingTarget.WidgetDeleted -= MyOnWidgetDeleted;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetDeleted END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetCreationAborted.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetCreationAborted A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetCreationAborted()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetCreationAborted START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetCreationAborted += MyOnWidgetCreationAborted;
        //        testingTarget.WidgetCreationAborted -= MyOnWidgetCreationAborted;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetCreationAborted END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetUpdatePeriodChanged.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetUpdatePeriodChanged A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetUpdatePeriodChanged()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetUpdatePeriodChanged START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetUpdatePeriodChanged += MyOnWidgetUpdatePeriodChanged;
        //        testingTarget.WidgetUpdatePeriodChanged -= MyOnWidgetUpdatePeriodChanged;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetUpdatePeriodChanged END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView WidgetFaulted.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.WidgetFaulted A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewWidgetFaulted()
        //{
        //    tlog.Debug(tag, $"WidgetViewWidgetFaulted START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        testingTarget.WidgetFaulted += MyOnWidgetFaulted;
        //        testingTarget.WidgetFaulted -= MyOnWidgetFaulted;
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewWidgetFaulted END (OK)");
        //}

        private void MyOnWidgetAdded(object sender, EventArgs e) { }
        //private void MyOnWidgetContentUpdated(object sender, EventArgs e) { }
        //private void MyOnWidgetDeleted(object sender, EventArgs e) { }
        //private void MyOnWidgetCreationAborted(object sender, EventArgs e) { }
        //private void MyOnWidgetUpdatePeriodChanged(object sender, EventArgs e) { }
        //private void MyOnWidgetFaulted(object sender, EventArgs e) { }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetID.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetID A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetID()
        {
            tlog.Debug(tag, $"WidgetViewWidgetID START");

            try
            {
                tlog.Debug(tag, "widgetView.WidgetID : " + widgetView.WidgetID);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewWidgetID END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView InstanceID.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.InstanceID A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewInstanceID()
        {
            tlog.Debug(tag, $"WidgetViewInstanceID START");

            try
            {
                tlog.Debug(tag, "widgetView.InstanceID : " + widgetView.InstanceID);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewInstanceID END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView ContentInfo.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.ContentInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewContentInfo()
        {
            tlog.Debug(tag, $"WidgetViewContentInfo START");

            try
            {
                tlog.Debug(tag, "widgetView.ContentInfo : " + widgetView.ContentInfo);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewContentInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView Title.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewTitle()
        {
            tlog.Debug(tag, $"WidgetViewTitle START");

            try
            {
                tlog.Debug(tag, "widgetView.Title : " + widgetView.Title);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewTitle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView UpdatePeriod.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewUpdatePeriod()
        {
            tlog.Debug(tag, $"WidgetViewUpdatePeriod START");

            try
            {
                tlog.Debug(tag, "widgetView.UpdatePeriod : " + widgetView.UpdatePeriod);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewUpdatePeriod END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView Preview.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.Preview A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewPreview()
        {
            tlog.Debug(tag, $"WidgetViewPreview START");

            try
            {
                tlog.Debug(tag, "Default widgetView.Preview is : " + widgetView.Preview);

                widgetView.Preview = true;
                tlog.Debug(tag, "widgetView.Preview : " + widgetView.Preview);
                
                widgetView.Preview = false;
                tlog.Debug(tag, "widgetView.Preview : " + widgetView.Preview);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewPreview END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView LoadingText.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.LoadingText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewLoadingText()
        {
            tlog.Debug(tag, $"WidgetViewLoadingText START");

            try
            {
                tlog.Debug(tag, "Default widgetView.Preview is : " + widgetView.LoadingText);

                widgetView.LoadingText = true;
                tlog.Debug(tag, "widgetView.LoadingText : " + widgetView.LoadingText);

                widgetView.LoadingText = false;
                tlog.Debug(tag, "widgetView.LoadingText : " + widgetView.LoadingText);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewLoadingText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView WidgetStateFaulted.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetStateFaulted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetStateFaulted()
        {
            tlog.Debug(tag, $"WidgetViewWidgetStateFaulted START");

            try
            {
                tlog.Debug(tag, "Default widgetView.Preview is : " + widgetView.WidgetStateFaulted);

                widgetView.WidgetStateFaulted = true;
                tlog.Debug(tag, "widgetView.WidgetStateFaulted : " + widgetView.WidgetStateFaulted);

                widgetView.WidgetStateFaulted = false;
                tlog.Debug(tag, "widgetView.WidgetStateFaulted : " + widgetView.WidgetStateFaulted);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewWidgetStateFaulted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView PermanentDelete.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.PermanentDelete A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetPermanentDelete()
        {
            tlog.Debug(tag, $"WidgetViewWidgetPermanentDelete START");

            try
            {
                tlog.Debug(tag, "Default widgetView.Preview is : " + widgetView.PermanentDelete);

                widgetView.PermanentDelete = true;
                tlog.Debug(tag, "widgetView.PermanentDelete : " + widgetView.PermanentDelete);

                widgetView.PermanentDelete = false;
                tlog.Debug(tag, "widgetView.PermanentDelete : " + widgetView.PermanentDelete);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewWidgetPermanentDelete END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView RetryText.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.RetryText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewRetryText()
        {
            tlog.Debug(tag, $"WidgetViewRetryText START");

            try
            {
                using (PropertyMap map = new PropertyMap())
                {
                    map.Insert(WidgetView.Property.RetryText, new PropertyValue(1));

                    widgetView.RetryText = map;

                    var result = widgetView.RetryText;
                    Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewRetryText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView Effect.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.Effect A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewEffect()
        {
            tlog.Debug(tag, $"WidgetViewEffect START");

            try
            {
                using (PropertyMap map = new PropertyMap())
                {
                    map.Insert(WidgetView.Property.EFFECT, new PropertyValue(1));

                    widgetView.Effect = map;

                    var result = widgetView.Effect;
                    Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewEffect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView PauseWidget.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.PauseWidget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetPauseWidget()
        {
            tlog.Debug(tag, $"WidgetViewWidgetPauseWidget START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.PauseWidget();
                testingTarget.ResumeWidget();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewWidgetPauseWidget END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView CancelTouchEvent.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.CancelTouchEvent M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewCancelTouchEvent()
        //{
        //    tlog.Debug(tag, $"WidgetViewCancelTouchEvent START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        tlog.Debug(tag, "testingTarget.CancelTouchEvent() : " + testingTarget.CancelTouchEvent());
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewCancelTouchEvent END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WidgetView ActivateFaultedWidget.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.ActivateFaultedWidget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewActivateFaultedWidget()
        {
            tlog.Debug(tag, $"WidgetViewActivateFaultedWidget START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.ActivateFaultedWidget();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewActivateFaultedWidget END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView TerminateWidget.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.TerminateWidget M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewTerminateWidget()
        {
            tlog.Debug(tag, $"WidgetViewTerminateWidget START");

            var testingTarget = new WidgetView(widgetView);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
            Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

            try
            {
                testingTarget.TerminateWidget();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewTerminateWidget END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WidgetView DownCast.")]
        //[Property("SPEC", "Tizen.NUI.WidgetView.DownCast M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewDownCast()
        //{
        //    tlog.Debug(tag, $"WidgetViewDownCast START");

        //    var testingTarget = new WidgetView(widgetView);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(testingTarget, "Should be an instance of WidgetView type.");

        //    try
        //    {
        //        WidgetView.DownCast(testingTarget);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewDownCast END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WidgetView GetWidgetViewFromPtr.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.GetWidgetViewFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewGetWidgetViewFromPtr()
        {
            tlog.Debug(tag, $"WidgetViewGetWidgetViewFromPtr START");

            try
            {
                WidgetView.GetWidgetViewFromPtr(widgetView.SwigCPtr.Handle);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewGetWidgetViewFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView Assign.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewAssign()
        {
            tlog.Debug(tag, $"WidgetViewAssign START");

            try
            {
                widgetView.Assign(widgetView);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetView.WidgetViewEventArgs.WidgetView.")]
        [Property("SPEC", "Tizen.NUI.WidgetView.WidgetViewEventArgs.WidgetView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewWidgetViewEventArgsWidgetView()
        {
            tlog.Debug(tag, $"WidgetViewWidgetViewEventArgsWidgetView START");

            var testingTarget = new WidgetView.WidgetViewEventArgs();
            tlog.Debug(tag, "Default testingTarget.WidgetView is : " + testingTarget.WidgetView);

            testingTarget.WidgetView = widgetView;
            tlog.Debug(tag, "testingTarget.WidgetView is : " + testingTarget.WidgetView);

            tlog.Debug(tag, $"WidgetViewWidgetViewEventArgsWidgetView END (OK)");
        }


    }
}
