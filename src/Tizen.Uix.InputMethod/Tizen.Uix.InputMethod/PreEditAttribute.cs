/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// Enumeration for Attribute Type
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum AttributeType
    {
        /// <summary>
        /// No attribute
        /// </summary>
        None,
        /// <summary>
        /// A font style attribute, e.g., underline, etc.
        /// </summary>
        FontStyle
    };
    /// <summary>
    /// This class represents the attributes for preedit string.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PreEditAttribute
    {
        /// <summary>
        /// The start position in the string of this attribute
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public uint Start
        {
            get;
            set;
        }

        /// <summary>
        /// The character length of this attribute, the range is [Start, Start+Length]
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public uint Length
        {
            get;
            set;
        }

        /// <summary>
        /// The type of this attribute
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public AttributeType Type
        {
            get;
            set;
        }

        /// <summary>
        /// The value of this attribute
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public uint Value
        {
            get;
            set;
        }
    }
}
