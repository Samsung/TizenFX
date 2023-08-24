/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

class HelloWorldExample : NUIApplication
{
    private const string itemBackgroundColor = "#88888860";
    private const string itemBackgroundDimColor = "#888888BB";

    // ThemeOptions
    // * PlatformThemeEnabled : Specify this flag when you want to change platform theme manually
    //                          or want to receive platform theme changed event.
    // * ThemeChangeSensitive : Basically, if you want a NUI View to automatically change its appearance
    //                          whenever the theme changes, you need to set "view.ThemeChangeSensitive = true"
    //                          for the view. It's "false" by default. However if this flag is specified,
    //                          the default value will be "true" so you won't be bother to set it for each view.
    //                          Please note that this flag makes NUI to track all views for theme update, therefore
    //                          it may slow down your application. It's recommended to use this option only when
    //                          absolutely necessary.
    public HelloWorldExample() : base(ThemeOptions.PlatformThemeEnabled | ThemeOptions.ThemeChangeSensitive)
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        var closeButton = new Button()
        {
            Text = "Exit"
        };
        closeButton.Clicked += (s, e) => {
            Exit();
        };

        var mainPage = new ContentPage()
        {
            ThemeChangeSensitive = true,
            AppBar = new AppBar()
            {
                AutoNavigationContent = false,
                Title = "NUI theme sample",
                Actions = new View[] { closeButton },
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

        var title = $"Click to change theme to {(ThemeManager.PlatformThemeId == ThemeManager.DefaultLightThemeName ? "Dark" : "Light")}";

        mainPage.Content.Add(CreateClickableItem("Theme change", title, delegate(View view) {
            TextLabel text = view.Children[1] as TextLabel;

            if (ThemeManager.PlatformThemeId == ThemeManager.DefaultDarkThemeName)
            {
                ThemeManager.ApplyPlatformTheme(ThemeManager.DefaultLightThemeName);
                text.Text = "Click to change theme to Dark";
            }
            else
            {
                ThemeManager.ApplyPlatformTheme(ThemeManager.DefaultDarkThemeName);
                text.Text = "Click to change theme to Light";
            }
        }));

        mainPage.Content.Add(CreateItem("Switch", CreateSwitchExample()));
        
        mainPage.Content.Add(CreateItem("RadioButton", CreateRadioButtonExample()));
        
        mainPage.Content.Add(CreateClickableItem("AlertDialog", "Click to post alert", delegate(View view) {
            Button button;
            DialogPage.ShowAlertDialog("Title", "Message", button = new Button() { Text = "Close" });
            button.Clicked += (s, e) => {
                NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            };
        }));

        mainPage.Content.Add(CreateItem("CheckBox", CreateCheckBoxExample()));

        mainPage.Content.Add(CreateClickableItem("Exit", "Click to exit application", delegate(View view) {
            Exit();
        }));

        NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(mainPage);
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
            BackgroundColor = new Color(itemBackgroundColor),
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
            BackgroundColor = new Color(itemBackgroundColor),
            CornerRadius = 16.0f,
            Padding = 20,
            LeaveRequired = true,
        };
        item.TouchEvent += (s, e) => {
            var state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                ((View)s).BackgroundColor = new Color(itemBackgroundDimColor);
            }
            else if (state == PointStateType.Up)
            {
                ((View)s).BackgroundColor = new Color(itemBackgroundColor);
                clicked?.Invoke(item);
            }
            else if (state == PointStateType.Leave || state == PointStateType.Interrupted)
            {
                ((View)s).BackgroundColor = new Color(itemBackgroundColor);
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

    private View CreateRadioButtonExample()
    {
        var view = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
        };
        var radio1 = new RadioButton() { Text = "Radio1", Padding = 7 };
        var radio2 = new RadioButton() { Text = "Radio2", Padding = 7 };
        var radio3 = new RadioButton() { Text = "Radio3", Padding = 7 };

        var group = new RadioButtonGroup();
        group.Add(radio1);
        group.Add(radio2);
        group.Add(radio3);

        view.Add(radio1);
        view.Add(radio2);
        view.Add(radio3);

        radio1.IsSelected = true;

        return view;
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
            Text = "Auto update : on"
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

    private View CreateCheckBoxExample()
    {
        var view = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FitToChildren,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
        };
        var check1 = new CheckBox() { Text = "Food", Padding = 7 };
        var check2 = new CheckBox() { Text = "Animal", Padding = 7 };
        var check3 = new CheckBox() { Text = "Vehicle", Padding = 7 };

        view.Add(check1);
        view.Add(check2);
        view.Add(check3);

        check2.IsSelected = true;
        check3.IsSelected = true;

        return view;
    }

    private void FullGC()
    {
        global::System.GC.Collect();
        global::System.GC.WaitForPendingFinalizers();
        global::System.GC.Collect();
    }

    /// <summary>
    /// Called when any key event is received.
    /// Will use this to exit the application if the Back or Escape key is pressed
    /// </summary>
    private void OnKeyEvent( object sender, Window.KeyEventArgs eventArgs )
    {
        if( eventArgs.Key.State == Key.StateType.Down )
        {
            switch( eventArgs.Key.KeyPressedName )
            {
                case "Escape":
                case "Back":
                {
                    Exit();
                }
                break;
            }
        }
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        HelloWorldExample example = new HelloWorldExample();
        example.Run(args);
    }
}
