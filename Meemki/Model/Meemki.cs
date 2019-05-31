using System;
using System.Collections.Generic;
using System.Linq;
using Meemki.Global;

namespace Meemki.Model
{
    public class Meemki
    {
        public ConsoleColor MeemkiColor { get; set; } = ConsoleColor.Cyan;
        private MeemkiPosition meemkiPosition;
        private List<Model.MeemkiAnimation> animationList;

        private MeemkiPosition lastMeemkiPosition = null;
        private AnimationEnum lastAnimationPlayed = AnimationEnum.Idle; //because Meemki starts idling
        private int lastPlayedPoseIndex = -1;

        public Meemki()
        {
            meemkiPosition = new MeemkiPosition();
            animationList = new Logic.AnimationLoader().Load();
        }

        public void Animate(AnimationEnum animationType)
        {
            CleanLastPose();
            ShowNextPose(animationType);
        }

        private void ShowNextPose(AnimationEnum animationType)
        {
            Console.ForegroundColor = MeemkiColor;

            MeemkiAnimation animationToPlay = animationList.Where(a => a.AnimationKind == animationType).First();

            //handle locking animations
            //LOCK
            if (animationToPlay.IsLockingAnimation)
            {
                Global.Variables.AnimationLock = true;
                Global.Variables.LockedAnimation = animationType;
            }

            if (animationType == lastAnimationPlayed)
            {
                int poseIndex = lastPlayedPoseIndex + 1 < animationToPlay.NumberOfFrames ? lastPlayedPoseIndex + 1 : 0;

                MeemkiPose newPose = animationToPlay.AnimationPoses[poseIndex];

                //loop on the right edge
                if (meemkiPosition.X + newPose.XOffsetToPrevious + Global.Variables.MeemkiWidth > Console.BufferWidth) //+ Meemki's width, so the check is about whole Meemki and not just the position where the drawing starts...
                {
                    meemkiPosition.X = 0;
                }
                //loop on the left edge
                else if (meemkiPosition.X + newPose.XOffsetToPrevious < 0)
                {
                    meemkiPosition.X = Console.BufferWidth - Global.Variables.MeemkiWidth;
                }
                else
                {
                    meemkiPosition.X += newPose.XOffsetToPrevious;
                }

                meemkiPosition.Y += newPose.YOffsetToPrevious;

                foreach (Model.PositionedChar posChar in newPose.Pose)
                {
                    int xOffset = (int)posChar.Position.X + meemkiPosition.X;
                    int yOffset = (int)posChar.Position.Y + meemkiPosition.Y;
                    Console.SetCursorPosition(xOffset, yOffset);
                    if (posChar.Char != ' ')
                    {
                        Console.Write(posChar.Char);
                    }
                }
                System.Threading.Thread.Sleep(newPose.ShowInMilliseconds);
                lastPlayedPoseIndex = poseIndex;
                lastAnimationPlayed = animationType;
                lastMeemkiPosition = meemkiPosition;
            }
            else
            {
                lastPlayedPoseIndex = -1;
                lastAnimationPlayed = animationType;
                ShowNextPose(animationType);
            }

            //UNLOCK
            if (lastPlayedPoseIndex == animationToPlay.NumberOfFrames - 1)
            {
                Global.Variables.AnimationLock = false;
            }
        }

        private void CleanLastPose()
        {
            if (lastPlayedPoseIndex >= 0)
            {
                foreach (Model.PositionedChar posChar in animationList.Where(a => a.AnimationKind == lastAnimationPlayed).First().AnimationPoses[lastPlayedPoseIndex].Pose)
                {
                    int xOffset = (int)posChar.Position.X + lastMeemkiPosition.X;
                    Console.SetCursorPosition(xOffset, (int)posChar.Position.Y + meemkiPosition.Y);
                    if (posChar.Char != ' ')
                    {
                        Console.Write(MemorizableConsole.GetChar(xOffset, (int)posChar.Position.Y + meemkiPosition.Y));
                    }
                }
            }
        }
    }
}
