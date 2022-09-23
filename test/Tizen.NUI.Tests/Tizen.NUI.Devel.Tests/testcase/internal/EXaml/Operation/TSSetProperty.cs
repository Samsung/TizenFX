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
    [Description("internal/EXaml/Operation/SetProperty ")]
    public class InternalOperationSetPropertyTest
    {
        private const string tag = "NUITEST";

        internal class MySetProperty : Tizen.NUI.EXaml.Operation 
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
        [Description("SetProperty  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetProperty.SetProperty C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetPropertyConstructor()
        {
            tlog.Debug(tag, $"EXamlSetPropertyConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(2);
			    
                List<object> list = new List<object>();
			    operationInfo.Add(list);
			
                var testingTarget = new Tizen.NUI.EXaml.SetProperty(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object SetProperty");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.SetProperty>(testingTarget, "Should be an instance of SetProperty type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlSetPropertyConstructor END (OK)");
        }
	}
}