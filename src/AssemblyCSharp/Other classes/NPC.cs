using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Other_classes
{
    public class NPC : INPC
    {
        private string mName;
        private int mId;

        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }

        public int MId
        {
            get { return mId; }
            set { mId = value; }
        }

        public NPC(string name, int id)
        {
            this.mName = name;
            this.mId = id;
        }
    }
}
