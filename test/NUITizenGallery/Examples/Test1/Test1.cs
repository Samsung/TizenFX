using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class Test1 : IExample
    {
        private Window window;
        private Test1Page page;
        private Animation animation;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new Test1Page();

            window.Add(page);

            animation = new Animation(2000);
            animation.AnimateTo(page.test1PageText, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
            animation.AnimateTo(page.test1PageText, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
            animation.Looping = true;
            animation.Play();
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            animation.Clear();
            page.Unparent();
            page.Dispose();
        }
    }
}
