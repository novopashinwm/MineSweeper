using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweeper
{
    public delegate void deShowBox(int x, int y, int num);

    public partial class Form1 : Form
    {
        //Ширина и высота боксика
        int boxW, boxH;
        //Ширина и высота панели
        int w,  h;

        private int cols = 15;
        private int rows = 15;
        private int total = 10;

        Mines mines;
        PictureBox[,] arr;

        public Form1()
        {
            InitializeComponent();
            boxW = 24;
            boxH = 24;

           // PlacePictureBox(0, 10, 5);
            StartGame();
            CreateBoxes();
            mines.ShowAll();
        }

        private void CreateBoxes()
        {
            for (int x = 0; x < cols; x++)
            for (int y = 0; y < rows; y++)
                arr[x,y]=PlacePictureBox(x, y);
        }

        public void StartGame()
        {
            mines = new Mines(cols, rows, total,ShowPictureBox);
            arr = new PictureBox[cols, rows];

            this.ClientSize = new System.Drawing.Size(cols * boxW, rows * boxH + boxH);
            this.panel.Location = new Point(0, boxH);
            this.panel.Size = new System.Drawing.Size(cols * boxW, rows * boxH);
            this.panel.Controls.Clear();
            
            mines.Init();
            mines.PlacedMines();                       
        }
        
        public PictureBox PlacePictureBox(int x, int y)
        {
            PictureBox box = new PictureBox();            
            box.Image = Properties.Resources.clos;
            box.Tag = new Point(x, y);
            box.Location = new System.Drawing.Point(x * boxW, y * boxH);
            box.Size = new System.Drawing.Size(boxW, boxH);
            box.MouseClick += new MouseEventHandler(this.box_Click);

            box.SizeMode = PictureBoxSizeMode.StretchImage;
            panel.Controls.Add(box);            
            return box;
        }

        bool isMessage = false;

        public void ShowPictureBox (int x, int y, int num)
        {            
            arr[x, y].Image = ShowBoxImage(num);
            if (mines.gameover == GameOver.yourWin && !isMessage) {
                MessageBox.Show("Вы выиграли!");
                isMessage = true;
            }
            else if (mines.gameover == GameOver.yourLost && !isMessage) {
                MessageBox.Show("Игра закончена!");
                isMessage = true;
            }

            lblFlagCount.Text = string.Format(" Флажки:{0}", mines.Total- mines.FlagCnt);
            lblHeight.Text = string.Format(" Высота:{0}", mines.Rows);
            lblWidth.Text = string.Format(" Ширина:{0}", mines.Cols);
            lblTotal.Text = string.Format(" Мины:{0}", mines.Total);

        }

        Bitmap ShowBoxImage(int num) 
        {
            switch (num) {
                case 0: return Properties.Resources._0;
                case 1: return Properties.Resources._1;
                case 2: return Properties.Resources._2;
                case 3: return Properties.Resources._3;
                case 4: return Properties.Resources._4;
                case 5: return Properties.Resources._5;
                case 6: return Properties.Resources._6;
                case 7: return Properties.Resources._7;
                case 8: return Properties.Resources._8;
                case 9: return Properties.Resources.mine;
                case 101: return Properties.Resources.clos;
                case 102: return Properties.Resources.flag;
                case 103: return Properties.Resources.ques;
                default: return null;
            }
        }

        private void box_Click(object sender, MouseEventArgs e)
        {
            Point point = (Point)((PictureBox)sender).Tag;

            int x = point.X;
            int y = point.Y;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mines.OpenMap(x, y);    
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mines.MarkMines(x, y);               
            }
            
        }

        private void mnuGameBeginer_Click(object sender, EventArgs e)
        {
            rows = 9; cols = 9; total = 10;
            StartGame();
            CreateBoxes();
            mines.ShowAll();
        }

        private void mnuGameMiddle_Click(object sender, EventArgs e)
        {
            rows = 16; cols = 16; total = 40;
            StartGame();
            CreateBoxes();
            mines.ShowAll();

        }

        private void mnuGameProfi_Click(object sender, EventArgs e)
        {
            rows = 16; cols = 32; total = 99;
            StartGame();
            CreateBoxes();
            mines.ShowAll();

        }

        private void mnuGameNew_Click(object sender, EventArgs e)
        {
            StartGame();
            CreateBoxes();
            mines.ShowAll();
        }

        private void mnuGameExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuGameUser_Click(object sender, EventArgs e)
        {
            FormSpecial objFrm = new FormSpecial();
            objFrm.ShowDialog();
            if (objFrm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                rows = int.Parse( objFrm.txtHeight.Text) ;
                cols = int.Parse(objFrm.txtWidth.Text);
                total = int.Parse(objFrm.txtTotal.Text);
                StartGame();
                CreateBoxes();
                mines.ShowAll();
            }
        }

    }
}
