﻿/*
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

namespace NUITizenGallery
{
    public partial class ActivityIndicatorPage : View
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();

            string[] imageArray = new string[13];
            for(int i = 0; i < 13; ++i) {
                imageArray[i] = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/progress_" + i.ToString() + ".png";
            }
            Spinner.ImageArray = imageArray;
        }
    }
}
