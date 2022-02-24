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
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Mono.Cecil;
using Tizen.NUI.Xaml;
using System;
using Tizen.NUI.Xaml.Build.Tasks;
using System.Linq;

namespace Tizen.NUI.Xaml
{
    interface ICompiledTypeConverter
    {
        IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node);
    }
}

namespace Tizen.NUI.Xaml.Core.XamlC
{
    //only used in unit tests to make sure the compiled InitializeComponent is invoked
    class IsCompiledTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            if (value != "IsCompiled?")
                throw new Exception();
            yield return Instruction.Create(OpCodes.Ldc_I4_1);
        }
    }
}
 
