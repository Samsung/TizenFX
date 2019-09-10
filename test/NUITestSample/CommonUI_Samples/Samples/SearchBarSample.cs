using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    using FH = Tizen.FH;
    public class SearchBar : IExample
    {
        private SampleLayout rootView = null;
        private Tizen.FH.NUI.Controls.SearchBar searchBar = null;

        private Tizen.NUI.CommonUI.Button button;
        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            CreateRootView();
            CreateSearchBar();
            button = new Tizen.NUI.CommonUI.Button();
            button.PointSize = 14;
            button.Size2D = new Size2D(300, 80);
            button.BackgroundColor = Color.Green;
            button.Position2D = new Position2D(40, 400);
            button.Text = "LTR/RTL";
            button.ClickEvent += OnLayoutChanged;
            rootView.Add(button);
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }
        private void OnLayoutChanged(object sender, global::System.EventArgs e)
        {
            if (searchBar.LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                searchBar.LayoutDirection = ViewLayoutDirectionType.RTL;
            }
            else
            {
                searchBar.LayoutDirection = ViewLayoutDirectionType.LTR;

            }
        }
        private void CreateRootView()
        {
            rootView = new SampleLayout();
            rootView.HeaderText = "SearchBar";
        }

        private void CreateSearchBar()
        {
            searchBar = new FH.NUI.Controls.SearchBar("DefaultSearchBar");
            searchBar.HintText = "DefaultSearchBar";
            searchBar.ResultListHeight = 536;
            rootView.Add(searchBar);
            searchBar.SearchButtonClickEvent += OnSearchButtonClickEvent;
            searchBar.CancelButtonClickEvent += OnCancelButtonClickEvent;
            rootView.AttachSearchBar(searchBar);
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                }
            }
        }

        private void OnCancelButtonClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.SearchBar)
            {
                Tizen.FH.NUI.Controls.SearchBar searchBarObj = sender as Tizen.FH.NUI.Controls.SearchBar;
                Console.WriteLine("-------, name: " + searchBarObj.Name + ", args.State = " + args.State);
                if (args.State == Tizen.FH.NUI.Controls.InputField.ButtonClickState.BounceUp)
                {
                    //if (searchBarObj.Text == "ERROR")
                    //{
                    searchBarObj.TextColor = Color.Black;
                    //}
                    searchBarObj.Text = "";
                    searchBarObj.ShrinkSearchList();
                }
            }
        }

        private void OnSearchButtonClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.SearchBar)
            {
                Tizen.FH.NUI.Controls.SearchBar searchBarObj = sender as Tizen.FH.NUI.Controls.SearchBar;
                Console.WriteLine("-------, name: " + searchBarObj.Name + ", args.State = " + args.State);
                if (args.State == Tizen.FH.NUI.Controls.InputField.ButtonClickState.BounceUp)
                {
                    if (searchBarObj.Text.Length > 10)
                    {
                        searchBarObj.TextColor = Color.Red;
                    }
                    else
                    {
                        searchBarObj.ExpandSearchList();
                    }
                }

            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;

            if (searchBar != null)
            {
                searchBar.SearchButtonClickEvent -= OnSearchButtonClickEvent;
                searchBar.CancelButtonClickEvent -= OnCancelButtonClickEvent;
                rootView.Remove(searchBar);
                searchBar.Dispose();
                searchBar = null;
            }

            if (button != null)
            {
                rootView.Remove(button);
                button.Dispose();
                button = null;
            }
            if (rootView != null)
            {
                rootView.Dispose();
                rootView = null;
            }
        }
    }
}
