/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// EnvironmentVariable
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    static public class EnvironmentVariable
    {
        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetEnvironmentVariable")]
        private static extern string EnvironmentVariable_GetEnvironmentVariable(string jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetEnvironmentVariable")]
        private static extern bool EnvironmentVariable_SetEnvironmentVariable(string jarg1, string jarg2);

        /// <summary>
        /// Get value of the specified environment variable.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns>The value of the specified environment variable.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public string GetEnvironmentVariable(string variable)
        {
            return EnvironmentVariable_GetEnvironmentVariable(variable);
        }

        /// <summary>
        /// Set value of the specified environment variable.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="value">String to set as a value.</param>
        /// <returns>True on success, false on error.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool SetEnvironmentVariable(string variable, string value)
        {
            return EnvironmentVariable_SetEnvironmentVariable(variable, value);
        }
    }
}
