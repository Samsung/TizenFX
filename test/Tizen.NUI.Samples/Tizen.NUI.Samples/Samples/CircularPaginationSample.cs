//using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Wearable;

namespace Tizen.NUI.Samples
{
    public class CircularPaginationSample : IExample
    {
        private CircularPagination circular;
        private CircularPagination homeCircular;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////// Symmetrical Circular Pagination ///////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            circular = new CircularPagination();
            circular.Position2D = new Position2D(50, 20);
            circular.Size2D = new Size2D(360, 360);
            circular.BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.6f);
            circular.IndicatorSize = new Size(26, 26);
            circular.IndicatorImageURL = new Selector<string>()
            {
                Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
            };

            circular.IndicatorCount = 19;

            //circular.SelectedIndex = 0;

            window.Add(circular);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////// Asymmetrical Circular Pagination ///////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            homeCircular = new CircularPagination();
            //homeCircular.Position2D = new Position2D(50, 410);
            homeCircular.Size2D = new Size2D(360, 360);
            homeCircular.BackgroundColor = new Color(0.7f, 0.7f, 0.7f, 0.6f);

            homeCircular.ParentOrigin = ParentOrigin.Center;
            homeCircular.PivotPoint = PivotPoint.Center;
            homeCircular.PositionUsesPivotPoint = true;
            homeCircular.IndicatorSize = new Size(26, 26);
            homeCircular.IndicatorImageURL = new Selector<string>()
            {
                Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
            };

            // If you want to set the center indicator image differently from other indicators,
            // Use CenterIndicatorImageURL like below. (for example, home indicator clock picker)
            homeCircular.CenterIndicatorImageURL = new Selector<string>()
            {
                Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_slide_handler_press.png",
                Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
            };

            homeCircular.IsSymmetrical = false;
            homeCircular.RightIndicatorCount = 5;
            homeCircular.LeftIndicatorCount = 2;

            //homeCircular.SetIndicatorPosition(0, new Position(111, 11));
            //homeCircular.SetIndicatorPosition(2, new Position(222, 73));

            //homeCircular.SelectedIndex = 0;

            window.Add(homeCircular);

            window.KeyEvent += Window_KeyEvent;
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (circular.SelectedIndex > 0)
                    {
                        circular.SelectedIndex = circular.SelectedIndex - 1;
                    }
                    if (homeCircular.SelectedIndex > 0)
                    {
                        homeCircular.SelectedIndex = homeCircular.SelectedIndex - 1;
                    }

                    /*for(int i = 0; i < 7; i++)
                    {
                        Position pos = homeCircular.GetIndicatorPosition(i);
                        Tizen.Log.Error("NUI", "home circular index : "+i+", pos x :"+pos.X+", y :"+pos.Y+"\n");
                    }*/
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (circular.SelectedIndex < circular.IndicatorCount - 1)
                    {
                        circular.SelectedIndex = circular.SelectedIndex + 1;
                    }
                    if (homeCircular.SelectedIndex < homeCircular.IndicatorCount - 1)
                    {
                        homeCircular.SelectedIndex = homeCircular.SelectedIndex + 1;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= Window_KeyEvent;
            window.Remove(circular);
            window.Remove(homeCircular);

            circular.Dispose();
            homeCircular.Dispose();
        }
    }
}
