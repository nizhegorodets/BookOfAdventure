// Copyright 2017 Anikin Dmitry, Mikhail Kudimov
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
    class emptyAnswer : AAnswer
    {
        public emptyAnswer(string inType, uint? inState, bool inEndTh, bool inEndG)
        {
            mNextState = inState;
            mTypeOfState = inType;
            mEndThread = inEndTh;
            mEndGame = inEndG;
        }
        public override uint? getNextState()
        {
            return mNextState;
        }
        public override void setNextState(uint? nextState)
        {
            mNextState = nextState;
        }
        public override string getData()
        {
            return "";
        }

    }
}
