using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.EXaml;
using System.Collections.Generic;
namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Operation/AddEvent ")]
    public class InternalOperationAddEventTest
    {
        private const string tag = "NUITEST";

        internal class MyAddEvent : Tizen.NUI.EXaml.Operation 
        {
            public void Do() { }
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
        [Description("AddEvent constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.AddEvent.AddEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AddEventConstructor()
        {
            tlog.Debug(tag, $"AddEventConstructor START");

            try
            {
                var globalDataList = new GlobalDataList();
                List<object> operationInfo = new List<object>();

                operationInfo.Add(1);		// instanceIndex
                operationInfo.Add(2);		// elementIndex
                operationInfo.Add(3);		// eventIndex
                operationInfo.Add(4);		// valueIndex

                var testingTarget = new Tizen.NUI.EXaml.AddEvent(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object AddEvent");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.AddEvent>(testingTarget, "Should be an instance of AddEvent type.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : failed!");
            }

            tlog.Debug(tag, $"AddEventConstructor END (OK)");
        }
    }
}