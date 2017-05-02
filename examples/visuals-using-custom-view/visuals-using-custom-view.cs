/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Dali;
using Dali.Constants;

namespace VisualsUsingCustomView
{
    class VisualsExample
    {
        public VisualsExample(Application application)
        {
            application.Initialized += Initialize;
        }

        private void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(14, 1);
            contentLayout.Name = "ContentLayout";
            contentLayout.WidthResizePolicy = "FILL_TO_PARENT";
            contentLayout.HeightResizePolicy = "FILL_TO_PARENT";
            contentLayout.SetCellPadding(new Size2D(5, 5));
            contentLayout.BackgroundColor = new Color(0.949f, 0.949f, 0.949f, 1.0f);

            window.GetDefaultLayer().Add(contentLayout);

            TextLabel title = new TextLabel("Contacts List with Visuals");
            title.Name = "Title";
            title.StyleName = "Title";
            title.WidthResizePolicy = "FILL_TO_PARENT";
            title.HeightResizePolicy = "USE_NATURAL_SIZE";
            title.HorizontalAlignment = "CENTER";
            contentLayout.Add(title);
            contentLayout.SetFitHeight(0);

            // Create ContactView(s) from ContactItem(s) in ContactsList and add them to TableView
            ContactView contactView;
            foreach (ContactItem contact in ContactsList.s_contactData)
            {
                contactView = new ContactView();
                contactView.WidthResizePolicy = "FILL_TO_PARENT";
                contactView.HeightResizePolicy = "FILL_TO_PARENT";

                // Configure visuals of ContactView via properties
                contactView.Name = contact.Name;
                contactView.ImageURL = contact.ImageURL;
                contactView.Color = contact.Color;
                contactView.Shape = contact.Shape;
                contentLayout.Add(contactView);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application application = Application.NewApplication();
            VisualsExample visualsExample = new VisualsExample(application);
            application.MainLoop();
        }
    }
}