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
    class stateEnterWord : AState
    {
        private string mEnteredWord;

        public stateEnterWord(uint id, string description, uint?[] nextStates)
        {
            this.mID = id;
            this.mDescription = description;
            this.mNextStates = nextStates;
            this.mEnteredWord = "";
            // The answer does return word
            this.mAnswer = new enteredWordAnswer("Enter word", mNextStates[0], false, false, mEnteredWord);
            this.mEndGame = false;
            this.mEndThread = false;
        }

        public override void Init() { }

        public override IAnswer startExecution()
        {
            this.mEnteredWord = Console.ReadLine();
            return mAnswer;
        }

        public string MEnteredWord
        {
            get { return mEnteredWord; }
            set { mEnteredWord = value; }
        }
    }
}
