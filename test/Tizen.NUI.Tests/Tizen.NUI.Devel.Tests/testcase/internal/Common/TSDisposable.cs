using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Disposable")]
    public class DisposableTests
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(tag, " Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(tag, " Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Disposable object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.Disposable.Disposable C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Disposable_INIT()
        {
            tlog.Debug(tag, $"DisposableConstructor START");
			
            var disposable = new Disposable();
            Assert.IsNotNull(disposable, "Can't create success object Disposable");
            Assert.IsInstanceOf<Disposable>(disposable, "Should be an instance of Disposable type.");
			
			tlog.Debug(tag, $"DisposableConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Disposable.")]
        [Property("SPEC", "Tizen.NUI.Disposable.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Dispose_TEST()
        {
            tlog.Debug(tag, $"DisposableWithDisposable START");
			
            try
            {
                Disposable disposable = new Disposable();
                disposable.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
			
			tlog.Debug(tag, $"DisposableWithDisposable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Disposable.")]
        [Property("SPEC", "Tizen.NUI.Disposable.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "DisposeTypes")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Dispose_Implicit_TEST_WITH_DISPOSETYPE()
        {
            tlog.Debug(tag, $"DisposableImplicit START");
			
            try
            {
                MyDisposable myDisposable = new MyDisposable();
                myDisposable.DisposeImplicit();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
			
			tlog.Debug(tag, $"DisposableImplicit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Disposable.")]
        [Property("SPEC", "Tizen.NUI.Disposable.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "DisposeTypes")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Dispose_Explicit_TEST_WITH_DISPOSETYPE()
        {
            tlog.Debug(tag, $"DisposableExplicit START");
			
            try
            {
                MyDisposable myDisposable = new MyDisposable();
                myDisposable.DisposeExplicit();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
			
			tlog.Debug(tag, $"DisposableExplicit END (OK)");
        }
    }

    public class MyDisposable : Disposable
    {
        public void DisposeImplicit()
        {
            Dispose(DisposeTypes.Implicit);
        }

        public void DisposeExplicit()
        {
            Dispose(DisposeTypes.Explicit);
        }

        public bool Disposed
        {
            get
            {
                return disposed;
            }
            set
            {
                disposed = value;
            }
        }
    }
}
