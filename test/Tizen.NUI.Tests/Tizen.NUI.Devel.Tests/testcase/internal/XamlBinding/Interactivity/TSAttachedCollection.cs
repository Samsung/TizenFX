using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/AttachedCollection")]
    public class InternalAttachedCollectionTest
    {
        private const string tag = "NUITEST";

        internal class MyView : View, IAttachedObject
        {
            public void AttachTo(BindableObject bindable)
            {
            }

            public void DetachFrom(BindableObject bindable)
            {
            }
        }

        internal class MyAttachedCollection<T> : AttachedCollection<T> where T : BindableObject, IAttachedObject
        {
            public void Clear()
            {
                ClearItems();
            }

            public void Insert(int index, T item)
            {
                InsertItem(index, item);
            }

            public void OnDetach(BindableObject bindable)
            {
                OnDetachingFrom(bindable);
            }

            public void Remove(int index)
            {
                RemoveItem(index);
            }

            public void Set(int index, T item)
            {
                SetItem(index, item);
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
        [Description("AttachedCollection constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.AttachedCollection C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void AttachedCollectionConstructor()
        {
            tlog.Debug(tag, $"AttachedCollectionConstructor START");
            IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
            var testingTarget = new AttachedCollection<MyView>(collection);
            Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

            IList<MyView> list = new List<MyView>() { new MyView() };
            var testingTarget2 = new AttachedCollection<MyView>(list);
            Assert.IsNotNull(testingTarget2, "Can't create success object AttachedCollection.");

            tlog.Debug(tag, $"AttachedCollectionConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("AttachedCollection AttachTo")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.AttachTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AttachTo()
        {
            tlog.Debug(tag, $"AttachTo START");
            IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
            var testingTarget = new AttachedCollection<MyView>(collection);
            Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

            Assert.Throws<ArgumentNullException>(() => testingTarget.AttachTo(null));


            tlog.Debug(tag, $"AttachTo END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection DetachFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.DetachFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void DetachFrom()
        {
            tlog.Debug(tag, $"DetachFrom START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new AttachedCollection<MyView>(collection);
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.DetachFrom(v);
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"DetachFrom END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection ClearItems")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.ClearItems M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ClearItems()
        {
            tlog.Debug(tag, $"ClearItems START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new MyAttachedCollection<MyView>();
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.Clear();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"ClearItems END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection InsertItem")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.InsertItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void InsertItem()
        {
            tlog.Debug(tag, $"InsertItem START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new MyAttachedCollection<MyView>();
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.Insert(0, new MyView());
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"InsertItem END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection OnDetachingFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.OnDetachingFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnDetachingFrom()
        {
            tlog.Debug(tag, $"OnDetachingFrom START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new MyAttachedCollection<MyView>();
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.OnDetach(v);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"OnDetachingFrom END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection RemoveItem")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.RemoveItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void RemoveItem()
        {
            tlog.Debug(tag, $"RemoveItem START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new MyAttachedCollection<MyView>();
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.Insert(0, new MyView());
                testingTarget.Remove(0);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"RemoveItem END");
        }

        [Test]
        [Category("P1")]
        [Description("AttachedCollection SetItem")]
        [Property("SPEC", "Tizen.NUI.Binding.AttachedCollection.SetItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetItem()
        {
            tlog.Debug(tag, $"SetItem START");
            try
            {
                IEnumerable<MyView> collection = new List<MyView>() { new MyView() };
                var testingTarget = new MyAttachedCollection<MyView>();
                Assert.IsNotNull(testingTarget, "Can't create success object AttachedCollection.");

                var v = new MyView();
                testingTarget.AttachTo(v);
                testingTarget.Insert(0, new MyView());
                testingTarget.Set(0, new MyView());
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"SetItem END");
        }
    }
}
