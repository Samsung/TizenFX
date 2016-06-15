/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


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
        public abstract Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter);
    }
}
