﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ViewAccessibility")]
    public class PublicViewAccessibilityTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/picture.png";
        private string lottiePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/lottie.json";

        internal class MyAddressCollection : AddressCollection
        {
            public MyAddressCollection(IntPtr collection) : base(collection)
            { }

            public void OnReleaseHandle()
            {
                base.ReleaseHandle();
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
        [Description("ViewAccessibility.Address constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.Address.Address C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressConstructor()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressConstructor START");

            var testingTarget = new Address("ViewAccessibility", lottiePath);
            Assert.IsNotNull(testingTarget, "Can't create success object Address");
            Assert.IsInstanceOf<Address>(testingTarget, "Should be an instance of Address type.");

            tlog.Debug(tag, $"ViewAccessibilityAddressConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AddressCollection constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AddressCollection.Address C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressCollectionConstructor()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionConstructor START");

            using (View view = new ImageView())
            {
                var testingTarget = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(view.SwigCPtr));
                Assert.IsNotNull(testingTarget, "Can't create success object AddressCollection");
                Assert.IsInstanceOf<AddressCollection>(testingTarget, "Should be an instance of AddressCollection type.");
            }

            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AddressCollection IsInvalid.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AddressCollection.IsInvalid A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressCollectionIsInvalid()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionIsInvalid START");

            using (View view = new ImageView())
            {
                var testingTarget = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(view.SwigCPtr));
                Assert.IsNotNull(testingTarget, "Can't create success object AddressCollection");
                Assert.IsInstanceOf<AddressCollection>(testingTarget, "Should be an instance of AddressCollection type.");

                Assert.IsFalse(testingTarget.IsInvalid);
            }

            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionIsInvalid END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AddressCollection GetRelationSize.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AddressCollection.GetRelationSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressCollectionGetRelationSize()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionGetRelationSize START");

            using (View view = new ImageView())
            {
                var testingTarget = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(view.SwigCPtr));
                Assert.IsNotNull(testingTarget, "Can't create success object AddressCollection");
                Assert.IsInstanceOf<AddressCollection>(testingTarget, "Should be an instance of AddressCollection type.");

                try
                {
                    testingTarget.GetRelationSize(AccessibilityRelationType.DetailsFor);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionGetRelationSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AddressCollection GetAddressAt.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AddressCollection.GetAddressAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressCollectionGetAddressAt()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionGetAddressAt START");

            using (View view = new ImageView())
            {
                var testingTarget = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(view.SwigCPtr));
                Assert.IsNotNull(testingTarget, "Can't create success object AddressCollection");
                Assert.IsInstanceOf<AddressCollection>(testingTarget, "Should be an instance of AddressCollection type.");

                try
                {
                    var result = testingTarget.GetAddressAt(AccessibilityRelationType.Details, 19);
                    Assert.IsNotNull(result, "Can't create success object Address");
                    Assert.IsInstanceOf<Address>(result, "Should be an instance of Address type.");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionGetAddressAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AddressCollection ReleaseHandle.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AddressCollection.ReleaseHandle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAddressCollectionReleaseHandle()
        {
            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionReleaseHandle START");

            using (View view = new ImageView())
            {
                var testingTarget = new MyAddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(view.SwigCPtr));
                Assert.IsNotNull(testingTarget, "Can't create success object AddressCollection");
                Assert.IsInstanceOf<AddressCollection>(testingTarget, "Should be an instance of AddressCollection type.");

                try
                {
                    testingTarget.OnReleaseHandle();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"ViewAccessibilityAddressCollectionReleaseHandle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AccessibilityRange StartOffset.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.StartOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeStartOffset()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeStartOffset START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");
                
            testingTarget.StartOffset = 10;
            Assert.AreEqual(10, testingTarget.StartOffset, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeStartOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AccessibilityRange EndOffset.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.EndOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeEndOffset()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeEndOffset START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");

            testingTarget.EndOffset = 30;
            Assert.AreEqual(30, testingTarget.EndOffset, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeEndOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.AccessibilityRange Content.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.AccessibilityRange.Content A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityAccessibilityRangeContent()
        {
            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeContent START");

            var testingTarget = new AccessibilityRange();
            Assert.IsNotNull(testingTarget, "Can't create success object AccessibilityRange");
            Assert.IsInstanceOf<AccessibilityRange>(testingTarget, "Should be an instance of AccessibilityRange type.");

            testingTarget.Content = "TextLabel";
            Assert.AreEqual("TextLabel", testingTarget.Content, "Should be equal!");

            tlog.Debug(tag, $"ViewAccessibilityAccessibilityRangeContent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.RemoveAccessibilityAttribute.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.RemoveAccessibilityAttribute A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewRemoveAccessibilityAttribute()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewRemoveAccessibilityAttribute START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.AppendAccessibilityAttribute("MyView", "test");

            try
            {
                testingTarget.RemoveAccessibilityAttribute("MyView");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ViewAccessibilityViewRemoveAccessibilityAttribute END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewAccessibility.View.ClearAccessibilityAttributes.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibility.View.ClearAccessibilityAttributes A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityViewClearAccessibilityAttributes()
        {
            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityAttributes START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.AppendAccessibilityAttribute("MyView", "test");

            try
            {
                testingTarget.ClearAccessibilityAttributes();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ViewAccessibilityViewClearAccessibilityAttributes END (OK)");
        }
    }
}
