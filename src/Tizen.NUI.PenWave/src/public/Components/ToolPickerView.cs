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
        private View mRootView;
        private Dictionary<ITool.ToolType, View> mToolIcons;
        // private List<View> mCustomIcons;

        public ToolPickerView(ToolManager toolManager, View rootView = null)
        {
            if (toolManager == null)
            {
                return;
            }
            mToolManager = toolManager;
            mRootView = rootView;
            mToolIcons = new Dictionary<ITool.ToolType, View>();
            // mCustomIcons = new List<View>();
            mToolManager.ToolChanged += OnToolChanged;

            InitialDefaultUI();
        }

        private void InitialDefaultUI()
        {
            if (mRootView == null)
            {
                mRootView = new View()
                {
                    CornerRadius = new Vector4(10, 10, 10, 10),
                    BackgroundImage = FrameworkInformation.ResourcePath + "images/" + "light" + "/toolbox_bg.png",
                    WidthSpecification = LayoutParamPolicies.WrapContent,
                    HeightSpecification = LayoutParamPolicies.WrapContent,
                    Layout = new GridLayout()
                    {
                        Columns = 1,
                        RowSpacing = 4,
                        Padding = new Extents(16, 16, 16, 16)
                    },
                };
            }
            this.Add(mRootView);
            UpdateUI();
        }

        public void ShowTool(ITool.ToolType type)
        {
            View toolView;
            if (mToolIcons.TryGetValue(type, out toolView))
            {
                mRootView.Add(toolView);
            }
        }

        public void HideTool(ITool.ToolType type)
        {
            View toolView;
            if (mToolIcons.TryGetValue(type, out toolView))
            {
                mRootView.Remove(toolView);
            }
        }

        public void AddCustomToolIcon(View view)
        {
            mRootView.Add(view);
        }

        public void RemoveCustomToolIcon(View view)
        {
            mRootView.Remove(view);
        }

        private void UpdateUI()
        {
            foreach (ITool tool in mToolManager.Tools.Values) {
                View toolView = tool.GetUI();
                if (mToolIcons.TryAdd(tool.Type, toolView))
                {
                    mRootView.Add(toolView);
                }
            }
        }

        private void OnToolChanged(ITool.ToolType toolType, int type)
        {
            // UpdateUI();
        }


    }
}