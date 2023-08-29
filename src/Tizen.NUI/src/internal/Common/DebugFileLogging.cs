
/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

using global::System;
using global::System.IO;
using global::System.Diagnostics;

namespace Tizen.NUI
{
    internal class DebugFileLogging : Disposable
    {
        #region Constant Fields
        private string logFolderPath;
        #endregion //Constant Fields

        #region Fields
        public static DebugFileLogging Instance => instance;
        private static readonly DebugFileLogging instance = new DebugFileLogging();
        private string filePath;
        private FileStream file;
        #endregion //Fields

        #region Constructors
        private DebugFileLogging()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                logFolderPath = Environment.GetEnvironmentVariable("HOME") + "/nui/";
            }
            else
            {
                logFolderPath = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + "/owner/share/nui/";
            }

            Directory.CreateDirectory(logFolderPath);

            using var process = Process.GetCurrentProcess();
            var id = process.Id;
            filePath = logFolderPath + id.ToString();
            file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        #endregion //Constructors

        #region Methods
        [Conditional("NUI_DISPOSE_DEBUG_ON")]
        internal void WriteLog(string log)
        {
            TimeSpan curr = DateTime.Now.TimeOfDay;

            FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter write = new StreamWriter(file);
            var time = String.Format("[{0,-13}] ", curr.TotalMilliseconds);
            write.WriteLine(time + log);
            write.Close();
        }
        #endregion //Methods
    }
}
