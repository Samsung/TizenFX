using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationUniverse : IExample
    {
        private Color [] VIEW_TITLE_COLOR = {
            new Color(38.0f/255.0f, 169.0f/255.0f, 242.0f/255.0f, 1.0f),
            new Color(177.0f/255.0f, 177.0f/255.0f, 177.0f/255.0f, 1.0f),
            new Color(241.0f/255.0f, 173.0f/255.0f, 63.0f/255.0f, 1.0f),
            new Color(232.0f/255.0f, 130.0f/255.0f, 101.0f/255.0f, 1.0f),
            new Color(233.0f/255.0f, 221.0f/255.0f, 198.0f/255.0f, 1.0f),
        };
        private string [] VIEW_TITLE = {
            "Earth", "Moon", "Sun", "Jupiter", "Venus",
        };
        private string [] VIEW_TEXT = {
        "Earth is the third planet from the sun.",
        "Moon is Earth's only natural satellite.",
        "Sun is the star at the center of the Solar System.",
        "Jupiter the fifth planet from the Sun.",
        "Venus is the second planet from the Sun."
        };
        private string [] VIEW_BG_PATH = {
            Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImageFirst.png",
            Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImage.png",
            Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImage.png",
            Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImage.png",
            Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImageEnd.png"
        };
        Position [] VIEW_POSITION = {
            new Position(0, 0),
            new Position(0, 310),
            new Position(0, 610),
            new Position(0, 910),
            new Position(0, 1210),
        };
        Size [] VIEW_SIZE = {
            new Size(720, 310),
            new Size(720, 300),
            new Size(720, 300),
            new Size(720, 300),
            new Size(720, 310),
        };
        bool [] viewBgClicked = {false, false, false, false, false};
        string VIEW_BG_CLICKED_PATH = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/ViewItemBgImageFirstClicked.png";

        private Window window;
        private Layer defaultLayer;
        private Tizen.NUI.Extension.RiveAnimationView rav;
        private TextLabel header;
        private Components.ScrollableBase scroll;
        private View[] viewItems;
        private float ravCenterY;
        private bool isMoving;
        private Position startPos;
        private Position scrollPos;
        private float preScrollPositionY;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();
            window.TouchEvent += OnRiveWindowTouchEvent;

            // Load RiveAnimation File
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/space_reload.riv")
            {
                Size = new Size(720, 500),
                Position = new Position(0, 72)
            };

            scroll = new Components.ScrollableBase()
            {
                Position = new Position(0, 120),
                Size = new Size(720, 1160),
                ScrollingDirection = Components.ScrollableBase.Direction.Vertical,
                EnableOverShootingEffect = true,
                HideScrollbar = true,
                ScrollEnabled = false
            };
            scroll.Scrolling += Scrolling;

            header = new TextLabel
            {
                Text = "Universe",
                Position = new Position(0, 0),
                Size = new Size(720, 120),
                BackgroundColor = new Color(52.0f/255.0f, 43.0f/255.0f, 117.0f/255.0f, 1.0f),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                PointSize = 20.0f,
                
            };

            viewItems = new View[5];
            for (int i = 0; i < 5; i++)
            {
                viewItems[i] = new View
                {
                    Position = VIEW_POSITION[i],
                    Size = VIEW_SIZE[i],
                    BackgroundImage = VIEW_BG_PATH[i],
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        LinearAlignment = LinearLayout.Alignment.Center,
                        CellPadding = new Size(40, 0)
                    }
                };

                TextLabel title = new TextLabel
                {
                    Size = new Size(550, 70),
                    PointSize = 12.0f,    
                    Text = VIEW_TITLE[i],
                    TextColor = VIEW_TITLE_COLOR[i]
                };

                TextLabel text = new TextLabel
                {
                    Size = new Size(550, 100),
                    PointSize = 9.0f,
                    MultiLine = true,
                    Text = VIEW_TEXT[i],
                    TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f)
                };

                if (i==0)
                    viewItems[i].TouchEvent += OnChangeEarthColor;
                else if(i==1)
                    viewItems[i].TouchEvent += OnChangeMoonColor;
                else if(i==2)
                    viewItems[i].TouchEvent += OnChangeSunColor;
                else if(i==3)
                    viewItems[i].TouchEvent += OnChangeJupiterColor;

                viewItems[i].Add(title);
                viewItems[i].Add(text);
                scroll.Add(viewItems[i]);
            }

            defaultLayer.Add(rav);
            defaultLayer.Add(scroll);
            defaultLayer.Add(header);

            // Enable RiveAnimation and Play
            rav.EnableAnimation("Idle", true);
            rav.Play();
        }
        private void Scrolling(object sender, Components.ScrollEventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                viewItems[i].BackgroundImage = VIEW_BG_PATH[i];
            }
        }

        [global::System.Obsolete]
        private void OnRiveWindowTouchEvent(object source, Window.TouchEventArgs e)
        {
            Vector2 sp = e.Touch.GetScreenPosition(0);
            PointStateType state = e.Touch.GetState(0);
            Position screenPos = new Position(sp.X, sp.Y);

            if (!scroll.ScrollEnabled)
            {
                if (state == PointStateType.Down)
                {
                    startPos = screenPos;
                    scrollPos = scroll.Position;
                }
                Position diff = screenPos - startPos;
                scroll.PositionX = 0.0f;
                float minmaxY = scrollPos.Y + diff.Y;

                if (minmaxY > 520)
                {
                    scroll.PositionY = 520;
                }
                else if(minmaxY <= 120)
                {
                    scroll.PositionY = 120;
                }
                else
                {
                    scroll.PositionY = minmaxY;
                }
            
                float time = (scroll.PositionY - 120 ) / 400;

                // Set RiveAnimation Elapsed Time using View Position
                rav.SetAnimationElapsedTime("Pull", time);

               if (time < 1.0)
               {
                   isMoving = true;
                   // Disable RiveAnimations
                   rav.EnableAnimation("Trigger", false);
                   rav.EnableAnimation("Loading", false);
               }
               else if (time >= 1.0 && isMoving)
               {
                   isMoving = false;
                   // Enable RiveAnimations   
                   rav.EnableAnimation("Trigger", true);
                   rav.EnableAnimation("Loading", true);
                   scroll.ScrollEnabled = true;
                   scroll.Size = new Size(720, 760);
               }
            }
            else
            {
                if (preScrollPositionY == 0)
                {
                    float diff = scroll.ScrollPosition.Y - preScrollPositionY;
                    if (diff > 5)
                    {
                        scroll.ScrollTo(0, false);
                        scroll.ScrollEnabled = false;
                        scroll.Size = new Size(720, 1160);
                        for (int i = 0; i < 5; i++)
                        {
                            viewItems[i].BackgroundImage = VIEW_BG_PATH[i];
                        }
                    }
                }
                preScrollPositionY = scroll.ScrollPosition.Y;
            }
            ravCenterY = (120.0f + scroll.Position.Y) / 2;
            rav.PositionX = 0.0f;
            rav.PositionY = ravCenterY - 248.0f;
        }

        private bool OnChangeEarthColor(object source, View.TouchEventArgs e)
        {
            PointStateType GetState = e.Touch.GetState(0);
            Vector2 item = e.Touch.GetLocalPosition(0);
            if (scroll.ScrollEnabled && item.Y > 30)
            {
                if (GetState == PointStateType.Down)
                {
                    viewBgClicked[0] = !viewBgClicked[0];
                    viewItems[0].BackgroundImage = VIEW_BG_CLICKED_PATH;
                    if (viewBgClicked[0])
                    {
                        // Set Earth Fill Color
                        rav.SetShapeFillColor("EarthColor", new Color(245.0f/255.0f, 117.0f/255.0f, 220.0f/255.0f, 1.0f));
                    }
                    else
                    {
                        // Set Earth Fill Color
                        rav.SetShapeFillColor("EarthColor", new Color(38.0f/255.0f, 169.0f/255.0f, 242.0f/255.0f, 1.0f));
                    }
                }
                if (GetState == PointStateType.Up)
                {
                    viewItems[0].BackgroundImage = VIEW_BG_PATH[0];
                }
            }
            return false;
        }

        private bool OnChangeMoonColor(object source, View.TouchEventArgs e)
        {
            PointStateType GetState = e.Touch.GetState(0);
            Vector2 item = e.Touch.GetLocalPosition(0);
            if (scroll.ScrollEnabled && item.Y > 30)
            {
                if (GetState == PointStateType.Down)
                {
                    viewBgClicked[1] = !viewBgClicked[1];
                    viewItems[1].BackgroundImage = VIEW_BG_CLICKED_PATH;
                    if (viewBgClicked[1])
                    {
                        // Set Moon Fill Color
                        rav.SetShapeFillColor("MoonColor", new Color(245.0f/255.0f, 117.0f/255.0f, 220.0f/255.0f, 1.0f));
                        rav.SetShapeFillColor("MoonShadowColor", new Color(225.0f/255.0f, 107.0f/255.0f, 200.0f/255.0f, 1.0f));
                    }
                    else
                    {
                        // Set Moon Fill Color
                        rav.SetShapeFillColor("MoonColor", new Color(177.0f/255.0f, 177.0f/255.0f, 177.0f/255.0f, 1.0f));
                        rav.SetShapeFillColor("MoonShadowColor", new Color(141.0f/255.0f, 141.0f/255.0f, 141.0f/255.0f, 1.0f));
                    }
                }
                if (GetState == PointStateType.Up)
                {
                    viewItems[1].BackgroundImage = VIEW_BG_PATH[1];
                }
            }
            return false;
        }

        private bool OnChangeSunColor(object source, View.TouchEventArgs e)
        {
            PointStateType GetState = e.Touch.GetState(0);
            Vector2 item = e.Touch.GetLocalPosition(0);
            if (scroll.ScrollEnabled && item.Y > 30)
            {
                if (GetState == PointStateType.Down)
                {
                    viewBgClicked[2] = !viewBgClicked[2];
                    viewItems[2].BackgroundImage = VIEW_BG_CLICKED_PATH;
                    if(viewBgClicked[2])
                    {
                        // Set Sun Fill Color
                        rav.SetShapeFillColor("SunColor", new Color(245.0f/255.0f, 117.0f/255.0f, 220.0f/255.0f, 1.0f));
                    }
                    else
                    {
                        // Set Sun Fill Color
                        rav.SetShapeFillColor("SunColor", new Color(241.0f/255.0f, 173.0f/255.0f, 63.0f/255.0f, 1.0f));
                    }
                }
                if (GetState == PointStateType.Up)
                {
                    viewItems[2].BackgroundImage = VIEW_BG_PATH[2];
                }
            }
            return false;
        }

        private bool OnChangeJupiterColor(object source, View.TouchEventArgs e)
        {
            PointStateType GetState = e.Touch.GetState(0);
            Vector2 item = e.Touch.GetLocalPosition(0);
            if (scroll.ScrollEnabled && item.Y > 30)
            {   
                if (GetState == PointStateType.Down)
                {
                    viewBgClicked[3] = !viewBgClicked[3];
                    viewItems[3].BackgroundImage = VIEW_BG_CLICKED_PATH;
                    if(viewBgClicked[3])
                    {
                        // Set Jupiter Fill Color
                        rav.SetShapeFillColor("JupiterColor", new Color(245.0f/255.0f, 117.0f/255.0f, 220.0f/255.0f, 1.0f));
                    }
                    else
                    {
                        // Set Jupiter Fill Color
                        rav.SetShapeFillColor("JupiterColor", new Color(232.0f/255.0f, 130.0f/255.0f, 101.0f/255.0f, 1.0f));
                    }
                }
                if (GetState == PointStateType.Up)
                {
                    viewItems[3].BackgroundImage = VIEW_BG_PATH[3];
                }
            }
            return false;
        }

        public void Deactivate()
        {
            window.TouchEvent -= OnRiveWindowTouchEvent;
            if (rav) { defaultLayer.Remove(rav); }
            if (scroll) { defaultLayer.Remove(scroll); }
            if (header) { defaultLayer.Remove(header); }
        }
    }
}
