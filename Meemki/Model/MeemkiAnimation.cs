using System;
using System.Collections.Generic;

namespace Meemki.Model
{
    public class MeemkiAnimation
    {
        public AnimationEnum AnimationKind { get; private set; }
        public bool IsLockingAnimation { get; private set; }
        public List<MeemkiPose> AnimationPoses { get; private set; }
        public int NumberOfFrames { get { return AnimationPoses.Count; } }

        public MeemkiAnimation(AnimationEnum animationKind, bool isLockingAnimation, List<MeemkiPose> poses)
        {
            AnimationKind = animationKind;
            IsLockingAnimation = isLockingAnimation;
            if (poses == null)
            {
                throw new ArgumentNullException();
            }
            AnimationPoses = poses;
        }
    }
}
