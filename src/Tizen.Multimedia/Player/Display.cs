/// Display
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
    /// Display
    /// </summary>
    /// <remarks>
    /// This class provides properties and API that are required for setting
    /// display configurations of a player.
    /// </remarks>
    public class Display
    {

        /// <summary>
        /// Set/Get Display mode.
        /// </summary>
        /// <value> LetterBox, OriginalSize, FullScreen, CroppedFull, OriginalOrFull, DstRoi </value>
        public DisplayMode Mode 
		{
			set
			{
				int ret = Interop.Player.SetDisplayMode (_playerHandle, (int)value);
				if ( ret == (int)PlayerError.None) 
				{
					_displayMode = value;
				} 
				else 
				{
					Log.Error (PlayerLog.LogTag, "Setting display mode failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException (ret, "Setting display mode failed"); 
				}
			}
			get
			{ 
				return _displayMode;
			}
		}

        /// <summary>
        /// Set/Get IsVisible.
        /// </summary>
        /// <value> true, false </value>
        public bool IsVisible 
		{
			set
			{
				int ret = Interop.Player.SetDisplayVisible (_playerHandle, value);
				if (ret == (int)PlayerError.None) 
				{
					_isVisible = value;
				} 
				else 
				{
					Log.Error (PlayerLog.LogTag, "Setting display visible failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException (ret, "Setting display visible failed"); 
				}
			}
			get
			{
				return _isVisible;
			}
		}

        /// <summary>
        /// Set/Get Display rotation.
        /// </summary>
        /// <value> RotationNone, Rotation90, Rotation180, Rotation270 </value>
        public DisplayRotation Rotation 
		{
			set
			{
				int ret = Interop.Player.SetDisplayRotation (_playerHandle, (int)value);
				if (ret == (int)PlayerError.None)
				{
					_rotation = value;
				} else 
				{
					Log.Error (PlayerLog.LogTag, "Setting display rotation failed" + (PlayerError)ret);
					PlayerErrorFactory.ThrowException (ret, "Setting display rotation failed"); 
				}
			}
			get
			{
				return _rotation;
			}
		}



        /// <summary>
        /// Constructor - sets video display </summary>
        /// <param name="displayType"> display type</param>
        public Display(DisplayType displayType)
        {
        }


		internal IntPtr _playerHandle;
		internal DisplayMode _displayMode;
		internal bool _isVisible;
		internal DisplayRotation _rotation;
    }
}