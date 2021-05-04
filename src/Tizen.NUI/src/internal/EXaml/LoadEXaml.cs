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
using System.ComponentModel;

namespace Tizen.NUI.EXaml
{
    internal static class LoadEXaml
    {
        internal static void Load(object view, string xaml)
        {
            var globalDataList = new GlobalDataList();

            CreateInstanceAction.Root = view;

            int index = 0;

            var createInstance = new CreateInstanceAction(globalDataList, null);
            var getObjectByProperty = new GetObjectByPropertyAction(globalDataList, null);
            var addExistInstance = new AddExistInstanceAction(globalDataList, null);
            var registerXName = new RegisterXNameAction(globalDataList, null);
            var setProperty = new SetPropertyAction(globalDataList, null);
            var addToCollectionProperty = new AddToCollectionPropertyAction(globalDataList, null);
            var addEvent = new AddEventAction(globalDataList, null);
            var setBindalbeProperty = new SetBindalbePropertyAction(globalDataList, null);
            var addObject = new CallAddMethodAction(globalDataList, null);
            var setDynamicResourceAction = new SetDynamicResourceAction(globalDataList, null);
            var addToResourceDictionaryAction = new AddToResourceDictionaryAction(globalDataList, null);
            var setBindingAction = new SetBindingAction(globalDataList, null);

            foreach (char c in xaml)
            {
                if (null == currentOp)
                {
                    switch (c)
                    {
                        case '<':
                            if (0 == index)
                            {
                                currentOp = new GatherAssembliesBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            else if (1 == index)
                            {
                                currentOp = new GatherTypesBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            else if (2 == index)
                            {
                                currentOp = new GatherPropertiesBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            else if (3 == index)
                            {
                                currentOp = new GatherEventsBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            else if (4 == index)
                            {
                                currentOp = new GatherMethodsBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            else if (5 == index)
                            {
                                currentOp = new GatherBindablePropertiesBlock(globalDataList, null);
                                currentOp.Init();
                                index++;
                            }
                            break;

                        case '{':
                            currentOp = createInstance;
                            currentOp.Init();
                            break;

                        case '`':
                            currentOp = getObjectByProperty;
                            currentOp.Init();
                            break;

                        case '@':
                            currentOp = addExistInstance;
                            currentOp.Init();
                            break;

                        case '&':
                            currentOp = registerXName;
                            currentOp.Init();
                            break;

                        case '[':
                            currentOp = setProperty;
                            currentOp.Init();
                            break;

                        case '~':
                            currentOp = addToCollectionProperty;
                            currentOp.Init();
                            break;

                        case '#':
                            currentOp = addEvent;
                            currentOp.Init();
                            break;

                        case '!':
                            currentOp = setBindalbeProperty;
                            currentOp.Init();
                            break;

                        case '$':
                            currentOp = setDynamicResourceAction;
                            currentOp.Init();
                            break;

                        case '^':
                            currentOp = addObject;
                            currentOp.Init();
                            break;

                        case '*':
                            currentOp = addToResourceDictionaryAction;
                            currentOp.Init();
                            break;

                        case '%':
                            currentOp = setBindingAction;
                            currentOp.Init();
                            break;
                    }
                }
                else
                {
                    currentOp = currentOp.DealChar(c);
                }
            }

            foreach (var op in globalDataList.Operations)
            {
                op.Do();
            }
        }

        private static Action currentOp = null;
    }
}
