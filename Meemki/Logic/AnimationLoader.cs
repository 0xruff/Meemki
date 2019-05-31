using Meemki.Model;
using Meemki.Assets.MeemkiAnimation;
using Meemki.Assets;
using System.Collections.Generic;

namespace Meemki.Logic
{
    public class AnimationLoader
    {
        public List<MeemkiAnimation> Load()
        {
            List<MeemkiAnimation> animations = new List<MeemkiAnimation>();
            animations.Add(TransformStringsToAnimations(AnimationEnum.Idle, new IdleStringAnimation()));
            animations.Add(TransformStringsToAnimations(AnimationEnum.RunRight, new WalkRightStringAnimation()));
            animations.Add(TransformStringsToAnimations(AnimationEnum.RunLeft, new WalkLeftStringAnimation()));
            animations.Add(TransformStringsToAnimations(AnimationEnum.JumpRight, new JumpRightStringAnimation()));
            animations.Add(TransformStringsToAnimations(AnimationEnum.JumpLeft, new JumpLeftStringAnimation()));

            return animations;
        }

        private MeemkiAnimation TransformStringsToAnimations(AnimationEnum animationKind, IStringAnimation posesRepresentedWithStrings)
        {
            List<MeemkiPose> meemkiPoses = new List<MeemkiPose>();

            foreach (StringFrame stringFramePose in posesRepresentedWithStrings.StringFramePoses)
            {
                meemkiPoses.Add(TransformStringToPose(animationKind, stringFramePose));
            }
            return new MeemkiAnimation(animationKind, posesRepresentedWithStrings.IsLockingAnimation, meemkiPoses);
        }

        private MeemkiPose TransformStringToPose(AnimationEnum animationKind, StringFrame stringFramePose)
        {
            List<PositionedChar> positionedChars = new List<PositionedChar>();

            int x = 0;
            int y = 0;
            foreach (char c in stringFramePose.Pose)
            {
                if (c == '\x0')
                {
                    y++;
                    x = 0;
                    continue;
                }

                positionedChars.Add(new PositionedChar(new System.Windows.Point(x, y), c));
                x++;
            }
            
            return new MeemkiPose(animationKind, stringFramePose.Frame, positionedChars, stringFramePose.XOffsetToPrevious, stringFramePose.YOffsetToPrevious, stringFramePose.ShowInMilliseconds);
        }
    }
}
