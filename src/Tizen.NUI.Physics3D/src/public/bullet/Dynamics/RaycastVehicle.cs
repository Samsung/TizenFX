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

#define ROLLING_INFLUENCE_FIX

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace Tizen.NUI.Physics3D.Bullet
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VehicleTuning
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionStiffness;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionCompression;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SuspensionDamping;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionTravelCm;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrictionSlip;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxSuspensionForce;

        public VehicleTuning()
        {
            SuspensionStiffness = 5.88f;
            SuspensionCompression = 0.83f;
            SuspensionDamping = 0.88f;
            MaxSuspensionTravelCm = 500.0f;
            FrictionSlip = 10.5f;
            MaxSuspensionForce = 6000.0f;
        }
    }
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RaycastVehicle : IAction
	{
        WheelInfo[] wheelInfo = new WheelInfo[0];

        global::System.Numerics.Vector3[] forwardWS = new global::System.Numerics.Vector3[0];
        global::System.Numerics.Vector3[] axle = new global::System.Numerics.Vector3[0];
        float[] forwardImpulse = new float[0];
        float[] sideImpulse = new float[0];

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 ChassisWorldTransform
        {
            get
            {
                /*if (RigidBody.MotionState != null)
                {
                    return RigidBody.MotionState.WorldTransform;
                }*/
                return RigidBody.CenterOfMassTransform;
            }
        }

        float currentVehicleSpeedKmHour;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int NumWheels
        {
            get { return wheelInfo.Length; }
        }

        int indexRightAxis = 0;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightAxis
        {
            get { return indexRightAxis; }
        }

        int indexUpAxis = 2;
        int indexForwardAxis = 1;

        RigidBody chassisBody;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RigidBody RigidBody
        {
            get { return chassisBody; }
        }

        IVehicleRaycaster vehicleRaycaster;

        static RigidBody fixedBody;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBrake(float brake, int wheelIndex)
        {
            Debug.Assert((wheelIndex >= 0) && (wheelIndex < NumWheels));
            GetWheelInfo(wheelIndex).Brake = brake;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetSteeringValue(int wheel)
        {
            return GetWheelInfo(wheel).Steering;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSteeringValue(float steering, int wheel)
        {
            Debug.Assert(wheel >= 0 && wheel < NumWheels);

            WheelInfo wheelInfo = GetWheelInfo(wheel);
            wheelInfo.Steering = steering;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCoordinateSystem(int rightIndex, int upIndex, int forwardIndex)
        {
            indexRightAxis = rightIndex;
            indexUpAxis = upIndex;
            indexForwardAxis = forwardIndex;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix4x4 GetWheelTransformWS(int wheelIndex)
        {
            Debug.Assert(wheelIndex < NumWheels);
            return wheelInfo[wheelIndex].WorldTransform;
        }

        static RaycastVehicle()
        {
            using (var ci = new RigidBodyConstructionInfo(0, null, null))
            {
                fixedBody = new RigidBody(ci);
                fixedBody.SetMassProps(0, global::System.Numerics.Vector3.Zero);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RaycastVehicle(VehicleTuning tuning, RigidBody chassis, IVehicleRaycaster raycaster)
        {
            chassisBody = chassis;
            vehicleRaycaster = raycaster;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WheelInfo AddWheel(global::System.Numerics.Vector3 connectionPointCS, global::System.Numerics.Vector3 wheelDirectionCS0, global::System.Numerics.Vector3 wheelAxleCS, float suspensionRestLength, float wheelRadius, VehicleTuning tuning, bool isFrontWheel)
        {
            var ci = new WheelInfoConstructionInfo()
            {
                ChassisConnectionCS = connectionPointCS,
                WheelDirectionCS = wheelDirectionCS0,
                WheelAxleCS = wheelAxleCS,
                SuspensionRestLength = suspensionRestLength,
                WheelRadius = wheelRadius,
                IsFrontWheel = isFrontWheel,
                SuspensionStiffness = tuning.SuspensionStiffness,
                WheelsDampingCompression = tuning.SuspensionCompression,
                WheelsDampingRelaxation = tuning.SuspensionDamping,
                FrictionSlip = tuning.FrictionSlip,
                MaxSuspensionTravelCm = tuning.MaxSuspensionTravelCm,
                MaxSuspensionForce = tuning.MaxSuspensionForce
            };

            Array.Resize(ref wheelInfo, wheelInfo.Length + 1);
            var wheel = new WheelInfo(ci);
            wheelInfo[wheelInfo.Length - 1] = wheel;

            UpdateWheelTransformsWS(wheel, false);
            UpdateWheelTransform(NumWheels - 1, false);
            return wheel;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyEngineForce(float force, int wheel)
        {
            Debug.Assert(wheel >= 0 && wheel < NumWheels);
            WheelInfo wheelInfo = GetWheelInfo(wheel);
            wheelInfo.EngineForce = force;
        }

        float CalcRollingFriction(RigidBody body0, RigidBody body1, global::System.Numerics.Vector3 contactPosWorld, global::System.Numerics.Vector3 frictionDirectionWorld, float maxImpulse)
        {
            float denom0 = body0.ComputeImpulseDenominator(contactPosWorld, frictionDirectionWorld);
            float denom1 = body1.ComputeImpulseDenominator(contactPosWorld, frictionDirectionWorld);
            const float relaxation = 1.0f;
            float jacDiagABInv = relaxation / (denom0 + denom1);

            float j1;

            global::System.Numerics.Vector3 rel_pos1 = contactPosWorld - body0.CenterOfMassPosition;
            global::System.Numerics.Vector3 rel_pos2 = contactPosWorld - body1.CenterOfMassPosition;

            global::System.Numerics.Vector3 vel1 = body0.GetVelocityInLocalPoint(rel_pos1);
            global::System.Numerics.Vector3 vel2 = body1.GetVelocityInLocalPoint(rel_pos2);
            global::System.Numerics.Vector3 vel = vel1 - vel2;

            float vrel = global::System.Numerics.Vector3.Dot(frictionDirectionWorld, vel);

            // calculate j that moves us to zero relative velocity
            j1 = -vrel * jacDiagABInv;
            j1 = global::System.Math.Min(j1, maxImpulse);
            j1 = global::System.Math.Max(j1, -maxImpulse);

            return j1;
        }

        global::System.Numerics.Vector3 blue = new global::System.Numerics.Vector3(0, 0, 1);
        global::System.Numerics.Vector3 magenta = new global::System.Numerics.Vector3(1, 0, 1);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DebugDraw(DebugDraw debugDrawer)
        {
            for (int v = 0; v < NumWheels; v++)
            {
                WheelInfo wheelInfo = GetWheelInfo(v);

                global::System.Numerics.Vector3 wheelColor;
                if (wheelInfo.RaycastInfo.IsInContact)
                {
                    wheelColor = blue;
                }
                else
                {
                    wheelColor = magenta;
                }

                Matrix4x4 transform = wheelInfo.WorldTransform;
                global::System.Numerics.Vector3 wheelPosWS = transform.Translation;

                global::System.Numerics.Vector3 axle = new global::System.Numerics.Vector3(
                    transform.GetComponent(0, RightAxis),
                    transform.GetComponent(1, RightAxis),
                    transform.GetComponent(2, RightAxis));

                global::System.Numerics.Vector3 to1 = wheelPosWS + axle;
                global::System.Numerics.Vector3 to2 = GetWheelInfo(v).RaycastInfo.ContactPointWS;

                //debug wheels (cylinders)
                debugDrawer.DrawLine(ref wheelPosWS, ref to1, ref wheelColor);
                debugDrawer.DrawLine(ref wheelPosWS, ref to2, ref wheelColor);

            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WheelInfo GetWheelInfo(int index)
        {
            Debug.Assert((index >= 0) && (index < NumWheels));

            return wheelInfo[index];
        }

        private float RayCast(WheelInfo wheel)
        {
            UpdateWheelTransformsWS(wheel, false);

            float depth = -1;
            float raylen = wheel.SuspensionRestLength + wheel.WheelsRadius;

            global::System.Numerics.Vector3 rayvector = wheel.RaycastInfo.WheelDirectionWS * raylen;
            global::System.Numerics.Vector3 source = wheel.RaycastInfo.HardPointWS;
            wheel.RaycastInfo.ContactPointWS = source + rayvector;
            global::System.Numerics.Vector3 target = wheel.RaycastInfo.ContactPointWS;

            float param = 0;
            VehicleRaycasterResult rayResults = new VehicleRaycasterResult();

            Debug.Assert(vehicleRaycaster != null);
            object obj = vehicleRaycaster.CastRay(ref source, ref target, rayResults);

            wheel.RaycastInfo.GroundObject = null;

            if (obj != null)
            {
                param = rayResults.DistFraction;
                depth = raylen * rayResults.DistFraction;
                wheel.RaycastInfo.ContactNormalWS = rayResults.HitNormalInWorld;
                wheel.RaycastInfo.IsInContact = true;

                wheel.RaycastInfo.GroundObject = fixedBody; //@todo for driving on dynamic/movable objects!;
                /////wheel.RaycastInfo.GroundObject = object;

                float hitDistance = param * raylen;
                wheel.RaycastInfo.SuspensionLength = hitDistance - wheel.WheelsRadius;
                //clamp on max suspension travel

                float minSuspensionLength = wheel.SuspensionRestLength - wheel.MaxSuspensionTravelCm * 0.01f;
                float maxSuspensionLength = wheel.SuspensionRestLength + wheel.MaxSuspensionTravelCm * 0.01f;
                if (wheel.RaycastInfo.SuspensionLength < minSuspensionLength)
                {
                    wheel.RaycastInfo.SuspensionLength = minSuspensionLength;
                }
                if (wheel.RaycastInfo.SuspensionLength > maxSuspensionLength)
                {
                    wheel.RaycastInfo.SuspensionLength = maxSuspensionLength;
                }

                wheel.RaycastInfo.ContactPointWS = rayResults.HitPointInWorld;

                float denominator = global::System.Numerics.Vector3.Dot(wheel.RaycastInfo.ContactNormalWS, wheel.RaycastInfo.WheelDirectionWS);

                global::System.Numerics.Vector3 chassis_velocity_at_contactPoint;
                global::System.Numerics.Vector3 relpos = wheel.RaycastInfo.ContactPointWS - RigidBody.CenterOfMassPosition;

                chassis_velocity_at_contactPoint = RigidBody.GetVelocityInLocalPoint(relpos);

                float projVel = global::System.Numerics.Vector3.Dot(wheel.RaycastInfo.ContactNormalWS, chassis_velocity_at_contactPoint);

                if (denominator >= -0.1f)
                {
                    wheel.SuspensionRelativeVelocity = 0;
                    wheel.ClippedInvContactDotSuspension = 1.0f / 0.1f;
                }
                else
                {
                    float inv = -1.0f / denominator;
                    wheel.SuspensionRelativeVelocity = projVel * inv;
                    wheel.ClippedInvContactDotSuspension = inv;
                }
            }
            else
            {
                //put wheel info as in rest position
                wheel.RaycastInfo.SuspensionLength = wheel.SuspensionRestLength;
                wheel.SuspensionRelativeVelocity = 0.0f;
                wheel.RaycastInfo.ContactNormalWS = -wheel.RaycastInfo.WheelDirectionWS;
                wheel.ClippedInvContactDotSuspension = 1.0f;
            }

            return depth;
        }

        void ResetSuspension()
        {
	        for (int i = 0; i < NumWheels; i++)
	        {
		        WheelInfo wheel = GetWheelInfo(i);
		        wheel.RaycastInfo.SuspensionLength = wheel.SuspensionRestLength;
		        wheel.SuspensionRelativeVelocity = 0;

		        wheel.RaycastInfo.ContactNormalWS = -wheel.RaycastInfo.WheelDirectionWS;
		        //wheel.ContactFriction = 0;
		        wheel.ClippedInvContactDotSuspension = 1;
	        }
        }

        private void ResolveSingleBilateral(RigidBody body1, global::System.Numerics.Vector3 pos1, RigidBody body2, global::System.Numerics.Vector3 pos2, float distance, global::System.Numerics.Vector3 normal, ref float impulse, float timeStep)
        {
            float normalLenSqr = normal.LengthSquared();
            Debug.Assert(global::System.Math.Abs(normalLenSqr) < 1.1f);
            if (normalLenSqr > 1.1f)
            {
                impulse = 0;
                return;
            }
            global::System.Numerics.Vector3 rel_pos1 = pos1 - body1.CenterOfMassPosition;
            global::System.Numerics.Vector3 rel_pos2 = pos2 - body2.CenterOfMassPosition;

            global::System.Numerics.Vector3 vel1 = body1.GetVelocityInLocalPoint(rel_pos1);
            global::System.Numerics.Vector3 vel2 = body2.GetVelocityInLocalPoint(rel_pos2);
            global::System.Numerics.Vector3 vel = vel1 - vel2;

            Matrix4x4 centerOfMass1 = body1.CenterOfMassTransform;
            Matrix4x4 centerOfMass2 = body2.CenterOfMassTransform;
            Matrix4x4 world2A = Matrix4x4.Transpose(centerOfMass1.GetBasis());
            Matrix4x4 world2B = Matrix4x4.Transpose(centerOfMass2.GetBasis());
            global::System.Numerics.Vector3 m_aJ = global::System.Numerics.Vector3.Transform(global::System.Numerics.Vector3.Cross(rel_pos1, normal), world2A);
            global::System.Numerics.Vector3 m_bJ = global::System.Numerics.Vector3.Transform(global::System.Numerics.Vector3.Cross(rel_pos2, -normal), world2B);
            global::System.Numerics.Vector3 m_0MinvJt = body1.InvInertiaDiagLocal * m_aJ;
            global::System.Numerics.Vector3 m_1MinvJt = body2.InvInertiaDiagLocal * m_bJ;
            float dot0, dot1;
            dot0 = global::System.Numerics.Vector3.Dot(m_0MinvJt, m_aJ);
            dot1 = global::System.Numerics.Vector3.Dot(m_1MinvJt, m_bJ);
            float jacDiagAB = body1.InvMass + dot0 + body2.InvMass + dot1;
            float jacDiagABInv = 1.0f / jacDiagAB;

            float rel_vel;
            rel_vel = global::System.Numerics.Vector3.Dot(normal, vel);

            //todo: move this into proper structure
            const float contactDamping = 0.2f;

#if ONLY_USE_LINEAR_MASS
	        float massTerm = 1.0f / (body1.InvMass + body2.InvMass);
	        impulse = - contactDamping * rel_vel * massTerm;
#else
            float velocityImpulse = -contactDamping * rel_vel * jacDiagABInv;
            impulse = velocityImpulse;
#endif
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateAction(CollisionWorld collisionWorld, float deltaTimeStep)
        {
            UpdateVehicle(deltaTimeStep);
        }

        const float sideFrictionStiffness2 = 1.0f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateFriction(float timeStep)
        {
            //calculate the impulse, so that the wheels don't move sidewards
            int numWheel = NumWheels;
            if (numWheel == 0)
                return;

            Array.Resize(ref forwardWS, numWheel);
            Array.Resize(ref axle, numWheel);
            Array.Resize(ref forwardImpulse, numWheel);
            Array.Resize(ref sideImpulse, numWheel);

            int numWheelsOnGround = 0;

            //collapse all those loops into one!
            for (int i = 0; i < NumWheels; i++)
            {
                RigidBody groundObject = wheelInfo[i].RaycastInfo.GroundObject as RigidBody;
                if (groundObject != null)
                    numWheelsOnGround++;
                sideImpulse[i] = 0;
                forwardImpulse[i] = 0;
            }

            for (int i = 0; i < NumWheels; i++)
            {
                WheelInfo wheel = wheelInfo[i];

                RigidBody groundObject = wheel.RaycastInfo.GroundObject as RigidBody;
                if (groundObject != null)
                {
                    Matrix4x4 wheelTrans = GetWheelTransformWS(i);

                    axle[i] = new global::System.Numerics.Vector3(
                        wheelTrans.GetComponent(0, indexRightAxis),
                        wheelTrans.GetComponent(1, indexRightAxis),
                        wheelTrans.GetComponent(2, indexRightAxis));

                    global::System.Numerics.Vector3 surfNormalWS = wheel.RaycastInfo.ContactNormalWS;
                    float proj;
                    proj = global::System.Numerics.Vector3.Dot(axle[i], surfNormalWS);
                    axle[i] -= surfNormalWS * proj;
                    axle[i] = global::System.Numerics.Vector3.Normalize(axle[i]);

                    forwardWS[i] = global::System.Numerics.Vector3.Cross(surfNormalWS, axle[i]);
                    forwardWS[i] = global::System.Numerics.Vector3.Normalize(forwardWS[i]);

                    ResolveSingleBilateral(chassisBody, wheel.RaycastInfo.ContactPointWS,
                              groundObject, wheel.RaycastInfo.ContactPointWS,
                              0, axle[i], ref sideImpulse[i], timeStep);

                    sideImpulse[i] *= sideFrictionStiffness2;
                }
            }

            const float sideFactor = 1.0f;
            const float fwdFactor = 0.5f;

            bool sliding = false;

            for (int i = 0; i < NumWheels; i++)
            {
                WheelInfo wheel = wheelInfo[i];
                RigidBody groundObject = wheel.RaycastInfo.GroundObject as RigidBody;

                float rollingFriction = 0.0f;

                if (groundObject != null)
                {
                    if (wheel.EngineForce != 0.0f)
                    {
                        rollingFriction = wheel.EngineForce * timeStep;
                    }
                    else
                    {
                        float defaultRollingFrictionImpulse = 0.0f;
                        float maxImpulse = (wheel.Brake != 0) ? wheel.Brake : defaultRollingFrictionImpulse;
                        rollingFriction = CalcRollingFriction(chassisBody, groundObject, wheel.RaycastInfo.ContactPointWS, forwardWS[i], maxImpulse);
                    }
                }

                //switch between active rolling (throttle), braking and non-active rolling friction (no throttle/break)

                forwardImpulse[i] = 0;
                wheelInfo[i].SkidInfo = 1.0f;

                if (groundObject != null)
                {
                    wheelInfo[i].SkidInfo = 1.0f;

                    float maximp = wheel.WheelsSuspensionForce * timeStep * wheel.FrictionSlip;
                    float maximpSide = maximp;

                    float maximpSquared = maximp * maximpSide;


                    forwardImpulse[i] = rollingFriction;//wheel.EngineForce* timeStep;

                    float x = forwardImpulse[i] * fwdFactor;
                    float y = sideImpulse[i] * sideFactor;

                    float impulseSquared = (x * x + y * y);

                    if (impulseSquared > maximpSquared)
                    {
                        sliding = true;

                        float factor = maximp / (float)global::System.Math.Sqrt(impulseSquared);

                        wheelInfo[i].SkidInfo *= factor;
                    }
                }
            }

            if (sliding)
            {
                for (int wheel = 0; wheel < NumWheels; wheel++)
                {
                    if (sideImpulse[wheel] != 0)
                    {
                        if (wheelInfo[wheel].SkidInfo < 1.0f)
                        {
                            forwardImpulse[wheel] *= wheelInfo[wheel].SkidInfo;
                            sideImpulse[wheel] *= wheelInfo[wheel].SkidInfo;
                        }
                    }
                }
            }

            // apply the impulses
            for (int i = 0; i < NumWheels; i++)
            {
                WheelInfo wheel = wheelInfo[i];

                global::System.Numerics.Vector3 rel_pos = wheel.RaycastInfo.ContactPointWS -
                        chassisBody.CenterOfMassPosition;

                if (forwardImpulse[i] != 0)
                {
                    chassisBody.ApplyImpulse(forwardWS[i] * forwardImpulse[i], rel_pos);
                }
                if (sideImpulse[i] != 0)
                {
                    RigidBody groundObject = wheel.RaycastInfo.GroundObject as RigidBody;

                    global::System.Numerics.Vector3 rel_pos2 = wheel.RaycastInfo.ContactPointWS -
                        groundObject.CenterOfMassPosition;


                    global::System.Numerics.Vector3 sideImp = axle[i] * sideImpulse[i];

#if ROLLING_INFLUENCE_FIX // fix. It only worked if car's up was along Y - VT.
                    //Vector4 vChassisWorldUp = RigidBody.CenterOfMassTransform.get_Columns(indexUpAxis);
                    Matrix4x4 centerOfMass = RigidBody.CenterOfMassTransform;
                    global::System.Numerics.Vector3 vChassisWorldUp = new global::System.Numerics.Vector3(
                        centerOfMass.GetComponent(0, indexUpAxis),
                        centerOfMass.GetComponent(1, indexUpAxis),
                        centerOfMass.GetComponent(2, indexUpAxis));
                    float dot = global::System.Numerics.Vector3.Dot(vChassisWorldUp, rel_pos);
                    rel_pos -= vChassisWorldUp * (dot * (1.0f - wheel.RollInfluence));
#else
                    rel_pos[indexUpAxis] *= wheel.RollInfluence;
#endif
                    chassisBody.ApplyImpulse(sideImp, rel_pos);

                    //apply friction impulse on the ground
                    groundObject.ApplyImpulse(-sideImp, rel_pos2);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateSuspension(float step)
        {
            float chassisMass = 1.0f / chassisBody.InvMass;

            for (int w_it = 0; w_it < NumWheels; w_it++)
            {
                WheelInfo wheel_info = wheelInfo[w_it];

                if (wheel_info.RaycastInfo.IsInContact)
                {
                    float force;
                    //	Spring
                    {
                        float susp_length = wheel_info.SuspensionRestLength;
                        float current_length = wheel_info.RaycastInfo.SuspensionLength;

                        float length_diff = (susp_length - current_length);

                        force = wheel_info.SuspensionStiffness
                            * length_diff * wheel_info.ClippedInvContactDotSuspension;
                    }

                    // Damper
                    {
                        float projected_rel_vel = wheel_info.SuspensionRelativeVelocity;
                        {
                            float susp_damping;
                            if (projected_rel_vel < 0.0f)
                            {
                                susp_damping = wheel_info.WheelsDampingCompression;
                            }
                            else
                            {
                                susp_damping = wheel_info.WheelsDampingRelaxation;
                            }
                            force -= susp_damping * projected_rel_vel;
                        }
                    }

                    // RESULT
                    wheel_info.WheelsSuspensionForce = force * chassisMass;
                    if (wheel_info.WheelsSuspensionForce < 0)
                    {
                        wheel_info.WheelsSuspensionForce = 0;
                    }
                }
                else
                {
                    wheel_info.WheelsSuspensionForce = 0;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateVehicle(float step)
        {
            for (int i = 0; i < wheelInfo.Length; i++)
            {
                UpdateWheelTransform(i, false);
            }

            currentVehicleSpeedKmHour = 3.6f * RigidBody.LinearVelocity.Length();

            Matrix4x4 chassisTrans = ChassisWorldTransform;

            global::System.Numerics.Vector3 forwardW = new global::System.Numerics.Vector3(
                chassisTrans.GetComponent(0, indexForwardAxis),
                chassisTrans.GetComponent(1, indexForwardAxis),
                chassisTrans.GetComponent(2, indexForwardAxis));

            if (global::System.Numerics.Vector3.Dot(forwardW, RigidBody.LinearVelocity) < 0)
            {
                currentVehicleSpeedKmHour *= -1.0f;
            }

            // Simulate suspension
            for (int i = 0; i < wheelInfo.Length; i++)
            {
                //float depth = 
                RayCast(wheelInfo[i]);
            }


            UpdateSuspension(step);

            for (int i = 0; i < wheelInfo.Length; i++)
            {
                //apply suspension force
                WheelInfo wheel = wheelInfo[i];

                float suspensionForce = wheel.WheelsSuspensionForce;

                if (suspensionForce > wheel.MaxSuspensionForce)
                {
                    suspensionForce = wheel.MaxSuspensionForce;
                }
                global::System.Numerics.Vector3 impulse = wheel.RaycastInfo.ContactNormalWS * suspensionForce * step;
                global::System.Numerics.Vector3 relpos = wheel.RaycastInfo.ContactPointWS - RigidBody.CenterOfMassPosition;

                RigidBody.ApplyImpulse(impulse, relpos);
            }


            UpdateFriction(step);

            for (int i = 0; i < wheelInfo.Length; i++)
            {
                WheelInfo wheel = wheelInfo[i];
                global::System.Numerics.Vector3 relpos = wheel.RaycastInfo.HardPointWS - RigidBody.CenterOfMassPosition;
                global::System.Numerics.Vector3 vel = RigidBody.GetVelocityInLocalPoint(relpos);

                if (wheel.RaycastInfo.IsInContact)
                {
                    Matrix4x4 chassisWorldTransform = ChassisWorldTransform;

                    global::System.Numerics.Vector3 fwd = new global::System.Numerics.Vector3(
                        chassisWorldTransform.GetComponent(0, indexForwardAxis),
                        chassisWorldTransform.GetComponent(1, indexForwardAxis),
                        chassisWorldTransform.GetComponent(2, indexForwardAxis));

                    float proj = global::System.Numerics.Vector3.Dot(fwd, wheel.RaycastInfo.ContactNormalWS);
                    fwd -= wheel.RaycastInfo.ContactNormalWS * proj;

                    float proj2 = global::System.Numerics.Vector3.Dot(fwd, vel);

                    wheel.DeltaRotation = (proj2 * step) / (wheel.WheelsRadius);
                    wheel.Rotation += wheel.DeltaRotation;
                }
                else
                {
                    wheel.Rotation += wheel.DeltaRotation;
                }

                wheel.DeltaRotation *= 0.99f;//damping of rotation when not in contact
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateWheelTransform(int wheelIndex, bool interpolatedTransform)
        {
            WheelInfo wheel = wheelInfo[wheelIndex];
            UpdateWheelTransformsWS(wheel, interpolatedTransform);
            global::System.Numerics.Vector3 up = -wheel.RaycastInfo.WheelDirectionWS;
            global::System.Numerics.Vector3 right = wheel.RaycastInfo.WheelAxleWS;
            global::System.Numerics.Vector3 fwd = global::System.Numerics.Vector3.Cross(up, right);
            fwd = global::System.Numerics.Vector3.Normalize(fwd);
            //up = global::System.Numerics.Vector3.Cross(right, fwd);
            //up.Normalize();

            //rotate around steering over the wheelAxleWS
            Matrix4x4 steeringMat = Matrix4x4.CreateFromAxisAngle(up, wheel.Steering);
            Matrix4x4 rotatingMat = Matrix4x4.CreateFromAxisAngle(right, -wheel.Rotation);

            Matrix4x4 basis2 = new Matrix4x4();
            basis2.M11 = right.X;
            basis2.M12 = fwd.X;
            basis2.M13 = up.X;
            basis2.M21 = right.Y;
            basis2.M22 = fwd.Y;
            basis2.M23 = up.Y;
            basis2.M31 = right.Z;
            basis2.M32 = fwd.Z;
            basis2.M13 = up.Z;

            Matrix4x4 transform = steeringMat * rotatingMat * basis2;
            transform.Translation = wheel.RaycastInfo.HardPointWS + wheel.RaycastInfo.WheelDirectionWS * wheel.RaycastInfo.SuspensionLength;
            wheel.WorldTransform = transform;
        }

        void UpdateWheelTransformsWS(WheelInfo wheel, bool interpolatedTransform)
        {
            wheel.RaycastInfo.IsInContact = false;

            Matrix4x4 chassisTrans = ChassisWorldTransform;
            if (interpolatedTransform && RigidBody.MotionState != null)
            {
                chassisTrans = RigidBody.MotionState.WorldTransform;
            }

            wheel.RaycastInfo.HardPointWS = global::System.Numerics.Vector3.Transform(wheel.ChassisConnectionPointCS, chassisTrans);
            Matrix4x4 chassisTransBasis = chassisTrans.GetBasis();
            wheel.RaycastInfo.WheelDirectionWS = global::System.Numerics.Vector3.Transform(wheel.WheelDirectionCS, chassisTransBasis);
            wheel.RaycastInfo.WheelAxleWS = global::System.Numerics.Vector3.Transform(wheel.WheelAxleCS, chassisTransBasis);
        }
	}

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultVehicleRaycaster : IVehicleRaycaster
    {
        private DynamicsWorld _dynamicsWorld;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultVehicleRaycaster(DynamicsWorld world)
        {
            _dynamicsWorld = world;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public object CastRay(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, VehicleRaycasterResult result)
        {
            //	RayResultCallback& resultCallback;
            using (var rayCallback = new ClosestRayResultCallback(ref from, ref to))
            {
                _dynamicsWorld.RayTestRef(ref from, ref to, rayCallback);

                if (rayCallback.HasHit)
                {
                    var body = RigidBody.Upcast(rayCallback.CollisionObject);
                    if (body != null && body.HasContactResponse)
                    {
                        result.HitPointInWorld = rayCallback.HitPointWorld;
                        global::System.Numerics.Vector3 hitNormalInWorld = rayCallback.HitNormalWorld;
                        hitNormalInWorld = global::System.Numerics.Vector3.Normalize(hitNormalInWorld);
                        result.HitNormalInWorld = hitNormalInWorld;
                        result.DistFraction = rayCallback.ClosestHitFraction;
                        return body;
                    }
                }
            }
            return null;
        }
    }
}
