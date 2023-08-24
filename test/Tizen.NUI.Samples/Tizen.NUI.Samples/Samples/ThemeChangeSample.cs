using System;
using System.Linq;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.Applications.ThemeManager;

namespace Tizen.NUI.Samples
{
    public class ThemeChangeSample : IExample
    {
        private ThemeLoader themeLoader;

        public void Activate()
        {
            themeLoader = new ThemeLoader();

            var mainPage = new ContentPage()
            {
                ThemeChangeSensitive = true,
                AppBar = new AppBar()
                {
                    AutoNavigationContent = false,
                    Title = "NUI theme sample",
                    //Actions = new View[] { closeButton },
                },
                Content = new ScrollableBase()
                {
                    Layout = new LinearLayout()
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        CellPadding = new Size2D(20, 20)
                    },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    Padding = new Extents(30, 30, 20, 20)
                }
            };

            string[] ids = (string[])themeLoader.QueryIds();
            if (ids != null && ids.Contains("org.tizen.default-dark-theme") || ids.Contains("org.tizen.default-light-theme"))
            {
                var title = $"Current theme: {(themeLoader.CurrentTheme.Id == "org.tizen.default-dark-theme" ? "Dark" : "Light")}";

                mainPage.Content.Add(CreateClickableItem("Theme change", title, delegate (View view)
                {
                    TextLabel text = view.Children[1] as TextLabel;

                    if (themeLoader.CurrentTheme.Id == "org.tizen.default-dark-theme")
                    {
                        var theme = themeLoader.LoadTheme("org.tizen.default-light-theme");
                        Tizen.Log.Info("test", $"Id: {theme.Id}, Version: {theme.Version}");
                        themeLoader.CurrentTheme = theme;
                        text.Text = "Current theme: Light";
                    }
                    else
                    {
                        var theme = themeLoader.LoadTheme("org.tizen.default-dark-theme");
                        Tizen.Log.Info("test", $"Id: {theme.Id}, Version: {theme.Version}");
                        themeLoader.CurrentTheme = theme;
                        text.Text = "Current theme: Dark";
                    }
                }));

                mainPage.Content.Add(CreateItem("Switch", CreateSwitchExample()));
            }
            else
            {
                mainPage.AppBar.Title = "No proper theme is found!";
            }

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(mainPage);
        }

        public void Deactivate()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();

            themeLoader.Dispose();
            themeLoader = null;
        }

        private View CreateItem(string title, View content)
        {
            var item = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                BackgroundColor = new Color("#88888860"),
                CornerRadius = 16.0f,
                Padding = 20,
            };
            item.Add(new TextLabel()
            {
                PixelSize = 22.0f,
                Text = title,
                Padding = new Extents(0, 0, 0, 20)
            });
            item.Add(content);
            return item;
        }

        private View CreateClickableItem(string title, string subtitle, Action<View> clicked)
        {
            var item = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                BackgroundColor = new Color("#88888860"),
                CornerRadius = 16.0f,
                Padding = 20,
                LeaveRequired = true,
            };
            item.TouchEvent += (s, e) => {
                var state = e.Touch.GetState(0);
                if (state == PointStateType.Down)
                {
                    ((View)s).BackgroundColor = new Color("#888888BB");
                }
                else if (state == PointStateType.Up)
                {
                    ((View)s).BackgroundColor = new Color("#88888860");
                    clicked?.Invoke(item);
                }
                else if (state == PointStateType.Leave || state == PointStateType.Interrupted)
                {
                    ((View)s).BackgroundColor = new Color("#88888860");
                }
                return true;
            };
            item.Add(new TextLabel()
            {
                PixelSize = 22.0f,
                Text = title,
                Padding = new Extents(0, 0, 0, 20)
            });
            item.Add(new TextLabel()
            {
                PixelSize = 32.0f,
                Text = subtitle,
                VerticalAlignment = VerticalAlignment.Center,
            });
            return item;
        }

        private View CreateSwitchExample()
        {
            var view = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
            };
            var textLabel = new TextLabel()
            {
                Text = "Auto update : on",
                TextColor = Color.Red,
            };
            view.Add(textLabel);

            var switchButton = new Switch()
            {
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
                PositionUsesPivotPoint = true,
                IsSelected = true,
            };
            switchButton.SelectedChanged += (s, e) => {
                textLabel.Text = $"Daily auto update : {(((Switch)s).IsSelected ? "on" : "off")}";
            };
            view.Add(switchButton);
            return view;
        }
    }
}
