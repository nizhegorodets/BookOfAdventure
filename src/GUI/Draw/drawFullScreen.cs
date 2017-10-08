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

namespace GUI.Draw
{
    class drawFullScreen : ADrawInterface
    {
        public drawFullScreen(gameContext inputGC, Control inputCanvas) : base(inputGC, inputCanvas) { }

        public override void saveButtonClick(object sender, EventArgs e)
        {
            stateFullScreen newFS = new stateFullScreen();
            newFS = (stateFullScreen)saveGeneralData(newFS);

            TextBox titleBox = (TextBox)canvas.Controls.Find("titleBox", false).FirstOrDefault();
            newFS.MPath = titleBox.Text;


            ComboBox zoomCombobox = (ComboBox)canvas.Controls.Find("animationZoom", false).FirstOrDefault();
            newFS.MAnimationZoom = Convert.ToBoolean(zoomCombobox.SelectedItem);

            ComboBox slideCombobox = (ComboBox)canvas.Controls.Find("animationSlide", false).FirstOrDefault();
            newFS.MAnimationSlide = Convert.ToBoolean(slideCombobox.SelectedItem);

            Label hiddenOldThread = (Label)canvas.Controls.Find("labelHiddenParentThread", false).FirstOrDefault();
            int IDOldThread = Convert.ToInt32(hiddenOldThread.Text);

            addStateToThread(newFS, IDOldThread);
            Form1.form1.loadToStateList();
        }
        public override void drawInterface(AState inputState)
        {
            drawGeneralElements(inputState);
            stateFullScreen tempStateDialogue = (stateFullScreen)inputState;

            // specific elements
            // animationZoom combobox
            ComboBox animationZoom = new ComboBox();
            animationZoom.Name = "animationZoom";
            animationZoom.Width = canvas.Width / 3 - 20;
            animationZoom.Height = 100;
            animationZoom.Location = new Point(20, canvas.Height - animationZoom.Height - 20);
            animationZoom.Items.Add("True");
            animationZoom.Items.Add("False");
            string currentValue = Convert.ToString(tempStateDialogue.MAnimationZoom);
            animationZoom.SelectedIndex = animationZoom.FindString(currentValue);
            canvas.Controls.Add(animationZoom);
            // animationSlide
            ComboBox animationSlide = new ComboBox();
            animationSlide.Name = "animationSlide";
            animationSlide.Width = canvas.Width / 3 - 20;
            animationSlide.Height = 100;
            animationSlide.Location = new Point(animationZoom.Location.X + animationZoom.Width + 15, 
                canvas.Height - animationSlide.Height - 20);
            animationSlide.Items.Add("True");
            animationSlide.Items.Add("False");
            currentValue = Convert.ToString(tempStateDialogue.MAnimationSlide);
            animationSlide.SelectedIndex = animationZoom.FindString(currentValue);
            canvas.Controls.Add(animationSlide);
            // title textbox
            TextBox titleBox = new TextBox();
            titleBox.Name = "titleBox";
            titleBox.Multiline = false;
            titleBox.Width = canvas.Width / 3 - 20;
            titleBox.Height = 100;
            titleBox.Location = new Point(animationSlide.Location.X + animationSlide.Width + 15, canvas.Height - titleBox.Height - 20);
            titleBox.Text = tempStateDialogue.MPath;
            canvas.Controls.Add(titleBox);
            // title label
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(titleBox.Location.X, titleBox.Location.Y - titleLabel.Height + 5);
            titleLabel.Text = "Path:";
            canvas.Controls.Add(titleLabel);
            // zoom label
            Label zoomLabel = new Label();
            zoomLabel.AutoSize = true;
            zoomLabel.Location = new Point(animationZoom.Location.X, titleBox.Location.Y - titleLabel.Height - 5);
            zoomLabel.Text = "Zoom:";
            canvas.Controls.Add(zoomLabel);
            // slide label
            Label slideLabel = new Label();
            slideLabel.AutoSize = true;
            slideLabel.Location = new Point(animationSlide.Location.X, titleBox.Location.Y - titleLabel.Height - 5);
            slideLabel.Text = "Slide:";
            canvas.Controls.Add(slideLabel);
        }

        public override void createState()
        {
            stateFullScreen newFS = new stateFullScreen();
            newFS.MDescription = "";
            newFS.MEndGame = false;
            newFS.MEndThread = false;
            newFS.MID = gc.getIDForNewState();
            newFS.MNextStates = new uint?[0];
            newFS.MAnimationSlide = false;
            newFS.MAnimationZoom = false;

            gc.Threads[0].addState(newFS);
            Form1.form1.loadToStateList();
        }

    }
}

