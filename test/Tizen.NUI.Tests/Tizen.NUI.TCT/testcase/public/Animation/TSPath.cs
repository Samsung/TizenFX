using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/Path")]
    public class PublicPathTest
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
        [Description("Path constructor")]
        [Property("SPEC", "Tizen.NUI.Path.Path C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstructor()
        {
            tlog.Debug(tag, $"PathConstructor START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PathConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path Points. Get")]
        [Property("SPEC", "Tizen.NUI.Path.Points A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathPointsGet()
        {
            tlog.Debug(tag, $"PathPointsGet START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            PropertyArray dummy = new PropertyArray();
            dummy.Add(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));

            testingTarget.Points = dummy;
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.Points[0].Get(vec);  //Get
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathPointsGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path Points. Set")]
        [Property("SPEC", "Tizen.NUI.Path.Points A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathPointsSet()
        {
            tlog.Debug(tag, $"PathPointsSet START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            PropertyArray dummy = new PropertyArray();
            dummy.Add(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));

            testingTarget.Points = dummy;   //Set
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.Points[0].Get(vec);
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathPointsSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path ControlPoints. Get")]
        [Property("SPEC", "Tizen.NUI.Path.ControlPoints A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathControlPointsGet()
        {
            tlog.Debug(tag, $"PathControlPointsGet START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            PropertyArray dummy = new PropertyArray();
            dummy.Add(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));

            testingTarget.ControlPoints = dummy;   //Set
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.ControlPoints[0].Get(vec);
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            tlog.Debug(tag, $"PathControlPointsGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path ControlPoints. Set")]
        [Property("SPEC", "Tizen.NUI.Path.ControlPoints A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathControlPointsSet()
        {
            tlog.Debug(tag, $"PathControlPointsSet START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            PropertyArray dummy = new PropertyArray();
            dummy.Add(new PropertyValue(new Vector3(0.5f, 0.0f, 0.8f)));

            testingTarget.ControlPoints = dummy;   //Set
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.ControlPoints[0].Get(vec);
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathControlPointsSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path AddPoints")]
        [Property("SPEC", "Tizen.NUI.Path.AddPoints M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathAddPoints()
        {
            tlog.Debug(tag, $"PathAddPoints START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            Position dummy = new Position(0.5f, 0.0f, 0.8f);
            testingTarget.AddPoint(dummy);
           
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.Points[0].Get(vec);
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathAddPoints END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path AddControlPoint")]
        [Property("SPEC", "Tizen.NUI.Path.AddControlPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathAddControlPoint()
        {
            tlog.Debug(tag, $"PathAddControlPoint START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            Position dummy = new Vector3(0.5f, 0.0f, 0.8f);
            testingTarget.AddControlPoint(dummy);

            Vector3 vec = new Vector3(0, 0, 0);
            testingTarget.ControlPoints[0].Get(vec);
            Assert.IsTrue(0.5f == vec.X);
            Assert.IsTrue(0.0f == vec.Y);
            Assert.IsTrue(0.8f == vec.Z);

            dummy.Dispose();
            vec.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathAddControlPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path GenerateControlPoints")]
        [Property("SPEC", "Tizen.NUI.Path.GenerateControlPoints M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathGenerateControlPoints()
        {
            tlog.Debug(tag, $"PathGenerateControlPoints START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            var points = new PropertyArray();
            Assert.IsNotNull(points, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(points, "should be an instance of PropertyArray class!");
            points.PushBack(new PropertyValue(new Vector3(1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            testingTarget.Points = points;

            testingTarget.GenerateControlPoints(0.5f);
            Vector3 vec = new Vector3(0, 0, 0);
            var result = testingTarget.ControlPoints[0].Get(vec);
            Assert.IsTrue(480 == vec.X);
            Assert.IsTrue(0 == vec.Y);
            Assert.IsTrue(480 == vec.Z);

            points.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathGenerateControlPoints END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path Sample")]
        [Property("SPEC", "Tizen.NUI.Path.Sample M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathSample()
        {
            tlog.Debug(tag, $"PathSample START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            Vector2 stageSize = Window.Instance.WindowSize;

            var points = new PropertyArray();
            Assert.IsNotNull(points, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(points, "should be an instance of PropertyArray class!");
            points.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            testingTarget.Points = points;

            var controlPoints = new PropertyArray();
            Assert.IsNotNull(controlPoints, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(controlPoints, "should be an instance of PropertyArray class!");
            controlPoints.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.5f, 0.0f, stageSize.X * 0.3f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.3f, 0.0f, 0.0f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.3f, 0.0f, 0.0f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.5f, 0.0f, stageSize.X * 0.3f)));
            testingTarget.ControlPoints = controlPoints;

            var progress = 0.0f;
            var position = new Position(0.0f, 0.0f, 0.0f);
            var tangent = new Vector3(0.0f, 0.0f, 0.0f);
            try
            {
                testingTarget.Sample(progress, position, tangent);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            position.Dispose();
            tangent.Dispose();
            points.Dispose();
            controlPoints.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathSample END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path GetPoint")]
        [Property("SPEC", "Tizen.NUI.Path.GetPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathGetPoint()
        {
            tlog.Debug(tag, $"PathGetPoint START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            var points = new PropertyArray();
            Assert.IsNotNull(points, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(points, "should be an instance of PropertyArray class!");
            points.PushBack(new PropertyValue(new Vector3(1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            testingTarget.Points = points;

            var result = testingTarget.GetPoint(2);
            Assert.IsTrue(-960 == result.X);
            Assert.IsTrue(0 == result.Y);
            Assert.IsTrue(960 == result.Z);

            points.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathGetPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path GetControlPoint")]
        [Property("SPEC", "Tizen.NUI.Path.GetControlPoint M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathGetControlPoint()
        {
            tlog.Debug(tag, $"PathGetControlPoint START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            var points = new PropertyArray();
            Assert.IsNotNull(points, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(points, "should be an instance of PropertyArray class!");
            points.PushBack(new PropertyValue(new Vector3(1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-1920 * 0.5f, 0.0f, 1920 * 0.5f)));
            testingTarget.Points = points;

            testingTarget.GenerateControlPoints(0.5f);
            var result = testingTarget.GetControlPoint(1);
            Assert.IsTrue(678.8225 == result.X);
            Assert.IsTrue(0 == result.Y);
            Assert.IsTrue(0 == result.Z);

            points.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathGetControlPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Path GetPointCount")]
        [Property("SPEC", "Tizen.NUI.Path.GetPointCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathGetPointCount()
        {
            tlog.Debug(tag, $"PathGetPointCount START");

            var testingTarget = new Path();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Path>(testingTarget, "should be an instance of Path class!");

            Vector2 stageSize = Window.Instance.WindowSize;

            var points = new PropertyArray();
            Assert.IsNotNull(points, "should be not null");
            Assert.IsInstanceOf<PropertyArray>(points, "should be an instance of PropertyArray class!");
            points.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            testingTarget.Points = points;

            var result = testingTarget.GetPointCount();
            Assert.IsTrue(3 == result);

            points.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PathGetPointCount END (OK)");
        }
    }
}
