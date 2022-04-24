using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/FlexibleViewAdapter")]
    public class FlexibleViewAdapterTest
    {
        private const string tag = "NUITEST";

        private Vector2 scrnSize;
        private ListBridge adapter;
        private FlexibleView horizontalFlexibleView;
        private LinearLayoutManager horizontalLayoutManager;
    }

    [TearDown]
    public void Destroy()
    {
        scrnSize?.Dispose();
        tlog.Info(tag, "Destroy() is called!");
    }

    private FlexibleView GetHorizontalFlexibleView()
    {
        horizontalFlexibleView = new FlexibleView();
        Assert.IsNotNull(horizontalFlexibleView, "should be not null");
        Assert.IsInstanceOf<FlexibleView>(horizontalFlexibleView, "should be an instance of testing target class!");

        horizontalFlexibleView.Name = "FlexibleView";
        horizontalFlexibleView.WidthSpecification = 400;
        horizontalFlexibleView.HeightSpecification = 450;
        horizontalFlexibleView.Padding = new Extents(10, 10, 10, 10);
        horizontalFlexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

        List<ListItemData> dataList = new List<ListItemData>();
        for (int i = 0; i < 4; ++i)
        {
            dataList.Add(new ListItemData(i));
        }
        adapter = new ListBridge(dataList);
        horizontalFlexibleView.SetAdapter(adapter);
        horizontalFlexibleView.OnRelayout(scrnSize, null);

        horizontalLayoutManager = new LinearLayoutManager(LinearLayoutManager.HORIZONTAL);
        horizontalFlexibleView.SetLayoutManager(horizontalLayoutManager);
        horizontalFlexibleView.OnRelayout(scrnSize, null);

        return horizontalFlexibleView;
    }

    [Test]
    [Category("P1")]
    [Description("FlexibleViewAdapter NotifyItemChanged.")]
    [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FlexibleViewAdapter.NotifyItemChanged M")]
    [Property("SPEC_URL", "-")]
    [Property("CRITERIA", "MR")]
    [Property("COVPARAM", "")]
    [Property("AUTHOR", "guowei.wang@samsung.com")]
    public void FlexibleViewAdapterNotifyItemChanged()
    {
        tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemChanged START");

        var testingTarget = GetHorizontalFlexibleView();
        Assert.IsNotNull(testingTarget, "should be not null");
        Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

        try
        {
            testingTarget.GetAdapter().NotifyItemChanged(2);
        }
        catch (Exception e)
        {
            tlog.Debug(tag, e.Message.ToString());
            Assert.Fail("Caught Exception : Failed!");
        }

        testingTarget.Dispose();
        tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemChanged END (OK)");
    }

    [Test]
    [Category("P1")]
    [Description("FlexibleViewAdapter NotifyItemRangeChanged.")]
    [Property("SPEC", "Tizen.NUI.Components.FlexibleView.FlexibleViewAdapter.NotifyItemRangeChanged M")]
    [Property("SPEC_URL", "-")]
    [Property("CRITERIA", "MR")]
    [Property("COVPARAM", "")]
    [Property("AUTHOR", "guowei.wang@samsung.com")]
    public void FlexibleViewAdapterNotifyItemRangeChanged()
    {
        tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemRangeChanged START");

        var testingTarget = GetHorizontalFlexibleView();
        Assert.IsNotNull(testingTarget, "should be not null");
        Assert.IsInstanceOf<FlexibleView>(testingTarget, "should be an instance of testing target class!");

        try
        {
            testingTarget.GetAdapter().NotifyItemRangeChanged(2, 2);
        }
        catch (Exception e)
        {
            tlog.Debug(tag, e.Message.ToString());
            Assert.Fail("Caught Exception : Failed!");
        }

        testingTarget.Dispose();
        tlog.Debug(tag, $"FlexibleViewAdapterNotifyItemRangeChanged END (OK)");
    }
}
