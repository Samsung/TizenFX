using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{


    public class TestUtils
    {

        public static bool CheckColor(Color colorSrc, Color colorDst)
        {
            if (colorSrc.R == colorDst.R && colorSrc.G == colorDst.G && colorSrc.B == colorDst.B && colorSrc.A == colorDst.A)
                return true;

            return false;
        }

        public static bool CheckColor(Vector4 colorSrc, Vector4 colorDst)
        {
            if (colorSrc.X == colorDst.X && colorSrc.Y == colorDst.Y && colorSrc.Z == colorDst.Z && colorSrc.W == colorDst.W)
                return true;

            return false;
        }

    }
}
