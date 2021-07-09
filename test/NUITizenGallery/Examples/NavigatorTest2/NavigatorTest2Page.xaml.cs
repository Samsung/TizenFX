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
    public partial class NavigatorTest2Page : ContentPage
    {
        public NavigatorTest2Page()
        {
            InitializeComponent();
        }

        private void SetButtonColor(NavigatorTest2Page page, int type)
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
            page.buttonPushAndInsert.BackgroundColor = backgroundColor;
            page.buttonRemoveAndPop.BackgroundColor = backgroundColor;
            page.buttonPushAndRemove.BackgroundColor = backgroundColor;
            page.buttonInsertAndPop.BackgroundColor = backgroundColor;
            page.buttonPopToRoot.BackgroundColor = backgroundColor;
        }

        private void ButtonPushClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var newPage = new NavigatorTest2Page();
            SetButtonColor(newPage, Navigator.PageCount % 4);
            newPage.AppBar.Title = "NavigatorTest2Page" + Navigator.PageCount.ToString();
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

            var poppedPage = Navigator.Pop() as NavigatorTest2Page;
            Tizen.Log.Info("NUI", poppedPage.AppBar.Title + " has been popped.\n");
        }

        private void InsertWhenAppeared(object sender, PageAppearedEventArgs args)
        {
            var page = sender as NavigatorTest2Page;
            page.Appeared -= InsertWhenAppeared;

            var insertedPage = new NavigatorTest2Page();
            SetButtonColor(insertedPage, Navigator.PageCount % 4);
            insertedPage.AppBar.Title = "NavigatorTest2Page" + (Navigator.PageCount - 1).ToString();
            Navigator.InsertBefore(page, insertedPage);
            Tizen.Log.Info("NUI", insertedPage.AppBar.Title + " has been inserted before the peek page.\n");
        }

        private void ButtonPushAndInsertClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var pushedPage = new NavigatorTest2Page();
            SetButtonColor(pushedPage, Navigator.PageCount % 4);
            pushedPage.AppBar.Title = "NavigatorTest2Page" + (Navigator.PageCount + 1).ToString();
            pushedPage.Appeared += InsertWhenAppeared;
            Navigator.Push(pushedPage);
            Tizen.Log.Info("NUI", pushedPage.AppBar.Title + " has been pushed.\n");
        }

        private void ButtonRemoveAndPopClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            if (Navigator.PageCount <= 2)
            {
                Tizen.Log.Info("NUI", "This test removes two pages, so at least two pages should be pushed.\n");
                return;
            }

            var removedPage = Navigator.GetPage(Navigator.PageCount - 2) as NavigatorTest2Page;
            Navigator.Remove(removedPage);
            Tizen.Log.Info("NUI", removedPage.AppBar.Title + " has been removed.\n");

            var poppedPage = Navigator.Pop() as NavigatorTest2Page;
            Tizen.Log.Info("NUI", poppedPage.AppBar.Title + " has been popped.\n");
        }

        private void RemoveWhenAppeared(object sender, PageAppearedEventArgs args)
        {
            var page = sender as NavigatorTest2Page;
            page.Appeared -= RemoveWhenAppeared;

            var removedPage = Navigator.GetPage(Navigator.PageCount - 2) as NavigatorTest2Page;
            Navigator.Remove(removedPage);
            Tizen.Log.Info("NUI", removedPage.AppBar.Title + " has been removed.\n");
        }

        private void ButtonPushAndRemoveClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var pushedPage = new NavigatorTest2Page();
            SetButtonColor(pushedPage, Navigator.PageCount % 4);
            pushedPage.AppBar.Title = "NavigatorTest2Page" + Navigator.PageCount.ToString();
            pushedPage.Appeared += RemoveWhenAppeared;
            Navigator.Push(pushedPage);
            Tizen.Log.Info("NUI", pushedPage.AppBar.Title + " has been pushed.\n");
        }

        private void ButtonInsertAndPopClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            var newPage = new NavigatorTest2Page();
            SetButtonColor(newPage, Navigator.PageCount % 4);
            newPage.AppBar.Title = "NavigatorTest2Page" + Navigator.PageCount.ToString();
            Navigator.InsertBefore(Navigator.Peek(), newPage);
            Tizen.Log.Info("NUI", newPage.AppBar.Title + " has been inserted before the peek page.\n");

            var poppedPage = Navigator.Pop() as NavigatorTest2Page;
            Tizen.Log.Info("NUI", poppedPage.AppBar.Title + " has been popped.\n");
        }

        private void ButtonPopToRootClicked(object sender, ClickedEventArgs args)
        {
            if (Navigator == null)
            {
                Tizen.Log.Error("NUI", "The page should be pushed to a Navigator.\n");
                return;
            }

            for (int i = Navigator.PageCount; i > 2; i--)
            {
                var removedPage = Navigator.GetPage(i - 2) as NavigatorTest2Page;
                Navigator.Remove(removedPage);
                Tizen.Log.Info("NUI", removedPage.AppBar.Title + " has been removed.\n");
            }

            var poppedPage = Navigator.Pop() as NavigatorTest2Page;
            Tizen.Log.Info("NUI", poppedPage.AppBar.Title + " has been popped.\n");
        }
    }
}
