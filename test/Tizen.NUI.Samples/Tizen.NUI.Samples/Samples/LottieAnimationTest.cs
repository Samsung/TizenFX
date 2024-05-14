using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class LottieAnimationTest : IExample
    {
        LottieAnimationView lav;
        public void Activate()
        {
            lav = new LottieAnimationView();
            lav.SynchronousLoading = false;
            lav.NotifyAfterRasterization = true;
            lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "a.json";
            lav.LoopCount = -1;
            lav.BackgroundColor = Color.White;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(lav);
            Tizen.Log.Error("NUI", $"Total frame before resource ready : {lav.TotalFrame} / might be 0 if still load images. or, might be valid value if load finished during above logic running.\n");

            lav.ResourceReady += (o, e) =>
            {
                if (lav.LoadingStatus == ImageView.LoadingStatusType.Failed)
                {
                    Tizen.Log.Error("NUI", $"Load failed!\n");
                }
                else
                {
                    Tizen.Log.Error("NUI", $"Total frame after resource ready : {lav.TotalFrame}\n");
                    lav.Play();
                }
            };
        }
        public void Deactivate()
        {
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(lav);
        }
    }
}
