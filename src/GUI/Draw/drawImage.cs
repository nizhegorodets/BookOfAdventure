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
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    class drawImage : ADrawInterface
    {
        public override void saveButtonClick(object sender, EventArgs e)
        {
            stateImage newImage = new stateImage();
            newImage = (stateImage)saveGeneralData(newImage);
            // building newImage
            TextBox titleBox = (TextBox)canvas.Controls.Find("titleBox", false).FirstOrDefault();
            newImage.MPath = titleBox.Text;

            // delete old version of state

            gc.Threads[0].deleteState(newImage.MID);
            gc.Threads[0].addState(newImage);
            Form1.form1.loadToStateList();
        }

        public drawImage(gameContext inputGC, Control inputCanvas) : base(inputGC, inputCanvas) { }

        public override void drawInterface(AState inputState)
        {
            drawGeneralElements(inputState);
            stateImage tempStateDialogue = (stateImage)inputState;

            // interface for specific data
            // title textbox
            TextBox titleBox = new TextBox();
            titleBox.Name = "titleBox";
            titleBox.Multiline = false;
            titleBox.Width = canvas.Width / 3 - 20;
            titleBox.Height = 100;
            titleBox.Location = new Point(20, canvas.Height - titleBox.Height - 20);
            titleBox.Text = tempStateDialogue.MPath;
            canvas.Controls.Add(titleBox);
            // title label
            Label titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, titleBox.Location.Y - titleLabel.Height + 5);
            titleLabel.Text = "Path:";
            canvas.Controls.Add(titleLabel);
        }

        public override void createState()
        {
            stateImage newImage = new stateImage();
            newImage.MDescription = "";
            newImage.MEndGame = false;
            newImage.MEndThread = false;
            newImage.MID = gc.getIDForNewState();
            newImage.MNextStates = new uint?[0];
            newImage.MPath = "New path";

            gc.Threads[0].addState(newImage);
            Form1.form1.loadToStateList();
        }
    }
}

