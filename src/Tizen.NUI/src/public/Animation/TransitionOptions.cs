/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using System.ComponentModel;
using Tizen.Applications;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This TransitionOptions class is a class to control Transition motion.
    /// This class includes multiple options for the Transition.
    /// NUI supports various kinds of Transitions such as App transition, Page transition, and so on.
    /// </summary>
    /// <seealso cref="NUIApplication.TransitionOptions" />
    /// <since_tizen> 9 </since_tizen>
    public class TransitionOptions : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Initializes the TransitionOptions class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TransitionOptions()
        {
        }

        /// <summary>
        /// String tag to find View pair to be used in Page transition.
        /// If there is a View have same TransitionTag in a next or previous Page.
        /// The View will be pair for transition.
        /// This is property for Page Transition.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string TransitionTag { set; get; } = null;

        /// <summary>
        /// Property for Page transition.
        /// A View could be transition with its child Views or without them.
        /// Default value is false
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool TransitionWithChild { set; get; } = false;

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
