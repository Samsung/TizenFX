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
namespace CoreUI.UI.Focus {
    /// <summary>Focus directions.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum Direction
    {
        /// <summary>previous direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Previous = 0,
        /// <summary>next direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Next = 1,
        /// <summary>up direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Up = 2,
        /// <summary>down direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Down = 3,
        /// <summary>right direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Right = 4,
        /// <summary>left direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Left = 5,
        /// <summary>last direction</summary>
        /// <since_tizen> 6 </since_tizen>
        Last = 6,
    }
}

namespace CoreUI.UI.Focus {
    /// <summary>Focus Movement Policy.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum MovePolicy
    {
        /// <summary>Move focus by mouse click or touch. Elementary focus is set on mouse click and this is checked at mouse up time. (default)</summary>
        /// <since_tizen> 6 </since_tizen>
        Click = 0,
        /// <summary>Move focus by mouse in. Elementary focus is set on mouse move when the mouse pointer is moved into an object.</summary>
        /// <since_tizen> 6 </since_tizen>
        MoveIn = 1,
        /// <summary>Move focus by key. Elementary focus is set on key input like Left, Right, Up, Down, Tab, or Shift+Tab.</summary>
        /// <since_tizen> 6 </since_tizen>
        KeyOnly = 2,
    }
}

namespace CoreUI.UI {
    /// <summary>Type of multi selectable object.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum SelectMode
    {
        /// <summary>Only single child is selected. If a child is selected, previous selected child will be unselected.</summary>
        /// <since_tizen> 6 </since_tizen>
        Single = 0,
        /// <summary>Allow multiple selection of children.</summary>
        /// <since_tizen> 6 </since_tizen>
        Multi = 1,
        /// <summary>No child can be selected at all.</summary>
        /// <since_tizen> 6 </since_tizen>
        None = 2,
    }
}

