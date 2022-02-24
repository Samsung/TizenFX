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
    /// When implemented in a renderer, registers a platform-specific effect on an element.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IEffectControlProvider
    {
        /// <summary>
        /// Registers the effect with the element by establishing the parent-child relations needed for rendering on the specific platform.
        /// </summary>
        /// <param name="effect">The effect to register.</param>
        void RegisterEffect(Effect effect);
    }
}
 
