/*
* Copyright (c) 2016 - 2017 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;

namespace Tizen.System
{
    internal class RuntimeInfoEventHandler
    {
        private RuntimeInfoKey Key;
        private event EventHandler<RuntimeFeatureStatusChangedEventArgs> Handler;

        internal RuntimeInfoEventHandler(RuntimeInfoKey key)
        {
            Key = key;
            Handler = null;
        }

        private static Interop.RuntimeInfo.RuntimeInformationChangedCallback __callback;

        internal event EventHandler<RuntimeFeatureStatusChangedEventArgs> EventHandler
        {
            add
            {
                if (Handler == null)
                {
                    __callback = (RuntimeInfoKey num, IntPtr userData) =>
                    {
                        string strKey = "Invalid";
                        RuntimeInfoKey key = TvProductHelper.ReconvertKeyIfTvProduct(num);

                        if (key > 0 && Information.EnumStringMapping.ContainsKey(key))
                        {
                            strKey = Information.EnumStringMapping[key];
                        }

                        RuntimeFeatureStatusChangedEventArgs eventArgs = new RuntimeFeatureStatusChangedEventArgs()
                        {
                            Key = Information.HttpPrefix + Information.RuntimeInfoStringKeyPrefix + strKey
                        };

                        Handler?.Invoke(null, eventArgs);
                    };

                    InformationError ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(TvProductHelper.ConvertKeyIfTvProduct(Key), __callback, IntPtr.Zero);
                    if (ret != InformationError.None)
                    {
                        Log.Error(InformationErrorFactory.LogTag, "Interop failed to add event handler");
                        InformationErrorFactory.ThrowException(ret);
                    }
                }
                Handler += value;
            }
            remove
            {
                Handler -= value;
                if (Handler == null)
                {
                    InformationError ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(TvProductHelper.ConvertKeyIfTvProduct(Key));
                    if (ret != InformationError.None)
                    {
                        Log.Error(InformationErrorFactory.LogTag, "Interop failed to add event handler");
                        InformationErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
    }
}
