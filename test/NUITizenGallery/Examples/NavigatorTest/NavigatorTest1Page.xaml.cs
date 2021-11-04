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
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class NavigatorTest1Page : ContentPage
    {
        public NavigatorTest1Page()
        {
            InitializeComponent();
        }

        private void SetButtonColor(NavigatorTest1Page page, int type)
        {
            Color backgroundColor;

            if (type == 0)
            {
                backgroundColor = Color.DarkGreen;
            }
            else if (type == 1)
            {
                backgroundColor = Color.DarkRed;
            }
            else if (type == 2)
            {
                backgroundColor = Color.DarkBlue;
            }
            else
            {
                backgroundColor = Color.SaddleBrown;
            }

            page.buttonPush.BackgroundColor = backgroundColor;
            page.buttonPop.BackgroundColor = backgroundColor;
            page.buttonInsert.BackgroundColor = backgroundColor;
            page.buttonInsertBefore.BackgroundColor = backgroundColor;
            page.buttonRemove.BackgroundColor = backgroundColor;
            page.buttonRemoveAt.BackgroundColor = backgroundColor;
        }

        private void ButtonPushClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var newPage = new NavigatorTest1Page();
            SetButtonColor(newPage, Navigator.PageCount % 4);
            newPage.AppBar.Title = "NavigatorTest1Page" + Navigator.PageCount.ToString();
            Navigator.Push(newPage);
            Tizen.Log.Info("NUI", newPage.AppBar.Title + " has been pushed.\n");
        }

        private void ButtonPopClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var poppedPage = Navigator.Pop() as NavigatorTest1Page;
            Tizen.Log.Info("NUI", poppedPage.AppBar.Title + " has been popped.\n");
        }

        private void ButtonInsertClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var newPage = new NavigatorTest1Page();
            SetButtonColor(newPage, Navigator.PageCount % 4);
            newPage.AppBar.Title = "NavigatorTest1Page" + Navigator.PageCount.ToString();
            Navigator.Insert(Navigator.PageCount, newPage);
            Tizen.Log.Info("NUI", newPage.AppBar.Title + " has been inserted.\n");
        }

        private void ButtonInsertBeforeClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var newPage = new NavigatorTest1Page();
            SetButtonColor(newPage, Navigator.PageCount % 4);
            newPage.AppBar.Title = "NavigatorTest1Page" + Navigator.PageCount.ToString();
            Navigator.InsertBefore(Navigator.Peek(), newPage);
            Tizen.Log.Info("NUI", newPage.AppBar.Title + " has been inserted before the peek page.\n");
        }

        private void ButtonRemoveClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var removedPage = Navigator.Peek() as NavigatorTest1Page;
            Navigator.Remove(removedPage);
            Tizen.Log.Info("NUI", removedPage.AppBar.Title + " has been removed.\n");
        }

        private void ButtonRemoveAtClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "This page should be pushed to a Navigator.\n");
                return;
            }

            if (Navigator.PageCount <= 2)
            {
                Tizen.Log.Info("NUI", "This test removes the previous page unless the previous page is the main page.\n");
                return;
            }

            int removedIndex = Navigator.PageCount - 2;
            var removedPage = Navigator.GetPage(removedIndex) as NavigatorTest1Page;
            Navigator.RemoveAt(removedIndex);
            Tizen.Log.Info("NUI", removedPage.AppBar.Title + " has been removed.\n");
        }
    }
}
