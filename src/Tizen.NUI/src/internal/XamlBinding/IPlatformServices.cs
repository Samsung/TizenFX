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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IPlatformServices
    {
        bool IsInvokeRequired { get; }

        void BeginInvokeOnMainThread(Action action);

        Assembly[] GetAssemblies();

        string GetMD5Hash(string input);

        // double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes);

        Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken);

        // IIsolatedStorageFile GetUserStoreForApplication();

        // void OpenUriAction(Uri uri);

        void StartTimer(TimeSpan interval, Func<bool> callback);

        string RuntimePlatform { get; }

        void QuitApplication();
    }
}
