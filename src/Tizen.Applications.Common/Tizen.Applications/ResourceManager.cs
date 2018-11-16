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
using System.IO;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// The class for getting the resource path.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class ResourceManager
    {
        /// <summary>
        /// Enumeration for the resource category.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        private static ErrorCode AppResourceManagerGet(Category category, string id, out string path)
        {
            ErrorCode err;

            try
            {
                err = Interop.AppCommon.AppResourceManagerGet(
                             (Interop.AppCommon.ResourceCategory)category, id, out path);
            }
            catch (System.TypeLoadException)
            {
                err = Interop.AppCommon.LegacyAppResourceManagerGet(
                             (Interop.AppCommon.ResourceCategory)category, id, out path);
            }

            return err;
        }

        /// <summary>
        /// Converts resource ID to the path name.
        /// </summary>
        /// <param name="category">Category to search.</param>
        /// <param name="id">ID to search.</param>
        /// <returns>Found resource path.</returns>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string GetPath(Category category, string id)
        {
            string path;
            ErrorCode err = AppResourceManagerGet(category, id, out path);

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
        /// Converts resource ID to the path name.
        /// </summary>
        /// <param name="category">Category to search.</param>
        /// <param name="id">ID to search.</param>
        /// <returns>Found resource path or null when the resource doesn't exist.</returns>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static string TryGetPath(Category category, string id)
        {
            string path;
            ErrorCode err;
            string res;

            if (Application.Current != null)
            {
                res = Application.Current.DirectoryInfo.Resource + "res.xml";
            }
            else
            {
                res = Interop.AppCommon.AppGetResourcePath() + "res.xml";
            }

            if (!File.Exists(res))
                return null;

            err = AppResourceManagerGet(category, id, out path);
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
