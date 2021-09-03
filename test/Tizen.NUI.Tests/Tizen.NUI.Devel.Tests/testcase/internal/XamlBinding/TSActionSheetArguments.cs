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
    [Description("internal/XamlBinding/ActionSheetArguments")]
    public class InternalActionSheetArgumentsTest
    {
        private const string tag = "NUITEST";
        private string[] Buttons = { "button1", "button2" };

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
        [Description("ActionSheetArguments constructor")]
        [Property("SPEC", "Tizen.NUI.ActionSheetArguments.ActionSheetArguments C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ActionSheetArgumentsConstructor()
        {
            tlog.Debug(tag, $"ActionSheetArgumentsConstructor START");

            var testingTarget = new ActionSheetArguments("ActionSheetArguments", "cancel", "destruction", Buttons);
            Assert.IsNotNull(testingTarget, "Can't create success object ActionSheetArguments.");
            Assert.IsInstanceOf<ActionSheetArguments>(testingTarget, "Should return ActionSheetArguments instance.");

            tlog.Debug(tag, "Buttons : " + testingTarget.Buttons);
            tlog.Debug(tag, "Cancel : " + testingTarget.Cancel);
            tlog.Debug(tag, "Destruction  : " + testingTarget.Destruction);
            tlog.Debug(tag, "Result  : " + testingTarget.Result);
            tlog.Debug(tag, "Title   : " + testingTarget.Title);

            try
            {
                testingTarget.SetResult("OK");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ActionSheetArgumentsConstructor END");
        }
    }
}
