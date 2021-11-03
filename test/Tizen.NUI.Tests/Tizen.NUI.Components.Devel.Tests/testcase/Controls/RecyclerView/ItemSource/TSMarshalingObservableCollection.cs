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
    [Description("Controls/RecyclerView/ItemSource/MarshalingObservableCollection")]
    class TSMarshalingObservableCollection
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
        [Description("MarshalingObservableCollection CollectionChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.MarshalingObservableCollection.CollectionChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task MarshalingObservableCollectionCollectionChangedAdd()
        {
            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedAdd START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var testingTarget = new MarshalingObservableCollection(para);
            testingTarget.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<MarshalingObservableCollection>(testingTarget, "should be an instance of testing target class!");

            para.Add("Test");

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 21, "should be equal.");

            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MarshalingObservableCollection CollectionChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.MarshalingObservableCollection.CollectionChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task MarshalingObservableCollectionCollectionChangedRemove()
        {
            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedRemove START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var testingTarget = new MarshalingObservableCollection(para);
            testingTarget.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<MarshalingObservableCollection>(testingTarget, "should be an instance of testing target class!");

            para.Remove("Cat");

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 19, "should be equal.");

            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MarshalingObservableCollection CollectionChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.MarshalingObservableCollection.CollectionChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task MarshalingObservableCollectionCollectionChangedReplace()
        {
            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedReplace START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var testingTarget = new MarshalingObservableCollection(para);
            testingTarget.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<MarshalingObservableCollection>(testingTarget, "should be an instance of testing target class!");

            para[0] = "Abc";

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 20, "should be equal.");

            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedReplace END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MarshalingObservableCollection CollectionChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.MarshalingObservableCollection.CollectionChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task MarshalingObservableCollectionCollectionChangedMove()
        {
            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedMove START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            NotifyCollectionChangedEventHandler onChanged = (s, e) => { tcs.TrySetResult(true); };

            var para = new TestModel();
            var testingTarget = new MarshalingObservableCollection(para);
            testingTarget.CollectionChanged += onChanged;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<MarshalingObservableCollection>(testingTarget, "should be an instance of testing target class!");

            para.Move(0, 2);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Change event should be invoked");
            Assert.AreEqual(testingTarget.Count, 20, "should be equal.");

            tlog.Debug(tag, $"MarshalingObservableCollectionCollectionChangedMove END (OK)");
        }
    }
}
