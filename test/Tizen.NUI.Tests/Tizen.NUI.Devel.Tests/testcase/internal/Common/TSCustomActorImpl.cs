using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/CustomActorImpl")]
    public class InternalCustomActorImplTest
    {
        private const string tag = "NUITEST";
        private View actor = null;

        internal class MyCustomActorImpl : CustomActorImpl
        {
            public MyCustomActorImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { 
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            actor = new View() { Size = new Size(100, 200) };
        }

        [TearDown]
        public void Destroy()
        {
            actor.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.CustomActorImpl C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplConstructor()
        {
            tlog.Debug(tag, $"CustomActorImplConstructor START");

            var testingTarget = new CustomActorImpl(actor.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActorImplConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl IsRelayoutEnabled.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.IsRelayoutEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplIsRelayoutEnabled()
        {
            tlog.Debug(tag, $"CustomActorImplIsRelayoutEnabled START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                var result = testingTarget.IsRelayoutEnabled();
                tlog.Debug(tag, "IsRelayoutEnabled : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplIsRelayoutEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl RelayoutDependentOnChildren.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.RelayoutDependentOnChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplRelayoutDependentOnChildren()
        {
            tlog.Debug(tag, $"CustomActorImplRelayoutDependentOnChildren START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                var result = testingTarget.RelayoutDependentOnChildren();
                tlog.Debug(tag, "RelayoutDependentOnChildren : " + result);

                result = testingTarget.RelayoutDependentOnChildren(DimensionType.Height);
                tlog.Debug(tag, "RelayoutDependentOnChildren : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplRelayoutDependentOnChildren END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("CustomActorImpl Self.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.Self M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplSelf()
        {
            tlog.Debug(tag, $"CustomActorImplSelf START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view).Self();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplSelf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnSceneConnection.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnSceneConnection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnSceneConnection()
        {
            tlog.Debug(tag, $"CustomActorImplOnSceneConnection START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    testingTarget.OnSceneConnection(1);
                    testingTarget.OnSceneDisconnection();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnSceneConnection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnChildAdd.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnChildAdd M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnChildAdd()
        {
            tlog.Debug(tag, $"CustomActorImplOnChildAdd START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                using (View child = new View())
                {
                    try
                    {
                        testingTarget.OnChildAdd(child);
                        
                        var result = testingTarget.CalculateChildSize(child, DimensionType.Width);
                        tlog.Debug(tag, "CalculateChildSize : " + result);

                        testingTarget.OnChildRemove(child);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnChildAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnPropertySet.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnPropertySet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnPropertySet()
        {
            tlog.Debug(tag, $"CustomActorImplOnPropertySet START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {

                    testingTarget.OnPropertySet(View.Property.OPACITY, new PropertyValue(0.3f));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnPropertySet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnLayoutNegotiated.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnLayoutNegotiated M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnLayoutNegotiated()
        {
            tlog.Debug(tag, $"CustomActorImplOnLayoutNegotiated START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    testingTarget.OnLayoutNegotiated(100.0f, DimensionType.Width);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnLayoutNegotiated END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnSetResizePolicy.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnSetResizePolicy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnSetResizePolicy()
        {
            tlog.Debug(tag, $"CustomActorImplOnSetResizePolicy START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    testingTarget.OnSetResizePolicy(ResizePolicyType.Fixed, DimensionType.Width);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnSetResizePolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnCalculateRelayoutSize.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnCalculateRelayoutSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnCalculateRelayoutSize()
        {
            tlog.Debug(tag, $"CustomActorImplOnCalculateRelayoutSize START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    testingTarget.OnCalculateRelayoutSize(DimensionType.AllDimensions);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnCalculateRelayoutSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl GetHeightForWidth.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.GetHeightForWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplGetHeightForWidth()
        {
            tlog.Debug(tag, $"CustomActorImplGetHeightForWidth START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                var size = testingTarget.GetNaturalSize();
                Assert.IsInstanceOf<Vector3>(size, "Should be an Instance of Vector3!");

                var result = testingTarget.GetHeightForWidth(100.0f);
                tlog.Debug(tag, "GetHeightForWidth : " + result);

                result = testingTarget.GetWidthForHeight(50.0f);
                tlog.Debug(tag, "GetWidthForHeight : " + result);
      
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplGetHeightForWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnSizeAnimation.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnSizeAnimation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnSizeAnimation()
        {
            tlog.Debug(tag, $"CustomActorImplOnSizeAnimation START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    using (Animation ani = new Animation(300))
                    {
                        using (Vector3 vector = new Vector3(100.0f, 20.0f, 80.0f))
                        {
                            testingTarget.OnSizeAnimation(ani, vector);
                        }
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnSizeAnimation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnSizeSet.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnSizeSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnSizeSet()
        {
            tlog.Debug(tag, $"CustomActorImplOnSizeSet START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                try
                {
                    using (Vector3 vector = new Vector3(100.0f, 20.0f, 80.0f))
                    {
                        testingTarget.OnSizeSet(vector);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnSizeSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplOnRelayout()
        {
            tlog.Debug(tag, $"CustomActorImplOnRelayout START");

            using (View view = new View())
            {
                var testingTarget = NDalic.GetImplementation(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                using (Vector2 vector = new Vector2(100.0f, 20.0f))
                {
                    using (RelayoutContainer container = new RelayoutContainer(view.SwigCPtr.Handle, false))
                    {
                        try
                        {
                            testingTarget.OnRelayout(vector, container);
                        }
                        catch (Exception e)
                        {
                            tlog.Debug(tag, e.Message.ToString());
                            Assert.Fail("Caught Exception : Failed!");
                        }
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplOnRelayout END (OK)");
        }
    }
}
