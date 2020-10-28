/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Applications;
using Tizen.Account.AccountManager;

namespace Tizen.Account.SyncManager
{
    /// <summary>
    /// This class contains the delegates to be called upon scheduling a sync operation.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SyncAdapter
    {
        Interop.Adapter.SyncAdapterStartSyncCallback _startSyncCallback;
        Interop.Adapter.SyncAdapterCancelSyncCallback _cancelSyncCallback;

        /// <summary>
        /// The callback function for the sync adapter's start sync request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="syncParameters"> The sync job parameters corresponding to the sync request. </param>
        /// <returns> true if the sync operation is success, @c false otherwise. </returns>
        public delegate bool StartSyncCallback(SyncJobData syncParameters);

        /// <summary>
        /// The callback function for the sync adapter's cancel sync request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="syncParameters"> The sync job parameters corresponding to the sync request. </param>
        public delegate void CancelSyncCallback(SyncJobData syncParameters);

        /// <summary>
        /// Sets the client (sync adapter) callback functions.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="startSyncCb"> A callback function to be called by the sync manager for performing the sync operation. </param>
        /// <param name="cancelSyncCb"> A callback function to be called by the sync manager for cancelling the sync operation. </param>
        /// <exception cref="ArgumentNullException"> Thrown when any of the arguments are null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when the application calling this API cannot be a sync adapter. </exception>
        public void SetSyncEventCallbacks(StartSyncCallback startSyncCb, CancelSyncCallback cancelSyncCb)
        {
            if (startSyncCb == null || cancelSyncCb == null)
            {
                throw new ArgumentNullException();
            }

            _startSyncCallback = (IntPtr accountHandle, string syncJobName, string syncCapability, IntPtr syncJobUserData) =>
            {
                Log.Debug(ErrorFactory.LogTag, "Start sync event received");

                AccountManager.Account account = new AccountManager.Account(new SafeAccountHandle(accountHandle, true));
                Bundle bundle = new Bundle(new SafeBundleHandle(syncJobUserData, true));

                SyncJobData syncJobData = new SyncJobData();
                syncJobData.Account = account;
                if (syncJobName == null)
                    syncJobData.SyncJobName = syncCapability;
                else
                    syncJobData.SyncJobName = syncJobName;
                syncJobData.UserData = bundle;


                return startSyncCb(syncJobData);
            };

            _cancelSyncCallback = (IntPtr accountHandle, string syncJobName, string syncCapability, IntPtr syncJobUserData) =>
            {
                Log.Debug(ErrorFactory.LogTag, "cancel sync event received");

                AccountManager.Account account = new AccountManager.Account(new SafeAccountHandle(accountHandle, true));
                Bundle bundle = new Bundle(new SafeBundleHandle(syncJobUserData, true));

                SyncJobData syncJobData = new SyncJobData();
                syncJobData.Account = account;
                if (syncJobName == null)
                    syncJobData.SyncJobName = syncCapability;
                else
                    syncJobData.SyncJobName = syncJobName;
                syncJobData.UserData = bundle;

                cancelSyncCb(syncJobData);
            };

            int ret = Interop.Adapter.SetCallbacks(_startSyncCallback, _cancelSyncCallback);
            if (ret != (int)SyncManagerErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to set callbacks");
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Unsets the client (sync adapter) callback functions.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="Exception"> Thrown when sync manager internal error occurs. </exception>
        public void UnsetSyncEventCallbacks()
        {
            int ret = Interop.Adapter.UnsetCallbacks();
            if (ret != (int)SyncManagerErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to unset callbacks");
                throw ErrorFactory.GetException(ret);
            }
        }
    }
}

