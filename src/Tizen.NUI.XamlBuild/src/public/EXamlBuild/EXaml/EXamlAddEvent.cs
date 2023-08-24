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
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use ##
    internal class EXamlAddEvent : EXamlOperation
    {
        internal override string Write()
        {
            if (false == Instance.IsValid)
            {
                return "";
            }

            string ret = "";

            ret += String.Format("({0} ({1} {2} {3} {4}))\n",
                                eXamlContext.GetValueString((int)EXamlOperationType.AddEvent),
                                eXamlContext.GetValueString(Instance.Index),
                                eXamlContext.GetValueString(Element.Index),
                                eXamlContext.GetValueString(eXamlContext.definedEvents.GetIndex(eventDef.DeclaringType, eventDef)),
                                eXamlContext.GetValueString(eXamlContext.definedMethods.GetIndex(Value.DeclaringType, Value)));

            return ret;
        }

        public EXamlAddEvent(EXamlContext context, EXamlCreateObject instance, EXamlCreateObject element, string eventName, MethodDefinition value)
            : base(context)
        {
            TypeReference typeref;
            var eventDef = instance.Type.GetEvent(fi=>fi.Name==eventName, out typeref);
            if (null != eventDef)
            {
                Instance = instance;
                Element = element;
                Value = value;
                DeclaringType = typeref;

                this.eventDef = eventDef;

                Instance.AddEvent(DeclaringType, eventDef);

                eXamlContext.eXamlOperations.Add(this);
                eXamlContext.eXamlAddEventList.Add(this);
            }
            else
            {
                throw new Exception("Property is not element");
            }
        }

        internal EXamlCreateObject Instance
        {
            get;
        }

        internal EXamlCreateObject Element
        {
            get;
        }

        internal TypeReference DeclaringType
        {
            get;
        }

        internal MethodDefinition Value
        {
            get;
        }

        private EventDefinition eventDef;
    }
}
 
