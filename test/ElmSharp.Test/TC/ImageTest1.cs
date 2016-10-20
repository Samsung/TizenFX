using System;
using System.IO;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class ImageTest1 : TestCaseBase
    {
        public override string TestName => "ImageTest1";
        public override string TestDescription => "To test basic operation of Image";

        Image image;
        Label lbInfo;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window);
            conformant.SetContent(box);
            box.Show();

            Box buttonBox1 = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox1.Show();

            Box buttonBox2 = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox2.Show();

            Button btnFile1 = new Button(window)
            {
                Text = "File1",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile1.Show();

            Button btnFile2 = new Button(window)
            {
                Text = "File2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFile2.Show();

            Button btnUri1 = new Button(window)
            {
                Text = "Uri",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnUri1.Show();

            Button btnStream1 = new Button(window)
            {
                Text = "Strm",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnStream1.Show();

            buttonBox1.PackEnd(btnFile1);
            buttonBox1.PackEnd(btnFile2);
            buttonBox1.PackEnd(btnUri1);
            buttonBox1.PackEnd(btnStream1);


            Button btnFileAsync1 = new Button(window)
            {
                Text = "FileA1",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFileAsync1.Show();

            Button btnFileAsync2 = new Button(window)
            {
                Text = "FileA2",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnFileAsync2.Show();

            Button btnUriAsync1 = new Button(window)
            {
                Text = "UriA",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnUriAsync1.Show();

            Button btnStreamAsync1 = new Button(window)
            {
                Text = "StrmA",
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            btnStreamAsync1.Show();

            buttonBox2.PackEnd(btnFileAsync1);
            buttonBox2.PackEnd(btnFileAsync2);
            buttonBox2.PackEnd(btnUriAsync1);
            buttonBox2.PackEnd(btnStreamAsync1);


            lbInfo = new Label(window)
            {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1
            };
            lbInfo.Show();

            image = new Image(window)
            {
                IsFixedAspect = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            image.Show();
            image.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            image.Clicked += (s, e) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true ? false : true;
            };

            btnFile1.Clicked += (s, e) => LoadFile("TED/large/a.jpg");
            btnFile2.Clicked += (s, e) => LoadFile("TED/large/b.jpg");
            btnUri1.Clicked += (s, e) => LoadUri("http://pe.tedcdn.com/images/ted/2e306b9655267cee35e45688ace775590b820510_615x461.jpg");
            btnStream1.Clicked += (s, e) => LoadStream(new FileStream(Path.Combine(TestRunner.ResourceDir, "TED/large/c.jpg"), FileMode.Open));

            btnFileAsync1.Clicked += (s, e) => LoadFileAsync("TED/large/d.jpg");
            btnFileAsync2.Clicked += (s, e) => LoadFileAsync("TED/large/e.jpg");
            btnUriAsync1.Clicked += (s, e) => LoadUriAsync("http://pe.tedcdn.com/images/ted/2e306b9655267cee35e45688ace775590b820510_615x461.jpg");
            btnStreamAsync1.Clicked += (s, e) => LoadStreamAsync(new FileStream(Path.Combine(TestRunner.ResourceDir, "TED/large/f.jpg"), FileMode.Open));
            box.PackEnd(buttonBox1);
            box.PackEnd(buttonBox2);
            box.PackEnd(lbInfo);
            box.PackEnd(image);
        }

        void LoadFile(string file)
        {
            bool ret = image.Load(Path.Combine(TestRunner.ResourceDir, file));
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void LoadUri(string uri)
        {
            bool ret = image.Load(uri);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void LoadStream(Stream stream)
        {
            bool ret = image.Load(stream);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadFileAsync(string file)
        {
            var ret = await image.LoadAsync(Path.Combine(TestRunner.ResourceDir, file));
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadUriAsync(string uri)
        {
            var ret = await image.LoadAsync(uri);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadStreamAsync(Stream stream)
        {
            var ret = await image.LoadAsync(stream);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void UpdateLabelText(Label lable, string text)
        {
            lable.Text = "<span color=#ffffff font_size=20>" + text + "</span>";
        }
    }
}
