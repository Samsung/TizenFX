/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// Class for getting resource path.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>
        /// Enumeration for Resource category.
        /// </summary>
        public enum Category : int
        {
            /// <summary>
            /// Image format.
            /// </summary>
            Image = 0,

            /// <summary>
            /// Layout format.
            /// </summary>
            Layout,

            /// <summary>
            /// Sound format.
            /// </summary>
            Sound,

            /// <summary>
            /// Binary format.
            /// </summary>
            Binary
        }

        /// <summary>
        /// Converts resource ID to path name.
        /// </summary>
        /// <param name="category">Category to search</param>
        /// <param name="id">ID to search</param>
        /// <returns>Found resource path</returns>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        public static string GetPath(Category category, string id)
        {
            string path;
            ErrorCode err = Interop.AppCommon.AppResourceManagerGet(
                    (Interop.AppCommon.ResourceCategory)category, id, out path);

            switch (err)
            {
                case ErrorCode.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");

                case ErrorCode.OutOfMemory:
                throw new InvalidOperationException("Out-of-memory at unmanaged code");

                case ErrorCode.IoError:
                throw new InvalidOperationException("IO error at unmanaged code");
            }

            return path;
        }

        /// <summary>
        /// Converts resource ID to path name.
        /// </summary>
        /// <param name="category">Category to search</param>
        /// <param name="id">ID to search</param>
        /// <returns>Found resource path or null when the resource doesn't exist</returns>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        public static string TryGetPath(Category category, string id)
        {
            string path;
            ErrorCode err = Interop.AppCommon.AppResourceManagerGet(
                    (Interop.AppCommon.ResourceCategory)category, id, out path);

            switch (err)
            {
                case ErrorCode.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");

                case ErrorCode.OutOfMemory:
                throw new InvalidOperationException("Out-of-memory at unmanaged code");

                case ErrorCode.IoError:
                return null;
            }

            return path;
        }
    }
}
