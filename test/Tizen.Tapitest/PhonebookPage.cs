using System;
using Xamarin.Forms;
using Tizen;
using Tizen.Tapi;
using System.Collections.Generic;
using System.Linq;

namespace XamarinForTizen.Tizen
{
    public class PhonebookPage : ContentPage
    {
        Phonebook pb = null;
        TapiHandle handle = Globals.handleModem0;
        public PhonebookPage()
        {
            try
            {
                pb = new Phonebook(handle);
                handle.RegisterNotiEvent(Notification.PhonebookContactChange);
                handle.NotificationChanged += Handle_ContactChanged_NotiEvent;
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb constructor throws exception = " + ex.ToString());
            }

            var PhonebookInitInfoBtn = new Button
            {
                Text = "PhonebookInitInfo",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookInitInfoBtn.Clicked += PhonebookInitInfoBtn_Clicked;

            var PhonebookStorageBtn = new Button
            {
                Text = "Get Phonebook Storage",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookStorageBtn.Clicked += PhonebookStorageBtn_Clicked;

            var PhonebookMetaInfoBtn = new Button
            {
                Text = "Get Phonebook MetaInfo",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookMetaInfoBtn.Clicked += PhonebookMetaInfoBtn_Clicked;

            var PhonebookMetaInfo3GBtn = new Button
            {
                Text = "Get Phonebook MetaInfo3G",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookMetaInfo3GBtn.Clicked += PhonebookMetaInfo3GBtn_Clicked;

            var PhonebookReadRecordGBtn = new Button
            {
                Text = "Read Phonebook record",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookReadRecordGBtn.Clicked += PhonebookReadRecordGBtn_Clicked;

            var PhonebookUpdateRecordGBtn = new Button
            {
                Text = "Update Phonebook record",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookUpdateRecordGBtn.Clicked += PhonebookUpdateRecordGBtn_Clicked;

            var PhonebookDeleteRecordGBtn = new Button
            {
                Text = "Delete Phonebook record",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            PhonebookDeleteRecordGBtn.Clicked += PhonebookDeleteRecordGBtn_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        PhonebookInitInfoBtn, PhonebookStorageBtn, PhonebookMetaInfoBtn, PhonebookMetaInfo3GBtn,
                        PhonebookReadRecordGBtn, PhonebookUpdateRecordGBtn, PhonebookDeleteRecordGBtn
                    }
            };
        }

        private void Handle_ContactChanged_NotiEvent(object sender, NotificationChangedEventArgs e)
        {
            PhonebookContactChangeInfo info = (PhonebookContactChangeInfo)e.Data;
            Log.Debug(Globals.LogTag, "Pb contact change noti event received");
            Log.Debug(Globals.LogTag, "Pb Type: " + info.Type);
            Log.Debug(Globals.LogTag, "Pb index: " + info.Index);
            Log.Debug(Globals.LogTag, "Pb operation: " + info.Operation);
        }

        private async void PhonebookDeleteRecordGBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb delete record call start");
                bool b = await pb.DeletePhonebookRecord(PhonebookType.Usim, 1);
                if (b)
                {
                    Log.Debug(Globals.LogTag, "Pb record deleted successfully");
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb delete record exception: " + ex.ToString());
            }
        }

        private async void PhonebookUpdateRecordGBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb update record call start");
                PhonebookRecord pbRec = await pb.ReadPhonebookRecord(PhonebookType.Usim, 1);
                Log.Debug(Globals.LogTag, "Read record Index: " + pbRec.Index);
                Log.Debug(Globals.LogTag, "Read record Name: " + pbRec.Name);
                Log.Debug(Globals.LogTag, "Read record Number: " + pbRec.Number);
                PhonebookRecord rec = new PhonebookRecord();
                rec.Type = PhonebookType.Usim;
                rec.Index = 1;
                rec.Name = "NewName";
                rec.Number = "999999";
                bool b = await pb.UpdatePhonebookRecord(rec);
                if (b)
                {
                    Log.Debug(Globals.LogTag, "Pb record updated successfully");
                }

                PhonebookRecord pbUpdt = await pb.ReadPhonebookRecord(PhonebookType.Usim, rec.Index);
                Log.Debug(Globals.LogTag, "Updated record Name: " + pbUpdt.Name);
                Log.Debug(Globals.LogTag, "Updated record Number: " + pbUpdt.Number);
                Log.Debug(Globals.LogTag, "Updated update record call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb update record exception: " + ex.ToString());
            }
        }

        private async void PhonebookReadRecordGBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb read record call start");
                PhonebookRecord pbRec = await pb.ReadPhonebookRecord(PhonebookType.Usim, 1);
                Log.Debug(Globals.LogTag, "Type: " + pbRec.Type);
                Log.Debug(Globals.LogTag, "Index: " + pbRec.Index);
                Log.Debug(Globals.LogTag, "NextIndex: " + pbRec.NextIndex);
                Log.Debug(Globals.LogTag, "Name: " + pbRec.Name);
                Log.Debug(Globals.LogTag, "Dcs: " + pbRec.Dcs);
                Log.Debug(Globals.LogTag, "Number: " + pbRec.Number);
                Log.Debug(Globals.LogTag, "Ton: " + pbRec.Ton);
                Log.Debug(Globals.LogTag, "Anr1: " + pbRec.Anr1);
                Log.Debug(Globals.LogTag, "Anr1Ton: " + pbRec.Anr1Ton);
                Log.Debug(Globals.LogTag, "Anr2: " + pbRec.Anr2);
                Log.Debug(Globals.LogTag, "Anr2Ton: " + pbRec.Anr2Ton);
                Log.Debug(Globals.LogTag, "Anr3: " + pbRec.Anr3);
                Log.Debug(Globals.LogTag, "Anr3Ton: " + pbRec.Anr3Ton);
                Log.Debug(Globals.LogTag, "Email1: " + pbRec.Email1);
                Log.Debug(Globals.LogTag, "Email2: " + pbRec.Email2);
                Log.Debug(Globals.LogTag, "Email3: " + pbRec.Email3);
                Log.Debug(Globals.LogTag, "Email4: " + pbRec.Email4);
                Log.Debug(Globals.LogTag, "Group index: " + pbRec.GroupIndex);
                Log.Debug(Globals.LogTag, "Pbcontrol: " + pbRec.PbControl);

                Log.Debug(Globals.LogTag, "Pb read record call success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb read record exception: " + ex.ToString());
            }
        }

        private void PhonebookInitInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb init info call start");
                SimPhonebookStatus pbStatus = pb.GetPhonebookInitInfo();
                if (pbStatus == null)
                {
                    Log.Debug(Globals.LogTag, "pbStatus is null");
                    return;
                }

                Log.Debug(Globals.LogTag, "pbStatus.isinitcompleted: " + pbStatus.IsInitCompleted);
                Log.Debug(Globals.LogTag, "pbStatus.pblist: " + pbStatus.PbList.Fdn + " " + pbStatus.PbList.Adn + " " + pbStatus.PbList.Sdn + " " + pbStatus.PbList.Usim + " " + pbStatus.PbList.Aas + " " + pbStatus.PbList.Gas);
                Log.Debug(Globals.LogTag, "Pb init info call success");
            }

            catch(Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb get init info exception: " + ex.ToString());
            }
        }

        private async void PhonebookMetaInfoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb get meta info call start");
                foreach (PhonebookType type in Enum.GetValues(typeof(PhonebookType)))
                {
                    if (type == PhonebookType.Unknown)
                    {
                        break;
                    }

                    PhonebookMetaInfo info = await pb.GetPhonebookMetaInfo(type);
                    if (info == null)
                    {
                        Log.Debug(Globals.LogTag, "Pb meta info for " + type.ToString() + "is null");
                        continue;
                    }

                    Log.Debug(Globals.LogTag, "Pb meta type for " + type.ToString() + ": " + info.Type);
                    Log.Debug(Globals.LogTag, "Pb min index for " + type.ToString() + ": " + info.MinIndex);
                    Log.Debug(Globals.LogTag, "Pb max index for " + type.ToString() + ": " + info.MaxIndex);
                    Log.Debug(Globals.LogTag, "Pb max number length for " + type.ToString() + ": " + info.NumberMaxLength);
                    Log.Debug(Globals.LogTag, "Pb max text length for " + type.ToString() + ": " + info.TextMaxLength);
                    Log.Debug(Globals.LogTag, "Pb used count for " + type.ToString() + ": " + info.UsedCount);
                }

                Log.Debug(Globals.LogTag, "Pb get meta info success");
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb get meta info exception: " + ex.ToString());
            }
        }

        private async void PhonebookStorageBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (PhonebookType type in Enum.GetValues(typeof(PhonebookType)))
                {
                    if (type == PhonebookType.Unknown)
                    {
                        break;
                    }

                    Log.Debug(Globals.LogTag, "Pb get storage start");
                    PhonebookStorageInfo info = await pb.GetPhonebookStorage(type);
                    Log.Debug(Globals.LogTag, "Pb get storage success");
                    if (info == null)
                    {
                        Log.Debug(Globals.LogTag, "Pb storage info for " + type.ToString() + "is null");
                        continue;
                    }

                    Log.Debug(Globals.LogTag, "Pb storage type for " + type.ToString() + ": " + info.Type);
                    Log.Debug(Globals.LogTag, "Pb total record for " + type.ToString() + ": " + info.TotalRecord);
                    Log.Debug(Globals.LogTag, "Pb used record for " + type.ToString() + ": " + info.UsedRecord);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb get storage info exception: " + ex.ToString());
            }
        }

        private async void PhonebookMetaInfo3GBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                Log.Debug(Globals.LogTag, "Pb get meta info 3G start");
                PhonebookMetaInfo3G info = await pb.GetPhonebookMetaInfo3G();
                Log.Debug(Globals.LogTag, "Pb get meta info 3G success");
                if (info == null)
                {
                    Log.Debug(Globals.LogTag, "Pb meta info 3G is null");
                    return;
                }

                Log.Debug(Globals.LogTag, "Pb file type count: " + info.FileTypeCount);
                List<FileTypeCapabilityInfo3G> infoList = new List<FileTypeCapabilityInfo3G>();
                if (infoList == null)
                {
                    Log.Debug(Globals.LogTag, "File type info list is null");
                    return;
                }

                infoList = info.FileTypeInfo.ToList();
                for (int i = 0; i < info.FileTypeCount; i++)
                {
                    Log.Debug(Globals.LogTag, "capa.FileTypeInfo[" + i + "].FileType: " + infoList[i].FileType);
                    Log.Debug(Globals.LogTag, "capa.FileTypeInfo[" + i + "].MaxIndex: " + infoList[i].MaxIndex);
                    Log.Debug(Globals.LogTag, "capa.FileTypeInfo[" + i + "].TextMaxLength: " + infoList[i].TextMaxLength);
                    Log.Debug(Globals.LogTag, "capa.FileTypeInfo[" + i + "].UsedCount: " + infoList[i].UsedCount);
                }
            }

            catch (Exception ex)
            {
                Log.Debug(Globals.LogTag, "Pb get meta info 3G exception: " + ex.ToString());
            }
        }

        ~PhonebookPage()
        {
            handle.DeregisterNotiEvent(Notification.PhonebookContactChange);
            handle.NotificationChanged -= Handle_ContactChanged_NotiEvent;
        }
    }
}
