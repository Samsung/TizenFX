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

            Action currentAction = new RootAction(globalDataList);

            foreach (char c in xaml)
            {
                currentAction = currentAction.DealChar(c);
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
