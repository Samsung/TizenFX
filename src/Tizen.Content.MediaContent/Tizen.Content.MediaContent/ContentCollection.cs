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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    public abstract class ContentCollection : IDisposable
    {
        /// <summary>
        /// Gets the media count for this content store matching the passed filter
        /// </summary>
        /// <param name="filter">the media filter</param>
        /// <returns>Media count</returns>
        public abstract int GetMediaInformationCount(ContentFilter filter);

        /// <summary>
        /// Destroys the unmanaged handles.
        /// Call Dispose API once Contentcollection operations are completed.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Gets the media matching the passed filter for this content store, asynchronously
        /// </summary>
        /// <param name="filter">The media filter</param>
        /// <returns>Task with Media Information list</returns>
        public abstract IEnumerable<MediaInformation> GetMediaInformations(ContentFilter filter);
    }
}
