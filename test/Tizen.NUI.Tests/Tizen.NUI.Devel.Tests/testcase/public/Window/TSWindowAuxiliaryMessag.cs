using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Window/WindowAuxiliaryMessageEvent")]
    internal class PublicWindowAuxiliaryMessageEventTest
    {
        private const string tag = "NUITEST";

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
        [Description("Create a AuxiliaryMessageEventArgs  object.")]
        [Property("SPEC", "Tizen.NUI.Window.WindowAuxiliaryMessageEvent.AuxiliaryMessageEventArgs  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AuxiliaryMessageEventArgsConstructor()
        {
            tlog.Debug(tag, $"AuxiliaryMessageEventArgsConstructor START");

            var testingTarget = new AuxiliaryMessageEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object AuxiliaryMessageEventArgs ");
            Assert.IsInstanceOf<AuxiliaryMessageEventArgs>(testingTarget, "Should return AuxiliaryMessageEventArgs instance.");

            tlog.Debug(tag, $"AuxiliaryMessageEventArgsConstructor END (OK)");
        }
	
	    [Test]
        [Category("P1")]
        [Description("WindowAuxiliaryMessageEvent Key")]
        [Property("SPEC", "Tizen.NUI.Window.WindowAuxiliaryMessageEvent Key M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAuxiliaryMessageEventKey()
        {
            tlog.Debug(tag, $"WindowAuxiliaryMessageEventKey START");

            var testingTarget = new AuxiliaryMessageEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object AuxiliaryMessageEventArgs ");
            Assert.IsInstanceOf<AuxiliaryMessageEventArgs>(testingTarget, "Should return AuxiliaryMessageEventArgs instance.");

            try
            {
                testingTarget.Key = "str";
                tlog.Debug(tag, "Key : " + testingTarget.Key);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowAuxiliaryMessageEventKey END (OK)");
        }

	    [Test]
        [Category("P1")]
        [Description("WindowAuxiliaryMessageEvent Value")]
        [Property("SPEC", "Tizen.NUI.Window.WindowAuxiliaryMessageEvent Value M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAuxiliaryMessageEventValue()
        {
            tlog.Debug(tag, $"WindowAuxiliaryMessageEventValue START");

            var testingTarget = new AuxiliaryMessageEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object AuxiliaryMessageEventArgs ");
            Assert.IsInstanceOf<AuxiliaryMessageEventArgs>(testingTarget, "Should return AuxiliaryMessageEventArgs instance.");

            try
            {
                testingTarget.Value = "str" ;
				tlog.Debug(tag, "Value : " + testingTarget.Value);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
           
            tlog.Debug(tag, $"WindowAuxiliaryMessageEventValue END (OK)");
        }
	
	    [Test]
        [Category("P1")]
        [Description("WindowAuxiliaryMessageEvent Options")]
        [Property("SPEC", "Tizen.NUI.Window.WindowAuxiliaryMessageEvent Options M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void WindowAuxiliaryMessageEventOptions()
        {
            tlog.Debug(tag, $"WindowAuxiliaryMessageEventOptions START");

            var testingTarget = new AuxiliaryMessageEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object AuxiliaryMessageEventArgs ");
            Assert.IsInstanceOf<AuxiliaryMessageEventArgs>(testingTarget, "Should return AuxiliaryMessageEventArgs instance.");

            try
            {
                List<string> list = new List<string>();
                list.Add("add");
                list.Add("minus");
                list.Add("multiply");
                list.Add("divide");

				testingTarget.Options = list;
                Assert.AreEqual("add", testingTarget.Options[0], "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"WindowAuxiliaryMessageEventOptions END (OK)");
        }
	}
	
}