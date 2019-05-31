using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets.MeemkiAnimation
{
    public class JumpRightStringAnimation : IStringAnimation
    {
        private string JumpPose1 =
            @"    O" + '\x0' +
            @"   /" + '\x0' +
            @" _/\" + '\x0' +
            @"`  /" + '\x0' +
            @"   Ì" + '\x0';

        private string JumpPose2 =
            @"   O" + '\x0' +
            @"  /" + '\x0' +
            @" _\" + '\x0' +
            @"`/" + '\x0' +
            @" Ì" + '\x0';

        private string JumpPose3 =
            @"   O" + '\x0' +
            @"  /_" + '\x0' +
            @" / /" + '\x0' +
            @"/  `" + '\x0' +
            @"Ì" + '\x0';

        private string JumpPose4 =
            @" O_"  + '\x0' +
            @"/_" + '\x0' +
            @"  \"  + '\x0' +
            @"   `" + '\x0';

        private string JumpPose5 =
            @" O_" + '\x0' +
            @"/  " + '\x0' +
            @"\  " + '\x0' +
            @" \ " + '\x0' +
            @"  `" + '\x0';

        private string JumpPose6 =
            @" O" + '\x0' +
            @"/\" + '\x0' +
            @"\" + '\x0' +
            @"/" + '\x0' +
            @"Ì" + '\x0';

        public List<StringFrame> StringFramePoses { get; private set; }
        public bool IsLockingAnimation { get; private set; }

        public JumpRightStringAnimation()
        {
            IsLockingAnimation = true;
            StringFramePoses = new List<StringFrame>()
            {
                new StringFrame(1, JumpPose1, 1, 0),
                new StringFrame(2, JumpPose2, 2, 0),
                new StringFrame(3, JumpPose3, 1, 0),
                new StringFrame(4, JumpPose4, 3, -1, 100),
                new StringFrame(5, JumpPose5, 3, 0, 100),
                new StringFrame(6, JumpPose6, 3, 1, 150)
            };
        }
    }
}
