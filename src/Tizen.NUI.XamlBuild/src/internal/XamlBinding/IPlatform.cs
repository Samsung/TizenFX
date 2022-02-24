/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// For internal use.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IPlatform
    {
        /// <summary>
        /// Returns the native size.
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="widthConstraint">The width constraint.</param>
        /// <param name="heightConstraint">The height constraint.</param>
        /// <returns>The native size.</returns>
        //SizeRequest GetNativeSize(BaseHandle view, double widthConstraint, double heightConstraint);
    }
}
 
