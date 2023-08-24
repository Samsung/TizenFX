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
    [Description("internal/EXaml/Operation/GatherProperty ")]
    public class InternalOperationGatherPropertyTest
    {
        private const string tag = "NUITEST";

        internal class MyGatherProperty : Tizen.NUI.EXaml.Operation 
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
        [Description("GatherProperty  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GatherProperty.GatherProperty C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGatherPropertyConstructor()
        {
            tlog.Debug(tag, $"EXamlGatherPropertyConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);      
                operationInfo.Add(2); 
			
                var testingTarget = new Tizen.NUI.EXaml.GatherProperty(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GatherProperty");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherProperty>(testingTarget, "Should be an instance of GatherProperty type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGatherPropertyConstructor END (OK)");
        }
	}
}