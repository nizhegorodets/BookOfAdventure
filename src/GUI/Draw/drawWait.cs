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
using core;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    class drawWait : ADrawInterface
    {
        public override void saveButtonClick(object sender, EventArgs e)
        {
            stateWait newWait = new stateWait();
            newWait = (stateWait)saveGeneralData(newWait);
            // building newWait
            TextBox title = (TextBox)canvas.Controls.Find("titleBox", false).FirstOrDefault();
            newWait.MTitle = title.Text;
            NumericUpDown upDown = (NumericUpDown)canvas.Controls.Find("delayUpDown", false).FirstOrDefault();
            newWait.MDelay = (uint)upDown.Value;
            // delete old version of state

            Label hiddenOldThread = (Label)canvas.Controls.Find("labelHiddenParentThread", false).FirstOrDefault();
            int IDOldThread = Convert.ToInt32(hiddenOldThread.Text);

            addStateToThread(newWait, IDOldThread);

            Form1.form1.loadToStateList();
        }

        public drawWait(gameContext inputGC, Control inputCanvas) : base(inputGC, inputCanvas) { }
        public override void drawInterface(AState inputState)
        {
            drawGeneralElements(inputState);
            stateWait tempStateDialogue = (stateWait)inputState;

            // interface for specific data
            // delayLabel
            Label delayLabel = new Label();
            delayLabel.AutoSize = true;
            delayLabel.Location = new Point(canvas.Width / 3 + 5, 20);
            delayLabel.Text = "Delay (sec):";
            canvas.Controls.Add(delayLabel);
            // delay
            NumericUpDown upDown = new NumericUpDown();
            upDown.Name = "delayUpDown";
            upDown.Location = new Point(canvas.Width / 3 + delayLabel.Width + 5, 20);
            upDown.Increment = 60;
            upDown.Maximum = 86400;
            upDown.Value = tempStateDialogue.MDelay;
            canvas.Controls.Add(upDown);
            // title label
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(canvas.Width / 3 + 5, upDown.Location.Y + upDown.Height + 5);
            titleLabel.Text = "Title:";
            canvas.Controls.Add(titleLabel);
            // title textbox
            TextBox titleBox = new TextBox();
            titleBox.Name = "titleBox";
            titleBox.Multiline = true;
            titleBox.Location = new Point(canvas.Width / 3 + 5, titleLabel.Location.Y + titleLabel.Height + 5);
            titleBox.Width = canvas.Width / 3 * 2 - 10;
            titleBox.Height = 100;
            titleBox.Text = tempStateDialogue.MTitle;
            canvas.Controls.Add(titleBox);
        }
        
        public override void createState(int parentTh)
        {
            stateWait newWait = new stateWait();
            newWait.MDescription = "";
            newWait.MEndGame = false;
            newWait.MEndThread = false;
            newWait.MID = gc.getIDForNewState();
            newWait.MNextStates = new uint?[0];

            newWait.MDelay = 0;
            newWait.MTitle = "New state wait";
            newWait.MParentThread = parentTh;

            gc.Threads[0].addState(newWait);
            Form1.form1.loadToStateList();
        }
    }
}
