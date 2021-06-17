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
    [Description("public/Template/DataTemplateSelector")]
    public class PublicDataTemplateSelectorTest
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
        [Category("P2")]
        [Description("DataTemplateSelector SelectTemplate. With null LoadTemplate.")]
        [Property("SPEC", "Tizen.NUI.DataTemplateExtensions.CreateContent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSelectorSelectTemplateWithNullLoadTemplate()
        {
            tlog.Debug(tag, $"DataTemplateSelectorSelectTemplateWithNullLoadTemplate START");

            var testingTarget = new MyDataTemplateSelector();

            try
            {
                DataTemplateExtensions.CreateContent(testingTarget, "Color", new View());
            }
            catch (NotSupportedException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"DataTemplateSelectorSelectTemplateWithNullLoadTemplate END (OK)");
                Assert.Pass("Caught NotSupportedException: Pass!");
            }

            tlog.Debug(tag, $"DataTemplateSelectorSelectTemplateWithNullLoadTemplate END (OK)");
        }
    }
}
