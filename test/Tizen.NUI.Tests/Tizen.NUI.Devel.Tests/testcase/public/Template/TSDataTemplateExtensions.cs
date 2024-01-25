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
    [Description("public/Template/DataTemplateExtensions")]
    public class PublicDataTemplateExtensionsTest
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
                    Func<object> LoadTemplate = () => new View();

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
        [Description("DataTemplateExtensions CreateContent.")]
        [Property("SPEC", "Tizen.NUI.DataTemplateExtensions.CreateContent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateExtensionsCreateContent()
        {
            tlog.Debug(tag, $"DataTemplateExtensionsCreateContent START");

            var testingTarget = new MyDataTemplateSelector();

            try
            {
                DataTemplateExtensions.CreateContent(testingTarget, View.Property.STATE, new View());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("CreateContent Fail!");
            }

            tlog.Debug(tag, $"DataTemplateExtensionsCreateContent END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("DataTemplateExtensions CreateContent. With null selector.")]
        [Property("SPEC", "Tizen.NUI.DataTemplateExtensions.CreateContent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateExtensionsCreateContentWithNullSelector()
        {
            tlog.Debug(tag, $"DataTemplateExtensionsCreateContentWithNullSelector START");

            Func<object> LoadTemplate = () => new View();
            var testingTarget = new DataTemplate(LoadTemplate);

            try
            {
                DataTemplateExtensions.CreateContent(testingTarget, View.Property.STATE, new View());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("CreateContent Fail!");
            }

            tlog.Debug(tag, $"DataTemplateExtensionsCreateContentWithNullSelector END (OK)");
        }
    }
}
