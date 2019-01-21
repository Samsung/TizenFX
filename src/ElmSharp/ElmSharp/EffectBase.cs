/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace ElmSharp
{
    /// <summary>
    /// The EffectBase class for TransitEffect.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class EffectBase
    {
        /// <summary>
        /// EffectEnded event will be triggered when the effect has ended.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler EffectEnded;

        internal abstract IntPtr CreateEffect(IntPtr transit);

        internal void SendEffectEnd()
        {
            EffectEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}