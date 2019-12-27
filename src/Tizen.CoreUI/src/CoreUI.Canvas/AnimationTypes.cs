/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.Canvas {
    /// <summary>Animation repeat mode.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum AnimationRepeatMode
    {
        /// <summary>Restart animation when the animation ends: The animation will play again from the beginning to the end.</summary>
        /// <since_tizen> 6 </since_tizen>
        Restart = 0,
        /// <summary>Reverse animation when the animation ends: The animation will continue playing from the end to the beginning.</summary>
        /// <since_tizen> 6 </since_tizen>
        Reverse = 1,
        Last = 2,
    }
}

