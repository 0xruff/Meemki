using System;
using System.Windows;

namespace Meemki.Model
{
    public class PositionedChar
    {
        public Point Position { get; private set; }
        public char Char { get; private set; }

        public PositionedChar(Point position, char easciiChar)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }
            Position = position;

            //TODO: Check for CP850 chars!
            if (easciiChar > 0xFF)
            {
                throw new ArgumentException("Char is not in the (extended) ASCII range!");
            }
            Char = easciiChar;
        }
    }
}
