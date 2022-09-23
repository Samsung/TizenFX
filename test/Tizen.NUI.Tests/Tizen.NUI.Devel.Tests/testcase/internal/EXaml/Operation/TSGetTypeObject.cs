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
    [Description("internal/EXaml/Operation/GetTypeObject ")]
    public class InternalOperationGetTypeObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyGetTypeObject : Tizen.NUI.EXaml.Operation 
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
        [Description("GetTypeObject  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetTypeObject.GetTypeObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetTypeObjectConstructor()
        {
            tlog.Debug(tag, $"EXamlGetTypeObjectConstructor START");

            try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();

                operationInfo.Add(1);     

                var testingTarget = new Tizen.NUI.EXaml.GetTypeObject(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object GetTypeObject");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GetTypeObject>(testingTarget, "Should be an instance of GetTypeObject type.");
            }
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGetTypeObjectConstructor END (OK)");
        }
	}
}