/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which defines SAT main menu info.
    /// </summary>
    public class SatMainMenuInfo
    {
        internal int Id;
        internal bool IsPresent;
        internal string Title;
        internal IEnumerable<SatMenuInfo> Items;
        internal ushort Num;
        internal bool IsHelpInfo;
        internal bool IsUpdated;
        internal SatIconIdInfo IcnId;
        internal SatIconIdListInfo IdList;

        internal SatMainMenuInfo()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command number represented in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Flag for checking whether main menu is present or not.
        /// </summary>
        /// <value>Boolean value checking the presence of main menu.</value>
        public bool IsMainMenuPresent
        {
            get
            {
                return IsPresent;
            }
        }

        /// <summary>
        /// Menu title text.
        /// </summary>
        /// <value>Title text of the menu item represented in string.</value>
        public string MenuTitle
        {
            get
            {
                return Title;
            }
        }

        /// <summary>
        /// Menu items.
        /// </summary>
        /// <value>List of SatMenuInfo objects.</value>
        public IEnumerable<SatMenuInfo> MenuItems
        {
            get
            {
                return Items;
            }
        }

        /// <summary>
        /// Number of menu itmes.
        /// </summary>
        /// <value>An unsigned value representing the number of menu items.</value>
        public ushort MainMenuCount
        {
            get
            {
                return Num;
            }
        }

        /// <summary>
        /// Flag for a help information request.
        /// </summary>
        /// <value>Boolean value for checking the flag for help information request.</value>
        public bool IsMainMenuHelpInfo
        {
            get
            {
                return IsHelpInfo;
            }
        }

        /// <summary>
        /// Updated Sat main menu or not.
        /// </summary>
        /// <value>Boolean value to check whether Sat main menu is updated or not.</value>
        public bool IsUpdatedMainMenu
        {
            get
            {
                return IsUpdated;
            }
        }

        /// <summary>
        /// Icon Identifier.
        /// </summary>
        /// <value>An instance of SatIconIdInfo class representing the icon identifier.</value>
        public SatIconIdInfo IconId
        {
            get
            {
                return IcnId;
            }
        }

        /// <summary>
        /// List of Icon Identifiers.
        /// </summary>
        /// <value>An instance of SatIconIdListInfo class representing the icon identifier list.</value>
        public SatIconIdListInfo IconIdList
        {
            get
            {
                return IdList;
            }
        }
    }


    /// <summary>
    /// A class which contains menu item information for the setup menu.
    /// </summary>
    public class SatMenuInfo
    {
        internal string Item;
        internal char Id;

        internal SatMenuInfo()
        {
        }

        /// <summary>
        /// Menu item character data.
        /// </summary>
        /// <value>Menu item data represented in string.</value>
        public string MenuItem
        {
            get
            {
                return Item;
            }
        }

        /// <summary>
        /// Identifies the item on the menu that the user selected.
        /// </summary>
        /// <value>Item identifier value represented as a character.</value>
        public char ItemId
        {
            get
            {
                return Id;
            }
        }
    }

    /// <summary>
    /// A class defining the icon data object.
    /// </summary>
    public class SatIconIdInfo
    {
        internal bool IsPresent;
        internal SatIconQualifierType Qualifier;
        internal byte Id;
        internal SatIconInfo Info;

        internal SatIconIdInfo()
        {
        }

        /// <summary>
        /// Flag for checking whether the icon identifier exists.
        /// </summary>
        /// <value>Boolean value representing if the icon exists or not.</value>
        public bool IsIconPresent
        {
            get
            {
                return IsPresent;
            }
        }

        /// <summary>
        /// Icon qualifier type.
        /// </summary>
        /// <value>Icon qualifier type represented as SatIconQualifierType enum.</value>
        public SatIconQualifierType IconQualifier
        {
            get
            {
                return Qualifier;
            }
        }

        /// <summary>
        /// Icon identifier.
        /// </summary>
        /// <value>A byte value representing the icon identifier.</value>
        public byte IconId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Icon info.
        /// </summary>
        /// <value>An instance of SatIconInfo class.</value>
        public SatIconInfo IconInfo
        {
            get
            {
                return Info;
            }
        }
    }

    /// <summary>
    /// A class containing the definition of icon info object.
    /// </summary>
    public class SatIconInfo
    {
        internal byte IconWidth;
        internal byte IconHeight;
        internal SatImageCodingScheme Scheme;
        internal ushort IconLength;
        internal ushort ClutLength;
        internal string IcnFile;
        internal string CltFile;

        internal SatIconInfo()
        {
        }

        /// <summary>
        /// Icon width.
        /// </summary>
        /// <value>Width of the icon represented in byte.</value>
        public byte Width
        {
            get
            {
                return IconWidth;
            }
        }

        /// <summary>
        /// Icon height.
        /// </summary>
        /// <value>Height of the icon represented in byte.</value>
        public byte Height
        {
            get
            {
                return IconHeight;
            }
        }

        /// <summary>
        /// Image coding scheme.
        /// </summary>
        /// <value>Image coding scheme represented as SatImageCodingScheme enum.</value>
        public SatImageCodingScheme Ics
        {
            get
            {
                return Scheme;
            }
        }

        /// <summary>
        /// Icon data length.
        /// </summary>
        /// <value>Data length of the icon represented in ushort.</value>
        public ushort IconDataLength
        {
            get
            {
                return IconLength;
            }
        }

        /// <summary>
        /// Clut data length.
        /// </summary>
        /// <value>Data length of the clut represented in ushort.</value>
        public ushort ClutDataLength
        {
            get
            {
                return ClutLength;
            }
        }

        /// <summary>
        /// Icon file.
        /// </summary>
        /// <value>Icon file string.</value>
        public string IconFile
        {
            get
            {
                return IcnFile;
            }
        }

        /// <summary>
        /// Clut file.
        /// </summary>
        /// <value>Clut file string.</value>
        public string ClutFile
        {
            get
            {
                return CltFile;
            }
        }
    }

    /// <summary>
    /// A class which defines the icon identifier data object.
    /// </summary>
    public class SatIconIdListInfo
    {
        internal bool IsPresent;
        internal SatIconQualifierType Qualifier;
        internal byte Count;
        internal byte[] IconList;
        internal IEnumerable<SatIconInfo> Info;

        internal SatIconIdListInfo()
        {
        }

        /// <summary>
        /// Flag for checking whether the icon identifier exists.
        /// </summary>
        /// <value>Boolean value indicating the presence of icon.</value>
        public bool IsIconPresent
        {
            get
            {
                return IsPresent;
            }
        }

        /// <summary>
        /// Icon list qualifier.
        /// </summary>
        /// <value>Icon list qualifier represented in SatIconQualifierType enum.</value>
        public SatIconQualifierType IconListQualifier
        {
            get
            {
                return Qualifier;
            }
        }

        /// <summary>
        /// Number of icons.
        /// </summary>
        /// <value>Byte value indicating the number of icons.</value>
        public byte IconCount
        {
            get
            {
                return Count;
            }
        }

        /// <summary>
        /// Icon identifier list.
        /// </summary>
        /// <value>A byte array containing the list of Icon identifier.</value>
        public byte[] IconIdList
        {
            get
            {
                return IconList;
            }
        }

        /// <summary>
        /// Icon list info.
        /// </summary>
        /// <value>List of icon info.</value>
        public IEnumerable<SatIconInfo> IconInfo
        {
            get
            {
                return Info;
            }
        }
    }

    /// <summary>
    /// A class containing display text proactive command for SAT UI.
    /// </summary>
    public class SatDisplayTextData
    {
        internal int Id;
        internal SatTextInfo Text;
        internal uint Drtn;
        internal bool IsPrtyHigh;
        internal bool IsRespRequired;
        internal bool IsImmediateResp;
        internal SatIconIdInfo IcnId;

        internal SatDisplayTextData()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command id in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Character data to display on screen.
        /// </summary>
        /// <value>An instance of SatTextInfo containing text information.</value>
        public SatTextInfo TextInfo
        {
            get
            {
                return Text;
            }
        }

        /// <summary>
        /// Duration of the display.
        /// </summary>
        /// <value>Duration in integer format.</value>
        public uint Duration
        {
            get
            {
                return Drtn;
            }
        }

        /// <summary>
        /// Flag that indicates whether text is to be displayed if some other app is using the screen.
        /// </summary>
        /// <value>Boolean value checking the priority of the display.</value>
        public bool IsPriorityHigh
        {
            get
            {
                return IsPrtyHigh;
            }
        }

        /// <summary>
        /// Flag that indicates whether user response is required.
        /// </summary>
        /// <value>Boolean value to check the need of user response.</value>
        public bool IsUserResponseRequired
        {
            get
            {
                return IsRespRequired;
            }
        }

        /// <summary>
        /// Flag for checking whether immediate response is required.
        /// </summary>
        /// <value>Boolean value to check the immediate response status.</value>
        public bool IsImmediateResponse
        {
            get
            {
                return IsImmediateResp;
            }
        }

        /// <summary>
        /// Icon Identifier.
        /// </summary>
        /// <value>An instance of SatIconIdInfo class.</value>
        public SatIconIdInfo IconId
        {
            get
            {
                return IcnId;
            }
        }
    }

    /// <summary>
    /// A class defining character data for the SAT engine data structure.
    /// </summary>
    public class SatTextInfo
    {
        internal ushort Length;
        internal byte[] Data;

        internal SatTextInfo()
        {
        }

        /// <summary>
        /// Character data length.
        /// </summary>
        /// <value>An unsigned short value representing the string length.</value>
        public ushort StringLength
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// Character data.
        /// </summary>
        /// <value>A byte array representing the string data.</value>
        public byte[] StringData
        {
            get
            {
                return Data;
            }
        }
    }

    /// <summary>
    /// A class which defines select item proactive command data for SAT UI.
    /// </summary>
    public class SatSelectItemData
    {
        internal int Id;
        internal bool IsHelpAvailable;
        internal SatTextInfo Text;
        internal char DefaultIndex;
        internal char ItemCount;
        internal IEnumerable<SatMenuItemInfo> Items;
        internal SatIconIdInfo IcnId;
        internal SatIconIdListInfo IdList;

        internal SatSelectItemData()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command id represented in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Flag for a help information request.
        /// </summary>
        /// <value>Boolean value to check whether help information is availale or not.</value>
        public bool IsHelpInfoAvailable
        {
            get
            {
                return IsHelpAvailable;
            }
        }

        /// <summary>
        /// Menu title text.
        /// </summary>
        /// <value>An instance of SatTextInfo class containing the text information.</value>
        public SatTextInfo TextInfo
        {
            get
            {
                return Text;
            }
        }

        /// <summary>
        /// Selected default item.
        /// </summary>
        /// <value>Default item index of the given items.</value>
        public char DefaultItemIndex
        {
            get
            {
                return DefaultIndex;
            }
        }

        /// <summary>
        /// Number of menu items.
        /// </summary>
        /// <value>Menu items count represented as a character.</value>
        public char MenuItemCount
        {
            get
            {
                return ItemCount;
            }
        }

        /// <summary>
        /// Menu items.
        /// </summary>
        /// <value>A list of SatMenuItemInfo objects.</value>
        public IEnumerable<SatMenuItemInfo> MenuItems
        {
            get
            {
                return Items;
            }
        }

        /// <summary>
        /// Icon Identifier.
        /// </summary>
        /// <value>An instance of SatIconIdInfo class.</value>
        public SatIconIdInfo IconId
        {
            get
            {
                return IcnId;
            }
        }

        /// <summary>
        /// List of Icon Identifiers.
        /// </summary>
        /// <value>An instance of SatIconIdListInfo class containing the list of icon identifiers.</value>
        public SatIconIdListInfo IconIdList
        {
            get
            {
                return IdList;
            }
        }
    }

    /// <summary>
    /// A class which defines the menu item data object.
    /// </summary>
    public class SatMenuItemInfo
    {
        internal byte Id;
        internal byte Length;
        internal byte[] Txt;

        internal SatMenuItemInfo()
        {
        }

        /// <summary>
        /// Item identifier.
        /// </summary>
        /// <value>Item Id represented in byte.</value>
        public byte ItemId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Text length.
        /// </summary>
        /// <value>Length of the text represented in byte.</value>
        public byte TextLength
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// Text information.
        /// </summary>
        /// <value>A byte array of length TextLength containing the text information.</value>
        public byte[] Text
        {
            get
            {
                return Txt;
            }
        }
    }

    /// <summary>
    /// A class which defines get inkey proactive command data for SAT UI.
    /// </summary>
    public class SatGetInKeyData
    {
        internal int Id;
        internal SatInKeyType Type;
        internal SatInputAlphabetType AlphabetType;
        internal bool IsNumericFlag;
        internal bool IsHelpAvailable;
        internal SatTextInfo Text;
        internal uint Duratn;
        internal SatIconIdInfo IcnId;

        internal SatGetInKeyData()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command id represented in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Input Type.
        /// </summary>
        /// <value>Character Set or Yes/No.</value>
        public SatInKeyType KeyType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Input character mode.
        /// </summary>
        /// <value>SMS default, UCS2.</value>
        public SatInputAlphabetType InputAlphabetType
        {
            get
            {
                return AlphabetType;
            }
        }

        /// <summary>
        /// Flag for checking whether input character is numeric.
        /// </summary>
        /// <value>Boolean value for checking whether input character is numeric or not.</value>
        public bool IsNumeric
        {
            get
            {
                return IsNumericFlag;
            }
        }

        /// <summary>
        /// Help info request flag.
        /// </summary>
        /// <value>Boolean value for checking whether help info is available or not.</value>
        public bool IsHelpInfoAvailable
        {
            get
            {
                return IsHelpAvailable;
            }
        }

        /// <summary>
        /// Character data to display on the screen.
        /// </summary>
        /// <value>An instance of SatTextInfo class containing the text information.</value>
        public SatTextInfo TextInfo
        {
            get
            {
                return Text;
            }
        }

        /// <summary>
        /// Duration of the display.
        /// </summary>
        /// <value>Display duration represented in unsigned integer.</value>
        public uint Duration
        {
            get
            {
                return Duratn;
            }
        }

        /// <summary>
        /// Icon identifier.
        /// </summary>
        /// <value>An instance of SatIconIdInfo class containing the Icon identifier information.</value>
        public SatIconIdInfo IconId
        {
            get
            {
                return IcnId;
            }
        }
    }

    /// <summary>
    /// A class which defines get input proactive command data for SAT UI.
    /// </summary>
    public class SatGetInputData
    {
        internal int Id;
        internal SatInputAlphabetType Type;
        internal bool IsNumericFlag;
        internal bool IsHelpAvailable;
        internal bool IsEcho;
        internal SatTextInfo Text;
        internal SatResponseLengthInfo RespLength;
        internal SatTextInfo Default;
        internal SatIconIdInfo IcnId;

        internal SatGetInputData()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command id represented in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Input character mode.
        /// </summary>
        /// <value>SMS default, UCS2.</value>
        public SatInputAlphabetType AlphabetType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Flag to check whether input character is numeric.
        /// </summary>
        /// <value>Boolean value to check the nature of input character.</value>
        public bool IsNumeric
        {
            get
            {
                return IsNumericFlag;
            }
        }

        /// <summary>
        /// Help info request flag.
        /// </summary>
        /// <value>Boolean value to check help information availability.</value>
        public bool IsHelpInfoAvailable
        {
            get
            {
                return IsHelpAvailable;
            }
        }

        /// <summary>
        /// Flag that indicates whether to show input data on the screen.
        /// </summary>
        /// <value>Boolean value to check the availability of input data on the screen.</value>
        public bool IsEchoInput
        {
            get
            {
                return IsEcho;
            }
        }

        /// <summary>
        /// Character data to display on the screen.
        /// </summary>
        /// <value>An instance of SatTextInfo.</value>
        public SatTextInfo TextInfo
        {
            get
            {
                return Text;
            }
        }

        /// <summary>
        /// Input data min, max length.
        /// </summary>
        /// <value>An instance of SatResponseLengthInfo.</value>
        public SatResponseLengthInfo ResponseLength
        {
            get
            {
                return RespLength;
            }
        }

        /// <summary>
        /// Default input character data.
        /// </summary>
        /// <value>An instance of SatTextInfo.</value>
        public SatTextInfo DefualtText
        {
            get
            {
                return Default;
            }
        }

        /// <summary>
        /// Icon identifier.
        /// </summary>
        /// <value>An instance of SatIconIdInfo.</value>
        public SatIconIdInfo IconId
        {
            get
            {
                return IcnId;
            }
        }
    }

    /// <summary>
    /// A class which defines expected user response length.
    /// </summary>
    public class SatResponseLengthInfo
    {
        internal byte Min;
        internal byte Max;

        internal SatResponseLengthInfo()
        {
        }

        /// <summary>
        /// User response length's minimum value.
        /// </summary>
        /// <value>Minimum value represented in byte.</value>
        public byte Minimum
        {
            get
            {
                return Min;
            }
        }

        /// <summary>
        /// User response length's maximum value.
        /// </summary>
        /// <value>Maximum value represented in byte.</value>
        public byte Maximum
        {
            get
            {
                return Max;
            }
        }
    }

    /// <summary>
    /// A class which defines refresh proactive command data for applications that are concerned with files residing on USIM.
    /// </summary>
    public class SatRefreshData
    {
        internal int Id;
        internal SatRefreshAppType Type;
        internal SatCmdQualiRefresh Mode;
        internal byte Count;
        internal IEnumerable<SimFileId> IdList;

        internal SatRefreshData()
        {
        }

        /// <summary>
        /// Proactive command number sent by USIM.
        /// </summary>
        /// <value>Command id represented in integer format.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Concerned application type.
        /// </summary>
        /// <value>Refresh app type represented in SatRefreshAppType enum.</value>
        public SatRefreshAppType AppType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Refresh mode.
        /// </summary>
        /// <value>Refresh mode represented in SatCmdQualiRefresh enum.</value>
        public SatCmdQualiRefresh RefreshMode
        {
            get
            {
                return Mode;
            }
        }

        /// <summary>
        /// Refresh file count.
        /// </summary>
        /// <value>File count represented in byte.</value>
        public byte FileCount
        {
            get
            {
                return Count;
            }
        }

        /// <summary>
        /// Refresh file identifiers.
        /// </summary>
        /// <value>A list of SimFileId enums.</value>
        public IEnumerable<SimFileId> FileId
        {
            get
            {
                return IdList;
            }
        }
    }

    /// <summary>
    /// A class which defines send SMS proactive command data for the SMS application.
    /// </summary>
    public class SatSendSmsData
    {
        internal int Id;
        internal bool IsPackRequired;
        internal SatAddressData Addr;
        internal SatSmsTpduInfo Info;

        internal SatSendSmsData()
        {
        }

        /// <summary>
        /// Proactive Command Number sent by USIM.
        /// </summary>
        /// <value>Command id represented in integer.</value>
        public int CommandId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Flag to check if packing is required for SMS Tpdu.
        /// </summary>
        /// <value>Boolean value to check the need of packing in SMS Tpdu data.</value>
        public bool IsPackingRequired
        {
            get
            {
                return IsPackRequired;
            }
        }

        /// <summary>
        /// Destination address.
        /// </summary>
        /// <value>An instance of SatAddressData containing the address info.</value>
        public SatAddressData Address
        {
            get
            {
                return Addr;
            }
        }

        /// <summary>
        /// SMS Tpdu data.
        /// </summary>
        /// <value>An instance of SatSmsTpduInfo.</value>
        public SatSmsTpduInfo TpduInfo
        {
            get
            {
                return Info;
            }
        }
    }

    /// <summary>
    /// A class which defines SAT address data object.
    /// </summary>
    public class SatAddressData
    {
        internal SimTypeOfNumber Type;
        internal SimNumberPlanIdentity NumId;
        internal byte NumLen;
        internal string Number;

        internal SatAddressData()
        {
        }

        /// <summary>
        /// Type of number.
        /// </summary>
        /// <value>Sim type of number represented in SimTypeOfNumber enum.</value>
        public SimTypeOfNumber Ton
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Number plan identity.
        /// </summary>
        /// <value>Sim number plan represented in SimNumberPlanIdentity enum.</value>
        public SimNumberPlanIdentity Npi
        {
            get
            {
                return NumId;
            }
        }

        /// <summary>
        /// Length of dialling number.
        /// </summary>
        /// <value>Dialling number length represented in byte.</value>
        public byte DiallingNumberLength
        {
            get
            {
                return NumLen;
            }
        }

        /// <summary>
        /// Dialling number.
        /// </summary>
        /// <value>Dialling number represented in string.</value>
        public string DiallingNumber
        {
            get
            {
                return Number;
            }
        }
    }

    /// <summary>
    /// A class which defines the Result data object.
    /// </summary>
    public class SatSmsTpduInfo
    {
        internal SatSmsTpduType Type;
        internal byte Length;
        internal byte[] Data;

        internal SatSmsTpduInfo()
        {
        }

        /// <summary>
        /// SMS TPDU type.
        /// </summary>
        /// <value>Tpdu type represented in SatSmsTpduType.</value>
        public SatSmsTpduType TpduType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// SMS TPDU data length.
        /// </summary>
        /// <value>Length of Tpdu data represented in byte.</value>
        public byte DataLength
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// SMS TPDU data.
        /// </summary>
        /// <value>An array of bytes representing TPDU data.</value>
        public byte[] TpduData
        {
            get
            {
                return Data;
            }
        }
    }
}
