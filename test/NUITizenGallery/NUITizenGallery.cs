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

    class Program : NUIApplication
    {
        private Window window;
        private Navigator navigator;
        private CollectionView colView;
        private ItemSelectionMode selMode;
        private IExample currentExample = null;
        private ContentPage page;
        private SearchField field;
        private List<Gallery> testSource;

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    if (null != currentExample)
                    {
                        ExitSample();
                    }
                    else
                    {
                        Exit();
                    }
                }
            }
        }

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
        }
        private void Initialize()
        {
            window = GetDefaultWindow();
            window.Title = "NUITizenGallery";
            window.KeyEvent += OnKeyEvent;

            navigator = window.GetDefaultNavigator();
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
                Title = "NUI Tizen Gallery",
                AutoNavigationContent = false,
            };

            var appBarStyle = ThemeManager.GetStyle("Tizen.NUI.Components.AppBar");
            var moreButton = new Button(((AppBarStyle)appBarStyle).BackButton);
            moreButton.Icon.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "menu.png";
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
            var app = new Program();
            app.Run(args);
        }
    }
}
