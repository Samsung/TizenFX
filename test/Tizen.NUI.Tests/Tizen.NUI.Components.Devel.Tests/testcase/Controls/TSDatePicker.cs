using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/DatePicker")]
    public class DatePickerTest
    {
        private const string tag = "NUITEST";

        internal class MyDatePicker : DatePicker
        {
            public MyDatePicker() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public override void OnInitialize()
            {
                base.OnInitialize();
            }

            public override void ApplyStyle(ViewStyle viewStyle)
            {
                base.ApplyStyle(viewStyle);
            }
        }

        internal class MyDatePickerStyle : DatePickerStyle
        {
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

        //[Test]
        //[Category("P1")]
        //[Description("DatePicker constructor.")]
        //[Property("SPEC", "Tizen.NUI.Components.DatePicker.constructor C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void DatePickerConstructor()
        //{
        //    tlog.Debug(tag, $"DatePickerConstructor START");

        //    var testingTarget = new MyDatePicker();
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

        //    try
        //    {
        //        testingTarget.OnDispose(DisposeTypes.Explicit);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"DatePickerConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("DatePicker OnInitialize.")]
        //[Property("SPEC", "Tizen.NUI.Components.DatePicker.OnInitialize M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void DatePickerOnInitialize()
        //{
        //    tlog.Debug(tag, $"DatePickerOnInitialize START");

        //    var testingTarget = new MyDatePicker();
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

        //    try
        //    {
        //        testingTarget.OnInitialize();
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"DatePickerOnInitialize END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("DatePicker ApplyStyle.")]
        //[Property("SPEC", "Tizen.NUI.Components.DatePicker.ApplyStyle M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void DatePickerApplyStyle()
        //{
        //    tlog.Debug(tag, $"DatePickerApplyStyle START");

        //    var testingTarget = new MyDatePicker();
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<DatePicker>(testingTarget, "Should return DatePicker instance.");

        //    try
        //    {
        //        ViewStyle style = new ViewStyle()
        //        {
        //            Size = new Size(30, 200)
        //        };
        //        testingTarget.ApplyStyle(style);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"DatePickerApplyStyle END (OK)");
        //}
    }
}
