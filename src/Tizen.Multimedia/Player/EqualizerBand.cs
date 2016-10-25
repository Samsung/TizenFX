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
        internal int _level;
        internal int _frequency;
        internal int _range;

        internal EqualizerBand(int level, int frequency, int range)
        {
            _level = level;
            _frequency = frequency;
            _range = range;
        }

        /// <summary>
        /// Set/Get  new gain in decibel that is set to the given band [dB]
        /// </summary>
        /// <value> int level </value>
        public int Level
        {
            set
            {
                _level = value;
            }
            get
            {
                return _level;
            }
        }

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
        /// Get frequency range of the given band [dB].
        /// </summary>
        /// <value> int range </value>
        public int Range
        {
            get
            {
                return _range;
            }
        }
    }
}