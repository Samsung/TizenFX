using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Ruler")]
    public class InternalRulerTest
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
        [Description("Ruler constructor.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Ruler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerConstructor()
        {
            tlog.Debug(tag, $"RulerConstructor START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Snap. With bias.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Snap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapWithBias()
        {
            tlog.Debug(tag, $"RulerSnapWithBias START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.Snap(15.0f, 2.0f);
                    tlog.Debug(tag, "Snap : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnapWithBias END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Snap.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Snap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnap()
        {
            tlog.Debug(tag, $"RulerSnap START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.Snap(15.0f);
                tlog.Debug(tag, "Snap : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler GetPositionFromPage.")]
        [Property("SPEC", "Tizen.NUI.Ruler.GetPositionFromPage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerGetPositionFromPage()
        {
            tlog.Debug(tag, $"RulerGetPositionFromPage START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.GetPositionFromPage(1, out uint vloume, true);
                tlog.Debug(tag, "Position : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerGetPositionFromPage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler GetPageFromPosition.")]
        [Property("SPEC", "Tizen.NUI.Ruler.GetPageFromPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerGetPageFromPosition()
        {
            tlog.Debug(tag, $"RulerGetPageFromPosition START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.GetPageFromPosition(15.0f, true);
                tlog.Debug(tag, "Position : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerGetPageFromPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler GetTotalPages.")]
        [Property("SPEC", "Tizen.NUI.Ruler.GetTotalPages M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerGetTotalPages()
        {
            tlog.Debug(tag, $"RulerGetTotalPages START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.GetTotalPages();
                tlog.Debug(tag, "Position : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerGetTotalPages END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler GetType.")]
        [Property("SPEC", "Tizen.NUI.Ruler.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerGetType()
        {
            tlog.Debug(tag, $"RulerGetType START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.GetType();
                tlog.Debug(tag, "Type : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler IsEnabled.")]
        [Property("SPEC", "Tizen.NUI.Ruler.IsEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerIsEnabled()
        {
            tlog.Debug(tag, $"RulerIsEnabled START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                var result = testingTarget.IsEnabled();
                tlog.Debug(tag, "Type : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerIsEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Enable.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Enable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerEnable()
        {
            tlog.Debug(tag, $"RulerEnable START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    testingTarget.Enable();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerEnable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Disable.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Disable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDisable()
        {
            tlog.Debug(tag, $"RulerDisable START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    testingTarget.Disable();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerDisable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SetDomain.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SetDomain M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSetDomain()
        {
            tlog.Debug(tag, $"RulerSetDomain START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    using (RulerDomain domain = new RulerDomain(0, 100, true))
                    {
                        testingTarget.SetDomain(domain);
                        var result = testingTarget.GetDomain();
                        tlog.Debug(tag, "Domain : " + result);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSetDomain END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler DisableDomain.")]
        [Property("SPEC", "Tizen.NUI.Ruler.DisableDomain M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerDisableDomain()
        {
            tlog.Debug(tag, $"RulerDisableDomain START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    testingTarget.DisableDomain();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerDisableDomain END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Clamp.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerClamp()
        {
            tlog.Debug(tag, $"RulerClamp START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.Clamp(10.0f);
                    tlog.Debug(tag, "Clamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerClamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Clamp. With length.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerClampWithLenght()
        {
            tlog.Debug(tag, $"RulerClampWithLenght START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.Clamp(10.0f, 50.0f);
                    tlog.Debug(tag, "Clamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerClampWithLenght END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Clamp. With scale.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerClampWithScale()
        {
            tlog.Debug(tag, $"RulerClampWithScale START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.Clamp(10.0f, 50.0f, 40.0f);
                    tlog.Debug(tag, "Clamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerClampWithScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler Clamp. With ClampState.")]
        [Property("SPEC", "Tizen.NUI.Ruler.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerClampWithClampState()
        {
            tlog.Debug(tag, $"RulerClampWithClampState START");

            DefaultRuler ruler = new DefaultRuler();
            var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
            Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

            var result = testingTarget.Clamp(10.0f, 50.0f, 40.0f, new SWIGTYPE_p_Dali__Toolkit__ClampState(ruler.SwigCPtr.Handle));
            tlog.Debug(tag, "Clamp : " + result);

            ruler.Disable();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerClampWithClampState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SnapAndClamp.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SnapAndClamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapAndClamp()
        {
            tlog.Debug(tag, $"RulerSnapAndClamp START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.SnapAndClamp(10.0f);
                    tlog.Debug(tag, "SnapAndClamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnapAndClamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SnapAndClamp. With bias.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SnapAndClamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapAndClampWithBias()
        {
            tlog.Debug(tag, $"RulerSnapAndClampWithBias START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.SnapAndClamp(10.0f, 50.0f);
                    tlog.Debug(tag, "SnapAndClamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnapAndClampWithBias END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SnapAndClamp. With length.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SnapAndClamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapAndClampWithLength()
        {
            tlog.Debug(tag, $"RulerSnapAndClampWithLength START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.SnapAndClamp(10.0f, 50.0f, 100.0f);
                    tlog.Debug(tag, "SnapAndClamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnapAndClampWithLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SnapAndClamp. With scale.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SnapAndClamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapAndClampWithScale()
        {
            tlog.Debug(tag, $"RulerSnapAndClampWithScale START");

            using (DefaultRuler ruler = new DefaultRuler())
            {
                var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
                Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

                try
                {
                    var result = testingTarget.SnapAndClamp(10.0f, 50.0f, 100.0f, 200.0f);
                    tlog.Debug(tag, "SnapAndClamp : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RulerSnapAndClampWithScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Ruler SnapAndClamp. With ClampState.")]
        [Property("SPEC", "Tizen.NUI.Ruler.SnapAndClamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RulerSnapAndClampWithClampState()
        {
            tlog.Debug(tag, $"RulerSnapAndClampWithClampState START");

            DefaultRuler ruler = new DefaultRuler();
            var testingTarget = new Ruler(ruler.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object Ruler.");
            Assert.IsInstanceOf<Ruler>(testingTarget, "Should return Ruler instance.");

            try
            {
                var result = testingTarget.SnapAndClamp(10.0f, 50.0f, 100.0f, 200.0f, new SWIGTYPE_p_Dali__Toolkit__ClampState(ruler.SwigCPtr.Handle));
                tlog.Debug(tag, "SnapAndClamp : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            ruler.Disable();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RulerSnapAndClampWithClampState END (OK)");
        }
    }
}
