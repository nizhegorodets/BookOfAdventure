using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class stateFullScreen : AState
    {
        private string mPath;
        private bool mAnimationZoom;
        private bool mAnimationSlide;
        public stateFullScreen() { mOrigin = -1; }
        public stateFullScreen(uint mID, string mDescription, uint?[] mNextStates, string path, bool zoom, bool slide)
        {
            this.mID = mID;
            this.mDescription = mDescription;
            this.mNextStates = mNextStates;
            // The answer doesn't return nothing
            this.mAnswer = new emptyAnswer("Wait", mNextStates[0], false, false);
            this.mEndGame = false;
            this.mEndThread = false;
            this.mOrigin = -1;
            this.mPath = path;
            this.mAnimationZoom = zoom;
            this.mAnimationSlide = slide;
        }

        public override void Init() { }

        public override IAnswer startExecution()
        {
            Console.WriteLine(mPath + " animationZoom " + Convert.ToString(mAnimationZoom) + ", animationSlide " + Convert.ToString(mAnimationSlide));
            return mAnswer;
        }

        public string MPath
        {
            get { return mPath; }
            set { mPath = value; }
        }

        public bool MAnimationZoom
        {
            get { return mAnimationZoom; }
            set { mAnimationZoom = value; }

        }

        public bool MAnimationSlide
        {
            get { return mAnimationSlide; }
            set { mAnimationSlide = value; }
        }

        public override string getDescription()
        {
            string description = getGeneralDescription();
            description += " [FULLSCREEN]";
            return description;
        }

    }
}
