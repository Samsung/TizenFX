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
    [Description("internal/EXaml/Operation/GetObjectConvertedFromString ")]
    public class InternalOperationGetObjectConvertedFromStringTest
    {
        private const string tag = "NUITEST";

        internal class MyGetObjectConvertedFromString : Tizen.NUI.EXaml.Operation 
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
        [Description("GetObjectConvertedFromString  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetObjectConvertedFromString.GetObjectConvertedFromString C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetObjectConvertedFromStringConstructor()
        {
            tlog.Debug(tag, $"EXamlGetObjectConvertedFromStringConstructor START");
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);       
                operationInfo.Add(2);  

                var testingTarget = new Tizen.NUI.EXaml.GetObjectConvertedFromString(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GetObjectConvertedFromString");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GetObjectConvertedFromString>(testingTarget, "Should be an instance of GetObjectConvertedFromString type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            tlog.Debug(tag, $"EXamlGetObjectConvertedFromStringConstructor END (OK)");
        }
	}
}