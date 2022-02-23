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
using System.Text;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use ``
    internal class EXamlGetObjectByProperty : EXamlOperation
    {
        internal override string Write()
        {
            if (instance.IsValid)
            {
                string ret = String.Format("({0} ({1} {2}))\n",
                         eXamlContext.GetValueString((int)EXamlOperationType.GetObjectByProperty),
                         eXamlContext.GetValueString(instance.Index),
                         eXamlContext.GetValueString(propertyName));

                return ret;
            }
            else
            {
                return "";
            }
        }

        internal EXamlGetObjectByProperty(EXamlContext context, EXamlCreateObject instance, string propertyName)
            : base(context)
        {
            this.instance = instance;
            this.propertyName = propertyName;
            eXamlContext.objectsAccordingToProperty.Add(this);

            eXamlContext.eXamlOperations.Add(this);
        }

        private EXamlCreateObject instance;
        private string propertyName;
    }
}
