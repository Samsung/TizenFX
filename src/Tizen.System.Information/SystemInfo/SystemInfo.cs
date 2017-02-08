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

namespace Tizen.System
{
    /// <summary>
    /// System Information class. This class has methods which can be used to obtain device information
    /// </summary>
    public static class SystemInfo
    {
        private const string LogTag = "Tizen.System";

        private static Interop.SystemInfo.SystemInfoType GetValueType(string key, out Interop.SystemInfo.SystemInfoValueType valueType)
        {
            Interop.SystemInfo.ErrorCode err = Interop.SystemInfo.SystemInfoGetPlatformType(key, out valueType);
            if (err == Interop.SystemInfo.ErrorCode.None)
            {
                return Interop.SystemInfo.SystemInfoType.platform;
            }

            Log.Debug(LogTag, string.Format("Key {0} not in platform system info", key));
            err = Interop.SystemInfo.SystemInfoGetCustomType(key, out valueType);
            if (err == Interop.SystemInfo.ErrorCode.None)
            {
                return Interop.SystemInfo.SystemInfoType.Custom;
            }

            Log.Debug(LogTag, string.Format("Key {0} not in custom system info", key));
            return Interop.SystemInfo.SystemInfoType.None;
        }

        /// <summary>
        /// Checks if type of value for given feature is T
        /// </summary>
        /// <typeparam name="T">Type of value for feature key</typeparam>
        /// <param name="key">The name of the feature</param>
        /// <returns>true if type of value for given feature is T, false otherwise</returns>
        public static bool Is<T>(string key)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            Interop.SystemInfo.SystemInfoType keyType = GetValueType(key, out valueType);
            if (keyType == Interop.SystemInfo.SystemInfoType.None)
            {
                return false;
            }

            switch (valueType)
            {
                case Interop.SystemInfo.SystemInfoValueType.Bool:
                    return typeof(T) == typeof(bool);
                case Interop.SystemInfo.SystemInfoValueType.Double:
                    return typeof(T) == typeof(double);
                case Interop.SystemInfo.SystemInfoValueType.Int:
                    return typeof(T) == typeof(int);
                case Interop.SystemInfo.SystemInfoValueType.String:
                    return typeof(T) == typeof(string);
            }
            return false;
        }

        /// <summary>
        /// Checks if given key is valid feature
        /// </summary>
        /// <param name="key">The name of the feature</param>
        /// <returns>true of key is valid, false otherwise</returns>
        public static bool IsValidKey(string key)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            return GetValueType(key, out valueType) != Interop.SystemInfo.SystemInfoType.None;
        }

        /// <summary>
        /// Gets the value of the feature.
        /// </summary>
        /// <typeparam name="T">Type of key value</typeparam>
        /// <param name="key">The name of the feature</param>
        /// <param name="value">The value of the given feature</param>
        /// <returns>return true on success otherwise false</returns>
        public static bool TryGetValue<T>(string key, out T value)
        {
            bool res = false;
            if (typeof(T) == typeof(bool))
            {
                bool val;
                res = TryGetValue(key, out val);
                value = (T)(object)val;
            }
            else if (typeof(T) == typeof(int))
            {
                int val;
                res = TryGetValue(key, out val);
                value = (T)(object)val;
            }
            else if (typeof(T) == typeof(double))
            {
                double val;
                res = TryGetValue(key, out val);
                value = (T)(object)val;
            }
            else if (typeof(T) == typeof(string))
            {
                string val;
                res = TryGetValue(key, out val);
                value = (T)(object)val;
            }
            else
            {
                value = default(T);
            }
            return res;
        }

        /// <summary>
        /// Gets the bool value of the feature.
        /// </summary>
        /// <param name="key">The name of the feature</param>
        /// <param name="value">The value of the given feature</param>
        /// <returns>return true on success otherwise false</returns>
        public static bool TryGetValue(string key, out bool value)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            Interop.SystemInfo.SystemInfoType keyType = GetValueType(key, out valueType);

            Interop.SystemInfo.ErrorCode err = Interop.SystemInfo.ErrorCode.InvalidParameter;
            if (keyType == Interop.SystemInfo.SystemInfoType.platform)
            {
                err = Interop.SystemInfo.SystemInfoGetPlatformBool(key, out value);
            }
            else if (keyType == Interop.SystemInfo.SystemInfoType.Custom)
            {
                err = Interop.SystemInfo.SystemInfoGetCustomBool(key, out value);
            } else
            {
                value = false;
            }

            if (err != Interop.SystemInfo.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get value for key: {0}. err = {1}", key, err));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the int value of the feature.
        /// </summary>
        /// <param name="key">The name of the feature</param>
        /// <param name="value">The value of the given feature</param>
        /// <returns>return true on success otherwise false</returns>
        public static bool TryGetValue(string key, out int value)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            Interop.SystemInfo.SystemInfoType keyType = GetValueType(key, out valueType);

            Interop.SystemInfo.ErrorCode err = Interop.SystemInfo.ErrorCode.InvalidParameter;
            if (keyType == Interop.SystemInfo.SystemInfoType.platform)
            {
                err = Interop.SystemInfo.SystemInfoGetPlatformInt(key, out value);
            }
            else if (keyType == Interop.SystemInfo.SystemInfoType.Custom)
            {
                err = Interop.SystemInfo.SystemInfoGetCustomInt(key, out value);
            }
            else
            {
                value = 0;
            }

            if (err != Interop.SystemInfo.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get value for key: {0}. err = {1}", key, err));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the double value of the feature.
        /// </summary>
        /// <param name="key">The name of the feature</param>
        /// <param name="value">The value of the given feature</param>
        /// <returns>return true on success otherwise false</returns>
        public static bool TryGetValue(string key, out double value)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            Interop.SystemInfo.SystemInfoType keyType = GetValueType(key, out valueType);

            Interop.SystemInfo.ErrorCode err = Interop.SystemInfo.ErrorCode.InvalidParameter;
            if (keyType == Interop.SystemInfo.SystemInfoType.platform)
            {
                err = Interop.SystemInfo.SystemInfoGetPlatformDouble(key, out value);
            }
            else if (keyType == Interop.SystemInfo.SystemInfoType.Custom)
            {
                err = Interop.SystemInfo.SystemInfoGetCustomDouble(key, out value);
            }
            else
            {
                value = 0;
            }

            if (err != Interop.SystemInfo.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get value for key: {0}. err = {1}", key, err));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the string value of the feature.
        /// </summary>
        /// <param name="key">The name of the feature</param>
        /// <param name="value">The value of the given feature</param>
        /// <returns>return true on success otherwise false</returns>
        public static bool TryGetValue(string key, out string value)
        {
            Interop.SystemInfo.SystemInfoValueType valueType;
            Interop.SystemInfo.SystemInfoType keyType = GetValueType(key, out valueType);

            Interop.SystemInfo.ErrorCode err = Interop.SystemInfo.ErrorCode.InvalidParameter;
            if (keyType == Interop.SystemInfo.SystemInfoType.platform)
            {
                err = Interop.SystemInfo.SystemInfoGetPlatformString(key, out value);
            }
            else if (keyType == Interop.SystemInfo.SystemInfoType.Custom)
            {
                err = Interop.SystemInfo.SystemInfoGetCustomString(key, out value);
            }
            else
            {
                value = string.Empty;
            }

            if (err != Interop.SystemInfo.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get value for key: {0}. err = {1}", key, err));
                return false;
            }

            return true;
        }
    }
}
