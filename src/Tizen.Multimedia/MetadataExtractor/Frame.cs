/// Frame
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.using System;
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Frame information
	/// </summary>
	/// <remarks>
	/// This class provides properties of the frame information of the given media
	/// </remarks>
	public class Frame
	{
		internal Frame(byte[] frameData)
		{
			FrameData = frameData;
		}
		public readonly byte[] FrameData;
	}
}
