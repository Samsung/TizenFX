using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;
using Tizen.NUI.Scene3D;
using System.Collections.Generic;
using Tizen.AIAvatar;

using NetMQ;
using System.Threading;
using System.Threading.Tasks;
using NetMQ.Sockets;
using Xunit;
using Xunit.Abstractions;

public class AvatarMotionTracker
{
    private const uint TimerTime = 30;
    private Avatar avatar;
    private Tizen.NUI.Timer TrackingTimer;

    private bool thread_live = true;
    private Thread mq;
    private float[] motionRadian = new float[12];

    public AvatarMotionTracker(Avatar avatar)
    {
        this.avatar = avatar;
        StartMotionTracking();
    }

    private void StartMotionTracking()
    {
        mq = new Thread(new ThreadStart(Run));
        mq.Start();

        PlayOverlayTimer();

    }

    public void PlayOverlayTimer()
    {
        TrackingTimer = new Tizen.NUI.Timer(TimerTime);
        TrackingTimer.Tick += (s, e) =>
        {
            SetAvatarMotionData();
            return true;
        };
        TrackingTimer.Start();
    }

    private void SetAvatarMotionData()
    {
        avatar.SetMotionData(CreateMotionData("l_arm_JNT", motionRadian[0], motionRadian[1], motionRadian[2]));
        avatar.SetMotionData(CreateMotionData("l_forearm_JNT", motionRadian[3], motionRadian[4], motionRadian[5]));
        avatar.SetMotionData(CreateMotionData("r_arm_JNT", motionRadian[6], motionRadian[7], motionRadian[8]));
        avatar.SetMotionData(CreateMotionData("r_forearm_JNT", motionRadian[9], motionRadian[10], motionRadian[11]));
    }

    private MotionData CreateMotionData(string keyValue, float pitch, float yaw, float roll)
    {
        var motionData = new MotionData();
        motionData.Add(
            new MotionTransformIndex()
            {
                //ModelNodeId = new PropertyKey("Skeleton_arm_joint_R__2_"),
                ModelNodeId = new PropertyKey(keyValue),
                TransformType = MotionTransformIndex.TransformTypes.Orientation,
            },
            new MotionValue()
            {
                PropertyValue = new PropertyValue(new Rotation(new Radian(pitch), new Radian(yaw), new Radian(roll))),
            }
        );
        return motionData;
    }

    private void Run()
    {
        using (var server = new ResponseSocket())
        {
            server.Bind("tcp://*:5556");
            try
            {
                while(thread_live)
                {
                    string msg = server.ReceiveFrameString();
                    Console.WriteLine("From Client: {0}", msg);
                    server.SendFrame("ACK");
                    string[] words = msg.Split(' ');
                    int i = 0;
                    foreach (var token in words)
                    {
                        Console.WriteLine("From Server: {0} : {1}", i, token);
                        motionRadian[i] = float.Parse(token);
                        i++;
                    }
                }
            }
            catch(ThreadAbortException abortException)
            {
                Console.WriteLine((string)abortException.ExceptionState);
            }
        }
    }
}

