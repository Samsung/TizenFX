using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/BaseObject")]
    public class InternalBaseObjectTest
    {
        private const string tag = "NUITEST";
        private Widget widget = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            widget = new Widget();
            tlog.Debug(tag, "widget.Id : " + widget.Id);
        }

        [TearDown]
        public void Destroy()
        {
            widget.Dispose();
            widget = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("BaseObject constructor.")]
        [Property("SPEC", "Tizen.NUI.BaseObject.BaseObject C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseObjectConstructor()
        {
            tlog.Debug(tag, $"BaseObjectConstructor START");

            var testingTarget = new BaseObject(widget.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<BaseObject>(testingTarget, "should be an instance of BaseObject class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseObjectConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("BaseObject DoAction.")]
        //[Property("SPEC", "Tizen.NUI.BaseObject.DoAction M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void BaseObjectDoAction()
        //{
        //    tlog.Debug(tag, $"BaseObjectDoAction START");

        //    var testingTarget = new BaseObject(widget.SwigCPtr.Handle, false);
        //    Assert.IsNotNull(testingTarget, "should not be null.");
        //    Assert.IsInstanceOf<BaseObject>(testingTarget, "should be an instance of BaseObject class!");

        //    using (PropertyMap map = new PropertyMap())
        //    {
        //        map.Insert("ContentInfo", new PropertyValue("widget"));
        //        var result = testingTarget.DoAction("set", map);
        //        tlog.Debug(tag, "DoAction : " + result);
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"BaseObjectDoAction END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("BaseObject GetTypeName.")]
        //[Property("SPEC", "Tizen.NUI.BaseObject.GetTypeName M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void BaseObjectGetTypeName()
        //{
        //    tlog.Debug(tag, $"BaseObjectGetTypeName START");

        //    var testingTarget = new BaseObject(widget.SwigCPtr.Handle, false);
        //    Assert.IsNotNull(testingTarget, "should not be null.");
        //    Assert.IsInstanceOf<BaseObject>(testingTarget, "should be an instance of BaseObject class!");

        //    var result = testingTarget.GetTypeName();
        //    tlog.Debug(tag, "TypeName : " + result);

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"BaseObjectGetTypeName END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("BaseObject GetTypeInfo.")]
        //[Property("SPEC", "Tizen.NUI.BaseObject.GetTypeInfo M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void BaseObjectGetTypeInfo()
        //{
        //    tlog.Debug(tag, $"BaseObjectGetTypeInfo START");

        //    var testingTarget = new BaseObject(widget.SwigCPtr.Handle, false);
        //    Assert.IsNotNull(testingTarget, "should not be null.");
        //    Assert.IsInstanceOf<BaseObject>(testingTarget, "should be an instance of BaseObject class!");

        //    using (TypeInfo info = new TypeInfo(widget.SwigCPtr.Handle, false))
        //    {
        //        var result = testingTarget.GetTypeInfo(info);
        //        tlog.Debug(tag, "TypeName : " + result);
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"BaseObjectGetTypeInfo END (OK)");
        //}
    }
}
