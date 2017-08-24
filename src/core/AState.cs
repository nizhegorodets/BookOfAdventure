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
    public abstract class AState : IState
    {
        protected uint mID;
        protected string mDescription;
        protected uint?[] mNextStates;
        protected IAnswer mAnswer;
        protected bool mEndThread, mEndGame;

        public abstract void Init();
        public abstract string getDescription();
        public abstract IAnswer startExecution();
        public uint getID() { return mID; }
        public uint?[] getNextStates() { return mNextStates; }

        public string getGeneralDescription()
        {
            string description = "[";
            //identify type
            string type = Convert.ToString(this.GetType());
            description += type[type.IndexOf(".") + ".state".Length];
            description += "-";
            //get ID
            description += Convert.ToString(mID);
            description += "]: ";
            return description;
        }

        public bool isEndGame()
        {
            return mEndGame;
        }

        public bool isEndThread()
        {
            return mEndThread;
        }
        public uint MID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string MDescription
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public uint?[] MNextStates
        {
            get { return mNextStates; }
            set { mNextStates = value; }
        }
        public IAnswer MAnswer
        {
            get { return mAnswer; }
            set { mAnswer = value; }
        }
        public bool MEndThread
        {
            get { return mEndThread; }
            set { mEndThread = value; }
        }
        public bool MEndGame
        {
            get { return mEndGame; }
            set { mEndGame = value; }
        }
    }
}
