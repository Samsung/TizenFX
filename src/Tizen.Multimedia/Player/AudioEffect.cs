/// Audio effect
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;


namespace Tizen.Multimedia
{
    /// <summary>
    /// Audio effect
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for setting
    /// audio effects of a player.
    /// </remarks>
    public class AudioEffect
    {

        /// <summary>
        /// Set/Get Equalizer band level, frequency and range.
        /// </summary>
        /// <value> EqualizerBand </value>
		public IList<EqualizerBand> EqualizerBands 
		{ 
			set
			{
				int ret;
				_bands = value;
				foreach(EqualizerBand band in _bands)
				{
					ret = Interop.Player.AudioEffectSetEqualizerBandLevel(_playerHandle, _bands.IndexOf(band), band.Level);
					if( ret != (int)PlayerError.None) 
					{
						Log.Error(PlayerLog.LogTag, "Failed to set equalizer band" + (PlayerError)ret);
						PlayerErrorFactory.ThrowException(ret, "Failed to set equalizer band"); 
					}
				}

			}
			get
			{
				return _bands;
			}
		}

        /// <summary>
        /// Get Min level.
        /// </summary>
        /// <value> Minimum level </value>
        public int MinLevel 
		{ 
			get 
			{ 
				int min, max, ret;
				ret = Interop.Player.AudioEffectGetEqualizerLevelRange(_playerHandle, out min, out max);
				if( ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get min level" + (PlayerError)ret);
				}
				return min;
			}
		}

        /// <summary>
        /// Get Min level.
        /// </summary>
        /// <value> Maximum level </value>
        public int MaxLevel 
		{
			get
			{
				int min, max, ret;
				ret = Interop.Player.AudioEffectGetEqualizerLevelRange(_playerHandle, out min, out max);
				if(ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get max level" + (PlayerError)ret);
				}
				return max;
			}
		}

        /// <summary>
        /// Get equalizer avaialbility.
        /// </summary>
        /// <value> true, false </value>
        public bool Available 
		{ 
			get
			{
				bool available = false;
				int ret = Interop.Player.AudioEffectEqualizerIsAvailable(_playerHandle, out available);
				if( ret != (int)PlayerError.None) 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get equalizer availability" + (PlayerError)ret);
				}
				return available;
			}
		}

		internal AudioEffect()
		{
		}

		internal IntPtr _playerHandle;

		IList<EqualizerBand> _bands;
    }
}