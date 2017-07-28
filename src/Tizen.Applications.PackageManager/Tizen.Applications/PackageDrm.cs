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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides the methods and properties for the DRM operation.
    /// </summary>
    public class PackageDrm
    {
        private string _responseData;
        private string _requestData;
        private string _licenseUrl;
        private PackageDrm(string responseData, string requestData, string licenseUrl)
        {
            _responseData = responseData;
            _requestData = requestData;
            _licenseUrl = licenseUrl;
        }

        /// <summary>
        /// Returns the response data.
        /// </summary>
        /// <returns>Returns the response data which is given when GenerateLicenseRequest has been invoked.</returns>
        public string ResponseData { get { return _responseData; } }

        /// <summary>
        /// Returns the request data.
        /// </summary>
        /// <returns>Returns the request data which is generated when GenerateLicenseRequest has been invoked.</returns>
        public string RequestData { get { return _requestData; } }

        /// <summary>
        /// Returns the license URL.
        /// </summary>
        /// <returns>Returns the license URL which is generated when GenerateLicenseRequest has been invoked.</returns>
        public string LicenseUrl { get { return _licenseUrl; } }

        internal static PackageDrm CreateDrmRequest(string responseData, string requestData, string licenseUrl)
        {
            PackageDrm packageDrm = new PackageDrm(responseData, requestData, licenseUrl);
            return packageDrm;
        }

        internal static PackageDrm GenerateLicenseRequest(string responseData)
        {
            string requestData;
            string licenseUrl;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerDrmGenerateLicenseRequest(responseData, out requestData, out licenseUrl);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to generate license request");
            }

            PackageDrm packageDrm = CreateDrmRequest(responseData, requestData, licenseUrl);
            return packageDrm;
        }
    }
}
