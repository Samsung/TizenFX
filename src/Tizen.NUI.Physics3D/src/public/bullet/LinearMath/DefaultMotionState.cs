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
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DefaultMotionState : MotionState
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultMotionState()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btDefaultMotionState_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultMotionState(Matrix4x4 startTrans)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btDefaultMotionState_new2(ref startTrans);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultMotionState(Matrix4x4 startTrans, Matrix4x4 centerOfMassOffset)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btDefaultMotionState_new3(ref startTrans, ref centerOfMassOffset);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetWorldTransform(out Matrix4x4 worldTrans)
		{
			btMotionState_getWorldTransform(Native, out worldTrans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetWorldTransform(ref Matrix4x4 worldTrans)
		{
			btMotionState_setWorldTransform(Native, ref worldTrans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CenterOfMassOffset
		{
			get
			{
				Matrix4x4 value;
				btDefaultMotionState_getCenterOfMassOffset(Native, out value);
				return value;
			}
			set => btDefaultMotionState_setCenterOfMassOffset(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 GraphicsWorldTrans
		{
			get
			{
				Matrix4x4 value;
				btDefaultMotionState_getGraphicsWorldTrans(Native, out value);
				return value;
			}
			set => btDefaultMotionState_setGraphicsWorldTrans(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 StartWorldTrans
		{
			get
			{
				Matrix4x4 value;
				btDefaultMotionState_getStartWorldTrans(Native, out value);
				return value;
			}
			set => btDefaultMotionState_setStartWorldTrans(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr UserPointer
		{
			get => btDefaultMotionState_getUserPointer(Native);
			set => btDefaultMotionState_setUserPointer(Native, value);
		}
	}
}
