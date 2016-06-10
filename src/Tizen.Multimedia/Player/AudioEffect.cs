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
using System.Linq;


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
		internal IntPtr _playerHandle;
		private List<EqualizerBand> _bands;

		internal AudioEffect()
		{
		}

        /// <summary>
        /// Set/Get Equalizer band level, frequency and range.
        /// </summary>
        /// <value> EqualizerBand </value>
		public IEnumerable<EqualizerBand> EqualizerBands 
		{ 
			set
			{
				int ret;
				_bands = value.ToList();
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
				int ret;
				int count = 0, level = 0, frequency = 0, range = 0;

				if(_bands == null)
				{
					_bands = new List<EqualizerBand>();
				}
				else
				{
					_bands.Clear();
				}

				ret = Interop.Player.AudioEffectGetEqualizerBandsCount(_playerHandle, out count);
				if(ret == (int)PlayerError.None) 
				{
					for(int idx = 0; idx < count; idx++)
					{
						ret = Interop.Player.AudioEffectGetEqualizerBandLevel(_playerHandle, idx, out level);
						if(ret != (int)PlayerError.None)
						{
							Log.Error(PlayerLog.LogTag, "Failed to get equalizer band level");
						}

						ret = Interop.Player.AudioEffectGetEqualizerBandFrequency(_playerHandle, idx, out frequency);
						if(ret != (int)PlayerError.None)
						{
							Log.Error(PlayerLog.LogTag, "Failed to get equalizer band frequency");
						}

						ret = Interop.Player.AudioEffectGetEqualizerBandFrequencyRange(_playerHandle, idx, out range);
						if(ret != (int)PlayerError.None)
						{
							Log.Error(PlayerLog.LogTag, "Failed to get equalizer band frequency range");
						}

						EqualizerBand band = new EqualizerBand(level, frequency, range);
						_bands.Add(band);
					}
				} 
				else 
				{
					Log.Error(PlayerLog.LogTag, "Failed to get equalizer band count");
				}

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
    }
}