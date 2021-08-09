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
using Tizen.NUI.Components;
using System.IO;


namespace NUITizenGallery
{
    public partial class CarouselViewFocusTestPage : ContentPage
    {
        private readonly static string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        private readonly static string PostersPath = ResourcePath + "posters/";
        private int FocusedItem = -1;
        private CarouselViewItem[] items;
        private readonly string TestDescription = "A great example of colour scheme that extends from a film to its marketing. Yellow emanates from this heartwarming Sundance hit, seen on Paul Dano��s t-shirt and the lovably rubbish VW campervan, here flooding the negative space of both trailer and poster.";

        public CarouselViewFocusTestPage()
        {
            InitializeComponent();

            string[] files = Directory.GetFiles(PostersPath);
            items = new CarouselViewItem[files.Length];

            int i = 0;

            foreach (string f in files)
            {
                items[i] = new CarouselViewItem(i, f, Path.GetFileNameWithoutExtension(f), TestDescription);
                items[i].CarouselViewItemClicked += OnItemClicked;
                Scroller.Add(items[i++]);
            }
        }
        public void OnItemClicked(object sender, CarouselViewItemClickedEventArgs args)
        {
            if (FocusedItem == -1)
            {
                items[args.ClickedItemId].SetFocused();
                FocusedItem = args.ClickedItemId;
            } else {
                items[FocusedItem].SetNormal();
                items[args.ClickedItemId].SetFocused();
            }

            FocusedItem = args.ClickedItemId;

            Scroller.ScrollToIndex(FocusedItem);
        }
    }
}
