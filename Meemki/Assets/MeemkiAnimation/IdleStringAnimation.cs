using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets.MeemkiAnimation
{
    public class IdleStringAnimation : IStringAnimation
    {
        private string IdlePose1 =
            @"  O" + '\x0' +
            @" /|\" + '\x0' +
            @"  |" + '\x0' +
            @" / \" + '\x0' +
            @"Ì   Ì";

        public List<StringFrame> StringFramePoses { get; private set; }
        public bool IsLockingAnimation { get; private set; }

        public IdleStringAnimation()
        {
            IsLockingAnimation = false;
            StringFramePoses = new List<StringFrame>()
            {
                new StringFrame(1, IdlePose1, 0)
            };
        }
    }
}
