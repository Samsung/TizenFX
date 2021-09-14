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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace NUITizenGallery
{
    public partial class CollectionViewCustomItem : RecyclerViewItem
    {
        void OnClicked(object sender, ClickedEventArgs e)
        {
            BackgroundColor = (IsSelected?
                                (((BindingContext == null) && (BindingContext is TestItem))?
                                    Color.Cyan: ((TestItem)BindingContext).BgColor):
                                Color.White);
        }

        public CollectionViewCustomItem()
        {
            Tizen.Log.Error("NUI", "Custom Item Created");
            InitializeComponent();
            Tizen.Log.Error("NUI", "Custom Item Initalzied");
            Clicked+=OnClicked;
        }
    }
}
