﻿// core 2017 Anikin Dmitry, Mikhail Kudimov
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
    public class stateChoice : AState
    {
        private uint mChoosedChoice;
        private Choice[] mChoices;
        private string mTitle;


        public override string buildText(int choice)
        {
            string text = "";
            text = mTitle + '\n';
            text += (mChoices[choice].MText + '\n');
            return text;
        }
        public void setTitle(string input)
        {
            mTitle = input;
        }
        public stateChoice() { }
        public stateChoice(uint mID, string mDescription, uint?[] mNextStates, Choice[] mChoices, string title)
        {
            this.mID = mID;
            this.mDescription = mDescription;
            this.mNextStates = mNextStates;
            this.mChoices = mChoices;
            this.mTitle = title;
            // The answer does return choice
            this.mAnswer = new choiceAnswer("Choice", mNextStates[0], false, false, 0);
            this.mEndGame = false;
            this.mEndThread = false;
            this.mOrigin = -1;
        }

        public override void Init() { this.mChoosedChoice = 0; }

        public override IAnswer startExecution()
        {
            Console.WriteLine("    " + mTitle);
            int count = 0;
            foreach (Choice ch in mChoices)
            {
                count++;
                Console.WriteLine("        " + Convert.ToString(count) + ". " + ch.MText);
            }
            this.mChoosedChoice = uint.Parse(Console.ReadLine());
            mAnswer.setNextState(this.mNextStates[this.mChoosedChoice - 1]);
            return mAnswer;
        }

        public uint MChoosedChoice
        {
            get { return mChoosedChoice; }
            set { mChoosedChoice = value; }
        }

        public Choice[] MChoices
        {
            get { return mChoices; }
            set { mChoices = value; }
        }

        public string MTitle
        {
            get { return mTitle; }
            set { mTitle = value; }
        }
        public override string getDescription()
        {
            string description = getGeneralDescription();
            if (mTitle.Length > 30)
            {
                description += mTitle.Substring(0, 30);
                description += "...";
                return description;
            }
            else
                return description + mTitle.Substring(0, MTitle.Length);
        }
    }
}
