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
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Defines the common contract for directory information.
    /// </summary>
    /// <remarks>
    /// This interface abstracts the shared properties between <see cref="DirectoryInfo"/>
    /// and <see cref="TeamDirectoryInfo"/>.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDirectoryInfo
    {
        /// <summary>
        /// Gets the absolute path to the application's data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Data { get; }

        /// <summary>
        /// Gets the absolute path to the application's cache directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Cache { get; }

        /// <summary>
        /// Gets the absolute path to the application resource directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string Resource { get; }

        /// <summary>
        /// Gets the absolute path to the application's shared data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedData { get; }

        /// <summary>
        /// Gets the absolute path to the application's shared resource directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedResource { get; }

        /// <summary>
        /// Gets the absolute path to the application's shared trusted directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string SharedTrusted { get; }

        /// <summary>
        /// Gets the absolute path to the application's external data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExternalData { get; }

        /// <summary>
        /// Gets the absolute path to the application's external cache directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExternalCache { get; }

        /// <summary>
        /// Gets the absolute path to the application's external shared data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExternalSharedData { get; }

        /// <summary>
        /// Gets the absolute path to the application's TEP(Tizen Expansion Package) directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ExpansionPackageResource { get; }

        /// <summary>
        /// Gets the absolute path to the application's common data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonData { get; }

        /// <summary>
        /// Gets the absolute path to the application's common cache directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonCache { get; }

        /// <summary>
        /// Gets the absolute path to the application's common shared data directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonSharedData { get; }

        /// <summary>
        /// Gets the absolute path to the application's common shared trusted directory.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string CommonSharedTrusted { get; }

        /// <summary>
        /// Gets the absolute path to the resource directory allowed by resource control for the given resource type.
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        /// <returns>The path to the allowed resource directory.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string GetResourceControlAllowedResource(string resourceType);

        /// <summary>
        /// Gets the absolute path to the global resource directory by resource control for the given resource type.
        /// </summary>
        /// <param name="resourceType">The resource type.</param>
        /// <returns>The path to the global resource directory.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        string GetResourceControlGlobalResource(string resourceType);
    }
}