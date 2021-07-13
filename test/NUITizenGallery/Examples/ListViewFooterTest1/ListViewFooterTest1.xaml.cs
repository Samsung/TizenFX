/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class ListItemClickedEventArgs : EventArgs
    {
        public string ClickedItemText;
        public int Index;
        
        public ListItemClickedEventArgs(string text, int index) 
        {
            ClickedItemText = text;
            Index = index;
        }
    }

    public class ListItem : TextLabel
    {
        private int Index = -1;
        public event EventHandler<ListItemClickedEventArgs> Clicked;
        public ListItem(string text, int index)
        {
            Text = text;
            Index = index;
            TouchEvent += OnTouchEvent;
            Size2D = new Tizen.NUI.Size2D(720, 100);
        }

        private bool OnTouchEvent(object sender, TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == Tizen.NUI.PointStateType.Finished)
            {
                Clicked.Invoke(this, new ListItemClickedEventArgs(Text, Index));
            }

            return true;
        }

        public void ChangeSelectionState(bool selected)
        {
            if (selected == true) 
            {
                BackgroundColor = Color.Gray;
            }
            else
            {
                BackgroundColor = Color.White;
            }
        }
    }

    public partial class ListViewFooterTest1Page : View
    {
        private readonly int ItemsCount = 20;

        private int SelectedItemIndex = -1;
        private List<ListItem> items;

        public ListViewFooterTest1Page()
        {
            InitializeComponent();
            items = new List<ListItem>();
            
            for (int i = 0; i < ItemsCount; ++i)
            {
                items.Add(new ListItem(string.Format("{0}th list item", i), i));
                items[i].Clicked += OnClicked;
                ListView.Add(items[i]);
            }
        }

        private void OnClicked(object sender, ListItemClickedEventArgs args)
        {
            Footer.Text = args.ClickedItemText;

            if (SelectedItemIndex != -1) 
            {
                items[SelectedItemIndex].ChangeSelectionState(false);
            }

            SelectedItemIndex = args.Index;
            items[SelectedItemIndex].ChangeSelectionState(true);
        }
    }
}
