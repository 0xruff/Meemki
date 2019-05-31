using System;
using System.Collections.Generic;
using Meemki.Model;

namespace Meemki.Assets
{
    /// <summary>
    /// Each line of a string-represented-pose needs to start on the most left (x = 0) of the pose!
    /// Meemki is considered to be 5 lines in height!
    /// End of line has to be 0x00!
    /// </summary>
    interface IStringAnimation
    {
        List<StringFrame> StringFramePoses { get; }
        bool IsLockingAnimation { get; }
    }
}
