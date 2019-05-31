using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets.MeemkiAnimation
{
    public class JumpLeftStringAnimation : IStringAnimation
    {
        private string JumpPose1 =
            @"O"     + '\x0' +
            @" \"    + '\x0' +
            @" /\_"  + '\x0' +
            @" \  ´" + '\x0' +
            @" Í"    + '\x0';

        private string JumpPose2 =
            @"O"    + '\x0' +
            @" \"   + '\x0' +
            @" /_"  + '\x0' +
            @" \´"  + '\x0' +
            @" Í"   + '\x0';

        private string JumpPose3 =
            @"O"    + '\x0' +
            @"_\"   + '\x0' +
            @"\ \"  + '\x0' +
            @"´  \" + '\x0' +
            @"   Í" + '\x0';

        private string JumpPose4 =
            @" _O"  + '\x0' +
            @"  _\" + '\x0' +
            @" / "  + '\x0' +
            @"´ "   + '\x0';

        private string JumpPose5 =
            @"_O"   + '\x0' +
            @"  \"  + '\x0' +
            @"  /"  + '\x0' +
            @" /"   + '\x0' +
            @"´"    + '\x0';

        private string JumpPose6 =
            @"O"  + '\x0' +
            @"/\" + '\x0' +
            @" /" + '\x0' +
            @" \" + '\x0' +
            @" Í" + '\x0';

        public List<StringFrame> StringFramePoses { get; private set; }
        public bool IsLockingAnimation { get; private set; }

        public JumpLeftStringAnimation()
        {
            IsLockingAnimation = true;
            StringFramePoses = new List<StringFrame>()
            {
                new StringFrame(1, JumpPose1, -1, 0),
                new StringFrame(2, JumpPose2, 0, 0),
                new StringFrame(3, JumpPose3, -2, 0),
                new StringFrame(4, JumpPose4, -3, -1, 100),
                new StringFrame(5, JumpPose5, -2, 0, 100),
                new StringFrame(6, JumpPose6, -2, 1, 150)
            };
        }
    }
}
