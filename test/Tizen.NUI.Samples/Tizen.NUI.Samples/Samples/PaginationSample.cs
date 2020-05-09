using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class PaginationSample : IExample
    {
        private TextLabel board1, board2;
        private Pagination pagination1;
        private Pagination pagination2;
        private View root;
        private View parent1, parent2;

        private readonly int PAGE_COUNT = 5;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            window.Add(root);
            window.KeyEvent += Window_KeyEvent;

            parent1 = new View()
            {
                Position = new Position(500, 400),
                Size = new Size(700, 70)
            };
            var parent1layout = new LinearLayout();
            parent1layout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            parent1layout.LinearAlignment = LinearLayout.Alignment.Bottom;
            parent1layout.CellPadding = new Size(20, 50);
            parent1.Layout = parent1layout;
            root.Add(parent1);

            parent2 = new View()
            {
                Position = new Position(500, 500),
                Size = new Size(700, 70)
            };
            var parent2layout = new LinearLayout();
            parent2layout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            parent2layout.LinearAlignment = LinearLayout.Alignment.Bottom;
            parent2layout.CellPadding = new Size(20, 50);
            parent2.Layout = parent2layout;
            root.Add(parent2);

            createBorads();

            ///////////////////////////////////////////////Create by Properties//////////////////////////////////////////////////////////
            pagination1 = new Pagination();
            pagination1.Name = "Pagination1";
            pagination1.Position = new Position(800, 430);
            pagination1.Size = new Size(300, 50);
            pagination1.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination1.IndicatorSize = new Size(26, 26);
            var indicatorImageUrlStyle = new PaginationStyle()
            {
                IndicatorImageURL = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png"
                }
            };
            pagination1.ApplyStyle(indicatorImageUrlStyle);
            pagination1.IndicatorSpacing = 8;
            pagination1.IndicatorCount = PAGE_COUNT;
            pagination1.SelectedIndex = 0;
            parent1.Add(pagination1);

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
            pagination2 = new Pagination(style);
            pagination2.Name = "Pagination2";
            pagination2.Position = new Position(800, 530);
            pagination2.Size = new Size(300, 50);
            pagination2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination2.IndicatorCount = PAGE_COUNT;
            pagination2.SelectedIndex = 0;
            parent2.Add(pagination2);
        }

        void createBorads()
        {
            board1 = new TextLabel();
            board1.Size = new Size(200, 50);
            board1.Position = new Position(450, 400);
            board1.PointSize = 15;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "By Prop. : ";
            parent1.Add(board1);

            board2 = new TextLabel();
            board2.Size = new Size(200, 50);
            board2.Position = new Position(450, 500);
            board2.PointSize = 15;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "By Attr. : ";
            parent2.Add(board2);
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

            if (root != null)
            {
                parent1.Remove(board1);
                board1.Dispose();
                board1 = null;

                parent1.Remove(pagination1);
                pagination1.Dispose();
                pagination1 = null;

                root.Remove(parent1);
                parent1.Dispose();
                parent1 = null;

                parent2.Remove(board2);
                board2.Dispose();
                board2 = null;

                parent2.Remove(pagination2);
                pagination2.Dispose();
                pagination2 = null;

                root.Remove(parent2);
                parent2.Dispose();
                parent2 = null;

                window.Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
