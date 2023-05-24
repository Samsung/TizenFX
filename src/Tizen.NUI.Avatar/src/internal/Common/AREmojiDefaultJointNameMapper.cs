using System.Collections.Generic;
namespace Tizen.NUI.Avatar
{
    internal class AREmojiDefaultJointNameMapper : AvatarPropertyNameMapper
    {
        public AREmojiDefaultJointNameMapper() : base()
        {
            customIndexCounter = (uint)arEmojiJointNameList.Count;
            foreach (var indexNamePair in arEmojiJointNameList)
            {
                base.SetPropertyName((uint)indexNamePair.Item1, indexNamePair.Item2);
            }
        }

        #region AR Emoji Joint name list
        private static readonly List<(JointType, string)> arEmojiJointNameList = new()
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
    }
}