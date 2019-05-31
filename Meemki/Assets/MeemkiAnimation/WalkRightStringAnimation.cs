using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets.MeemkiAnimation
{
    public class WalkRightStringAnimation : IStringAnimation
    {
        private string WalkingPose1 =
            @"   O" + '\x0' +
            @"  /" + '\x0' +
            @" /\" + '\x0' +
            @"/ |" + '\x0' +
            @"Ì  Ì" + '\x0';

        private string WalkingPose2 =
            @"    O" + '\x0' +
            @"   /" + '\x0' +
            @" _/\" + '\x0' +
            @"`  /" + '\x0' +
            @"   Ì" + '\x0';

        private string WalkingPose3 =
            @"   O" + '\x0' +
            @"  /" + '\x0' +
            @" _\" + '\x0' +
            @"`/" + '\x0' +
            @" Ì" + '\x0';

        private string WalkingPose4 =
            @"   O" + '\x0' +
            @"  /" + '\x0' +
            @" /\" + '\x0' +
            @"/ |" + '\x0' +
            @"Ì  Ì" + '\x0';

        private string WalkingPose5 =
            @"    O" + '\x0' +
            @"   /" + '\x0' +
            @" _/\" + '\x0' +
            @"`  /" + '\x0' +
            @"   Ì" + '\x0';

        private string WalkingPose6 =
            @"   O" + '\x0' +
            @"  /" + '\x0' +
            @" |\" + '\x0' +
            @"`/" + '\x0' +
            @" Ì" + '\x0';

        public List<StringFrame> StringFramePoses { get; private set; }
        public bool IsLockingAnimation { get; private set; }

        public WalkRightStringAnimation()
        {
            IsLockingAnimation = false;
            StringFramePoses = new List<StringFrame>()
            {
                new StringFrame(1, WalkingPose1, 1),
                new StringFrame(2, WalkingPose2, 0),
                new StringFrame(3, WalkingPose3, 2),
                new StringFrame(4, WalkingPose4, 1),
                new StringFrame(5, WalkingPose5, 0),
                new StringFrame(6, WalkingPose6, 2)
            };
        }
    }
}
