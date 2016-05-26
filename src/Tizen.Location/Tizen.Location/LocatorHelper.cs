// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Location
{
    public static class LocatorHelper
    {
        /// <summary>
        /// Checks if the specified geographical positioning type is supported or not.
        /// </summary>
        /// <param name="locationType"> The back-end positioning method to be used for LBS.</param>
        /// <returns>Returns a boolean value indicating whether or not the specified method is supported.</returns>
        public static bool IsSupportedType(LocationType locationType)
        {
            bool initStatus = Interop.LocatorHelper.IsSupported((int)locationType);
            Log.Info(Globals.LogTag, "Checking if the Location Manager type is supported ," + initStatus);
            return initStatus;
        }

        /// <summary>
        /// Checks if the specified geographical positioning type is enabled or not.
        /// </summary>
        /// <param name="locationType"> The back-end positioning method to be used for LBS.</param>
        /// <returns>Returns a boolean value indicating whether or not the specified method is supported.</returns>
        public static bool IsEnableType(LocationType locationType)
        {
            Log.Info(Globals.LogTag, "Checking if the Location Manager type is Enabled");
            bool initStatus;
            int ret = Interop.LocatorHelper.IsEnabled((int)locationType, out initStatus);
            if (((LocationError)ret != LocationError.None))
            {
                Log.Error(Globals.LogTag, "Error Checking the Location Manager type is Enabled," + (LocationError)ret);
                LocationErrorFactory.ThrowLocationException(ret);
            }
            return initStatus;
        }
    }
}
