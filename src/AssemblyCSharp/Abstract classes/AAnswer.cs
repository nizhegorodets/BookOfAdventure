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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    abstract class AAnswer : IAnswer
    {
        protected uint? mNextState;
        protected string mTypeOfState;
        protected bool mEndThread, mEndGame;

        public abstract uint? getNextState();
        public abstract void setNextState(uint? nextState);
        public string getTypeOfState() { return mTypeOfState; }
        public abstract string getData();
        public bool getEndTh() { return mEndThread; }
        public bool getEndGame() { return mEndGame; }

        public uint? MNextState
        {
            get { return mNextState; }
            set { mNextState = value; }
        }
        public string MTypeOfState
        {
            get { return mTypeOfState; }
            set { mTypeOfState = value; }
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
