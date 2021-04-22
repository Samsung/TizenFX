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

namespace Tizen.NUI.EXaml
{
    internal class AddEvent : Operation
    {
        public AddEvent(GlobalDataList globalDataList, int instanceIndex, int elementIndex, int eventIndex, int valueIndex)
        {
            this.instanceIndex = instanceIndex;
            this.elementIndex = elementIndex;
            this.eventIndex = eventIndex;
            this.valueIndex = valueIndex;
            this.globalDataList = globalDataList;
        }

        private GlobalDataList globalDataList;

        public void Do()
        {
            object instance = globalDataList.GatheredInstances[instanceIndex];
            object element = globalDataList.GatheredInstances[elementIndex];
            var eventInfo = globalDataList.GatheredEvents[eventIndex];
            try
            {
                var methodInfo = globalDataList.GatheredMethods[valueIndex];
                eventInfo.AddEventHandler(instance, methodInfo.CreateDelegate(eventInfo.EventHandlerType, element));
            }
            catch (ArgumentException ae)
            {
                Tizen.Log.Fatal("EXaml", ae.ToString());
            }
        }

        private int instanceIndex;
        private int elementIndex;
        private int eventIndex;
        private int valueIndex;
    }
}
