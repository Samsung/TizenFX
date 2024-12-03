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
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Abstract base class for AI services, providing common functionalities.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BaseAIService : IAIService, IDisposable
    {
        /// <summary>
        /// Gets the name of the AI service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)] 
        public abstract string ServiceName { get; }

        /// <summary>
        /// Gets the capabilities of the AI service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract ServiceCapabilities Capabilities { get; }

        /// <summary>
        /// Gets the service client manager responsible for managing client operations.
        /// </summary>
        protected ServiceClientManager ClientManager { get; }

        /// <summary>
        /// Gets the configuration settings for the AI service.
        /// </summary>
        protected AIServiceConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAIService"/> class with the specified configuration.
        /// </summary>
        /// <param name="config">The configuration settings for the AI service.</param>
        protected BaseAIService(AIServiceConfiguration config)
        {
            Configuration = config;
            ClientManager = new ServiceClientManager(config);
        }

        /// <summary>
        /// Releases all resources used by the AI service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the AI service.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && ClientManager != null)
            {
                ClientManager.Dispose();
            }
        }
    }
}