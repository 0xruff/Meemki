using System;

namespace Meemki.Model
{
    public class StringFrame
    {
        public int Frame { get; private set; }
        public string Pose { get; private set; }
        public int XOffsetToPrevious { get; private set; }
        public int YOffsetToPrevious { get; private set; }
        public int ShowInMilliseconds { get; private set; }

        public StringFrame(int frame, string pose, int xOffsetToPrevious, int yOffsetToPrevious = 0, int showInMilliseconds = 60) //TODO: put in global variables?
        {
            Frame = frame;
            if (String.IsNullOrWhiteSpace(pose))
            {
                throw new ArgumentException();
            }
            Pose = pose;
            XOffsetToPrevious = xOffsetToPrevious;
            YOffsetToPrevious = yOffsetToPrevious;
            ShowInMilliseconds = showInMilliseconds;
        }
    }
}
