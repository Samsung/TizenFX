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
    [Description("internal/EXaml/Operation/CreateDataTemplate ")]
    public class InternalOperationCreateDataTemplateTest
    {
        private const string tag = "NUITEST";

        internal class MyCreateDataTemplate : Tizen.NUI.EXaml.Operation 
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
        [Description("CreateDataTemplate  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.CreateDataTemplate.GatherEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlCreateDataTemplateConstructor()
        {
            tlog.Debug(tag, $"EXamlCreateDataTemplateConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();

                operationInfo.Add(1);     
                operationInfo.Add(2);            
                operationInfo.Add(3);

                var testingTarget = new Tizen.NUI.EXaml.CreateDataTemplate(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object CreateDataTemplate");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.CreateDataTemplate>(testingTarget, "Should be an instance of CreateDataTemplate type.");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
		   
            tlog.Debug(tag, $"EXamlCreateDataTemplateConstructor END (OK)");
        }
	}
}