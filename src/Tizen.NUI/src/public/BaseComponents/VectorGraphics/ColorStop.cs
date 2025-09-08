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
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// A data storing the information about the color and its relative position inside the gradient bounds.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ColorStop
    {
        private float offset; //The relative position of the color. 
        private Color color; //The color value.

        /// <summary>
        /// Initializes a new instance of the ColorStop class with the specified offset and color.
        /// </summary>
        /// <param name="offset">The offset at which the color stop applies.</param>
        /// <param name="color">The color to apply at the specified offset.</param>
        /// <since_tizen> 9 </since_tizen>
        public ColorStop(float offset, Color color)
        {
            this.offset = offset;
            this.color = color;
        }

        /// <summary>
        /// Gets or sets the relative position of the color stop along the gradient line.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float Offset
        {
            set
            {
                this.offset = value;
            }
            get
            {
                return this.offset;
            }
        }

        /// <summary>
        /// Gets or sets the color value of the gradient stop.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color Color
        {
            set {
                this.color = value;
            }
            get {
                return this.color;
            }
        }
    };
}
