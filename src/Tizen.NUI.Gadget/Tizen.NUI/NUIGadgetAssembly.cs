/*
* Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;
using Tizen.Applications;

namespace Tizen.NUI
{
    /// <summary>
    /// Represents a class that provides access to the methods and properties of the NUIGadgetAssembly.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIGadgetAssembly
    {
        internal NUIGadgetAssembly(UIGadgetAssembly assembly) { Assembly = assembly; }

        internal UIGadgetAssembly Assembly { get; set; }

        /// <summary>
        /// Property indicating whether the weak reference to the gadget assembly is still alive.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public bool IsAlive {  get { return Assembly.IsAlive; } }
    }
}
