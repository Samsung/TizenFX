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
    [NUnit.Framework.Description("Controls/RecyclerView/SelectionChangedEventArgs")]
    public class SelectionChangedEventArgsTest
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
        [Description("SelectionChangedEventArgs PreviousSelection .")]
        [Property("SPEC", "Tizen.NUI.Components.SelectionChangedEventArgs.PreviousSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectionChangedEventArgsPreviousSelection()
        {
            tlog.Debug(tag, $"SelectionChangedEventArgsPreviousSelection START");

            List<string> list = new List<string>();
            list.Add("Russia");
            list.Add("Ukraine");
            list.Add("America");

            var testingTarget = new SelectionChangedEventArgs(list[1], list[2]);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<SelectionChangedEventArgs>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, "PreviousSelection : " + testingTarget.PreviousSelection);
            tlog.Debug(tag, "CurrentSelection : " + testingTarget.CurrentSelection);

            tlog.Debug(tag, $"SelectionChangedEventArgsPreviousSelection END (OK)");
        }
    }
}
