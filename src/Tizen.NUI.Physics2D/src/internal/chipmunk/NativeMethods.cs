/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

// ReSharper disable IdentifierTypo
using System;
using System.Runtime.InteropServices;
using System.Security;
using cpArbiter = System.IntPtr;
using cpBitmask = System.UInt32;
using cpBody = System.IntPtr;
using cpBodyArbiterIteratorFunc = System.IntPtr;
using cpBodyConstraintIteratorFunc = System.IntPtr;
using cpBodyPositionFunc = System.IntPtr;
using cpBodyShapeIteratorFunc = System.IntPtr;
using cpBodyType = System.Int32;
using cpBodyVelocityFunc = System.IntPtr;
using cpBool = System.Byte;
using cpCollisionHandlerPointer = System.IntPtr;
using cpCollisionType = System.UIntPtr;
using cpConstraint = System.IntPtr;
using cpConstraintPostSolveFunc = System.IntPtr;
using cpConstraintPreSolveFunc = System.IntPtr;
using cpDampedRotarySpringTorqueFunc = System.IntPtr;
using cpDampedSpringForceFunc = System.IntPtr;
using cpDataPointer = System.IntPtr;
using cpFloat = System.Double;
using cpGroup = System.UIntPtr;
using cpMarchSampleFunc = System.IntPtr;
using cpMarchSegmentFunc = System.IntPtr;
using cpPolyline = System.IntPtr;
using cpPolylineSet = System.IntPtr;
using cpPostStepFunc = System.IntPtr;
using cpShape = System.IntPtr;
using cpSpace = System.IntPtr;
using cpSpaceBBQueryFunc = System.IntPtr;
using cpSpaceBodyIteratorFunc = System.IntPtr;
using cpSpaceConstraintIteratorFunc = System.IntPtr;
using cpSpaceDebugDrawOptionsPointer = System.IntPtr;
using cpSpaceHash = System.IntPtr;
using cpSpacePointQueryFunc = System.IntPtr;
using cpSpaceSegmentQueryFunc = System.IntPtr;
using cpSpaceShapeIteratorFunc = System.IntPtr;
using cpSpaceShapeQueryFunc = System.IntPtr;
using cpSpatialIndex = System.IntPtr;
using cpSpatialIndexBBFunc = System.IntPtr;
using cpSpatialIndexQueryFunc = System.IntPtr;
using cpSweep1D = System.IntPtr;
using cpTimestamp = System.UInt32;
using cpVectPointer = System.IntPtr;
using VoidPointer = System.IntPtr;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {

#pragma warning disable CA1823 // Unused field 'ChipmunkLibraryName'

#if __MACOS__
        private const string ChipmunkLibraryName = "libchipmunk.dylib";
#else
        private const string ChipmunkLibraryName = "libchipmunk.so";
#endif

#pragma warning restore CA1823 // Unused field 'ChipmunkLibraryName'

#pragma warning disable IDE1006 // Naming Styles

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardBeginA(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardBeginB(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardPostSolveA(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardPostSolveB(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpArbiterCallWildcardPreSolveA(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpArbiterCallWildcardPreSolveB(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardSeparateA(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterCallWildcardSeparateB(cpArbiter arb, cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterGetBodies(cpArbiter arb, out cpBody a, out cpBody b);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpContactPointSet cpArbiterGetContactPointSet(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpArbiterGetCount(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpArbiterGetDepth(cpArbiter arb, int i);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpArbiterGetFriction(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpArbiterGetNormal(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpArbiterGetPointA(cpArbiter arb, int i);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpArbiterGetPointB(cpArbiter arb, int i);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpArbiterGetRestitution(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterGetShapes(cpArbiter arb, out cpShape a, out cpShape b);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpArbiterGetSurfaceVelocity(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDataPointer cpArbiterGetUserData(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpArbiterIgnore(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpArbiterIsFirstContact(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpArbiterIsRemoval(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterSetContactPointSet(cpArbiter arb, ref cpContactPointSet set);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterSetFriction(cpArbiter arb, cpFloat friction);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterSetRestitution(cpArbiter arb, cpFloat restitution);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterSetSurfaceVelocity(cpArbiter arb, Vect vr);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpArbiterSetUserData(cpArbiter arb, cpDataPointer userData);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpArbiterTotalImpulse(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpArbiterTotalKE(cpArbiter arb);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpAreaForCircle(cpFloat r1, cpFloat r2);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpAreaForPoly(int count, cpVectPointer verts, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpAreaForSegment(Vect a, Vect b, cpFloat radius);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpBBTree cpBBTreeAlloc();

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpBBTreeInit(cpBBTree tree, cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpBBTreeNew(cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpBBTreeOptimize(cpSpatialIndex index);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpBBTreeSetVelocityFunc(cpSpatialIndex index, cpBBTreeVelocityFunc func);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyActivate(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyActivateStatic(cpBody body, cpShape filter);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpBody cpBodyAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyForceAtLocalPoint(cpBody body, Vect force, Vect point);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyForceAtWorldPoint(cpBody body, Vect force, Vect point);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyTorque(cpBody body, cpFloat torque);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyAngularImpulse(cpBody body, cpFloat impulse);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyImpulseAtLocalPoint(cpBody body, Vect impulse, Vect point);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyApplyImpulseAtWorldPoint(cpBody body, Vect impulse, Vect point);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpBodyDestroy(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpBodyContactWith(cpBody bodyA, cpBody bodyB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyEachArbiter(cpBody body, cpBodyArbiterIteratorFunc func, VoidPointer data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyEachConstraint(cpBody body, cpBodyConstraintIteratorFunc func, VoidPointer data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyEachShape(cpBody body, cpBodyShapeIteratorFunc func, VoidPointer data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyFree(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyGetAngle(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyGetAngularVelocity(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetCenterOfGravity(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpBodyGetContactedBodiesCount(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyGetUserDataContactedBodies(cpBody body, IntPtr userDataArray);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBodyPositionFunc cpBodyGetDefaultPositionUpdateFunc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBodyVelocityFunc cpBodyGetDefaultVelocityUpdateFunc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetForce(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyGetMass(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyGetMoment(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetPosition(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetRotation(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpSpace cpBodyGetSpace(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyGetTransform(cpBody body, out Vect pos, out cpFloat angle);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyGetTorque(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBodyType cpBodyGetType(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDataPointer cpBodyGetUserData(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetVelocity(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetVelocityAtLocalPoint(cpBody body, Vect point);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyGetVelocityAtWorldPoint(cpBody body, Vect point);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpBody cpBodyInit(cpBody body, cpFloat mass, cpFloat moment);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpBodyIsSleeping(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpBodyKineticEnergy(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyLocalToWorld(cpBody body, Vect point);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpBodyNew(cpFloat mass, cpFloat moment);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpBodyNewKinematic();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpBodyNewStatic();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetAngle(cpBody body, cpFloat a);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetAngularVelocity(cpBody body, cpFloat angularVelocity);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetCenterOfGravity(cpBody body, Vect cog);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetForce(cpBody body, Vect force);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetMass(cpBody body, cpFloat m);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetMoment(cpBody body, cpFloat i);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetPosition(cpBody body, Vect pos);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetPositionUpdateFunc(cpBody body, cpBodyPositionFunc positionFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetTransform(cpBody body, Vect pos, cpFloat angle);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetTorque(cpBody body, cpFloat torque);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetType(cpBody body, cpBodyType type);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetUserData(cpBody body, cpDataPointer userData);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetVelocity(cpBody body, Vect velocity);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySetVelocityUpdateFunc(cpBody body, cpBodyVelocityFunc velocityFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySleep(cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodySleepWithGroup(cpBody body, cpBody group);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyUpdatePosition(cpBody body, cpFloat dt);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpBodyUpdateVelocity(cpBody body, Vect gravity, cpFloat damping, cpFloat dt);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpBodyWorldToLocal(cpBody body, Vect point);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolyShape cpBoxShapeInit(cpPolyShape poly, cpBody body, cpFloat width, cpFloat height, cpFloat radius);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolyShape cpBoxShapeInit2(cpPolyShape poly, cpBody body, BoundingBox box, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpBoxShapeNew(cpBody body, cpFloat width, cpFloat height, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpBoxShapeNew2(cpBody body, BoundingBox box, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpCentroidForPoly(int count, cpVectPointer verts);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpCircleShape cpCircleShapeAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpCircleShapeGetOffset(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpCircleShapeGetRadius(cpShape shape);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpCircleShape cpCircleShapeInit(cpCircleShape circle, cpBody body, cpFloat radius, Vect offset);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpCircleShapeNew(cpBody body, cpFloat radius, Vect offset);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpCircleShapeSetOffset(cpShape shape, Vect offset);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpCircleShapeSetRadius(cpShape shape, cpFloat radius);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpConstraintDestroy(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintFree(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpConstraintGetBodyA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpConstraintGetBodyB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintGetCollideBodies(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpConstraintGetErrorBias(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpConstraintGetImpulse(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpConstraintGetMaxBias(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpConstraintGetMaxForce(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpConstraintPostSolveFunc cpConstraintGetPostSolveFunc(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpConstraintPreSolveFunc cpConstraintGetPreSolveFunc(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpSpace cpConstraintGetSpace(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDataPointer cpConstraintGetUserData(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsDampedRotarySpring(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsDampedSpring(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsGearJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsGrooveJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsPinJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsPivotJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsRatchetJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsRotaryLimitJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsSimpleMotor(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpConstraintIsSlideJoint(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetCollideBodies(cpConstraint constraint, cpBool collideBodies);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetErrorBias(cpConstraint constraint, cpFloat errorBias);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetMaxBias(cpConstraint constraint, cpFloat maxBias);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetMaxForce(cpConstraint constraint, cpFloat maxForce);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetPostSolveFunc(cpConstraint constraint, cpConstraintPostSolveFunc postSolveFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetPreSolveFunc(cpConstraint constraint, cpConstraintPreSolveFunc preSolveFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpConstraintSetUserData(cpConstraint constraint, cpDataPointer userData);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpConvexHull(int count, cpVectPointer verts, cpVectPointer result, IntPtr first, cpFloat tol);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpDampedRotarySpring cpDampedRotarySpringAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedRotarySpringGetDamping(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedRotarySpringGetRestAngle(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDampedRotarySpringTorqueFunc cpDampedRotarySpringGetSpringTorqueFunc(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedRotarySpringGetStiffness(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpDampedRotarySpring cpDampedRotarySpringInit(cpDampedRotarySpring joint, cpBody a, cpBody b, cpFloat restAngle, cpFloat stiffness, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpDampedRotarySpringNew(cpBody a, cpBody b, cpFloat restAngle, cpFloat stiffness, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedRotarySpringSetDamping(cpConstraint constraint, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedRotarySpringSetRestAngle(cpConstraint constraint, cpFloat restAngle);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedRotarySpringSetSpringTorqueFunc(cpConstraint constraint, cpDampedRotarySpringTorqueFunc springTorqueFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedRotarySpringSetStiffness(cpConstraint constraint, cpFloat stiffness);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpDampedSpring cpDampedSpringAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpDampedSpringGetAnchorA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpDampedSpringGetAnchorB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedSpringGetDamping(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedSpringGetRestLength(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDampedSpringForceFunc cpDampedSpringGetSpringForceFunc(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpDampedSpringGetStiffness(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpDampedSpring cpDampedSpringInit(cpDampedSpring joint, cpBody a, cpBody b, Vect anchorA, Vect anchorB, cpFloat restLength, cpFloat stiffness, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpDampedSpringNew(cpBody a, cpBody b, Vect anchorA, Vect anchorB, cpFloat restLength, cpFloat stiffness, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetAnchorA(cpConstraint constraint, Vect anchorA);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetAnchorB(cpConstraint constraint, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetDamping(cpConstraint constraint, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetRestLength(cpConstraint constraint, cpFloat restLength);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetSpringForceFunc(cpConstraint constraint, cpDampedSpringForceFunc springForceFunc);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpDampedSpringSetStiffness(cpConstraint constraint, cpFloat stiffness);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpGearJoint cpGearJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpGearJointGetPhase(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpGearJointGetRatio(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpGearJoint cpGearJointInit(cpGearJoint joint, cpBody a, cpBody b, cpFloat phase, cpFloat ratio);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpGearJointNew(cpBody a, cpBody b, cpFloat phase, cpFloat ratio);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpGearJointSetPhase(cpConstraint constraint, cpFloat phase);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpGearJointSetRatio(cpConstraint constraint, cpFloat ratio);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpGrooveJoint cpGrooveJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpGrooveJointGetAnchorB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpGrooveJointGetGrooveA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpGrooveJointGetGrooveB(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpGrooveJoint cpGrooveJointInit(cpGrooveJoint joint, cpBody a, cpBody b, Vect groove_a, Vect groove_b, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpGrooveJointNew(cpBody a, cpBody b, Vect groove_a, Vect groove_b, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpGrooveJointSetAnchorB(cpConstraint constraint, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpGrooveJointSetGrooveA(cpConstraint constraint, Vect grooveA);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpGrooveJointSetGrooveB(cpConstraint constraint, Vect grooveB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpHastySpaceFree(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint cpHastySpaceGetThreads(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpSpace cpHastySpaceNew();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpHastySpaceSetThreads(cpSpace space, uint threads);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpHastySpaceStep(cpSpace space, cpFloat dt);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpMarchHard(
          BoundingBox bb, uint x_samples, uint y_samples, cpFloat threshold,
          cpMarchSegmentFunc segment, IntPtr segment_data,
          cpMarchSampleFunc sample, IntPtr sample_data
        );

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpMarchSoft(
          BoundingBox bb, uint x_samples, uint y_samples, cpFloat threshold,
          cpMarchSegmentFunc segment, IntPtr segment_data,
          cpMarchSampleFunc sample, IntPtr sample_data
        );

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpMomentForBox(cpFloat m, cpFloat width, cpFloat height);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpMomentForBox2(cpFloat m, BoundingBox box);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpMomentForCircle(cpFloat m, cpFloat r1, cpFloat r2, Vect offset);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpMomentForPoly(cpFloat m, int count, cpVectPointer verts, Vect offset, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpMomentForSegment(cpFloat m, Vect a, Vect b, cpFloat radius);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPinJoint cpPinJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpPinJointGetAnchorA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpPinJointGetAnchorB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpPinJointGetDist(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPinJoint cpPinJointInit(cpPinJoint joint, cpBody a, cpBody b, Vect anchorA, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpPinJointNew(cpBody a, cpBody b, Vect anchorA, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPinJointSetAnchorA(cpConstraint constraint, Vect anchorA);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPinJointSetAnchorB(cpConstraint constraint, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPinJointSetDist(cpConstraint constraint, cpFloat dist);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPivotJoint cpPivotJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpPivotJointGetAnchorA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpPivotJointGetAnchorB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPivotJoint cpPivotJointInit(cpPivotJoint joint, cpBody a, cpBody b, Vect anchorA, Vect anchorB);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpPivotJointNew(cpBody a, cpBody b, Vect pivot);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpPivotJointNew2(cpBody a, cpBody b, Vect anchorA, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPivotJointSetAnchorA(cpConstraint constraint, Vect anchorA);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPivotJointSetAnchorB(cpConstraint constraint, Vect anchorB);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolyShape cpPolyShapeAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpPolyShapeGetCount(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpPolyShapeGetRadius(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpPolyShapeGetVert(cpShape shape, int index);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolyShape cpPolyShapeInit(cpPolyShape poly, cpBody body, int count, cpVectPointer verts, Transform transform, cpFloat radius);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolyShape cpPolyShapeInitRaw(cpPolyShape poly, cpBody body, int count, cpVectPointer verts, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpPolyShapeNew(cpBody body, int count, cpVectPointer verts, Transform transform, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpPolyShapeNewRaw(cpBody body, int count, cpVectPointer verts, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolyShapeSetRadius(cpShape shape, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolyShapeSetVerts(cpShape shape, int count, cpVectPointer verts, Transform transform);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolyShapeSetVertsRaw(cpShape shape, int count, cpVectPointer verts);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolylineSet cpPolylineConvexDecomposition(cpPolyline line, cpFloat tol);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolylineFree(cpPolyline line);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolyline cpPolylineSimplifyCurves(cpPolyline line, cpFloat tol);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolylineSet cpPolylineSetAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolylineSetCollectSegment(Vect v0, Vect v1, cpPolylineSet lines);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpPolylineSetDestroy(cpPolylineSet set, cpBool freePolylines);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpPolylineSetFree(cpPolylineSet set, cpBool freePolylines);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpPolylineSet cpPolylineSetInit(cpPolylineSet set);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolylineSet cpPolylineSetNew();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolyline cpPolylineSimplifyVertexes(cpPolyline line, cpFloat tol);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpPolyline cpPolylineToConvexHull(cpPolyline line, cpFloat tol);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpRatchetJoint cpRatchetJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpRatchetJointGetAngle(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpRatchetJointGetPhase(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpRatchetJointGetRatchet(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpRatchetJoint cpRatchetJointInit(cpRatchetJoint joint, cpBody a, cpBody b, cpFloat phase, cpFloat ratchet);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpRatchetJointNew(cpBody a, cpBody b, cpFloat phase, cpFloat ratchet);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpRatchetJointSetAngle(cpConstraint constraint, cpFloat angle);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpRatchetJointSetPhase(cpConstraint constraint, cpFloat phase);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpRatchetJointSetRatchet(cpConstraint constraint, cpFloat ratchet);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpRotaryLimitJoint cpRotaryLimitJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpRotaryLimitJointGetMax(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpRotaryLimitJointGetMin(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpRotaryLimitJoint cpRotaryLimitJointInit(cpRotaryLimitJoint joint, cpBody a, cpBody b, cpFloat min, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpRotaryLimitJointNew(cpBody a, cpBody b, cpFloat min, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpRotaryLimitJointSetMax(cpConstraint constraint, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpRotaryLimitJointSetMin(cpConstraint constraint, cpFloat min);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSegmentShape cpSegmentShapeAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSegmentShapeGetA(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSegmentShapeGetB(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSegmentShapeGetNormal(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSegmentShapeGetRadius(cpShape shape);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSegmentShape cpSegmentShapeInit(cpSegmentShape seg, cpBody body, Vect a, Vect b, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpSegmentShapeNew(cpBody body, Vect a, Vect b, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSegmentShapeSetEndpoints(cpShape shape, Vect a, Vect b);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSegmentShapeSetNeighbors(cpShape shape, Vect prev, Vect next);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSegmentShapeSetRadius(cpShape shape, cpFloat radius);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BoundingBox cpShapeCacheBB(cpShape shape);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpShapeDestroy(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeFree(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetArea(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BoundingBox cpShapeGetBB(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpShapeGetBody(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpShapeGetCenterOfGravity(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpCollisionType cpShapeGetCollisionType(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetDensity(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetElasticity(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetFriction(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetMass(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapeGetMoment(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpShapeGetSensor(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpSpace cpShapeGetSpace(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpShapeGetSurfaceVelocity(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDataPointer cpShapeGetUserData(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ShapeFilter cpShapeGetFilter(cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpShapePointQuery(cpShape shape, Vect p, ref cpPointQueryInfo output);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpShapeSegmentQuery(cpShape shape, Vect a, Vect b, cpFloat radius, ref cpSegmentQueryInfo info);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetBody(cpShape shape, cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetCollisionType(cpShape shape, cpCollisionType collisionType);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetDensity(cpShape shape, cpFloat density);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetElasticity(cpShape shape, cpFloat elasticity);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetFriction(cpShape shape, cpFloat friction);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetMass(cpShape shape, cpFloat mass);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetSensor(cpShape shape, cpBool sensor);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetSurfaceVelocity(cpShape shape, Vect surfaceVelocity);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpShapeSetUserData(cpShape shape, cpDataPointer userData);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpShapeSetFilter(cpShape shape, ShapeFilter filter);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BoundingBox cpShapeUpdate(cpShape shape, Transform transform);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpContactPointSet cpShapesCollide(cpShape a, cpShape b);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSimpleMotor cpSimpleMotorAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSimpleMotorGetRate(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSimpleMotor cpSimpleMotorInit(cpSimpleMotor joint, cpBody a, cpBody b, cpFloat rate);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpSimpleMotorNew(cpBody a, cpBody b, cpFloat rate);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSimpleMotorSetRate(cpConstraint constraint, cpFloat rate);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSlideJoint cpSlideJointAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSlideJointGetAnchorA(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSlideJointGetAnchorB(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSlideJointGetMax(cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSlideJointGetMin(cpConstraint constraint);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSlideJoint cpSlideJointInit(cpSlideJoint joint, cpBody a, cpBody b, Vect anchorA, Vect anchorB, cpFloat min, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpSlideJointNew(cpBody a, cpBody b, Vect anchorA, Vect anchorB, cpFloat min, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSlideJointSetAnchorA(cpConstraint constraint, Vect anchorA);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSlideJointSetAnchorB(cpConstraint constraint, Vect anchorB);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSlideJointSetMax(cpConstraint constraint, cpFloat max);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSlideJointSetMin(cpConstraint constraint, cpFloat min);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpSpaceAddBody(cpSpace space, cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpCollisionHandlerPointer cpSpaceAddCollisionHandler(cpSpace space, cpCollisionType a, cpCollisionType b);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpConstraint cpSpaceAddConstraint(cpSpace space, cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpCollisionHandlerPointer cpSpaceAddDefaultCollisionHandler(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceAddPostStepCallback(cpSpace space, cpPostStepFunc func, IntPtr key, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpSpaceAddShape(cpSpace space, cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpCollisionHandlerPointer cpSpaceAddWildcardHandler(cpSpace space, cpCollisionType type);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpace cpSpaceAlloc();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceBBQuery(cpSpace space, BoundingBox bb, ShapeFilter filter, cpSpaceBBQueryFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceContainsShape(cpSpace space, cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceContainsBody(cpSpace space, cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceContainsConstraint(cpSpace space, cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceDebugDraw(cpSpace space, cpSpaceDebugDrawOptionsPointer options);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpSpaceDestroy(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceEachBody(cpSpace space, cpSpaceBodyIteratorFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceEachConstraint(cpSpace space, cpSpaceConstraintIteratorFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpSpaceGetBodyCount(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceGetBodiesUserDataArray(cpSpace space, IntPtr userDataArray);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpSpaceGetDynamicBodyCount(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceGetDynamicBodiesUserDataArray(cpSpace space, IntPtr userDataArray);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceEachShape(cpSpace space, cpSpaceShapeIteratorFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceFree(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetCollisionBias(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpTimestamp cpSpaceGetCollisionPersistence(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetCollisionSlop(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetCurrentTimeStep(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetDamping(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Vect cpSpaceGetGravity(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetIdleSpeedThreshold(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cpSpaceGetIterations(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpFloat cpSpaceGetSleepTimeThreshold(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBody cpSpaceGetStaticBody(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpDataPointer cpSpaceGetUserData(cpSpace space);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpaceHash cpSpaceHashAlloc();

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpSpaceHashInit(cpSpaceHash hash, cpFloat celldim, int numcells, cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpSpaceHashNew(cpFloat celldim, int cells, cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpSpaceHashResize(cpSpaceHash hash, cpFloat celldim, int numcells);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpace cpSpaceInit(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceIsLocked(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpSpace cpSpaceNew();

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpacePointQuery(cpSpace space, Vect point, cpFloat maxDistance, ShapeFilter filter, cpSpacePointQueryFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpSpacePointQueryNearest(cpSpace space, Vect point, cpFloat maxDistance, ShapeFilter filter, ref cpPointQueryInfo output);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceReindexShape(cpSpace space, cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceReindexShapesForBody(cpSpace space, cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceReindexStatic(cpSpace space);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceRemoveBody(cpSpace space, cpBody body);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceRemoveConstraint(cpSpace space, cpConstraint constraint);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceRemoveShape(cpSpace space, cpShape shape);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSegmentQuery(cpSpace space, Vect start, Vect end, cpFloat radius, ShapeFilter filter, cpSpaceSegmentQueryFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpShape cpSpaceSegmentQueryFirst(cpSpace space, Vect start, Vect end, cpFloat radius, ShapeFilter filter, ref cpSegmentQueryInfo output);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetCollisionBias(cpSpace space, cpFloat collisionBias);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetCollisionPersistence(cpSpace space, cpTimestamp collisionPersistence);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetCollisionSlop(cpSpace space, cpFloat collisionSlop);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetDamping(cpSpace space, cpFloat damping);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetGravity(cpSpace space, Vect gravity);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetIdleSpeedThreshold(cpSpace space, cpFloat idleSpeedThreshold);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetIterations(cpSpace space, int iterations);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetSleepTimeThreshold(cpSpace space, cpFloat sleepTimeThreshold);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceSetUserData(cpSpace space, cpDataPointer userData);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern cpBool cpSpaceShapeQuery(cpSpace space, cpShape shape, cpSpaceShapeQueryFunc func, IntPtr data);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceStep(cpSpace space, cpFloat dt);

        [DllImport(ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cpSpaceUseSpatialHash(cpSpace space, cpFloat dim, int count);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpSpatialIndexCollideStatic(cpSpatialIndex dynamicIndex, cpSpatialIndex staticIndex, cpSpatialIndexQueryFunc func, IntPtr data);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void cpSpatialIndexFree(cpSpatialIndex index);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSweep1D cpSweep1DAlloc();

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpSweep1DInit(cpSweep1D sweep, cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

        //[DllImport (ChipmunkLibraryName, CallingConvention = CallingConvention.Cdecl)]
        //internal static extern cpSpatialIndex cpSweep1DNew(cpSpatialIndexBBFunc bbfunc, cpSpatialIndex staticIndex);

#pragma warning restore IDE1006 // Naming Styles

    }
}
