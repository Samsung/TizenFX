/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using System.Collections.Generic;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// Represents properties specific to an Emoji avatar, including mappings for joints, blend shapes, and nodes.
    /// </summary>
    internal class EmojiAvatarProperties : AvatarProperties
    {
        private static AvatarPropertyMapper defaultJointMapper = new AvatarPropertyMapper();
        private static AvatarPropertyMapper defaultBlendShapeNameMapper = new AvatarPropertyMapper();
        private static AvatarPropertyMapper defaultNodeMapper = new AvatarPropertyMapper();

        /// <summary>
        /// Initializes a new instance of the EmojiAvatarProperties class using default mappers for joints, blend shapes, and nodes.
        /// </summary>
        public EmojiAvatarProperties() : base(defaultJointMapper, defaultBlendShapeNameMapper, defaultNodeMapper)
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (var indexNamePair in blendShapeList)
            {
                BlendShapeMapper.SetPropertyName((uint)indexNamePair.Item1, indexNamePair.Item2);
            }

            foreach (var indexNamePair in jointList)
            {
                JointMapper.SetPropertyName((uint)indexNamePair.Item1, indexNamePair.Item2);
            }

            foreach (var indexNamePair in nodeList)
            {
                NodeMapper.SetPropertyName((uint)indexNamePair.Item1, indexNamePair.Item2);
            }

        }

        /// <summary>
        /// Reinitializes the property mappings for joints and nodes.
        /// </summary>
        public void Reinitialize()
        {
            BlendShapeMapper.Clear();
            JointMapper.Clear();
            NodeMapper.Clear();
            Initialize();
        }

        /// <summary>
        /// Updates a blend shape mapping.
        /// </summary>
        /// <param name="key">The blend shape type identifier.</param>
        /// <param name="value">The blend shape name.</param>
        public void UpdateBlendShapeMapping(BlendShapeType key, string value)
        {
            var existingIndex = blendShapeList.FindIndex(item => item.Item1 == key);
            if (existingIndex >= 0)
            {
                blendShapeList[existingIndex] = (key, value);
            }
            else
            {
                throw new KeyNotFoundException("Blend shape type identifier not found.");
            }
        }

        /// <summary>
        /// Updates a joint mapping.
        /// </summary>
        /// <param name="key">The joint type identifier.</param>
        /// <param name="value">The joint name.</param>
        public void UpdateJointMapping(JointType key, string value)
        {
            var existingIndex = jointList.FindIndex(item => item.Item1 == key);
            if (existingIndex >= 0)
            {
                jointList[existingIndex] = (key, value);
            }
            else
            {
                throw new KeyNotFoundException("Joint type identifier not found.");
            }
        }

        /// <summary>
        /// Updates a node mapping.
        /// </summary>
        /// <param name="key">The node type identifier.</param>
        /// <param name="value">The node name.</param>
        public void UpdateNodeMapping(NodeType key, string value)
        {
            var existingIndex = nodeList.FindIndex(item => item.Item1 == key);
            if (existingIndex >= 0)
            {
                nodeList[existingIndex] = (key, value);
            }
            else
            {
                throw new KeyNotFoundException("Node type identifier not found.");
            }
        }


        #region AR Emoji BlendShape name list
        private List<(BlendShapeType, string)> blendShapeList = new List<(BlendShapeType, string)>()
        {
            (BlendShapeType.EyeBlinkLeft, "EyeBlink_Left"),
            (BlendShapeType.EyeSquintLeft, "EyeSquint_Left"),
            (BlendShapeType.EyeDownLeft, "EyeDown_Left"),
            (BlendShapeType.EyeInLeft, "EyeIn_Left"),
            (BlendShapeType.EyeOpenLeft, "EyeOpen_Left"),
            (BlendShapeType.EyeOutLeft, "EyeOut_Left"),
            (BlendShapeType.EyeUpLeft, "EyeUp_Left"),

            (BlendShapeType.EyeBlinkRight, "EyeBlink_Right"),
            (BlendShapeType.EyeSquintRight, "EyeSquint_Right"),
            (BlendShapeType.EyeDownRight, "EyeDown_Right"),
            (BlendShapeType.EyeInRight, "EyeIn_Right"),
            (BlendShapeType.EyeOpenRight, "EyeOpen_Right"),
            (BlendShapeType.EyeOutRight, "EyeOut_Right"),
            (BlendShapeType.EyeUpRight, "EyeUp_Right"),

            (BlendShapeType.JawForward, "JawFwd"),
            (BlendShapeType.JawOpen, "JawOpen"),
            (BlendShapeType.JawChew, "JawChew"),
            (BlendShapeType.JawLeft, "JawLeft"),
            (BlendShapeType.JawRight, "JawRight"),

            (BlendShapeType.MouthLeft, "MouthLeft"),
            (BlendShapeType.MouthFrownLeft, "MouthFrown_Left"),
            (BlendShapeType.MouthSmileLeft, "MouthSmile_Left"),
            (BlendShapeType.MouthDimpleLeft, "MouthDimple_Left"),

            (BlendShapeType.MouthRight, "MouthRight"),
            (BlendShapeType.MouthFrownRight, "MouthFrown_Right"),
            (BlendShapeType.MouthSmileRight, "MouthSmile_Right"),
            (BlendShapeType.MouthDimpleRight, "MouthDimple_Right"),

            (BlendShapeType.LipsStretchLeft, "LipsStretch_Left"),
            (BlendShapeType.LipsStretchRight, "LipsStretch_Right"),
            (BlendShapeType.LipsUpperClose, "LipsUpperClose"),
            (BlendShapeType.LipsLowerClose, "LipsLowerClose"),
            (BlendShapeType.LipsUpperUp, "LipsUpperUp"),
            (BlendShapeType.LipsLowerDown, "LipsLowerDown"),
            (BlendShapeType.LipsUpperOpen, "LipsUpperOpen"),
            (BlendShapeType.LipsLowerOpen, "LipsLowerOpen"),
            (BlendShapeType.LipsFunnel, "LipsFunnel"),
            (BlendShapeType.LipsPucker, "LipsPucker"),

            (BlendShapeType.BrowDownLeft, "BrowsDown_Left"),
            (BlendShapeType.BrowDownRight, "BrowsDown_Right"),
            (BlendShapeType.BrowUpCenter, "BrowsUp_Center"),
            (BlendShapeType.BrowUpLeft, "BrowsUp_Left"),
            (BlendShapeType.BrowUpRight, "BrowsUp_Right"),
            (BlendShapeType.CheekSquintLeft, "CheekSquint_Left"),
            (BlendShapeType.CheekSquintRight, "CheekSquint_Right"),
            (BlendShapeType.ChinLowerRaise, "ChinLowerRaise"),
            (BlendShapeType.ChinUpperRaise, "ChinUpperRaise"),

            (BlendShapeType.TongueOut, "Tongue_Out"),
            (BlendShapeType.TongueUp, "Tongue_Up"),
            (BlendShapeType.TongueDown, "Tongue_Down"),
            (BlendShapeType.TongueLeft, "Tongue_Left"),
            (BlendShapeType.TongueRight, "Tongue_Right"),

            (BlendShapeType.Sneer, "Sneer"),
            (BlendShapeType.Puff, "Puff"),
            (BlendShapeType.PuffLeft, "Puff_Left"),
            (BlendShapeType.PuffRight, "Puff_Right"),
        };
        #endregion

        #region AR Emoji Joint name list
        private List<(JointType, string)> jointList = new List<(JointType, string)>
        {
            (JointType.Head, "head_JNT"),
            (JointType.Neck, "neck_JNT"),
            (JointType.EyeLeft, "l_eye_JNT"),
            (JointType.EyeRight, "r_eye_JNT"),

            (JointType.ShoulderLeft, "l_arm_JNT"),
            (JointType.ElbowLeft, "l_forearm_JNT"),
            (JointType.WristLeft, "l_hand_JNT"),

            (JointType.ShoulderRight, "r_arm_JNT"),
            (JointType.ElbowRight, "r_forearm_JNT"),
            (JointType.WristRight, "r_hand_JNT"),

            (JointType.HipLeft, "l_upleg_JNT"),
            (JointType.KneeLeft, "l_leg_JNT"),
            (JointType.AnkleLeft, "l_foot_JNT"),
            (JointType.ForeFootLeft, "l_toebase_JNT"),

            (JointType.HipRight, "r_upleg_JNT"),
            (JointType.KneeRight, "r_leg_JNT"),
            (JointType.AnkleRight, "r_foot_JNT"),
            (JointType.ForeFootRight, "r_toebase_JNT"),

            (JointType.FingerThumb1Left, "l_handThumb1_JNT"),
            (JointType.FingerThumb2Left, "l_handThumb2_JNT"),
            (JointType.FingerThumb3Left, "l_handThumb3_JNT"),
            (JointType.FingerThumb4Left, "l_handThumb4_JNT"),
            (JointType.FingerIndex1Left, "l_handIndex1_JNT"),
            (JointType.FingerIndex2Left, "l_handIndex2_JNT"),
            (JointType.FingerIndex3Left, "l_handIndex3_JNT"),
            (JointType.FingerIndex4Left, "l_handIndex4_JNT"),
            (JointType.FingerMiddle1Left, "l_handMiddle1_JNT"),
            (JointType.FingerMiddle2Left, "l_handMiddle2_JNT"),
            (JointType.FingerMiddle3Left, "l_handMiddle3_JNT"),
            (JointType.FingerMiddle4Left, "l_handMiddle4_JNT"),
            (JointType.FingerRing1Left, "l_handRing1_JNT"),
            (JointType.FingerRing2Left, "l_handRing2_JNT"),
            (JointType.FingerRing3Left, "l_handRing3_JNT"),
            (JointType.FingerRing4Left, "l_handRing4_JNT"),
            (JointType.FingerPinky1Left, "l_handPinky1_JNT"),
            (JointType.FingerPinky2Left, "l_handPinky2_JNT"),
            (JointType.FingerPinky3Left, "l_handPinky3_JNT"),
            (JointType.FingerPinky4Left, "l_handPinky4_JNT"),

            (JointType.FingerThumb1Right, "r_handThumb1_JNT"),
            (JointType.FingerThumb2Right, "r_handThumb2_JNT"),
            (JointType.FingerThumb3Right, "r_handThumb3_JNT"),
            (JointType.FingerThumb4Right, "r_handThumb4_JNT"),
            (JointType.FingerIndex1Right, "r_handIndex1_JNT"),
            (JointType.FingerIndex2Right, "r_handIndex2_JNT"),
            (JointType.FingerIndex3Right, "r_handIndex3_JNT"),
            (JointType.FingerIndex4Right, "r_handIndex4_JNT"),
            (JointType.FingerMiddle1Right, "r_handMiddle1_JNT"),
            (JointType.FingerMiddle2Right, "r_handMiddle2_JNT"),
            (JointType.FingerMiddle3Right, "r_handMiddle3_JNT"),
            (JointType.FingerMiddle4Right, "r_handMiddle4_JNT"),
            (JointType.FingerRing1Right, "r_handRing1_JNT"),
            (JointType.FingerRing2Right, "r_handRing2_JNT"),
            (JointType.FingerRing3Right, "r_handRing3_JNT"),
            (JointType.FingerRing4Right, "r_handRing4_JNT"),
            (JointType.FingerPinky1Right, "r_handPinky1_JNT"),
            (JointType.FingerPinky2Right, "r_handPinky2_JNT"),
            (JointType.FingerPinky3Right, "r_handPinky3_JNT"),
            (JointType.FingerPinky4Right, "r_handPinky4_JNT"),
        };
        #endregion

        #region AR Emoji Joint name list
        private List<(NodeType, string)> nodeList = new List<(NodeType, string)>
        {
            (NodeType.HeadGeo, "head_GEO"),
            (NodeType.MouthGeo, "mouth_GEO"),
            (NodeType.EyelashGeo, "eyelash_GEO"),
        };
        #endregion
    }
}
