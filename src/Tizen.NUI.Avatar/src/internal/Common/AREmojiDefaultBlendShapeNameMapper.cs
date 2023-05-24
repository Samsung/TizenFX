using System.Collections.Generic;
namespace Tizen.NUI.Avatar
{
    internal class AREmojiDefaultBlendShapeNameMapper : AvatarPropertyNameMapper
    {
        public AREmojiDefaultBlendShapeNameMapper() : base()
        {
            customIndexCounter = (uint)arEmojiBlendShapeNameList.Count;
            foreach (var indexNamePair in arEmojiBlendShapeNameList)
            {
                base.SetPropertyName((uint)indexNamePair.Item1, indexNamePair.Item2);
            }
            foreach (var customName in arEmojiCustomBlendShapeNameList)
            {
                // We can ensure that default name list is always unique
                base.SetPropertyName(customIndexCounter++, customName);
            }
        }

        #region AR Emoji BlendShape name list
        private static readonly List<(BlendShapeType, string)> arEmojiBlendShapeNameList = new()
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
        private static readonly List<string> arEmojiCustomBlendShapeNameList = new List<string>
        {
          "HAPPY_48",
          "HAPPY_49",
          "HAPPY_50",
          "HAPPY_51",
          "HAPPY_52",
          "ANGRY_53",
          "ANGRY_54",
          "ANGRY_55",
          "DISGUST_56",
          "DISGUST_57",
          "SAD_58",
          "SURPRISE_59",
          "SURPRISE_60",
        };
        #endregion

    }
}