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
    //use **
    internal class EXamlSetBinding : EXamlOperation
    {
        internal override string Write()
        {
            if (Instance.IsValid)
            {
                string ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.SetBinding),
                         eXamlContext.GetValueString(Instance.Index),
                         eXamlContext.GetValueString(eXamlContext.definedBindableProperties.IndexOf(BindableProperty.Resolve())),
                         eXamlContext.GetValueString(Value.Index));

                return ret;
            }
            else
            {
                return "";
            }
        }

        public EXamlSetBinding(EXamlContext context, EXamlCreateObject @object, MemberReference bindableProperty, object binding)
            : base(context)
        {
            Instance = @object;
            BindableProperty = bindableProperty;
            Value = binding as EXamlCreateObject;
            if (null == Value)
            {
                throw new Exception($"Can't set binding {binding.ToString()} to {bindableProperty.FullName}");
            }
            eXamlContext.eXamlOperations.Add(this);

            Instance.AddBindableProperty(bindableProperty);
        }

        public EXamlCreateObject Instance
        {
            get;
        }

        public MemberReference BindableProperty
        {
            get;
        }

        public EXamlCreateObject Value
        {
            get;
        }
    }
}
