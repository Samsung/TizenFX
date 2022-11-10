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
    [Description("internal/EXaml/Operation/CreateDPObject ")]
    public class InternalOperationCreateDPObjectTest
    {
        private const string tag = "NUITEST";

        internal class MyCreateDPObject : Tizen.NUI.EXaml.Operation 
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
        [Description("CreateDPObject constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.CreateDPObject.CreateDPObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlCreateDPObjectConstructor()
        {
            tlog.Debug(tag, $"EXamlCreateDPObjectConstructor START");
            try
            {
                var globalDataList = new GlobalDataList();
                List<object> operationInfo = new List<object>();

                operationInfo.Add("str");
                operationInfo.Add(-4);

                var testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                Assert.IsNotNull(testingTarget, "Can't create success object CreateDPObject");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.CreateDPObject>(testingTarget, "Should be an instance of CreateDPObject type.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlCreateDPObjectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CreateDPObject Do.")]
        [Property("SPEC", "Tizen.NUI.EXaml.CreateDPObject.Do M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlCreateDPObjectDo()
        {
            tlog.Debug(tag, $"EXamlCreateDPObjectDo START");

            var globalDataList = new GlobalDataList();
            List<object> operationInfo = new List<object>();

            try
            {
                // ToInt16 
                operationInfo.Add("20dp");
                operationInfo.Add(-3);
                var testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToInt32
                operationInfo.Clear();
                operationInfo.Add("20px");
                operationInfo.Add(-4);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToInt64
                operationInfo.Clear();
                operationInfo.Add("20sp");
                operationInfo.Add(-5);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToUint16
                operationInfo.Clear();
                operationInfo.Add("20pt");
                operationInfo.Add(-7);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToUint32
                operationInfo.Clear();
                operationInfo.Add("30pt");
                operationInfo.Add(-8);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToUInt64
                operationInfo.Clear();
                operationInfo.Add("30sp");
                operationInfo.Add(-9);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToSingle
                operationInfo.Clear();
                operationInfo.Add("30px");
                operationInfo.Add(-15);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();

                // ToDouble
                operationInfo.Clear();
                operationInfo.Add("30dp");
                operationInfo.Add(-16);
                testingTarget = new Tizen.NUI.EXaml.CreateDPObject(globalDataList, operationInfo);
                testingTarget.Do();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlCreateDPObjectDo END (OK)");
        }
    }
}