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
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class QuantizedBvhNode : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public QuantizedBvhNode()
		{
			IntPtr native = btQuantizedBvhNode_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndex => btQuantizedBvhNode_getEscapeIndex(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndexOrTriangleIndex
		{
			get => btQuantizedBvhNode_getEscapeIndexOrTriangleIndex(Native);
			set => btQuantizedBvhNode_setEscapeIndexOrTriangleIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode => btQuantizedBvhNode_isLeafNode(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PartId => btQuantizedBvhNode_getPartId(Native);
		/*
		public UShortArray QuantizedAabbMax
		{
			get { return btQuantizedBvhNode_getQuantizedAabbMax(Native); }
		}

		public UShortArray QuantizedAabbMin
		{
			get { return btQuantizedBvhNode_getQuantizedAabbMin(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleIndex => btQuantizedBvhNode_getTriangleIndex(Native);

		protected override void Dispose(bool disposing)
		{
			btQuantizedBvhNode_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OptimizedBvhNode : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public OptimizedBvhNode()
		{
			IntPtr native = btOptimizedBvhNode_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AabbMaxOrg
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btOptimizedBvhNode_getAabbMaxOrg(Native, out value);
				return value;
			}
			set => btOptimizedBvhNode_setAabbMaxOrg(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AabbMinOrg
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btOptimizedBvhNode_getAabbMinOrg(Native, out value);
				return value;
			}
			set => btOptimizedBvhNode_setAabbMinOrg(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndex
		{
			get => btOptimizedBvhNode_getEscapeIndex(Native);
			set => btOptimizedBvhNode_setEscapeIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SubPart
		{
			get => btOptimizedBvhNode_getSubPart(Native);
			set => btOptimizedBvhNode_setSubPart(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleIndex
		{
			get => btOptimizedBvhNode_getTriangleIndex(Native);
			set => btOptimizedBvhNode_setTriangleIndex(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btOptimizedBvhNode_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class NodeOverlapCallback : BulletDisposableObject
	{
		internal NodeOverlapCallback(IntPtr native) // public
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessNode(int subPart, int triangleIndex)
		{
			btNodeOverlapCallback_processNode(Native, subPart, triangleIndex);
		}

		protected override void Dispose(bool disposing)
		{
			btNodeOverlapCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class QuantizedBvh : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum TraversalMode
		{
			Stackless,
			StacklessCacheFriendly,
			Recursive
		}

		internal QuantizedBvh(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public QuantizedBvh()
		{
			IntPtr native = btQuantizedBvh_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildInternal()
		{
			btQuantizedBvh_buildInternal(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint CalculateSerializeBufferSize()
		{
			return btQuantizedBvh_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSizeNew()
		{
			return btQuantizedBvh_calculateSerializeBufferSizeNew(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DeSerializeDouble(IntPtr quantizedBvhDoubleData)
		{
			btQuantizedBvh_deSerializeDouble(Native, quantizedBvhDoubleData);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DeSerializeFloat(IntPtr quantizedBvhFloatData)
		{
			btQuantizedBvh_deSerializeFloat(Native, quantizedBvhFloatData);
		}
		/*
		public static QuantizedBvh DeSerializeInPlace(IntPtr alignedDataBuffer, uint dataBufferSize,
			bool swapEndian)
		{
			return btQuantizedBvh_deSerializeInPlace(alignedDataBuffer, dataBufferSize,
				swapEndian);
		}

		public void Quantize(unsigned short out, global::System.Numerics.Vector3 point, int isMax)
		{
			btQuantizedBvh_quantize(Native, out._native, ref point, isMax);
		}

		public void QuantizeWithClamp(unsigned short out, global::System.Numerics.Vector3 point2, int isMax)
		{
			btQuantizedBvh_quantizeWithClamp(Native, out._native, ref point2, isMax);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReportAabbOverlappingNodex(NodeOverlapCallback nodeCallback,
		 	global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btQuantizedBvh_reportAabbOverlappingNodex(Native, nodeCallback.Native,
				ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReportBoxCastOverlappingNodex(NodeOverlapCallback nodeCallback,
		 	global::System.Numerics.Vector3 raySource, global::System.Numerics.Vector3 rayTarget, global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btQuantizedBvh_reportBoxCastOverlappingNodex(Native, nodeCallback.Native,
				ref raySource, ref rayTarget, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReportRayOverlappingNodex(NodeOverlapCallback nodeCallback, global::System.Numerics.Vector3 raySource,
		 	global::System.Numerics.Vector3 rayTarget)
		{
			btQuantizedBvh_reportRayOverlappingNodex(Native, nodeCallback.Native,
				ref raySource, ref rayTarget);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetQuantizationValues(global::System.Numerics.Vector3 bvhAabbMin, global::System.Numerics.Vector3 bvhAabbMax,
			float quantizationMargin = 1.0f)
		{
			btQuantizedBvh_setQuantizationValues(Native, ref bvhAabbMin, ref bvhAabbMax,
				quantizationMargin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetTraversalMode(TraversalMode traversalMode)
		{
			btQuantizedBvh_setTraversalMode(Native, traversalMode);
		}
		/*
		public global::System.Numerics.Vector3 UnQuantize(unsigned short vecIn)
		{
		 	global::System.Numerics.Vector3 value;
			btQuantizedBvh_unQuantize(Native, vecIn._native, out value);
			return value;
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static uint AlignmentSerializationPadding => btQuantizedBvh_getAlignmentSerializationPadding();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsQuantized => btQuantizedBvh_isQuantized(Native);
		/*
		public QuantizedNodeArray LeafNodeArray
		{
			get { return btQuantizedBvh_getLeafNodeArray(Native); }
		}

		public QuantizedNodeArray QuantizedNodeArray
		{
			get { return btQuantizedBvh_getQuantizedNodeArray(Native); }
		}

		public BvhSubtreeInfoArray SubtreeInfoArray
		{
			get { return btQuantizedBvh_getSubtreeInfoArray(Native); }
		}
		*/
		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btQuantizedBvh_delete(Native);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct QuantizedBvhFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData BvhAabbMin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData BvhAabbMax;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData BvhQuantization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CurNodeIndex;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseQuantization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumContiguousLeafNodes;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumQuantizedContiguousNodes;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr ContiguousNodesPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr QuantizedContiguousNodesPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr SubTreeInfoPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TraversalMode;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumSubtreeHeaders;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(QuantizedBvhFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct QuantizedBvhDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData BvhAabbMin;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData BvhAabbMax;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData BvhQuantization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CurNodeIndex;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseQuantization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumContiguousLeafNodes;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumQuantizedContiguousNodes;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr ContiguousNodesPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr QuantizedContiguousNodesPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr SubTreeInfoPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TraversalMode;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumSubtreeHeaders;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(QuantizedBvhDoubleData), fieldName).ToInt32(); }
	}
}
