using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Msagl;

namespace Aplikacja
{
    public partial class Form1 : Form
    {
        public const int max_n = 10000;
        public List<int>[] gS; //wyjście graf SSS
        public int[] sss = new int[max_n]; //wyjscie: numer SSS wierzchołka i
        public int ns; //wyjscie ilosc ns
        public int[] sssF = new int[max_n];
        public int ttt;
        public bool[] sssvis = new bool[max_n];
        public int n;
        public string[] grafSilny = new string[20];

        public int licznikNextButton = 0;
        public List<int>[] lista;
        public List<int>[] listaTransponowana;

        //public int[] visited; //dfs 
        //public int[] NR; //numer post order w DFS
        //public int nr = 1; //do numeracji
        //public int[] visitedSSS; // do Silnie spójnej składowej
        //public List<int>[] silnaWierzcholki; //wierzchołki należące do silnie spójnej składowej
        //public int licznikSilnych = 0; //ilosc silnych

        public Form1()
        {
            InitializeComponent();

            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.ToolBarIsVisible = false;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Controls.Add(viewer);
            //######################################################
            gS = new List<int>[max_n];
            for (int i = 0; i < max_n; i++)
            {
                {
                    gS[i] = new List<int>();
                }
            }





            //visited = new int[10000];
            //NR = new int[10000];
            //silnaWierzcholki = new List<int>[10000];
            //for (int i = 0; i < 10000; i++)
            //{
            //    {
            //        silnaWierzcholki[i] = new List<int>();
            //    }
            //}
            //visitedSSS = new int[10000];


            //graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create a graph object 
            //  Data macierz;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph = new Microsoft.Msagl.Drawing.Graph("graph");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("B", "A");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("D").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            graph.AddNode("E, F");
            graph.AddEdge("E,F", "A");

            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;

            viewer.Graph = graph;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            viewer.Refresh();
        }

        private void wczytaj_Click(object sender, EventArgs e)
        {
            int wiersze = 0;
            int kolumny = 0;

            Stream myStream = null;
            OpenFileDialog okno = new OpenFileDialog();
            okno.InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            okno.Filter = "Pliki tekstowy, macierz (txt)|*.txt";
            okno.ShowDialog();
            try
            {
                if ((myStream = okno.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(okno.FileName);
                        do
                        {
                            kolumny = sr.ReadLine().Length;
                            wiersze++;
                        } while (!sr.EndOfStream);

                        sr.DiscardBufferedData(); //czyszczenie bufora
                        sr.BaseStream.Seek(0, SeekOrigin.Begin); //powrót karetki odczytu pliku do początku
                        int wierszBledu = 1;
                        do
                        {
                            kolumny = sr.ReadLine().Length;
                            if (kolumny > 10)
                                throw new InvalidOptionException("Macierz nie może być większa niż 10x10", sr);
                            if (kolumny != wiersze)
                            {
                                throw new InvalidOptionException("Macierz nie jest kwadratowa\n" +
                                "Błąd w wierszu: " + wierszBledu, sr);
                            }
                            wierszBledu++;
                        } while (!sr.EndOfStream);

                        sr.DiscardBufferedData(); //czyszczenie bufora
                        sr.BaseStream.Seek(0, SeekOrigin.Begin); //powrót karetki odczytu pliku do początku

                        this.macierz = new Data(wiersze, kolumny);
                        int liczba = 0;
                        for (int i = 0; i < wiersze; i++)
                        {
                            string temp = sr.ReadLine();
                            for (int j = 0; j < kolumny; j++)
                            {
                                if (temp[j] == 48)
                                {
                                    liczba = 0;
                                    macierz.Write(i, j, liczba);
                                }
                                else if (temp[j] == 49)
                                {
                                    liczba = 1;
                                    macierz.Write(i, j, liczba);
                                }
                                else
                                    throw new InvalidOptionException("Macierz musi zawierać liczby 0 lub 1.\n", sr);
                            }
                        }
                        sr.Close();
                    }
                }
                MessageBox.Show("Liczba wierszy: " + wiersze.ToString() + "\n" + //do testow
                    "Liczba kolumn: " + kolumny);

                graph = new Microsoft.Msagl.Drawing.Graph("graph");

                //for (int i = 0; i < macierz.RowGet; i++)
                //{
                //    for (int j = 0; j < macierz.ColGet; j++)
                //    {
                //        if (macierz.Read(i, j) == 1)
                //        {
                //            graph.AddEdge((i + 1).ToString(), (j + 1).ToString());
                //        }
                //    }
                //} //prawidłowa macierz zaczytująca plik do grafu.
                lista = macierz.ToList();

                for (int i = 0; i < macierz.RowGet; i++)
                {
                    foreach (int element in lista[i])
                    {
                        graph.AddEdge((i + 1).ToString(), (element + 1).ToString());
                    }
                }

                viewer.Graph = graph;

            }
            catch (InvalidOptionException ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        public Data macierz { get; set; }



        private void zoomPlus_Click(object sender, EventArgs e)
        {
            viewer.ZoomInPressed();
        }

        private void zoomMinus_Click(object sender, EventArgs e)
        {
            viewer.ZoomOutPressed();
        }

        private void normal_Click(object sender, EventArgs e)
        {
            viewer.ZoomF = 1.0;
            viewer.Refresh();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            //lista = macierz.ToList();
            listaTransponowana = macierz.ToListTransponowany(lista);

            if (licznikNextButton == 0)
            {
                this.graph.Edges.Clear();

                viewer.Graph = graph;
                viewer.Refresh();

                //for (int i = 0; i < macierz.RowGet; i++)
                //{
                //    for (int j = 0; j < macierz.ColGet; j++)
                //    {
                //        if (macierz.Read(j, i) == 1)
                //        {
                //            graph.AddEdge((i + 1).ToString(), (j + 1).ToString());
                //        }
                //    }
                //} działa prawidłowo dla macierzy.

                // lista = macierz.ToList();

                for (int i = 0; i < macierz.RowGet; i++)
                {
                    foreach (int element in listaTransponowana[i])
                    {
                        graph.AddEdge((i + 1).ToString(), (element + 1).ToString());
                    }
                }


                //for (int i = 0; i < macierz.RowGet; i++)
                //{
                //    int licznik = 1;
                //    foreach (int element in listaTransponowana[i])
                //    {
                //        if (element == 1)
                //        {
                //            graph.AddEdge((i + 1).ToString(), licznik.ToString());

                //        }
                //        licznik++;
                //    }
                //}

                viewer.Graph = graph;
                viewer.Refresh();
                licznikNextButton++;
            }
            else if (licznikNextButton == 1)
            {
                n = macierz.RowGet;

                for (int i = 0; i < n; ++i)
                {
                    sssvis[i] = false;
                    gS[i].Clear();
                }
                ttt = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (!sssvis[i])
                    {
                        sss_dfs(i);
                    }
                }
                for (int i = 0; i < n; ++i)
                {
                    sssvis[i] = false;
                }
                ns = 0;
                for (int i = ttt - 1; i >= 0; --i)
                {
                    if (!sssvis[sssF[i]])
                    {
                        sss_dfs2(sssF[i]);
                        ++ns;
                    }
                }
                //MessageBox.Show("Liczba sss: " + ns);
                //for (int i = 0; i < ns; ++i)
                //{
                //    MessageBox.Show("Skladowa d: " + (i + 1));
                //    for (int v = 0; v < n; ++v)
                //        if (sss[v] == i)
                //        {
                //            MessageBox.Show("Wierzchołek " + (v + 1));
                //        }
                //}
                //#######################################
               
                this.graph.Edges.Clear();
                this.graph.NodeMap.Clear();
                viewer.Graph = graph;
                viewer.Refresh();

                for (int i = 0; i < ns; ++i)
                {
                    //string wyrazenie = null;

                    for (int v = 0; v < n; ++v)
                        if (sss[v] == i)
                        {
                            grafSilny[i] += (v + 1).ToString() + ",";
                        }

                   // graph.AddEdge((i + 1).ToString(), wyrazenie);
                }
                for (int i = 0; i < 19; i++)
                {
                    if (grafSilny[i + 1] != null)
                        graph.AddEdge(grafSilny[i].Remove(grafSilny[i].Length - 1), grafSilny[i + 1].Remove(grafSilny[i + 1].Length - 1));
                }

                viewer.Graph = graph;
                viewer.Refresh();
                licznikNextButton++;
            }

        }

        public void sss_dfs(int v)
        {
            sssvis[v] = true;
            
            //for (int i = 0; i < macierz.RowGet; i++)
            {
                foreach(int element in lista[v])
                {
                    if (!sssvis[element])
                        sss_dfs(element);

                }
            }
            sssF[ttt++] = v;
        }

        public void sss_dfs2(int v)
        {
            sss[v] = ns;
            sssvis[v] = true;
            //for (int i = 0; i < macierz.RowGet; i++)
            {
                foreach (int element in listaTransponowana[v])
                {
                    if (!sssvis[element])
                        sss_dfs2(element);
                }
            }
        }
    }
}
