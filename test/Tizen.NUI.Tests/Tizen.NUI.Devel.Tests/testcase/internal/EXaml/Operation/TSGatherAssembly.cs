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
    [Description("internal/EXaml/Operation/GatherAssembly ")]
    public class InternalOperationGatherAssemblyTest
    {
        private const string tag = "NUITEST";

        internal class MyGatherAssembly : Tizen.NUI.EXaml.Operation 
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
        [Description("GatherAssembly  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GatherAssembly.GatherAssembly C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGatherAssemblyConstructor()
        {
            tlog.Debug(tag, $"EXamlGatherAssemblyConstructor START");
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);
			
                var testingTarget = new Tizen.NUI.EXaml.GatherAssembly(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GatherAssembly");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherAssembly>(testingTarget, "Should be an instance of GatherAssembly type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGatherAssemblyConstructor END (OK)");
        }
	}	
}