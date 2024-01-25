using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/ViewProperty/ImageShadow.cs")]
    public class PublicImageShadowTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyImageShadow : ImageShadow
        {
            public MyImageShadow() : base()
            { }

            public void OnGetPropertyMap()
            {
                base.GetPropertyMap();
            }
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
        [Description("ImageShadow constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructor()
        {
            tlog.Debug(tag, $"ImageShadowConstructor START");

            var testingTarget = new ImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            tlog.Debug(tag, $"ImageShadowConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructorWith3Parameters()
        {
            tlog.Debug(tag, $"ImageShadowConstructorWith3Parameters START");

            var testingTarget = new ImageShadow(url, new Vector2(20, 30), new Vector2(30, 40));
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            tlog.Debug(tag, $"ImageShadowConstructorWith3Parameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow constructor. With Border.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructorWithBorder()
        {
            tlog.Debug(tag, $"ImageShadowConstructorWithBorder START");

            var testingTarget = new ImageShadow(url, new Rectangle(5, 5, 5, 5), new Vector2(20, 30), new Vector2(30, 40));
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            tlog.Debug(tag, $"ImageShadowConstructorWithBorder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow constructor. With ImageShadow.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructorWithImageShadow()
        {
            tlog.Debug(tag, $"ImageShadowConstructorWithImageShadow START");

            var shadow = new ImageShadow(url, new Rectangle(5, 5, 5, 5), new Vector2(20, 30), new Vector2(30, 40));
            Assert.IsNotNull(shadow, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(shadow, "Should be an instance of ImageShadow type.");

            var testingTarget = new ImageShadow(shadow);
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            tlog.Debug(tag, $"ImageShadowConstructorWithImageShadow END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageShadow constructor. With null ImageShadow.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructorWithNullImageShadow()
        {
            tlog.Debug(tag, $"ImageShadowConstructorWithNullImageShadow START");

            ImageShadow shadow = null;

            try
            {
                var testingTarget = new ImageShadow(shadow);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageShadowConstructorWithNullImageShadow END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageShadow constructor. By PropertyMap.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.ImageShadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowConstructorWithByPropertyMap()
        {
            tlog.Debug(tag, $"ImageShadowConstructorWithByPropertyMap START");

            using (PropertyMap map = new PropertyMap())
            {
                var testingTarget = new ImageShadow(map);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
                Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

                tlog.Debug(tag, $"ImageShadowConstructorWithByPropertyMap END (OK)");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow Equals.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowEquals()
        {
            tlog.Debug(tag, $"ImageShadowEquals START");

            var testingTarget = new ImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            var result = testingTarget.Equals(new ImageShadow());
            Assert.IsTrue(result);

            testingTarget.Url = url;
            result = testingTarget.Equals(new ImageShadow());
            Assert.IsFalse(result);

            tlog.Debug(tag, $"ImageShadowEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowGetHashCode()
        {
            tlog.Debug(tag, $"ImageShadowGetHashCode START");

            var testingTarget = new ImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            testingTarget.Border = new Rectangle(5, 5, 5, 5);
            testingTarget.Url = url;

            var result = testingTarget.GetHashCode();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"ImageShadowGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow Clone.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowClone()
        {
            tlog.Debug(tag, $"ImageShadowClone START");

            var testingTarget = new ImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            var result = testingTarget.Clone();
            Assert.IsNotNull(result, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(result, "Should be an instance of ImageShadow type.");

            tlog.Debug(tag, $"ImageShadowClone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow IsEmpty.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.IsEmpty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowIsEmpty()
        {
            tlog.Debug(tag, $"ImageShadowIsEmpty START");

            var testingTarget = new ImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            var result = testingTarget.IsEmpty();
            Assert.IsTrue(result);

            tlog.Debug(tag, $"ImageShadowIsEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow GetPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.GetPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowGetPropertyMap()
        {
            tlog.Debug(tag, $"ImageShadowGetPropertyMap START");

            var testingTarget = new MyImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            testingTarget.Border = new Rectangle(5, 5, 5, 5);
            testingTarget.Url = url;

            try
            {
                testingTarget.OnGetPropertyMap();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ImageShadowGetPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageShadow GetPropertyMap. Border is null.")]
        [Property("SPEC", "Tizen.NUI.ImageShadow.GetPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageShadowGetPropertyMapWithNullBorder()
        {
            tlog.Debug(tag, $"ImageShadowGetPropertyMapWithNullBorder START");

            var testingTarget = new MyImageShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageShadow");
            Assert.IsInstanceOf<ImageShadow>(testingTarget, "Should be an instance of ImageShadow type.");

            testingTarget.Url = url;

            try
            {
                testingTarget.OnGetPropertyMap();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ImageShadowGetPropertyMapWithNullBorder END (OK)");
        }
    }
}
