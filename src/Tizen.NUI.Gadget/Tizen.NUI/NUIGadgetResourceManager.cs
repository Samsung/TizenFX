/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Tizen.NUI
{
    /// <summary>
    /// This class has the methods of the NUIGadgetResourceManager.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class NUIGadgetResourceManager
    {
        private readonly string _resourcePath;
        private readonly string _localeDll;
        private readonly string _localeClassName;
        private readonly IDictionary<string, global::System.Resources.ResourceManager> _resourceMap = new Dictionary<string, global::System.Resources.ResourceManager>();

        internal NUIGadgetResourceManager(string resourcePath, string localeDll, string localeClassName)
        {
            _resourcePath = resourcePath;
            _localeDll = localeDll;
            _localeClassName = localeClassName;
        }

        /// <summary>
        /// Get the value of the specified string resource.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <returns>The value of the resource, or null if name cannot be found in a resource set.</returns>
        /// <since_tizen> 10 </since_tizen>
        public string GetString(string name)
        {
            return GetString(name, CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Gets the return value of the string resource localied for the specified culture.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <param name="cultureInfo">An object that represents the culture for which the resource is localied.</param>
        /// <returns>The value of the resource localied for the specified culture, or null if name cannot be found in a resource set.</returns>
        /// <exception cref="ArgumentNullException">Thrown when failed because of a invalid argument.</exception>
        /// <since_tizen> 10 </since_tizen>
        public string GetString(string name, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (cultureInfo == null)
            {
                Log.Warn("Use CurrentUICulture");
                cultureInfo = CultureInfo.CurrentUICulture;
            }

            var resourceManager = GetResourceManager(cultureInfo.Name);
            if (resourceManager == null)
            {
                return string.Empty;
            }

            return resourceManager.GetString(name, cultureInfo);
        }

        private global::System.Resources.ResourceManager GetResourceManager(string locale)
        {
            global::System.Resources.ResourceManager resourceManager;
            if (_resourceMap.TryGetValue(locale, out resourceManager))
            {
                return resourceManager;
            }

            string path = _resourcePath + locale + "/" + _localeDll;
            if (!File.Exists(path))
            {
                Log.Warn(path + " does not exist");
                return null;
            }

            try
            {
                Assembly assembly = Assembly.Load(File.ReadAllBytes(path));
                if (assembly != null)
                {
                    string baseName = _localeClassName + "." + locale;
                    resourceManager = new global::System.Resources.ResourceManager(baseName, assembly);
                    if (resourceManager == null)
                    {
                        Log.Error("Failed to create ResourceManager");
                    }
                    else
                    {
                        _resourceMap.Add(locale, resourceManager);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Log.Error("ArgumentNullException occurs. " + e.Message);
            }
            catch (BadImageFormatException e)
            {
                Log.Error("BadImageFormatException occurs. " + e.Message);
            }
            catch (Exception e)
            {
                Log.Error("Exception occurs. " + e.Message);
            }

            return resourceManager;
        }
    }
}
