﻿/*
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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// This class has the methods of the NUIGadgetResourceManager.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIGadgetResourceManager
    {
        private readonly string _resourcePath;
        private readonly string _resourceDll;
        private readonly string _resourceClassName;
        private readonly IDictionary<string, global::System.Resources.ResourceManager> _resourceMap = new Dictionary<string, global::System.Resources.ResourceManager>();

        internal NUIGadgetResourceManager(NUIGadgetInfo info)
        {
            _resourcePath = info.ResourcePath;
            _resourceDll = info.ResourceFile;
            _resourceClassName = info.ResourceClassName;
        }

        /// <summary>
        /// Initializes the resource manager of the gadget.
        /// </summary>
        /// <param name="resourcePath">The path of the resource</param>
        /// <param name="resourceDll">The file name of the resource.</param>
        /// <param name="resourceClassName">The class name of the resource.</param>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadgetResourceManager(string resourcePath, string resourceDll, string resourceClassName)
        {
            _resourcePath = resourcePath;
            _resourceDll = resourceDll;
            _resourceClassName = resourceClassName;
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
        /// Gets the return value of the string resource localized for the specified culture.
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
                if (cultureInfo.Name != "en")
                {
                    resourceManager = GetResourceManager("en");
                    if (resourceManager != null)
                    {
#pragma warning disable CA1304
                        return resourceManager.GetString(name);
#pragma warning restore CA1304
                    }
                }

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

            string path = _resourcePath + locale + "/" + _resourceDll;
            if (!File.Exists(path))
            {
                Log.Warn(path + " does not exist");
                return null;
            }

#pragma warning disable CA1031
            try
            {
                Assembly assembly = Assembly.Load(File.ReadAllBytes(path));
                if (assembly != null)
                {
                    string baseName = _resourceClassName + "." + locale;
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
#pragma warning restore CA1031

            return resourceManager;
        }
    }
}
