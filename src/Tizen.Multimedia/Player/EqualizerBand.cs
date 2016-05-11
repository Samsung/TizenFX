/// Equalizer Band
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Multimedia
{

    /// <summary>
    /// Equalizer band
    /// </summary>
    /// <remarks>
    /// Contains Equalizer properties
    /// </remarks>
    public class EqualizerBand
    {
        /// <summary>
        /// Set/Get  new gain in decibel that is set to the given band [dB]
        /// </summary>
        /// <value> int level </value>
        public int Level { set; get;}

        /// <summary>
        /// Get frequency of the given band [dB] .
        /// </summary>
        /// <value> int frequency</value>
        public int Frequency 
        {
            get
            {
                return _frequency;
            }
        }

        /// <summary>
        /// Getfrequency range of the given band [dB].
        /// </summary>
        /// <value> int range </value>
        public int Range 
        {
            get
            {
                return _range;
            }
        }

        internal int _frequency;
        internal int _range;
    }
}