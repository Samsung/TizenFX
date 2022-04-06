using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.IO;
using global::System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("DisposeTest")]
    public class DisposeTest
    {
        private const string tag = "NUITEST";
        private const int testSize = 100;
        private const int testPosition = 100;
        private const int RefCountWhenNew = 2;
        private const int RefCountWhenAdd = 1;
        private const int RefCountWhenRemoveOrUnparent = -1;
        private const int RefCountWhenAddedInList = 0;
        private const int RefCountWhenRemovedInList = 0;
        private const int RefCountWhenCurrentFocusSet = 1;
        private const int RefCountWhenFocusCleared = -1;
        private const int RefCountWhenAnimationSet = 0;
        private const int RefCountWhenAnimationPlayed = 0;
        private const int RefCountWhenAnimationFinished = 0;
        private string path;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, $"Init() is called! process={Process.GetCurrentProcess().Id}, thread={Thread.CurrentThread.ManagedThreadId}\n");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, $"Destroy() is called! process={Process.GetCurrentProcess().Id}, thread={Thread.CurrentThread.ManagedThreadId}\n");
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_NEW()
        {
            /* TEST CODE */
            View testView = new View();

            var expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_NEW_WITH_SETTINGS()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };

            var expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_ADD()
        {
            /* TEST CODE */
            View testView = new View();
            NUIApplication.GetDefaultWindow().Add(testView);

            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Unparent();

            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenRemoveOrUnparent;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_ADD_WITH_SETTING()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };

            NUIApplication.GetDefaultWindow().Add(testView);

            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Unparent();

            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenRemoveOrUnparent;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_ADD_MULTIPLE_WITH_SETTING()
        {
            /* TEST CODE */
            View parentView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };

            Layer defaultLayer = NUIApplication.GetDefaultWindow().GetDefaultLayer();
            //check defaultLayer
            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, defaultLayer.RefCnt(), $"reference count should be {expectedValue}");

            NUIApplication.GetDefaultWindow().Add(parentView);

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            View childView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Blue,
            };
            parentView.Add(childView);

            //check defaultLayer
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, defaultLayer.RefCnt(), $"reference count should be {expectedValue}");

            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            parentView.Unparent();

            //check defaultLayer
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, defaultLayer.RefCnt(), $"reference count should be {expectedValue}");

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenRemoveOrUnparent;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            parentView.Dispose();

            //check defaultLayer
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, defaultLayer.RefCnt(), $"reference count should be {expectedValue}");

            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenRemoveOrUnparent;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            childView.Dispose();

            //check defaultLayer
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, defaultLayer.RefCnt(), $"reference count should be {expectedValue}");
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_ADD_WITH_SETTING_IN_CSHARP_LIST()
        {
            /* TEST CODE */
            View parentView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };

            NUIApplication.GetDefaultWindow().Add(parentView);

            //check parentView
            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            View childView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Blue,
            };
            //check childView
            expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            parentView.Add(childView);

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            List<View> list = new List<View>();
            list.Add(parentView);

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAddedInList;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            list.Add(childView);

            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAddedInList;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            //check list
            expectedValue = 2;
            Assert.AreEqual(expectedValue, list.Count, $"list count should be {expectedValue}");

            list.Remove(parentView);

            //check parentView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAddedInList + RefCountWhenRemovedInList;
            Assert.AreEqual(expectedValue, parentView.RefCnt(), $"reference count should be {expectedValue}");

            list.Remove(childView);
            //check childView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAddedInList + RefCountWhenRemovedInList;
            Assert.AreEqual(expectedValue, childView.RefCnt(), $"reference count should be {expectedValue}");

            parentView.Unparent();
            childView.Unparent();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_SET_FOCUSMANAGER()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
                Focusable = true,
            };

            NUIApplication.GetDefaultWindow().Add(testView);

            //check testView
            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            FocusManager.Instance.SetCurrentFocusView(testView);

            //check testView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenCurrentFocusSet;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            FocusManager.Instance.ClearFocus();

            //check testView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenCurrentFocusSet + RefCountWhenFocusCleared;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_ANIMATION()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };

            NUIApplication.GetDefaultWindow().Add(testView);

            //check testView
            var expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            var ani = new Animation(300);
            ani.AnimateTo(testView, "Size", new Size(testSize * 2, testSize * 2, 0));
            ani.Finished += (sender, e) =>
            {
                //check testView
                expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAnimationSet +
                    RefCountWhenAnimationPlayed + RefCountWhenAnimationFinished;
                Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

                testView.Dispose();
            };

            //check testView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAnimationSet;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            ani.Play();

            //check testView
            expectedValue = RefCountWhenNew + RefCountWhenAdd + RefCountWhenAnimationSet + RefCountWhenAnimationPlayed;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");
        }

        private ImageUrl imageUrl;

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_IMAGEURL_CLASS()
        {
            /* TEST CODE */
            path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

            Stream stream = File.OpenRead(path);
            EncodedImageBuffer buffer = new EncodedImageBuffer(stream);
            imageUrl = buffer.GenerateUrl();

            //check imagUrl
            var expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");

            View testView = new View
            {
                Name = "testImageUrl",
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundImage = imageUrl.ToString(),
            };

            // new EventThreadCallback( new EventThreadCallback.CallbackDelegate
            //     (
            //         ()=>
            //         {
            //             NUIApplication.GetDefaultWindow().Add(testView);
            //         }
            //     )
            // ).Trigger();

            // test1(testView);
            // await Task.Delay(300);

            //check imagUrl
            expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");

            NUIApplication.GetDefaultWindow().Add(testView);

            //await Task.Delay(300);

            //check imagUrl
            expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");

            //imageUrl.Dispose();

            //check testView
            expectedValue = RefCountWhenNew + RefCountWhenAdd;
            Assert.AreEqual(expectedValue, testView.RefCnt(), $"reference count should be {expectedValue}");

            View sameImageUrlView = new View
            {
                Name = "testImageUrl2",
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition * 2, testPosition * 2, 0),
                BackgroundImage = imageUrl.ToString(),
            };

            //check imagUrl
            expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");

            NUIApplication.GetDefaultWindow().Add(sameImageUrlView);

            //check imagUrl
            expectedValue = RefCountWhenNew;
            Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");

        }
        // void test1(View view)
        // {
        //     NUIApplication.GetDefaultWindow().Add(view);
        // }

        [Test]
        [Category("P1")]
        [Description("DisposeTest")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MMB")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void Dispose_CHECK_REFERENCE_COUNT_WHEN_IMAGEURL_CLASS_DISPOSE_IMAGEURL()
        {
            /* TEST CODE */
            var win = NUIApplication.GetDefaultWindow();
            View testView = win.GetDefaultLayer().FindChildByName("testImageUrl");
            var expectedValue = 0;
            if (testView)
            {
                if (imageUrl)
                {
                    //check imagUrl
                    expectedValue = RefCountWhenNew;
                    Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");
                }
                testView.Dispose();

                //check imagUrl
                expectedValue = RefCountWhenNew;
                Assert.AreEqual(expectedValue, imageUrl.RefCnt(), $"reference count should be {expectedValue}");
            }
        }


    }

    public static class BaseHandleExtension
    {
        public static int RefCnt(this BaseHandle baseHandle)
        {
            if (baseHandle)
            {
                BaseObject tmp = new BaseObject(Interop.BaseHandle.GetBaseObject(baseHandle.GetBaseHandleCPtrHandleRef), false);
                var refCnt = tmp.ReferenceCount();
                tmp.Dispose();
                return refCnt;
            }
            return -1;
        }
    }

    // public static class ViewExtension
    // {
    //     public static int RefCnt(this View view)
    //     {
    //         if (view)
    //         {
    //             BaseObject tmp = new BaseObject(Interop.BaseHandle.GetBaseObject(view.GetBaseHandleCPtrHandleRef), false);
    //             var refCnt = tmp.ReferenceCount();
    //             tmp.Dispose();
    //             return refCnt;
    //         }
    //         return -1;
    //     }
    // }

    // public static class LayerExtension
    // {
    //     public static int RefCnt(this Layer layer)
    //     {
    //         if (layer)
    //         {
    //             BaseObject tmp = new BaseObject(Interop.BaseHandle.GetBaseObject(layer.GetBaseHandleCPtrHandleRef), false);
    //             var refCnt = tmp.ReferenceCount();
    //             tmp.Dispose();
    //             return refCnt;
    //         }
    //         return -1;
    //     }
    // }

}
