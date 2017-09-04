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
using core.Other_classes;

namespace GUI
{
    abstract class ADrawInterface : IDrawInterface
    {
        protected gameContext gc;
        protected Control canvas;
        
        abstract public void createState();
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

            // create labelOrigin
            Label labelOrigin = new Label();
            labelOrigin.Name = "labelOrigin";
            labelOrigin.Text = "Origin: ";
            labelOrigin.Location = new Point(labelID.Location.X + labelID.Width + 5, labelID.Location.Y);
            labelOrigin.AutoSize = true;
            canvas.Controls.Add(labelOrigin);

            // create originCombobox
            ComboBox originCombobox = new ComboBox();
            originCombobox.Name = "originCombobox";
            originCombobox.Location = new Point(labelOrigin.Location.X + labelOrigin.Width + 5, labelOrigin.Location.Y);
            if (gc.nPCs != null)
            {
                foreach (NPC npc in gc.nPCs)
                {
                    originCombobox.Items.Add(npc.MId.ToString() + " - " + npc.MName);
                }
                if (inputState.origin != -1)
                {
                    string currentValue = inputState.origin.ToString() + " - " + gc.getNPC(inputState.origin).MName;
                    originCombobox.SelectedIndex = originCombobox.FindString(currentValue);
                }
            }

            canvas.Controls.Add(originCombobox);
            // create listNextState
            ListView NextStates = new ListView();
            NextStates.Name = "NextStates";
            NextStates.View = View.Details;
            NextStates.Width = canvas.Width / 3 - 20;
            NextStates.Height = 100;
            NextStates.LabelEdit = true;
            NextStates.Location = new Point(0 + 20, labelID.Location.Y + labelID.Height + 10);
            canvas.Controls.Add(NextStates);
            NextStates.Columns.Add("Next state(s)", NextStates.Width - 4, HorizontalAlignment.Left);
            NextStates.MouseUp += new MouseEventHandler(NextStates_MouseUp);
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

            combobox = (ComboBox)canvas.Controls.Find("originCombobox", false).FirstOrDefault();
            inputState.origin = Convert.ToInt32(combobox.Text.Split()[0]);
            return inputState;
        }

        public static void deleteState(uint mIDState, gameContext gc)
        {
            AState selectedState;
            stateChoice selectedStateChoice;

            uint? keyCurrent = 0;
            foreach (thread th in gc.Threads)
                foreach (KeyValuePair<uint?, IState> st in th.MIDToIState)
                {
                    keyCurrent = st.Key;
                    selectedState = (AState)st.Value;
                    if ((st.Value as stateChoice) == null)
                    {
                        // delete the state from nextStates
                        foreach (uint? nextState in selectedState.MNextStates)
                            if (nextState == mIDState)
                            {
                                List<uint?> tmp = new List<uint?>(selectedState.MNextStates);
                                tmp.Remove(nextState);
                                selectedState.MNextStates = tmp.ToArray();
                            }
                    }
                    else
                    {
                        // for stateChoice we delete the state from nextStates and the corresponding variant from choicesList
                        foreach (uint? nextState in selectedState.MNextStates)
                            if (nextState == mIDState)
                            {
                                selectedStateChoice = (stateChoice)st.Value;
                                List<uint?> tmp = new List<uint?>(selectedStateChoice.MNextStates);
                                int ind = tmp.IndexOf(nextState);
                                tmp.Remove(nextState);
                                selectedStateChoice.MNextStates = tmp.ToArray();

                                List<Choice> tmp1 = new List<Choice>(selectedStateChoice.MChoices);
                                tmp1.RemoveAt(ind);
                                selectedStateChoice.MChoices = tmp1.ToArray();
                            }
                    }
                }
            // delete the state
            gc.Threads[0].deleteState(mIDState);
            Form1.form1.loadToStateList();
        }

        private void NextStates_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Delete state from list");
            contextMenu.Items.Add("Add next state");
            contextMenu.Items[0].Click += new EventHandler(deleteNextState_Click);
            contextMenu.Items[1].Click += new EventHandler(addNextState_Click);
            ListView NextStates = (ListView)canvas.Controls.Find("NextStates", false).FirstOrDefault();
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

        private void addNextState_Click(object sender, EventArgs e)
        {
            // add element in nextStates
            ListView choicesList = (ListView)canvas.Controls.Find("NextStates", false).FirstOrDefault();
            choicesList.Items.Add("0");
        }

        private void deleteNextState_Click(object sender, EventArgs e)
        {
            // delete selected items from nextStates
            ListView choicesList = (ListView)canvas.Controls.Find("NextStates", false).FirstOrDefault();
            foreach (ListViewItem item in choicesList.SelectedItems)
                choicesList.Items.Remove(item);
        }
    }
}
