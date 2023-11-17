using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Element")]
    internal class PublicElementTest
    {
        private const string tag = "NUITEST";

        internal class MyElement : Element
        {
            public new void ChildAdded(Element child)
            {
                OnChildAdded(child);
            }

            public new void ChildRemoved(Element child)
            {
                OnChildRemoved(child);
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
        [Description("Element AutomationId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.AutomationId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementAutomationId()
        {
            tlog.Debug(tag, $"ElementAutomationId START");

            try
            {
                var testingTarget = new View();
                testingTarget.AutomationId = "View1";
                Assert.AreEqual("View1", testingTarget.AutomationId, "Should be equal");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementAutomationId END");
        }

        [Test]
        [Category("P2")]
        [Description("Element AutomationId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.AutomationId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementAutomationIdNotNull()
        {
            tlog.Debug(tag, $"ElementAutomationIdNotNull START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.AutomationId = "View1";
                Assert.AreEqual("View1", testingTarget.AutomationId, "Should be equal");
                testingTarget.AutomationId = "View2";

                testingTarget.Dispose();
            }
            catch (InvalidOperationException e)
            {
                Assert.True(true, "Caught InvalidOperationException" + e.Message.ToString());
            }

            tlog.Debug(tag, $"ElementAutomationIdNotNull END");
        }

        [Test]
        [Category("P1")]
        [Description("Element ClassId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ClassId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementClassId()
        {
            tlog.Debug(tag, $"ElementClassId START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.ClassId = "View1";
                Assert.AreEqual("View1", testingTarget.ClassId, "Should be equal");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementClassId END");
        }

        [Test]
        [Category("P1")]
        [Description("Element Id")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Id  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ElementId()
        {
            tlog.Debug(tag, $"ElementId START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                Assert.IsNotNull(testingTarget.Id, "Should not be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementId END");
        }

        [Test]
        [Category("P1")]
        [Description("Element ParentView")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentView  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Obsolete]
        public void ElementParentView()
        {
            tlog.Debug(tag, $"ElementParentView START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                Assert.IsNull(testingTarget.ParentView, "Should be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementParentView END");
        }

        [Test]
        [Category("P1")]
        [Description("Element ParentView")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentView  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Obsolete]
        public void ElementParentViewParentNotNull()
        {
            tlog.Debug(tag, $"ElementParentViewParentNotNull START");

            try
            {
                var testingTarget = new BaseHandle();
                Assert.IsNotNull(testingTarget, "null BaseHandle");
                
                using (BaseHandle handle = new BaseHandle())
                {
                    testingTarget.Parent = handle;
                    testingTarget.ParentOverride = handle;
                    Assert.IsNull(testingTarget.ParentView, "Should be null");
                }

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementParentViewParentNotNull END");
        }

        [Test]
        [Category("P1")]
        [Description("Element StyleId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.StyleId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementStyleId()
        {
            tlog.Debug(tag, $"ElementStyleId START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.StyleId = "View1";
                testingTarget.StyleId = "View1";
                Assert.AreEqual("View1", testingTarget.StyleId, "Should be equal");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementStyleId END");
        }

        [Test]
        [Category("P1")]
        [Description("Element LogicalChildren")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.LogicalChildren   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ElementLogicalChildren()
        {
            tlog.Debug(tag, $"ElementLogicalChildren START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");
                Assert.AreEqual(0, testingTarget.LogicalChildren.Count, "Should be equal");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementLogicalChildren END");
        }

        [Test]
        [Category("P1")]
        [Description("Element Owned")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Owned A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementOwned()
        {
            tlog.Debug(tag, $"ElementOwned START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.Owned = false;
                Assert.AreEqual(false, testingTarget.Owned, "Should be equal");
                testingTarget.Owned = true;
                Assert.AreEqual(true, testingTarget.Owned, "Should be equal");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementOwned END");
        }

        [Test]
        [Category("P1")]
        [Description("Element ParentOverride")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentOverride A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementParentOverride()
        {
            tlog.Debug(tag, $"ElementParentOverride START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.ParentOverride = null;
                Assert.IsNull(testingTarget.ParentOverride, "Should be null");

                testingTarget.ParentOverride = new View();
                Assert.IsNotNull(testingTarget.ParentOverride, "Should not be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementParentOverride END");
        }

        [Test]
        [Category("P1")]
        [Description("Element RealParent")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.RealParent  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ElementRealParent()
        {
            tlog.Debug(tag, $"ElementRealParent START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");
                Assert.IsNull(testingTarget.RealParent, "Should be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementRealParent END");
        }

        [Test]
        [Category("P1")]
        [Description("Element Parent")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ElementParent()
        {
            tlog.Debug(tag, $"ElementParent START");

            try
            {
                var testingTarget = new Animatable();
                Assert.IsNotNull(testingTarget, "null Element");

                Assert.IsNull(testingTarget.Parent, "Should be null");

                testingTarget.Parent = new View();
                Assert.IsNotNull(testingTarget.Parent, "Should not be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementParent END");
        }

        [Test]
        [Category("P1")]
        [Description("Element SetValueFromRenderer")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.SetValueFromRenderer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementSetValueFromRenderer()
        {
            tlog.Debug(tag, $"ElementSetValueFromRenderer START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");
                
                testingTarget.SetValueFromRenderer(View.NameProperty, "View1");
                Assert.True(true, "Should go here");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementSetValueFromRenderer END");
        }

        [Test]
        [Category("P1")]
        [Description("Element RemoveDynamicResource")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.RemoveDynamicResource  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementRemoveDynamicResource()
        {
            tlog.Debug(tag, $"ElementRemoveDynamicResource START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.SetDynamicResource(View.NameProperty, "View1");
                testingTarget.RemoveDynamicResource(View.NameProperty);
                Assert.True(true, "Should go here");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementRemoveDynamicResource END");
        }

        [Test]
        [Category("P1")]
        [Description("Element OnChildAdded")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildAdded  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementOnChildAdded()
        {
            tlog.Debug(tag, $"ElementOnChildAdded START");
            
            try
            {
                var testingTarget = new MyElement();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.ChildAdded(new MyElement());
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementOnChildAdded END");
        }

        [Test]
        [Category("P2")]
        [Description("Element OnChildAdded")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildAdded  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementOnChildAddedNull()
        {
            tlog.Debug(tag, $"ElementOnChildAddedNull START");
            try
            {
                var testingTarget = new MyElement();
                Assert.IsNotNull(testingTarget, "null Element");

                Element child = null;
                testingTarget.ChildAdded(child);
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true, "Caught Exception" + e.Message.ToString());
            }

            tlog.Debug(tag, $"ElementOnChildAddedNull END");
        }

        [Test]
        [Category("P1")]
        [Description("Element OnChildRemoved")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildRemoved  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementOnChildRemoved()
        {
            tlog.Debug(tag, $"ElementOnChildRemoved START");

            try
            {
                var testingTarget = new MyElement();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.ChildRemoved(new MyElement());
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementOnChildRemoved END");
        }

        [Test]
        [Category("P2")]
        [Description("Element OnChildRemoved")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildRemoved  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementOnChildRemovedNull()
        {
            tlog.Debug(tag, $"ElementOnChildRemovedNull START");

            try
            {
                var testingTarget = new MyElement();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.ChildRemoved(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true, "Caught Exception" + e.Message.ToString());
            }

            tlog.Debug(tag, $"ElementOnChildRemovedNull END");
        }

        [Test]
        [Category("P1")]
        [Description("Element Descendants")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Descendants M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ElementDescendants()
        {
            tlog.Debug(tag, $"ElementDescendants START");

            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                var ret = testingTarget.Descendants();
                Assert.IsNotNull(ret, "Should not be null");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementDescendants END");
        }

        [Test]
        [Category("P1")]
        [Description("Element VisibleDescendants")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.VisibleDescendants M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ElementVisibleDescendants()
        {
            tlog.Debug(tag, $"ElementVisibleDescendants START");
            
            try
            {
                var testingTarget = new View();
                Assert.IsNotNull(testingTarget, "null Element");

                testingTarget.LogicalChildren.Append<Element>(new View());
                testingTarget.VisibleDescendants();

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ElementVisibleDescendants END");
        }
    }
}