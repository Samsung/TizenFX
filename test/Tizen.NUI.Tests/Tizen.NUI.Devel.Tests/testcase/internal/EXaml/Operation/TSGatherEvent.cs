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
    [Description("internal/EXaml/Operation/GatherEvent ")]
    public class InternalOperationGatherEventTest
    {
        private const string tag = "NUITEST";

        internal class MyGatherEvent : Tizen.NUI.EXaml.Operation 
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
        [Description("GatherEvent  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GatherEvent.GatherEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGatherEventConstructor()
        {
            tlog.Debug(tag, $"EXamlGatherEventConstructor START");
            try
            {
                var globalDataList = new GlobalDataList();
                List<object> operationInfo = new List<object>();

                operationInfo.Add(1);
                operationInfo.Add(2);

                var testingTarget = new Tizen.NUI.EXaml.GatherEvent(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GatherEvent");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherEvent>(testingTarget, "Should be an instance of GatherEvent type.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGatherEventConstructor END (OK)");
        }
    }
}