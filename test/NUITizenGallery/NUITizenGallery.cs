/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

namespace NUITizenGallery
{
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
            var underline = CreateUnderline();

            searchTextBox.Add(SearchTextField);
            searchTextBox.Add(underline);

            SearchButton = CreateSearchButton();

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

    public class Gallery
    {
        public Gallery(string name, string fullName = null)
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

    public class GalleryViewModel
    {
        public List<Tuple<string, string>> NamePool = new List<Tuple<string, string>>();

        public GalleryViewModel()
        {
            //CreateData();
        }

        public List<Gallery> CreateData()
        {
            GetXamlPages();

            List<Gallery> result = new List<Gallery>();
            foreach (var name in NamePool)
            {
                result.Add(new Gallery(name.Item1, name.Item2));
            }
            return result;
        }

        private void GetXamlPages()
        {
            Assembly assembly = this.GetType().Assembly;
            Type exampleType = assembly.GetType("NUITizenGallery.IExample");

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

    public class CustomNavigator : Navigator
    {
        // Customizes how to handle back navigation.
        // base.OnBackNavigation() pops the peek page.
        protected override void OnBackNavigation(BackNavigationEventArgs args)
        {
            if (PageCount > 1)
            {
                // Deactivates the peek page example before page pop.
                if (Peek() is IExample currentExample)
                {
                    currentExample.Deactivate();
                }
            }

            // Pops the peek page if navigator has more than one page.
            // If navigator has only one page, then the program is exited.
            base.OnBackNavigation(args);
        }
    }

    class Program : NUIApplication
    {
        private Window window;
        private AppBar appBar;
        private View pageContent;
        private Navigator navigator;
        private CollectionView colView;
        private ItemSelectionMode selMode;
        private IExample currentExample = null;
        private ContentPage page;
        private SearchField field;
        private List<Gallery> testSource;

        public void OnSelectionChanged(object sender, SelectionChangedEventArgs ev)
        {
            Console.WriteLine($"@@@ OnSelectionChanged() {ev.CurrentSelection}");

            foreach (object item in ev.CurrentSelection)
            {
                if (item == null)
                {
                    break;
                }

                var selItem = item as Gallery;
                Console.WriteLine($"@@@ selItem.Name={selItem.Name}, selItem.FullName={selItem.FullName}");
                RunSample(selItem?.FullName);
                colView.SelectedItem = null;
            }

            /* Use the following code when it is actually required.
            foreach (object item in ev.PreviousSelection)
            {
                if (item == null)
                {
                    break;
                }

                var unselItem = item as Gallery;
            }

            foreach (object item in ev.CurrentSelection)
            {
                if (item == null)
                {
                    break;
                }

                var selItem = item as Gallery;
            }
            */
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            SetMainPage();
            pageContent.SizeHeight = Window.Instance.WindowSize.Height - appBar.SizeHeight;
        }
        private void Initialize()
        {
            window = GetDefaultWindow();
            window.Title = "NUITizenGallery";

            // In this example, GetDefaultNavigator() has not been called before so default navigator has not been set yet.
            // Therefore, the following codes for unsetting and disposing the previous default navigator are not required in this example.
            /*
            var prevDefaultNavigator = window.GetDefaultNavigator();
            window.Remove(prevDefaultNavigator);
            prevDefaultNavigator.Dispose();
            prevDefaultNavigator = null;
            */

            // Uses customized navigator to customize how to handle back navigation.
            navigator = new CustomNavigator()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            // Sets the customized navigator as the default navigator of the window.
            window.SetDefaultNavigator(navigator);
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
            appBar = new AppBar()
            {
                Title = "NUI Tizen Gallery",
                AutoNavigationContent = false,
            };

            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");
            var moreButton = new Button(((AppBarStyle)appBarStyle).BackButton);
            moreButton.Icon.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "menu.png";
            appBar.NavigationContent = moreButton;


            pageContent = new View()
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

            testSource = new GalleryViewModel().CreateData();
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
                    return item;
                }),
                Header = myTitle,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                HideScrollbar = false,
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
            navigator.Push(page);
        }

        private void RunSample(string name)
        {
            IExample example = typeof(Program).Assembly?.CreateInstance(name) as IExample;

            Console.WriteLine($"@@@ typeof(Program).Assembly={typeof(Program).Assembly}, name={name}");

            if (example != null)
            {
                example.Activate();
            }
            else
            {
                Console.WriteLine($"@@@ examle is null!");
            }
            currentExample = example;
        }

        private void ExitSample()
        {
            currentExample?.Deactivate();
            currentExample = null;

            FullGC();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        static void Main(string[] args)
        {
            string[] emptyArgs = new string[0];
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
                if (arg.ToString() == "--implicit-scaling-factor")
                {
                    Console.WriteLine("NOTE: Scaling Factor is implicitly declaired as 1.5");
                    System.Environment.SetEnvironmentVariable("NUI_SCALING_FACTOR","1.5");
                }
            }

            var app = new Program();
            app.Run(args);
        }
    }
}
