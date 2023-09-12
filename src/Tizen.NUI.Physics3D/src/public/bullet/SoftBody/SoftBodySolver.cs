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

using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftBodySolver : BulletDisposableObject
	{
		protected internal SoftBodySolver()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckInitialized()
		{
			return btSoftBodySolver_checkInitialized(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CopyBackToSoftBodies(bool bMove = true)
		{
			btSoftBodySolver_copyBackToSoftBodies(Native, bMove);
		}
		/*
		public void Optimize(AlignedObjectArray softBodies, bool forceUpdate = false)
		{
			btSoftBodySolver_optimize(Native, softBodies._native, forceUpdate);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictMotion(float solverdt)
		{
			btSoftBodySolver_predictMotion(Native, solverdt);
		}
		/*
		public void ProcessCollision(SoftBody __unnamed0, CollisionObjectWrapper __unnamed1)
		{
			btSoftBodySolver_processCollision(Native, __unnamed0._native, __unnamed1._native);
		}

		public void ProcessCollision(SoftBody __unnamed0, SoftBody __unnamed1)
		{
			btSoftBodySolver_processCollision2(Native, __unnamed0._native, __unnamed1._native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SolveConstraints(float solverdt)
		{
			btSoftBodySolver_solveConstraints(Native, solverdt);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateSoftBodies()
		{
			btSoftBodySolver_updateSoftBodies(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumberOfPositionIterations
		{
			get => btSoftBodySolver_getNumberOfPositionIterations(Native);
			set => btSoftBodySolver_setNumberOfPositionIterations(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumberOfVelocityIterations
		{
			get => btSoftBodySolver_getNumberOfVelocityIterations(Native);
			set => btSoftBodySolver_setNumberOfVelocityIterations(Native, value);
		}
		/*
		public SolverTypes SolverType
		{
			get { return btSoftBodySolver_getSolverType(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TimeScale => btSoftBodySolver_getTimeScale(Native);

		protected override void Dispose(bool disposing)
		{
			btSoftBodySolver_delete(Native);
		}
	}
	/*
	public class SoftBodySolverOutput : BulletObject
	{
		internal SoftBodySolverOutput(IntPtr native)
		{
			Initialize(native);
		}

		public void CopySoftBodyToVertexBuffer(SoftBody softBody, VertexBufferDescriptor vertexBuffer)
		{
			btSoftBodySolverOutput_copySoftBodyToVertexBuffer(Native, softBody.Native, vertexBuffer.Native);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_native != IntPtr.Zero)
			{
				btSoftBodySolverOutput_delete(Native);
				_native = IntPtr.Zero;
			}
		}

		~SoftBodySolverOutput()
		{
			Dispose(false);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodySolverOutput_copySoftBodyToVertexBuffer(IntPtr obj, IntPtr softBody, IntPtr vertexBuffer);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btSoftBodySolverOutput_delete(IntPtr obj);
	}*/
}
