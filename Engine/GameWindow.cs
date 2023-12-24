using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Engine {
    public class GameWindow : RenderWindow {
        public static uint WidthBounds { get => VideoMode.DesktopMode.Width; }
        public static uint HeightBounds { get => VideoMode.DesktopMode.Height; }

        public GameWindow(VideoMode mode, string title) : base(mode, title) {}
    };
};