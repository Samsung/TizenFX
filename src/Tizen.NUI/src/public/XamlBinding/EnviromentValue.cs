/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding
{
    /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Key")]
    public class EnviromentValue
    {
        static internal Dictionary<string, string> keyToValue = new Dictionary<string, string>();

        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void RegisterLocalEnviroment(string key, string value)
        {
            if (keyToValue.ContainsKey(key))
            {
                keyToValue[key] = value;
            }
            else
            {
                keyToValue.Add(key, value);
            }
        }

        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key
        {
            get;
            set;
        }

        internal string Value
        {
            get
            {
                string ret = Environment.GetEnvironmentVariable(Key);

                if (null == ret)
                {
                    keyToValue.TryGetValue(Key, out ret);
                }

                return ret;
            }
        }
    }
}
