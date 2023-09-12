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
	public abstract class MotionState : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void GetWorldTransformUnmanagedDelegate(out Matrix4x4 worldTrans);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void SetWorldTransformUnmanagedDelegate(ref Matrix4x4 worldTrans);

		private readonly GetWorldTransformUnmanagedDelegate _getWorldTransform;
		private readonly SetWorldTransformUnmanagedDelegate _setWorldTransform;

		internal MotionState(ConstructionInfo info)
		{
		}

		protected MotionState()
		{
			_getWorldTransform = new GetWorldTransformUnmanagedDelegate(GetWorldTransformUnmanaged);
			_setWorldTransform = new SetWorldTransformUnmanagedDelegate(SetWorldTransformUnmanaged);

			IntPtr native = btMotionStateWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_getWorldTransform),
				Marshal.GetFunctionPointerForDelegate(_setWorldTransform));
			InitializeUserOwned(native);
		}

		void GetWorldTransformUnmanaged(out Matrix4x4 worldTrans)
		{
			GetWorldTransform(out worldTrans);
		}

		void SetWorldTransformUnmanaged(ref Matrix4x4 worldTrans)
		{
			SetWorldTransform(ref worldTrans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void GetWorldTransform(out Matrix4x4 worldTrans);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract void SetWorldTransform(ref Matrix4x4 worldTrans);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 WorldTransform
		{
			get
			{
				Matrix4x4 transform;
				GetWorldTransform(out transform);
				return transform;
			}
			set => SetWorldTransform(ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btMotionState_delete(Native);
		}
	}
}
