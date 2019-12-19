using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class LottieAnimationSample : IExample
    {
        LottieAnimationView lav;
        public void Activate()
        {
            lav = new LottieAnimationView();
            lav.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "a.json";
            lav.LoopCount = -1;
            lav.BackgroundColor = Color.White;
            Window.Instance.GetDefaultLayer().Add(lav);
            lav.Play();
        }
        public void Deactivate()
        {
            Window.Instance.GetDefaultLayer().Remove(lav);
        }
    }
}
