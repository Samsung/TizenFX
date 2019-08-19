

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using tlog = Tizen.Log;

namespace Tizen.TV.NUI.Example
{
    public class AtspiTest : IExample
    {
        View view;
        const string tag = "NUITEST";

        public void Activate()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = Color.Green;

            guide = new TextLabel();
            guide.Position = new Position(100, 100, 0);
            guide.MultiLine = true;
            guide.PointSize = 30.0f;
            guide.Text = "dali-atspi test\n" +
                            "Return Key: stop Say().\n" +
                            "Up Key: Say() script3. discardable=false.\n" +
                            "Right Key: Say() script1.\n" +
                            "Down Key: Say() repeat infinitely.\n" +
                            "Left Key: Say() script2.";

            Window.Instance.GetDefaultLayer().Add(guide);

            view = new View();
            view.Size2D = new Size2D(100, 100);
            view.Position2D = new Position2D(700, 700);
            view.BackgroundColor = Color.Red;
            Window.Instance.GetDefaultLayer().Add(view);

            view.KeyEvent += OnKeyPressed;
            view.Focusable = true;
            FocusManager.Instance.SetCurrentFocusView(view);

            //var accessbilityStatus = NDalicPINVOKE.accessibility_get_status(View.getCPtr(view));
            //Tizen.Log.Fatal("NUITEST", $"accessbilityStatus={accessbilityStatus}");
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
        }

        private TextLabel guide;

        string testScript1 = "�ȳ��ϼ���. �޸� ����Ƽ�����Ǿ��� �׽�Ʈ �Դϴ�. ������Ű�� ������ �����̰� ������Ű�� ������ �����Դϴ�. " +
            "Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved PROPRIETARY / CONFIDENTIAL " +
            "This software is the confidential and proprietary information of SAMSUNG ELECTRONICS(Confidential Information). " +
            "You shall not disclose such Confidential Information and shall use it only in accordance with the terms of the license agreement " +
            "you entered into with SAMSUNG ELECTRONICS.SAMSUNG make no representations or warranties about the suitability of the software, " +
            "either express or implied, including but not limited to the implied warranties of merchantability, fitness for a particular purpose, " +
            "or non-infringement.SAMSUNG shall not be liable for any damages suffered by licensee as a result of using, modifying or distributing " +
            "this software or its derivatives.";

        const string testScript2 = "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 1 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 2 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 3 " +
            "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 4 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 5 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 6 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 7 " +
            "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 8 �̰� ���� �׽�Ʈ �Դϴ�. �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 9 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 10 " +
            "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 11 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 12 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 13 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 14 " +
            "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 15 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 16 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 17 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 18 " +
            "�̰� ���� �׽�Ʈ �Դϴ�. This is Say test 19 �̰� ���� �׽�Ʈ �Դϴ�. This is Say test 20";

        const string testScript3 = "Say another test 1 Say another test 2 Say another test 3 Say another test 4 Say another test 5";

        bool repeatFlag = false;
        private bool OnKeyPressed(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                tlog.Fatal(tag, $"KeyPressedName={e.Key.KeyPressedName}");
                //var accessbilityStatus = NDalicPINVOKE.accessibility_get_status(View.getCPtr(view));
                if (e.Key.KeyPressedName == "Return")
                {
                    Accessibility.Instance.SayFinished -= Instance_SayFinished;
                    Accessibility.Instance.Say("", true);
                    repeatFlag = false;
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    Accessibility.Instance.Say(testScript1, true);
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    Accessibility.Instance.Say(testScript2, true);
                }
                else if (e.Key.KeyPressedName == "Up")
                {
                    Accessibility.Instance.Say(testScript3, true);
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    repeatFlag = true;
                    Accessibility.Instance.SayFinished += Instance_SayFinished;
                    Accessibility.Instance.Say("my name is say api !!!", true);
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    Accessibility.Instance.PauseResume(true);
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    Accessibility.Instance.PauseResume(false);
                }
            }
            return false;
        }

        private void Instance_SayFinished(object sender, Accessibility.SayFinishedEventArgs e)
        {
            tlog.Fatal(tag, $"Instance_SayFinished()! State={e.State}");
            if (e.State == Accessibility.SayFinishedStates.Stopped)
            {
                Accessibility.Instance.Say("�̰� �ݹ� �׽�Ʈ �Դϴ�. this is callback test!  �ݹ��� ������ Ȯ��Ű�� ��������. to remove callback please push Return key", true);
            }
        }

        public void Deactivate()
        {
        }
    }
}
