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
    [Description("internal/EXaml/Operation/GetEnumObject ")]
    public class InternalOperationGetEnumObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyGetEnumObject : Tizen.NUI.EXaml.Operation 
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
        [Description("GetEnumObject  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetEnumObject.GetEnumObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetEnumObjectConstructor()
        {
            tlog.Debug(tag, $"EXamlGetEnumObjectConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(2); 
			
                var testingTarget = new Tizen.NUI.EXaml.GetEnumObject(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GetEnumObject");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GetEnumObject>(testingTarget, "Should be an instance of GetEnumObject type.");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"EXamlGetEnumObjectConstructor END (OK)");
        }
	}
}