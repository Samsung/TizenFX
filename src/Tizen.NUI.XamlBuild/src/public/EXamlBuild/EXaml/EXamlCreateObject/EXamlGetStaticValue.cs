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
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    //use {}
    internal class EXamlGetStaticValue : EXamlCreateObject
    {
        private MemberReference memberOfStaticInstance;

        internal TypeReference DeclareType
        {
            get;
        }

        internal override string Write()
        {
            if (false == IsValid)
            {
                return "";
            }

            string ret = "";

            int typeIndex = eXamlContext.GetTypeIndex(DeclareType);

            if (memberOfStaticInstance is FieldReference field)
            {
                ret += String.Format("({0} ({1} {2} {3}))\n",
                                  eXamlContext.GetValueString((int)EXamlOperationType.GetStaticObject),
                                  eXamlContext.GetValueString(typeIndex),
                                  eXamlContext.GetValueString(null),
                                  eXamlContext.GetValueString(field.Name));
            }
            else if (memberOfStaticInstance is PropertyReference property)
            {
                ret += String.Format("({0} ({1} {2} {3}))\n",
                                  eXamlContext.GetValueString((int)EXamlOperationType.GetStaticObject),
                                  eXamlContext.GetValueString(typeIndex),
                                  eXamlContext.GetValueString(property.Name),
                                  eXamlContext.GetValueString(null));
            }

            return ret;
        }

        internal new TypeReference GetType()
        {
            if (memberOfStaticInstance is FieldReference field)
            {
                return field.FieldType;
            }
            else if (memberOfStaticInstance is PropertyReference property)
            {
                return property.PropertyType;
            }
            else
            {
                throw new Exception($"Invalid static instance, type is {Type.FullName}");
            }
        }

        public EXamlGetStaticValue(EXamlContext context, TypeReference type, FieldReference field, PropertyReference property)
            : base(context, GetValueType(field, property))
        {
            MemberReference memberRef = null;
            DeclareType = type;

            if (null != field)
            {
                memberRef = field;
            }
            else if (null != property)
            {
                memberRef = property;
            }

            memberOfStaticInstance = memberRef;

            eXamlContext.eXamlOperations.Add(this);

            Index = eXamlContext.eXamlCreateObjects.Count;
            eXamlContext.eXamlCreateObjects.Add(this);
        }

        private static TypeReference GetValueType(FieldReference field, PropertyReference property)
        {
            if (null != field)
            {
                return field.FieldType;
            }
            else if (null != property)
            {
                return property.PropertyType;
            }
            else
            {
                throw new XamlParseException("Field and property are both null", null);
            }
        }
    }
}
 
