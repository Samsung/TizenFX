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
    [Description("internal/EXaml/Operation/GetStaticObject ")]
    public class InternalOperationGetStaticObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyGetStaticObject : Tizen.NUI.EXaml.Operation 
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
        [Description("GetStaticObject  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetStaticObject.GetStaticObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetStaticObjectConstructor()
        {
            tlog.Debug(tag, $"EXamlGetStaticObjectConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(2); 
			    operationInfo.Add(3); 
			
                var testingTarget = new Tizen.NUI.EXaml.GetStaticObject(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GetStaticObject");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GetStaticObject>(testingTarget, "Should be an instance of GetStaticObject type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetStaticObjectConstructor END (OK)");
        }
	}
}