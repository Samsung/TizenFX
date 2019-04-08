/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd. All Rights Reserved
*
* PROPRIETARY/CONFIDENTIAL
*
* This software is the confidential and proprietary information of
* Samsung Electronics Co., Ltd. ("Confidential Information").
* You shall not disclose such Confidential Information and shall
* use it only in accordance with the terms of the license agreement
* you entered into with Samsung Electronics Co., Ltd. ("SAMSUNG").
*
* SAMSUNG MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY
* OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
* LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR
* A PARTICULAR PURPOSE, OR NON-INFRINGEMENT.SAMSUNG SHALL NOT BE
* LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING,
* MODIFYING OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Sensor
{
    /// <summary>
    /// Indicates Recorder Data callback.
    /// </summary>
    public class RecorderDataEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates Recorder Data callback.
        /// </summary>
        internal RecorderDataEventArgs(Enum type, Int64 data, int remains, Enum error, Int64 userData) {
            Type = type;
            Data = data;
            Remains = remains;
            Error = error;
            UserData = userData;
            RecorderDataStatus = true;
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        public Enum Type { get; private set; }

        /// <summary>
        /// Gets Data.
        /// </summary>
        public Int64 Data { get; private set; }

        /// <summary>
        /// Gets Remains.
        /// </summary>
        public int Remains { get; private set; }

        /// <summary>
        /// Gets Error.
        /// </summary>
        public Enum Error { get; private set; }

        /// <summary>
        /// Gets UserData.
        /// </summary>
        public Int64 UserData { get; private set; }

        /// <summary>
        /// Sets RecorderDataStatus.
        /// </summary>
        public bool RecorderDataStatus { get; set; }

    }
}
