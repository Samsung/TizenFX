using global::System;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    internal class CustomBindableObject : BindableObject
    {
        /// <summary> Bindable property of SizeWidth. Please do not open it. </summary>
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create("SizeWidth", typeof(float?), typeof(CustomBindableObject), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (bindable is CustomBindableObject bindableObject)
            {
                bindableObject.size = new Size((float)newValue, 0);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            if (bindable is CustomBindableObject bindableObject)
            {
                return bindableObject.size.Width;
            }
            else
            {
                return null;
            }
        });

        /// <summary> Bindable property of SizeWidth. Please do not open it. </summary>
        public static readonly BindableProperty SizeProperty = BindableProperty.Create("Size", typeof(Size), typeof(CustomBindableObject), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (bindable is CustomBindableObject bindableObject)
            {
                bindableObject.size = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            if (bindable is CustomBindableObject bindableObject)
            {
                return bindableObject.size;
            }
            else
            {
                return null;
            }
        });

        private Size size;
    }

    [TestFixture]
    [Description("public/Xaml")]
    public class TSBindableObject
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "index.xml";

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
        [Description("BindableObject CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void CopyFrom()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            using (View view = new View())
            {
                Assert.IsNotNull(view, "Create View failed");
                try
                {
                    var viewTo = new View();
                    //viewTo.CopyFrom(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                view.Dispose();
            }

            tlog.Debug(tag, $"CopyFrom END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObject ClearValue.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.ClearValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void ClearValue()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            try
            {
                CustomBindableObject customBindableObject = new CustomBindableObject();
                Assert.IsNotNull(customBindableObject, "Create object failed");

                customBindableObject.ClearValue(CustomBindableObject.SizeProperty, true);

                var key = new BindablePropertyKey(CustomBindableObject.SizeProperty);
                customBindableObject.ClearValue(key);

                var size = new Size(300, 200);

                customBindableObject.IsBinded = true;
                customBindableObject.SetValue(CustomBindableObject.SizeProperty, size);
                customBindableObject.SetValue(CustomBindableObject.SizeWidthProperty, 100);

                customBindableObject.ClearValue(CustomBindableObject.SizeProperty);

                size.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ClearValue END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObject IsSet.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.IsSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void IsSet()
        {
            tlog.Debug(tag, $"IsSet START");

            using (View view = new View())
            {
                Assert.IsNotNull(view, "Create View failed");
                try
                {
                    bool isSet = view.IsSet(View.PositionProperty);
                    Assert.AreEqual(false, isSet, "Should be false");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                view.Dispose();
            }

            tlog.Debug(tag, $"IsSet END");
        }

        [Test]
        [Category("P2")]
        [Description("BindableObject IsSet.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.IsSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void IsSet2()
        {
            tlog.Debug(tag, $"IsSet2 START");
            View view = new View();
            Assert.Throws<ArgumentNullException>(() => view.IsSet(null));

            tlog.Debug(tag, $"IsSet2 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObject RemoveBinding.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.RemoveBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void RemoveBinding()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            using (View view = new View())
            {
                Assert.IsNotNull(view, "Create View failed");
                try
                {
                    view.RemoveBinding(View.PositionProperty);

                    Binding.Binding binding = new Binding.Binding();
                    view.SetBinding(View.PositionProperty, binding);

                    view.RemoveBinding(View.PositionProperty);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                view.Dispose();
            }

            tlog.Debug(tag, $"RemoveBinding END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObject RemoveBinding.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.SetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void BindableObjectSetValueWithBindablePropertyKey()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            using (View view = new View())
            {
                Assert.IsNotNull(view, "Create View failed");
                try
                {
                    var pos = new Position(1, 2);
                    var key = new BindablePropertyKey(View.PositionProperty);
                    view.SetValue(key, pos);
                    Assert.AreEqual(pos, view.Position, "Should be equal");

                    pos.Dispose();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                view.Dispose();
            }

            tlog.Debug(tag, $"SetValue END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObject GetValues.")]
        [Property("SPEC", "Tizen.NUI.XamlBinding.BindableObject.GetValues M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void BindableObjectGetValues()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            try
            {
                var pos = new Position(1, 2);

                {
                    View view = new View();
                    view.Position = pos;

                    var values = view.GetValues(View.PositionXProperty, View.PositionYProperty);
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");

                    values = view.GetValues(View.PositionXProperty, View.PositionYProperty);
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");

                    view.Dispose();
                }

                {
                    View view = new View();
                    view.Position = pos;

                    var values = view.GetValues(View.PositionXProperty, View.PositionYProperty, View.PositionZProperty);
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");
                    Assert.AreEqual(0.0f, (float)values[2], "Should be equal");

                    values = view.GetValues(View.PositionXProperty, View.PositionYProperty, View.PositionZProperty);
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");
                    Assert.AreEqual(0.0f, (float)values[2], "Should be equal");

                    view.Dispose();
                }

                {
                    View view = new View();
                    view.Position = pos;

                    var values = view.GetValues(new BindableProperty[] { View.PositionXProperty, View.PositionYProperty });
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");

                    values = view.GetValues(new BindableProperty[] { View.PositionXProperty, View.PositionYProperty });
                    Assert.AreEqual(1.0f, (float)values[0], "Should be equal");
                    Assert.AreEqual(2.0f, (float)values[1], "Should be equal");

                    view.Dispose();
                }

                pos.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GetValues END");
        }
    }
}
