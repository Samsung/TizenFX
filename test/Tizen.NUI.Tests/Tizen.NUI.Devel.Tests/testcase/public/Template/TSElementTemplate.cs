using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Template/ElementTemplate")]
    public class PublicElementTemplateTest
    {
        private const string tag = "NUITEST";

        internal class MyDataTemplateSelector : DataTemplateSelector
        {
            public MyDataTemplateSelector() : base()
            { }

            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                if (item.GetType().ToString() == "System.String")
                {
                    return new MyDataTemplateSelector();
                }
                else
                {
                    Func<object> LoadTemplate = null;

                    return new DataTemplate(LoadTemplate);
                }

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
        [Description("ElementTemplate Parent.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateParent()
        {
            tlog.Debug(tag, $"ElementTemplateParent START");

            try
            {
                Func<object> LoadTemplate = () => new View();
                var testingTarget = new DataTemplate(LoadTemplate) as IElement;

                testingTarget.Parent = Window.Instance.GetDefaultLayer();
                Assert.AreEqual("Tizen.NUI.Layer", testingTarget.Parent.ToString(), "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ElementTemplateParent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ElementTemplate CanRecycle.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.CanRecycle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateCanRecycle()
        {
            tlog.Debug(tag, $"ElementTemplateCanRecycle START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as ElementTemplate;
            Assert.AreEqual(false, testingTarget.CanRecycle, "Should be equal!");

            string str = "ElementTemplate";
            var testingTarget1 = new DataTemplate(str.GetType()) as ElementTemplate;
            Assert.AreEqual(true, testingTarget1.CanRecycle, "Should be equal!");

            tlog.Debug(tag, $"ElementTemplateCanRecycle END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ElementTemplate Parent. Parent == Value.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateParentEqualsToValue()
        {
            tlog.Debug(tag, $"ElementTemplateParentEqualsToValue START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as IElement;

            testingTarget.Parent = Window.Instance.GetDefaultLayer();
            Assert.AreEqual("Tizen.NUI.Layer", testingTarget.Parent.ToString(), "Should be equal!");

            try
            {
                testingTarget.Parent = testingTarget.Parent;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ElementTemplateParentEqualsToValue END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ElementTemplate Parent. Parent != Value.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.Parent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateParentNotEqualsToValue()
        {
            tlog.Debug(tag, $"ElementTemplateParentNotEqualsToValue START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as IElement;

            testingTarget.Parent = Window.Instance.GetDefaultLayer();
            Assert.AreEqual("Tizen.NUI.Layer", testingTarget.Parent.ToString(), "Should be equal!");

            try
            {
                testingTarget.Parent = new View();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ElementTemplateParentNotEqualsToValue END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ElementTemplate constructor. With null Type.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.ElementTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateConstructorWithNullType()
        {
            tlog.Debug(tag, $"ElementTemplateConstructorWithNullType START");

            try
            {
                Type type = null;
                var testingTarget = new DataTemplate(type);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, $"ElementTemplateConstructorWithNullType END (OK)");
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught ArgumentNullException: Pass!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ElementTemplate constructor. With null loadTemplate.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.ElementTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateConstructorWithNullLoadTemplate()
        {
            tlog.Debug(tag, $"ElementTemplateConstructorWithNullLoadTemplate START");

            try
            {
                var testingTarget = new MyDataTemplateSelector();

                View view = new View()
                {
                    Color = Color.Cyan,
                };

                DataTemplateExtensions.CreateContent(testingTarget, View.Property.STATE, view);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, $"ElementTemplateConstructorWithNullLoadTemplate END (OK)");
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught ArgumentNullException: Pass!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ElementTemplate AddResourcesChangedListener.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.AddResourcesChangedListener M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateAddResourcesChangedListener()
        {
            tlog.Debug(tag, $"ElementTemplateAddResourcesChangedListener START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as IElement;

            Action<object, ResourcesChangedEventArgs> onChanged = null;

            try
            {
                testingTarget.AddResourcesChangedListener(onChanged);
            }
            catch (Exception e) 
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Falied!");
            }

            tlog.Debug(tag, $"ElementTemplateAddResourcesChangedListener END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ElementTemplate RemoveResourcesChangedListener.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.RemoveResourcesChangedListener M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateRemoveResourcesChangedListener()
        {
            tlog.Debug(tag, $"ElementTemplateRemoveResourcesChangedListener START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as IElement;

            Action<object, ResourcesChangedEventArgs> onChanged = null;
            testingTarget.AddResourcesChangedListener(onChanged);

            try
            {
                testingTarget.RemoveResourcesChangedListener(onChanged);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Falied!");
            }

            tlog.Debug(tag, $"ElementTemplateRemoveResourcesChangedListener END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ElementTemplate RemoveResourcesChangedListener. Null changeHandlers.")]
        [Property("SPEC", "Tizen.NUI.ElementTemplate.RemoveResourcesChangedListener M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ElementTemplateRemoveResourcesChangedListenerWithNullChangeHandlers()
        {
            tlog.Debug(tag, $"ElementTemplateRemoveResourcesChangedListenerWithNullChangeHandlers START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate) as IElement;

            Action<object, ResourcesChangedEventArgs> onChanged = null;

            try
            {
                testingTarget.RemoveResourcesChangedListener(onChanged);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Falied!");
            }

            tlog.Debug(tag, $"ElementTemplateRemoveResourcesChangedListenerWithNullChangeHandlers END (OK)");
        }
    }
}
