using System;

namespace Meemki.Model
{
    public class MeemkiPosition
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = (Console.BufferHeight / 2) + 10; //TODO: Put into global variables or something
    }
}
