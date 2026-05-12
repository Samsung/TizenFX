/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.Threading;

namespace Tizen.NUI
{
    internal static class NUIApplicationInitializer
    {
        internal static bool IsStaticInitialized {get; set;}
        internal static bool IsInitialized {get; set;}

        /// <summary>
        /// Initialize call at very early time of project. (Should only called once)
        /// </summary>
        public static void StaticInitialize()
        {
            Tizen.Log.Info("NUI", $"[NUI] IsStaticInitialized : {IsStaticInitialized}\n");
            if (!IsStaticInitialized)
            {
                Tizen.Log.Info("NUI", "[NUI] NUIApplicationInitializer: StaticInitialize");
                Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
                PropertyBridge.RegisterStringGetter();

                IsStaticInitialized = true;
                Tizen.Log.Info("NUI", "[NUI] NUIApplicationInitializer: StaticInitialize done");
            }
        }

        /// <summary>
        /// Initialize call at Application::OnInitialize(), or Preload() when SupportPreInitializedCreation == true.
        /// </summary>
        public static void Initialize()
        {
            Tizen.Log.Info("NUI", $"[NUI] Preload : {NUIApplication.IsPreload} Support preload time view creation : {NUIApplication.SupportPreInitializedCreation} IsStaticInitialized : {IsStaticInitialized} IsInitialized : {IsInitialized}\n");

            if (!IsInitialized)
            {
                Tizen.Log.Info("NUI", "[NUI] NUIApplicationInitializer: ProcessorController Initialize");
                Tizen.Tracer.Begin("[NUI] NUIApplicationInitializer: ProcessorController Initialize");
                ProcessorController.Instance.Initialize();
                Tizen.Tracer.End();

                // Initialize DisposeQueue Singleton class. This is also required to create DisposeQueue on main thread.
                Tizen.Log.Info("NUI", "[NUI] NUIApplicationInitializer: DisposeQueue Initialize");
                Tizen.Tracer.Begin("[NUI] NUIApplicationInitializer: DisposeQueue Initialize");
                DisposeQueue.Instance.Initialize();
                Tizen.Tracer.End();

                IsInitialized = true;
            }
        }
    }
}
