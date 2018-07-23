using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Sample
{
    public class AmbientScreenUXControl : NUIApplication
    {
        static private string imagePath = "E:\\Dali\\dali-windows-backend\\csharp-demo\\res\\images\\Ambient Screen UX Control\\";
        private ImageView bgImg;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window.Instance.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);

            bgImg = new ImageView();
            bgImg.SetImage(imagePath + "bg.png");
            bgImg.PivotPoint = PivotPoint.TopLeft;
            bgImg.ScaleX = 0.5f;
            bgImg.ScaleY = 0.5f;

            Window.Instance.Add(bgImg);

            Window.Instance.KeyEvent += AppBack;
        }

        private void AppBack(object source, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape")
                {
                    Window.Instance.Dispose();
                    this.Exit();
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    new OOBE(bgImg);
                }
            }
        }
    }
}
