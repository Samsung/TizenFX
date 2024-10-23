// /*
//  * Copyright(c) 2024 Samsung Electronics Co., Ltd.
//  *
//  * Licensed under the Apache License, Version 2.0 (the "License");
//  * you may not use this file except in compliance with the License.
//  * You may obtain a copy of the License at
//  *
//  * http://www.apache.org/licenses/LICENSE-2.0
//  *
//  * Unless required by applicable law or agreed to in writing, software
//  * distributed under the License is distributed on an "AS IS" BASIS,
//  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  * See the License for the specific language governing permissions and
//  * limitations under the License.
//  *
//  */

// using System;
// using System.Collections.Generic;

// namespace Tizen.NUI.PenWave
// {
//     public static class EventBus
//     {
//         private static readonly Dictionary<string, Action<object>> events = new();

//         public static void Subscribe(string eventName, Action<object> callback)
//         {
//             if (events.ContainsKey(eventName))
//                 events[eventName] += callback;
//             else
//                 events[eventName] = callback;
//         }

//         public static void Publish(string eventName, object eventArgs = null)
//         {
//             if (events.TryGetValue(eventName, out var action))
//                 action.Invoke(eventArgs);
//         }
//     }
// }
