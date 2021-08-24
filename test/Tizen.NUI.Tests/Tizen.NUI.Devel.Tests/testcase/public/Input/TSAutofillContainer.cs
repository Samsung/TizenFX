using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/TSAutofillContainer")]
    internal class PublicAutofillContainerTest
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

        //[Test]
        //[Category("P1")]
        //[Description("Create a AutofillContainer object.")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.AutofillContainer C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerConstructor()
        //{
        //    tlog.Debug(tag, $"AutofillContainerConstructor START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");
        //    AutofillContainer b1 = new AutofillContainer(a1);

        //    b1.Dispose();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerConstructor END (OK)");
        //    Assert.Pass("AutofillContainerConstructor");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer ServiceEvent")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.ServiceEvent M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerServiceEvent()
        //{
        //    tlog.Debug(tag, $"AutofillContainerServiceEvent START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.ServiceEvent += OnServiceEvent;
        //    a1.ServiceEvent -= OnServiceEvent;
        //    object o1 = new object();
        //    AutofillContainer.AuthenticationEventArgs e = new AutofillContainer.AuthenticationEventArgs();

        //    OnServiceEvent(o1, e);
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerServiceEvent END (OK)");
        //    Assert.Pass("AutofillContainerServiceEvent");
        //}

        //private void OnServiceEvent(object sender, AutofillContainer.AuthenticationEventArgs e)
        //{
        //    AutofillContainer a1 = new AutofillContainer("myContent");
        //    e.AutofillContainer = a1;
        //    a1 = e.AutofillContainer;
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer ListEvent")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.ListEvent M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerListEvent()
        //{
        //    tlog.Debug(tag, $"AutofillContainerListEvent START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.ListEvent += OnListEvent;
        //    a1.ListEvent -= OnListEvent;
        //    object o1 = new object();
        //    AutofillContainer.AuthenticationEventArgs e = new AutofillContainer.AuthenticationEventArgs();

        //    OnServiceEvent(o1, e);
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerServiceEvent END (OK)");
        //    Assert.Pass("AutofillContainerServiceEvent");
        //}

        //private void OnListEvent(object sender, AutofillContainer.ListEventArgs e)
        //{
        //    BaseComponents.View v1 = new BaseComponents.View();
        //    e.Control = v1;
        //    v1 = e.Control;

        //    v1.Dispose();
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer getCPtr")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.getCPtr M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainergetCPtr()
        //{
        //    tlog.Debug(tag, $"AutofillContainergetCPtr START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    global::System.Runtime.InteropServices.HandleRef b1 = AutofillContainer.getCPtr(a1);
        //    global::System.Runtime.InteropServices.HandleRef c1 = AutofillContainer.getCPtr(null);

        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainergetCPtr END (OK)");
        //    Assert.Pass("AutofillContainergetCPtr");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer Assign")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.Assign M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerAssign()
        //{
        //    tlog.Debug(tag, $"AutofillContainerAssign START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");
        //    AutofillContainer b1 = a1;

        //    b1.Dispose();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerAssign END (OK)");
        //    Assert.Pass("AutofillContainerAssign");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer DownCast")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.DownCast M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerDownCast()
        //{
        //    tlog.Debug(tag, $"AutofillContainerDownCast START");
        //    BaseHandle handle = new BaseHandle();
        //    AutofillContainer a1 = AutofillContainer.DownCast(handle);

        //    handle.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerDownCast END (OK)");
        //    Assert.Pass("AutofillContainerDownCast");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer AddAutofillView")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.AddAutofillView M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerAddAutofillView()
        //{
        //    tlog.Debug(tag, $"AutofillContainerAddAutofillView START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    BaseComponents.View view = new BaseComponents.View();
        //    int propertyIndex = 1;
        //    string id = "myContainer";
        //    string label = "testLabel";

        //    AutofillContainer.ItemHint hint = AutofillContainer.ItemHint.CreditCardExpirationData;
        //    bool isSensitive = false;

        //    a1.AddAutofillView(view, propertyIndex, id, label, hint, isSensitive);
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerAddAutofillView END (OK)");
        //    Assert.Pass("AutofillContainerAddAutofillView");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer RemoveAutofillItem")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.RemoveAutofillItem M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerRemoveAutofillItem()
        //{
        //    tlog.Debug(tag, $"AutofillContainerRemoveAutofillItem START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    BaseComponents.View view = new BaseComponents.View();
        //    a1.RemoveAutofillItem(view);
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerRemoveAutofillItem END (OK)");
        //    Assert.Pass("AutofillContainerRemoveAutofillItem");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer SaveAutofillData")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.SaveAutofillData M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerSaveAutofillData()
        //{
        //    tlog.Debug(tag, $"AutofillContainerSaveAutofillData START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.SaveAutofillData();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerSaveAutofillData END (OK)");
        //    Assert.Pass("AutofillContainerSaveAutofillData");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer RequestFillData")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.RequestFillData M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerRequestFillData()
        //{
        //    tlog.Debug(tag, $"AutofillContainerRequestFillData START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.RequestFillData();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerRequestFillData END (OK)");
        //    Assert.Pass("AutofillContainerRequestFillData");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer GetAutofillServiceName")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.GetAutofillServiceName M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerGetAutofillServiceName()
        //{
        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceName START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.GetAutofillServiceName();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceName END (OK)");
        //    Assert.Pass("AutofillContainerGetAutofillServiceName");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer GetAutofillServiceMessage")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.GetAutofillServiceMessage M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerGetAutofillServiceMessage()
        //{
        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceMessage START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.GetAutofillServiceMessage();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceMessage END (OK)");
        //    Assert.Pass("AutofillContainerGetAutofillServiceMessage");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer GetAutofillServiceImagePath")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.GetAutofillServiceImagePath M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerGetAutofillServiceImagePath()
        //{
        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceImagePath START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.GetAutofillServiceImagePath();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerGetAutofillServiceImagePath END (OK)");
        //    Assert.Pass("AutofillContainerGetAutofillServiceImagePath");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer GetListItemCount")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.GetListItemCount M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerGetListItemCount()
        //{
        //    tlog.Debug(tag, $"AutofillContainerGetListItemCount START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.GetListItemCount();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerGetListItemCount END (OK)");
        //    Assert.Pass("AutofillContainerGetListItemCount");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer GetListItem")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.GetListItem M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerGetListItem()
        //{
        //    tlog.Debug(tag, $"AutofillContainerGetListItem START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.GetListItem(0);
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerGetListItem END (OK)");
        //    Assert.Pass("AutofillContainerGetListItem");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer SetSelectedItem")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.SetSelectedItem M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerSetSelectedItem()
        //{
        //    tlog.Debug(tag, $"AutofillContainerSetSelectedItem START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.SetSelectedItem("testContent");
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerSetSelectedItem END (OK)");
        //    Assert.Pass("AutofillContainerSetSelectedItem");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer AutofillServiceEventSignal")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.AutofillServiceEventSignal M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerAutofillServiceEventSignal()
        //{
        //    tlog.Debug(tag, $"AutofillContainerAutofillServiceEventSignal START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.AutofillServiceEventSignal();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerAutofillServiceEventSignal END (OK)");
        //    Assert.Pass("AutofillContainerAutofillServiceEventSignal");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("AutofillContainer AutofillListEventSignal")]
        //[Property("SPEC", "Tizen.NUI.AutofillContainer.AutofillListEventSignal M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AutofillContainerAutofillListEventSignal()
        //{
        //    tlog.Debug(tag, $"AutofillContainerAutofillListEventSignal START");
        //    AutofillContainer a1 = new AutofillContainer("myContainer");

        //    a1.AutofillListEventSignal();
        //    a1.Dispose();

        //    tlog.Debug(tag, $"AutofillContainerAutofillListEventSignal END (OK)");
        //    Assert.Pass("AutofillContainerAutofillListEventSignal");
        //}
    }
}