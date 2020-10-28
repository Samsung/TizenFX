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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="MediaController.MetadataUpdated"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MetadataUpdatedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataUpdatedEventArgs"/> class.
        /// </summary>
        /// <param name="metadata">The updated <see cref="MediaControlMetadata"/>.</param>
        /// <since_tizen> 4 </since_tizen>
        public MetadataUpdatedEventArgs(MediaControlMetadata metadata)
        {
            Metadata = metadata;
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <value>The updated <see cref="MediaControlMetadata"/>.</value>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlMetadata Metadata { get; }
    }
}