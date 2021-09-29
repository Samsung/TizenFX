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
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class RootAction : Action
    {
        delegate void CreateOperation(GlobalDataList globalDataList, List<object> operationInfo);

        public RootAction(GlobalDataList globalDataList)
        {
            this.globalDataList = globalDataList;

            childAction = new GetValueListAction(')', this);
            childAction.Init();
        }

        public Action DealChar(char c)
        {
            if ('(' == c)
            {
                childAction.Init();
                return childAction;
            }
            else if ('\n' == c)
            {
                return this;
            }
            else
            {
                throw new Exception($"RootAction must not deal the char {c}");
            }
        }

        public void Init()
        {
            childAction.Init();
        }

        public void OnActive()
        {
            int opIndex = (int)childAction.ValueList[0];
            Operations[opIndex].Invoke(globalDataList, childAction.ValueList[1] as List<object>);

            childAction.Init();
        }

        private GlobalDataList globalDataList;
        private GetValueListAction childAction;

        private static CreateOperation[] operations;

        private static CreateOperation[] Operations
        {
            get
            {
                if (null == operations)
                {
                    InitOperationFactory(out operations);
                }

                return operations;
            }
        }

        private static void InitOperationFactory(out CreateOperation[] createOperations)
        {
            createOperations = new CreateOperation[(int)EXamlOperationType.MAX];

            createOperations[(int)EXamlOperationType.GatherAssembly] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherAssembly(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GatherType] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherType(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GatherProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherProperty(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GatherEvent] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherEvent(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GatherMethod] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherMethod(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GatherBindableProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GatherBindableProperties(globalDataList, opInfo);
                globalDataList.PreLoadOperations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.CreateObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new CreateObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.CreateDPObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new CreateDPObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.CreateArrayObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new CreateArrayObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.CreateDataTemplate] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new CreateDataTemplate(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetStaticObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GetStaticObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetTypeObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GetTypeObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetObjectConvertedFromString] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GetObjectConvertedFromString(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetEnumObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GetEnumObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetObjectByProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new GetObjectByProperty(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.SetProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new SetProperty(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.SetBindableProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new SetBindableProperty(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.SetBinding] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new SetBinding(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.SetDynamicResource] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new SetDynamicResource(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.AddEvent] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new AddEvent(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.AddObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new AddObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.AddToCollectionObject] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new AddToCollectionObject(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.AddToCollectionProperty] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new AddToCollectionProperty(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.AddToResourceDictionary] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new AddToResourceDictionary(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.RegisterXName] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                var operation = new RegisterXName(globalDataList, opInfo);
                globalDataList.Operations.Add(operation);
            };

            createOperations[(int)EXamlOperationType.GetLongString] = (GlobalDataList globalDataList, List<object> opInfo) =>
            {
                globalDataList.LongStrings = opInfo[0] as string;
            };
        }
    }
}
