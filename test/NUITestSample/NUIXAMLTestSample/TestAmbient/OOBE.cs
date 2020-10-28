using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Sample
{
    class OOBE
    {
        static private string imagePath = "E:\\Dali\\dali-windows-backend\\csharp-demo\\res\\images\\Ambient Screen UX Control\\";

        private ImageView[] cardImages = null;
        private Vector2[] positionOfCard = null;

        private Animation[] alphaAni = null;
        public OOBE(View root)
        {
            if (null == positionOfCard)
            {
                positionOfCard = new Vector2[3];

                positionOfCard[0] = new Vector2(3239.0f, 1762.0f);
                positionOfCard[1] = new Vector2(3353.0f, 1662.0f);
                positionOfCard[2] = new Vector2(3430, 1562.0f);
            }

            if (null == cardImages)
            {
                cardImages = new ImageView[3];

                for (int i = 2; i >= 0; i--)
                {
                    cardImages[i] = new ImageView();
                    cardImages[i].BackgroundColor = Color.Transparent;
                    cardImages[i].SetImage(imagePath + "Cut/card" + (i + 1) + ".png");
                    cardImages[i].Position2D = positionOfCard[i];
                    cardImages[i].PivotPoint = PivotPoint.TopLeft;
                    cardImages[i].Opacity = 0.0f;

                    root.Add(cardImages[i]);
                }
            }

            if (null == alphaAni)
            {
                alphaAni = new Animation[3];

                for (int i = 0; i < 3; i++)
                {
                    alphaAni[i] = new Animation(500);
                    alphaAni[i].AnimateTo(cardImages[i], "Opacity", 1.0f, 0, i * 100);
                    alphaAni[i].Play();
                }
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < 3; i++)
            {
                cardImages[i].Dispose();

                cardImages[i] = null;
            }

            cardImages = null;
        }
    }
}
