using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class PaginationSample : IExample
    {
        private TextLabel[] board = new TextLabel[2];
        private Pagination[] pagination = new Pagination[2];
        private View[] layout = new View[3];

        private readonly int PAGE_COUNT = 5;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            // Root layout.
            layout[0] = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            layout[0].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size(20, 50)
            };
            window.Add(layout[0]);
            window.KeyEvent += Window_KeyEvent;

            // A pagination sample created by properties will be added to this layout.
            layout[1]= new View()
            {
                Size = new Size(700, 70),
            };
            layout[1].Layout = new LinearLayout() 
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size(20, 50)
            };
            layout[0].Add(layout[1]);

            // A pagination sample created by attributes will be added to this layout.
            layout[2] = new View()
            {
                Size = new Size(700, 70),
            };
            layout[2].Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size(20, 50)
            };
            layout[0].Add(layout[2]);

            createBorads();

            ///////////////////////////////////////////////Create by Properties//////////////////////////////////////////////////////////
            pagination[0] = new Pagination();
            pagination[0].Name = "Pagination1";
            pagination[0].Size = new Size(300, 50);
            pagination[0].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination[0].IndicatorSize = new Size(26, 26);
            var indicatorImageUrlStyle = new PaginationStyle()
            {
                IndicatorImageURL = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png"
                }
            };
            pagination[0].ApplyStyle(indicatorImageUrlStyle);
            pagination[0].IndicatorSpacing = 8;
            pagination[0].IndicatorCount = PAGE_COUNT;
            pagination[0].SelectedIndex = 0;
            layout[1].Add(pagination[0]);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            PaginationStyle style = new PaginationStyle()
            {
                IndicatorSize = new Size(15, 15),
                IndicatorSpacing = 20,
                IndicatorImageURL = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png"
                }
            };
            pagination[1] = new Pagination(style);
            pagination[1].Name = "Pagination2";
            pagination[1].Size = new Size(300, 50);
            pagination[1].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination[1].IndicatorCount = PAGE_COUNT;
            pagination[1].SelectedIndex = 0;
            layout[2].Add(pagination[1]);
        }

        void createBorads()
        {
            board[0] = new TextLabel();
            board[0].Size = new Size(300, 50);
            board[0].PointSize = 15;
            board[0].HorizontalAlignment = HorizontalAlignment.Center;
            board[0].VerticalAlignment = VerticalAlignment.Center;
            board[0].BackgroundColor = Color.Magenta;
            board[0].Text = "Property construction";
            layout[1].Add(board[0]);

            board[1] = new TextLabel();
            board[1].Size = new Size(300, 50);
            board[1].PointSize = 15;
            board[1].HorizontalAlignment = HorizontalAlignment.Center;
            board[1].VerticalAlignment = VerticalAlignment.Center;
            board[1].BackgroundColor = Color.Magenta;
            board[1].Text = "Attribute construction";
            layout[2].Add(board[1]);
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    if (pagination[0].SelectedIndex > 0)
                    {
                        pagination[0].SelectedIndex = pagination[0].SelectedIndex - 1;
                    }
                    if (pagination[1].SelectedIndex > 0)
                    {
                        pagination[1].SelectedIndex = pagination[1].SelectedIndex - 1;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    if (pagination[0].SelectedIndex < pagination[0].IndicatorCount - 1)
                    {
                        pagination[0].SelectedIndex = pagination[0].SelectedIndex + 1;
                    }
                    if (pagination[1].SelectedIndex < pagination[1].IndicatorCount - 1)
                    {
                        pagination[1].SelectedIndex = pagination[1].SelectedIndex + 1;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.KeyEvent -= Window_KeyEvent;

            if (layout[0] != null)
            {
                layout[1].Remove(board[0]);
                board[0].Dispose();
                board[0] = null;

                layout[1].Remove(pagination[0]);
                pagination[0].Dispose();
                pagination[0] = null;

                layout[0].Remove(layout[1]);
                layout[1].Dispose();
                layout[1] = null;

                layout[2].Remove(board[1]);
                board[1].Dispose();
                board[1] = null;

                layout[2].Remove(pagination[1]);
                pagination[1].Dispose();
                pagination[1] = null;

                layout[0].Remove(layout[2]);
                layout[2].Dispose();
                layout[2] = null;

                window.Remove(layout[0]);
                layout[0].Dispose();
                layout[0] = null;
            }
        }
    }
}
