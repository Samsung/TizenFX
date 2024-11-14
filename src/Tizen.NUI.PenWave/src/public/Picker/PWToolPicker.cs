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
    public class PWToolPicker : View
    {
        private readonly PWCanvasView canvasView;
        private readonly Dictionary<Type, ToolBase> tools;

        public delegate void ToolChangedEventHandler(ToolBase tool);
        public event ToolChangedEventHandler ToolChanged;


        public PWToolPicker(PWCanvasView canvasView)
        {
            this.canvasView = canvasView;
            tools = new Dictionary<Type, ToolBase>();

            var pencilTool = new PencilTool(PencilTool.BrushType.Stroke, Color.Black, 5.0f);
            var eraserTool = new EraserTool(EraserTool.EraserType.Partial, 48.0f);
            var selectionTool = new SelectionTool(SelectionTool.SelectionType.Move);

            AddTool(pencilTool);
            AddTool(eraserTool);
            AddTool(selectionTool);

            SetTool<PencilTool>();

        }


        private void AddTool(ToolBase tool)
        {
            tools[tool.GetType()] = tool;
        }

        public void SetTool<T>() where T : ToolBase
        {
            if (tools.TryGetValue(typeof(T), out ToolBase tool))
            {
                canvasView.Tool = tool;
                ToolChanged?.Invoke(tool);
            }
        }

        public T GetTool<T>() where T : ToolBase
        {
            return tools[typeof(T)] as T;
        }

        public void SetPencilToolSettings(PencilTool.BrushType brushType, Color color, float size)
        {
            if (GetTool<PencilTool>() is PencilTool pencilTool)
            {
                pencilTool.Brush = brushType;
                pencilTool.BrushColor = color;
                pencilTool.BrushSize = size;
                SetTool<PencilTool>();
            }
        }

        public void SetEraserToolSettings(EraserTool.EraserType eraserType, float radius)
        {
            if (GetTool<EraserTool>() is EraserTool eraserTool)
            {
                eraserTool.Eraser = eraserType;
                eraserTool.EraserRadius = radius;
                SetTool<EraserTool>();
            }
        }

        public void SetSelectionToolSettings(SelectionTool.SelectionType selectionType)
        {
            if (GetTool<SelectionTool>() is SelectionTool selectionTool)
            {
                selectionTool.Selection = selectionType;
                SetTool<SelectionTool>();
            }
        }

        public bool IsPencilToolActive => canvasView.Tool is PencilTool;
        public bool IsEraserToolActive => canvasView.Tool is EraserTool;
        public bool IsSelectionToolActive => canvasView.Tool is SelectionTool;
    }
}
