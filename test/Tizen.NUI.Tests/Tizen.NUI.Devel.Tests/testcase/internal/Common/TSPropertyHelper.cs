using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PropertyHelper")]
    public class InternalPropertyHelperTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
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
        [Description("PropertyHelper GetPropertyFromString.")]
        [Property("SPEC", "Tizen.NUI.PropertyHelper.GetPropertyFromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyHelperGetPropertyFromString()
        {
            tlog.Debug(tag, $"PropertyHelperGetPropertyFromString START");

            using (ImageView imageView = new ImageView())
            {
                imageView.SetProperty(ImageView.Property.IMAGE, new PropertyValue(url));

                var testingTarget = PropertyHelper.GetPropertyFromString(imageView, "image");
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<Property>(testingTarget, "Should be an Instance of Property!");

                testingTarget.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PropertyHelperGetPropertyFromString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyHelper Search.")]
        [Property("SPEC", "Tizen.NUI.PropertyHelper.Search M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyHelperSearch()
        {
            tlog.Debug(tag, $"PropertyHelperSearch START");

            using (ImageView imageView = new ImageView())
            {
                imageView.Opacity = 0.3f;
                imageView.SetProperty(ImageView.Property.IMAGE, new PropertyValue(url));

                var testingTarget = PropertyHelper.Search(imageView, "image");
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PropertyHelper.SearchResult>(testingTarget, "Should be an Instance of SearchResult!");

                // view.GetPropertyType(property.propertyIndex).Equals(PropertyType.Float)
                var testingTarget2 = PropertyHelper.Search(imageView, "opacity");
                Assert.IsNotNull(testingTarget2, "Should be not null!");
                Assert.IsInstanceOf<PropertyHelper.SearchResult>(testingTarget2, "Should be an Instance of SearchResult!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PropertyHelperSearch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyHelper SearchVisualProperty.")]
        [Property("SPEC", "Tizen.NUI.PropertyHelper.SearchVisualProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyHelperSearchVisualProperty()
        {
            tlog.Debug(tag, $"PropertyHelperSearchVisualProperty START");

            using (ImageView ani = new ImageView())
            {
                ani.BackgroundColor = Color.Cyan;

                var testingTarget = PropertyHelper.Search(ani, "backgroundColor");
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PropertyHelper.SearchResult>(testingTarget, "Should be an Instance of SearchResult!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PropertyHelperSearchVisualProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyHelper.SearchResult RefineValue.")]
        [Property("SPEC", "Tizen.NUI.PropertyHelper.SearchResult.RefineValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyHelperSearchResultRefineValue()
        {
            tlog.Debug(tag, $"PropertyHelperSearchResultRefineValue START");

            using (ImageView imageView = new ImageView())
            {
                imageView.SetProperty(ImageView.Property.IMAGE, new PropertyValue(new Position(0, 0)));
                PropertyHelper.SearchResult result = PropertyHelper.Search(imageView, "position");

                try
                {
                    var testingTarget = result.RefineValue(new Position(100, 150));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"PropertyHelperSearchResultRefineValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyHelper.SearchResult RefineKeyFrames.")]
        [Property("SPEC", "Tizen.NUI.PropertyHelper.SearchResult.RefineKeyFrames M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyHelperSearchResultRefineKeyFrames()
        {
            tlog.Debug(tag, $"PropertyHelperSearchResultRefineKeyFrames START");

            using (ImageView imageView = new ImageView())
            {
                imageView.SetProperty(ImageView.Property.IMAGE, new PropertyValue(new Position(0, 0)));
                PropertyHelper.SearchResult result = PropertyHelper.Search(imageView, "position");

                try
                {
                    var testingTarget = result.RefineKeyFrames(new KeyFrames());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"PropertyHelperSearchResultRefineKeyFrames END (OK)");
        }
    }
}
