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
using System.Runtime.InteropServices;
using System.Security;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class TriangleCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void ProcessTriangleDelegate(IntPtr triangle, int partId, int triangleIndex);

		private readonly ProcessTriangleDelegate _processTriangle;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleCallback()
		{
			_processTriangle = new ProcessTriangleDelegate(ProcessTriangleUnmanaged);

			IntPtr native = btTriangleCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_processTriangle));
			InitializeUserOwned(native);
		}

		private void ProcessTriangleUnmanaged(IntPtr triangle, int partId, int triangleIndex)
		{
			float[] triangleData = new float[11];
			Marshal.Copy(triangle, triangleData, 0, 11);
			global::System.Numerics.Vector3 p0 = new global::System.Numerics.Vector3(triangleData[0], triangleData[1], triangleData[2]);
			global::System.Numerics.Vector3 p1 = new global::System.Numerics.Vector3(triangleData[4], triangleData[5], triangleData[6]);
			global::System.Numerics.Vector3 p2 = new global::System.Numerics.Vector3(triangleData[8], triangleData[9], triangleData[10]);
			ProcessTriangle(ref p0, ref p1, ref p2, partId, triangleIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void ProcessTriangle(ref global::System.Numerics.Vector3 point0, ref global::System.Numerics.Vector3 point1, ref global::System.Numerics.Vector3 point2, int partId, int triangleIndex);

		protected override void Dispose(bool disposing)
		{
			btTriangleCallback_delete(Native);
		}
}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class InternalTriangleIndexCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		delegate void InternalProcessTriangleIndexDelegate(IntPtr triangle, int partId, int triangleIndex);

		private readonly InternalProcessTriangleIndexDelegate _internalProcessTriangleIndex;

		internal InternalTriangleIndexCallback()
		{
			_internalProcessTriangleIndex = new InternalProcessTriangleIndexDelegate(InternalProcessTriangleIndexUnmanaged);

			IntPtr native = btInternalTriangleIndexCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_internalProcessTriangleIndex));
			InitializeUserOwned(native);
		}

		private void InternalProcessTriangleIndexUnmanaged(IntPtr triangle, int partId, int triangleIndex)
		{
			float[] triangleData = new float[11];
			Marshal.Copy(triangle, triangleData, 0, 11);
		 	global::System.Numerics.Vector3 p0 = new global::System.Numerics.Vector3(triangleData[0], triangleData[1], triangleData[2]);
		 	global::System.Numerics.Vector3 p1 = new global::System.Numerics.Vector3(triangleData[4], triangleData[5], triangleData[6]);
		 	global::System.Numerics.Vector3 p2 = new global::System.Numerics.Vector3(triangleData[8], triangleData[9], triangleData[10]);
			InternalProcessTriangleIndex(ref p0, ref p1, ref p2, partId, triangleIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void InternalProcessTriangleIndex(ref global::System.Numerics.Vector3 point0, ref global::System.Numerics.Vector3 point1, ref global::System.Numerics.Vector3 point2, int partId, int triangleIndex);

		protected override void Dispose(bool disposing)
		{
			btInternalTriangleIndexCallback_delete(Native);
		}
	}
}
