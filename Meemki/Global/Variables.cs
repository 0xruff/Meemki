using System;
using Meemki.Interface;

namespace Meemki.Global
{
    static class Variables
    {
        //General
        public static int HorizontalLimitRight { get; } = Console.LargestWindowWidth;
        public static int MeemkiWidth { get; } = 5;
        public static IControllable PlayerControlledEntity { get; set; }

        //Animations
        public static bool AnimationLock { get; set; } = false;
        public static Model.AnimationEnum LockedAnimation { get; set; } = Model.AnimationEnum.Idle;
    }
}
