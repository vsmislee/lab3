using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class IndexOfElement
    {
        int row;
        int col;

        public IndexOfElement(int i, int j)
        {
            this.row = i;
            this.col = j;
        }

        public int Row{ get { return this.row; } }
        public int Col { get { return this.col; } }
    }
}
