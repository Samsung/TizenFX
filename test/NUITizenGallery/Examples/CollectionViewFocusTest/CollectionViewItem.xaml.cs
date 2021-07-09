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
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using System;

namespace NUITizenGallery
{
    public partial class CollectionViewItemClickedEventArgs : EventArgs
    {
        public int ClickedItemId = -1;
        public CollectionViewItemClickedEventArgs(int id)
        {
            ClickedItemId = id;
        }
    }

    public partial class CollectionViewItem : View
    {
        private int ItemId = -1;
        public event EventHandler<CollectionViewItemClickedEventArgs> CollectionViewItemClicked;

        private Animation animation;

        public CollectionViewItem(int id, string poster, string name, string description)
        {
            ItemId = id;
            InitializeComponent();

            ItemPoster.ResourceUrl = poster;
            ItemTitle.Text = name;
            ItemDescription.Text = description;
            ItemDescription.MultiLine = true;

            TouchEvent += OnTouchEvent;
            animation = new Animation();
        }

        public bool OnTouchEvent(object sender, TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == Tizen.NUI.PointStateType.Finished) {
                CollectionViewItemClicked.Invoke(this, new CollectionViewItemClickedEventArgs(ItemId));
            }

            return false;
        }

        public void SetFocused()
        {
            ItemBackground.BackgroundColor = Color.Blue;

            animation.AnimateTo(ItemBackground, "SizeWidth", 340, 0, 100);
            animation.AnimateTo(ItemBackground, "SizeHeight", 900, 0, 100);
            animation.AnimateTo(ItemPoster, "SizeWidth", 340, 0, 100);
            animation.AnimateTo(ItemPoster, "SizeHeight", 496, 0, 100);
            animation.AnimateTo(ItemTitle, "SizeWidth", 340, 0, 100);
            animation.AnimateTo(ItemDescription, "SizeWidth", 340, 0, 100);
            animation.AnimateTo(ItemDescription, "SizeHeight", 350, 0, 100);
            animation.Looping = false;
            animation.Play();
        }

        public void SetNormal()
        {
            ItemBackground.BackgroundColor = Color.Red;
            animation.AnimateTo(ItemBackground, "SizeWidth", 300, 0, 100);
            animation.AnimateTo(ItemBackground, "SizeHeight", 700, 0, 100);
            animation.AnimateTo(ItemPoster, "SizeWidth", 300, 0, 100);
            animation.AnimateTo(ItemPoster, "SizeHeight", 438, 0, 100);
            animation.AnimateTo(ItemTitle, "SizeWidth", 300, 0, 100);
            animation.AnimateTo(ItemDescription, "SizeWidth", 300, 0, 100);
            animation.AnimateTo(ItemDescription, "SizeHeight", 50, 0, 100);
            animation.Looping = false;
            animation.Play();
        }
    }
}
