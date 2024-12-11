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
        /// <summary>
        /// The Stroke brush type.
        /// </summary>
        Stroke  = 0,

        /// <summary>
        /// The VarStroke brush type.
        /// </summary>
        VarStroke,

        /// <summary>
        /// The DotBrush brush type.
        /// </summary>
        DotBrush,

        /// <summary>
        /// The SprayBrush brush type.
        /// </summary>
        SprayBrush,

        /// <summary>
        /// The DashedLine brush type.
        /// </summary>
        DashedLine,

        /// <summary>
        /// The Highlighter brush type.
        /// </summary>
        Highlighter,

        /// <summary>
        /// The VarStrokeInc brush type.
        /// </summary>
        VarStrokeInc,

        /// <summary>
        /// The SoftBrush brush type.
        /// </summary>
        SoftBrush,

        /// <summary>
        /// The SharpBrush brush type.
        /// </summary>
        SharpBrush
    }

    /// <summary>
    /// The type of eraser tool.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum EraserType
    {
        /// <summary>
        /// The partial eraser type.
        /// </summary>
        Partial = 0,

        /// <summary>
        /// The full eraser type.
        /// </summary>
        Full,
    }

    /// <summary>
    /// Enumeration for the type of selection transform
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SelectionTransformType
    {
        /// <summary>
        /// The move type.
        /// </summary>
        Move  = 0,

        /// <summary>
        /// The scale type.
        /// </summary>
        Scale,

        /// <summary>
        /// The rotate type.
        /// </summary>
        Rotate,
    }

    /// <summary>
    /// Enumeration for the type of selection operation
    /// </summary>
    public enum SelectionOperationType
    {
        /// <summary>
        /// The none operation type.
        /// </summary>
        None,

        /// <summary>
        /// The copy operation type.
        /// </summary>
        Copy,

        /// <summary>
        /// The cut operation type.
        /// </summary>
        Cut,

        /// <summary>
        /// The paste operation type.
        /// </summary>
        Paste,
    }

    /// <summary>
    /// Enumeration for the grid density type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GridDensityType
    {
        /// <summary>
        /// The none grid density type.
        /// </summary>
        None = 0,

        /// <summary>
        /// The small grid density type.
        /// </summary>
        Small = 1,

        /// <summary>
        /// The medium grid density type.
        /// </summary>
        Medium = 2,

        /// <summary>
        /// The large grid density type.
        /// </summary>
        Large = 4
    }

    /// <summary>
    /// Enumeration for the type of ruler operation
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum RulerType
    {
        /// <summary>
        /// The line ruler type.
        /// </summary>
        Line  = 0,

        /// <summary>
        /// The circle ruler type.
        /// </summary>
        Circle,

        /// <summary>
        /// The rectangle ruler type.
        /// </summary>
        Rectangle,
    }

    /// <summary>
    /// The error codes returned from the native side when adding points to a shape.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ErrorShapeAddPointsType
    {
        /// <summary>
        /// No error occurred.
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Too many points (new shape has to be created)
        /// </summary>
        OverflowShape,

        /// <summary>
        /// No canvas set
        /// </summary>
        NoCanvasSet,

        /// <summary>
        /// No shapes in canvas
        /// </summary>
        NoShapesInCanvas,

        /// <summary>
        /// Bad shapeID (not exists)
        /// </summary>
        BadIdShape,

        /// <summary>
        /// Object with id=shapeID is not a shape
        /// </summary>
        DrawableIsNotAShape,

        /// <summary>
        /// Object with id=shapeID is not a line
        /// </summary>
        DrawableIsNotALine,

        /// <summary>
        /// Drawing has been canceled.
        /// </summary>
        DrawingCanceled
    }
}
