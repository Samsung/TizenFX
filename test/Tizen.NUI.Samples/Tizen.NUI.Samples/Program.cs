/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Samples
{
    public class Application
    {
       /* public delegate string SWIGStringDelegate(string message);

        [global::System.Runtime.InteropServices.DllImport("libcapi-appfw-app-common.so.0", EntryPoint = "RegisterCreateStringCallback")]
        public static extern void RegisterCreateStringCallback(SWIGStringDelegate stringDelegate);*/

        [STAThread]
        static void Main(string[] args)
        {
            /*RegisterCreateStringCallback(new SWIGStringDelegate((string message) =>
            {
                return message;
            }));*/

            new DaliDemo(CommonResource.GetDaliResourcePath() + @"../../style/demo-theme.json").Run(args);
        }
    }
}

