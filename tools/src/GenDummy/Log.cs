/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace GenDummy
{
    public enum LogLevel
    {
        NONE = 0,
        ERROR,
        WARNING,
        INFO,
        DEBUG,
        VERBOSE
    }

    public class Log
    {
        public static LogLevel Level { get; set; } = LogLevel.INFO;

        public static void Error(string msg) => Print(LogLevel.ERROR, "[ERROR] " + msg);

        public static void Warning(string msg) => Print(LogLevel.WARNING, "[WARNING] " + msg);

        public static void Info(string msg) => Print(LogLevel.INFO, "[INFO] " + msg);

        public static void Debug(string msg) => Print(LogLevel.DEBUG, "[DEBUG] " + msg);

        public static void Verbose(string msg) => Print(LogLevel.VERBOSE, "[VERBOSE] " + msg);

        private static void Print(LogLevel msgLevel, string msg)
        {
            if (Level >= msgLevel)
            {
                Console.WriteLine(msg);
            }
        }
    }
}