using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/AlphaFunction")]
    public class PublicAlphaFunctionTest
    {
        private const string tag = "NUITEST";

        private delegate float dummyAlphaFunctionDelegate(float progress);
        private dummyAlphaFunctionDelegate alphaFunction;

        private float callback(float progress)
        {
            return 1.0f;
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

        [Test]
        [Category("P1")]
        [Description("AlphaFunction Constructor, Creates an alpha function object with the user-defined alpha function")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionConstructorWithUserDefinedFunction()
        {
            tlog.Debug(tag, $"AlphaFunctionConstructorWithUserDefinedFunction START");

            alphaFunction = new dummyAlphaFunctionDelegate(callback);
            var testingTarget = new AlphaFunction(alphaFunction);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, "getCPtr : " + AlphaFunction.getCPtr(testingTarget));

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionConstructorWithUserDefinedFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction Constructor, Creates an alpha function object with the default built-in alpha function")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionConstructorWithDefaultFunction()
        {
            tlog.Debug(tag, $"AlphaFunctionConstructorWithDefaultFunction START");

            var testingTarget = new AlphaFunction();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionConstructorWithDefaultFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction Constructor, Creates an alpha function object with the built-in alpha function passed as a parameter to the constructor")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionConstructorWithDefaultFunctionAsParameter()
        {
            tlog.Debug(tag, $"AlphaFunctionConstructorWithDefaultFunctionAsParameter START");

            var testingTarget = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionConstructorWithDefaultFunctionAsParameter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction Constructor, Creates a bezier alpha function. The bezier will have the first point at (0,0) and the end point at (1,1)")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.AlphaFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionConstructorNewBezierFunction()
        {
            tlog.Debug(tag, $"AlphaFunctionConstructorNewBezierFunction START");

            var testingTarget = new AlphaFunction(new Vector2(0, 0), new Vector2(1, 1));
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionConstructorNewBezierFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction.GetBezierControlPoints method")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetBezierControlPoints M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionGetBezierControlPoints()
        {
            tlog.Debug(tag, $"AlphaFunctionGetBezierControlPoints START");

            var testingTarget = new AlphaFunction(new Vector2(0, 0), new Vector2(1, 1));
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            testingTarget.GetBezierControlPoints(out Vector2 controlPoint0, out Vector2 controlPoint1);
            Assert.IsTrue(controlPoint0.X == 0);
            Assert.IsTrue(controlPoint0.Y == 0);
            Assert.IsTrue(controlPoint1.X == 1);
            Assert.IsTrue(controlPoint1.Y == 1);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionGetBezierControlPoints END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction.GetBuiltinFunction method")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetBuiltinFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionGetBuiltinFunction()
        {
            tlog.Debug(tag, $"AlphaFunctionGetBuiltinFunction START");

            var testingTarget = new AlphaFunction();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetBuiltinFunction();
            Assert.IsNotNull(result, "should be not null");
            Assert.IsTrue(result == Tizen.NUI.AlphaFunction.BuiltinFunctions.Default);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionGetBuiltinFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction.GetMode method")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.GetMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionGetMode()
        {
            tlog.Debug(tag, $"AlphaFunctionGetMode START");

            var testingTarget = new AlphaFunction();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AlphaFunction>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetMode();
            Assert.IsNotNull(result, "should be not null");
            Assert.IsTrue(result == Tizen.NUI.AlphaFunction.Modes.BuiltinFunction);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlphaFunctionGetMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AlphaFunction BuiltinToPropertyKey.")]
        [Property("SPEC", "Tizen.NUI.AlphaFunction.BuiltinToPropertyKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlphaFunctionBuiltinToPropertyKey()
        {
            tlog.Debug(tag, $"AlphaFunctionBuiltinToPropertyKey START");

            PropertyValue pvAlpha = null;
            string result = null;

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.Linear));
            pvAlpha.Get(out result);
            Assert.AreEqual("LINEAR", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.Reverse));
            pvAlpha.Get(out result);
            Assert.AreEqual("REVERSE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseInSquare));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_IN_SQUARE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseOutSquare));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_OUT_SQUARE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseIn));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_IN", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseOut));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_OUT", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseInOut));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_IN_OUT", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseInSine));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_IN_SINE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseOutSine));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_OUT_SINE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseInOutSine));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_IN_OUT_SINE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.Bounce));
            pvAlpha.Get(out result);
            Assert.AreEqual("BOUNCE", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.Sin));
            pvAlpha.Get(out result);
            Assert.AreEqual("SIN", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.EaseOutBack));
            pvAlpha.Get(out result);
            Assert.AreEqual("EASE_OUT_BACK", result, "Should be equal!");

            pvAlpha = new PropertyValue(AlphaFunction.BuiltinToPropertyKey(AlphaFunction.BuiltinFunctions.Default));
            pvAlpha.Get(out result);
            Assert.AreEqual("DEFAULT", result, "Should be equal!");

            result = null;
            pvAlpha.Dispose();
            tlog.Debug(tag, $"AlphaFunctionBuiltinToPropertyKey END (OK)");
        }
    }
}
