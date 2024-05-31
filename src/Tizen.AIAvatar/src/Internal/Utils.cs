/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.IO;
using Tizen.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using static Tizen.AIAvatar.AIAvatar;

namespace Tizen.AIAvatar
{
    internal class Utils
    {
        internal static void ConvertAudioToFloat(in byte[] audioBytes, out float[] audioFloat)
        {
            audioFloat = new float[audioBytes.Length / 2];

            for (int i = 0, j = 0; i < audioBytes.Length; i += 2, j++)
            {
                short sample = BitConverter.ToInt16(audioBytes, i);
                audioFloat[j] = sample / 32768.0f;
            }
        }

        internal static byte[] ReadAllBytes(string path)
        {
            try
            {
                var bytes = File.ReadAllBytes(path);
                return bytes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static void SaveFile(string path, string filename, byte[] array)
        {
            try
            {
                var file = new FileStream($"{path}/{filename}", FileMode.Create);
                file.Write(array, 0, array.Length);
                file.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        internal static void CheckPrivilege(string privilege)
        {
            var result = PrivacyPrivilegeManager.CheckPermission(privilege);

            switch (result)
            {
                case CheckResult.Allow:
                    Log.Info(LogTag, $"Privilege \"{privilege}\" : allowed.");
                    break;
                case CheckResult.Deny:
                    Log.Info(LogTag, $"Privilege \"{privilege}\" : denied.");
                    /// Privilege can't be used
                    break;
                case CheckResult.Ask:
                    /// Request permission to user
                    PrivacyPrivilegeManager.RequestPermission(privilege);
                    break;
            }
        }

        internal static T ConvertJson<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        internal int FindMaxValue<T>(List<T> list, Converter<T, int> projection)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int maxValue = int.MinValue;
            foreach (T item in list)
            {
                int value = projection(item);
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }
    }
}

internal class SystemUtils
{
    internal static string GetFileName(string path)
    {
        return System.IO.Path.GetFileName(path);
    }
    internal static string GetFileNameWithoutExtension(string path)
    {
        return System.IO.Path.GetFileNameWithoutExtension(path);
    }
}
