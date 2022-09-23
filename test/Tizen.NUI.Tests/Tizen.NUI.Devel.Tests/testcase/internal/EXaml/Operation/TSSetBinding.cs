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
    [Description("internal/EXaml/Operation/SetBinding ")]
    public class InternalOperationSetBindingTest
    {
        private const string tag = "NUITEST";

        internal class MySetBinding : Tizen.NUI.EXaml.Operation 
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
        [Description("SetBinding  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.SetBinding.SetBinding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlSetBindingConstructor()
        {
            tlog.Debug(tag, $"EXamlSetBindingConstructor START");
			
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();

                operationInfo.Add(1);     
                operationInfo.Add(2); 
                operationInfo.Add(3);
			
                var testingTarget = new Tizen.NUI.EXaml.SetBinding(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object SetBinding");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.SetBinding>(testingTarget, "Should be an instance of SetBinding type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlSetBindingConstructor END (OK)");
        }
	}	
}