﻿/*
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
    internal class RemoveEvent : Operation
    {
        public RemoveEvent(Delegate eventDelegate, object instance, EventInfo eventInfo)
        {
            this.instance = instance;
            this.eventInfo = eventInfo;
            this.eventDelegate = eventDelegate;
        }

        public void Do()
        {
            try
            {
                eventInfo.RemoveEventHandler(instance, eventDelegate);
            }
            catch (ArgumentException ae)
            {
                Tizen.Log.Fatal("EXaml", ae.ToString());
            }
        }

        private object instance;
        private EventInfo eventInfo;
        private Delegate eventDelegate;
    }
}
