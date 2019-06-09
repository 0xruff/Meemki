using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Meemki.Global;
using Meemki.Keyboard;

namespace Meemki
{
    class Program
    {
        static class FullScreenHandler
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct _COORD
            {
                public short X;
                public short Y;

                public _COORD(short x, short y)
                {
                    X = x;
                    Y = y;
                }
            };

            [DllImport("kernel32.dll")]
            public static extern IntPtr
                GetStdHandle(int nStdHandle);

            [DllImport("kernel32.dll")]
            public static extern bool
                SetConsoleDisplayMode(IntPtr
                hConsoleOutput, uint dwFlags, out _COORD lpNewScreenBufferDimensions);
        }

        static void Main(string[] args)
        {
            //LOADING SCREEN + MEMORY-CONSOLE SETUP
            Setup();

            //MEEMKI SETUP
            Model.Meemki meemki = new Model.Meemki();

            //PLAYER CONTROLLED ENTITY SETUP
            Global.Variables.PlayerControlledEntity = meemki;

            //LVL SETUP
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                MemorizableConsole.Write('I', i, ((Console.BufferHeight / 2) + 10) + 4, ConsoleColor.DarkCyan);
            }
            MemorizableConsole.Write(">>> PRESS THE RIGHT-ARROW TO RUN FORWARD >>>", 10, ((Console.BufferHeight / 2) + 10) + 2, ConsoleColor.Magenta);
            MemorizableConsole.Write("^^^ PRESS THE UP-ARROW TO JUMP ^^^", 70, ((Console.BufferHeight / 2) + 7) + 2, ConsoleColor.Magenta);

            //MAINLOOP
            while (true)
            {
                if (Global.Variables.AnimationLock)
                {
                    Global.Variables.PlayerControlledEntity.Animate(Global.Variables.LockedAnimation);
                }
                else
                {
                    if (FasterKeyboard.IsKeyDown(KeyCode.Left))
                    {
                        if (FasterKeyboard.IsKeyDown(KeyCode.Up))
                        {
                            Global.Variables.PlayerControlledEntity.Animate(Model.AnimationEnum.JumpLeft);
                        }
                        else
                        {
                            Global.Variables.PlayerControlledEntity.Animate(Model.AnimationEnum.RunLeft);
                        }
                    }
                    else if (FasterKeyboard.IsKeyDown(KeyCode.Right))
                    {
                        if (FasterKeyboard.IsKeyDown(KeyCode.Up))
                        {
                            Global.Variables.PlayerControlledEntity.Animate(Model.AnimationEnum.JumpRight);
                        }
                        else
                        {
                            Global.Variables.PlayerControlledEntity.Animate(Model.AnimationEnum.RunRight);
                        }
                    }
                    else if (FasterKeyboard.IsKeyDown(KeyCode.Up))
                    {

                    }
                    else if (FasterKeyboard.IsKeyDown(KeyCode.Down))
                    {

                    }
                    else
                    {
                        Global.Variables.PlayerControlledEntity.Animate(Model.AnimationEnum.Idle);
                    }
                }
            }
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleDisplayMode(IntPtr hConsoleOutput, uint dwFlags, out _COORD lpNewScreenBufferDimensions);

        [StructLayout(LayoutKind.Sequential)]
        public struct _COORD
        {
            public short X;
            public short Y;

            public _COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        };

        static void Setup()
        {
            _COORD coord = new _COORD();
            SetConsoleDisplayMode(GetStdHandle(-11), 1, out coord);

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            Task initTask = Task.Run(() => MemorizableConsole.Init(Console.BufferWidth, Console.BufferHeight));

            System.Threading.Thread.Sleep(500);
            new Logic.IntroPlayer().ShowIntro();

            string loading = "LOADING CONSOLE............. ";
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)(Console.LargestWindowWidth / 2) - 14, (int)(Console.LargestWindowHeight / 2) + 12);
            Console.Write(loading);

            initTask.Wait();

            string pressAny = "PRESS [ENTER] TO CONTINUE... ";
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)(Console.LargestWindowWidth / 2) - 14, (int)(Console.LargestWindowHeight / 2) + 12);
            Console.Write(pressAny);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
