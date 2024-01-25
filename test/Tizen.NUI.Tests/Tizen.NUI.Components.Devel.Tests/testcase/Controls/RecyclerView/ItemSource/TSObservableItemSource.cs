using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/ItemSource/ObservableItemSource")]
    class TSObservableItemSource
    {
        private const string tag = "NUITEST";

        private class TestModel : ObservableCollection<string>
        {
            private string[] namePool = {
                "Cat",
                "Boy",
                "Arm muscle",
                "Girl",
                "House",
                "Cafe",
                "Statue",
                "Sea",
                "hosepipe",
                "Police",
                "Rainbow",
                "Icicle",
                "Tower with the Moon",
                "Giraffe",
                "Camel",
                "Zebra",
                "Red Light",
                "Banana",
                "Lion",
                "Espresso",
            };

            public TestModel()
            {
                CreateData(this, 20);
            }

            private ObservableCollection<string> CreateData(ObservableCollection<string> result, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(namePool[i % 20]);
                }
                return result;
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
        [Description("ObservableItemSource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableItemSourceIsFooter()
        {
            tlog.Debug(tag, $"ObservableItemSourceIsFooter START");

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            Assert.IsFalse(testingTarget.IsFooter(18), "should be false.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableItemSourceIsFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource IsHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.IsHeader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableItemSourceIsHeader()
        {
            tlog.Debug(tag, $"ObservableItemSourceIsHeader START");

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.IsHeader(0), "should be true.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableItemSourceIsHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource GetPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.GetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableItemSourceGetPosition()
        {
            tlog.Debug(tag, $"ObservableItemSourceGetPosition START");

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.GetPosition("Cat"), 0, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableItemSourceGetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource GetItem.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.GetItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableItemSourceGetItem()
        {
            tlog.Debug(tag, $"ObservableItemSourceGetItem START");

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");
            Assert.IsNotNull(testingTarget.GetItem(0), "should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableItemSourceGetItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableItemSourceCollectionItemsSourceChangedMove()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);
            testingTarget.CollectionItemsSourceChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            para.Move(0, 2);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 20, "should be equal.");

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableItemSourceCollectionItemsSourceChangedAdd()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);
            testingTarget.CollectionItemsSourceChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            para.Add("test");

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 21, "should be equal.");

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableItemSourceCollectionItemsSourceChangedRemove()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);
            testingTarget.CollectionItemsSourceChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            para.Add("test");
            para.Remove("test");

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 20, "should be equal.");

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableItemSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableItemSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableItemSourceCollectionItemsSourceChangedReset()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var cView = new CollectionView(para);
            var testingTarget = new ObservableItemSource(cView.ItemsSource, cView);
            testingTarget.CollectionItemsSourceChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableItemSource>(testingTarget, "should be an instance of testing target class!");

            para[0] = "test";
            para.Clear();

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 0, "should be equal.");

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }
    }
}
