using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using core;
using core.Other_classes;
using GUI.Draw;

namespace GUI
{
    public partial class Form1 : Form
    {
        // number of last state
        uint countStates = 0; 
        gameContext gameContext = new gameContext();
        SortedDictionary<int, uint> indexTreeOfStateToIDOfState = new SortedDictionary<int, uint>();
        IDrawInterface drawObj;
        public static Form1 form1 = null;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                gameContext.Load(openFileDialog1.FileName);
                loadToStateList();
                addOriginToolStripMenuItem.Enabled = true;
            }
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            gameContext.Save(saveFileDialog1.FileName);
        }

        public void loadToStateList()
        {
            countStates = 0;
            TreeOfStates.Items.Clear();
            indexTreeOfStateToIDOfState.Clear();
            foreach (thread th in gameContext.Threads)
            {
                foreach(KeyValuePair<uint?, IState> st in th.MIDToIState)
                {
                    indexTreeOfStateToIDOfState.Add(TreeOfStates.Items.Count, st.Value.getID());
                    TreeOfStates.Items.Add(st.Value.getDescription());
                    countStates++;
                }
            }
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            // redraw backgroung ListBox.  
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            // find corrent index
            if (e.Index != -1)
            {
                string value = TreeOfStates.Items[e.Index].ToString();
                char stateSymbol = value[1];
                switch (stateSymbol)
                {
                    case 'D':
                        myBrush = Brushes.Brown;
                        break;
                    case 'W':
                        myBrush = Brushes.DarkBlue;
                        break;
                    case 'E':
                        myBrush = Brushes.DarkGreen;
                        break;
                    case 'C':
                        myBrush = Brushes.DarkGreen;
                        break;
                    case 'I':
                        myBrush = Brushes.Purple;
                        break;

                }

                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);

                e.DrawFocusRectangle();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this method not effective. need rewrite this code
            AState selectedState;
            char type = TreeOfStates.SelectedItem.ToString()[1];
            PropertiesOfElements.Controls.Clear();
            // find selected state
            uint index = indexTreeOfStateToIDOfState[TreeOfStates.SelectedIndex];
            foreach (thread th in gameContext.Threads)
            {
                foreach (KeyValuePair<uint?, IState> st in th.MIDToIState)
                {
                    if (index == st.Value.getID())
                    {
                        selectedState = (AState)st.Value;
                        // draw interface
                        switch (type)
                        {
                            case 'D':
                                drawObj = new drawDialogue(gameContext, PropertiesOfElements);
                                break;
                            case 'W':
                                drawObj = new drawWait(gameContext, PropertiesOfElements);
                                break;
                            case 'E':
                                break;
                            case 'C':
                                drawObj = new drawChoice(gameContext, PropertiesOfElements);
                                break;
                            case 'I':
                                drawObj = new drawImage(gameContext, PropertiesOfElements);
                                break;
                            case 'F':
                                drawObj = new drawFullScreen(gameContext, PropertiesOfElements);
                                break;
                        }
                        drawObj.drawInterface(selectedState);
                        break;
                    }
                }
            }
        }

        private void TreeOfStates_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int y = e.Y / this.TreeOfStates.ItemHeight;

                if (y < this.TreeOfStates.Items.Count)
                {
                    // If get on a item of ListBox
                    this.TreeOfStates.SelectedIndex = this.TreeOfStates.TopIndex + y;
                    deleteState.Enabled = true;
                    createState.Enabled = false;
                    menuStripStates.Show(this.TreeOfStates, e.Location);
                }
                else
                {
                    // if not hit on a item of ListBox
                    deleteState.Enabled = false;
                    createState.Enabled = true;
                    menuStripStates.Show(this.TreeOfStates, e.Location);
                }
            }
        }

        private void stateWaitCreate_Click(object sender, EventArgs e)
        {
            // selected "State Wait" in context menu
            if (gameContext.Threads != null)
            {
                drawObj = new drawWait(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
            else
            {
                // If the game is not created still 
                gameContext.init();
                gameContext.Threads.Add(new thread());
                drawObj = new drawWait(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
        }

        private void stateDialogueCreate_Click(object sender, EventArgs e)
        {
            // selected "State dialogue" in context menu
            if (gameContext.Threads != null)
            {
                drawObj = new drawDialogue(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
            else
            {
                // If the game is not created still 
                gameContext.init();
                gameContext.Threads.Add(new thread());
                drawObj = new drawDialogue(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
        }

        private void stateChoiceCreate_Click(object sender, EventArgs e)
        {
            // selected "State choice" in context menu
            if (gameContext.Threads != null)
            {
                drawObj = new drawChoice(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
            else
            {
                // If the game is not created still 
                gameContext.init();
                gameContext.Threads.Add(new thread());
                drawObj = new drawChoice(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
        }

        private void deleteState_Click(object sender, EventArgs e)
        {
            // selected "Delete choice" in context menu
            int index = TreeOfStates.SelectedIndex;

            ADrawInterface.deleteState((uint)indexTreeOfStateToIDOfState[TreeOfStates.SelectedIndex], gameContext);

            if (index != 0)
                this.TreeOfStates.SelectedIndex = (int)index - 1;
        }

        private void addOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = originPrompt.ShowDialog("ID", "Name", "Adding a new origin...");
            string[] splited = promptValue.Split();
            NPC newNPC = new NPC(splited[1], Convert.ToInt32(splited[0]));
            gameContext.addNPC(newNPC);
        }

        private void stateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // selected "State image" in context menu
            if (gameContext.Threads != null)
            {
                drawObj = new drawImage(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
            else
            {
                // If the game is not created still 
                gameContext.init();
                gameContext.Threads.Add(new thread());
                drawObj = new drawChoice(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
        }

        private void stateFullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // selected "State FullScreen" in context menu
            if (gameContext.Threads != null)
            {
                drawObj = new drawFullScreen(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }
            else
            {
                // If the game is not created still 
                gameContext.init();
                gameContext.Threads.Add(new thread());
                drawObj = new drawFullScreen(gameContext, PropertiesOfElements);
                drawObj.createState();
                this.TreeOfStates.SelectedIndex = (int)countStates - 1;
            }

        }

        private void addThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = threadPrompt.ShowDialog("Description", "Adding a new thread...");
            int newID = -1;
            for(int i = 0; i < gameContext.Threads.Count; i++)
            {
                if(gameContext.Threads[i].MID != i)
                {
                    newID = i;
                    break;
                }
            }
            if (newID < 0)
                newID = gameContext.Threads.Count;


            thread thread = new thread();
            thread.setID((uint)newID);
            thread.MDescription = promptValue;

            gameContext.Threads.Add(thread);
        }

        private void exportToGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameContext.exportToGraph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoSaving.Enabled = true;
        }

        private void autoSaving_Tick(object sender, EventArgs e)
        {
            gameContext.Save("temp.json");
        }
    }

}
