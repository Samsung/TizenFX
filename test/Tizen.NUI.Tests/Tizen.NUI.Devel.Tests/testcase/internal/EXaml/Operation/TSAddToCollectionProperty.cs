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
    [Description("internal/EXaml/Operation/AddToCollectionProperty ")]
    public class InternalOperationAddToCollectionPropertyTest
    {
        private const string tag = "NUITEST";

        internal class MyAddToCollectionProperty : Tizen.NUI.EXaml.Operation 
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
        [Description("AddToCollectionProperty  constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.AddToCollectionProperty.AddToCollectionProperty C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlAddToCollectionPropertyConstructor()
        {
            tlog.Debug(tag, $"EXamlAddToCollectionPropertyConstructor START");
			try
			{
                var globalDataList = new GlobalDataList();
			    List<object> operationInfo = new List<object>();
            
			    operationInfo.Add(1);     
                operationInfo.Add(new {}); 
			
                var testingTarget = new Tizen.NUI.EXaml.AddToCollectionProperty(globalDataList, operationInfo);			
                Assert.IsNotNull(testingTarget, "Can't create success object AddToCollectionProperty");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.AddToCollectionProperty>(testingTarget, "Should be an instance of AddToCollectionProperty type.");
			}
			catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlAddToCollectionPropertyConstructor END (OK)");
        }
	}
}