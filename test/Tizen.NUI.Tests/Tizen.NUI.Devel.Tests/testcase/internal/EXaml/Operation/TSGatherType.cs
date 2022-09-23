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
    [Description("internal/EXaml/Operation/GatherType ")]
    public class InternalOperationGatherTypeTest
    {
        private const string tag = "NUITEST";

        internal class MyGatherType : Tizen.NUI.EXaml.Operation 
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
        [Description("GatherType  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GatherType.GatherType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGatherTypeConstructor()
        {
            tlog.Debug(tag, $"EXamlGatherTypeConstructor START");

			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(2); 
			
			    List<object> list = new List<object>();
			    operationInfo.Add(list);
			
                var testingTarget = new Tizen.NUI.EXaml.GatherType(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GatherType");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherType>(testingTarget, "Should be an instance of GatherType type.");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGatherTypeConstructor END (OK)");
        }
		
		[Test]
        [Category("P1")]
        [Description("GatherType Do.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GatherType.Do M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
		public void EXamlGatherTypeDo()
        {
            tlog.Debug(tag, $"EXamlGatherTypeDo START");
			
            var globalDataList = new GlobalDataList();
			List<object> operationInfo = new List<object>();
            
			operationInfo.Add(1);     
            operationInfo.Add(2); 
			
			List<object> list = new List<object>();
			operationInfo.Add(list);
			
            var testingTarget = new Tizen.NUI.EXaml.GatherType(globalDataList, operationInfo);
			Assert.IsNotNull(testingTarget, "Can't create success object GatherType");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.GatherType>(testingTarget, "Should be an instance of GatherType type.");
			
			try
			{
			    testingTarget.Do();
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception : Passed!");
            }
           
            tlog.Debug(tag, $"EXamlGatherTypeDo END (OK)");
        }
	}
}