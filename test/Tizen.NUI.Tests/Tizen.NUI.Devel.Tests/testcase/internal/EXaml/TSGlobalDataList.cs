using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/EXaml/GlobalDataList")]
    public class InternalGlobalDataListTest
    {
        private const string tag = "NUITEST";

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
        [Description("GlobalDataList constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GlobalDataList.RootAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGlobalDataListConstructor()
        {
            tlog.Debug(tag, $"EXamlGlobalDataListConstructor START");

            try
            {
                var testingTarget = new Tizen.NUI.EXaml.GlobalDataList();
                Assert.IsNotNull(testingTarget, "Can't create success object RootAction");
                Assert.IsInstanceOf<Tizen.NUI.EXaml.GlobalDataList>(testingTarget, "Should be an instance of RootAction type.");

                var result = testingTarget.Root;
                tlog.Debug(tag, "Root : " + result);

                var result1 = testingTarget.PreLoadOperations;
                tlog.Debug(tag, "PreLoadOperations : " + result1);

                var result2 = testingTarget.Operations;
                tlog.Debug(tag, "Operations : " + result2);

                var result3 = testingTarget.RemoveEventOperations;
                tlog.Debug(tag, "RemoveEventOperations : " + result3);

                var result4 = testingTarget.GatheredInstances;
                tlog.Debug(tag, "GatheredInstances : " + result4);

                var result5 = testingTarget.ObjectsFromProperty;
                tlog.Debug(tag, "ObjectsFromProperty : " + result5);

                var result6 = testingTarget.GatheredEvents;
                tlog.Debug(tag, "GatheredEvents : " + result6);

                var result7 = testingTarget.GatheredMethods;
                tlog.Debug(tag, "GatheredMethods : " + result7);

                var result8 = testingTarget.GatheredTypes;
                tlog.Debug(tag, "GatheredTypes : " + result8);

                //var result9 = testingTarget.AssemblyNameList;
                //tlog.Debug(tag, "AssemblyNameList : " + result9);
            }
            catch (Exception e)
            {
                tlog.Info(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlGlobalDataListConstructor END (OK)");
        }
    }
}
