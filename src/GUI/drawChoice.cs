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
    }
}
