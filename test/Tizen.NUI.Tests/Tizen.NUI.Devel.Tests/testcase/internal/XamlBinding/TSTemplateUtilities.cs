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
    [Description("internal/XamlBinding/TemplateUtilities")]
    public class InternalTemplateUtilitiesTest
    {
        private const string tag = "NUITEST";
        internal class MyView : BaseHandle, IControlTemplated
        {
            public IList<Element> InternalChildren => new List<Element>() { };

            public void OnControlTemplateChanged(ControlTemplate oldValue, ControlTemplate newValue)
            {
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
        [Description("TemplateUtilities constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateUtilities.FindTemplatedParentAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FindTemplatedParentAsync()
        {
            tlog.Debug(tag, $"FindTemplatedParentAsync START");
            try
            {
                var view = new BaseHandle();
                var testingTarget = TemplateUtilities.FindTemplatedParentAsync(view);
                Assert.IsNotNull(testingTarget, "Should not be null");
                var parent = new BaseHandle();
                view.Parent = parent;
                var testingTarget2 = TemplateUtilities.FindTemplatedParentAsync(view);
                Assert.IsNotNull(testingTarget, "Should not be null");
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception" + e.Message.ToString());
            }

            tlog.Debug(tag, $"FindTemplatedParentAsync END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateUtilities constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateUtilities.GetRealParentAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetRealParentAsync()
        {
            tlog.Debug(tag, $"GetRealParentAsync START");
            try
            {
                var view = new BaseHandle();
                var testingTarget = TemplateUtilities.GetRealParentAsync(view);
                Assert.IsNotNull(testingTarget, "Should not be null");
                var parent = new BaseHandle();
                view.Parent = parent;
                var testingTarget2 = TemplateUtilities.GetRealParentAsync(view);
                Assert.IsNotNull(testingTarget, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception" + e.Message.ToString());
            }

            tlog.Debug(tag, $"GetRealParentAsync END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateUtilities constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateUtilities.OnControlTemplateChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnControlTemplateChanged()
        {
            tlog.Debug(tag, $"OnControlTemplateChanged START");
            try
            {
                var view = new MyView();
                var child = new MyView();
                child.Parent = view;

                TemplateUtilities.OnControlTemplateChanged(view, "old", "new");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception" + e.Message.ToString());
            }

            tlog.Debug(tag, $"OnControlTemplateChanged END");
        }
    }
}
