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
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    internal class EXamlValueConverterFromString
    {
        private EXamlContext context;

        internal string GetString()
        {
            string ret = "";
            ret += String.Format("{0} {1}", context.GetValueString(converterInstance), context.GetValueString(Value));
            return ret;
        }

        internal EXamlValueConverterFromString(EXamlContext context, TypeDefinition converterType, string value)
        {
            this.context = context;

            ConverterType = converterType;
            Value = value;

            if (!context.typeToInstance.ContainsKey(converterType))
            {
                converterInstance = new EXamlCreateObject(context, null, converterType);
                context.typeToInstance.Add(converterType, converterInstance);
            }
            else
            {
                converterInstance = context.typeToInstance[converterType];
            }
        }

        internal TypeDefinition ConverterType
        {
            get;
            private set;
        }

        internal string Value
        {
            get;
            private set;
        }

        private EXamlCreateObject converterInstance;
    }
}
 
