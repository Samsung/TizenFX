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
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.NUI
{
    /// <summary>
    /// Window information class for ComponentApplication
    /// </summary>
    internal class NUIWindowInfo : IWindowInfo
    {
        private const string logTag = "Tizen.NUI";
        private Window window;
        private int resourceId;
        private bool disposed = false;

        /// <summary>
        /// Initializes the NUI Window class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        internal NUIWindowInfo(Window win)
        {
            window = win;
        }

        /// <summary>
        /// Gets the resource ID of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        public int ResourceId
        {
            get
            {
                if (resourceId == 0)
                {
                    resourceId = window.GetNativeId();
                    if (resourceId != 0)
                        Log.Info(logTag, "Fail to get resource ID");
                }

                return resourceId;
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                window.Dispose();
                window = null;
            }
            disposed = true;
        }

        /// <summary>
        /// Dispose the window resources
        /// </summary>
        /// <returns></returns>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

