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
    [Description("internal/EXaml/Operation/CreateArrayObject ")]
    public class InternalOperationCreateArrayObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyCreateArrayObject : Tizen.NUI.EXaml.Operation 
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
        [Description("CreateArrayObject  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.CreateArrayObject.CreateArrayObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlCreateArrayObjectConstructor()
        {
            tlog.Debug(tag, $"EXamlCreateArrayObjectConstructor START");
			
            try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(new {});
			
                var testingTarget = new Tizen.NUI.EXaml.CreateArrayObject(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object CreateArrayObject");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.CreateArrayObject>(testingTarget, "Should be an instance of CreateArrayObject type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlCreateArrayObjectConstructor END (OK)");
        }
	}
}