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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IAction
	{
		void DebugDraw(DebugDraw debugDrawer);
		void UpdateAction(CollisionWorld collisionWorld, float deltaTimeStep);
	}

	internal class ActionInterfaceWrapper : BulletDisposableObject
	{
		private IAction _actionInterface;
		private readonly DynamicsWorld _world;

		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void DebugDrawUnmanagedDelegate(IntPtr debugDrawer);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void UpdateActionUnmanagedDelegate(IntPtr collisionWorld, float deltaTimeStep);

		private readonly DebugDrawUnmanagedDelegate _debugDraw;
		private readonly UpdateActionUnmanagedDelegate _updateAction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ActionInterfaceWrapper(IAction actionInterface, DynamicsWorld world)
		{
			_debugDraw = new DebugDrawUnmanagedDelegate(DebugDrawUnmanaged);
			_updateAction = new UpdateActionUnmanagedDelegate(UpdateActionUnmanaged);

			IntPtr native = btActionInterfaceWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_debugDraw),
				Marshal.GetFunctionPointerForDelegate(_updateAction));
			InitializeUserOwned(native);

			_actionInterface = actionInterface;
			_world = world;
		}

		private void DebugDrawUnmanaged(IntPtr debugDrawer)
		{
			_actionInterface.DebugDraw(DebugDraw.GetManaged(debugDrawer));
		}

		private void UpdateActionUnmanaged(IntPtr collisionWorld, float deltaTimeStep)
		{
			_actionInterface.UpdateAction(_world, deltaTimeStep);
		}

		protected override void Dispose(bool disposing)
		{
			btActionInterface_delete(Native);
		}
	}
}
