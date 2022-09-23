using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextEvent")]
	public class PublicDragEventTest
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
        [Description("DragData MimeType.")]
        [Property("SPEC", "Tizen.NUI.DragData.MimeType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
	    public void DragDataMimeType()
        {
            tlog.Debug(tag, $"DragDataMimeType START");

            var testingTarget = new Tizen.NUI.DragData();
            Assert.IsNotNull(testingTarget, "Can't create success object DragData");
            Assert.IsInstanceOf<Tizen.NUI.DragData>(testingTarget, "Should be an instance of testingTarget type.");
			
			testingTarget.MimeType = "st";
            Assert.AreEqual("st", testingTarget.MimeType, "Should be equal!");

            tlog.Debug(tag, $"DragDataMimeType END (OK)");	
        }
	
	     
		[Test]
        [Category("P1")]
        [Description("DragData Data.")]
        [Property("SPEC", "Tizen.NUI.DragData.Data A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
	    public void DragDataData()
        {
            tlog.Debug(tag, $"DragDataData START");

            var testingTarget = new Tizen.NUI.DragData();
            Assert.IsNotNull(testingTarget, "Can't create success object DragData");
            Assert.IsInstanceOf<Tizen.NUI.DragData>(testingTarget, "Should be an instance of testingTarget type.");
			
			testingTarget.Data ="st";
			testingTarget.MimeType=null;
                                    
            tlog.Debug(tag, $"DragDataData END (OK)");	
        }
	    
		[Test]
        [Category("P1")]
        [Description("DragEvent DragType.")]
        [Property("SPEC", "Tizen.NUI.DragEvent.DragType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
		public void TextDragEventDragData()
        {
            tlog.Debug(tag, $"DragEventTest DragEvent START");
            
            var testingTarget = new Tizen.NUI.DragEvent();			
            Assert.IsNotNull(testingTarget, "Can't create success object DragEvent");
            Assert.IsInstanceOf<Tizen.NUI.DragEvent>(testingTarget, "Should be an instance of testingTarget type.");
		       	
			testingTarget.Position = null;
			testingTarget.MimeType = null;
		    testingTarget.Data = null;
			
			testingTarget.DragType = DragType.Drop;
			testingTarget.MimeType ="st";
			testingTarget.Data ="st";
			      
			testingTarget.Position = new Position();
		    testingTarget.MimeType = "str3";
			testingTarget.Data = "str4";
		    
            testingTarget.DragType = DragType.Enter;
            testingTarget.DragType = DragType.Leave;
            testingTarget.DragType = DragType.Move;
                                     
            tlog.Debug(tag, $"TextDragEventDragData MimeType END (OK)");
        }
	}
}