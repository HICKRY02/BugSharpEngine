using System;
using Engine;
using Engine.ValueObjects;
using SFML;
using SFML.Graphics;
using SFML.Window;

class Program {
    static void Main() {
        // Console.Clear();

        GameWindow gameWindow = new GameWindow(new VideoMode(800, 600), "BugSharpEngine");

        gameWindow.Closed += (sender, e) => gameWindow.Close();

        uint width, height;
        width = gameWindow.Size.X;
        height = gameWindow.Size.Y;

        Image screenBuffer = new Image(width, height);
        Texture texture = new Texture(screenBuffer);
        Sprite sprite = new Sprite();
        
        Vertex2D[] vertexs = new Vertex2D[] { new Vertex2D() { X = 0, Y = 0 }, new Vertex2D() { X = 799, Y = 599 } };
        Vertex2D[] line;
        Color[] colors;

        byte[] startColor = new byte[] { 255, 100, 0 };
        byte[] endColor = new byte[] { 0, 200, 255 };

        while (gameWindow.IsOpen) {
            gameWindow.DispatchEvents();

            for (byte i = 0; i < vertexs.Length; i++) {
                if (vertexs[i].X == 0)
                    if (vertexs[i].Y == 599)
                        vertexs[i].X++;
                    else 
                        vertexs[i].Y++;
                else if (vertexs[i].Y == 599)
                    if (vertexs[i].X == 799)
                        vertexs[i].Y--;
                    else
                        vertexs[i].X++;
                else if (vertexs[i].X == 799)
                    if (vertexs[i].Y == 0)
                        vertexs[i].X--;
                    else
                        vertexs[i].Y--;
                else
                    vertexs[i].X--;
            }

            line = Render.LineDrawAlgorithm(vertexs[0].X, vertexs[0].Y, vertexs[1].X, vertexs[1].Y);          
            colors = new Color[line.Length];

            double dR = (endColor[0] - startColor[0]) / (double)line.Length;
            double dG = (endColor[1] - startColor[1]) / (double)line.Length;
            double dB = (endColor[2] - startColor[2]) / (double)line.Length;

            for (int i = 0; i < colors.Length; i++) {
                colors[i] = new Color((byte)(startColor[0] + dR * i), (byte)(startColor[1] + dG * i), (byte)(startColor[2] + dB * i));
            }

            gameWindow.Clear();
            screenBuffer = new Image(width, height);

            for (int i = 0; i < line.Length; i++) {
                screenBuffer.SetPixel((uint)line[i].X, (uint)line[i].Y, colors[i]);
            }

            texture.Update(screenBuffer);
            sprite.Texture = texture;
            gameWindow.Draw(sprite);
            gameWindow.Display();
        };
    }
}