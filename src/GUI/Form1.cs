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


namespace GUI
{
    public partial class Form1 : Form
    {
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
            TreeOfStates.Items.Clear();
            indexTreeOfStateToIDOfState.Clear();
            foreach (thread th in gameContext.Threads)
            {
                foreach(KeyValuePair<uint?, IState> st in th.MIDToIState)
                {
                    indexTreeOfStateToIDOfState.Add(TreeOfStates.Items.Count, st.Value.getID());
                    TreeOfStates.Items.Add(st.Value.getDescription());
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
                        }
                        drawObj.drawInterface(selectedState);
                        break;
                    }
                }
            }
        }
    }

}
