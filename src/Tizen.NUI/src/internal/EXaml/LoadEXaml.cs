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
        internal static GlobalDataList GatherDataList(string xaml)
        {
            var globalDataList = new GlobalDataList();

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
            var otherActions = new OtherActions(globalDataList, null);

            Action currentOp = null;

            Action[] blockActions = new Action[]
                {
                    new GatherAssembliesBlock(globalDataList, null),
                    new GatherTypesBlock(globalDataList, null),
                    new GatherPropertiesBlock(globalDataList, null),
                    new GatherEventsBlock(globalDataList, null),
                    new GatherMethodsBlock(globalDataList, null),
                    new GatherBindablePropertiesBlock(globalDataList, null),
                    new GatherLongStringsBlock(globalDataList, null)
                };

            foreach (char c in xaml)
            {
                if (null == currentOp)
                {
                    switch (c)
                    {
                        case '<':
                            currentOp = blockActions[index++];
                            currentOp.Init();
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

                        case 'a':
                            currentOp = otherActions;
                            currentOp.Init();
                            break;
                    }
                }
                else
                {
                    currentOp = currentOp.DealChar(c);
                }
            }

            foreach (var op in globalDataList.PreLoadOperations)
            {
                op.Do();
            }

            return globalDataList;
        }

        internal static void Load(object view, string xaml, out GlobalDataList xamlData)
        {
            var globalDataList = GatherDataList(xaml);

            globalDataList.Root = view;

            foreach (var op in globalDataList.Operations)
            {
                op.Do();
            }

            xamlData = globalDataList;
        }

        internal static void Load(object view, object preloadData)
        {
            var globalDataList = preloadData as GlobalDataList;

            if (null == globalDataList)
            {
                return;
            }

            globalDataList.Root = view;

            foreach (var op in globalDataList.Operations)
            {
                op.Do();
            }
        }

        internal static void RemoveEventsInXaml(object eXamlData)
        {
            if (eXamlData is GlobalDataList globalDataList)
            {
                foreach (var op in globalDataList.RemoveEventOperations)
                {
                    op.Do();
                }
            }
        }
    }
}
