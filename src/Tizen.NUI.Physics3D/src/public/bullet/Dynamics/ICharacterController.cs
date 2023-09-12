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

using System.Numerics;
using System.ComponentModel;

namespace Tizen.NUI.Physics3D.Bullet
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICharacterController : IAction
    {
        void SetWalkDirection(ref global::System.Numerics.Vector3 walkDirection);
        void SetVelocityForTimeInterval(ref global::System.Numerics.Vector3 velocity, float timeInterval);
        void Reset(CollisionWorld collisionWorld);
        void Warp(ref global::System.Numerics.Vector3 origin);

        void PreStep(CollisionWorld collisionWorld);
        void PlayerStep(CollisionWorld collisionWorld, float deltaTime);
        void Jump();
        void Jump(ref global::System.Numerics.Vector3 dir);

        void SetUpInterpolate(bool value);

        bool OnGround { get; }
        bool CanJump { get; }
    }
}
