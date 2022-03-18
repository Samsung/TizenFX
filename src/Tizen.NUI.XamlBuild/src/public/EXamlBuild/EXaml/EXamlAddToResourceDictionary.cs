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
using System.IO;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use %%
    internal class EXamlAddToResourceDictionary : EXamlOperation
    {
        internal override string Write()
        {
            if (instance.IsValid)
            {
                string ret = "";
                if (null != key)
                {
                    ret = String.Format("({0} ({1} {2} {3}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.AddToResourceDictionary),
                         eXamlContext.GetValueString(instance.Index),
                         eXamlContext.GetValueString(key),
                         eXamlContext.GetValueString(value));
                }

                return ret;
            }
            else
            {
                return "";
            }
        }

        public EXamlAddToResourceDictionary(EXamlContext context, EXamlCreateObject @object, string key, object value)
            : base(context)
        {
            instance = @object;
            this.key = key;
            this.value = value;
            eXamlContext.eXamlOperations.Add(this);

            eXamlContext.resourceDictionary.Add(key, value);
        }

        public EXamlAddToResourceDictionary(EXamlContext context, EXamlCreateObject @object, EXamlCreateObject value)
            : base(context)
        {
            eXamlContext.eXamlOperations.Add(this);
        }

        private EXamlCreateObject instance;
        private string key;
        private object value;
    }
}
 
