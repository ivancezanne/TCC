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

            this.r = new Regiao(this.pictureBox1.Width, this.pictureBox1.Height);
        }

        private void atualizaTela(){
            Graphics graf = this.pictureBox1.CreateGraphics();

            this.pictureBox1.Refresh();
            
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

            switch(this.r.npontos){
                case 0:
                    if(coordinates.X < this.r.pontos[1].X && coordinates.Y < this.r.pontos[1].Y){
                        this.r.pontos[0] = coordinates;
                        this.r.npontos = 1;

                        this.atualizaTela();
                    }
                    else{
                        MessageBox.Show(this, "Você deve marcar o canto superior esquerdo da região.", "Erro!");
                    }
                    break;
                case 1:
                    if (coordinates.X > this.r.pontos[0].X && coordinates.Y > this.r.pontos[0].Y) {
                        this.r.pontos[1] = coordinates;
                        this.r.npontos = 0;

                        this.atualizaTela();
                    }
                    else {
                        MessageBox.Show(this, "Você deve marcar o canto inferior direito da região.", "Erro!");
                    }
                    break;
            }
        }

        private void abrirImagemToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Title = "Abrir imagem";

            this.openFileDialog1.ShowDialog();

            if (this.openFileDialog1.FileName != "") {
                String arquivo = this.openFileDialog1.FileName;

                this.pictureBox1.Image = new Bitmap(arquivo);

                this.Text = "Mínimos Quadrados (" + arquivo + ")";

                this.resetarRegiãoDeInteresseToolStripMenuItem_Click(sender, e);
            }
        }

        private void executarAproximaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagem = (Bitmap)pictureBox1.Image;

            this.r.interesse.Clear();

            if(this.pictureBox1.Image != null) {
                for (int x = 0; x < this.pictureBox1.Image.Width; x++) {
                    for (int y = 0; y < this.pictureBox1.Image.Height; y++) {
                        //verifica se está na região quadrada selecionada...
                        if (x > this.r.pontos[0].X && x < this.r.pontos[1].X && y > this.r.pontos[0].Y && y < this.r.pontos[1].Y) {
                            //verifica se é (quase)preto...
                            Color ponto = imagem.GetPixel(x, y);
                            if (ponto.R < 32 && ponto.G < 32 && ponto.B < 32) {
                                this.r.interesse.Add(new Point(x, y));
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

                MessageBox.Show(this, "Aproximação concluída.", "Aviso");
            }
            else{
                MessageBox.Show(this, "Você precisa abrir uma imagem antes de detectar linhas", "Erro!");
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog(this);
        }

        private void resetarRegiãoDeInteresseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.r.pontos[0] = new Point(0, 0);
            this.r.pontos[1] = new Point(this.pictureBox1.Width, this.pictureBox1.Height);

            this.r.npontos = 0;

            this.pictureBox1.Refresh();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
