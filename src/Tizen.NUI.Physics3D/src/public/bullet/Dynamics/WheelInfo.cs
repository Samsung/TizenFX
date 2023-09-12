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
	public struct WheelInfoConstructionInfo
	{
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFrontWheel;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 ChassisConnectionCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrictionSlip;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionForce;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionTravelCm;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionRestLength;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionStiffness;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelAxleCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelDirectionCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelRadius;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsDampingCompression;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsDampingRelaxation;
	}

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct RaycastInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 ContactNormalWS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 ContactPointWS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BulletObject GroundObject;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 HardPointWS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsInContact;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionLength;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelAxleWS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelDirectionWS;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WheelInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WheelInfo(WheelInfoConstructionInfo ci)
        {
            SuspensionRestLength1 = ci.SuspensionRestLength;
            MaxSuspensionTravelCm = ci.MaxSuspensionTravelCm;

            WheelsRadius = ci.WheelRadius;
            SuspensionStiffness = ci.SuspensionStiffness;
            WheelsDampingCompression = ci.WheelsDampingCompression;
            WheelsDampingRelaxation = ci.WheelsDampingRelaxation;
            ChassisConnectionPointCS = ci.ChassisConnectionCS;
            WheelDirectionCS = ci.WheelDirectionCS;
            WheelAxleCS = ci.WheelAxleCS;
            FrictionSlip = ci.FrictionSlip;
            Steering = 0;
            EngineForce = 0;
            Rotation = 0;
            DeltaRotation = 0;
            Brake = 0;
            RollInfluence = 0.1f;
            IsFrontWheel = ci.IsFrontWheel;
            MaxSuspensionForce = ci.MaxSuspensionForce;

            //ClientInfo = IntPtr.Zero;
            //ClippedInvContactDotSuspension = 0;
            WorldTransform = Matrix4x4.Identity;
            //WheelsSuspensionForce = 0;
            //SuspensionRelativeVelocity = 0;
            //SkidInfo = 0;
            RaycastInfo = new RaycastInfo();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateWheel(RigidBody chassis, RaycastInfo raycastInfo)
        {
            if (raycastInfo.IsInContact)
            {
                float project = global::System.Numerics.Vector3.Dot(raycastInfo.ContactNormalWS, raycastInfo.WheelDirectionWS);
                global::System.Numerics.Vector3 chassis_velocity_at_contactPoint;
                global::System.Numerics.Vector3 relpos = raycastInfo.ContactPointWS - chassis.CenterOfMassPosition;
                chassis_velocity_at_contactPoint = chassis.GetVelocityInLocalPoint(relpos);
                float projVel = global::System.Numerics.Vector3.Dot(raycastInfo.ContactNormalWS, chassis_velocity_at_contactPoint);
                if (project >= -0.1f)
                {
                    SuspensionRelativeVelocity = 0;
                    ClippedInvContactDotSuspension = 1.0f / 0.1f;
                }
                else
                {
                    float inv = -1.0f / project;
                    SuspensionRelativeVelocity = projVel * inv;
                    ClippedInvContactDotSuspension = inv;
                }

            }

            else    // Not in contact : position wheel in a nice (rest length) position
            {
                RaycastInfo.SuspensionLength = SuspensionRestLength;
                SuspensionRelativeVelocity = 0;
                RaycastInfo.ContactNormalWS = -raycastInfo.WheelDirectionWS;
                ClippedInvContactDotSuspension = 1.0f;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionRestLength
        {
            get { return SuspensionRestLength1; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFrontWheel;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Brake;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 ChassisConnectionPointCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr ClientInfo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ClippedInvContactDotSuspension;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DeltaRotation;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float EngineForce;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrictionSlip;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionForce;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionTravelCm;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RaycastInfo RaycastInfo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RollInfluence;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Rotation;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SkidInfo;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Steering;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionRelativeVelocity;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionRestLength1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionStiffness;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelAxleCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public global::System.Numerics.Vector3 WheelDirectionCS;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsDampingCompression;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsDampingRelaxation;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsRadius;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WheelsSuspensionForce;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 WorldTransform;
    }
}
