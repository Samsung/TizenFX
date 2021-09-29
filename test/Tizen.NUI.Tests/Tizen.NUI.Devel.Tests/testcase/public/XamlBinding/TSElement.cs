using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

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
            public void ChildAdded(Element child)
            {
                OnChildAdded(child);
            }

            public void ChildRemoved(Element child)
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
        [Description("Element  AutomationId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.AutomationId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void AutomationIdTest()
        {
            tlog.Debug(tag, $"AutomationIdTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.AutomationId = "View1";
                Assert.AreEqual("View1", t2.AutomationId, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"AutomationIdTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Element  AutomationId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.AutomationId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void AutomationIdTest2()
        {
            tlog.Debug(tag, $"AutomationIdTest2 START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.AutomationId = "View1";
                Assert.AreEqual("View1", t2.AutomationId, "Should be equal");
                t2.AutomationId = "View2";
            }
            catch (InvalidOperationException e)
            {
                Assert.True(true, "Caught InvalidOperationException" + e.Message.ToString());
            }
            tlog.Debug(tag, $"AutomationIdTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  ClassId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ClassId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ClassIdTest()
        {
            tlog.Debug(tag, $"ClassIdTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.ClassId = "View1";
                Assert.AreEqual("View1", t2.ClassId, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ClassIdTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  Id")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Id  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void IdTest()
        {
            tlog.Debug(tag, $"IdTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                Assert.IsNotNull(t2.Id, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"IdTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  ParentView")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentView  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ParentViewTest()
        {
            tlog.Debug(tag, $"ParentViewTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                Assert.IsNull(t2.ParentView, "Should be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ParentViewTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  ParentView")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentView  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ParentViewTest2()
        {
            tlog.Debug(tag, $"ParentViewTest2 START");
            try
            {
                BaseHandle t1 = new BaseHandle();
                Assert.IsNotNull(t1, "null BaseHandle");
                BaseHandle t2 = new BaseHandle();
                Assert.IsNotNull(t2, "null BaseHandle");
                t1.Parent = t2;
                t1.ParentOverride = t2;
                Assert.IsNull(t1.ParentView, "Should be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ParentViewTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  StyleId")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.StyleId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StyleIdTest()
        {
            tlog.Debug(tag, $"StyleIdTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.StyleId = "View1";
                t2.StyleId = "View1";
                Assert.AreEqual("View1", t2.StyleId, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"StyleIdTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  LogicalChildren ")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.LogicalChildren   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void LogicalChildrenTest()
        {
            tlog.Debug(tag, $"LogicalChildrenTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                Assert.AreEqual(0, t2.LogicalChildren.Count, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"LogicalChildrenTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  Owned ")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Owned   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void OwnedTest()
        {
            tlog.Debug(tag, $"OwnedTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.Owned = false;
                Assert.AreEqual(false, t2.Owned, "Should be equal");
                t2.Owned = true;
                Assert.AreEqual(true, t2.Owned, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"OwnedTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  ParentOverride")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.ParentOverride   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ParentOverrideTest()
        {
            tlog.Debug(tag, $"OwnedTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.ParentOverride = null;
                Assert.IsNull(t2.ParentOverride, "Should be null");
                t2.ParentOverride = null;
                Assert.IsNull(t2.ParentOverride, "Should be null");
                t2.ParentOverride = new View();
                Assert.IsNotNull(t2.ParentOverride, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"OwnedTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  RealParent")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.RealParent  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void RealParentTest()
        {
            tlog.Debug(tag, $"RealParentTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                Assert.IsNull(t2.RealParent, "Should be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"RealParentTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  Parent")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Parent  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ParentTest()
        {
            tlog.Debug(tag, $"ParentTest START");
            try
            {
                Animatable t2 = new Animatable();
                Assert.IsNotNull(t2, "null Element");
                Assert.IsNull(t2.Parent, "Should be null");
                t2.Parent = new View();
                Assert.IsNotNull(t2.Parent, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ParentTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  SetValueFromRenderer")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.SetValueFromRenderer  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetValueFromRendererTest()
        {
            tlog.Debug(tag, $"SetValueFromRendererTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.SetValueFromRenderer(View.NameProperty, "View1");
                
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SetValueFromRendererTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  RemoveDynamicResource")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.RemoveDynamicResource  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void RemoveDynamicResourceTest()
        {
            tlog.Debug(tag, $"RemoveDynamicResourceTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.SetDynamicResource(View.NameProperty, "View1");
                t2.RemoveDynamicResource(View.NameProperty);

                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"RemoveDynamicResourceTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  OnChildAdded")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildAdded  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnChildAdded()
        {
            tlog.Debug(tag, $"OnChildAdded START");
            try
            {
                MyElement t2 = new MyElement();
                Assert.IsNotNull(t2, "null Element");
                t2.ChildAdded(new MyElement());
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"OnChildAdded END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  OnChildAdded")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildAdded  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnChildAdded2()
        {
            tlog.Debug(tag, $"OnChildAdded2 START");
            try
            {
                MyElement t2 = new MyElement();
                Assert.IsNotNull(t2, "null Element");
                t2.ChildAdded(new MyElement());
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true, "Caught Exception" + e.Message.ToString());
            }
            tlog.Debug(tag, $"OnChildAdded2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  OnChildRemoved")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildRemoved  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnChildRemoved()
        {
            tlog.Debug(tag, $"OnChildRemoved START");
            try
            {
                MyElement t2 = new MyElement();
                Assert.IsNotNull(t2, "null Element");
                t2.ChildRemoved(new MyElement());
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"OnChildRemoved END");
        }

        [Test]
        [Category("P2")]
        [Description("Element  OnChildRemoved")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.OnChildRemoved  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnChildRemoved2()
        {
            tlog.Debug(tag, $"OnChildRemoved2 START");
            try
            {
                MyElement t2 = new MyElement();
                Assert.IsNotNull(t2, "null Element");
                t2.ChildRemoved(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true, "Caught Exception" + e.Message.ToString());
            }
            tlog.Debug(tag, $"OnChildRemoved2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  Descendants")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.Descendants  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void DescendantsTest()
        {
            tlog.Debug(tag, $"DescendantsTest START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                var ret = t2.Descendants();

                Assert.IsNotNull(ret, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"DescendantsTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Element  VisibleDescendants")]
        [Property("SPEC", "Tizen.NUI.Binding.Element.VisibleDescendants  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void VisibleDescendants()
        {
            tlog.Debug(tag, $"VisibleDescendants START");
            try
            {
                View t2 = new View();
                Assert.IsNotNull(t2, "null Element");
                t2.LogicalChildren.Append<Element>(new View());
                t2.VisibleDescendants();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"VisibleDescendants END");
        }
    }
}