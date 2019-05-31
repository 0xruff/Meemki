using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets.MeemkiAnimation
{
    public class WaveStringAnimation : IStringAnimation
    {
        private string WavePose1 =
            @"  O_" + '\x0' +
            @" /|" + '\x0' +
            @"  |" + '\x0' +
            @" / \" + '\x0' +
            @"Ì   Ì";

        private string WavePose2 =
            @"  O/" + '\x0' +
            @" /|" + '\x0' +
            @"  |" + '\x0' +
            @" / \" + '\x0' +
            @"Ì   Ì";

        private string WavePose3 =
            @"  O_" + '\x0' +
            @" /|" + '\x0' +
            @"  |" + '\x0' +
            @" / \" + '\x0' +
            @"Ì   Ì";

        public List<StringFrame> StringFramePoses { get; private set; }
        public bool IsLockingAnimation { get; private set; }

        public WaveStringAnimation()
        {
            IsLockingAnimation = false;
            StringFramePoses = new List<StringFrame>()
            {
                new StringFrame(1, WavePose1, 0),
                new StringFrame(2, WavePose2, 0),
                new StringFrame(3, WavePose3, 0)
            };
        }
    }
}
