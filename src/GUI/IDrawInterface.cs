using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using core;

namespace GUI
{
    interface IDrawInterface
    {
        void drawInterface(AState inputState);
        void saveButtonClick(object sender, EventArgs e);
    }
}
