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
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// Auxiliary Message Event arguments
    /// This has the three members as key, value and options.
    /// Options has the list of string
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AuxiliaryMessageEventArgs : EventArgs
    {
        private string key;
        private string val;
        private List<string> options;

        public string Key
        {
            get => key;
            internal set => key = value;
        }

        public string Value
        {
            get => val;
            internal set => val = value;
        }

        public List<string> Options
        {
            get => options;
            internal set => options = value;
        }
    }
}
