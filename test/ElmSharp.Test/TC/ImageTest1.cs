using System;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class ImageTest1 : TestCaseBase
    {
        public override string TestName => "ImageTest1";
        public override string TestDescription => "To test basic operation of Image";

        public override void Run(Window window)
        {
            Image image = new Image(window)
            {
                IsFixedAspect = false
            };
            image.Load("/home/owner/res/picture.png");
            image.Clicked += (e, o) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true?false:true;
            };

            image.Show();
            image.Resize(500, 500);
            image.Move(100,100);
        }
    }
}
