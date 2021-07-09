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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class CheckBoxTestPage : View
    {
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";

        public CheckBoxTestPage()
        {
            InitializeComponent();

            var check2style = checkBox2.Style;
            check2style.Icon.ResourceUrl = new Selector<string>
            {
                Normal = ResourcePath + "controller_btn_check_off.png",
                Selected = ResourcePath + "controller_btn_check_on.png",
                DisabledSelected = ResourcePath + "controller_btn_check_off.png",
                Disabled = ResourcePath + "controller_btn_check_off.png",
            };

            checkBox2.ApplyStyle(check2style);

            checkBox1.Clicked += (o, e) =>
            {
                if (checkBox1.IsSelected)
                {
                    checkBox1.Text = "True";
                }
                else
                {
                    checkBox1.Text = "False";
                }
            };

            checkBox2.Clicked += (o, e) =>
            {

            };
        }
    }
}

