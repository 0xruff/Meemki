using System;
using System.Collections.Generic;

namespace Meemki.Model
{
    public class MeemkiPose
    {
        public AnimationEnum BelongsToAnimation { get; private set; }
        public int Frame { get; private set; }
        public List<PositionedChar> Pose { get; private set; }
        public int XOffsetToPrevious { get; private set; }
        public int YOffsetToPrevious { get; private set; }
        public int ShowInMilliseconds { get; private set; }

        public MeemkiPose(AnimationEnum belongsToAnimation, int frame, List<PositionedChar> pose, int xOffsetToPrevious, int yOffsetToPrevious, int showInMilliseconds)
        {
            BelongsToAnimation = belongsToAnimation;
            Frame = frame;
            if (pose == null)
            {
                throw new ArgumentNullException();
            }
            Pose = pose;
            XOffsetToPrevious = xOffsetToPrevious;
            YOffsetToPrevious = yOffsetToPrevious;
            ShowInMilliseconds = showInMilliseconds;
        }
    }
}
