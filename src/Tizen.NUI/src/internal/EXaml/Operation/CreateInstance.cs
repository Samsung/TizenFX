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
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal class CreateInstance : Operation
    {
        public CreateInstance(GlobalDataList globalDataList, int typeIndex, int xFactoryMethodIndex, List<object> paramList = null)
        {
            this.typeIndex = typeIndex;
            this.paramList = paramList;
            this.globalDataList = globalDataList;
            this.xFactoryMethodIndex = xFactoryMethodIndex;
        }

        private GlobalDataList globalDataList;
        private int xFactoryMethodIndex;

        public void Do()
        {
            object obj = null;

            if (0 == globalDataList.GatheredInstances.Count && null != globalDataList.Root)
            {
                obj = globalDataList.Root;
            }
            else
            {
                var type = globalDataList.GatheredTypes[typeIndex];

                var xFactoryMethod = (0 <= xFactoryMethodIndex) ? globalDataList.GatheredMethods[xFactoryMethodIndex] : null;

                if (null == paramList)
                {
                    if (null == xFactoryMethod)
                    {
                        obj = Activator.CreateInstance(type);
                    }
                    else
                    {
                        obj = xFactoryMethod.Invoke(null, Array.Empty<object>());
                    }
                }
                else
                {
                    for (int i = 0; i < paramList.Count; i++)
                    {
                        if (paramList[i] is Instance instance)
                        {
                            paramList[i] = globalDataList.GatheredInstances[instance.Index];
                        }

                        if (paramList[i] is IMarkupExtension markupExtension)
                        {
                            paramList[i] = markupExtension.ProvideValue(null);
                        }
                    }

                    if (null == xFactoryMethod)
                    {
                        obj = Activator.CreateInstance(type, paramList.ToArray());
                    }
                    else
                    {
                        obj = xFactoryMethod.Invoke(null, paramList.ToArray());
                    }
                }
            }

            if (null != obj)
            {
                globalDataList.GatheredInstances.Add(obj);

                if (globalDataList.Root == null)
                {
                    globalDataList.Root = obj;
                }

                if (obj is BindableObject bindableObject)
                {
                    bindableObject.IsCreateByXaml = true;

                    if (1 == globalDataList.GatheredInstances.Count)
                    {
                        NameScope nameScope = new NameScope();
                        NameScope.SetNameScope(bindableObject, nameScope);
                    }
                }
            }
            else
            {
                throw new Exception($"Can't create instance typeIndex:{typeIndex}");
            }
        }

        private int typeIndex;

        private List<object> paramList;
    }
}
