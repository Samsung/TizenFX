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
using Mono.Cecil;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    static class MethodReferenceExtensions
    {
        public static MethodReference ResolveGenericParameters(this MethodReference self, TypeReference declaringTypeRef,
            ModuleDefinition module)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (declaringTypeRef == null)
                throw new ArgumentNullException(nameof(declaringTypeRef));

            var reference = new MethodReference(self.Name, module.ImportReference(self.ReturnType))
            {
                DeclaringType = module.ImportReference(declaringTypeRef),
                HasThis = self.HasThis,
                ExplicitThis = self.ExplicitThis,
                CallingConvention = self.CallingConvention
            };

            foreach (var parameter in self.Parameters) {
                var p = parameter.ParameterType.IsGenericParameter ? parameter.ParameterType : module.ImportReference(parameter.ParameterType);
                reference.Parameters.Add(new ParameterDefinition(p));
            }

            foreach (var generic_parameter in self.GenericParameters)
                reference.GenericParameters.Add(new GenericParameter(generic_parameter.Name, reference));

            return reference;
        }

        public static void ImportTypes(this MethodReference self, ModuleDefinition module)
        {
            if (!self.HasParameters)
                return;

            for (var i = 0; i < self.Parameters.Count; i++)
                self.Parameters[i].ParameterType = module.ImportReference(self.Parameters[i].ParameterType);
        }

        public static MethodReference MakeGeneric(this MethodReference self, TypeReference declaringType, params TypeReference [] arguments)
        {
            var reference = new MethodReference(self.Name, self.ReturnType) {
                DeclaringType = declaringType,
                HasThis = self.HasThis,
                ExplicitThis = self.ExplicitThis,
                CallingConvention = self.CallingConvention,
            };

            foreach (var parameter in self.Parameters)
                reference.Parameters.Add(new ParameterDefinition(parameter.ParameterType));

            foreach (var generic_parameter in self.GenericParameters)
                reference.GenericParameters.Add(new GenericParameter(generic_parameter.Name, reference));

            return reference;
        }
    }
}
 
