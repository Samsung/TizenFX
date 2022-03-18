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
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MethodAttributes = Mono.Cecil.MethodAttributes;
using MethodImplAttributes = Mono.Cecil.MethodImplAttributes;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    static class TypeDefinitionExtensions
    {
        public static MethodDefinition AddDefaultConstructor(this TypeDefinition targetType)
        {
            var module = targetType.Module;
            var parentType = module.ImportReference(("mscorlib", "System", "Object"));

            return AddDefaultConstructor(targetType, parentType);
        }

        public static MethodDefinition AddDefaultConstructor(this TypeDefinition targetType, TypeReference parentType)
        {
            var module = targetType.Module;
            var voidType = module.ImportReference(("mscorlib", "System", "Void"));
            var methodAttributes = MethodAttributes.Public |
                                   MethodAttributes.HideBySig |
                                   MethodAttributes.SpecialName |
                                   MethodAttributes.RTSpecialName;

            var parentctor = module.ImportCtorReference(parentType, paramCount: 0) ?? module.ImportCtorReference(("mscorlib", "System", "Object"), parameterTypes: null);

            var ctor = new MethodDefinition(".ctor", methodAttributes, voidType)
            {
                CallingConvention = MethodCallingConvention.Default,
                ImplAttributes = (MethodImplAttributes.IL | MethodImplAttributes.Managed)
            };
            ctor.Body.InitLocals = true;

            var IL = ctor.Body.GetILProcessor();

            IL.Emit(OpCodes.Ldarg_0);
            IL.Emit(OpCodes.Call, parentctor);
            IL.Emit(OpCodes.Ret);

            targetType.Methods.Add(ctor);
            return ctor;
        }

        public static IEnumerable<MethodDefinition> AllMethods(this TypeDefinition self)
        {
            while (self != null)
            {
                foreach (var md in self.Methods)
                    yield return md;
                self = self.BaseType == null ? null : self.BaseType.ResolveCached();
            }
        }

        public static FieldDefinition GetOrCreateField(this TypeDefinition self, string name, Mono.Cecil.FieldAttributes attributes, TypeReference fieldType)
        {
            var field = self.Fields.FirstOrDefault(a => a.Name == name);

            if (null == field)
            {
                field = new FieldDefinition(name, attributes, fieldType);
                self.Fields.Add(field);
            }

            return field;
        }

        public static MethodDefinition GetOrCreateMethod(this TypeDefinition self, string name, MethodAttributes attributes, Type type)
        {
            MethodDefinition method = self.Methods.FirstOrDefault(a => a.Name == name);
            if (null == method)
            {
                method = new MethodDefinition(name, MethodAttributes.Public, self.Module.ImportReference(type));
                self.Methods.Add(method);
            }

            return method;
        }
    }
}
 
