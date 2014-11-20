using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinimosQuadrados
{
    public partial class Form1 : Form
    {

        Regiao r;

        public Form1()
        {
            InitializeComponent();

            r = new Regiao();
        }

        private void atualizaTela(){
            Graphics graf = this.pictureBox1.CreateGraphics();

            pictureBox1.Refresh();
            
            graf.DrawRectangle(new Pen(Color.Red),
                               r.pontos[0].X,
                               r.pontos[0].Y,
                               Math.Abs(r.pontos[1].X - r.pontos[0].X),
                               Math.Abs(r.pontos[1].Y - r.pontos[0].Y));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            r.pontos[r.npontos] = coordinates;

            switch(r.npontos){
                case 0:
                    r.npontos++;
                    break;
                case 1:
                    r.npontos = 0;
                    break;
            }

            this.atualizaTela();
        }

        private void abrirImagemToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Abrir imagem";

            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                String arquivo = openFileDialog1.FileName;

                pictureBox1.Image = new Bitmap(arquivo);

                this.Text = "Mínimos Quadrados (" + arquivo + ")";
            }
        }

        private void executarAproximaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagem = (Bitmap)pictureBox1.Image;

            r.interesse.Clear();

            for (int x = 0; x < pictureBox1.Image.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    //verifica se está na região quadrada selecionada...
                    if (x > r.pontos[0].X && x < r.pontos[1].X && y > r.pontos[0].Y && y < r.pontos[1].Y)
                    {
                        //verifica se é (quase)preto...
                        Color ponto = imagem.GetPixel(x, y);
                        if (ponto.R < 32 && ponto.G < 32 && ponto.B < 32)
                        {
                            r.interesse.Add(new Point(x, y));
                        }
                    }
                }
            }


            double m = r.descobreM();
            double b = r.descobreB();

            label1.Text = "m = " + m + " e b = " + b;

            Point p1 = new Point(0, Convert.ToInt32(m * 0 + b));
            Point p2 = new Point(this.pictureBox1.Width, Convert.ToInt32(m * this.pictureBox1.Width + b));

            Graphics graf = pictureBox1.CreateGraphics();

            graf.DrawLine(new Pen(Color.Blue, 2), p1, p2);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog(this);
        }
    }
}
