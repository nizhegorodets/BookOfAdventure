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
    class stateDialogue : AState
    {
        private Phrase[] mPhrases;
        private uint mCurrentPhrase;

        public stateDialogue() { }
        public stateDialogue(uint id, string description, uint?[] nextStates, Phrase[] phrases, bool endTh, bool endGame)
        {
            this.mID = id;
            this.mDescription = description;
            this.mNextStates = nextStates;
            this.mPhrases = phrases;
            this.mCurrentPhrase = 0;
            this.mEndGame = endGame;
            this.mEndThread = endTh;
            // set endState automatically
            if ((mEndGame == true) || (mEndThread == true))
            {
                mNextStates = new uint?[1];
                mNextStates[0] = null;
            }
            // The answer doesn't return nothing
            this.mAnswer = new emptyAnswer("Dialogue", mNextStates[0], mEndThread, mEndGame);
        }
        public override void Init() { }

        public override IAnswer startExecution()
        {
            foreach (var i in this.mPhrases)
            {
                i.sayPhrase();
                this.mCurrentPhrase++;
                System.Threading.Thread.Sleep(2000);
            }
            return mAnswer;
        }
    }
}
