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
    //use $$
    internal class EXamlSetDynamicResource : EXamlOperation
    {
        internal override string Write()
        {
            if (@object.IsValid)
            {
                string ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.SetDynamicResource),
                         eXamlContext.GetValueString(@object.Index),
                         eXamlContext.GetValueString(eXamlContext.definedBindableProperties.IndexOf(bindableProperty.Resolve())),
                         eXamlContext.GetValueString(key));
                return ret;
            }
            else
            {
                return "";
            }
        }

        public EXamlSetDynamicResource(EXamlContext context, EXamlCreateObject @object, MemberReference bindalbeProperty, string key)
            : base(context)
        {
            this.@object = @object;
            this.bindableProperty = bindalbeProperty;
            this.key = key;
            eXamlContext.eXamlOperations.Add(this);

            @object.AddBindableProperty(bindableProperty);
        }

        private EXamlCreateObject @object;
        private MemberReference bindableProperty;
        private string key;
    }
}
