using System;

namespace Engine.ValueObjects {
    public struct Vertex2D {
        public int X, Y;

        public Vertex2D(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }
    }
}