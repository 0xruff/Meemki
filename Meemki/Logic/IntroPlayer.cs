using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Meemki.Logic
{
    public class IntroPlayer
    {
        public void ShowIntro()
        {
            Console.Clear();
            Version assemblyVers = Assembly.GetExecutingAssembly().GetName().Version;
            string buildDate______________ = Properties.Resources.BuildDate;

            //TODO: Move to file?
            string introText =
$"MMMMMMMM               MMMMMMMM  Version {assemblyVers}                                        kkkkkkkk             iiii  " + '\x0' +
$"M:::::::M             M:::::::M  Build Date {buildDate______________}                          k::::::k            i::::i " + '\x0' +
@"M::::::::M           M::::::::M  CP850 CMD GAME                                                k::::::k             iiii  " + '\x0' +
@"M:::::::::M         M:::::::::M                                                                k::::::k                   " + '\x0' +
@"M::::::::::M       M::::::::::M    eeeeeeeeeeee        eeeeeeeeeeee       mmmmmmm    mmmmmmm    k:::::k    kkkkkkkiiiiiii " + '\x0' +
@"M:::::::::::M     M:::::::::::M  ee::::::::::::ee    ee::::::::::::ee   mm:::::::m  m:::::::mm  k:::::k   k:::::k i:::::i " + '\x0' +
@"M:::::::M::::M   M::::M:::::::M e::::::eeeee:::::ee e::::::eeeee:::::eem::::::::::mm::::::::::m k:::::k  k:::::k   i::::i " + '\x0' +
@"M::::::M M::::M M::::M M::::::Me::::::e     e:::::ee::::::e     e:::::em::::::::::::::::::::::m k:::::k k:::::k    i::::i " + '\x0' +
@"M::::::M  M::::M::::M  M::::::Me:::::::eeeee::::::ee:::::::eeeee::::::em:::::mmm::::::mmm:::::m k::::::k:::::k     i::::i " + '\x0' +
@"M::::::M   M:::::::M   M::::::Me:::::::::::::::::e e:::::::::::::::::e m::::m   m::::m   m::::m k:::::::::::k      i::::i " + '\x0' +
@"M::::::M    M:::::M    M::::::Me::::::eeeeeeeeeee  e::::::eeeeeeeeeee  m::::m   m::::m   m::::m k:::::::::::k      i::::i " + '\x0' +
@"M::::::M     MMMMM     M::::::Me:::::::e           e:::::::e           m::::m   m::::m   m::::m k::::::k:::::k     i::::i " + '\x0' +
@"M::::::M               M::::::Me::::::::e          e::::::::e          m::::m   m::::m   m::::mk::::::k k:::::k   i::::::i" + '\x0' +
@"M::::::M               M::::::M e::::::::eeeeeeee   e::::::::eeeeeeee  m::::m   m::::m   m::::mk::::::k  k:::::k  i::::::i" + '\x0' +
@"M::::::M               M::::::M  ee:::::::::::::e    ee:::::::::::::e  m::::m   m::::m   m::::mk::::::k   k:::::k i::::::i" + '\x0' +
@"MMMMMMMM               MMMMMMMM    eeeeeeeeeeeeee      eeeeeeeeeeeeee  mmmmmm   mmmmmm   mmmmmmkkkkkkkk    kkkkkkkiiiiiiii" + '\x0' +
@"                                                                                                                          " + '\x0' +
@"==========================================================================================================================" + '\x0' +
@"                                                          0xCEFF                                                          " + '\x0' +
@"==========================================================================================================================";

            List<Model.PositionedChar> positionedChars = new List<Model.PositionedChar>();

            //TODO: What if the console is smaller? What's actually the smallest resolution constraint?
            int x = (Console.LargestWindowWidth / 2) - 61; //61 is half width of intro text
            int y = (Console.LargestWindowHeight / 2) - 10; //10 is half height of intro text
            foreach (char c in introText)
            {
                if (c == '\x0')
                {
                    y++;
                    x = (Console.LargestWindowWidth / 2) - 61;
                    continue;
                }

                positionedChars.Add(new Model.PositionedChar(new System.Windows.Point(x, y), c));
                x++;
            }

            Random r = new Random();

            Stopwatch sw = new Stopwatch();
            bool isNotAllPrinted = true;
            int timeInTicks = 1000;
            
            while (isNotAllPrinted)
            {
                sw.Start();
                //RANDOM APPROACH
                int randomIndex = r.Next(0, positionedChars.Count - 1);
                Model.PositionedChar current = positionedChars[randomIndex];
                Console.SetCursorPosition((int)current.Position.X, (int)current.Position.Y);
                if (current.Position.Y > (Console.LargestWindowHeight / 2) + 6)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.ForegroundColor = GetRandomConsoleColor();
                }
                Console.Write(current.Char);
                positionedChars.Remove(current);
                if (positionedChars.Count == 0)
                {
                    isNotAllPrinted = false;
                }
                while (sw.ElapsedTicks < timeInTicks)
                {
                }
                sw.Stop();
                sw.Reset();
            }
        }

        private static ConsoleColor GetRandomConsoleColor()
        {
            Random r = new Random();
            int[] numbers = new int[] { 2, 10, 10, 7, 10, 15 };
            int number = numbers[r.Next(numbers.Length)];

            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(number);
        }
    }
}

