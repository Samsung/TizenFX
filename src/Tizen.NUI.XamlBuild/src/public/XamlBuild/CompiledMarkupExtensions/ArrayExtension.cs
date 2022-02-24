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
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    [ContentProperty("Items")]
    class ArrayExtension : ICompiledMarkupExtension
    {
        public IEnumerable<Instruction> ProvideValue(IElementNode node, ModuleDefinition module, ILContext context, out TypeReference memberRef)
        {
            var typeNode = node.Properties[new XmlName("", "Type")] as IElementNode;
            var typeTypeRef = context.TypeExtensions[typeNode];
            var n = node.CollectionItems.Count;

            var instructions = new List<Instruction>();
            instructions.Add(Instruction.Create(OpCodes.Ldc_I4, n));
            instructions.Add(Instruction.Create(OpCodes.Newarr, typeTypeRef));

            memberRef = typeTypeRef.MakeArrayType();
            for (var i = 0; i < n; i++)
            {
                var vardef = context.Variables[node.CollectionItems[i] as IElementNode];
                if (typeTypeRef.IsValueType)
                {
                    instructions.Add(Instruction.Create(OpCodes.Dup));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, i));
                    instructions.Add(Instruction.Create(OpCodes.Ldelema, typeTypeRef));
                    instructions.Add(Instruction.Create(OpCodes.Ldloc, vardef));
                    if (vardef.VariableType == module.TypeSystem.Object)
                        instructions.Add(Instruction.Create(OpCodes.Unbox_Any, module.ImportReference(typeTypeRef)));
                    instructions.Add(Instruction.Create(OpCodes.Stobj, typeTypeRef));
                }
                else
                {
                    instructions.Add(Instruction.Create(OpCodes.Dup));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, i));
                    instructions.Add(Instruction.Create(OpCodes.Ldloc, vardef));
                    instructions.Add(Instruction.Create(OpCodes.Stelem_Ref));
                }
            }
            return instructions;
        }

        public EXamlCreateObject ProvideValue(IElementNode node, ModuleDefinition module, EXamlContext Context)
        {
            return new EXamlCreateArrayObject(Context, Type.MakeArrayType(), items);
        }

        public TypeReference Type
        {
            get;
            set;
        }

        public object Items
        {
            get
            {
                return null;
            }
            set
            {
                if (null == items)
                {
                    items = new List<object>();
                }

                items.Add(value);
            }
        }

        private List<object> items;
    }
}
 
