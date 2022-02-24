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
using System.IO;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use ^^
    internal class EXamlAddObject : EXamlOperation
    {
        internal override string Write()
        {
            if (false == Parent.IsValid || false == (Child as EXamlCreateObject)?.IsValid)
            {
                return "";
            }

            string ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.AddObject),
                         eXamlContext.GetValueString(Parent.Index),
                         eXamlContext.GetValueString(Child),
                         eXamlContext.GetValueString(eXamlContext.definedMethods.GetIndex(Method.DeclaringType, Method)));
            return ret;
        }

        public EXamlAddObject(EXamlContext context, EXamlCreateObject parent, object child, MethodDefinition addMethod)
            : base(context)
        {
            Parent = parent;
            Child = child;
            Method = addMethod;

            eXamlContext.eXamlOperations.Add(this);
            eXamlContext.eXamlAddObjectList.Add(this);
        }

        public EXamlCreateObject Parent
        {
            get;
        }

        public object Child
        {
            get;
        }

        public MethodDefinition Method
        {
            get;
        }
    }
}
 
