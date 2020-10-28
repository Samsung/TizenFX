/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SatMenuSelectionInfoStruct
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatEventDownloadInfoStruct
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatUiUserConfirmInfoStruct
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatMainMenuInfoStruct
    {
        internal int CommandId;
        internal int IsMainMenuPresent;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Title;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.LPStruct)]
        internal SatMenuInfoStruct[] MenuItem;
        internal ushort NumOfMenuItems;
        internal int IsMainMenuHelpInfo;
        internal int IsUpdatedMainMenu;
        internal SatIconIdentifierStruct IconId;
        internal SatIconIdentifierListStruct IconIdList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatMenuInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261)]
        internal string Item;
        internal char ItemId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatIconIdentifierStruct
    {
        internal int IsPresent;
        internal SatIconQualifierType IconQualifier;
        internal byte IconIdentifier;
        internal SatIconInfoStruct IconInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatIconInfoStruct
    {
        internal byte Width;
        internal byte Height;
        internal SatImageCodingScheme Ics;
        internal ushort IconDataLength;
        internal ushort ClutDataLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        internal string IconFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        internal string ClutFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatIconIdentifierListStruct
    {
        internal int IsPresent;
        internal SatIconQualifierType IconListQualifier;
        internal byte IconCount;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        internal string IconIdentifierList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.LPStruct)]
        internal SatIconInfoStruct[] IconInfoList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatDisplayTextStruct
    {
        internal int CommandId;
        internal SatTextInfoStruct Text;
        internal uint Duration;
        internal int IsPriorityHigh;
        internal int IsUserResponseRequired;
        internal int IsImmediateResponse;
        internal SatIconIdentifierStruct IconId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatTextInfoStruct
    {
        internal ushort Length;
        internal IntPtr DataString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSelectItemStruct
    {
        internal int commandId;
        internal int IsHelpInfoAvailable;
        internal SatTextInfoStruct Text;
        internal char DefaultItemIndex;
        internal char MenuItemCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.LPStruct)]
        internal SatMenuItemInfoStruct[] MenuItems;
        internal SatIconIdentifierStruct IconId;
        internal SatIconIdentifierListStruct IconIdList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatMenuItemInfoStruct
    {
        internal byte ItemId;
        internal byte TextLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string Text;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatGetInKeyStruct
    {
        internal int CommandId;
        internal SatInKeyType KeyType;
        internal SatInputAlphabetType InputType;
        internal int IsNumeric;
        internal int IsHelpInfoAvailable;
        internal SatTextInfoStruct Text;
        internal uint Duration;
        internal SatIconIdentifierStruct IconId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatGetInputStruct
    {
        internal int CommandId;
        internal SatInputAlphabetType Type;
        internal int IsNumeric;
        internal int IsHelpInfoAvailable;
        internal int IsEchoInput;
        internal SatTextInfoStruct Text;
        internal SatResponseLengthStruct RespLength;
        internal SatTextInfoStruct DefaultText;
        internal SatIconIdentifierStruct IconId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatResponseLengthStruct
    {
        internal byte Min;
        internal byte Max;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatRefreshStruct
    {
        internal int CommandId;
        internal SatRefreshAppType AppType;
        internal SatCmdQualiRefresh RefreshMode;
        internal byte FileCount;
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4, SizeConst = 20)]
        internal SimFileId[] fileId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSendSmsStruct
    {
        internal int CommandId;
        internal int IsPackingRequired;
        internal SatAddressStruct Address;
        internal SatSmsTpduStruct SmsTpdu;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatAddressStruct
    {
        internal SimTypeOfNumber Ton;
        internal SimNumberPlanIdentity Npi;
        internal byte DiallingNumLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
        internal string DiallingNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSmsTpduStruct
    {
        internal SatSmsTpduType TpduType;
        internal byte DataLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 175)]
        internal string Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatEventListDataStruct
    {
        internal int IsEventDownloadActive;
        internal int IsMtCallEvent;
        internal int IsCallConnected;
        internal int IsCallDisconnected;
        internal int IsLocationStatus;
        internal int IsUserActivity;
        internal int IsIdleScreenAvailable;
        internal int IsCardReaderStatus;
        internal int IsLanguageSelection;
        internal int IsBrowserTermination;
        internal int IsDataAvailable;
        internal int IsChannelStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSendDtmfDataStruct
    {
        internal int CommandId;
        internal int IsHiddenMode;
        internal SatTextInfoStruct DtmfString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatCallCtrlIndCallSsDataStruct
    {
        internal SatTextInfoStruct Address;
        internal SatTextInfoStruct SubAddress;
        internal SatBcRepeatIndicatorType BcRepeatIndicator;
        internal SatTextInfoStruct Ccp1;
        internal SatTextInfoStruct Ccp2;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatCallCtrlIndUssdDataStruct
    {
        internal SatTextInfoStruct UssdString;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct SatCallCtrlIndStruct
    {
        [FieldOffset(0)]
        internal SatCallCtrlIndCallSsDataStruct CallCtrlCnfCallData;
        [FieldOffset(0)]
        internal SatCallCtrlIndCallSsDataStruct CallCtrlCnfSsData;
        [FieldOffset(0)]
        internal SatCallCtrlIndUssdDataStruct CallCtrlCnfUssdData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatCallCtrlIndDataStruct
    {
        internal SatCallType CallCtrlCnfType;
        internal SatCallCtrlResultType CallCtrlResult;
        internal SatTextInfoStruct DisplayData;
        internal int IsUserInfoDispEnabled;
        internal SatCallCtrlIndStruct CallCtrlIndData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatTextTypeInfoStruct
    {
        internal int IsDigitOnly;
        internal SatDataCodingSchemeStruct Dcs;
        internal ushort StringLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 501)]
        internal string TextString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatDataCodingSchemeStruct
    {
        internal int IsCompressedFormat;
        internal SatAlphabetFormat AlphabetFormat;
        internal SatMsgClassType MsgClass;
        internal byte RawDcs;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatMoSmsCtrlDataStruct
    {
        internal SatCallCtrlResultType Result;
        internal int IsUserInfoDisplayEnabled;
        internal SatTextTypeInfoStruct DisplayData;
        internal SatTextTypeInfoStruct RpDestAddr;
        internal SatTextTypeInfoStruct TpDestAddr;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSetupCallDataStruct
    {
        internal int CommandId;
        internal SatCmdQualiSetupCall CallType;
        internal SatTextInfoStruct DisplayText;
        internal SatTextInfoStruct CallNumber;
        internal uint Duration;
        internal SatIconIdentifierStruct IconId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSendSsDataStruct
    {
        internal int CommandId;
        internal SimTypeOfNumber Ton;
        internal SimNumberPlanIdentity Npi;
        internal byte StringLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 161)]
        internal string SsString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatSetupUssdDataStruct
    {
        internal int CommandId;
        internal byte RawDcs;
        internal byte UssdStringLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 266)]
        internal string UssdString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SatResultDataStruct
    {
    }

    internal static class SatStructConversions
    {
        internal static SatTextInfo ConvertSatTextInfoStruct(SatTextInfoStruct textStruct)
        {
            SatTextInfo textInfo = new SatTextInfo();
            textInfo.Length = textStruct.Length;
            byte[] data = new byte[textStruct.Length];
            Marshal.Copy(textStruct.DataString, data, 0, textInfo.Length);
            textInfo.Data = data;
            return textInfo;
        }

        internal static SatIconInfo ConvertSatIconInfoStruct(SatIconInfoStruct iconStruct)
        {
            SatIconInfo iconInfo = new SatIconInfo();
            iconInfo.IconWidth = iconStruct.Width;
            iconInfo.IconHeight = iconStruct.Height;
            iconInfo.Scheme = iconStruct.Ics;
            iconInfo.IconLength = iconStruct.IconDataLength;
            iconInfo.ClutLength = iconStruct.ClutDataLength;
            iconInfo.IcnFile = iconStruct.IconFile;
            iconInfo.CltFile = iconStruct.ClutFile;
            return iconInfo;
        }

        internal static SatIconIdInfo ConvertSatIconIdentifierStruct(SatIconIdentifierStruct idStruct)
        {
            SatIconIdInfo iconId = new SatIconIdInfo();
            if (idStruct.IsPresent == 1)
            {
                iconId.IsPresent = true;
            }

            else if (idStruct.IsPresent == 0)
            {
                iconId.IsPresent = false;
            }

            iconId.Qualifier = idStruct.IconQualifier;
            iconId.Id = idStruct.IconIdentifier;
            iconId.Info = ConvertSatIconInfoStruct(idStruct.IconInfo);
            return iconId;
        }

        internal static SatIconIdListInfo ConvertSatIconIdListStruct(SatIconIdentifierListStruct listStruct)
        {
            SatIconIdListInfo iconIdList = new SatIconIdListInfo();
            if (listStruct.IsPresent == 1)
            {
                iconIdList.IsPresent = true;
            }

            else if (listStruct.IsPresent == 0)
            {
                iconIdList.IsPresent = false;
            }

            iconIdList.Qualifier = listStruct.IconListQualifier;
            iconIdList.Count = listStruct.IconCount;
            iconIdList.IconList = Encoding.ASCII.GetBytes(listStruct.IconIdentifierList);
            List<SatIconInfo> iconInfoList = new List<SatIconInfo>();
            foreach (SatIconInfoStruct info in listStruct.IconInfoList)
            {
                iconInfoList.Add(ConvertSatIconInfoStruct(info));
            }

            iconIdList.Info = iconInfoList;
            return iconIdList;
        }

        internal static SatMainMenuInfo ConvertSatMainMenuInfoStruct(SatMainMenuInfoStruct infoStruct)
        {
            SatMainMenuInfo mainMenuInfo = new SatMainMenuInfo();
            mainMenuInfo.Id = infoStruct.CommandId;
            if (infoStruct.IsMainMenuPresent == 1)
            {
                mainMenuInfo.IsPresent = true;
            }

            else if (infoStruct.IsMainMenuPresent == 0)
            {
                mainMenuInfo.IsPresent = false;
            }

            mainMenuInfo.Title = infoStruct.Title;
            List<SatMenuInfo> menuInfoList = new List<SatMenuInfo>();
            foreach (SatMenuInfoStruct menu in infoStruct.MenuItem)
            {
                SatMenuInfo menuInfo = new SatMenuInfo();
                menuInfo.Item = menu.Item;
                menuInfo.Id = menu.ItemId;
                menuInfoList.Add(menuInfo);
            }

            mainMenuInfo.Items = menuInfoList;
            mainMenuInfo.Num = infoStruct.NumOfMenuItems;
            if (infoStruct.IsMainMenuHelpInfo == 1)
            {
                mainMenuInfo.IsHelpInfo = true;
            }

            else if (infoStruct.IsMainMenuHelpInfo == 0)
            {
                mainMenuInfo.IsHelpInfo = false;
            }

            if (infoStruct.IsUpdatedMainMenu == 1)
            {
                mainMenuInfo.IsUpdated = true;
            }

            else if (infoStruct.IsUpdatedMainMenu == 0)
            {
                mainMenuInfo.IsUpdated = false;
            }

            mainMenuInfo.IcnId = ConvertSatIconIdentifierStruct(infoStruct.IconId);
            mainMenuInfo.IdList = ConvertSatIconIdListStruct(infoStruct.IconIdList);
            return mainMenuInfo;
        }

        internal static SatDisplayTextData ConvertSatDisplayTextStruct(SatDisplayTextStruct textStruct)
        {
            SatDisplayTextData textData = new SatDisplayTextData();
            textData.Id = textStruct.CommandId;
            textData.Text = ConvertSatTextInfoStruct(textStruct.Text);
            textData.Drtn = textStruct.Duration;
            if (textStruct.IsPriorityHigh == 1)
            {
                textData.IsPrtyHigh = true;
            }

            else if (textStruct.IsPriorityHigh == 0)
            {
                textData.IsPrtyHigh = false;
            }

            if (textStruct.IsUserResponseRequired == 1)
            {
                textData.IsRespRequired = true;
            }

            else if (textStruct.IsUserResponseRequired == 0)
            {
                textData.IsRespRequired = false;
            }

            if (textStruct.IsImmediateResponse == 1)
            {
                textData.IsImmediateResp = true;
            }

            else if (textStruct.IsImmediateResponse == 0)
            {
                textData.IsImmediateResp = false;
            }

            textData.IcnId = ConvertSatIconIdentifierStruct(textStruct.IconId);
            return textData;
        }

        internal static SatSelectItemData ConvertSatSelectItemStruct(SatSelectItemStruct itemStruct)
        {
            SatSelectItemData itemData = new SatSelectItemData();
            itemData.Id = itemStruct.commandId;
            if (itemStruct.IsHelpInfoAvailable == 1)
            {
                itemData.IsHelpAvailable = true;
            }

            else if (itemStruct.IsHelpInfoAvailable == 0)
            {
                itemData.IsHelpAvailable = false;
            }

            itemData.Text = ConvertSatTextInfoStruct(itemStruct.Text);
            itemData.DefaultIndex = itemStruct.DefaultItemIndex;
            itemData.ItemCount = itemStruct.MenuItemCount;

            List<SatMenuItemInfo> items = new List<SatMenuItemInfo>();
            foreach(SatMenuItemInfoStruct infoStruct in itemStruct.MenuItems)
            {
                SatMenuItemInfo menuItem = new SatMenuItemInfo();
                menuItem.Id = infoStruct.ItemId;
                menuItem.Length = infoStruct.TextLength;
                menuItem.Txt = Encoding.ASCII.GetBytes(infoStruct.Text);
                items.Add(menuItem);
            }

            itemData.Items = items;
            itemData.IcnId = ConvertSatIconIdentifierStruct(itemStruct.IconId);
            itemData.IdList = ConvertSatIconIdListStruct(itemStruct.IconIdList);
            return itemData;
        }

        internal static SatGetInKeyData ConvertSatGetInKeyStruct(SatGetInKeyStruct inKeyStruct)
        {
            SatGetInKeyData inKeyData = new SatGetInKeyData();
            inKeyData.Id = inKeyStruct.CommandId;
            inKeyData.Type = inKeyStruct.KeyType;
            inKeyData.AlphabetType = inKeyStruct.InputType;
            if (inKeyStruct.IsNumeric == 1)
            {
                inKeyData.IsNumericFlag = true;
            }

            else if (inKeyStruct.IsNumeric == 0)
            {
                inKeyData.IsNumericFlag = false;
            }

            if (inKeyStruct.IsHelpInfoAvailable == 1)
            {
                inKeyData.IsHelpAvailable = true;
            }

            else if (inKeyStruct.IsHelpInfoAvailable == 0)
            {
                inKeyData.IsHelpAvailable = false;
            }

            inKeyData.Text = ConvertSatTextInfoStruct(inKeyStruct.Text);
            inKeyData.Duratn = inKeyStruct.Duration;
            inKeyData.IcnId = ConvertSatIconIdentifierStruct(inKeyStruct.IconId);
            return inKeyData;
        }

        internal static SatGetInputData ConvertSatGetInputStruct(SatGetInputStruct inputStruct)
        {
            SatGetInputData inputData = new SatGetInputData();
            inputData.Id = inputStruct.CommandId;
            inputData.Type = inputStruct.Type;
            if (inputStruct.IsNumeric == 1)
            {
                inputData.IsNumericFlag = true;
            }

            else if (inputStruct.IsNumeric == 0)
            {
                inputData.IsNumericFlag = false;
            }

            if (inputStruct.IsHelpInfoAvailable == 1)
            {
                inputData.IsHelpAvailable = true;
            }

            else if (inputStruct.IsHelpInfoAvailable == 0)
            {
                inputData.IsHelpAvailable = false;
            }

            if (inputStruct.IsEchoInput == 1)
            {
                inputData.IsEcho = true;
            }

            else if (inputStruct.IsEchoInput == 0)
            {
                inputData.IsEcho = false;
            }

            inputData.Text = ConvertSatTextInfoStruct(inputStruct.Text);

            SatResponseLengthInfo responseLength = new SatResponseLengthInfo();
            responseLength.Min = inputStruct.RespLength.Min;
            responseLength.Max = inputStruct.RespLength.Max;

            inputData.RespLength = responseLength;
            inputData.Default = ConvertSatTextInfoStruct(inputStruct.DefaultText);
            inputData.IcnId = ConvertSatIconIdentifierStruct(inputStruct.IconId);
            return inputData;
        }

        internal static SatRefreshData ConvertSatRefreshStruct(SatRefreshStruct refreshStruct)
        {
            SatRefreshData refreshData = new SatRefreshData();
            refreshData.Id = refreshStruct.CommandId;
            refreshData.Type = refreshStruct.AppType;
            refreshData.Mode = refreshStruct.RefreshMode;
            refreshData.Count = refreshStruct.FileCount;
            List<SimFileId> fileId = new List<SimFileId>();
            foreach(SimFileId id in refreshStruct.fileId)
            {
                fileId.Add(id);
            }
            refreshData.IdList = fileId;
            return refreshData;
        }

        internal static SatAddressData ConvertSatAddressStruct(SatAddressStruct addressStruct)
        {
            SatAddressData addressData = new SatAddressData();
            addressData.Type = addressStruct.Ton;
            addressData.NumId = addressStruct.Npi;
            addressData.NumLen = addressStruct.DiallingNumLength;
            addressData.Number = addressStruct.DiallingNumber;
            return addressData;
        }

        internal static SatSmsTpduInfo ConvertSatSmsTpduStruct(SatSmsTpduStruct tpduStruct)
        {
            SatSmsTpduInfo tpduInfo = new SatSmsTpduInfo();
            tpduInfo.Type = tpduStruct.TpduType;
            tpduInfo.Length = tpduStruct.DataLength;
            tpduInfo.Data = Encoding.ASCII.GetBytes(tpduStruct.Data);
            return tpduInfo;
        }

        internal static SatSendSmsData ConvertSatSendSmsStruct(SatSendSmsStruct smsStruct)
        {
            SatSendSmsData smsData = new SatSendSmsData();
            smsData.Id = smsStruct.CommandId;
            if (smsStruct.IsPackingRequired == 1)
            {
                smsData.IsPackRequired = true;
            }

            else if (smsStruct.IsPackingRequired == 0)
            {
                smsData.IsPackRequired = false;
            }

            smsData.Addr = ConvertSatAddressStruct(smsStruct.Address);
            smsData.Info = ConvertSatSmsTpduStruct(smsStruct.SmsTpdu);
            return smsData;
        }

        internal static SatEventListData ConvertSatEventListStruct(SatEventListDataStruct listStruct)
        {
            SatEventListData listData = new SatEventListData();
            if (listStruct.IsEventDownloadActive == 1)
            {
                listData.IsDownloadActive = true;
            }

            else if (listStruct.IsEventDownloadActive == 0)
            {
                listData.IsDownloadActive = false;
            }

            if (listStruct.IsMtCallEvent == 1)
            {
                listData.IsCallEvent = true;
            }

            else if (listStruct.IsMtCallEvent == 0)
            {
                listData.IsCallEvent = false;
            }

            if (listStruct.IsCallConnected == 1)
            {
                listData.IsConnected = true;
            }

            else if (listStruct.IsCallConnected == 0)
            {
                listData.IsConnected = false;
            }

            if (listStruct.IsCallDisconnected == 1)
            {
                listData.IsDisconnected = true;
            }

            else if (listStruct.IsCallDisconnected == 0)
            {
                listData.IsDisconnected = false;
            }

            if (listStruct.IsLocationStatus == 1)
            {
                listData.IsStatus = true;
            }

            else if (listStruct.IsLocationStatus == 0)
            {
                listData.IsStatus = false;
            }

            if (listStruct.IsUserActivity == 1)
            {
                listData.IsUsrActivity = true;
            }

            else if (listStruct.IsUserActivity == 0)
            {
                listData.IsUsrActivity = false;
            }

            if (listStruct.IsIdleScreenAvailable == 1)
            {
                listData.IsIdleScreen = true;
            }

            else if (listStruct.IsIdleScreenAvailable == 0)
            {
                listData.IsIdleScreen = false;
            }

            if (listStruct.IsCardReaderStatus == 1)
            {
                listData.IsReaderStatus = true;
            }

            else if (listStruct.IsCardReaderStatus == 0)
            {
                listData.IsReaderStatus = false;
            }

            if (listStruct.IsLanguageSelection == 1)
            {
                listData.IsLanguageSelect = true;
            }

            else if (listStruct.IsLanguageSelection == 0)
            {
                listData.IsLanguageSelect = false;
            }

            if (listStruct.IsBrowserTermination == 1)
            {
                listData.IsBrowserTerminate = true;
            }

            else if (listStruct.IsBrowserTermination == 0)
            {
                listData.IsBrowserTerminate = false;
            }

            if (listStruct.IsDataAvailable == 1)
            {
                listData.IsDataPresent = true;
            }

            else if (listStruct.IsDataAvailable == 0)
            {
                listData.IsDataPresent = false;
            }

            if (listStruct.IsChannelStatus == 1)
            {
                listData.IsCnlStatus = true;
            }

            else if (listStruct.IsChannelStatus == 0)
            {
                listData.IsCnlStatus = false;
            }

            return listData;
        }

        internal static SatSendDtmfData ConvertSatSendDtmfStruct(SatSendDtmfDataStruct dtmfStruct)
        {
            SatSendDtmfData dtmfData = new SatSendDtmfData();
            dtmfData.Id = dtmfStruct.CommandId;
            if (dtmfStruct.IsHiddenMode == 1)
            {
                dtmfData.IsHidden = true;
            }

            else if (dtmfStruct.IsHiddenMode == 0)
            {
                dtmfData.IsHidden = false;
            }

            dtmfData.Dtmf = ConvertSatTextInfoStruct(dtmfStruct.DtmfString);
            return dtmfData;
        }

        internal static SatCallCtrlData ConvertSatCallCtrlIndCallSsDataStruct(SatCallCtrlIndCallSsDataStruct dataStruct)
        {
            SatCallCtrlData data = new SatCallCtrlData();
            data.Addr = ConvertSatTextInfoStruct(dataStruct.Address);
            data.SubAddr = ConvertSatTextInfoStruct(dataStruct.SubAddress);
            data.RepeatIndicator = dataStruct.BcRepeatIndicator;
            data.Ccparam1 = ConvertSatTextInfoStruct(dataStruct.Ccp1);
            data.Ccparam2 = ConvertSatTextInfoStruct(dataStruct.Ccp2);
            return data;
        }

        internal static SatCallCtrlConfirmData ConvertSatCallCtrlIndDataStruct(SatCallCtrlIndDataStruct dataStruct)
        {
            SatCallCtrlConfirmData data = new SatCallCtrlConfirmData();
            data.Type = dataStruct.CallCtrlCnfType;
            data.Result = dataStruct.CallCtrlResult;
            data.Data = ConvertSatTextInfoStruct(dataStruct.DisplayData);
            if (dataStruct.IsUserInfoDispEnabled == 1)
            {
                data.IsUserInfoEnabled = true;
            }

            else if (dataStruct.IsUserInfoDispEnabled == 0)
            {
                data.IsUserInfoEnabled = false;
            }

            if (dataStruct.CallCtrlCnfType == SatCallType.MoVoice)
            {
                data.CallData = ConvertSatCallCtrlIndCallSsDataStruct(dataStruct.CallCtrlIndData.CallCtrlCnfCallData);
            }

            else if (dataStruct.CallCtrlCnfType == SatCallType.Ss)
            {
                data.SsData = ConvertSatCallCtrlIndCallSsDataStruct(dataStruct.CallCtrlIndData.CallCtrlCnfSsData);
            }

            else if (dataStruct.CallCtrlCnfType == SatCallType.Ussd)
            {
                data.Ussd = ConvertSatTextInfoStruct(dataStruct.CallCtrlIndData.CallCtrlCnfUssdData.UssdString);
            }

            return data;
        }

        internal static SatDataCodingScheme ConvertSatDataCodingSchemeStruct(SatDataCodingSchemeStruct dataStruct)
        {
            SatDataCodingScheme codingScheme = new SatDataCodingScheme();
            if (dataStruct.IsCompressedFormat == 1)
            {
                codingScheme.IsCompressed = true;
            }

            else if (dataStruct.IsCompressedFormat == 0)
            {
                codingScheme.IsCompressed = false;
            }

            codingScheme.Alphabet = dataStruct.AlphabetFormat;
            codingScheme.Msg = dataStruct.MsgClass;
            codingScheme.Dcs = dataStruct.RawDcs;
            return codingScheme;
        }

        internal static SatTextTypeInfo ConvertSatTextTypeInfoStruct(SatTextTypeInfoStruct infoStruct)
        {
            SatTextTypeInfo info = new SatTextTypeInfo();
            if (infoStruct.IsDigitOnly == 1)
            {
                info.IsDigit = true;
            }

            else if (infoStruct.IsDigitOnly == 0)
            {
                info.IsDigit = false;
            }

            info.CodingScheme = ConvertSatDataCodingSchemeStruct(infoStruct.Dcs);
            info.StringLen = infoStruct.StringLength;
            info.Text = infoStruct.TextString;
            return info;
        }

        internal static SatMoSmsCtrlData ConvertSatMoSmsCtrlDataStruct(SatMoSmsCtrlDataStruct dataStruct)
        {
            SatMoSmsCtrlData data = new SatMoSmsCtrlData();
            data.Result = dataStruct.Result;
            if (dataStruct.IsUserInfoDisplayEnabled == 1)
            {
                data.IsUserInfo = true;
            }

            else if (dataStruct.IsUserInfoDisplayEnabled == 0)
            {
                data.IsUserInfo = false;
            }

            data.Data = ConvertSatTextTypeInfoStruct(dataStruct.DisplayData);
            data.RpAddr = ConvertSatTextTypeInfoStruct(dataStruct.RpDestAddr);
            data.TpAddr = ConvertSatTextTypeInfoStruct(dataStruct.TpDestAddr);
            return data;
        }

        internal static SatSetupCallData ConvertSatSetupCallDataStruct(SatSetupCallDataStruct dataStruct)
        {
            SatSetupCallData callData = new SatSetupCallData();
            callData.Id = dataStruct.CommandId;
            callData.Type = dataStruct.CallType;
            callData.Text = ConvertSatTextInfoStruct(dataStruct.DisplayText);
            callData.Number = ConvertSatTextInfoStruct(dataStruct.CallNumber);
            callData.Duratn = dataStruct.Duration;
            callData.IcnId = ConvertSatIconIdentifierStruct(dataStruct.IconId);
            return callData;
        }

        internal static SatSendSsData ConvertSatSendSsDataStruct(SatSendSsDataStruct dataStruct)
        {
            SatSendSsData ssData = new SatSendSsData();
            ssData.Id = dataStruct.CommandId;
            ssData.NumType = dataStruct.Ton;
            ssData.Identity = dataStruct.Npi;
            ssData.StringLen = dataStruct.StringLength;
            ssData.Ss = dataStruct.SsString;
            return ssData;
        }

        internal static SatSetupUssdData ConvertSatSetupUssdDataStruct(SatSetupUssdDataStruct ussdStruct)
        {
            SatSetupUssdData ussdData = new SatSetupUssdData();
            ussdData.Id = ussdStruct.CommandId;
            ussdData.Dcs = ussdStruct.RawDcs;
            ussdData.StringLen = ussdStruct.UssdStringLength;
            ussdData.Ussd = ussdStruct.UssdString;
            return ussdData;
        }
    }
}
