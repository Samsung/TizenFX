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
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace VisualsUsingCustomView
{
    class VisualsExample : NUIApplication
    {
        public VisualsExample() : base()
        {
        }

        public VisualsExample(string stylesheet) : base(stylesheet)
        {
        }

        public VisualsExample(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(14, 1);
            contentLayout.Name = "ContentLayout";
            //contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            //contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.PivotPoint = PivotPoint.TopLeft;
            contentLayout.ParentOrigin = ParentOrigin.TopLeft;
            contentLayout.Size2D = new Vector2(window.Size.Width, window.Size.Height);
            contentLayout.SetCellPadding(new Size2D(5, 5));
            contentLayout.BackgroundColor = new Color(0.949f, 0.949f, 0.949f, 1.0f);

            window.Add(contentLayout);

            TextLabel title = new TextLabel("Contacts List with Visuals");
            title.Name = "Title";
            title.StyleName = "Title";
            title.WidthResizePolicy = ResizePolicyType.FillToParent;
            title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            contentLayout.Add(title);
            contentLayout.SetFitHeight(0);

            // Create ContactView(s) from ContactItem(s) in ContactsList and add them to TableView
            ContactView contactView;
            foreach (ContactItem contact in ContactsList.s_contactData)
            {
                contactView = new ContactView();
                contactView.WidthResizePolicy = ResizePolicyType.FillToParent;
                contactView.HeightResizePolicy = ResizePolicyType.FillToParent;

                // Configure visuals of ContactView via properties
                contactView.NameField = contact.Name;
                contactView.MaskURL = contact.MaskURL;
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
        static void _Main(string[] args)
        {
            VisualsExample visualsExample = new VisualsExample();
            visualsExample.Run(args);
        }
    }
}
