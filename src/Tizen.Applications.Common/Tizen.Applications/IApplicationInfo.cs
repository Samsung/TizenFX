/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Defines the common contract for application information.
    /// </summary>
    /// <remarks>
    /// This interface abstracts the shared properties between <see cref="ApplicationInfo"/>
    /// and <see cref="TeamApplicationInfo"/>.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IApplicationInfo : IDisposable
    {
        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ApplicationId { get; }

        /// <summary>
        /// Gets the package ID of the application.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string PackageId { get; }

        /// <summary>
        /// Gets the label of the application.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Label { get; }

        /// <summary>
        /// Gets the executable path of the application.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExecutablePath { get; }

        /// <summary>
        /// Gets the absolute path to the icon image.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IconPath { get; }

        /// <summary>
        /// Gets the application type name.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ApplicationType { get; }

        /// <summary>
        /// Gets the application component type.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        ApplicationComponentType ComponentType { get; }

        /// <summary>
        /// Gets the application's metadata.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Gets a value indicating whether the application is not displayed on the launcher.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsNoDisplay { get; }

        /// <summary>
        /// Gets a value indicating whether the application is launched automatically on system boot.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsOnBoot { get; }

        /// <summary>
        /// Gets a value indicating whether the application is preloaded on the device.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IsPreload { get; }

        /// <summary>
        /// Gets the categories the application belongs to.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<string> Categories { get; }

        /// <summary>
        /// Gets the shared data path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedDataPath { get; }

        /// <summary>
        /// Gets the shared resource path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedResourcePath { get; }

        /// <summary>
        /// Gets the shared trusted path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedTrustedPath { get; }

        /// <summary>
        /// Gets the external shared data path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExternalSharedDataPath { get; }

        /// <summary>
        /// Gets the resource controls.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<ResourceControl> ResourceControls { get; }

        /// <summary>
        /// Gets the common shared data path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonSharedDataPath { get; }

        /// <summary>
        /// Gets the common shared trusted path.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonSharedTrustedPath { get; }

        /// <summary>
        /// Gets the localized label of the application for the given locale.
        /// </summary>
        /// <param name="locale">The locale string.</param>
        /// <returns>The localized label string.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string GetLocalizedLabel(string locale);
    }
}