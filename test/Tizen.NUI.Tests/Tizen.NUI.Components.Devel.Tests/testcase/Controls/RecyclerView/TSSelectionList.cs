using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [NUnit.Framework.Description("Controls/RecyclerView/SelectionList")]
    public class SelectionListTest
    {
        private const string tag = "NUITEST";
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) { }

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

        private DataTemplate testDataTemplate;

        internal class NCImpl : INotifyCollectionChanged
        {
            public event NotifyCollectionChangedEventHandler CollectionChanged;
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            testDataTemplate = new DataTemplate(() =>
            {
                var rand = new Random();
                DefaultLinearItem item = new DefaultLinearItem();
                //Set Width Specification as MatchParent to fit the Item width with parent View.
                item.WidthSpecification = LayoutParamPolicies.MatchParent;

                //Decorate Label
                item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                item.Label.HorizontalAlignment = HorizontalAlignment.Begin;

                //Decorate SubLabel
                if ((rand.Next() % 2) == 0)
                {
                    item.SubLabel.SetBinding(TextLabel.TextProperty, "Name");
                    item.SubLabel.HorizontalAlignment = HorizontalAlignment.Begin;
                }

                return item;
            });
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("SelectionList Contains.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectionList.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectionListContains()
        {
            tlog.Debug(tag, $"SelectionListContains START");

            var model = new TestModel();

            using (CollectionView cv = new CollectionView(model))
            {
                var testingTarget = new SelectionList(cv);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<SelectionList>(testingTarget, "should be an instance of testing target class!");

                tlog.Debug(tag, "IsReadOnly : " + testingTarget.IsReadOnly.ToString());

                try
                {
                    testingTarget.Add("TEST");
                    var result = testingTarget.Contains("TEST");
                    tlog.Debug(tag, "Contains : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
                
            tlog.Debug(tag, $"SelectionListContains END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectionList CopyTo.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectionList.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectionListCopyTo()
        {
            tlog.Debug(tag, $"SelectionListCopyTo START");

            var model = new TestModel();
            string[] list = { "Jiangsu", "Zhejiang", "Shanghai" };

            using (CollectionView cv = new CollectionView(model))
            {
                var testingTarget = new SelectionList(cv);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<SelectionList>(testingTarget, "should be an instance of testing target class!");

                testingTarget.CopyTo(list, 1);

                var result = testingTarget.Remove("Zhejiang");
                tlog.Debug(tag, "Remove : " + result);

                testingTarget.Insert(0, "Beijing");
                tlog.Debug(tag, "Contains : " + testingTarget.Contains("Beijing"));

                testingTarget.RemoveAt(0);
                tlog.Debug(tag, "Contains : " + testingTarget.Contains("Beijing"));
            }

            tlog.Debug(tag, $"SelectionListCopyTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectionList OnCollectionChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectionList.OnCollectionChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectionListOnCollectionChanged()
        {
            tlog.Debug(tag, $"SelectionListOnCollectionChanged START");

            var model = new TestModel();
            string[] list = { "Jiangsu", "Zhejiang", "Shanghai" };

            var incc = new NCImpl();
            incc.CollectionChanged += OnCollectionChanged;

            List<object> item = new List<object>();
            item.Add(item);

            using (CollectionView cv = new CollectionView(model))
            {
                var testingTarget = new SelectionList(cv, item);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<SelectionList>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Insert(0, "Beijing");
                tlog.Debug(tag, "Contains : " + testingTarget.Contains("Beijing"));
            }

            tlog.Debug(tag, $"SelectionListOnCollectionChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectionList GetEnumerator.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectionList.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectionListGetEnumerator()
        {
            tlog.Debug(tag, $"SelectionListGetEnumerator START");

            var model = new TestModel();
            string[] list = { "Jiangsu", "Zhejiang", "Shanghai" };

            using (CollectionView cv = new CollectionView(model))
            {
                var testingTarget = new SelectionList(cv);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<SelectionList>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Insert(0, "China");

                var index = testingTarget.IndexOf("China");
                tlog.Debug(tag, "IndexOf : " + index);
                // this[index]
                tlog.Debug(tag, "this[index] : " + testingTarget[index]);

                var result = testingTarget.GetEnumerator();
                tlog.Debug(tag, "Enumerator : " + result);
            }

            tlog.Debug(tag, $"SelectionListGetEnumerator END (OK)");
        }
    }
}
