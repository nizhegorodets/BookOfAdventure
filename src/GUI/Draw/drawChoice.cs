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

using core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class drawChoice : ADrawInterface
    {
        public override void saveButtonClick(object sender, EventArgs e)
        {
            stateChoice newChoice = new stateChoice();
            newChoice = (stateChoice)saveGeneralData(newChoice);
            // building newWait
            TextBox titleBox = (TextBox)canvas.Controls.Find("titleBox", false).FirstOrDefault();
            newChoice.MTitle = titleBox.Text;
            newChoice.MChoosedChoice = 0;

            ListView choicesList = (ListView)canvas.Controls.Find("choicesList", false).FirstOrDefault();
            Choice[] choices = new Choice[choicesList.Items.Count];
            uint count = 0;
            foreach (ListViewItem ch in choicesList.Items)
            {
                Choice tempCh = new Choice(count, ch.SubItems[0].Text);
                choices[count] = tempCh;
                count++;
            }
            newChoice.MChoices = choices;
            // delete old version of state

            gc.Threads[0].deleteState(newChoice.MID);
            gc.Threads[0].addState(newChoice);
            Form1.form1.loadToStateList();
        }

        public drawChoice(gameContext inputGC, Control inputCanvas) : base(inputGC, inputCanvas) { }

        public override void drawInterface(AState inputState)
        {
            drawGeneralElements(inputState);
            stateChoice tempStateDialogue = (stateChoice)inputState;

            // interface for specific data
            // create  and fill ChoicesList
            ListView choicesList = new ListView();
            choicesList.Name = "choicesList";
            choicesList.Height = canvas.Height - 85;
            choicesList.Width = canvas.Width / 3 * 2 - 20;
            choicesList.Location = new Point(canvas.Width / 3 + 10, 63);
            choicesList.View = View.Details;
            choicesList.LabelEdit = true;
            choicesList.MouseUp += new MouseEventHandler(choices_MouseUp);
            choicesList.Columns.Add("Choices", choicesList.Width -5, HorizontalAlignment.Left);
            canvas.Controls.Add(choicesList);

            foreach (Choice ch in tempStateDialogue.MChoices)
            {
                var listViewItem = new ListViewItem(new[] { ch.MText});
                choicesList.Items.Add(listViewItem);
            }
        
            // title textbox
            TextBox titleBox = new TextBox();
            titleBox.Name = "titleBox";
            titleBox.Multiline = true;
            titleBox.Width = canvas.Width / 3 - 20;
            titleBox.Height = 100;
            titleBox.Location = new Point(20, canvas.Height - titleBox.Height - 20);
            titleBox.Text = tempStateDialogue.MTitle;
            canvas.Controls.Add(titleBox);
            // title label
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, titleBox.Location.Y - titleLabel.Height+5);
            titleLabel.Text = "Title:";
            canvas.Controls.Add(titleLabel);
        }

        public override void createState()
        {
            stateChoice newChoice = new stateChoice();
            newChoice.MDescription = "";
            newChoice.MEndGame = false;
            newChoice.MEndThread = false;
            newChoice.MID = gc.getIDForNewState();
            newChoice.MNextStates = new uint?[0];

            newChoice.MChoices = new Choice[1] { new Choice(0, "First option") };

            newChoice.MTitle = "New state choice";
            newChoice.MChoosedChoice = 0;

            gc.Threads[0].addState(newChoice);
            Form1.form1.loadToStateList();
        }

        private void choices_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Delete choices");
            contextMenu.Items.Add("Add new choice");
            contextMenu.Items[0].Click += new EventHandler(deleteChoices_Click);
            contextMenu.Items[1].Click += new EventHandler(addChoice_Click);
            ListView NextStates = (ListView)canvas.Controls.Find("choicesList", false).FirstOrDefault();
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (NextStates.SelectedItems.Count != 0)
                {
                    contextMenu.Items[0].Enabled = true;
                    contextMenu.Items[1].Enabled = false;
                    contextMenu.Show(NextStates, e.Location);
                }
                else
                {
                    contextMenu.Items[0].Enabled = false;
                    contextMenu.Items[1].Enabled = true;
                    contextMenu.Show(NextStates, e.Location);
                }
            }
        }

        private void addChoice_Click(object sender, EventArgs e)
        {
            // add new choice
            ListView choicesList = (ListView)canvas.Controls.Find("choicesList", false).FirstOrDefault();
            choicesList.Items.Add("New phrase");
        }

        private void deleteChoices_Click(object sender, EventArgs e)
        {
            // delete selected choices from choicesList
            ListView choicesList = (ListView)canvas.Controls.Find("choicesList", false).FirstOrDefault();
            foreach (ListViewItem item in choicesList.SelectedItems)
                choicesList.Items.Remove(item);
        }
    }
}
