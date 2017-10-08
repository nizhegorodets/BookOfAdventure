using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class threadPrompt
    {
        public static string ShowDialog(string description, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label descriptionLabel = new Label() { Left = prompt.Width /2 - 50, Top = 30, Text = description, Width = 100 };
            TextBox descriptionBox = new TextBox() { Left = 80, Top = 50, Width = 150 };

            Button confirmation = new Button() { Text = "Ok", Left = prompt.Width / 2 - 50, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(descriptionBox);
            prompt.Controls.Add(descriptionLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? descriptionBox.Text: "";
        }
    }
}
