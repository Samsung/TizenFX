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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Provides commands to manage face information in the database.
    /// </summary>
    /// <seealso cref="Album"/>
    /// <since_tizen> 4 </since_tizen>
    public class FaceInfoCommand : MediaCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaceInfoCommand"/> class with the specified <see cref="MediaDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MediaDatabase"/> that the commands run on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="database"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="database"/> has already been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public FaceInfoCommand(MediaDatabase database) : base(database)
        {
        }

        /// <summary>
        /// Deletes the face information from the database.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="faceInfoId">The face information ID to delete.</param>
        /// <returns>true if the matched record was found and deleted, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="faceInfoId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="faceInfoId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool Delete(string faceInfoId)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(faceInfoId, nameof(faceInfoId));

            var reader = Select(new SelectArguments { FilterExpression = $"{FaceInfoColumns.Id}='{faceInfoId}'" });

            if (reader.Read() == false)
            {
                return false;
            }

            CommandHelper.Delete(Interop.Face.DeleteFromDb, faceInfoId);
            return true;
        }

        /// <summary>
        /// Retrieves the face information.
        /// </summary>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<FaceInfo> Select()
        {
            return Select(null);
        }

        /// <summary>
        /// Retrieves the face information with the <see cref="SelectArguments"/>.
        /// </summary>
        /// <param name="filter">The criteria to use to filter. This value can be null.</param>
        /// <returns>The <see cref="MediaDataReader{TRecord}"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <since_tizen> 4 </since_tizen>
        public MediaDataReader<FaceInfo> Select(SelectArguments filter)
        {
            ValidateDatabase();

            return CommandHelper.Select(filter, Interop.Face.ForeachFromDb, FaceInfo.FromHandle);
        }

        /// <summary>
        /// Updates a tag with the specified tag.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="faceInfoId">The face information ID to update.</param>
        /// <param name="tag">The tag value for update.</param>
        /// <returns>true if the matched record was found and updated, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="faceInfoId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="faceInfoId"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 4 </since_tizen>
        public bool UpdateTag(string faceInfoId, string tag)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(faceInfoId, nameof(faceInfoId));

            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            var handle = CommandHelper.SelectScalar(Interop.Face.ForeachFromDb, $"{FaceInfoColumns.Id}='{faceInfoId}'",
                Interop.Face.Clone);

            if (handle == IntPtr.Zero)
            {
                return false;
            }

            try
            {
                Interop.Face.SetTag(handle, tag).ThrowIfError("Failed to update(setting tag)");

                Interop.Face.Update(handle).ThrowIfError("Failed to update(executing query)");
                return true;
            }
            finally
            {
                Interop.Face.Destroy(handle);
            }
        }

        /// <summary>
        /// Inserts a new face information to the database with the specified media ID, area, orientation.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to be associated with.</param>
        /// <param name="area">The region of face in the media.</param>
        /// <param name="orientation">The orientation of specified media.</param>
        /// <returns>The <see cref="FaceInfo"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null. </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="orientation"/> is not valid enumeration.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FaceInfo Insert(string mediaId, Rectangle area, Orientation orientation)
        {
            return Insert(mediaId, area, orientation, null);
        }

        /// <summary>
        /// Inserts a new face information to the database with the specified media ID, area, orientation, and tag.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/content.write</privilege>
        /// <param name="mediaId">The media ID to be associated with.</param>
        /// <param name="area">The region of face in the media.</param>
        /// <param name="orientation">The orientation of specified media.</param>
        /// <param name="tag">The tag value.</param>
        /// <returns>The <see cref="FaceInfo"/> containing the results.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="MediaDatabase"/> is disconnected.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaDatabase"/> has already been disposed of.</exception>
        /// <exception cref="MediaDatabaseException">An error occurred while executing the command.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="mediaId"/> is null. </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="mediaId"/> is a zero-length string, contains only white space.<br/>
        ///     -or-<br/>
        ///     <paramref name="orientation"/> is not valid enumeration.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FaceInfo Insert(string mediaId, Rectangle area, Orientation orientation, string tag)
        {
            ValidateDatabase();

            ValidationUtil.ValidateNotNullOrEmpty(mediaId, nameof(mediaId));
            ValidationUtil.ValidateEnum(typeof(Orientation), orientation, nameof(orientation));

            Interop.Face.Create(mediaId, out IntPtr handle).ThrowIfError("Failed to create face handle");

            try
            {
                Interop.Face.SetFaceRect(handle, area.X, area.Y, area.Width, area.Height).
                    ThrowIfError("Failed to set face area");

                Interop.Face.SetOrientation(handle, orientation).ThrowIfError("Failed to set face orientation");

                if (tag != null)
                {
                    Interop.Face.SetTag(handle, tag).ThrowIfError("Failed to set face tag");
                }

                Interop.Face.Insert(handle).ThrowIfError("Failed to insert face information");

                return new FaceInfo(handle);
            }
            finally
            {
                Interop.Face.Destroy(handle).ThrowIfError("Failed to destroy face handle");
            }
        }
    }
}
