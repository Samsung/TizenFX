using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/BindingExpression")]
    public class InternalBindingExpressionTest
    {
        private const string tag = "NUITEST";
        private string selfpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_View.xaml";

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
        [Description("BindingExpression constructor")]
        [Property("SPEC", "Tizen.NUI.BindingExpression.BindingExpression C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingExpressionConstructor()
        {
            tlog.Debug(tag, $"BindingExpressionConstructor START");

            var testingTarget = new BindingExpression(new TemplateBinding(), selfpath);
            Assert.IsNotNull(testingTarget, "Can't create success object BindingExpression.");
            Assert.IsInstanceOf<BindingExpression>(testingTarget, "Should return BindingExpression instance.");

            tlog.Debug(tag, "Binding : " + testingTarget.Binding);

            tlog.Debug(tag, $"BindingExpressionConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("BindingExpression constructor")]
        [Property("SPEC", "Tizen.NUI.BindingExpression.BindingExpression C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingExpressionConstructorNullBinding()
        {
            tlog.Debug(tag, $"BindingExpressionConstructorNullBinding START");

            BindingBase binding = null;
            Assert.Throws<ArgumentNullException>(() => new BindingExpression(binding, selfpath));
            tlog.Debug(tag, $"BindingExpressionConstructorNullBinding END");
        }

        [Test]
        [Category("P2")]
        [Description("BindingExpression constructor")]
        [Property("SPEC", "Tizen.NUI.BindingExpression.BindingExpression C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingExpressionConstructorNullPath()
        {
            tlog.Debug(tag, $"BindingExpressionConstructorNullPath START");
            Assert.Throws<ArgumentNullException>(() => new BindingExpression(new TemplateBinding(), null));
            tlog.Debug(tag, $"BindingExpressionConstructorNullPath END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExpression Apply")]
        [Property("SPEC", "Tizen.NUI.BindingExpression.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void BindingExpressionApplyNullSource()
        {
            tlog.Debug(tag, $"BindingExpressionApplyNullSource START");

            var testingTarget = new BindingExpression(new TemplateBinding(), selfpath);
            Assert.IsNotNull(testingTarget, "Can't create success object BindingExpression.");
            Assert.IsInstanceOf<BindingExpression>(testingTarget, "Should return BindingExpression instance.");

            try
            {
                testingTarget.Apply(false);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExpressionApplyNullSource END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExpression Apply")]
        [Property("SPEC", "Tizen.NUI.BindingExpression.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void BindingExpressionApply()
        {
            tlog.Debug(tag, $"BindingExpressionApply START");

            var testingTarget = new BindingExpression(new TemplateBinding(), selfpath);
            Assert.IsNotNull(testingTarget, "Can't create success object BindingExpression.");
            Assert.IsInstanceOf<BindingExpression>(testingTarget, "Should return BindingExpression instance.");

            try
            {
                using (View view = new View() { Color = Color.Red })
                {
                    using (View preView = new View() { Color = Color.Cyan })
                    {
                        BindableProperty property = BindableProperty.Create("myProperty", typeof(string), typeof(View), null, BindingMode.OneWay,
                                                  null, null, null, null, null);

                        testingTarget.Apply(view, preView, property);
                        testingTarget.Apply(true);
                        testingTarget.Apply(false);
                        testingTarget.Unapply();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExpressionApply END");
        }
    }
}
