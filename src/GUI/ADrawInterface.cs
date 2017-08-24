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
    abstract class ADrawInterface : IDrawInterface
    {
        protected gameContext gc;
        protected Control canvas;

        abstract public void drawInterface(AState inputState);
        abstract public void saveButtonClick(object sender, EventArgs e);
        public void drawGeneralElements(AState inputState)
        {
            AState tempStateDialogue = inputState;
            // create labelID
            Label labelID = new Label();
            labelID.Name = "labelID";
            labelID.Text = "ID = " + tempStateDialogue.getID().ToString();
            labelID.Location = new Point(0 + 20, 45);
            labelID.AutoSize = true;
            canvas.Controls.Add(labelID);
            // create listNextState
            ListView NextStates = new ListView();
            NextStates.Name = "NextStates";
            NextStates.View = View.Details;
            NextStates.Width = canvas.Width / 3 - 20;
            NextStates.Height = 100;
            NextStates.LabelEdit = true;
            NextStates.Location = new Point(0 + 20, labelID.Location.Y + labelID.Height + 5);
            canvas.Controls.Add(NextStates);
            NextStates.Columns.Add("Next state(s)", NextStates.Width - 4, HorizontalAlignment.Left);
            uint?[] nextStates = tempStateDialogue.getNextStates();
            foreach (uint? ns in nextStates)
            {
                var listViewItem = new ListViewItem(ns.ToString());
                NextStates.Items.Add(listViewItem);
            }
            // comboboxes Label
            Label endThreadLabel = new Label();
            Label endGameLabel = new Label();
            endThreadLabel.Location = new Point(20, NextStates.Location.Y + NextStates.Height + 5);
            endGameLabel.Location = new Point(20, endThreadLabel.Location.Y + endThreadLabel.Height + 5);
            endThreadLabel.Text = "end thread";
            endGameLabel.Text = "end game";
            endThreadLabel.Width = 70;
            endGameLabel.Width = 70;
            canvas.Controls.Add(endThreadLabel);
            canvas.Controls.Add(endGameLabel);
            // create comboboxes
            ComboBox endThread = new ComboBox();
            ComboBox endGame = new ComboBox();
            endThread.Location = new Point(endThreadLabel.Location.X + endThreadLabel.Width, endThreadLabel.Location.Y);
            endGame.Location = new Point(endGameLabel.Location.X + endGameLabel.Width, endGameLabel.Location.Y);
            endThread.Items.Add("true");
            endThread.Items.Add("false");
            endGame.Items.Add("true");
            endGame.Items.Add("false");
            endGame.Name = "endGame";
            endThread.Name = "endThread";
            // fill comboboxes
            if (tempStateDialogue.isEndGame())
            {
                endGame.SelectedIndex = 0;
            }
            else
            {
                endGame.SelectedIndex = 1;
            }

            if (tempStateDialogue.isEndThread())
            {
                endThread.SelectedIndex = 0;
            }
            else
            {
                endThread.SelectedIndex = 1;
            }
            canvas.Controls.Add(endGame);
            canvas.Controls.Add(endThread);
            // create saveButton
            Button saveButton = new Button();
            saveButton.Width = canvas.Width / 3 - 20;
            saveButton.Location = new Point(0 + 20, 20);
            saveButton.Text = "Save State";
            saveButton.Click += new System.EventHandler(saveButtonClick);
            canvas.Controls.Add(saveButton);

        }
        public ADrawInterface(gameContext inputGC, Control inputCanvas) : base() 
        {
            gc = inputGC;
            canvas = inputCanvas;
        }
        public AState saveGeneralData(AState inputState)
        {
            inputState.MDescription = "";
            ComboBox combobox = (ComboBox)canvas.Controls.Find("endGame", false).FirstOrDefault();
            inputState.MEndGame = Convert.ToBoolean(combobox.SelectedItem);
            combobox = (ComboBox)canvas.Controls.Find("endThread", false).FirstOrDefault();
            inputState.MEndThread = Convert.ToBoolean(combobox.SelectedItem);

            Label label = (Label)canvas.Controls.Find("labelID", false).FirstOrDefault();
            inputState.MID = Convert.ToUInt32(label.Text.Split()[2]);

            ListView NextStates = (ListView)canvas.Controls.Find("NextStates", false).FirstOrDefault();
            uint?[] s = new uint?[NextStates.Items.Count];
            for (int i = 0; i < NextStates.Items.Count; i++)
            {
                if (NextStates.Items[i].Text != "")
                {
                    s[i] = Convert.ToUInt32(NextStates.Items[i].Text);
                }
            }
            inputState.MNextStates = s;
            return inputState;
        }
    }
}
