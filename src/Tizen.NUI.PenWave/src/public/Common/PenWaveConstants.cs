// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;

namespace Tizen.NUI.PenWave
{
    internal struct FrameworkInformation
    {
        public readonly static string ResourcePath = "/usr/share/dotnet.tizen/framework/res/";
    }

    /// <summary>
    /// The type of brush used to draw.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum BrushType
    {
        Stroke  = 0,
        VarStroke,
        DotBrush,
        SprayBrush,
        DashedLine,
        Highlighter,
        VarStrokeInc,
        SoftBrush,
        SharpBrush
    }

    /// <summary>
    /// The type of eraser tool.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum EraserType
    {
        Partial = 0,
        Full,
    }

    /// <summary>
    /// Enumeration for the type of selection operation
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SelectionType
    {
        Move  = 0,
        Scale,
        Rotate,
    }

    /// <summary>
    /// Enumeration for the grid density type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GridDensityType
    {
        None = 0,
        Small = 1,
        Medium = 2,
        Large = 4
    }

    /// <summary>
    /// Enumeration for the type of ruler operation
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum RulerType
    {
        Line  = 0,
        Circle,
        Rectangle,
    }

    // The error codes returned from the native side when adding points to a shape.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ErrorShapeAddPointsType
    {
        NoError = 0,
        OverflowShape,
        NoCanvasSet,
        NoShapesInCanvas,
        BadIdShape,
        DrawableIsNotAShape,
        DrawableIsNotALine,
        DrawingCanceled
    }


}