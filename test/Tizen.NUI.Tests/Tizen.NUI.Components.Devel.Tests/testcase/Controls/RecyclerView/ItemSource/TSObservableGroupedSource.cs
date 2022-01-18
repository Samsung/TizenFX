using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/ItemSource/ObservableGroupedSource")]
    class TSObservableGroupedSource
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
        [Description("ObservableGroupedSource constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceConstructor()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceConstructor START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource Count.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.Count A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceCount()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceCount START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource HasHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.HasHeader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceHasHeader()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceHasHeader START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.HasHeader, "should be true.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceHasHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource HasFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.HasFooter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceHasFooter()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceHasFooter START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            Assert.IsTrue(testingTarget.HasFooter, "should be true.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceHasFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.IsFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceIsFooter()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceIsFooter START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasFooter = true;
            tlog.Debug(tag, "IsFooter : " + testingTarget.IsFooter(19));
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceIsFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource IsHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.IsHeader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceIsHeader()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceIsHeader START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            testingTarget.HasHeader = true;
            Assert.IsTrue(testingTarget.IsHeader(0), "The item should be footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceIsHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource GetPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.GetPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void ObservableGroupedSourceGetPosition()
        {
            tlog.Debug(tag, $"ObservableGroupedSourceGetPosition START");

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            Assert.AreEqual(testingTarget.GetPosition("Cat"), 0, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ObservableGroupedSourceGetPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableGroupedSourceCollectionItemsSourceChangedMove()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);
            model.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            model.Move(0, 2);
            testingTarget.NotifyItemMoved(testingTarget, 0, 2);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            tlog.Debug(tag, "Count : " + testingTarget.Count);            

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableGroupedSourceCollectionItemsSourceChangedAdd()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);
            model.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            model.Add("test");
            testingTarget.NotifyItemInserted(testingTarget, model.Count - 1);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableGroupedSourceCollectionItemsSourceChangedRemove()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);
            model.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            model.Add("test");
            model.Remove("test");
            testingTarget.NotifyItemRemoved(testingTarget, model.Count - 1);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableGroupedSourceCollectionItemsSourceChangedReset()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);
            model.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            model.Clear();   

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ObservableGroupedSource CollectionItemsSourceChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ObservableGroupedSource.CollectionItemsSourceChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task ObservableGroupedSourceCollectionItemsSourceChangedReplace()
        {
            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var cView = new CollectionView(model);
            var testingTarget = new ObservableGroupedSource(cView, cView);
            model.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ObservableGroupedSource>(testingTarget, "should be an instance of testing target class!");

            model[0] = "test";

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            tlog.Debug(tag, $"ObservableItemSourceCollectionItemsSourceChanged END (OK)");
        }
    }
}
