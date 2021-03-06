﻿// Copyright 2017 Anikin Dmitry, Mikhail Kudimov
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class thread
    {
        private uint? mID;
        private uint? mCurrentState;
        private SortedDictionary<string, string> enteredWords;
        private SortedDictionary<string, uint> enteredChoices;
        private SortedDictionary<uint?, IState> mIDToIState;
        private string mDescription;
        private List<int> startState;

        // methods

        public List<int> StartState
        {
            get { return startState; }
            set { startState = value; }
        }

        public void deleteState(uint? delIndex)
        {
            mIDToIState.Remove(delIndex);
        }
        public uint? getThID() { return mID; }
        IAnswer startExecution(uint? CurrentStateID)
        {
            IAnswer ans;
            IState currentState = mIDToIState[CurrentStateID];
            ans = currentState.startExecution();
            return ans;
        }

        public void setCurrentState(uint? index)
        {
            mCurrentState = index;
        }
        public List<bool> runState()
        {
            uint? nextState;
            IAnswer ans;
            do
            {
                ans = startExecution(mCurrentState);
                nextState = ans.getNextState();
                string typeOfState = ans.getTypeOfState();
                //Console.WriteLine("Answer contains " + typeOfState);
                string key = Convert.ToString(mID) + "_" + Convert.ToString(mCurrentState);
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
            startState = new List<int>();
            startState.Add(0);
            mIDToIState = new SortedDictionary<uint?, IState>();
            enteredWords = new SortedDictionary<string, string>();
            enteredChoices = new SortedDictionary<string, uint>();
        }

        public void Load(string file)
        {
            thread obj = JsonConvert.DeserializeObject<thread>(File.ReadAllText(file), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            mID = obj.MID;
            mCurrentState = obj.MCurrentState;
            enteredWords = obj.EnteredWords;
            enteredChoices = obj.EnteredChoices;
            mIDToIState = obj.MIDToIState;
            mDescription = obj.MDescription;
            startState = obj.StartState;
    }

        public void setID(uint input)
        {
            mID = input;
        }
        public void addState(IState input)
        {

            mIDToIState.Add(input.getID(), input);
        }

        public uint? MID
        {
            get { return mID; }
            set { mID = value; }
        }
        
        public string MDescription
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public uint? MCurrentState
        {
            get { return mCurrentState; }
            set { mCurrentState = value; }
        }

        public SortedDictionary<string, string> EnteredWords
        {
            get { return enteredWords; }
            set { enteredWords = value; }
        }

        public SortedDictionary<string, uint> EnteredChoices
        {
            get { return enteredChoices; }
            set { enteredChoices = value; }
        }

        public SortedDictionary<uint?, IState> MIDToIState
        {
            get { return mIDToIState; }
            set { mIDToIState = value; }
        }
    }
}
