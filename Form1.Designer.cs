namespace Aplikacja
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wczytaj = new System.Windows.Forms.Button();
            this.zoomPlus = new System.Windows.Forms.Button();
            this.zoomMinus = new System.Windows.Forms.Button();
            this.normal = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(86, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 345);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Visible = false;
            this.button1.Location = new System.Drawing.Point(5, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Visible = false;
            this.button2.Location = new System.Drawing.Point(5, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wczytaj
            // 
            this.wczytaj.Location = new System.Drawing.Point(5, 13);
            this.wczytaj.Name = "wczytaj";
            this.wczytaj.Size = new System.Drawing.Size(75, 23);
            this.wczytaj.TabIndex = 3;
            this.wczytaj.Text = "Wczytaj";
            this.wczytaj.UseVisualStyleBackColor = true;
            this.wczytaj.Click += new System.EventHandler(this.wczytaj_Click);
            // 
            // zoomPlus
            // 
            this.zoomPlus.Location = new System.Drawing.Point(5, 258);
            this.zoomPlus.Name = "zoomPlus";
            this.zoomPlus.Size = new System.Drawing.Size(75, 23);
            this.zoomPlus.TabIndex = 4;
            this.zoomPlus.Text = "Zoom +";
            this.zoomPlus.UseVisualStyleBackColor = true;
            this.zoomPlus.Click += new System.EventHandler(this.zoomPlus_Click);
            // 
            // zoomMinus
            // 
            this.zoomMinus.Location = new System.Drawing.Point(5, 287);
            this.zoomMinus.Name = "zoomMinus";
            this.zoomMinus.Size = new System.Drawing.Size(75, 23);
            this.zoomMinus.TabIndex = 5;
            this.zoomMinus.Text = "Zoom -";
            this.zoomMinus.UseVisualStyleBackColor = true;
            this.zoomMinus.Click += new System.EventHandler(this.zoomMinus_Click);
            // 
            // normal
            // 
            this.normal.Location = new System.Drawing.Point(5, 317);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(75, 23);
            this.normal.TabIndex = 6;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.normal_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(5, 43);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 7;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 348);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.normal);
            this.Controls.Add(this.zoomMinus);
            this.Controls.Add(this.zoomPlus);
            this.Controls.Add(this.wczytaj);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Graph";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        
        public Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        public Microsoft.Msagl.Drawing.Graph graph;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button wczytaj;
        private System.Windows.Forms.Button zoomPlus;
        private System.Windows.Forms.Button zoomMinus;
        private System.Windows.Forms.Button normal;
        private System.Windows.Forms.Button Next;
    }
}

