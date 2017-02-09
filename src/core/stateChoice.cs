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
    class stateChoice : AState
    {
        private uint mChoosedChoice;
        private Choice[] mChoices;

        public stateChoice(uint mID, string mDescription, IState[] mNextStates, Choice[] mChoices)
        {
            this.mID = mID;
            this.mDescription = mDescription;
            this.mNextStates = mNextStates;
            this.mChoices = mChoices;
        }
        
        public override void Init() { this.mChoosedChoice = 0; }

        public override IState startExecution(gameContext game)
        {
            this.mChoosedChoice = uint.Parse(Console.ReadLine());
            return this.mNextStates[this.mChoosedChoice - 1];
        }
    }
}
