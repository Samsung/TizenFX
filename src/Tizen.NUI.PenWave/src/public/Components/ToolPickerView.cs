/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class ToolPickerView : View, IToolPickerView
    {
        private ToolManager mToolManager;
        // private Dictionary<ITool.ToolType, View> mToolIcons;
        // private List<View> mCustomIcons;

        public ToolPickerView(ToolManager toolManager)
        {
            mToolManager = toolManager;
            // mToolIcons = new Dictionary<ITool.ToolType, View>();
            // mCustomIcons = new List<View>();

            mToolManager.ToolChanged += OnToolChanged;
            InitialDefaultUI();
        }

        public void InitialDefaultUI()
        {
            CornerRadius = new Vector4(10, 10, 10, 10);
            BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/toolbox_bg.png";


            WidthSpecification = LayoutParamPolicies.WrapContent;
            HeightSpecification = LayoutParamPolicies.WrapContent;

            var gridLayout = new GridLayout()
            {
                Columns = 1,
                RowSpacing = 4,
                Padding = new Extents(16, 16, 16, 16)
            };
            Layout = gridLayout;


            foreach (ITool tool in mToolManager.Tools.Values) {
                this.Add(tool.GetUI());
            }
        }



        public void AddCustomToolIcon(View view)
        {

        }

        public void RemoveCustomToolIcon(View view)
        {

        }



        private void OnToolChanged(ITool.ToolType toolType, int type)
        {

        }


    }
}