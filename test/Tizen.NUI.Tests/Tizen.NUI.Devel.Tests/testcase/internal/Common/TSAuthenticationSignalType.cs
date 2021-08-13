using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/AuthenticationSignalType")]
    public class InternalAuthenticationSignalTypeTest
    {
        private const string tag = "NUITEST";
		
		private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
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
		
  //      [Test]
  //      [Category("P1")]
  //      [Description("AuthenticationSignalType constructor.")]
  //      [Property("SPEC", "Tizen.NUI.AuthenticationSignalType.AuthenticationSignalType C")]
  //      [Property("SPEC_URL", "-")]
  //      [Property("CRITERIA", "CONSTR")]
  //      [Property("AUTHOR", "guowei.wang@samsung.com")]
  //      public void AuthenticationSignalTypeConstructor()
  //      {
  //          tlog.Debug(tag, $"AuthenticationSignalTypeConstructor START");

  //          using (View view = new View())
  //          {
  //              var testingTarget = new AuthenticationSignalType(view.SwigCPtr.Handle, false);
  //              Assert.IsNotNull(testingTarget, "Should be not null!");
  //              Assert.IsInstanceOf<AuthenticationSignalType>(testingTarget, "Should be an Instance of AuthenticationSignalType!");

  //              testingTarget.Dispose();
  //          }

  //          tlog.Debug(tag, $"AuthenticationSignalTypeConstructor END (OK)");
  //      }

  //      [Test]
  //      [Category("P1")]
  //      [Description("AuthenticationSignalType Empty.")]
  //      [Property("SPEC", "Tizen.NUI.AuthenticationSignalType.Empty M")]
  //      [Property("SPEC_URL", "-")]
  //      [Property("CRITERIA", "MR")]
  //      [Property("AUTHOR", "guowei.wang@samsung.com")]
  //      public void AuthenticationSignalTypeEmpty()
  //      {
  //          tlog.Debug(tag, $"AuthenticationSignalTypeEmpty START");

  //          var testingTarget = new AuthenticationSignalType();
  //          Assert.IsNotNull(testingTarget, "Should be not null!");
  //          Assert.IsInstanceOf<AuthenticationSignalType>(testingTarget, "Should be an Instance of AuthenticationSignalType!");

  //          try
  //          {
  //              testingTarget.Empty();
  //          }
  //          catch (Exception e)
  //          {
  //              tlog.Debug(tag, e.Message.ToString());
  //              Assert.Fail("Caught Exception: Failed!");
  //          }

  //          testingTarget.Dispose();

  //          tlog.Debug(tag, $"AuthenticationSignalTypeEmpty END (OK)");
  //      }

  //      [Test]
  //      [Category("P1")]
  //      [Description("AuthenticationSignalType GetConnectionCount.")]
  //      [Property("SPEC", "Tizen.NUI.AuthenticationSignalType.GetConnectionCount M")]
  //      [Property("SPEC_URL", "-")]
  //      [Property("CRITERIA", "MR")]
  //      [Property("AUTHOR", "guowei.wang@samsung.com")]
  //      public void AuthenticationSignalTypeGetConnectionCount()
  //      {
  //          tlog.Debug(tag, $"AuthenticationSignalTypeGetConnectionCount START");

  //          var testingTarget = new AuthenticationSignalType();
  //          Assert.IsNotNull(testingTarget, "Should be not null!");
  //          Assert.IsInstanceOf<AuthenticationSignalType>(testingTarget, "Should be an Instance of AuthenticationSignalType!");

  //          try
  //          {
  //              testingTarget.GetConnectionCount();
  //          }
  //          catch (Exception e)
  //          {
  //              tlog.Debug(tag, e.Message.ToString());
  //              Assert.Fail("Caught Exception: Failed!");
  //          }

  //          testingTarget.Dispose();

  //          tlog.Debug(tag, $"AuthenticationSignalTypeGetConnectionCount END (OK)");
  //      }

  //      [Test]
  //      [Category("P1")]
  //      [Description("AuthenticationSignalType Connect.")]
  //      [Property("SPEC", "Tizen.NUI.AuthenticationSignalType.Connect M")]
  //      [Property("SPEC_URL", "-")]
  //      [Property("CRITERIA", "MR")]
  //      [Property("AUTHOR", "guowei.wang@samsung.com")]
  //      public void AuthenticationSignalTypeConnect()
  //      {
  //          tlog.Debug(tag, $"AuthenticationSignalTypeConnect START");

  //          var testingTarget = new AuthenticationSignalType();
  //          Assert.IsNotNull(testingTarget, "Should be not null!");
  //          Assert.IsInstanceOf<AuthenticationSignalType>(testingTarget, "Should be an Instance of AuthenticationSignalType!");

  //          try
  //          {
  //              dummyCallback callback = OnDummyCallback;
  //              testingTarget.Connect(callback);
  //              testingTarget.Disconnect(callback);
  //          }
  //          catch (Exception e)
  //          {
  //              tlog.Debug(tag, e.Message.ToString());
  //              Assert.Fail("Caught Exception: Failed!");
  //          }

  //          testingTarget.Dispose();

  //          tlog.Debug(tag, $"AuthenticationSignalTypeConnect END (OK)");
  //      }

  //      [Test]
  //      [Category("P1")]
  //      [Description("AuthenticationSignalType Emit.")]
  //      [Property("SPEC", "Tizen.NUI.AuthenticationSignalType.Emit M")]
  //      [Property("SPEC_URL", "-")]
  //      [Property("CRITERIA", "MR")]
  //      [Property("AUTHOR", "guowei.wang@samsung.com")]
  //      [Obsolete]
  //      public void AuthenticationSignalTypeEmit()
  //      {
  //          tlog.Debug(tag, $"AuthenticationSignalTypeEmit START");
  //          var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
  //          var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

  //          tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

  //          var testingTarget = new AuthenticationSignalType();
  //          Assert.IsNotNull(testingTarget, "Should be not null!");
  //          Assert.IsInstanceOf<AuthenticationSignalType>(testingTarget, "Should be an Instance of AuthenticationSignalType!");

  //          try
  //          {
  //              using (AutofillContainer container = new AutofillContainer("container"))
  //              {
  //                  testingTarget.Emit(container);
  //              }
  //          }
  //          catch (Exception e)
  //          {
  //              tlog.Debug(tag, e.Message.ToString());
  //              Assert.Fail("Caught Exception: Failed!");
  //          }

  //          testingTarget.Dispose();

  //          tlog.Debug(tag, $"AuthenticationSignalTypeEmit END (OK)");
  //      }
    }
}
