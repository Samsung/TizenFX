using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using l = Tizen.Log;
    class Program : IExample
    {
        const string t = "NUITEST";
        TextLabel v1, v2, v3;
        Window win;
        NativeImageSource nis;
        byte[] buff;
        public void Activate()
        {
            win = Window.Instance;
            win.BackgroundColor = Color.Green;
            win.KeyEvent += Window_KeyEvent;

            nis = new NativeImageSource(123, 156, NativeImageSource.ColorDepth.Bits32);

            buff = new byte[100];
            for(int i = 0; i < 100; i++)
            {
                buff[i] = (byte)(100 - i);
            }

            l.Fatal(t, $"### buff [0]={buff[0]}, [10]={buff[10]}, [50]={buff[50]}, [99]={buff[99]}");

            int width = 234, height = 567, stride = 1;
            var ret = nis.Acquire(buff, ref width, ref height, ref stride);
            l.Fatal(t, $"### after Acquire ret={ret} width={width}, height={height}, stride={stride}");
            ret = nis.Release();
            l.Fatal(t, $"### after Release ret={ret} width={width}, height={height}, stride={stride}");

            Texture mNativeTexture = new Texture(nis);
            TextureSet textureSet = new TextureSet();
            textureSet.SetTexture(0u, mNativeTexture);
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                l.Fatal(t, $"Window_KeyEvent() key:{e.Key.KeyPressedName}");
                switch (e.Key.KeyPressedName)
                {
                    case "1":
                        nis.Dispose();
                        nis = null;
                        break;
                    case "2":
                        nis = new NativeImageSource(200, 200, NativeImageSource.ColorDepth.Bits32);
                        Texture txt = new Texture(nis);
                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                }
            }
        }
    }
}
