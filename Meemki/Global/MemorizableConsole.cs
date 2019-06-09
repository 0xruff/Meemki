using System;
using System.Collections.Generic;
using System.Linq;
using Meemki.Model;
using System.Windows;
using Meemki.Logic;

namespace Meemki.Global
{
    public static class MemorizableConsole
    {
        //TODO: USE ARRAY FOR PERFORMANCE + ALSO STORE COLOR!
        private static List<PositionedChar> memory = new List<PositionedChar>();

        public static void Write(char c, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            CodePageEnsurer.EnsureLegitCP850(c);

            IEnumerable<PositionedChar> toReplace = memory.Where(ch => ch.Position.X == x && ch.Position.Y == y);
            if (toReplace != null && toReplace.Count() == 1)
            {
                memory.Remove(toReplace.First());
            }

            //Write to memory
            memory.Add(new PositionedChar(new Point(x, y), c));

            //Write to screen
            ConsoleColor before = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.ForegroundColor = before;
        }

        public static void Write(string s, int startLeft, int startTop, ConsoleColor color = ConsoleColor.White)
        {
            CodePageEnsurer.EnsureLegitCP850(s);

            foreach (char c in s)
            {
                IEnumerable<PositionedChar> toReplace = memory.Where(ch => ch.Position.X == startLeft && ch.Position.Y == startTop);
                if (toReplace != null && toReplace.Count() == 1)
                {
                    memory.Remove(toReplace.First());
                }

                //Write to memory
                memory.Add(new PositionedChar(new Point(startLeft, startTop), c));

                //Write to screen
                ConsoleColor before = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(startLeft, startTop);
                Console.Write(c);
                Console.ForegroundColor = before;

                startLeft++;
            }
        }

        private static void WriteOnlyToMemory(char c, int x, int y)
        {
            CodePageEnsurer.EnsureLegitCP850(c);

            IEnumerable<PositionedChar> toReplace = memory.Where(ch => ch.Position.X == x && ch.Position.Y == y);
            if (toReplace != null && toReplace.Count() == 1)
            {
                memory.Remove(toReplace.First());
            }

            //Write to memory
            memory.Add(new PositionedChar(new Point(x, y), c));
        }

        private static void WriteOnlyToMemoryWithoutReplacing_UNSAFE(char c, int x, int y)
        {
            CodePageEnsurer.EnsureLegitCP850(c);

            //Write to memory
            memory.Add(new PositionedChar(new Point(x, y), c));
        }

        public static void Clear()
        {
            memory.Clear();
            Init(Console.BufferWidth, Console.BufferHeight);
            Console.Clear();
        }

        public static char GetChar(int x, int y)
        {
            IEnumerable<PositionedChar> found = memory.Where(ch => ch.Position.X == x && ch.Position.Y == y);
            if (found != null && found.Count() == 1)
            {
                return found.First().Char;
            }
            throw new ArgumentException("Something went wrong during getting a character from memory-console");
        }

        public static void Init(int bufferWidth, int bufferHeight)
        {
            for (int x = 0; x < bufferWidth; x++)
            {
                for (int y = 0; y < bufferHeight; y++)
                {
                    WriteOnlyToMemoryWithoutReplacing_UNSAFE(' ', x, y);
                }
            }
        }
    }
}
