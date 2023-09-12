/*
 * Copyright (c) 2013-2022 Andres Traks
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class OverlappingPairCallback : BulletDisposableObject
	{
		internal OverlappingPairCallback(ConstructionInfo info)
		{
		}
		/*
		protected OverlappingPairCallback()
		{
			Native = btOverlappingPairCallbackWrapper_new();
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract IntPtr RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1, Dispatcher dispatcher);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0, Dispatcher dispatcher);

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btOverlappingPairCallback_delete(Native);
			}
		}
	}
}
