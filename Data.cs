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

        public List<int>[] ToList()
        {
            List<int>[] listaTablic = new List<int>[col];

            for (int i = 0; i < row; i++)
            {
                {
                    listaTablic[i] = new List<int>();
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    {
                        listaTablic[i].Add(tab[j,i]);
                    }
                }
            }
            return listaTablic;
        }
    }
}
