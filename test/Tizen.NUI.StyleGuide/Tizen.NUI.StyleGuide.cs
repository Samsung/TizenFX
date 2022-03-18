/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Linq;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Reflection;

namespace Tizen.NUI.StyleGuide
{

    /// Helder static extension class for Focusable.
    /// NUI default behavior is unfocusable in key or touch,
    /// this class help to setting focusable features easily.
    public static class FocusableExtension
    {
        public static FocusManager FocusManager;
        public static void EnableFocus(this View view)
        {
            view.Focusable = true;
            view.FocusableInTouch = true;
        }

        public static void EnableAutoFocusable()
        {
            FocusManager = FocusManager.Instance;
            FocusManager.EnableDefaultAlgorithm(true);
            FocusManager.FocusIndicator = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = new Position(0, 0, 0),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BorderlineColor = Color.Orange,
                BorderlineWidth = 4.0f,
                BorderlineOffset = -1f,
                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.2f),
            };
        }

        public static void SetFocusOnPage(Page page)
        {
            View focusCandidate = null;
            if (page == null) return;

            if (page is ContentPage contentPage)
            {
                focusCandidate = contentPage.AppBar?.NavigationContent;
                focusCandidate.Focusable = true;
            }

            if (focusCandidate == null)
            {
                foreach (View child in page.Children)
                {
                    if (child.Focusable)
                    {
                        focusCandidate = child;
                    }
                }
            }

            Log.Info("FocusableExtension", $"Focus candidate {focusCandidate}\n");

            if (focusCandidate != null)
            {
                FocusManager.SetCurrentFocusView(focusCandidate);
            }
        }
    }

    public class SearchField : View
    {
        public TextField SearchTextField;
        public Button SearchButton;
        public SearchField() : base()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.CenterVertical,
                CellPadding = new Size2D(40, 0),
            };

            BackgroundColor = Color.White;

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.WrapContent;
            Padding = new Extents(64, 64, 0, 0);

            var searchTextBox = CreateSearchText();
            SearchTextField = CreateTextField();
            SearchTextField.EnableFocus();
            var underline = CreateUnderline();

            searchTextBox.Add(SearchTextField);
            searchTextBox.Add(underline);

            SearchButton = CreateSearchButton();
            SearchButton.EnableFocus();

            Add(searchTextBox);
            Add(SearchButton);
        }

        private View CreateSearchText()
        {
            return new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
        }

        private TextField CreateTextField()
        {
            return new TextField()
            {
                PlaceholderText = "Search",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                MinimumSize = new Size2D(0, 40),
            };
        }

        private View CreateUnderline()
        {
            return new View()
            {
                BackgroundColor = new Color("#0A0E4AFF"),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 2,
            };
        }

        private Button CreateSearchButton()
        {
            return new Button()
            {
                Text = "Run",
                WidthSpecification = 120,
                HeightSpecification = LayoutParamPolicies.WrapContent,
            };
        }
    }

    public class ControlMenu
    {
        public ControlMenu(string name, string fullName = null)
        {
            Name = name;
            FullName = fullName;
        }

        public string Name { get; set; }

        public string ViewLabel
        {
            get
            {
                return Name;
            }
        }

        public bool Selected { get; set; }

        internal string FullName { get; set; }
    }

    public class ControlMenuViewModel
    {
        public List<Tuple<string, string>> NamePool = new List<Tuple<string, string>>();

        public ControlMenuViewModel()
        {
            //CreateData();
        }

        public List<ControlMenu> CreateData()
        {
            GetXamlPages();

            List<ControlMenu> result = new List<ControlMenu>();
            foreach (var name in NamePool)
            {
                result.Add(new ControlMenu(name.Item1, name.Item2));
            }
            return result;
        }

        private void GetXamlPages()
        {
            Assembly assembly = this.GetType().Assembly;
            Type exampleType = assembly.GetType("Tizen.NUI.StyleGuide.IExample");

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"@@@ type.Name={type.Name}, type.FullName={type.FullName}");
                if (exampleType.IsAssignableFrom(type) && type.Name != "SampleMain" && this.GetType() != type && type.IsClass)
                {
                    NamePool.Add(new Tuple<string, string>(type.Name, type.FullName));
                }
            }
        }
    }

    class Program : NUIApplication
    {
        private Window window;
        private Navigator navigator;
        private CollectionView colView;
        private ItemSelectionMode selMode;
        private ContentPage page;
        private SearchField field;
        private List<ControlMenu> testSource;
        private FocusManager focusManager;

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            // FIXME:: Navigator should provide Back/Escape event processing.
            if (e.Key.State == Key.StateType.Up)
            {
                Log.Info("StyleGuide", $"[{e.Key.KeyPressedName}] is pressed!\n");
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    if (navigator == null) return;

                    ExitSample();

                    if (navigator.PageCount == 0)
                    {
                         Exit();
                    }
                }
            }
        }

        public void OnSelectionChanged(object sender, SelectionChangedEventArgs ev)
        {
            Console.WriteLine($"@@@ OnSelectionChanged() {ev.CurrentSelection}");

            if (ev.CurrentSelection.Count == 0) return;

            if (ev.CurrentSelection[0] is ControlMenu selItem)
            {
                Console.WriteLine($"@@@ selItem.Name={selItem.Name}, selItem.FullName={selItem.FullName}");
                RunSample(selItem?.FullName);
            }
            colView.SelectedItem = null;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            SetMainPage();
        }
        private void Initialize()
        {
            window = GetDefaultWindow();
            window.Title = "NUI Style Guide";
            window.KeyEvent += OnKeyEvent;

            FocusableExtension.EnableAutoFocusable();

            navigator = window.GetDefaultNavigator();
            navigator.Popped += (object obj, PoppedEventArgs ev) =>
            {
                Page top = navigator.Peek();
                FocusableExtension.SetFocusOnPage(top);
            };
        }

        void OnSearchBtnClicked(object sender, ClickedEventArgs e)
        {
            var filteredSource = from filter in testSource
                                 where filter.Name.ToLower().Contains(field.SearchTextField?.Text?.ToLower())
                                 select filter;

            colView.Header = new DefaultTitleItem()
            {
                Text = "result",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            colView.ItemsSource = filteredSource;
        }

        private void SetMainPage()
        {
            var appBar = new AppBar()
            {
                Title = "NUI Style Guide",
                AutoNavigationContent = false,
            };

            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");
            var moreButton = new Button(((AppBarStyle)appBarStyle).BackButton);
            moreButton.Icon.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "menu.png";
            moreButton.EnableFocus();
            appBar.NavigationContent = moreButton;


            var pageContent = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            field = new SearchField()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            field.SearchButton.Clicked += OnSearchBtnClicked;

            testSource = new ControlMenuViewModel().CreateData();
            selMode = ItemSelectionMode.SingleAlways;
            var myTitle = new DefaultTitleItem()
            {
                Text = "TestCase",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };

            colView = new CollectionView()
            {
                ItemsSource = testSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    DefaultLinearItem item = new DefaultLinearItem()
                    {
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                    };
                    item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    item.EnableFocus();
                    return item;
                }),
                Header = myTitle,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = selMode,
            };
            colView.SelectionChanged += OnSelectionChanged;

            pageContent.Add(field);
            pageContent.Add(colView);

            page = new ContentPage()
            {
                AppBar = appBar,
                Content = pageContent,
            };
            page.Focusable = true;

            navigator.Push(page);
            FocusableExtension.SetFocusOnPage(page);
        }

        private void RunSample(string name)
        {
            IExample example = typeof(Program).Assembly?.CreateInstance(name) as IExample;


            Console.WriteLine($"@@@ typeof(Program).Assembly={typeof(Program).Assembly}, name={name}");

            if (example != null)
            {
                example.Activate();
                if (example is Page examplePage)
                {
                    examplePage.Focusable = true;
                    navigator.Push(examplePage);
                    FocusableExtension.SetFocusOnPage(examplePage);
                }
            }
            else
            {
                Console.WriteLine($"@@@ examle is null!");
            }
        }

        private void ExitSample()
        {
            if (navigator.Peek() is IExample currentExample)
            {
                currentExample.Deactivate();
            }

            navigator.Pop();
            // FullGC();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
