/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for console message of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebConsoleMessage : Disposable
    {
        internal WebConsoleMessage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for level of log severity.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SeverityLevel
        {
            /// <summary>
            /// Empty.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Empty,

            /// <summary>
            /// Log level.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Log,

            /// <summary>
            /// Warning level.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Warning,

            /// <summary>
            /// Error level.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Error,

            /// <summary>
            /// Debug level.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Debug,

            /// <summary>
            /// Info level.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Info,
        }

        /// <summary>
        /// Queries the source of the console message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Source
        {
            get
            {
                return Interop.WebConsoleMessage.GetSource(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries line no of the console message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Line
        {
            get
            {
                return Interop.WebConsoleMessage.GetLine(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries the log severity of the console message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SeverityLevel Level
        {
            get
            {
                return (SeverityLevel)Interop.WebConsoleMessage.GetSeverityLevel(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries the text of console message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return Interop.WebConsoleMessage.GetText(SwigCPtr);
            }
        }
    }
}
