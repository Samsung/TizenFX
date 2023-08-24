/*
* Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using NativeApi = Interop.Inspections;

namespace Tizen.Inspections
{
    /// <summary>
    /// DataRequestReceivedEventArgs is an extended EventArgs class.
    /// This class contains event arguments for the DataRequestReceived event from the Inspection class.
    /// </summary>
    public class DataRequestReceivedEventArgs : EventArgs
    {
        internal DataRequestReceivedEventArgs(InspectionData data, string[] parameters, InspectionContext ctx)
        {
            Data = data;
            Parameters = parameters;
            Context = ctx;
        }

        /// <summary>
        /// The instance of InspectionData.
        /// </summary>
        public InspectionData Data { get; internal set; }

        /// <summary>
        /// An array of data request parameters.
        /// </summary>
        public string[] Parameters { get; internal set; }

        /// <summary>
        /// The instance of InspectionContext.
        /// </summary>
        public InspectionContext Context { get; internal set; }
    }
}
