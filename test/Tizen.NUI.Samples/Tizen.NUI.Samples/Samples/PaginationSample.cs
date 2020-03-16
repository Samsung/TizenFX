﻿using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class PaginationSample : IExample
    {
        private Pagination pagination1;
        private Pagination pagination2;

        private readonly int PAGE_COUNT = 5;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            ///////////////////////////////////////////////Create by Properties//////////////////////////////////////////////////////////
            pagination1 = new Pagination();
            pagination1.Name = "Pagination1";
            pagination1.Position2D = new Position2D(500, 450);
            pagination1.Size2D = new Size2D(400, 30);
            pagination1.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination1.IndicatorSize = new Size(26, 26);
            pagination1.IndicatorImageURL = new Selector<string>()
            {
                Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
            };
            pagination1.IndicatorSpacing = 8;
            pagination1.IndicatorCount = PAGE_COUNT;
            pagination1.SelectedIndex = 0;
            window.Add(pagination1);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            PaginationStyle style = new PaginationStyle();
            style.IndicatorSize = new Size(15, 15);
            style.IndicatorImageURL = new Selector<string>()
            {
                Normal = CommonResource.GetTVResourcePath() + "component/c_pagination/c_paganation_medium_dot_normal.png",
                Selected = CommonResource.GetTVResourcePath() + "component/c_pagination/c_paganation_medium_dot_focus.png",
            };
            style.IndicatorSpacing = 14;
            pagination2 = new Pagination(style);
            pagination2.Name = "Pagination2";
            pagination2.Position2D = new Position2D(500, 500);
            pagination2.Size2D = new Size2D(400, 30);
            pagination2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination2.IndicatorCount = PAGE_COUNT;
            pagination2.SelectedIndex = 0;
            window.Add(pagination2);

            window.KeyEvent += Window_KeyEvent;
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (pagination1.SelectedIndex > 0)
                    {
                        pagination1.SelectedIndex = pagination1.SelectedIndex - 1;
                    }
                    if (pagination2.SelectedIndex > 0)
                    {
                        pagination2.SelectedIndex = pagination2.SelectedIndex - 1;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (pagination1.SelectedIndex < pagination1.IndicatorCount - 1)
                    {
                        pagination1.SelectedIndex = pagination1.SelectedIndex + 1;
                    }
                    if (pagination2.SelectedIndex < pagination2.IndicatorCount - 1)
                    {
                        pagination2.SelectedIndex = pagination2.SelectedIndex + 1;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.KeyEvent -= Window_KeyEvent;
            window.Remove(pagination1);
            window.Remove(pagination2);

            pagination1.Dispose();
            pagination2.Dispose();
        }
    }
}
