/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Highlight class for the editable.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Highlight
    {
        private IntPtr _raw = IntPtr.Zero;
        private int _x;
        private int _y;
        private int _w;
        private int _h;
        private ShapeType _type;

        /// <summary>
        /// Initializes the Highlight class.
        /// </summary>
        /// <param name="type">The highlight shape type.</param>
        /// <param name="x">The highlight geometry x.</param>
        /// <param name="y">The highlight geometry y.</param>
        /// <param name="w">The highlight geometry w.</param>
        /// <param name="h">The highlight geometry h.</param>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Highlight(ShapeType type, int x, int y, int w, int h)
        {
            _type = type;
            _x = x;
            _y = y;
            _w = w;
            _h = h;
        }

        /// <summary>
        /// Destructor of the Highlight class.
        /// </summary>
        ~Highlight()
        {
            Interop.WatchfaceComplication.DestroyHighlight(_raw);
        }

        internal IntPtr Raw
        {
            get
            {
                ComplicationError ret;
                if (_raw == IntPtr.Zero)
                {
                    ret = Interop.WatchfaceComplication.CreateHighlight(out _raw);
                    if (ret != ComplicationError.None)
                    {
                        ErrorFactory.ThrowException(ret, "Fail to create Highlight");
                    }
                }

                ret = Interop.WatchfaceComplication.SetHighlightGeometry(_raw, _x, _y, _w, _h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to set Highlight geometry");
                }
                ret = Interop.WatchfaceComplication.SetHighlightShapeType(_raw, _type);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to set Highlight type");
                }
                return _raw;
            }
        }

        /// <summary>
        /// The x coordinate.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid x value (" + value + ")");
                _x = value;
            }
        }

        /// <summary>
        /// The y coordinate.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid y value (" + value + ")");
                _y = value;
            }
        }

        /// <summary>
        /// The width of editable.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int W
        {
            get
            {
                return _w;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid w value (" + value + ")");
                _w = value;
            }
        }

        /// <summary>
        /// The height of editable.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int H
        {
            get
            {
                return _h;
            }
            set
            {
                if (value < 0)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid h value (" + value + ")");
                _h = value;
            }
        }

        /// <summary>
        /// The shape of editable.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ShapeType ShapeType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
