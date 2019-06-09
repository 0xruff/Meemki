using System;
using System.Windows;
using Meemki.Logic;

namespace Meemki.Model
{
    public class PositionedChar
    {
        public Point Position { get; private set; }
        public char Char { get; private set; }

        public PositionedChar(Point position, char inputChar)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }
            Position = position;

            CodePageEnsurer.EnsureLegitCP850(inputChar);
            Char = inputChar;
        }
    }
}
