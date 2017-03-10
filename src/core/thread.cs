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
    class thread
    {
        private uint mID;
        private List<IState> mStates;
        private IState mCurrentState;
        // key = mID(thread)_mID(AState)
        private SortedDictionary<string, string> enteredWords;
        private SortedDictionary<string, uint> enteredChoices;

        // methods

        public void setCurrentState(int index)
        {
            mCurrentState = mStates[index];
        }
        public List<bool> runState()
        {
            IState nextState;
            IAnswer ans;
            do
            {
                ans = mCurrentState.startExecution();
                nextState = ans.getNextState();
                string typeOfState = ans.getTypeOfState();
                //Console.WriteLine("Answer contains " + typeOfState);
                string key = Convert.ToString(mID) + "_" + Convert.ToString(mCurrentState.getID());
                switch (typeOfState)
                {
                    case "Enter word":
                        enteredWords.Add(key, ans.getData());
                        break;
                    case "Choice":
                        enteredChoices.Add(key, Convert.ToUInt32(ans.getData()));
                        break;
                }
                if (nextState != null)
                {
                    mCurrentState = nextState;
                }
            } while (nextState != null);

            // array for mEndThread, mEndGame
            List<bool> goodStateFlags = new List<bool>();
            goodStateFlags.Add(ans.getEndTh());
            goodStateFlags.Add(ans.getEndGame());
            return goodStateFlags;
        }
        public thread()
        {
            mID = 0;
            mStates = new List<IState>();
            enteredWords = new SortedDictionary<string, string>();
            enteredChoices = new SortedDictionary<string, uint>();
    }
        public void setID(uint input)
        {
            mID = input;
        }
        public void addState(IState input)
        {
            mStates.Add(input);
        }
    }
}
