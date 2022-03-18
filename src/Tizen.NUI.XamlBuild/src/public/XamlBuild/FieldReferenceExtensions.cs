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

namespace Tizen.NUI.Xaml.Build.Tasks
{
    static class FieldReferenceExtensions
    {
        public static FieldReference ResolveGenericParameters(this FieldReference self, TypeReference declaringTypeRef)
        {
            var fieldType = self.FieldType;
            if (fieldType.IsGenericParameter)
            {
                var genericParameter = (GenericParameter)fieldType;
                fieldType = ((GenericInstanceType)declaringTypeRef).GenericArguments[genericParameter.Position];
            }
            var fieldReference = new FieldReference(self.Name, fieldType)
            {
                DeclaringType = declaringTypeRef
            };
            return fieldReference;
        }
    }
}
 
