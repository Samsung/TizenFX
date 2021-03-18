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

// using ElmSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;
// using TAppControl = Tizen.Applications.AppControl;

namespace Tizen.NUI.Binding
{
    internal class TizenPlatformServices : IPlatformServices
    {
        static SHA256 checksum = SHA256.Create();

        static SynchronizationContext s_context;

        public TizenPlatformServices()
        {
            s_context = SynchronizationContext.Current;
        }

        #region IPlatformServices implementation
        public void BeginInvokeOnMainThread(Action action)
        {
            s_context.Post((o) => action(), null);
        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            Console.WriteLine("TizenPlatformServices StartTimer ...");
            System.Threading.Timer timer = null;
            bool invoking = false;
            TimerCallback onTimeout = o =>
            {
                if (!invoking)
                {
                    invoking = true;
                    BeginInvokeOnMainThread(() =>
                        {
                            if (!callback())
                            {
                                timer.Dispose();
                            }
                            invoking = false;
                        }
                    );
                }
            };
            timer = new System.Threading.Timer(onTimeout, null, Timeout.Infinite, Timeout.Infinite);
            // set interval separately to prevent calling onTimeout before `timer' is assigned
            timer.Change(interval, interval);
        }

        public async Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(uri, cancellationToken).ConfigureAwait(false))
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        public Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        // public IIsolatedStorageFile GetUserStoreForApplication()
        // {
        // 	return new TizenIsolatedStorageFile();
        // }

        static readonly char[] HexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        public string GetMD5Hash(string input)
        {
            byte[] bin = checksum.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            char[] hex = new char[32];
            for (var i = 0; i < 16; ++i)
            {
                hex[2 * i] = HexDigits[bin[i] >> 4];
                hex[2 * i + 1] = HexDigits[bin[i] & 0xf];
            }
            return new string(hex);
        }

        public void QuitApplication()
        {
            // Forms.Context.Exit();
            Console.WriteLine("!!!!!!!!!!!! Exit !!!!!!!!!!!!!!");
        }

        public bool IsInvokeRequired
        {
            get
            {
                // return !EcoreMainloop.IsMainThread;
                return true;
            }
        }

        public string RuntimePlatform => Device.Tizen;

        #endregion

        // In .NETCore, AppDomain is not supported. The list of the assemblies should be generated manually.
        internal class AppDomain
        {
            public static AppDomain CurrentDomain { get; private set; }

            List<Assembly> assemblies;

            public static bool IsTizenSpecificAvailable { get; private set; }

            static AppDomain()
            {
                CurrentDomain = new AppDomain();
            }

            AppDomain()
            {
                assemblies = new List<Assembly>();

                // Add this renderer assembly to the list
                assemblies.Add(GetType().GetTypeInfo().Assembly);
            }

            internal void RegisterAssemblyRecursively(Assembly asm)
            {
                if (assemblies.Contains(asm))
                    return;

                assemblies.Add(asm);

                foreach (var refName in asm.GetReferencedAssemblies())
                {
                    if (!refName.Name.StartsWith("System.") && !refName.Name.StartsWith("Microsoft.") && !refName.Name.StartsWith("mscorlib"))
                    {
                        try
                        {
                            Assembly refAsm = Assembly.Load(refName);
                            if (refAsm != null)
                            {
                                RegisterAssemblyRecursively(refAsm);
                                if (refName.Name == "Tizen.NUI.Xaml.Core")
                                {
                                    if (refAsm.GetType("Tizen.NUI.Xaml.PlatformConfiguration.TizenSpecific.VisualElement") != null)
                                    {
                                        IsTizenSpecificAvailable = true;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Log.Warn("Reference Assembly can not be loaded. {0}", refName.FullName);
                        }
                    }
                }
            }

            public Assembly[] GetAssemblies()
            {
                return assemblies.ToArray();
            }
        }
    }
}

