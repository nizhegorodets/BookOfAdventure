// core 2017 Anikin Dmitry, Mikhail Kudimov
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class stateWait : AState
    {
        private uint mDelay;
        private string mTitle;
        public void setTitle(string title)
        {
            mTitle = title;
        }
        public stateWait() { }
        public stateWait(uint mID, string mDescription, uint?[] mNextStates, uint mDelay, string title)
        {
            this.mID = mID;
            this.mDescription = mDescription;
            this.mNextStates = mNextStates;
            this.mDelay = mDelay;
            this.mTitle = title;
            // The answer doesn't return nothing
            this.mAnswer = new emptyAnswer("Wait", mNextStates[0], false, false);
            this.mEndGame = false;
            this.mEndThread = false;
        }

        public override void Init() { }

        public override IAnswer startExecution()
        {
            Console.WriteLine(mTitle);
            System.Threading.Thread.Sleep(Convert.ToInt32(mDelay) * 1000);
            return mAnswer;
        }

        public uint MDelay
        {
            get { return mDelay; }
            set { mDelay = value; }
        }

        public string MTitle
        {
            get { return mTitle; }
            set { mTitle = value; }
        }
        public override string getDescription()
        {
            string description = getGeneralDescription();
            description += (Convert.ToString(mDelay) + "sec, ");
            description += mTitle.Substring(0, 30);
            description += "...";
            return description;
        }
    }
}
