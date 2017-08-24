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
using System.Windows.Forms;
using core;
using System.Drawing;

namespace GUI
{
    class drawDialogue : ADrawInterface
    {
        public drawDialogue(gameContext inputGC, Control inputCanvas) : base(inputGC, inputCanvas) { }

        public override void saveButtonClick(object sender, EventArgs e)
        {
            stateDialogue newDialogue = new stateDialogue();
            newDialogue = (stateDialogue)saveGeneralData(newDialogue);

            // building newDialogue
            ListView phrasesList = (ListView)canvas.Controls.Find("phrasesList", false).FirstOrDefault();
            Phrase[] p = new Phrase[phrasesList.Items.Count];
            for(int i = 0; i < phrasesList.Items.Count; i++)
            {
                p[i] = new Phrase(0, phrasesList.Items[i].Text);
            }

            newDialogue.MPhrases = p;
            newDialogue.MCurrentPhrase = 0;
            // delete old version of state

            gc.Threads[0].deleteState(newDialogue.MID);
            gc.Threads[0].addState(newDialogue);
            Form1.form1.loadToStateList();
        }
        public override void drawInterface(AState inputState)
        {
            drawGeneralElements(inputState);
            stateDialogue tempStateDialogue = (stateDialogue)inputState;

            // specific elements
            // create  and fill phrasesList
            ListView phrasesList = new ListView();
            phrasesList.Name = "phrasesList";
            phrasesList.Height = canvas.Height - 40;
            phrasesList.Width = canvas.Width / 3 * 2 - 20;
            phrasesList.Location = new Point(canvas.Width / 3 + 10, 20);
            phrasesList.View = View.Details;
            phrasesList.LabelEdit = true;
            phrasesList.Columns.Add("Phrases", phrasesList.Width, HorizontalAlignment.Left);
            canvas.Controls.Add(phrasesList);

            foreach (Phrase ph in tempStateDialogue.MPhrases)
            {
                var listViewItem = new ListViewItem(ph.MPhrase);
                phrasesList.Items.Add(listViewItem);
            }
        }
    }
}
