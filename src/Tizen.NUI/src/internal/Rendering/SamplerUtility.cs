/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// FadeTransitionItem is an object to set Fade transition of a View that will appear or disappear.
    /// FadeTransitionItem object is required to be added to the TransitionSet to play.
    /// </summary>
    internal class SamplerUtility
    {
        public enum PresetFilter
        {
            None = 0,
            Default,
            Nearest,
            Linear,
            NearestMipmapNearest,
            LinearMipmapNearest,
            NearestMipmapLinear,
            LinearMipmapLinear
        }

        public static PresetFilter GetPresetFilter(SamplerFilter samplerFilter, MipmapFilter mipmapFilter = MipmapFilter.None)
        {
            if(samplerFilter == SamplerFilter.Nearest)
            {
                switch(mipmapFilter)
                {
                    case MipmapFilter.None:
                    {
                        return PresetFilter.Nearest;
                    }
                    case MipmapFilter.Nearest:
                    {
                        return PresetFilter.NearestMipmapNearest;
                    }
                    case MipmapFilter.Linear:
                    {
                        return PresetFilter.NearestMipmapLinear;
                    }
                }
            }
            else if(samplerFilter == SamplerFilter.Linear)
            {
                switch(mipmapFilter)
                {
                    case MipmapFilter.None:
                    {
                        return PresetFilter.Linear;
                    }
                    case MipmapFilter.Nearest:
                    {
                        return PresetFilter.LinearMipmapNearest;
                    }
                    case MipmapFilter.Linear:
                    {
                        return PresetFilter.LinearMipmapLinear;
                    }
                }
            }
            return PresetFilter.None;
        }
    }
}
