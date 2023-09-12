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
	public class SimulationIslandManager : BulletObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class IslandCallback : BulletDisposableObject
		{
			internal IslandCallback(IntPtr native) // public
			{
			}
			/*
			public void ProcessIsland(CollisionObject bodies, int numBodies, PersistentManifold manifolds,
				int numManifolds, int islandId)
			{
				btSimulationIslandManager_IslandCallback_processIsland(Native, bodies.Native,
					numBodies, manifolds.Native, numManifolds, islandId);
			}
			*/
			protected override void Dispose(bool disposing)
			{
				btSimulationIslandManager_IslandCallback_delete(Native);
			}
		}

		internal SimulationIslandManager(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildAndProcessIslands(Dispatcher dispatcher, CollisionWorld collisionWorld,
			IslandCallback callback)
		{
			btSimulationIslandManager_buildAndProcessIslands(Native, dispatcher.Native,
				collisionWorld.Native, callback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildIslands(Dispatcher dispatcher, CollisionWorld colWorld)
		{
			btSimulationIslandManager_buildIslands(Native, dispatcher.Native, colWorld.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FindUnions(Dispatcher dispatcher, CollisionWorld colWorld)
		{
			btSimulationIslandManager_findUnions(Native, dispatcher.Native, colWorld.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InitUnionFind(int n)
		{
			btSimulationIslandManager_initUnionFind(Native, n);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void StoreIslandActivationState(CollisionWorld world)
		{
			btSimulationIslandManager_storeIslandActivationState(Native, world.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateActivationState(CollisionWorld colWorld, Dispatcher dispatcher)
		{
			btSimulationIslandManager_updateActivationState(Native, colWorld.Native,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SplitIslands
		{
			get => btSimulationIslandManager_getSplitIslands(Native);
			set => btSimulationIslandManager_setSplitIslands(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnionFind UnionFind => new UnionFind(btSimulationIslandManager_getUnionFind(Native));
	}
}
