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
    [Description("internal/EXaml/Operation/AddObject ")]
    public class InternalOperationAddObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyAddObject : Tizen.NUI.EXaml.Operation 
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
       [Description("AddObject constructor.")]
       [Property("SPEC", "Tizen.NUI.EXaml.AddObject.AddObject C")]
       [Property("SPEC_URL", "-")]
       [Property("CRITERIA", "CONSTR")]
       [Property("AUTHOR", "guowei.wang@samsung.com")]
       public void EXamlAddObjectConstructor()
       {
           tlog.Debug(tag, $"EXamlAddObjectConstructor START");

           try
           {
               var globalDataList = new GlobalDataList();
               List<object> operationInfo = new List<object>();

               operationInfo.Add(1);
               operationInfo.Add(new object());
               operationInfo.Add(2);

               var testingTarget = new Tizen.NUI.EXaml.AddObject(globalDataList, operationInfo);
               Assert.IsNotNull(testingTarget, "Can't create success object AddObject");
               Assert.IsInstanceOf<Tizen.NUI.EXaml.AddObject>(testingTarget, "Should be an instance of AddObject type.");
           }
           catch (Exception e)
           {
               tlog.Debug(tag, e.Message.ToString());
               Assert.Fail("Caught Exception : failed!");
           }

           tlog.Debug(tag, $"EXamlAddObjectConstructor END (OK)");
        }
    }
}