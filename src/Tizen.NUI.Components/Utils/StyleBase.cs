/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// StyleBase class.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class StyleBase
    {
        /// <summary>
        /// StyleBase construct.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public StyleBase()
        {
        }

        /// <summary>
        /// Content object.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        protected object Content
        {
            get;
            set;
        }

        /// <summary>
        /// Get view style.
        /// </summary>
        /// <returns>ViewStyle</returns>
        /// <since_tizen> 8 </since_tizen>
        protected internal virtual ViewStyle GetViewStyle()
        {
            return Content as ViewStyle;
        }
    }
}

