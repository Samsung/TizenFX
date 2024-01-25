using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TouchPointContainer")]
    public class InternalTouchPointContainerTest
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
        [Description("TouchPointContainer constructor.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerConstructor()
        {
            tlog.Debug(tag, $"TouchPointContainerConstructor START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer constructor. With ICollection.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerConstructorWithICollection()
        {
            tlog.Debug(tag, $"TouchPointContainerConstructorWithICollection START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            try
            {
                var testingTarget = new TouchPointContainer(c);
                tlog.Debug(tag, "Count : " + testingTarget.Count);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerConstructorWithICollection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer constructor. With TouchPointContainer.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerConstructorWithTouchPointContainer()
        {
            tlog.Debug(tag, $"TouchPointContainerConstructorWithTouchPointContainer START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            using (TouchPointContainer container = new TouchPointContainer(c))
            {
                var testingTarget = new TouchPointContainer(container);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");
            }

            tlog.Debug(tag, $"TouchPointContainerConstructorWithTouchPointContainer END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("TouchPointContainer constructor. With null ICollection.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerConstructorWithNullICollection()
        {
            tlog.Debug(tag, $"TouchPointContainerConstructorWithNullICollection START");

            ICollection c = null;

            try
            {
                var testingTarget = new TouchPointContainer(c);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TouchPointContainerConstructorWithNullICollection END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer constructor. With capacity.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerConstructorWithCapacity()
        {
            tlog.Debug(tag, $"TouchPointContainerConstructorWithCapacity START");

            var testingTarget = new TouchPointContainer(10);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerConstructorWithCapacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer AddRange.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.AddRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerAddRange()
        {
            tlog.Debug(tag, $"TouchPointContainerAddRange START");

            using (TouchPointContainer container = new TouchPointContainer())
            {
                using (TouchPointContainer values = new TouchPointContainer(10))
                {
                    try
                    {
                        container.AddRange(values);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            tlog.Debug(tag, $"TouchPointContainerAddRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer GetRange.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.GetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerGetRange()
        {
            tlog.Debug(tag, $"TouchPointContainerGetRange START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);

            try
            {
                testingTarget.GetRange(0, 1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerAddRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer IsFixedSize.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.IsFixedSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerIsFixedSize()
        {
            tlog.Debug(tag, $"TouchPointContainerIsFixedSize START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            var result = testingTarget.IsFixedSize;
            tlog.Debug(tag, "IsFixedSize : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerIsFixedSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer IsReadOnly.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.IsReadOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerIsReadOnly()
        {
            tlog.Debug(tag, $"TouchPointContainerIsFixedSize START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            var result = testingTarget.IsReadOnly;
            tlog.Debug(tag, "IsReadOnly : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerIsReadOnly END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer IsSynchronized.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.IsSynchronized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerIsSynchronized()
        {
            tlog.Debug(tag, $"TouchPointContainerIsSynchronized START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            var result = testingTarget.IsSynchronized;
            tlog.Debug(tag, "IsSynchronized : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerIsSynchronized END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Capacity.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Capacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerCapacity()
        {
            tlog.Debug(tag, $"TouchPointContainerCapacity START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Capacity = 100;
            var result = testingTarget.Capacity;
            tlog.Debug(tag, "Capacity : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerCapacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer CopyTo.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerCopyTo()
        {
            tlog.Debug(tag, $"TouchPointContainerCopyTo START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };

            testingTarget.CopyTo(arr);
            var result = testingTarget.Capacity;
            tlog.Debug(tag, "Capacity : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerCopyTo END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("TouchPointContainer CopyTo. Array is null.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerCopyToWithNullArray()
        {
            tlog.Debug(tag, $"TouchPointContainerCopyToWithNullArray START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            TouchPoint[] arr = null ;

            try
            {
                testingTarget.CopyTo(arr);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchPointContainerCopyToWithNullArray END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("TouchPointContainer CopyTo. ArrayIndex less than 0.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerCopyToWithArrayIndexLessThan0()
        {
            tlog.Debug(tag, $"TouchPointContainerCopyToWithArrayIndexLessThan0 START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };

            try
            {
                testingTarget.CopyTo(arr, -2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                tlog.Debug(tag, $"TouchPointContainerCopyToWithArrayIndexLessThan0 END (OK)");
                Assert.Pass("Caught ArgumentOutOfRangeException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer GetEnumerator.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.GetEnumerator M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerGetEnumerator()
        {
            tlog.Debug(tag, $"TouchPointContainerGetEnumerator START");

            var testingTarget = new TouchPointContainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };

            testingTarget.CopyTo(arr);
            var result = testingTarget.GetEnumerator();
            tlog.Debug(tag, "Enumerator : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointContainerGetEnumerator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Reverse.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerReverse()
        {
            tlog.Debug(tag, $"TouchPointContainerReverse START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            try
            {
                
                testingTarget.Reverse();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerReverse END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Reverse. With parameters.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Reverse M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerReverseWithParameters()
        {
            tlog.Debug(tag, $"TouchPointContainerReverseWithParameters START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            try
            {

                testingTarget.Reverse(0, 2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerReverseWithParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer SetRange.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.SetRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerSetRange()
        {
            tlog.Debug(tag, $"TouchPointContainerSetRange START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            try
            {
                using (TouchPointContainer container = new TouchPointContainer(30))
                {
                    testingTarget.SetRange(0, container);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerSetRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer RemoveAt.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.RemoveAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerRemoveAt()
        {
            tlog.Debug(tag, $"TouchPointContainerRemoveAt START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            try
            {
                testingTarget.RemoveAt(0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerRemoveAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer RemoveRange.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.RemoveRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerRemoveRange()
        {
            tlog.Debug(tag, $"TouchPointContainerRemoveRange START");

            TouchPoint[] arr = new TouchPoint[] { new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), new TouchPoint(2, TouchPoint.StateType.Last, 100.0f, 100.0f) };
            global::System.Collections.ICollection c = arr;

            var testingTarget = new TouchPointContainer(c);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            try
            {
                testingTarget.RemoveRange(0, 1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerRemoveRange END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Repeat.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Repeat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerRepeat()
        {
            tlog.Debug(tag, $"TouchPointContainerRepeat START");

            try
            {
                TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerRepeat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Insert.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Insert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerInsert()
        {
            tlog.Debug(tag, $"TouchPointContainerInsert START");

            var testingTarget =  TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Insert(2, new TouchPoint(1, TouchPoint.StateType.Down, 30.0f, 0.0f));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerInsert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer InsertRange.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.InsertRange M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerInsertRange()
        {
            tlog.Debug(tag, $"TouchPointContainerInsertRange START");

            var testingTarget = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.InsertRange(2, new TouchPointContainer(1));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerInsert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainer Clear.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerClear()
        {
            tlog.Debug(tag, $"TouchPointContainerClear START");

            var testingTarget = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPointContainer>(testingTarget, "Should be an Instance of TouchPointContainer!");

            testingTarget.Capacity = 5;

            try
            {
                testingTarget.Clear();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TouchPointContainerClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainerEnumerator Current.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainerEnumerator.Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerEnumeratorCurrent()
        {
            tlog.Debug(tag, $"TouchPointContainerEnumeratorCurrent START");

            using (TouchPointContainer container = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2))
            {
                var testingTarget = container.GetEnumerator();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchPointContainer.TouchPointContainerEnumerator>(testingTarget, "Should be an Instance of TouchPointContainerEnumerator!");

                try
                {
                    var result = testingTarget.Current;
                }
                catch (InvalidOperationException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    testingTarget.Dispose();
                    tlog.Debug(tag, $"TouchPointContainerEnumeratorCurrent END (OK)");
                    Assert.Pass("Caught InvalidOperationException : Passed!");
                }  
            }      
        }

        [Test]
        [Category("P2")]
        [Description("TouchPointContainerEnumerator Current. With null currentObject.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainerEnumerator.Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerEnumeratorCurrentWithNullCurrentObject()
        {
            tlog.Debug(tag, $"TouchPointContainerEnumeratorCurrentWithNullCurrentObject START");

            using (TouchPointContainer container = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2))
            {
                var testingTarget = container.GetEnumerator();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchPointContainer.TouchPointContainerEnumerator>(testingTarget, "Should be an Instance of TouchPointContainerEnumerator!");

                try
                {
                    testingTarget.MoveNext();
                    testingTarget.MoveNext();
                    testingTarget.MoveNext();
                    var result = testingTarget.Current;
                }
                catch (InvalidOperationException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    testingTarget.Dispose();
                    tlog.Debug(tag, $"TouchPointContainerEnumeratorCurrentWithNullCurrentObject END (OK)");
                    Assert.Pass("Caught InvalidOperationException : Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainerEnumerator MoveNext.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainerEnumerator.MoveNext A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerEnumeratorMoveNext()
        {
            tlog.Debug(tag, $"TouchPointContainerEnumeratorMoveNext START");

            using (TouchPointContainer container = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2))
            {
                var testingTarget = container.GetEnumerator();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchPointContainer.TouchPointContainerEnumerator>(testingTarget, "Should be an Instance of TouchPointContainerEnumerator!");

                var result = testingTarget.MoveNext();
                tlog.Debug(tag, "Current : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchPointContainerEnumeratorMoveNext END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPointContainerEnumerator Reset.")]
        [Property("SPEC", "Tizen.NUI.TouchPointContainer.TouchPointContainerEnumerator.Reset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointContainerEnumeratorReset()
        {
            tlog.Debug(tag, $"TouchPointContainerEnumeratorReset START");

            using (TouchPointContainer container = TouchPointContainer.Repeat(new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f), 2))
            {
                var testingTarget = container.GetEnumerator();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchPointContainer.TouchPointContainerEnumerator>(testingTarget, "Should be an Instance of TouchPointContainerEnumerator!");

                try
                {
                    testingTarget.Reset();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchPointContainerEnumeratorReset END (OK)");
        }
    }
}
