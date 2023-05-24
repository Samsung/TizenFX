/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Scene3D;

namespace Tizen.NUI.Avatar
{
    /// <summary>
    /// Avatar is a Class to show 3D avatar objects.
    /// It is subclass of Model s.t. we can control Avatar like models animation easly.
    /// For example, 
    /// 
    /// Avatar supports AR Emoji.
    /// TODO : Explain more detail
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Avatar : Model
    {
        /// <summary>
        /// Create an initialized AvatarModel.
        /// </summary>
        /// <param name="avatarModelUrl">avatar model file url.(e.g. glTF, and DLI).</param>
        /// <param name="resourceDirectoryUrl"> The url to derectory containing resources: binary, image etc.</param>
        /// <remarks>
        /// If resourceDirectoryUrl is empty, the parent directory url of avatarModelUrl is used for resource url.
        ///
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(string avatarModelUrl, string resourceDirectoryUrl = "") : base(avatarModelUrl, resourceDirectoryUrl)
        {
        }

        /// <summary>
        /// Create an initialized AvatarModel.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar() : base()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="avatarModel">Source object to copy.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Avatar(Avatar avatarModel) : base(avatarModel)
        {
        }

        private static readonly AREmojiDefaultJointNameMapper defaultJointNameMapper = new();
        private static readonly AREmojiDefaultBlendShapeNameMapper defaultBlendShapeNameMapper = new();

        internal AvatarPropertyNameMapper JointMapper { get; set; } = new AvatarPropertyNameMapper(defaultJointNameMapper);
        internal AvatarPropertyNameMapper BlendShapeMapper { get; set; } = new AvatarPropertyNameMapper(defaultBlendShapeNameMapper);
    }
}
