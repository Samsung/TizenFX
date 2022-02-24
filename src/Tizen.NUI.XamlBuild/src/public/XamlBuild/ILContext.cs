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
using System;
using System.Collections.Generic;

using Mono.Cecil;
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class ILContext
    {
        public ILContext(ILProcessor il, MethodBody body, List<Instruction> insOfAddEvent, ModuleDefinition module, FieldDefinition parentContextValues = null)
        {
            IL = il;
            Body = body;
            InsOfAddEvent = insOfAddEvent;
            Values = new Dictionary<INode, object>();
            Variables = new Dictionary<IElementNode, VariableDefinition>();
            Scopes = new Dictionary<INode, Tuple<VariableDefinition, IList<string>>>();
            TypeExtensions = new Dictionary<INode, TypeReference>();
            ParentContextValues = parentContextValues;
            Module = module;
        }

        public Dictionary<INode, object> Values { get; private set; }

        public Dictionary<IElementNode, VariableDefinition> Variables { get; private set; }

        public Dictionary<INode, Tuple<VariableDefinition, IList<string>>> Scopes { get; private set; }

        public Dictionary<INode, TypeReference> TypeExtensions { get; }

        public FieldDefinition ParentContextValues { get; private set; }

        public object Root { get; set; } //FieldDefinition or VariableDefinition

        public ILProcessor IL { get; private set; }

        public MethodBody Body { get; private set; }

        public List<Instruction> InsOfAddEvent { get; private set; }

        public ModuleDefinition Module { get; private set; }
    }
}
 
