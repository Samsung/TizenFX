using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Model3dView")]
    public class InternalModel3dViewTest
    {
        private const string tag = "NUITEST";
        private string objUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string mtlUrl = "https://image.baidu.com/search/detail?ct=503316480&z=0&ipn=d&word=bmp%E4%B8%8B%E8%BD%BD%20%E4%BD%8D%E5%9B%BE&step_word=&hs=2&pn=0&spn=0&di=30360&pi=0&rn=1&tn=baiduimagedetail&is=0%2C0&istype=2&ie=utf-8&oe=utf-8&in=&cl=2&lm=-1&st=-1&cs=506847219%2C2820013657&os=4205693751%2C1065126395&simid=0%2C0&adpicid=0&lpn=0&ln=389&fr=&fmq=1389861203899_R&fm=&ic=0&s=undefined&hd=undefined&latest=undefined&copyright=undefined&se=&sme=&tab=0&width=&height=&face=undefined&ist=&jit=&cg=&bdtype=0&oriquery=bmp%E4%B8%8B%E8%BD%BD&objurl=https%3A%2F%2Fgimg2.baidu.com%2Fimage_search%2Fsrc%3Dhttp%3A%2F%2Fbpic.ooopic.com%2F17%2F52%2F38%2F17523837-6a28a5a38920964a54ed89d8e93c3a3c-0.jpg%26refer%3Dhttp%3A%2F%2Fbpic.ooopic.com%26app%3D2002%26size%3Df9999%2C10000%26q%3Da80%26n%3D0%26g%3D0n%26fmt%3Djpeg%3Fsec%3D1624445232%26t%3Db9e3c91e4753f12d81e73c7142181326&fromurl=ippr_z2C%24qAzdH3FAzdH3Fooo_z%26e3B555rtv_z%26e3Bv54AzdH3Ffij3ty7wgf7AzdH3F80cdnbn0_z%26e3Bip4s&gsm=1&rpstart=0&rpnum=0&islist=&querylist=&force=undefined";
        private string imageUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("Model3dView constructor.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Model3dView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewConstructor()
        {
            tlog.Debug(tag, $"Model3dViewConstructor START");

            var testingTarget = new Model3dView();
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"Model3dViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView constructor.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Model3dView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewConstructorWith3Urls()
        {
            tlog.Debug(tag, $"Model3dViewConstructorWith3Urls START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"Model3dViewConstructorWith3Urls END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView constructor.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Model3dView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewConstructorWithModel3dView()
        {
            tlog.Debug(tag, $"Model3dViewConstructorWithModel3dView START");

            using (Model3dView view = new Model3dView(objUrl, mtlUrl, imageUrl))
            {
                var testingTarget = new Model3dView(view);
                Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
                Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Model3dViewConstructorWithModel3dView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView Assign.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewAssign()
        {
            tlog.Debug(tag, $"Model3dViewAssign START");

            using (Model3dView view = new Model3dView(objUrl, mtlUrl, imageUrl))
            {
                var testingTarget = view.Assign(view);
                Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
                Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Model3dViewAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView DownCast.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewDownCast()
        {
            tlog.Debug(tag, $"Model3dViewDownCast START");

            using (Model3dView view = new Model3dView(objUrl, mtlUrl, imageUrl))
            {
                var testingTarget = Model3dView.DownCast(view);
                Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
                Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Model3dViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView ImagesUrl.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.ImagesUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewImagesUrl()
        {
            tlog.Debug(tag, $"Model3dViewImagesUrl START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.ImagesUrl);
            testingTarget.ImagesUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.ImagesUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewImagesUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView GeometryUrl.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.GeometryUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewGeometryUrl()
        {
            tlog.Debug(tag, $"Model3dViewGeometryUrl START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.GeometryUrl);
            testingTarget.GeometryUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.GeometryUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewGeometryUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView MaterialUrl.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.MaterialUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewMaterialUrl()
        {
            tlog.Debug(tag, $"Model3dViewMaterialUrl START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.MaterialUrl);
            testingTarget.MaterialUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.MaterialUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewMaterialUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView IlluminationType.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.IlluminationType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewIlluminationType()
        {
            tlog.Debug(tag, $"Model3dViewIlluminationType START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.IlluminationType.ToString());
            testingTarget.IlluminationType = 2;
            tlog.Debug(tag, testingTarget.IlluminationType.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewIlluminationType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView Texture0Url.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Texture0Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewTexture0Url()
        {
            tlog.Debug(tag, $"Model3dViewTexture0Url START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.Texture0Url);
            testingTarget.Texture0Url = imageUrl;
            tlog.Debug(tag, testingTarget.Texture0Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewTexture0Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView Texture1Url.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Texture1Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewTexture1Url()
        {
            tlog.Debug(tag, $"Model3dViewTexture1Url START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.Texture1Url);
            testingTarget.Texture1Url = objUrl;
            tlog.Debug(tag, testingTarget.Texture1Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewTexture1Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView Texture2Url.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.Texture2Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewTexture2Url()
        {
            tlog.Debug(tag, $"Model3dViewTexture2Url START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.Texture2Url);
            testingTarget.Texture2Url = mtlUrl;
            tlog.Debug(tag, testingTarget.Texture2Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewTexture2Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Model3dView LightPosition.")]
        [Property("SPEC", "Tizen.NUI.Model3dView.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Model3dViewLightPosition()
        {
            tlog.Debug(tag, $"Model3dViewLightPosition START");

            var testingTarget = new Model3dView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object Model3dView");
            Assert.IsInstanceOf<Model3dView>(testingTarget, "Should be an instance of Model3dView type.");

            tlog.Debug(tag, testingTarget.LightPosition.ToString());
            testingTarget.LightPosition = new Vector3(0.3f, 0.1f, 0.8f);
            tlog.Debug(tag, testingTarget.LightPosition.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"Model3dViewLightPosition END (OK)");
        }
    }
}
