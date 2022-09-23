using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/DragAndDrop/DragAndDrop")]
    class PublicDragAndDropTest
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
        [Description("DragAndDrop Instance.")]
        [Property("SPEC", "Tizen.NUI.DragAndDrop.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DragAndDropInstance()
        {
            tlog.Debug(tag, $"DragAndDropInstance START");
			      
            var testingTarget= DragAndDrop.Instance; 
            Assert.IsNotNull(testingTarget, "Can't create success object DragAndDrop ");
            Assert.IsInstanceOf<DragAndDrop>(testingTarget, "Should return DragAndDrop instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DragAndDropInstance END (OK)");
        }
    }
}