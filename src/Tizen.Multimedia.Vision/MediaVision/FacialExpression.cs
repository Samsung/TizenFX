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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Specifies the expression types for faces.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FacialExpression
    {
        /// <summary>
        /// Unknown face expression.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Unknown,

        /// <summary>
        /// Face expression is neutral.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Neutral,

        /// <summary>
        /// Face expression is smiling.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Smile,

        /// <summary>
        /// Face expression is sadness.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sadness,

        /// <summary>
        /// Face expression is surprise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Surprise,

        /// <summary>
        /// Face expression is anger.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Anger,

        /// <summary>
        /// Face expression is fear.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Fear,

        /// <summary>
        /// Face expression is disgust.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Disgust
    }
}
