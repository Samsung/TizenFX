using System.Numerics;
/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Index of Transform feature.
    /// Each TransformTypes has their own matched MotionValue type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionTransformIndex : MotionIndex
    {
        /// <summary>
        /// The list of component types what this MotionIndex can control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum TransformTypes
        {
            /// <summary>
            /// The position of ModelNode. MotionValue should be Vector3.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Position,

            /// <summary>
            /// The x position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionX,

            /// <summary>
            /// The y position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionY,

            /// <summary>
            /// The z position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionZ,

            /// <summary>
            /// The orientation of ModelNode. MotionValue should be Rotation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Orientation,

            /// <summary>
            /// The scale of ModelNode. MotionValue should be Vector3.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Scale,

            /// <summary>
            /// The x scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleX,

            /// <summary>
            /// The y scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleY,

            /// <summary>
            /// The z scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleZ,
        }

        /// <summary>
        /// Create an initialized motion index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionTransformIndex()
        {
        }

        /// <summary>
        /// The component type what this MotionIndex want to control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransformTypes TransformType { get; set; } = TransformTypes.Position;

        /// <summary>
        /// Get uniform name of TransformType.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override string GetPropertyName(ModelNode node)
        {
            switch (TransformType)
            {
                case TransformTypes.Position:
                {
                    return "Position";
                }
                case TransformTypes.PositionX:
                {
                    return "PositionX";
                }
                case TransformTypes.PositionY:
                {
                    return "PositionY";
                }
                case TransformTypes.PositionZ:
                {
                    return "PositionZ";
                }
                case TransformTypes.Orientation:
                {
                    return "Orientation";
                }
                case TransformTypes.Scale:
                {
                    return "Scale";
                }
                case TransformTypes.ScaleX:
                {
                    return "ScaleX";
                }
                case TransformTypes.ScaleY:
                {
                    return "ScaleY";
                }
                case TransformTypes.ScaleZ:
                {
                    return "ScaleZ";
                }
            }
            return null;
        }
    }
}
