using System;
using Engine.ValueObjects;
using SFML.Graphics;

namespace Engine {
    public static class Render {
        public static Vertex2D[] LineDrawAlgorithm(int x1, int y1, int x2, int y2) {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;
            int err = dx - dy;

            List<Vertex2D> vertexs = new();

            while (true) {
                vertexs.Add(new Vertex2D(x1, y1));

                if (x1 == x2 && y1 == y2) 
                    return vertexs.ToArray();

                int e2 = 2 * err;
                if (e2 > -dy) {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx) {
                    err += dx;
                    y1 += sy;
                }
            };
        }
    }
}