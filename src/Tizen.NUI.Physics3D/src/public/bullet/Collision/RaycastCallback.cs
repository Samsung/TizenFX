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

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class TriangleRaycastCallback : TriangleCallback
	{
		[Flags]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum EFlags
		{
			None = 0,
            FilterBackfaces = 1,
            KeepUnflippedNormal = 2,
            UseSubSimplexConvexCastRaytest = 4,
            UseGjkConvexCastRaytest = 8,
            DisableHeightfieldAccelerator = 16,
            Terminator = -1
		}

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriangleRaycastCallback(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, EFlags flags)
        {
            HitFraction = 1.0f;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriangleRaycastCallback(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to)
            : this(ref from, ref to, EFlags.None)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ProcessTriangle(ref global::System.Numerics.Vector3 point0, ref global::System.Numerics.Vector3 point1, ref global::System.Numerics.Vector3 point2, int partId, int triangleIndex)
        {
            global::System.Numerics.Vector3 v10 = point1 - point0;
            global::System.Numerics.Vector3 v20 = point2 - point0;

            global::System.Numerics.Vector3 triangleNormal = global::System.Numerics.Vector3.Cross(v10, v20);

            float dist = global::System.Numerics.Vector3.Dot(point0, triangleNormal);
            float distA = global::System.Numerics.Vector3.Dot(triangleNormal, From) - dist;
            float distB = global::System.Numerics.Vector3.Dot(triangleNormal, To) - dist;

            if (distA * distB >= 0.0f)
            {
                return; // same sign
            }

            if (((Flags & EFlags.FilterBackfaces) != 0) && (distA <= 0.0f))
            {
                // Backface, skip check
                return;
            }


            float proj_length = distA - distB;
            float distance = (distA) / (proj_length);
            // Now we have the intersection point on the plane, we'll see if it's inside the triangle
            // Add an epsilon as a tolerance for the raycast,
            // in case the ray hits exacly on the edge of the triangle.
            // It must be scaled for the triangle size.

            if (distance < HitFraction)
            {
                float edgeTolerance = triangleNormal.LengthSquared();
                edgeTolerance *= -0.0001f;
                global::System.Numerics.Vector3 point = global::System.Numerics.Vector3.Lerp(From, To, distance);
                {
                    global::System.Numerics.Vector3 v0p = point0 - point;
                    global::System.Numerics.Vector3 v1p = point1 - point;
                    global::System.Numerics.Vector3 cp0 = global::System.Numerics.Vector3.Cross(v0p, v1p);

                    float dot = global::System.Numerics.Vector3.Dot(cp0, triangleNormal);
                    if (dot >= edgeTolerance)
                    {
                        global::System.Numerics.Vector3 v2p; v2p = point2 - point;
                        global::System.Numerics.Vector3 cp1 = global::System.Numerics.Vector3.Cross(v1p, v2p);
                        dot = global::System.Numerics.Vector3.Dot(cp1, triangleNormal);
                        if (dot >= edgeTolerance)
                        {
                            global::System.Numerics.Vector3 cp2 = global::System.Numerics.Vector3.Cross(v2p, v0p);

                            dot = global::System.Numerics.Vector3.Dot(cp2, triangleNormal);
                            if (dot >= edgeTolerance)
                            {
                                //@BP Mod
                                // Triangle normal isn't normalized
                                triangleNormal = global::System.Numerics.Vector3.Normalize(triangleNormal);

                                //@BP Mod - Allow for unflipped normal when raycasting against backfaces
                                if (((Flags & EFlags.KeepUnflippedNormal) == 0) && (distA <= 0.0f))
                                {
                                    triangleNormal = -triangleNormal;
                                }
                                HitFraction = ReportHit(ref triangleNormal, distance, partId, triangleIndex);
                            }
                        }
                    }
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float ReportHit(ref global::System.Numerics.Vector3 hitNormalLocal, float hitFraction, int partId, int triangleIndex);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public EFlags Flags { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 From { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float HitFraction { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 To { get; set; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class TriangleConvexcastCallback : TriangleCallback
	{
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriangleConvexcastCallback(ConvexShape convexShape, ref Matrix4x4 convexShapeFrom, ref Matrix4x4 convexShapeTo, ref Matrix4x4 triangleToWorld, float triangleCollisionMargin)
        {
            ConvexShape = convexShape;
            ConvexShapeFrom = convexShapeFrom;
            ConvexShapeTo = convexShapeTo;
            TriangleToWorld = triangleToWorld;
            TriangleCollisionMargin = triangleCollisionMargin;

            AllowedPenetration = 0.0f;
            HitFraction = 1.0f;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ProcessTriangle(ref global::System.Numerics.Vector3 point0, ref global::System.Numerics.Vector3 point1, ref global::System.Numerics.Vector3 point2, int partId, int triangleIndex)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float ReportHit(ref global::System.Numerics.Vector3 hitNormalLocal, ref global::System.Numerics.Vector3 hitPointLocal, float hitFraction, int partId, int triangleIndex);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float AllowedPenetration { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConvexShape ConvexShape { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 ConvexShapeFrom { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 ConvexShapeTo { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float HitFraction { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TriangleCollisionMargin { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 TriangleToWorld { get; set; }
	}
}
