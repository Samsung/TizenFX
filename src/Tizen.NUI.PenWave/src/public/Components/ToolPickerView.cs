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
    public class ToolPickerRowContainer : View
    {
        public bool isIconsRow;
    }

    public class ToolPickerView : View, IToolPickerView
    {
        private ToolManager mToolManager;
        private Dictionary<ITool.ToolType, View> mToolIcons;
        private List<View> mCustomIcons;

        private int mIconsInRow = 4;

        public ToolPickerView(ToolManager toolManager)
        {
            mToolManager = toolManager;
            mToolIcons = new Dictionary<ITool.ToolType, View>();
            mCustomIcons = new List<View>();
            InitialDefaultUI();
        }

        public void InitialDefaultUI()
        {
            CornerRadius = new Vector4(10, 10, 10, 10);
            BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/" + "light" + "/toolbox_bg.png";

            var viewBrushColors = CreateView();

            foreach (var item in PencilTool.mBrushColors)
            {
                ColorIcon i = new ColorIcon(item);
                i.TouchEvent += IconClick;
                viewBrushColors.Add(i);
            }
            this.Add(viewBrushColors);
        }

        protected bool IconClick(object sender, TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                if (sender is ColorIcon icon)
                {
                    Interop.ExtRenderer.SetStrokeColor(icon.GetColorHex(), 1.0f);

                }
            }
            return true;
        }

        public void AddCustomToolIcon(View view)
        {

        }

        public void RemoveCustomToolIcon(View view)
        {

        }

        protected ToolPickerRowContainer CreateView()
        {
            var row = new ToolPickerRowContainer()
            {
                Layout = new GridLayout()
                {
                    Columns = mIconsInRow,
                    ColumnSpacing = 8,
                    RowSpacing = 8,
                    Padding = new Extents(0, 0, 0, 0)
                },
            };

            row.isIconsRow = true;
            return row;
        }


    }
}