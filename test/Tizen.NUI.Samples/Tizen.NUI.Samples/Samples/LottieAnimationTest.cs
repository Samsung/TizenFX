using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class LottieAnimationTest : IExample
    {
        LottieAnimationView lav;
        public void Activate()
        {
            lav = new LottieAnimationView();
            lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "a.json";
            lav.LoopCount = -1;
            lav.BackgroundColor = Color.White;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(lav);
            lav.Play();
        }
        public void Deactivate()
        {
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(lav);
        }
    }
}
