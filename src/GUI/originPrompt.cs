using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public static class originPrompt
    {
        public static string ShowDialog(string id, string name, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label idLabel = new Label() { Left = 30, Top = 30, Text = id, Width = 50 };
            TextBox idBox = new TextBox() { Left = 80, Top = 30, Width = 150 };
            Label nameLabel = new Label() { Left = 30, Top = 50, Text = name, Width = 50 };
            TextBox nameBox = new TextBox() { Left = 80, Top = 50, Width = 150 };

            Button confirmation = new Button() { Text = "Ok", Left = prompt.Width / 2 - 50, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(idBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(idLabel);
            prompt.Controls.Add(nameBox);
            prompt.Controls.Add(nameLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? idBox.Text + " " + nameBox.Text : "";
        }
    }
}
