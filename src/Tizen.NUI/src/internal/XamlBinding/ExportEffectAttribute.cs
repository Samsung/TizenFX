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

namespace Tizen.NUI.Binding
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class ExportEffectAttribute : Attribute
    {
        public ExportEffectAttribute(Type effectType, string uniqueName)
        {
            if (uniqueName.Contains("."))
                throw new ArgumentException("uniqueName must not contain a .");
            Type = effectType;
            Id = uniqueName;
        }

        internal string Id { get; private set; }

        internal Type Type { get; private set; }
    }
}
