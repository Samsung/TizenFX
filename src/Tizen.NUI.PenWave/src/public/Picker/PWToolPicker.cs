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
using Tizen.NUI.Components;

namespace Tizen.NUI.PenWave
{
    public class PWToolPicker : View
    {
        private static readonly string resourcePath = FrameworkInformation.ResourcePath + "images/light/";

        // for pencilTool
        private static readonly Dictionary<PencilTool.BrushType, string> BrushIconMap = new Dictionary<PencilTool.BrushType, string>
        {
            { PencilTool.BrushType.Stroke, "icon_pencil" },
            { PencilTool.BrushType.VarStroke, "icon_varstroke_dec" },
            { PencilTool.BrushType.VarStrokeInc, "icon_varstroke_inc" },
            { PencilTool.BrushType.SprayBrush, "icon_spray" },
            { PencilTool.BrushType.DotBrush, "icon_dot" },
            { PencilTool.BrushType.DashedLine, "icon_dashed_line" },
            { PencilTool.BrushType.Highlighter, "icon_highlighter" },
            { PencilTool.BrushType.SoftBrush, "icon_soft_brush" },
            { PencilTool.BrushType.SharpBrush, "icon_sharp_brush" },
        };

        private static readonly List<Color> BrushColorMap = new List<Color>
        {
            new Color("#F7B32C"),
            new Color("#FD5703"),
            new Color("#DA1727"),
            new Color("#FF00A8"),
            new Color("#74BFB8"),
            new Color("#4087C5"),
            new Color("#070044"),
            new Color("#0E0E0E"),
        };
        //

        // for canvas
        private static readonly List<Color> CanvasColor = new List<Color>
        {
            new Color("#F0F0F0"),
            new Color("#B7B7B7"),
            new Color("#E3F2FF"),
            new Color("#202022"),
            new Color("#515151"),
            new Color("#17234D"),
        };

        private static readonly Dictionary<GridDensityType, string> GridIconMap = new Dictionary<GridDensityType, string>
        {
            { GridDensityType.Small, "icon_small_grid_density" },
            { GridDensityType.Medium, "icon_medium_grid_density" },
            { GridDensityType.Large, "icon_large_grid_density" },
        };

        // Properties to define colors for different states.
        public string IconStateNormalColor { get; set; } = "#17234d";
        public string IconStateSelectedColor { get; set; } = "#FF6200";
        public string IconStatePressedColor { get; set; } = "#FF6200";
        public string IconStateDisabledColor { get; set; } = "#CACACA";

        private readonly PWCanvasView canvasView;

        private readonly Dictionary<Type, ToolBase> tools;

        public delegate void ToolChangedEventHandler(ToolBase tool);
        public event ToolChangedEventHandler ToolChanged;

        private View rootView;
        public View PickerView { get; private set; }
        public View PopupView { get; private set; }

        private ImageView pencilButton;
        private ImageView eraserButton;
        private ImageView canvasGridButton;

        private ImageView currentBrushIcon;

        private ImageView canvasUndoButton;
        private ImageView canvasRedoButton;


        public PWToolPicker(PWCanvasView canvasView)
        {
            this.canvasView = canvasView;
            tools = new Dictionary<Type, ToolBase>();
        }

        public virtual void InitializeToolPicker()
        {
            InitializeUI();

            InitializeCanvasTool();

            InitializeTools();
        }

        private void UpdateUI()
        {
            canvasRedoButton.IsEnabled = canvasView.CanRedo;
            canvasUndoButton.IsEnabled = canvasView.CanUndo;

            if (canvasView.CanUndo == false)
            {
                canvasUndoButton.Color = new Color(IconStateDisabledColor);
            }
            else
            {
                canvasUndoButton.Color = new Color(IconStateNormalColor);
            }
            if (canvasView.CanRedo == false)
            {
                canvasRedoButton.Color = new Color(IconStateDisabledColor);
            }
            else
            {
                canvasRedoButton.Color = new Color(IconStateNormalColor);
            }
        }

        private void InitializeUI()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;

            rootView = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                }
            };

            PickerView = new View
            {
                CornerRadius = new Vector4(10, 10, 10, 10),
                BackgroundImage = resourcePath + "/menu_bg.png",
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
            };
            PickerView.TouchEvent += (s, e) => { return true; };

            PopupView = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundImage = resourcePath + "/canvas_popup_bg.png",
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                Padding = new Extents(20, 20, 20, 20)
            };
            PopupView.TouchEvent += (s, e) => { return true; };
            canvasView.TouchEvent += (s, e) => { ClearPopupView(); return false; };
            PopupView.Hide();

            rootView.Add(PickerView);
            rootView.Add(PopupView);
            Add(rootView);

            canvasView.Add(this);
        }

        private void InitializeCanvasTool()
        {
            var canvasBackgroundColorIcon = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                Color = new Color(IconStateNormalColor),
                ResourceUrl = resourcePath + "icon_color_palette.png",
            };
            canvasBackgroundColorIcon.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    ShowPaletteSettings();
                }
                return true;
            };
            PickerView.Add(canvasBackgroundColorIcon);

            canvasGridButton = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                Color = new Color(IconStateNormalColor),
                ResourceUrl = resourcePath + "icon_medium_grid_density.png",
            };
            canvasGridButton.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    ShowGridSettings();
                }
                return true;
            };
            PickerView.Add(canvasGridButton);

            canvasUndoButton = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                Color = new Color(IconStateDisabledColor),
                ResourceUrl = resourcePath + "icon_undo.png",
            };

            canvasRedoButton = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                Color = new Color(IconStateDisabledColor),
                ResourceUrl = resourcePath + "icon_redo.png",
            };

            canvasUndoButton.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    canvasView.Undo();
                    UpdateUI();
                }
                return true;
            };

            canvasRedoButton.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    canvasView.Redo();
                    UpdateUI();
                }
                return true;
            };

            PickerView.Add(canvasUndoButton);
            PickerView.Add(canvasRedoButton);


            var canvasClearButton = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                Color = new Color(IconStateNormalColor),
                ResourceUrl = resourcePath + "icon_clear.png",
            };
            canvasClearButton.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    canvasView.ClearCanvas();
                }
                return true;
            };
            PickerView.Add(canvasClearButton);
        }

        private void ShowPaletteSettings()
        {
            ClearPopupView();

            PopupView.Show();

            var canvasBackgroundColorPicker = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            PopupView.Add(canvasBackgroundColorPicker);

            var canvasColors = CanvasColor;
            foreach (var color in canvasColors)
            {
                var canvasColorIcon = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = color,
                    ResourceUrl = resourcePath + "/color_icon_base.png",
                };
                canvasColorIcon.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        canvasView.SetCanvasColor(color);
                    }
                    return true;
                };
                canvasBackgroundColorPicker.Add(canvasColorIcon);
            }

        }

        private void ShowGridSettings()
        {
            ClearPopupView();

            PopupView.Show();

            var canvasGridPicker = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            PopupView.Add(canvasGridPicker);

            foreach (var icon in GridIconMap)
            {
                var gridIcon = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = new Color(IconStateNormalColor),
                    ResourceUrl = resourcePath + icon.Value + ".png",
                };
                gridIcon.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        canvasView.ToggleGrid(icon.Key);
                        canvasGridButton.ResourceUrl = gridIcon.ResourceUrl;
                        canvasGridButton.Color = new Color(IconStateSelectedColor);
                    }
                    return true;
                };
                canvasGridPicker.Add(gridIcon);
            }
        }

        private void InitializeTools()
        {
            var pencilTool = new PencilTool(PencilTool.BrushType.Stroke, Color.Black, 5.0f);
            var eraserTool = new EraserTool(EraserTool.EraserType.Partial, 48.0f);
            var selectionTool = new SelectionTool(SelectionTool.SelectionType.Move);

            pencilTool.ActionStarted += (s, e) =>
            {
                UpdateUI();
            };
            eraserTool.ActionStarted += (s, e) =>
            {
                UpdateUI();
            };
            selectionTool.ActionStarted += (s, e) =>
            {
                UpdateUI();
            };

            pencilTool.ActionFinished += (s, e) =>
            {
                UpdateUI();
            };
            eraserTool.ActionFinished += (s, e) =>
            {
                UpdateUI();
            };
            selectionTool.ActionFinished += (s, e) =>
            {
                UpdateUI();
            };

            AddTool(pencilTool);
            AddTool(eraserTool);
            AddTool(selectionTool);

            SetTool<PencilTool>();
            ClearPopupView();
        }

        private void AddTool(ToolBase tool)
        {
            tools[tool.GetType()] = tool;

            if (tool.GetType() == typeof(PencilTool))
            {
                pencilButton = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = new Color(IconStateNormalColor),
                    ResourceUrl = resourcePath + BrushIconMap[PencilTool.BrushType.Stroke] + ".png",
                };
                pencilButton.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        if (GetTool<PencilTool>() is PencilTool pencilTool)
                        {
                            SetTool<PencilTool>();
                        }
                    }
                    return true;
                };
                PickerView.Add(pencilButton);
            }
            else if (tool.GetType() == typeof(EraserTool))
            {
                eraserButton = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = new Color(IconStateNormalColor),
                    ResourceUrl = resourcePath + "icon_eraser.png",
                };
                eraserButton.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        if (GetTool<EraserTool>() is EraserTool eraserTool)
                        {
                            SetTool<EraserTool>();
                        }
                    }
                    return true;
                };
                PickerView.Add(eraserButton);
            }
            else if (tool.GetType() == typeof(SelectionTool))
            {
                var selectionButton = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = new Color(IconStateNormalColor),
                    ResourceUrl = resourcePath + "icon_select.png",
                };

                selectionButton.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        if (e.Touch.GetState(0) == PointStateType.Down)
                        {
                            if (GetTool<SelectionTool>() is SelectionTool selectionTool)
                            {
                                SetTool<SelectionTool>();
                            }
                        }
                    }
                    return true;
                };

                PickerView.Add(selectionButton);
            }

        }

        public void SetTool<T>() where T : ToolBase
        {
            if (tools.TryGetValue(typeof(T), out ToolBase tool))
            {
                canvasView.Tool = tool;
                ShowToolSettings(tool);
                ToolChanged?.Invoke(tool);
            }
        }

        public T GetTool<T>() where T : ToolBase
        {
            return tools[typeof(T)] as T;
        }

        private void ShowToolSettings(ToolBase tool)
        {
            if (tool is PencilTool pencilTool)
            {
                ShowPencilToolSettings(pencilTool);
            }
            else if (tool is EraserTool eraserTool)
            {
                ShowEraserToolSettings(eraserTool);
            }
            else if (tool is SelectionTool selectionTool)
            {
                ShowSelectionToolSettings(selectionTool);
            }

        }

        private void ShowPencilToolSettings(PencilTool pencilTool)
        {
            ClearPopupView();

            PopupView.Show();

            // Add brush icons
            var brushTypePickerView = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            PopupView.Add(brushTypePickerView);

            foreach (var icon in BrushIconMap)
            {
                var brushIcon = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = new Color(IconStateNormalColor),
                    ResourceUrl = resourcePath + icon.Value + ".png",
                };
                brushIcon.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        pencilButton.ResourceUrl = brushIcon.ResourceUrl;
                        pencilButton.Color = new Color(IconStateSelectedColor);
                        pencilTool.Brush = icon.Key;
                        pencilTool.Activate();

                        if (currentBrushIcon != null)
                        {
                            currentBrushIcon.Color = new Color(IconStateNormalColor);
                        }
                        currentBrushIcon = brushIcon;
                        brushIcon.Color = new Color(IconStateSelectedColor);
                    }
                    return true;
                };
                brushTypePickerView.Add(brushIcon);
            }

            // Add brush color icons
            var brushColorPickerView = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            PopupView.Add(brushColorPickerView);

            var brushColors = BrushColorMap;
            foreach (var color in brushColors)
            {
                var brushColorIcon = new ImageView
                {
                    GrabTouchAfterLeave = true,
                    Size2D = new Size2D(48, 48),
                    Color = color,
                    ResourceUrl = resourcePath + "/color_icon_base.png",
                };
                brushColorIcon.TouchEvent += (s, e) =>
                {
                    if (e.Touch.GetState(0) == PointStateType.Down)
                    {
                        pencilTool.BrushColor = color;
                        pencilTool.Activate();
                    }
                    return true;
                };
                brushColorPickerView.Add(brushColorIcon);
            }

            var sizePicker = new Slider
            {
                MinValue = 1,
                MaxValue = 20,
                CurrentValue = pencilTool.BrushSize,
                WidthSpecification = 300,
            };
            sizePicker.ValueChanged += (s, e) =>
            {
                pencilTool.BrushSize = (int)e.CurrentValue;
                pencilTool.Activate();
            };

            PopupView.Add(sizePicker);
        }

        private void ShowEraserToolSettings(EraserTool eraserTool)
        {
            ClearPopupView();

            PopupView.Show();

            var eraserTypePicker = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                ResourceUrl = resourcePath + "/icon_eraser.png",
                Color = new Color(IconStateNormalColor),
            };
            eraserTypePicker.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    if (eraserTool.Eraser == EraserTool.EraserType.Partial)
                    {
                        eraserTool.Eraser = EraserTool.EraserType.Full;
                        eraserTypePicker.ResourceUrl = resourcePath + "/icon_full_eraser.png";
                    }
                    else
                    {
                        eraserTool.Eraser = EraserTool.EraserType.Partial;
                        eraserTypePicker.ResourceUrl = resourcePath + "/icon_eraser.png";
                    }
                    eraserButton.ResourceUrl = eraserTypePicker.ResourceUrl;
                    eraserButton.Color = new Color(IconStateSelectedColor);
                }
                return true;
            };
            PopupView.Add(eraserTypePicker);


            var eraserSizePicker = new Slider
            {
                MinValue = 10,
                MaxValue = 100,
                CurrentValue = eraserTool.EraserRadius,
                WidthSpecification = 300,
            };
            eraserSizePicker.ValueChanged += (s, e) => eraserTool.EraserRadius = e.CurrentValue;

            PopupView.Add(eraserSizePicker);
        }

        private void ShowSelectionToolSettings(SelectionTool selectionTool)
        {
            ClearPopupView();

            PopupView.Show();

            var selectionTypePicker = new View
            {
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Layout = new LinearLayout
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                }
            };
            PopupView.Add(selectionTypePicker);


            var selectionMoveIcon = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                ResourceUrl = resourcePath + "/icon_select_single.png",
                Color = new Color(IconStateNormalColor),
            };

            var selectionScaleIcon = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                ResourceUrl = resourcePath + "/icon_scale.png",
                Color = new Color(IconStateNormalColor),
            };

            var selectionRotateIcon = new ImageView
            {
                GrabTouchAfterLeave = true,
                Size2D = new Size2D(48, 48),
                ResourceUrl = resourcePath + "/icon_rotate.png",
                Color = new Color(IconStateNormalColor),
            };

            selectionMoveIcon.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    selectionTool.Selection = SelectionTool.SelectionType.Move;
                    selectionMoveIcon.Color = new Color(IconStateSelectedColor);
                    selectionScaleIcon.Color = new Color(IconStateNormalColor);
                    selectionRotateIcon.Color = new Color(IconStateNormalColor);
                }
                return true;
            };

            selectionScaleIcon.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    selectionTool.Selection = SelectionTool.SelectionType.Scale;
                    selectionMoveIcon.Color = new Color(IconStateNormalColor);
                    selectionScaleIcon.Color = new Color(IconStateSelectedColor);
                    selectionRotateIcon.Color = new Color(IconStateNormalColor);
                }
                return true;
            };

            selectionRotateIcon.TouchEvent += (s, e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    selectionTool.Selection = SelectionTool.SelectionType.Rotate;
                    selectionMoveIcon.Color = new Color(IconStateNormalColor);
                    selectionScaleIcon.Color = new Color(IconStateNormalColor);
                    selectionRotateIcon.Color = new Color(IconStateSelectedColor);
                }
                return true;
            };

            selectionTypePicker.Add(selectionMoveIcon);
            selectionTypePicker.Add(selectionScaleIcon);
            selectionTypePicker.Add(selectionRotateIcon);
            PopupView.Add(selectionTypePicker);
        }

        public virtual void ClearPopupView()
        {
            pencilButton.Color = new Color(IconStateNormalColor);
            eraserButton.Color = new Color(IconStateNormalColor);
            canvasGridButton.Color = new Color(IconStateNormalColor);

            int childNum = (int)PopupView.ChildCount;
            for (int i = childNum - 1; i >= 0; i--)
            {
                PopupView.Remove(PopupView.GetChildAt((uint)i));
            }
            PopupView.Hide();
        }

        public bool IsPencilToolActive => canvasView.Tool is PencilTool;
        public bool IsEraserToolActive => canvasView.Tool is EraserTool;
        public bool IsSelectionToolActive => canvasView.Tool is SelectionTool;
    }
}
