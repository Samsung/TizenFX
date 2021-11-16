using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ModelView")]
    public class PublicModelViewTest
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
        [Description("ModelView constructor.")]
        [Property("SPEC", "Tizen.NUI.ModelView.ModelView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewConstructor()
        {
            tlog.Debug(tag, $"ModelViewConstructor START");

            var testingTarget = new ModelView();
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ModelViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView constructor.")]
        [Property("SPEC", "Tizen.NUI.ModelView.ModelView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewConstructorWith3Urls()
        {
            tlog.Debug(tag, $"ModelViewConstructorWith3Urls START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ModelViewConstructorWith3Urls END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView constructor.")]
        [Property("SPEC", "Tizen.NUI.ModelView.ModelView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewConstructorWithModel3dView()
        {
            tlog.Debug(tag, $"ModelViewConstructorWithModel3dView START");

            using (ModelView view = new ModelView(objUrl, mtlUrl, imageUrl))
            {
                var testingTarget = new ModelView(view);
                Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
                Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ModelViewConstructorWithModel3dView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView Assign.")]
        [Property("SPEC", "Tizen.NUI.ModelView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewAssign()
        {
            tlog.Debug(tag, $"ModelViewAssign START");

            using (ModelView view = new ModelView(objUrl, mtlUrl, imageUrl))
            {
                var testingTarget = view.Assign(view);
                Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
                Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ModelViewAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView ImagesUrl.")]
        [Property("SPEC", "Tizen.NUI.ModelView.ImagesUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewImagesUrl()
        {
            tlog.Debug(tag, $"ModelViewImagesUrl START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.ImagesUrl);
            testingTarget.ImagesUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.ImagesUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewImagesUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView GeometryUrl.")]
        [Property("SPEC", "Tizen.NUI.ModelView.GeometryUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewGeometryUrl()
        {
            tlog.Debug(tag, $"ModelViewGeometryUrl START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.GeometryUrl);
            testingTarget.GeometryUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.GeometryUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewGeometryUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView MaterialUrl.")]
        [Property("SPEC", "Tizen.NUI.ModelView.MaterialUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewMaterialUrl()
        {
            tlog.Debug(tag, $"ModelViewMaterialUrl START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.MaterialUrl);
            testingTarget.MaterialUrl = mtlUrl;
            tlog.Debug(tag, testingTarget.MaterialUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewMaterialUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView IlluminationType.")]
        [Property("SPEC", "Tizen.NUI.ModelView.IlluminationType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewIlluminationType()
        {
            tlog.Debug(tag, $"ModelViewIlluminationType START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.IlluminationType.ToString());
            testingTarget.IlluminationType = 2;
            tlog.Debug(tag, testingTarget.IlluminationType.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewIlluminationType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView Texture0Url.")]
        [Property("SPEC", "Tizen.NUI.ModelView.Texture0Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewTexture0Url()
        {
            tlog.Debug(tag, $"ModelViewTexture0Url START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.Texture0Url);
            testingTarget.Texture0Url = imageUrl;
            tlog.Debug(tag, testingTarget.Texture0Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewTexture0Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView Texture1Url.")]
        [Property("SPEC", "Tizen.NUI.ModelView.Texture1Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewTexture1Url()
        {
            tlog.Debug(tag, $"ModelViewTexture1Url START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.Texture1Url);
            testingTarget.Texture1Url = objUrl;
            tlog.Debug(tag, testingTarget.Texture1Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewTexture1Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView Texture2Url.")]
        [Property("SPEC", "Tizen.NUI.ModelView.Texture2Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewTexture2Url()
        {
            tlog.Debug(tag, $"ModelViewTexture2Url START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.Texture2Url);
            testingTarget.Texture2Url = mtlUrl;
            tlog.Debug(tag, testingTarget.Texture2Url);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewTexture2Url END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ModelView LightPosition.")]
        [Property("SPEC", "Tizen.NUI.ModelView.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ModelViewLightPosition()
        {
            tlog.Debug(tag, $"ModelViewLightPosition START");

            var testingTarget = new ModelView(objUrl, mtlUrl, imageUrl);
            Assert.IsNotNull(testingTarget, "Can't create success object ModelView");
            Assert.IsInstanceOf<ModelView>(testingTarget, "Should be an instance of ModelView type.");

            tlog.Debug(tag, testingTarget.LightPosition.ToString());
            testingTarget.LightPosition = new Vector3(0.3f, 0.1f, 0.8f);
            tlog.Debug(tag, testingTarget.LightPosition.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ModelViewLightPosition END (OK)");
        }
    }
}
