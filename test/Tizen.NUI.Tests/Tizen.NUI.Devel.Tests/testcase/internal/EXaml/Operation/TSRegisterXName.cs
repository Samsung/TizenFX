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
    [Description("internal/EXaml/Operation/RegisterXName ")]
    public class InternalOperationRegisterXNameTest
    {
        private const string tag = "NUITEST";

        internal class MyRegisterXName : Tizen.NUI.EXaml.Operation 
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
        [Description("RegisterXName  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RegisterXName.RegisterXName C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlRegisterXNameConstructor()
        {
            tlog.Debug(tag, $"EXamlRegisterXNameConstructor START");

			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(2); 
			
                var testingTarget = new Tizen.NUI.EXaml.RegisterXName(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object RegisterXName");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.RegisterXName>(testingTarget, "Should be an instance of RegisterXName type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlRegisterXNameConstructor END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("RegisterXName Do.")]
        [Property("SPEC", "Tizen.NUI.EXaml.RegisterXName.Do M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
		public void EXamlRegisterXNameDo()
        {
            tlog.Debug(tag, $"EXamlRegisterXNameDo START");
			
            var globalDataList = new GlobalDataList();
			List<object> operationInfo = new List<object>();
            
			operationInfo.Add(1);     
            operationInfo.Add(2); 
			
            var testingTarget = new Tizen.NUI.EXaml.RegisterXName(globalDataList, operationInfo);
			Assert.IsNotNull(testingTarget, "Can't create success object RegisterXName");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.RegisterXName>(testingTarget, "Should be an instance of RegisterXName type.");
			
			try
			{
			    testingTarget.Do();
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
           
            tlog.Debug(tag, $"EXamlRegisterXNameDo END (OK)");
        }
    }
}