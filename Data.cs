using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class Data
    {
        private int row, col;
        private int[,] tab;

        public int RowGet
        {
            get { return row; }
        }
        
        public int ColGet
        {
            get { return col; }
        }
        
        Data()
        {
        }

        public Data(int row, int col)
        {
            this.row = row;
            this.col = col;
            
            this.tab = new int[row, col];    
        }

        public void Write(int row, int col, int data)
        {
            this.tab[row, col] = data;
        }

        public int Read(int row, int col)
        {
            return this.tab[row,col];
        }
    }
}
