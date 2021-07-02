using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/Camera")]
    public class InternalCameraTest
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
        [Description("Camera constructor.")]
        [Property("SPEC", "Tizen.NUI.Camera.Camera C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraConstructor()
        {
            tlog.Debug(tag, $"CameraConstructor START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera constructor. With Vector2.")]
        [Property("SPEC", "Tizen.NUI.Camera.Camera C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraConstructorWithVector2()
        {
            tlog.Debug(tag, $"CameraConstructorWithVector2 START");

            using (Vector2 size = new Vector2(50, 80))
            {
                var testingTarget = new Camera(size);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CameraConstructorWithVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera constructor. With Camera.")]
        [Property("SPEC", "Tizen.NUI.Camera.Camera C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraConstructorWithCamera()
        {
            tlog.Debug(tag, $"CameraConstructorWithCamera START");

            using (Camera camera = new Camera())
            {
                var testingTarget = new Camera(camera);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CameraConstructorWithCamera END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera DownCast.")]
        [Property("SPEC", "Tizen.NUI.Camera.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraDownCast()
        {
            tlog.Debug(tag, $"CameraDownCast START");

            using (Camera camera = new Camera())
            {
                var testingTarget = Camera.DownCast(camera);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CameraDownCast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Camera DownCast. With null.")]
        [Property("SPEC", "Tizen.NUI.Camera.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraDownCastWithNull()
        {
            tlog.Debug(tag, $"CameraDownCastWithNull START");

            try
            {
                var testingTarget = Camera.DownCast(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"CameraDownCastWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Camera Assign.")]
        [Property("SPEC", "Tizen.NUI.Camera.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraAssign()
        {
            tlog.Debug(tag, $"CameraAssign START");

            using (Camera camera = new Camera())
            {
                var testingTarget = camera.Assign(camera);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CameraAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetType.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetType()
        {
            tlog.Debug(tag, $"CameraSetType START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetType(Tizen.NUI.CameraType.FreeLook);
            Assert.AreEqual(Tizen.NUI.CameraType.FreeLook, testingTarget.GetType(), "Should be equal!");

            testingTarget.SetType(Tizen.NUI.CameraType.LookAtTarget);
            Assert.AreEqual(Tizen.NUI.CameraType.LookAtTarget, testingTarget.GetType(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetProjectionMode.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetProjectionMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetProjectionMode()
        {
            tlog.Debug(tag, $"CameraSetProjectionMode START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetProjectionMode(ProjectionMode.OrthographicProjection);
            Assert.AreEqual(ProjectionMode.OrthographicProjection, testingTarget.GetProjectionMode(), "Should be equal!");

            testingTarget.SetProjectionMode(ProjectionMode.PerspectiveProjection);
            Assert.AreEqual(ProjectionMode.PerspectiveProjection, testingTarget.GetProjectionMode(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetProjectionMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetFieldOfView.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetFieldOfView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void CameraSetFieldOfView()
        {
            tlog.Debug(tag, $"CameraSetFieldOfView START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetFieldOfView(0.5f);
            Assert.AreEqual(0.5f, testingTarget.GetFieldOfView(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetFieldOfView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetAspectRatio.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetAspectRatio M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void CameraSetAspectRatio()
        {
            tlog.Debug(tag, $"CameraSetAspectRatio START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetAspectRatio(0.5f);
            Assert.AreEqual(0.5f, testingTarget.GetAspectRatio(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetAspectRatio END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetNearClippingPlane.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetNearClippingPlane M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetNearClippingPlane()
        {
            tlog.Debug(tag, $"CameraSetNearClippingPlane START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetNearClippingPlane(0.5f);
            Assert.AreEqual(0.5f, testingTarget.GetNearClippingPlane(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetNearClippingPlane END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetFarClippingPlane.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetFarClippingPlane M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetFarClippingPlane()
        {
            tlog.Debug(tag, $"CameraSetFarClippingPlane START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetFarClippingPlane(0.5f);
            Assert.AreEqual(0.5f, testingTarget.GetFarClippingPlane(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetFarClippingPlane END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetTargetPosition.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetTargetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void CameraSetTargetPosition()
        {
            tlog.Debug(tag, $"CameraSetTargetPosition START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            using (Vector3 position = new Vector3(0.3f, 0.8f, 0.0f))
            {
                testingTarget.SetTargetPosition(position);

                var result = testingTarget.GetTargetPosition();
                Assert.AreEqual(0.3f, result.X, "Should be equal!");
                Assert.AreEqual(0.8f, result.Y, "Should be equal!");
                Assert.AreEqual(0.0f, result.Z, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetTargetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera GetInvertYAxis.")]
        [Property("SPEC", "Tizen.NUI.Camera.GetInvertYAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void CameraGetInvertYAxis()
        {
            tlog.Debug(tag, $"CameraGetInvertYAxis START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.SetInvertYAxis(true);
            Assert.AreEqual(true, testingTarget.GetInvertYAxis(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraGetInvertYAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetPerspectiveProjection.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetPerspectiveProjection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetPerspectiveProjection()
        {
            tlog.Debug(tag, $"CameraSetPerspectiveProjection START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            using (Vector2 size = new Vector2(80, 50))
            {
                try
                {
                    testingTarget.SetPerspectiveProjection(size);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetPerspectiveProjection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetOrthographicProjection.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetOrthographicProjection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetOrthographicProjection()
        {
            tlog.Debug(tag, $"CameraSetOrthographicProjection START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            using (Vector2 size = new Vector2(80, 50))
            {
                try
                {
                    testingTarget.SetOrthographicProjection(size);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetOrthographicProjection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera SetOrthographicProjection. With Float.")]
        [Property("SPEC", "Tizen.NUI.Camera.SetOrthographicProjection M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraSetOrthographicProjectionWithFloat()
        {
            tlog.Debug(tag, $"CameraSetOrthographicProjectionWithFloat START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            try
            {
                testingTarget.SetOrthographicProjection(0.3f, 0.0f, 0.5f, 0.2f, 0.3f, 1.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraSetOrthographicProjectionWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera Type.")]
        [Property("SPEC", "Tizen.NUI.Camera.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraType()
        {
            tlog.Debug(tag, $"CameraType START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.Type = "FreeLook";
            Assert.AreEqual("FREE_LOOK", testingTarget.Type, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera ProjectionMode.")]
        [Property("SPEC", "Tizen.NUI.Camera.ProjectionMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraProjectionMode()
        {
            tlog.Debug(tag, $"CameraProjectionMode START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.ProjectionMode = "PerspectiveProjection";
            Assert.AreEqual("PERSPECTIVE_PROJECTION", testingTarget.ProjectionMode, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraProjectionMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera FieldOfView.")]
        [Property("SPEC", "Tizen.NUI.Camera.FieldOfView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraFieldOfView()
        {
            tlog.Debug(tag, $"CameraFieldOfView START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.FieldOfView = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.FieldOfView, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraFieldOfView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera AspectRatio.")]
        [Property("SPEC", "Tizen.NUI.Camera.AspectRatio A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraAspectRatio()
        {
            tlog.Debug(tag, $"CameraAspectRatio START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.AspectRatio = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.AspectRatio, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraAspectRatio END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera NearPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.NearPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraNearPlaneDistance()
        {
            tlog.Debug(tag, $"CameraNearPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.NearPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.NearPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraNearPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera FarPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.FarPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraFarPlaneDistance()
        {
            tlog.Debug(tag, $"CameraFarPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.FarPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.FarPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraFarPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera LeftPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.LeftPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraLeftPlaneDistance()
        {
            tlog.Debug(tag, $"CameraLeftPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.LeftPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.LeftPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraLeftPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera RightPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.RightPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraRightPlaneDistance()
        {
            tlog.Debug(tag, $"CameraRightPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.RightPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.RightPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraRightPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera TopPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.TopPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraTopPlaneDistance()
        {
            tlog.Debug(tag, $"CameraTopPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.TopPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.TopPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraTopPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera BottomPlaneDistance.")]
        [Property("SPEC", "Tizen.NUI.Camera.BottomPlaneDistance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraBottomPlaneDistance()
        {
            tlog.Debug(tag, $"CameraBottomPlaneDistance START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.BottomPlaneDistance = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.BottomPlaneDistance, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraBottomPlaneDistance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera TargetPosition.")]
        [Property("SPEC", "Tizen.NUI.Camera.TargetPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraTargetPosition()
        {
            tlog.Debug(tag, $"CameraTargetPosition START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.TargetPosition = new Vector3(0.3f, 0.5f, 0.0f);
            Assert.AreEqual(0.3f, testingTarget.TargetPosition.X, "Should be equal!");
            Assert.AreEqual(0.5f, testingTarget.TargetPosition.Y, "Should be equal!");
            Assert.AreEqual(0.0f, testingTarget.TargetPosition.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraTargetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera ProjectionMatrix.")]
        [Property("SPEC", "Tizen.NUI.Camera.ProjectionMatrix A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraProjectionMatrix()
        {
            tlog.Debug(tag, $"CameraProjectionMatrix START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            var result = testingTarget.ProjectionMatrix;
            Assert.AreEqual(1, result.GetXAxis().X, "Should be equal!");
            Assert.AreEqual(0, result.GetXAxis().Y, "Should be equal!");
            Assert.AreEqual(0, result.GetXAxis().Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraProjectionMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera ViewMatrix.")]
        [Property("SPEC", "Tizen.NUI.Camera.ViewMatrix A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraViewMatrix()
        {
            tlog.Debug(tag, $"CameraViewMatrix START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            var result = testingTarget.ViewMatrix;
            Assert.AreEqual(1, result.GetXAxis().X, "Should be equal!");
            Assert.AreEqual(0, result.GetXAxis().Y, "Should be equal!");
            Assert.AreEqual(0, result.GetXAxis().Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraViewMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Camera InvertYAxis.")]
        [Property("SPEC", "Tizen.NUI.Camera.InvertYAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CameraInvertYAxis()
        {
            tlog.Debug(tag, $"CameraInvertYAxis START");

            var testingTarget = new Camera();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Camera>(testingTarget, "Should be an Instance of Camera!");

            testingTarget.InvertYAxis = true;
            Assert.AreEqual(true, testingTarget.InvertYAxis, "Should be equal!");

            testingTarget.InvertYAxis = false;
            Assert.AreEqual(false, testingTarget.InvertYAxis, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CameraInvertYAxis END (OK)");
        }
    }
}
