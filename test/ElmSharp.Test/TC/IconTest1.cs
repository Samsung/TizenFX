using System;
using ElmSharp;
using System.Collections.Generic;

namespace ElmSharp.Test
{
    public class IconTest1 : TestCaseBase
    {
        public override string TestName => "IconTest1";
        public override string TestDescription => "To test basic operation of Icon";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Scroller scroller = new Scroller(window);
            scroller.Show();
            conformant.SetContent(scroller);
            Box box = new Box(window);
            box.Show();
            scroller.SetContent(box);

            List<string> iconList = new List<string>{ "home", "close", "apps", "arrow_up", "arrow_down", "arrow_left", "arrow_right", "chat", "clock", "delete", "edit", "refresh", "folder", "file",
                "menu/home", "menu/close", "menu/apps", "menu/arrow_up", "menu/arrow_down", "menu/arrow_left", "menu/arrow_right", "menu/chat", "menu/clock", "menu/delete", "menu/edit", "menu/refresh", "menu/folder",
                "menu/file", "media_player/forward", "media_player/info", "media_player/next", "media_player/pause", "media_player/play", "media_player/prev", "media_player/rewind", "media_player/stop"};

            foreach (var iconName in iconList)
            {
                Label label = new Label(window)
                {
                    Text = iconName,
                };
                Icon icon = new Icon(window)
                {
                    IconLookupOrder = IconLookupOrder.ThemeFirst,
                    StandardIconName = iconName,
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    MinimumHeight = 100,
                    MinimumWidth = 100,
                };
                icon.Show();
                label.Show();
                box.PackEnd(icon);
                box.PackEnd(label);
            }

            
        }
    }
}
