using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjecaoCap3
{
    public partial class Form1 : Form
    {

        string filename;
        List<double[]> vtable;
        List<int[]> ftable;
        List<int[]> etable;
        List<double[]> eixo;
        int ajusteZ = 2;
        Point origemClick;
        Boolean manipulacaoAtiva = false;
        Pen canetaVertice;
        Pen canetaFace;
        SolidBrush pincelFace;
        Pen canetaAresta;
        Boolean[] renderizarElemento;
        double txAntigo;
        double tyAntigo;
        double tzAntigo;

        public Form1()
        {
            InitializeComponent();

            this.vtable = new List<double[]>();
            this.ftable = new List<int[]>();
            this.etable = new List<int[]>();

            this.eixo = new List<double[]>();
            this.eixo.Add(new double[3] { 0, 0, 0 });
            this.eixo.Add(new double[3] { 1, 0, 0 });
            this.eixo.Add(new double[3] { 0, 1, 0 });
            this.eixo.Add(new double[3] { 0, 0, 1 });

            this.txAntigo = this.tyAntigo = this.tzAntigo = 0;

            this.canetaVertice = new Pen(Color.Blue, 4);
            this.canetaFace = new Pen(Color.Black, 1);
            this.pincelFace = new SolidBrush(Color.FromArgb(70, Color.Gray));
            this.canetaAresta = new Pen(Color.Red, 1);

            this.renderizarElemento = new Boolean[4] {true, true, true, false};
        }

        private void atualizaTela() {
            Graphics gp = pictureBox1.CreateGraphics();

            int scale, scaleX, scaleY;

            pictureBox1.Refresh();

            Point[] pictureVertices = new Point[vtable.Count];

            if (this.pictureBox1.Height > this.pictureBox1.Width) {
                scale = this.pictureBox1.Width / 2;
                scaleY = this.pictureBox1.Height / 2;
                scaleX = scale;
            }
            else {
                scale = this.pictureBox1.Height / 2;
                scaleX = this.pictureBox1.Width / 2;
                scaleY = scale;
            }

            //renderizando referencial
            if(renderizarElemento[3]){

                List<double[]> p = new List<double[]>();
                List<int[]> pz = new List<int[]>();

                for (int i = 0; i < 4; i++ ) {
                    p.Add(multiplicar(eixo[i],
                                      Convert.ToDouble(trackBar1.Value),
                                      Convert.ToDouble(trackBar2.Value),
                                      Convert.ToDouble(trackBar3.Value)));

                    pz.Add(new int[2] { Convert.ToInt32(scale * ((p[i][0] / (p[i][2] + ajusteZ))) + scaleX), 
                                        Convert.ToInt32(scale * ((p[i][1] / (p[i][2] + ajusteZ))) + scaleY)});
                }

                gp.DrawLine(new Pen(Color.Red, 3), pz[0][0], pz[0][1], pz[3][0], pz[3][1]);
                gp.DrawLine(new Pen(Color.Lime, 3), pz[0][0], pz[0][1], pz[2][0], pz[2][1]);
                gp.DrawLine(new Pen(Color.Blue, 3), pz[0][0], pz[0][1], pz[1][0], pz[1][1]);
            }


            //renderizando vertices
            for (int i = 0; i < vtable.Count; i++)
            {

                double[] p1 = multiplicar(vtable[i],
                                            Convert.ToDouble(trackBar1.Value),
                                            Convert.ToDouble(trackBar2.Value),
                                            Convert.ToDouble(trackBar3.Value));

                double x = p1[0];
                double y = p1[1];
                double z = p1[2] + ajusteZ;

                double xprime = x / z;
                double yprime = y / z;

                pictureVertices[i].X = Convert.ToInt32(scale * xprime + scaleX);
                pictureVertices[i].Y = Convert.ToInt32(scale * yprime + scaleY);

                if(this.renderizarElemento[0]){
                    gp.DrawRectangle(canetaVertice,
                                     new Rectangle(pictureVertices[i].X,
                                                   pictureVertices[i].Y,
                                                   1,
                                                   1));   
                }
            }

            //renderizando faces
            if(this.renderizarElemento[1]){
                for (int i1 = 0; i1 < ftable.Count; i1++)
                {
                    int numeroVertices = ftable[i1].Length;

                    Point[] pontos = new Point[numeroVertices];

                    for (int k = 0; k < numeroVertices; k++)
                    {
                        pontos[k] = pictureVertices[ftable[i1][k]];
                    }

                    gp.FillPolygon(pincelFace,
                                   pontos);
                    gp.DrawPolygon(canetaFace,
                                   pontos);
                }
            }

            //renderizando arestas
            if(this.renderizarElemento[2]){
                for (int i2 = 0; i2 < etable.Count; i2++)
                {
                    int v1 = etable[i2][0];
                    int v2 = etable[i2][1];

                    gp.DrawLine(canetaAresta, pictureVertices[v1], pictureVertices[v2]);
                }
            }
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string linha = string.Empty;
            int nVertices = 0;
            int nFaces = 0;
            int nArestas = 0;

            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Abrir malha PLY";
            openFileDialog1.ShowDialog();

            if(openFileDialog1.FileName != ""){
                filename = openFileDialog1.FileName;

                System.IO.StreamReader file = new System.IO.StreamReader(filename);

                Boolean fimCabecalho = false;

                vtable.Clear();
                ftable.Clear();
                etable.Clear();

                //lê todas as linhas
                while(linha != null && fimCabecalho == false){
                   
                    linha = file.ReadLine();

                    //se a linha for de declaração de elemento...
                    if(linha.Substring(0, 3).Equals("ele")){
                        //...se for declaração de vertice......
                        if(linha.Substring(8, 6).Equals("vertex")){
                            nVertices = Convert.ToInt32(linha.Substring(15));
                        }
                        else{
                            //...se for declaração de face......
                            if (linha.Substring(8, 4).Equals("face")) {
                                nFaces = Convert.ToInt32(linha.Substring(13));
                            }
                            else {
                                //...se for declaração de aresta......
                                if (linha.Substring(8, 4).Equals("edge")) {
                                    nArestas = Convert.ToInt32(linha.Substring(13));
                                }
                            }
                        }
                    }
                    //se a linha for de fim de cabeçalho...
                    if(linha.Substring(0, 3).Equals("end")){
                        fimCabecalho = true;
                    }
                }

                //inserindo vertices
                for (int i = 0; i < nVertices; i++ ) {
                    linha = file.ReadLine();

                    linha = linha.Replace('.', ',');

                    var partes = linha.Split(' ');


                    vtable.Add(new double[3] { Convert.ToDouble(partes[0]), 
                                               Convert.ToDouble(partes[1]), 
                                               Convert.ToDouble(partes[2])});
                }

                //inserindo faces
                for (int i = 0; i < nFaces; i++) {
                    linha = file.ReadLine();

                    var partes = linha.Split(' ');

                    int numeroVerticesFace = Convert.ToInt32(partes[0]);

                    int[] verticesFace = new int[numeroVerticesFace];

                    for (int k = 0; k < numeroVerticesFace; k++ ) {
                        verticesFace[k] = Convert.ToInt32(partes[k + 1]);
                    }

                    ftable.Add(verticesFace);
                }

                //inserindo arestas
                for (int i = 0; i < nArestas; i++) {
                    linha = file.ReadLine();

                    var partes = linha.Split(' ');

                    etable.Add(new int[2] { Convert.ToInt32(partes[0]), 
                                            Convert.ToInt32(partes[1]) });
                }

                file.Close();

                this.Text = "Projeção (" + filename + ")";

                toolStripStatusLabel1.Text = "vertices: " + nVertices + ", faces: " + nFaces + ", arestas: " + nArestas;

                MessageBox.Show(this, "PLY carregado com sucesso!", "Projeção - Aviso");

                this.atualizaTela();
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Update the mouse path with the mouse information
            Point localClick = new Point(e.X, e.Y);

            this.origemClick = localClick;

            this.manipulacaoAtiva = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) { 
            if(this.manipulacaoAtiva){
                Point localMovimento = new Point(e.X, e.Y);

                this.trackBar1.Value = (-1 * (localMovimento.Y - origemClick.Y)) % 360;
                this.trackBar2.Value = (localMovimento.X - origemClick.X) % 360;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            this.manipulacaoAtiva = false;
        }

        private double[] multiplicar(double[] ponto, double angulo1, double angulo2, double angulo3) {

            angulo1 = angulo1 * Math.PI / 180;
            angulo2 = angulo2 * Math.PI / 180;
            angulo3 = angulo3 * Math.PI / 180;

            double[,] matrizEuler = new double[3, 3] {{Math.Cos(angulo2) * Math.Cos(angulo3), Math.Cos(angulo3) * Math.Sin(angulo1) * Math.Sin(angulo2) - Math.Cos(angulo1) * Math.Sin(angulo3), Math.Cos(angulo1) * Math.Cos(angulo3) * Math.Sin(angulo2) + Math.Sin(angulo1) * Math.Sin(angulo3)},
                                                      {Math.Cos(angulo2) * Math.Sin(angulo3), Math.Cos(angulo1) * Math.Cos(angulo3) + Math.Sin(angulo1) * Math.Sin(angulo2) * Math.Sin(angulo3), -1 * Math.Cos(angulo3) * Math.Sin(angulo1) + Math.Cos(angulo1) * Math.Sin(angulo2) * Math.Sin(angulo3)},
                                                      {        -1 * Math.Sin(angulo2)       ,                                   Math.Cos(angulo2) * Math.Sin(angulo1)                          ,                                 Math.Cos(angulo1) * Math.Cos(angulo2)                                 }};
            
            double[] p1 = new double[3]{0, 0, 0};

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    p1[i] += ponto[j] * matrizEuler[j, i];
                }
            }

            return p1;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e) 
        {
            label1.Text = "Eixo X (" + trackBar1.Value + "°)";

            this.atualizaTela();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "Eixo Y (" + trackBar2.Value + "°)";

            this.atualizaTela();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "Eixo Z (" + trackBar3.Value + "°)";

            this.atualizaTela();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e) { 
            double t = Convert.ToDouble(this.trackBar4.Value) / 5;

            this.label4.Text = "Eixo X (" + t + ")";

            for(int i = 0; i < this.vtable.Count; i++){
                this.vtable[i][0] += (t - this.txAntigo);
            }

            this.txAntigo = t;

            this.atualizaTela();
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e) {
            double t = Convert.ToDouble(this.trackBar5.Value) / 5;

            this.label5.Text = "Eixo Y (" + t + ")";

            for (int i = 0; i < this.vtable.Count; i++)
            {
                this.vtable[i][1] += (t - this.tyAntigo);
            }

            this.tyAntigo = t;

            this.atualizaTela();
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e) {
            double t = Convert.ToDouble(this.trackBar6.Value) / 5;

            this.label6.Text = "Eixo Z (" + t + ")";

            for (int i = 0; i < this.vtable.Count; i++)
            {
                this.vtable[i][2] += (t - this.tzAntigo);
            }

            this.tzAntigo = t;

            this.atualizaTela();
        }

        private void verticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.renderizarElemento[0] = !this.renderizarElemento[0];

            this.atualizaTela();
        }

        private void facesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.renderizarElemento[1] = !this.renderizarElemento[1];

            this.atualizaTela();
        }

        private void arestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.renderizarElemento[2] = !this.renderizarElemento[2];

            this.atualizaTela();
        }

        private void verticesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            Color cor = colorDialog1.Color;

            this.canetaVertice.Color = cor;

            this.atualizaTela();
        }

        private void contornoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            Color cor = colorDialog1.Color;

            this.canetaFace.Color = cor;

            this.atualizaTela();
        }

        private void áreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            Color cor = colorDialog1.Color;

            this.pincelFace.Color = Color.FromArgb(70, cor);

            this.atualizaTela();
        }

        private void arestasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            Color cor = colorDialog1.Color;

            this.canetaAresta.Color = cor;

            this.atualizaTela();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog();
        }

        private void Form1_Resize(object sender, System.EventArgs e) {

            Control control = (Control)sender;

            Size s = new Size(control.Width - 400,
                              control.Height - 135);

            this.pictureBox1.Size = s;

            this.atualizaTela();
        }

        private void toolStripButton1_CheckedChanged(object sender, System.EventArgs e) {
            this.renderizarElemento[3] = this.toolStripButton1.Checked;

            this.atualizaTela();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            double[] maior = new double[3], menor = new double[3];

            maior[0] = menor[0] = vtable[0][0];
            maior[1] = menor[1] = vtable[0][1];
            maior[2] = menor[2] = vtable[0][2];

            //busca de maior e menor valores
            for (int i = 1; i < this.vtable.Count; i++)
            {
                //maior x
                if (this.vtable[i][0] > maior[0])
                {
                    maior[0] = this.vtable[i][0];
                }
                //menor x
                if (this.vtable[i][0] < menor[0])
                {
                    menor[0] = this.vtable[i][0];
                }

                //maior y
                if (this.vtable[i][1] > maior[1])
                {
                    maior[1] = this.vtable[i][1];
                }
                //menor y
                if (this.vtable[i][1] < menor[1])
                {
                    menor[1] = this.vtable[i][1];
                }

                //maior z
                if (this.vtable[i][2] > maior[2])
                {
                    maior[2] = this.vtable[i][2];
                }
                //menor z
                if (this.vtable[i][2] < menor[2])
                {
                    menor[2] = this.vtable[i][2];
                }
            }

            //cálculo de baricentro
            double bx, by, bz;

            bx = (maior[0] + menor[0]) / 2;
            by = (maior[1] + menor[1]) / 2;
            bz = (maior[2] + menor[2]) / 2;

            //translação
            for(int i = 0; i < vtable.Count; i++){
                this.vtable[i][0] -= bx;
                this.vtable[i][1] -= by;
                this.vtable[i][2] -= bz;
            }

            this.txAntigo = this.tyAntigo = this.tzAntigo = 0;

            this.trackBar4.Value = 0;
            this.trackBar5.Value = 0;
            this.trackBar6.Value = 0;

            this.atualizaTela();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            double maior = 0;;

            //inicialização de maior
            if(this.vtable[0][0] >= this.vtable[0][1] && this.vtable[0][0] >= this.vtable[0][2]){
                maior = this.vtable[0][0];
            }
            else{
                if (this.vtable[0][1] >= this.vtable[0][0] && this.vtable[0][1] >= this.vtable[0][2]){
                    maior = this.vtable[0][1];
                }
                else{
                    if (this.vtable[0][2] >= this.vtable[0][0] && this.vtable[0][2] >= this.vtable[0][1]){
                        maior = this.vtable[0][2];
                    }
                }
            }

            //busca de maior valor
            for (int i = 1; i < this.vtable.Count; i++) {
                double m;

                if (this.vtable[i][0] >= this.vtable[i][1] && this.vtable[i][0] >= this.vtable[i][2]){
                    m = this.vtable[i][0];
                }
                else{
                    if (this.vtable[i][1] >= this.vtable[i][0] && this.vtable[i][1] >= this.vtable[i][2]){
                        m = this.vtable[i][1];
                    }
                    else{
                        if (this.vtable[i][2] >= this.vtable[i][0] && this.vtable[i][2] >= this.vtable[i][1]){
                            m = this.vtable[i][2];
                        }
                    }
                }
            }

            //escalonamento
            for (int i = 0; i < vtable.Count; i++){
                this.vtable[i][0] /= maior;
                this.vtable[i][1] /= maior;
                this.vtable[i][2] /= maior;
            }

            this.atualizaTela();
        }
    }
}
