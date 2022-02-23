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
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.EXaml
{
    //use []
    internal class EXamlSetProperty : EXamlOperation
    {
        internal override string Write()
        {
            if (false == instance.IsValid)
            {
                return "";
            }

            string ret = String.Format("({0} ({1} {2} {3}))\n",
                            eXamlContext.GetValueString((int)EXamlOperationType.SetProperty),
                            eXamlContext.GetValueString(instance.Index),
                            eXamlContext.GetValueString(eXamlContext.definedProperties.GetIndex(property.DeclaringType, property)),
                            eXamlContext.GetValueString(value));

            return ret;
        }

        public EXamlSetProperty(EXamlContext context, EXamlCreateObject instance, string propertyName, object value)
            : base(context)
        {
            var property = instance.Type.GetProperty(fi=>fi.Name==propertyName, out declareTypeRef);
            if (null != property)
            {
                this.instance = instance;
                this.property = property;
                this.value = value;

                if (null != this.instance.Instance)
                {
                    var propertyInfo = this.instance.Instance.GetType().GetProperty(property.Name);

                    if (value is EXamlCreateObject eXamlCreateObject && null != eXamlCreateObject.Instance)
                    {
                        if (this.instance.Instance is BindingExtension bindingExtension
                            &&
                            eXamlCreateObject.Type.FullName == typeof(BindingMode).FullName)
                        {
                            bindingExtension.ModeInEXaml = eXamlCreateObject;
                        }
                        else if (eXamlCreateObject.Type.ResolveCached().IsEnum)
                        {
                            if (eXamlCreateObject.Type.FullName == typeof(BindingMode).FullName)
                            {
                                var realValue = Enum.Parse(typeof(BindingMode), eXamlCreateObject.Instance as string);
                                propertyInfo.SetMethod.Invoke(this.instance.Instance, new object[] { realValue });
                            }
                        }
                        else
                        {
                            if (instance.GetType().FullName == typeof(Xaml.Build.Tasks.ArrayExtension).FullName
                                &&
                                "Type" == propertyName)
                            {
                                eXamlCreateObject.IsValid = false;
                            }

                            propertyInfo.SetMethod.Invoke(this.instance.Instance, new object[] { eXamlCreateObject.Instance });
                        }
                    }
                    else
                    {
                        propertyInfo.SetMethod.Invoke(this.instance.Instance, new object[] { value });
                    }
                }

                this.instance.AddProperty(declareTypeRef, property);

                eXamlContext.eXamlOperations.Add(this);
            }
            else
            {
                throw new Exception("Property is not element");
            }
        }

        private EXamlCreateObject instance;
        private TypeReference declareTypeRef;
        private PropertyDefinition property;
        private object value;
    }
}
