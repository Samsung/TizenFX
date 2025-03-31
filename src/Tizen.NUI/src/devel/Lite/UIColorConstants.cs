/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial struct UIColor
    {
        static internal void Preload()
        {
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// The default color. (This is to distinguish from transparent)
        /// </summary>
        public static readonly UIColor Default = new (-1, -1, -1, -1);

        /// <summary>
        /// The Transparent color. 0x000000 with alpha = 0.0f
        /// </summary>
        public static readonly UIColor Transparent = new (0, 0, 0, 0);

        // Subset of X11 Colors (CSS colors)
        // https://www.w3.org/TR/css-color-3

        /// <summary>
        /// The AliceBlue color. 0xF0F8FF
        /// </summary>
        public static readonly UIColor AliceBlue = new (240.0f / 255.0f, 248.0f / 255.0f, 1, 1);

        /// <summary>
        /// The AntiqueWhite color. 0xFAEBD7
        /// </summary>
        public static readonly UIColor AntiqueWhite = new (250.0f / 255.0f, 235.0f / 255.0f, 215.0f / 255.0f, 1);

        /// <summary>
        /// The Aqua color. 0x00FFFF
        /// </summary>
        public static readonly UIColor Aqua = new (0, 1, 1, 1);

        /// <summary>
        /// The AquaMarine color. 0x7FFFD4
        /// </summary>
        public static readonly UIColor AquaMarine = new (127.0f / 255.0f, 1, 212.0f / 255.0f, 1);

        /// <summary>
        /// The Azure color. 0xF0FFFF
        /// </summary>
        public static readonly UIColor Azure = new (240.0f / 255.0f, 1, 1, 1);

        /// <summary>
        /// The Beige color. 0xF5F5DC
        /// </summary>
        public static readonly UIColor Beige = new (245.0f / 255.0f, 245.0f / 255.0f, 220.0f / 255.0f, 1);

        /// <summary>
        /// The Bisque color. 0xFFE4C4
        /// </summary>
        public static readonly UIColor Bisque = new (1, 228.0f / 255.0f, 196.0f / 255.0f, 1);

        /// <summary>
        /// The Black color. 0x000000
        /// </summary>
        public static readonly UIColor Black = new (0, 0, 0, 1);

        /// <summary>
        /// The BlancheDalmond color. 0xFFEBCD
        /// </summary>
        public static readonly UIColor BlancheDalmond = new (1, 235.0f / 255.0f, 205.0f / 255.0f, 1);

        /// <summary>
        /// The Blue color. 0x0000FF
        /// </summary>
        public static readonly UIColor Blue = new (0, 0, 1, 1);

        /// <summary>
        /// The BlueViolet color. 0x8A2BE2
        /// </summary>
        public static readonly UIColor BlueViolet = new (138.0f / 255.0f, 43.0f / 255.0f, 226.0f / 255.0f, 1);

        /// <summary>
        /// The Brown color. 0xA52A2A
        /// </summary>
        public static readonly UIColor Brown = new (165.0f / 255.0f, 42.0f / 255.0f, 42.0f / 255.0f, 1);

        /// <summary>
        /// The BurlyWood color. 0xDEB887
        /// </summary>
        public static readonly UIColor BurlyWood = new (222.0f / 255.0f, 184.0f / 255.0f, 135.0f / 255.0f, 1);

        /// <summary>
        /// The CadetBlue color. 0x5F9EA0
        /// </summary>
        public static readonly UIColor CadetBlue = new (95.0f / 255.0f, 158.0f / 255.0f, 160.0f / 255.0f, 1);

        /// <summary>
        /// The Chartreuse color. 0x7FFF00
        /// </summary>
        public static readonly UIColor Chartreuse = new (127.0f / 255.0f, 1, 0, 1);

        /// <summary>
        /// The Chocolate color. 0xD2691E
        /// </summary>
        public static readonly UIColor Chocolate = new (210.0f / 255.0f, 105.0f / 255.0f, 30.0f / 255.0f, 1);

        /// <summary>
        /// The Coral color. 0xFF7F50
        /// </summary>
        public static readonly UIColor Coral = new (1, 127.0f / 255.0f, 80.0f / 255.0f, 1);

        /// <summary>
        /// The CornflowerBlue color. 0x6495ED
        /// </summary>
        public static readonly UIColor CornflowerBlue = new (100.0f / 255.0f, 149.0f / 255.0f, 237.0f / 255.0f, 1);

        /// <summary>
        /// The Cornsilk color. 0xFFF8DC
        /// </summary>
        public static readonly UIColor Cornsilk = new (1, 248.0f / 255.0f, 220.0f / 255.0f, 1);

        /// <summary>
        /// The Crimson color. 0xDC143C
        /// </summary>
        public static readonly UIColor Crimson = new (220.0f / 255.0f, 20.0f / 255.0f, 60.0f / 255.0f, 1);

        /// <summary>
        /// The Cyan color. 0x00FFFF
        /// </summary>
        public static readonly UIColor Cyan = new (0, 1, 1, 1);

        /// <summary>
        /// The DarkBlue color. 0x00008B
        /// </summary>
        public static readonly UIColor DarkBlue = new (0, 0, 139.0f / 255.0f, 1);

        /// <summary>
        /// The DarkCyan color. 0x008B8B
        /// </summary>
        public static readonly UIColor DarkCyan = new (0, 139.0f / 255.0f, 139.0f / 255.0f, 1);

        /// <summary>
        /// The DarkGoldenrod color. 0xB8860B
        /// </summary>
        public static readonly UIColor DarkGoldenrod = new (184.0f / 255.0f, 134.0f / 255.0f, 11.0f / 255.0f, 1);

        /// <summary>
        /// The DarkGray color. 0xA9A9A9
        /// </summary>
        public static readonly UIColor DarkGray = new (169.0f / 255.0f, 169.0f / 255.0f, 169.0f / 255.0f, 1);

        /// <summary>
        /// The DarkGreen color. 0x006400
        /// </summary>
        public static readonly UIColor DarkGreen = new (0, 100.0f / 255.0f, 0, 1);

        /// <summary>
        /// The DarkGrey color. 0xA9A9A9
        /// </summary>
        public static readonly UIColor DarkGrey = new (169.0f / 255.0f, 169.0f / 255.0f, 169.0f / 255.0f, 1);

        /// <summary>
        /// The DarkKhaki color. 0xBDB76B
        /// </summary>
        public static readonly UIColor DarkKhaki = new (189.0f / 255.0f, 183.0f / 255.0f, 107.0f / 255.0f, 1);

        /// <summary>
        /// The DarkMagenta color. 0x8B008B
        /// </summary>
        public static readonly UIColor DarkMagenta = new (139.0f / 255.0f, 0, 139.0f / 255.0f, 1);

        /// <summary>
        /// The DarkOliveGreen color. 0x556B2F
        /// </summary>
        public static readonly UIColor DarkOliveGreen = new (85.0f / 255.0f, 107.0f / 255.0f, 47.0f / 255.0f, 1);

        /// <summary>
        /// The DarkOrange color. 0xFF8C00
        /// </summary>
        public static readonly UIColor DarkOrange = new (1, 140.0f / 255.0f, 0, 1);

        /// <summary>
        /// The DarkOrchid color. 0x9932CC
        /// </summary>
        public static readonly UIColor DarkOrchid = new (153.0f / 255.0f, 50.0f / 255.0f, 204.0f / 255.0f, 1);

        /// <summary>
        /// The DarkRed color. 0x8B0000
        /// </summary>
        public static readonly UIColor DarkRed = new (139.0f / 255.0f, 0, 0, 1);

        /// <summary>
        /// The DarkSalmon color. 0xE9967A
        /// </summary>
        public static readonly UIColor DarkSalmon = new (233.0f / 255.0f, 150.0f / 255.0f, 122.0f / 255.0f, 1);

        /// <summary>
        /// The DarkSeaGreen color. 0x8FBC8F
        /// </summary>
        public static readonly UIColor DarkSeaGreen = new (143.0f / 255.0f, 188.0f / 255.0f, 143.0f / 255.0f, 1);

        /// <summary>
        /// The DarkSlateBlue color. 0x483D8B
        /// </summary>
        public static readonly UIColor DarkSlateBlue = new (72.0f / 255.0f, 61.0f / 255.0f, 139.0f / 255.0f, 1);

        /// <summary>
        /// The DarkSlateGray color. 0x2F4F4F
        /// </summary>
        public static readonly UIColor DarkSlateGray = new (47.0f / 255.0f, 79.0f / 255.0f, 79.0f / 255.0f, 1);

        /// <summary>
        /// The DarkSlateGrey color. 0x2F4F4F
        /// </summary>
        public static readonly UIColor DarkSlateGrey = new (47.0f / 255.0f, 79.0f / 255.0f, 79.0f / 255.0f, 1);

        /// <summary>
        /// The DarkTurquoise color. 0x00CED1
        /// </summary>
        public static readonly UIColor DarkTurquoise = new (0, 206.0f / 255.0f, 209.0f / 255.0f, 1);

        /// <summary>
        /// The DarkViolet color. 0x9400D3
        /// </summary>
        public static readonly UIColor DarkViolet = new (148.0f / 255.0f, 0, 211.0f / 255.0f, 1);

        /// <summary>
        /// The DeepPink color. 0xFF1493
        /// </summary>
        public static readonly UIColor DeepPink = new (1, 20.0f / 255.0f, 147.0f / 255.0f, 1);

        /// <summary>
        /// The DeepSkyBlue color. 0x00BFFF
        /// </summary>
        public static readonly UIColor DeepSkyBlue = new (0, 191.0f / 255.0f, 1, 1);

        /// <summary>
        /// The DimGray color. 0x696969
        /// </summary>
        public static readonly UIColor DimGray = new (105.0f / 255.0f, 105.0f / 255.0f, 105.0f / 255.0f, 1);

        /// <summary>
        /// The DimGrey color. 0x696969
        /// </summary>
        public static readonly UIColor DimGrey = new (105.0f / 255.0f, 105.0f / 255.0f, 105.0f / 255.0f, 1);

        /// <summary>
        /// The DodgerBlue color. 0x1E90FF
        /// </summary>
        public static readonly UIColor DodgerBlue = new (30.0f / 255.0f, 144.0f / 255.0f, 1, 1);

        /// <summary>
        /// The FireBrick color. 0xB22222
        /// </summary>
        public static readonly UIColor FireBrick = new (178.0f / 255.0f, 34.0f / 255.0f, 34.0f / 255.0f, 1);

        /// <summary>
        /// The FloralWhite color. 0xFFFAF0
        /// </summary>
        public static readonly UIColor FloralWhite = new (1, 250.0f / 255.0f, 240.0f / 255.0f, 1);

        /// <summary>
        /// The ForestGreen color. 0x228B22
        /// </summary>
        public static readonly UIColor ForestGreen = new (34.0f / 255.0f, 139.0f / 255.0f, 34.0f / 255.0f, 1);

        /// <summary>
        /// The Fuchsia color. 0xFF00FF
        /// </summary>
        public static readonly UIColor Fuchsia = new (1, 0, 1, 1);

        /// <summary>
        /// The Gainsboro color. 0xDCDCDC
        /// </summary>
        public static readonly UIColor Gainsboro = new (220.0f / 255.0f, 220.0f / 255.0f, 220.0f / 255.0f, 1);

        /// <summary>
        /// The GhostWhite color. 0xF8F8FF
        /// </summary>
        public static readonly UIColor GhostWhite = new (248.0f / 255.0f, 248.0f / 255.0f, 1, 1);

        /// <summary>
        /// The Gold color. 0xFFD700
        /// </summary>
        public static readonly UIColor Gold = new (1, 215.0f / 255.0f, 0, 1);

        /// <summary>
        /// The GoldenRod color. 0xDAA520
        /// </summary>
        public static readonly UIColor GoldenRod = new (218.0f / 255.0f, 165.0f / 255.0f, 32.0f / 255.0f, 1);

        /// <summary>
        /// The Gray color. 0xBEBEBE
        /// </summary>
        public static readonly UIColor Gray = new (190.0f / 255.0f, 190.0f / 255.0f, 190.0f / 255.0f, 1);

        /// <summary>
        /// The Green color. 0x00FF00
        /// </summary>
        public static readonly UIColor Green = new (0, 1, 0, 1);

        /// <summary>
        /// The GreenYellow color. 0xADFF2F
        /// </summary>
        public static readonly UIColor GreenYellow = new (173.0f / 255.0f, 1, 47.0f / 255.0f, 1);

        /// <summary>
        /// The Grey color. 0x808080
        /// </summary>
        public static readonly UIColor Grey = new (128.0f / 255.0f, 128.0f / 255.0f, 128.0f / 255.0f, 1);

        /// <summary>
        /// The Honeydew color. 0xF0FFF0
        /// </summary>
        public static readonly UIColor Honeydew = new (240.0f / 255.0f, 1, 240.0f / 255.0f, 1);

        /// <summary>
        /// The HotPink color. 0xFF69B4
        /// </summary>
        public static readonly UIColor HotPink = new (1, 105.0f / 255.0f, 180.0f / 255.0f, 1);

        /// <summary>
        /// The Indianred color. 0xCD5C5C
        /// </summary>
        public static readonly UIColor Indianred = new (205.0f / 255.0f, 92.0f / 255.0f, 92.0f / 255.0f, 1);

        /// <summary>
        /// The Indigo color. 0x4B0082
        /// </summary>
        public static readonly UIColor Indigo = new (75.0f / 255.0f, 0, 130.0f / 255.0f, 1);

        /// <summary>
        /// The Ivory color. 0xFFFFF0
        /// </summary>
        public static readonly UIColor Ivory = new (1, 1, 240.0f / 255.0f, 1);

        /// <summary>
        /// The Khaki color. 0xF0E68C
        /// </summary>
        public static readonly UIColor Khaki = new (240.0f / 255.0f, 230.0f / 255.0f, 140.0f / 255.0f, 1);

        /// <summary>
        /// The Lavender color. 0xE6E6FA
        /// </summary>
        public static readonly UIColor Lavender = new (230.0f / 255.0f, 230.0f / 255.0f, 250.0f / 255.0f, 1);

        /// <summary>
        /// The LavenderBlush color. 0xFFF0F5
        /// </summary>
        public static readonly UIColor LavenderBlush = new (1, 240.0f / 255.0f, 245.0f / 255.0f, 1);

        /// <summary>
        /// The LawnGreen color. 0x7CFC00
        /// </summary>
        public static readonly UIColor LawnGreen = new (124.0f / 255.0f, 252.0f / 255.0f, 0, 1);

        /// <summary>
        /// The LemonChiffon color. 0xFFFACD
        /// </summary>
        public static readonly UIColor LemonChiffon = new (1, 250.0f / 255.0f, 205.0f / 255.0f, 1);

        /// <summary>
        /// The LightBlue color. 0xADD8E6
        /// </summary>
        public static readonly UIColor LightBlue = new (173.0f / 255.0f, 216.0f / 255.0f, 230.0f / 255.0f, 1);

        /// <summary>
        /// The LightCoral color. 0xF08080
        /// </summary>
        public static readonly UIColor LightCoral = new (240.0f / 255.0f, 128.0f / 255.0f, 128.0f / 255.0f, 1);

        /// <summary>
        /// The LightCyan color. 0xE0FFFF
        /// </summary>
        public static readonly UIColor LightCyan = new (224.0f / 255.0f, 1, 1, 1);

        /// <summary>
        /// The LightGoldenRodYellow color. 0xFAFAD2
        /// </summary>
        public static readonly UIColor LightGoldenRodYellow = new (250.0f / 255.0f, 250.0f / 255.0f, 210.0f / 255.0f, 1);

        /// <summary>
        /// The LightGray color. 0xD3D3D3
        /// </summary>
        public static readonly UIColor LightGray = new (211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1);

        /// <summary>
        /// The LightGreen color. 0x90EE90
        /// </summary>
        public static readonly UIColor LightGreen = new (144.0f / 255.0f, 238.0f / 255.0f, 144.0f / 255.0f, 1);

        /// <summary>
        /// The LightGrey color. 0xD3D3D3
        /// </summary>
        public static readonly UIColor LightGrey = new (211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1);

        /// <summary>
        /// The LightPink color. 0xFFB6C1
        /// </summary>
        public static readonly UIColor LightPink = new (1, 182.0f / 255.0f, 193.0f / 255.0f, 1);

        /// <summary>
        /// The LightSalmon color. 0xFFA07A
        /// </summary>
        public static readonly UIColor LightSalmon = new (1, 160.0f / 255.0f, 122.0f / 255.0f, 1);

        /// <summary>
        /// The LightSeaGreen color. 0x20B2AA
        /// </summary>
        public static readonly UIColor LightSeaGreen = new (32.0f / 255.0f, 178.0f / 255.0f, 170.0f / 255.0f, 1);

        /// <summary>
        /// The LightSkyBlue color. 0x87CEFA
        /// </summary>
        public static readonly UIColor LightSkyBlue = new (135.0f / 255.0f, 206.0f / 255.0f, 250.0f / 255.0f, 1);

        /// <summary>
        /// The LightSlateGray color. 0x778899
        /// </summary>
        public static readonly UIColor LightSlateGray = new (119.0f / 255.0f, 136.0f / 255.0f, 153.0f / 255.0f, 1);

        /// <summary>
        /// The LightSlateGrey color. 0x778899
        /// </summary>
        public static readonly UIColor LightSlateGrey = new (119.0f / 255.0f, 136.0f / 255.0f, 153.0f / 255.0f, 1);

        /// <summary>
        /// The LightSteelBlue color. 0xB0C4DE
        /// </summary>
        public static readonly UIColor LightSteelBlue = new (176.0f / 255.0f, 196.0f / 255.0f, 222.0f / 255.0f, 1);

        /// <summary>
        /// The LightYellow color. 0xFFFFE0
        /// </summary>
        public static readonly UIColor LightYellow = new (1, 1, 224.0f / 255.0f, 1);

        /// <summary>
        /// The Lime color. 0x00FF00
        /// </summary>
        public static readonly UIColor Lime = new (0, 1, 0, 1);

        /// <summary>
        /// The LimeGreen color. 0x32CD32
        /// </summary>
        public static readonly UIColor LimeGreen = new (50.0f / 255.0f, 205.0f / 255.0f, 50.0f / 255.0f, 1);

        /// <summary>
        /// The Linen color. 0xFAF0E6
        /// </summary>
        public static readonly UIColor Linen = new (250.0f / 255.0f, 240.0f / 255.0f, 230.0f / 255.0f, 1);

        /// <summary>
        /// The Magenta color. 0xFF00FF
        /// </summary>
        public static readonly UIColor Magenta = new (1, 0, 1, 1);

        /// <summary>
        /// The Maroon color. 0xB03060
        /// </summary>
        public static readonly UIColor Maroon = new (176.0f / 255.0f, 48.0f / 255.0f, 96.0f / 255.0f, 1);

        /// <summary>
        /// The MediumAquaMarine color. 0x66CDAA
        /// </summary>
        public static readonly UIColor MediumAquaMarine = new (102.0f / 255.0f, 205.0f / 255.0f, 170.0f / 255.0f, 1);

        /// <summary>
        /// The MediumBlue color. 0x0000CD
        /// </summary>
        public static readonly UIColor MediumBlue = new (0, 0, 205.0f / 255.0f, 1);

        /// <summary>
        /// The MediumOrchid color. 0xBA55D3
        /// </summary>
        public static readonly UIColor MediumOrchid = new (186.0f / 255.0f, 85.0f / 255.0f, 211.0f / 255.0f, 1);

        /// <summary>
        /// The MediumPurple color. 0x9370DB
        /// </summary>
        public static readonly UIColor MediumPurple = new (147.0f / 255.0f, 112.0f / 255.0f, 219.0f / 255.0f, 1);

        /// <summary>
        /// The MediumSeaGreen color. 0x3CB371
        /// </summary>
        public static readonly UIColor MediumSeaGreen = new (60.0f / 255.0f, 179.0f / 255.0f, 113.0f / 255.0f, 1);

        /// <summary>
        /// The MediumSlateBlue color. 0x7B68EE
        /// </summary>
        public static readonly UIColor MediumSlateBlue = new (123.0f / 255.0f, 104.0f / 255.0f, 238.0f / 255.0f, 1);

        /// <summary>
        /// The MediumSpringGreen color. 0x00FA9A
        /// </summary>
        public static readonly UIColor MediumSpringGreen = new (0, 250.0f / 255.0f, 154.0f / 255.0f, 1);

        /// <summary>
        /// The MediumTurquoise color. 0x48D1CC
        /// </summary>
        public static readonly UIColor MediumTurquoise = new (72.0f / 255.0f, 209.0f / 255.0f, 204.0f / 255.0f, 1);

        /// <summary>
        /// The MediumVioletred color. 0xC71585
        /// </summary>
        public static readonly UIColor MediumVioletred = new (199.0f / 255.0f, 21.0f / 255.0f, 133.0f / 255.0f, 1);

        /// <summary>
        /// The MidnightBlue color. 0x191970
        /// </summary>
        public static readonly UIColor MidnightBlue = new (25.0f / 255.0f, 25.0f / 255.0f, 112.0f / 255.0f, 1);

        /// <summary>
        /// The MintCream color. 0xF5FFFA
        /// </summary>
        public static readonly UIColor MintCream = new (245.0f / 255.0f, 1, 250.0f / 255.0f, 1);

        /// <summary>
        /// The MistyRose color. 0xFFE4E1
        /// </summary>
        public static readonly UIColor MistyRose = new (1, 228.0f / 255.0f, 225.0f / 255.0f, 1);

        /// <summary>
        /// The Moccasin color. 0xFFE4B5
        /// </summary>
        public static readonly UIColor Moccasin = new (1, 228.0f / 255.0f, 181.0f / 255.0f, 1);

        /// <summary>
        /// The NavajoWhite color. 0xFFDEAD
        /// </summary>
        public static readonly UIColor NavajoWhite = new (1, 222.0f / 255.0f, 173.0f / 255.0f, 1);

        /// <summary>
        /// The Navy color. 0x000080
        /// </summary>
        public static readonly UIColor Navy = new (0, 0, 128.0f / 255.0f, 1);

        /// <summary>
        /// The OldLace color. 0xFDF5E6
        /// </summary>
        public static readonly UIColor OldLace = new (253.0f / 255.0f, 245.0f / 255.0f, 230.0f / 255.0f, 1);

        /// <summary>
        /// The Olive color. 0x808000
        /// </summary>
        public static readonly UIColor Olive = new (128.0f / 255.0f, 128.0f / 255.0f, 0, 1);

        /// <summary>
        /// The OliveDrab color. 0x6B8E23
        /// </summary>
        public static readonly UIColor OliveDrab = new (107.0f / 255.0f, 142.0f / 255.0f, 35.0f / 255.0f, 1);

        /// <summary>
        /// The Orange color. 0xFFA500
        /// </summary>
        public static readonly UIColor Orange = new (1, 165.0f / 255.0f, 0, 1);

        /// <summary>
        /// The OrangeRed color. 0xFF4500
        /// </summary>
        public static readonly UIColor OrangeRed = new (1, 69.0f / 255.0f, 0, 1);

        /// <summary>
        /// The Orchid color. 0xDA70D6
        /// </summary>
        public static readonly UIColor Orchid = new (218.0f / 255.0f, 112.0f / 255.0f, 214.0f / 255.0f, 1);

        /// <summary>
        /// The PaleGoldenRod color. 0xEEE8AA
        /// </summary>
        public static readonly UIColor PaleGoldenRod = new (238.0f / 255.0f, 232.0f / 255.0f, 170.0f / 255.0f, 1);

        /// <summary>
        /// The PaleGreen color. 0x98FB98
        /// </summary>
        public static readonly UIColor PaleGreen = new (152.0f / 255.0f, 251.0f / 255.0f, 152.0f / 255.0f, 1);

        /// <summary>
        /// The PaleTurquoise color. 0xAFEEEE
        /// </summary>
        public static readonly UIColor PaleTurquoise = new (175.0f / 255.0f, 238.0f / 255.0f, 238.0f / 255.0f, 1);

        /// <summary>
        /// The PaleVioletRed color. 0xDB7093
        /// </summary>
        public static readonly UIColor PaleVioletRed = new (219.0f / 255.0f, 112.0f / 255.0f, 147.0f / 255.0f, 1);

        /// <summary>
        /// The PapayaWhip color. 0xFFEFD5
        /// </summary>
        public static readonly UIColor PapayaWhip = new (1, 239.0f / 255.0f, 213.0f / 255.0f, 1);

        /// <summary>
        /// The PeachPuff color. 0xFFDAB9
        /// </summary>
        public static readonly UIColor PeachPuff = new (1, 218.0f / 255.0f, 185.0f / 255.0f, 1);

        /// <summary>
        /// The Peru color. 0xCD853F
        /// </summary>
        public static readonly UIColor Peru = new (205.0f / 255.0f, 133.0f / 255.0f, 63.0f / 255.0f, 1);

        /// <summary>
        /// The Pink color. 0xFFC0CB
        /// </summary>
        public static readonly UIColor Pink = new (1, 192.0f / 255.0f, 203.0f / 255.0f, 1);

        /// <summary>
        /// The Plum color. 0xDDA0DD
        /// </summary>
        public static readonly UIColor Plum = new (221.0f / 255.0f, 160.0f / 255.0f, 221.0f / 255.0f, 1);

        /// <summary>
        /// The PowderBlue color. 0xB0E0E6
        /// </summary>
        public static readonly UIColor PowderBlue = new (176.0f / 255.0f, 224.0f / 255.0f, 230.0f / 255.0f, 1);

        /// <summary>
        /// The Purple color. 0xA020F0
        /// </summary>
        public static readonly UIColor Purple = new (160.0f / 255.0f, 32.0f / 255.0f, 240.0f / 255.0f, 1);

        /// <summary>
        /// The Red color. 0xFF0000
        /// </summary>
        public static readonly UIColor Red = new (1, 0, 0, 1);

        /// <summary>
        /// The RosyBrown color. 0xBC8F8F
        /// </summary>
        public static readonly UIColor RosyBrown = new (188.0f / 255.0f, 143.0f / 255.0f, 143.0f / 255.0f, 1);

        /// <summary>
        /// The RoyalBlue color. 0x4169E1
        /// </summary>
        public static readonly UIColor RoyalBlue = new (65.0f / 255.0f, 105.0f / 255.0f, 225.0f / 255.0f, 1);

        /// <summary>
        /// The SaddleBrown color. 0x8B4513
        /// </summary>
        public static readonly UIColor SaddleBrown = new (139.0f / 255.0f, 69.0f / 255.0f, 19.0f / 255.0f, 1);

        /// <summary>
        /// The Salmon color. 0xFA8072
        /// </summary>
        public static readonly UIColor Salmon = new (250.0f / 255.0f, 128.0f / 255.0f, 114.0f / 255.0f, 1);

        /// <summary>
        /// The SandyBrown color. 0xF4A460
        /// </summary>
        public static readonly UIColor SandyBrown = new (244.0f / 255.0f, 164.0f / 255.0f, 96.0f / 255.0f, 1);

        /// <summary>
        /// The SeaGreen color. 0x2E8B57
        /// </summary>
        public static readonly UIColor SeaGreen = new (46.0f / 255.0f, 139.0f / 255.0f, 87.0f / 255.0f, 1);

        /// <summary>
        /// The SeaShell color. 0xFFF5EE
        /// </summary>
        public static readonly UIColor SeaShell = new (1, 245.0f / 255.0f, 238.0f / 255.0f, 1);

        /// <summary>
        /// The Sienna color. 0xA0522D
        /// </summary>
        public static readonly UIColor Sienna = new (160.0f / 255.0f, 82.0f / 255.0f, 45.0f / 255.0f, 1);

        /// <summary>
        /// The Silver color. 0xC0C0C0
        /// </summary>
        public static readonly UIColor Silver = new (192.0f / 255.0f, 192.0f / 255.0f, 192.0f / 255.0f, 1);

        /// <summary>
        /// The SkyBlue color. 0x87CEEB
        /// </summary>
        public static readonly UIColor SkyBlue = new (135.0f / 255.0f, 206.0f / 255.0f, 235.0f / 255.0f, 1);

        /// <summary>
        /// The SlateBlue color. 0x6A5ACD
        /// </summary>
        public static readonly UIColor SlateBlue = new (106.0f / 255.0f, 90.0f / 255.0f, 205.0f / 255.0f, 1);

        /// <summary>
        /// The SlateGray color. 0x708090
        /// </summary>
        public static readonly UIColor SlateGray = new (112.0f / 255.0f, 128.0f / 255.0f, 144.0f / 255.0f, 1);

        /// <summary>
        /// The SlateGrey color. 0x708090
        /// </summary>
        public static readonly UIColor SlateGrey = new (112.0f / 255.0f, 128.0f / 255.0f, 144.0f / 255.0f, 1);

        /// <summary>
        /// The Snow color. 0xFFFAFA
        /// </summary>
        public static readonly UIColor Snow = new (1, 250.0f / 255.0f, 250.0f / 255.0f, 1);

        /// <summary>
        /// The SpringGreen color. 0x00FF7F
        /// </summary>
        public static readonly UIColor SpringGreen = new (0, 1, 127.0f / 255.0f, 1);

        /// <summary>
        /// The SteelBlue color. 0x4682B4
        /// </summary>
        public static readonly UIColor SteelBlue = new (70.0f / 255.0f, 130.0f / 255.0f, 180.0f / 255.0f, 1);

        /// <summary>
        /// The Tan color. 0xD2B48C
        /// </summary>
        public static readonly UIColor Tan = new (210.0f / 255.0f, 180.0f / 255.0f, 140.0f / 255.0f, 1);

        /// <summary>
        /// The Teal color. 0x008080
        /// </summary>
        public static readonly UIColor Teal = new (0, 128.0f / 255.0f, 128.0f / 255.0f, 1);

        /// <summary>
        /// The Thistle color. 0xD8BFD8
        /// </summary>
        public static readonly UIColor Thistle = new (216.0f / 255.0f, 191.0f / 255.0f, 216.0f / 255.0f, 1);

        /// <summary>
        /// The Tomato color. 0xFF6347
        /// </summary>
        public static readonly UIColor Tomato = new (1, 99.0f / 255.0f, 71.0f / 255.0f, 1);

        /// <summary>
        /// The Turquoise color. 0x40E0D0
        /// </summary>
        public static readonly UIColor Turquoise = new (64.0f / 255.0f, 224.0f / 255.0f, 208.0f / 255.0f, 1);

        /// <summary>
        /// The Violet color. 0xEE82EE
        /// </summary>
        public static readonly UIColor Violet = new (238.0f / 255.0f, 130.0f / 255.0f, 238.0f / 255.0f, 1);

        /// <summary>
        /// The Wheat color. 0xF5DEB3
        /// </summary>
        public static readonly UIColor Wheat = new (245.0f / 255.0f, 222.0f / 255.0f, 179.0f / 255.0f, 1);

        /// <summary>
        /// The White color. 0xFFFFFF
        /// </summary>
        public static readonly UIColor White = new (1, 1, 1, 1);

        /// <summary>
        /// The WhiteSmoke color. 0xF5F5F5
        /// </summary>
        public static readonly UIColor WhiteSmoke = new (245.0f / 255.0f, 245.0f / 255.0f, 245.0f / 255.0f, 1);

        /// <summary>
        /// The Yellow color. 0xFFFF00
        /// </summary>
        public static readonly UIColor Yellow = new (1, 1, 0, 1);

        /// <summary>
        /// The YellowGreen color. 0x9ACD32
        /// </summary>
        public static readonly UIColor YellowGreen = new (154.0f / 255.0f, 205.0f / 255.0f, 50.0f / 255.0f, 1);
    }
}
