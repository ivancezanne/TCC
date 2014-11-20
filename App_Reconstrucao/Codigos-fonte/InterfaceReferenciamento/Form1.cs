using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InterfaceReferenciamento
{
    public partial class Form1 : Form
    {

        private string nomeArquivo;
        private Referencia referencia;
        private Boolean[] visualizar;
        private Camera camera;
        private Interesse interesse;

        public Form1()
        {
            InitializeComponent();

            this.referencia = new Referencia();
            this.visualizar = new Boolean[3] { true, true, false };
            this.camera = new Camera();
            this.interesse = new Interesse();
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Title = "Abrir imagem";

            this.openFileDialog1.ShowDialog(this);

            if(this.openFileDialog1.FileName != ""){

                nomeArquivo = openFileDialog1.FileName;

                pictureBox1.Image = new Bitmap(nomeArquivo);

                this.Text = "TCC (" + nomeArquivo + ")";

                this.referencia.removeReferencia();

                this.resetaReferencias();

                this.atualizarReferências();

            }
        }

        private void atualizarReferências() {
            Graphics pbgfx = pictureBox1.CreateGraphics();

            pictureBox1.Refresh();

            //renderizar pontos e faces referenciadas pelo usuário
            if(this.visualizar[0]) {
                Point[, ,] pontos = this.referencia.pontos();

                for (int i = 0; i < 2; i++) {
                    for (int j = 0; j < 2; j++) {
                        for (int k = 0; k < 2; k++) {
                            if (this.referencia.referenciado(i, j, k)) {

                                pbgfx.FillEllipse(new SolidBrush(Color.Blue),
                                                  pontos[i, j, k].X - 4,
                                                  pictureBox1.Height - pontos[i, j, k].Y - 4,
                                                  9,
                                                  9);
                                pbgfx.DrawString("(" + i + ", " + j + ", " + k + ")",
                                                 new Font("Times New Roman", 10),
                                                 new SolidBrush(Color.Black),
                                                 pontos[i, j, k].X - 23,
                                                 pictureBox1.Height - pontos[i, j, k].Y + 7);
                            }
                        }
                    }
                }

                //face de baixo (lime)
                if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(1, 0, 0) &&
                   this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(0, 1, 0)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(60, 190, 255, 0)),
                                       pontosTransformados);
                }

                //face de cima (quasi-red)
                if (this.referencia.referenciado(0, 0, 1) && this.referencia.referenciado(1, 0, 1) &&
                   this.referencia.referenciado(1, 1, 1) && this.referencia.referenciado(0, 1, 1)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(60, 250, 10, 0)),
                                      pontosTransformados);
                }

                //face da frente esquerda (cyan)
                if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(1, 0, 0) &&
                   this.referencia.referenciado(1, 0, 1) && this.referencia.referenciado(0, 0, 1)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(90, 0, 255, 255)),
                                      pontosTransformados);
                }

                //face da frente direita (yellow)
                if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(0, 1, 0) &&
                   this.referencia.referenciado(0, 1, 1) && this.referencia.referenciado(0, 0, 1)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),
                                                                new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 255, 0)),
                                      pontosTransformados);
                }

                //face da trás esquerda (lily)
                if (this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(1, 0, 0) &&
                   this.referencia.referenciado(1, 0, 1) && this.referencia.referenciado(1, 1, 1)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 0, 255)),
                                      pontosTransformados);
                }

                //face da trás direita (orange)
                if (this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(0, 1, 0) &&
                   this.referencia.referenciado(0, 1, 1) && this.referencia.referenciado(1, 1, 1)) {

                    Point[] pontosTransformados = new Point[] { new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),};

                    pbgfx.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 153, 0)),
                                      pontosTransformados);
                }
            }

            //renderizar pontos de interesse
            if(this.visualizar[1]) {
                List<Point> pontos = this.interesse.interesses();
                List<int> planos = this.interesse.interesses(true);
                Color cor = Color.Gold;

                for (int i = 0; i < pontos.Count; i++){

                    switch(planos[i] % 10){
                        case 0:
                            cor = Color.Black;
                            break;
                        case 1:
                            cor = Color.Brown;
                            break;
                        case 2:
                            cor = Color.Green;
                            break;
                        case 3:
                            cor = Color.DarkKhaki;
                            break;
                        case 4:
                            cor = Color.Chocolate;
                            break;
                        case 5:
                            cor = Color.Orange;
                            break;
                        case 6:
                            cor = Color.Yellow;
                            break;
                        case 7:
                            cor = Color.Beige;
                            break;
                        case 8:
                            cor = Color.Fuchsia;
                            break;
                        case 9:
                            cor = Color.Gray;
                            break;
                    }

                    Pen caneta = new Pen(cor, 3);

                    pbgfx.DrawLine(caneta,
                                   pontos[i].X - 5,
                                   pictureBox1.Height - pontos[i].Y - 5,
                                   pontos[i].X + 5,
                                   pictureBox1.Height - pontos[i].Y + 5);

                    pbgfx.DrawLine(caneta,
                                   pontos[i].X + 5,
                                   pictureBox1.Height - pontos[i].Y - 5,
                                   pontos[i].X - 5,
                                   pictureBox1.Height - pontos[i].Y + 5);
                }
            }

            //renderizar aproximações das referências
            if(this.visualizar[2]) {
                this.camera.calculaReferenciasAproximadas();
                Point[, ,] r = this.camera.referenciasAproximadas();

                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 0, 0].X,
                               pictureBox1.Height - r[0, 0, 0].Y,
                               r[1, 0, 0].X,
                               pictureBox1.Height - r[1, 0, 0].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[1, 0, 0].X,
                               pictureBox1.Height - r[1, 0, 0].Y,
                               r[1, 1, 0].X,
                               pictureBox1.Height - r[1, 1, 0].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                                r[1, 1, 0].X,
                                pictureBox1.Height - r[1, 1, 0].Y,
                                r[0, 1, 0].X,
                                pictureBox1.Height - r[0, 1, 0].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 1, 0].X,
                               pictureBox1.Height - r[0, 1, 0].Y,
                               r[0, 0, 0].X,
                               pictureBox1.Height - r[0, 0, 0].Y);

                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 0, 1].X,
                               pictureBox1.Height - r[0, 0, 1].Y,
                               r[1, 0, 1].X,
                               pictureBox1.Height - r[1, 0, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[1, 0, 1].X,
                               pictureBox1.Height - r[1, 0, 1].Y,
                               r[1, 1, 1].X,
                               pictureBox1.Height - r[1, 1, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[1, 1, 1].X,
                               pictureBox1.Height - r[1, 1, 1].Y,
                               r[0, 1, 1].X,
                               pictureBox1.Height - r[0, 1, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 1, 1].X,
                               pictureBox1.Height - r[0, 1, 1].Y,
                               r[0, 0, 1].X,
                               pictureBox1.Height - r[0, 0, 1].Y);

                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 0, 0].X,
                               pictureBox1.Height - r[0, 0, 0].Y,
                               r[0, 0, 1].X,
                               pictureBox1.Height - r[0, 0, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[1, 0, 0].X,
                               pictureBox1.Height - r[1, 0, 0].Y,
                               r[1, 0, 1].X,
                               pictureBox1.Height - r[1, 0, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[1, 1, 0].X,
                               pictureBox1.Height - r[1, 1, 0].Y,
                               r[1, 1, 1].X,
                               pictureBox1.Height - r[1, 1, 1].Y);
                pbgfx.DrawLine(new Pen(Color.Red, 3),
                               r[0, 1, 0].X,
                               pictureBox1.Height - r[0, 1, 0].Y,
                               r[0, 1, 1].X,
                               pictureBox1.Height - r[0, 1, 1].Y);
            }
        }

        private void resetaReferencias() {
            int xMedio = this.pictureBox1.Image.Width / 2;
            int yMedio = this.pictureBox1.Image.Height / 2;
            int ajusteX = xMedio / 3;
            int ajusteY = yMedio / 3;

            this.referencia.insereReferencia(0, 0, 0, xMedio, yMedio - ajusteY);
            this.referencia.insereReferencia(1, 0, 0, xMedio - ajusteX, yMedio);
            this.referencia.insereReferencia(1, 1, 0, xMedio, yMedio + ajusteY);
            this.referencia.insereReferencia(0, 1, 0, xMedio + ajusteX, yMedio);
            this.referencia.insereReferencia(0, 0, 1, xMedio, yMedio);
            this.referencia.insereReferencia(1, 0, 1, xMedio - ajusteX, yMedio + ajusteY);
            this.referencia.insereReferencia(1, 1, 1, xMedio, yMedio + 2 * ajusteY);
            this.referencia.insereReferencia(0, 1, 1, xMedio + ajusteX, yMedio + ajusteY);

            this.interesse.removeInteresse();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var click = e as MouseEventArgs;
            Point p = click.Location;

            PromptReferencia prompt = new PromptReferencia();
            prompt.ShowDialog(this);

            int[] ponto3d = prompt.valores();
            int idPlano = prompt.idPlano();
            int tipo = prompt.qualTipo();

            prompt.Dispose();

            if(tipo == 1){
                if (ponto3d[0] + ponto3d[1] + ponto3d[2] >= 0){
                    this.referencia.insereReferencia(ponto3d[0],
                                                     ponto3d[1],
                                                     ponto3d[2],
                                                     p.X,
                                                     pictureBox1.Height - p.Y);
                }
            }
            else{
                if(tipo == 2){
                    this.interesse.insereInteresse(p.X, pictureBox1.Height - p.Y, idPlano);
                }
            }

            this.atualizarReferências();
        }

        private void verReferênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptPontosReferencia prompt = new PromptPontosReferencia(this.referencia.pontos());
            prompt.ShowDialog(this);
        }

        private void apagarPontoDeReferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptRemocaoReferencia prompt = new PromptRemocaoReferencia(this.referencia.pontos());
            prompt.ShowDialog(this);

            Boolean[,,] p = prompt.remocoes();

            prompt.Dispose();

            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        if(p[i, j, k]){
                            this.referencia.removeReferencia(i, j, k);
                        }
                    }
                }
            }

            this.atualizarReferências();
        }

        private void executarCalibraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.referencia.quantosPontos() == 8) {
                this.Cursor = Cursors.WaitCursor;

                this.camera.calibrar(this.referencia.pontos());

                this.Cursor = Cursors.Default;

                MessageBox.Show(this, "Câmera calibrada!", "TCC - Aviso");
            }
            else {
                MessageBox.Show(this, "Você precisa referenciar todos os 8 pontos para calibrar a câmera!", "TCC - Erro");
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog();
        }

        private void sistemaDeReferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.visualizar[0]) {
                this.visualizar[0] = false;
            }
            else {
                this.visualizar[0] = true;
            }

            this.atualizarReferências();
        }

        private void pontosDeInteresseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.visualizar[1]){
                this.visualizar[1] = false;
            }
            else{
                this.visualizar[1] = true;
            }

            this.atualizarReferências();
        }

        private void aproximaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.visualizar[2]) {
                this.visualizar[2] = false;
            }
            else {
                if(this.camera.estaCalibrada()){
                    this.visualizar[2] = true;
                }
                else{
                    MessageBox.Show(this, "Visualizar as aproximações só é possível após calibrar a câmera!", "TCC - Erro");
                    this.aproximaçãoToolStripMenuItem.Checked = false;
                }
            }

            this.atualizarReferências();
        }

        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image != null){
                this.openFileDialog2.FileName = "";
                this.openFileDialog2.Title = "Abrir arquivo de referências";

                this.openFileDialog2.ShowDialog(this);

                if (this.openFileDialog2.FileName != ""){
                    System.IO.StreamReader arquivo = new System.IO.StreamReader(this.openFileDialog2.FileName);

                    String linha;
                    String[] elemento;

                    while ((linha = arquivo.ReadLine()) != null){
                        elemento = linha.Split(' ');

                        this.referencia.insereReferencia(Convert.ToInt32(elemento[0]),
                                                         Convert.ToInt32(elemento[1]),
                                                         Convert.ToInt32(elemento[2]),
                                                         Convert.ToInt32(elemento[3]),
                                                         Convert.ToInt32(elemento[4]));
                    }

                    arquivo.Close();

                    MessageBox.Show(this, "Referências carregadas com sucesso!", "TCC - Aviso");

                    if (this.pictureBox1.Image != null){
                        this.atualizarReferências();
                    }
                }
            }
            else{
                MessageBox.Show(this, "Você precisa abrir uma imagem antes de referenciá-la!", "TCC - Erro");
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image != null){
                System.IO.StreamWriter arquivoSaida;

                this.saveFileDialog1.FileName = "";
                this.saveFileDialog1.Title = "Salvar arquivo de referências";
                this.saveFileDialog1.ShowDialog(this);

                if (this.saveFileDialog1.FileName != "")
                {
                    arquivoSaida = new System.IO.StreamWriter(this.saveFileDialog1.FileName);

                    Point[, ,] pontos = this.referencia.pontos();

                    for (int x = 0; x < 2; x++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                            for (int z = 0; z < 2; z++)
                            {
                                arquivoSaida.WriteLine(x + " " + y + " " + z + " " + pontos[x, y, z].X + " " + pontos[x, y, z].Y);
                            }
                        }
                    }

                    arquivoSaida.Close();

                    MessageBox.Show(this, "Referências salvas com sucesso!", "TCC - Aviso");
                }
            }
            else{
                MessageBox.Show(this, "Você precisa ter aberto uma imagem para ter referenciado-a!", "TCC - Erro");
            }
        }

        private void verPontosDeInteresseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptPontosInteresse prompt = new PromptPontosInteresse(this.interesse.interesses(), 
                                                                     this.interesse.interesses(true));
            prompt.ShowDialog(this);
        }

        private void apagarPontoDeInteresseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptRemocaoInteresse prompt = new PromptRemocaoInteresse(this.interesse.interesses(),
                                                                       this.interesse.interesses(true));
            prompt.ShowDialog(this);

            int[,] p = prompt.remocoes();

            prompt.Dispose();

            for (int i = 0; i < p.GetLength(0); i++){
                if(p[i, 0] != -1 && p[i, 1] != -1){
                    int indiceReal = this.interesse.interesses().FindIndex(item => (item.X == p[i, 0] && item.Y == p[i, 1]));
                    this.interesse.removeInteresse(indiceReal);
                }
            }

            this.atualizarReferências();
        }

        private void carregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image != null){
                this.openFileDialog2.FileName = "";
                this.openFileDialog2.Title = "Abrir arquivo de pontos de interesse";

                this.openFileDialog2.ShowDialog(this);

                if (this.openFileDialog2.FileName != "")
                {
                    System.IO.StreamReader arquivo = new System.IO.StreamReader(this.openFileDialog2.FileName);

                    String linha;
                    String[] elemento;

                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        elemento = linha.Split(' ');

                        this.interesse.insereInteresse(Convert.ToInt32(elemento[0]),
                                                       Convert.ToInt32(elemento[1]),
                                                       Convert.ToInt32(elemento[2]));
                    }

                    arquivo.Close();

                    MessageBox.Show(this, "Interesses carregados com sucesso!", "TCC - Aviso");

                    if (this.pictureBox1.Image != null)
                    {
                        this.atualizarReferências();
                    }
                }
            }
            else{
                MessageBox.Show(this, "Você precisa abrir uma imagem para demarcar pontos de interesse!", "TCC - Erro");
            }
        }

        private void salvarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image != null){
                System.IO.StreamWriter arquivoSaida;

                this.saveFileDialog1.FileName = "";
                this.saveFileDialog1.Title = "Salvar arquivo de pontos de interesse";
                this.saveFileDialog1.ShowDialog(this);

                if (this.saveFileDialog1.FileName != "")
                {
                    arquivoSaida = new System.IO.StreamWriter(this.saveFileDialog1.FileName);

                    List<Point> pontos = this.interesse.interesses();
                    List<int> planos = this.interesse.interesses(true);

                    for (int i = 0; i < pontos.Count; i++)
                    {
                        arquivoSaida.WriteLine(pontos[i].X + " " + pontos[i].Y + " " + planos[i]);
                    }

                    arquivoSaida.Close();

                    MessageBox.Show(this, "Interesses salvos com sucesso!", "TCC - Aviso");
                }
            }
            else{
                MessageBox.Show(this, "Você precisa ter aberto uma imagem para ter pontos de interesse!", "TCC - Erro");
            }
        }

        private void executarReconstruçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double incremento = 0.005;
            int toleranciaPlanar = 3;
            int criterio = 0;
            Boolean ok;

            Boolean abortar = false;

            System.IO.StreamWriter arquivoSaida;

            List<Point> interesse = this.interesse.interesses();
            List<int> plano = this.interesse.interesses(true);

            List<Point> pontosPlano = new List<Point>(); //guarda os pontos de um plano por vez
            int planoAtual = 0; //indica o plano atual

            List<double> valoresZ = new List<double>(); //guarda os valores z gerais
            List<double> valoresZponto = new List<double>(); //guarda os valores z de um ponto de interesse por vez

            double menorValorZ = 1.1; //guarda o menor valor z

            double valorZ = 1.1; //guarda o valor z geral

            List<double[]> pontos3DMesmoPlano = new List<double[]>(); //guarda os pontos 3D correspondentes de um mesmo plano por vez

            double ultimoValorZ = -1; //guarda o valor z do último plano trabalhado

            PromptReconstrucao prompt1;

            Stopwatch temporizador = new Stopwatch();


            //verifica se a câmera está calibrada
            if (this.camera.estaCalibrada()) {

                prompt1 = new PromptReconstrucao();
                prompt1.ShowDialog(this);

                incremento = prompt1.incremento();
                toleranciaPlanar = prompt1.tolerancia();
                criterio = prompt1.criterio();
                ok = prompt1.ok();

                prompt1.Dispose();

                //verifica se foi confirmada a reconstrução
                if (ok) {
                    //verifica se tem pontos de interesse
                    if (this.interesse.quantosPontos() > 0) {
                        double x, y, z;

                        List<string> pontosStr = new List<string>();

                        this.saveFileDialog2.FileName = " ";
                        this.saveFileDialog2.ShowDialog(this);

                        //verifica se foi selecionado um arquivo de salvamento
                        if (this.saveFileDialog2.FileName != " ") {

                            temporizador.Start();

                            arquivoSaida = new System.IO.StreamWriter(this.saveFileDialog2.FileName);

                            //passa de plano em plano (categoricamente)
                            for (planoAtual = 0; planoAtual < 10 && abortar == false; planoAtual++) {

                                this.Cursor = Cursors.WaitCursor;

                                //inicializa a lista de valores z com todos os possíveis
                                valoresZ.Clear();
                                double aux = 0;
                                while (aux <= 1) {
                                    valoresZ.Add(aux);
                                    aux += incremento;
                                }

                                //pega os pontos de interesse do plano atual
                                pontosPlano.Clear();
                                for (int i = 0; i < plano.Count; i++) {
                                    if (plano[i] == planoAtual) {
                                        pontosPlano.Add(interesse[i]);
                                    }
                                }

                                //verifica se há pontos naquele plano categórico
                                if (pontosPlano.Count > 0) {
                                    //passa ponto de interesse a ponto de interesse (para possíveis valores z)
                                    for (int i = 0; i < pontosPlano.Count && abortar == false; i++) {
                                        //inicializa valores Z do pontos corrente
                                        valoresZponto.Clear();
                                        
                                        //faz a varredura no espaço delimitado (para possíveis valores z)
                                        for (x = 0; x <= 1; x += incremento) {
                                            for (y = 0; y <= 1; y += incremento) {
                                                for (z = 0; z <= 1; z += incremento) {
                                                    double[] p = new double[3] { 0, 0, 0 };
                                                    int[] pp = new int[2];

                                                    //faz a projeção
                                                    Matriz.multiplica(this.camera.matriz(),
                                                                      new double[4] { x, y, z, 1 },
                                                                      p,
                                                                      3,
                                                                      4);
                                                    pp[0] = Convert.ToInt32(p[0] / p[2]);
                                                    pp[1] = Convert.ToInt32(p[1] / p[2]);

                                                    //verifica se o ponto 3D projeta próximo do ponto de interesse atual
                                                    if (Math.Abs(pontosPlano[i].X - pp[0]) < toleranciaPlanar && Math.Abs(pontosPlano[i].Y - pp[1]) < toleranciaPlanar) {

                                                        //busca se o valor z já existe na listagem
                                                        //corrente. se não existe, insere.
                                                        int busca1 = valoresZponto.FindIndex(valor => valor == z);
                                                        if (busca1 == -1) {
                                                            valoresZponto.Add(z);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        //remove todos os valores z que o ponto atual não tem (fica só com a interseção)
                                        List<double> valoresARemover = new List<double>();
                                        for (int k = 0; k < valoresZ.Count; k++) {
                                            Boolean remove = true;
                                            for (int kk = 0; kk < valoresZponto.Count; kk++) {
                                                if (valoresZ[k] == valoresZponto[kk]) {
                                                    remove = false;
                                                }
                                            }
                                            if (remove) {
                                                valoresZ.RemoveAt(k);
                                                k--;
                                            }
                                        }

                                        //verifica se houve problemas com a interseção
                                        if(valoresZ.Count == 0) {
                                            abortar = true;

                                            MessageBox.Show(this, 
                                                            "Não foi possível determinar a coordenada Z do plano " + planoAtual + ". Por favor, verifique-se que todos os pontos de interesses estão na área de busca.", 
                                                            "TCC - Reconstrução abortada!");
                                        }
                                    }

                                    this.Cursor = Cursors.WaitCursor;

                                    //aplica o último critério de convergência
                                    if(abortar == false){
                                        double mediaZ = 0;
                                        int maisPerto = 0;
                                        double valorMaisPerto = valoresZ[0];
                                        double distMaisPerto = 100;
                                            switch (criterio) {
                                                //adota o valor z como o mais próximo do valor z anterior
                                                case 0:
                                                                                for (int i = 0; i < valoresZ.Count; i++) {
                                                    if (valoresZ[i] < menorValorZ && valoresZ[i] > ultimoValorZ) {
                                                        menorValorZ = valoresZ[i];
                                                    }
                                                }
                                                valoresZ.RemoveAll(item => item != menorValorZ);
                                                
                                                valorZ = valoresZ[0];
                                                    break;

                                                //adota o valor z como o mais próximo da média dos valores z restantes
                                                case 1:
                                                                                                            mediaZ = 0;
                                                maisPerto = 0;

                                                for (int i = 0; i < valoresZ.Count; i++) {
                                                    mediaZ += valoresZ[i];
                                                }
                                                mediaZ /= valoresZ.Count;

                                                distMaisPerto = Math.Abs(mediaZ - valoresZ[0]);

                                                for (int i = 1; i < valoresZ.Count; i++) {
                                                    if (Math.Abs(mediaZ - valoresZ[i]) < distMaisPerto) {
                                                        distMaisPerto = Math.Abs(mediaZ - valoresZ[i]);
                                                        maisPerto = i;
                                                    }
                                                }
                                                
                                                valorZ = valoresZ[maisPerto];
                                                    break;

                                                //escolha manual
                                                case 2:
                                                                                                                                                                    int indice;

                                                //busca o menor valor mais proximo do anterior
                                                for (int i = 0; i < valoresZ.Count; i++) {
                                                    if (valoresZ[i] < menorValorZ && valoresZ[i] > ultimoValorZ) {
                                                        menorValorZ = valoresZ[i];
                                                    }
                                                }

                                                //busca o valor mais próximo à média
                                                mediaZ = 0;
                                                valorMaisPerto = valoresZ[0];
                                                for (int i = 0; i < valoresZ.Count; i++) {
                                                    mediaZ += valoresZ[i];
                                                }
                                                mediaZ /= valoresZ.Count;

                                                distMaisPerto = Math.Abs(mediaZ - valoresZ[0]);

                                                for (int i = 1; i < valoresZ.Count; i++) {
                                                    if (Math.Abs(mediaZ - valoresZ[i]) < distMaisPerto) {
                                                        distMaisPerto = Math.Abs(mediaZ - valoresZ[i]);
                                                        valorMaisPerto = valoresZ[i];
                                                    }
                                                }

                                                //exibe prompt para escolha
                                                do {
                                                    PromptEscolhaValorZ prompt = new PromptEscolhaValorZ(valoresZ, menorValorZ, valorMaisPerto, planoAtual);
                                                    prompt.ShowDialog(this);

                                                    indice = prompt.indexValorZ();

                                                    prompt.Dispose();
                                                }while(indice == -1);

                                                valorZ = valoresZ[indice];
                                                    break;
                                            }
                                    }

                                    //passa ponto de interesse a ponto de interesse
                                    //( busca correspondentes 3D pra cada ponto de interesse no plano
                                    //  atual, através de uma tolerância planar e baricentro planar  )
                                    for (int i = 0; i < pontosPlano.Count && abortar == false; i++) {

                                        //busca correspondentes 3D no plano z escolhido
                                        for (x = 0; x <= 1; x += incremento) {
                                            for (y = 0; y <= 1; y += incremento) {
                                                double[] p = new double[3] { 0, 0, 0 };
                                                int[] pp = new int[2];

                                                //faz a projeção
                                                Matriz.multiplica(this.camera.matriz(),
                                                                  new double[4] { x, y, valorZ, 1 },
                                                                  p,
                                                                  3,
                                                                  4);
                                                pp[0] = Convert.ToInt32(p[0] / p[2]);
                                                pp[1] = Convert.ToInt32(p[1] / p[2]);

                                                //verifica se o ponto 3D projeta próximo do ponto de interesse
                                                if (Math.Abs(pp[0] - pontosPlano[i].X) < toleranciaPlanar && Math.Abs(pp[1] - pontosPlano[i].Y) < toleranciaPlanar) {
                                                    pontos3DMesmoPlano.Add(new double[3] { x, y, valorZ });
                                                }
                                            }
                                        }

                                        //calcula baricentro planar (xy) dos pontos 3D correspondentes
                                        double xfinal = 0, yfinal = 0;
                                        for (int i1 = 0; i1 < pontos3DMesmoPlano.Count; i1++) {
                                            xfinal += pontos3DMesmoPlano[i1][0];
                                            yfinal += pontos3DMesmoPlano[i1][1];
                                        }
                                        xfinal /= pontos3DMesmoPlano.Count;
                                        yfinal /= pontos3DMesmoPlano.Count;

                                        //imprime pontos 3D correspondente
                                        pontosStr.Add(xfinal + " " + yfinal + " " + valorZ);

                                        //reseta variáveis
                                        pontos3DMesmoPlano.Clear();
                                    }

                                    this.Cursor = Cursors.WaitCursor;

                                    //reseta variáveis
                                    pontosPlano.Clear();

                                    ultimoValorZ = valorZ;

                                    menorValorZ = 1.1;
                                }
                            }

                            //verifica se a reconstrução nao fora abortada
                            if(abortar == false){
                                //escreve o arquivo
                                arquivoSaida.WriteLine("ply");
                                arquivoSaida.WriteLine("format ascii 1.0");
                                arquivoSaida.WriteLine("element vertex " + pontosStr.Count);
                                arquivoSaida.WriteLine("property float x");
                                arquivoSaida.WriteLine("property float y");
                                arquivoSaida.WriteLine("property float z");
                                arquivoSaida.WriteLine("end_header");

                                for (int i = 0; i < pontosStr.Count; i++) {
                                    arquivoSaida.WriteLine(pontosStr[i].Replace(',', '.'));
                                }
                            }

                            arquivoSaida.Close();

                            this.Cursor = Cursors.Default;

                            if(abortar == false){
                                temporizador.Stop();

                                int minutos = Convert.ToInt32(temporizador.ElapsedMilliseconds / 60000);
                                int segundos = Convert.ToInt32((temporizador.ElapsedMilliseconds % 60000) / 1000);

                                MessageBox.Show(this, "Reconstrução terminada em " + minutos + " minutos e " + segundos + " segundos!", "TCC - Aviso");
                            }
                        }
                    }
                    else {
                        MessageBox.Show(this, "Você precisa indicar os pontos a serem reconstruídos!", "TCC - Erro");
                    }
                }
            }
            else {
                DialogResult r = MessageBox.Show(this,
                                                 "Você precisa calibrar a câmera antes de reconstruir o objeto, deseja fazer isso agora?",
                                                 "Reconstruir objeto",
                                                 MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes) {
                    this.executarCalibraçãoToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.abrirImagemToolStripMenuItem_Click(sender, e);

            if(this.pictureBox1.Image != null){
                this.carregarToolStripMenuItem_Click(sender, e);

                this.carregarToolStripMenuItem1_Click(sender, e);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.executarCalibraçãoToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.executarReconstruçãoToolStripMenuItem_Click(sender, e);
        }

        private void salvarTelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image != null) {

                this.saveFileDialog3.FileName = "";
                this.saveFileDialog3.Title = "Salvar imagem da captura de tela de trabalho";
                this.saveFileDialog3.ShowDialog(this);

                if (this.saveFileDialog3.FileName != "") {

                    Bitmap imagem = new Bitmap(pictureBox1.Image);

                    Graphics graf = Graphics.FromImage(imagem);

                    //renderizar pontos e faces referenciadas pelo usuário
                    if (this.visualizar[0]) {
                        Point[, ,] pontos = this.referencia.pontos();

                        for (int i = 0; i < 2; i++) {
                            for (int j = 0; j < 2; j++) {
                                for (int k = 0; k < 2; k++) {
                                    if (this.referencia.referenciado(i, j, k)) {

                                        graf.FillEllipse(new SolidBrush(Color.Blue),
                                                          pontos[i, j, k].X - 4,
                                                          pictureBox1.Height - pontos[i, j, k].Y - 4,
                                                          9,
                                                          9);
                                        graf.DrawString("(" + i + ", " + j + ", " + k + ")",
                                                         new Font("Times New Roman", 10),
                                                         new SolidBrush(Color.Black),
                                                         pontos[i, j, k].X - 23,
                                                         pictureBox1.Height - pontos[i, j, k].Y + 7);
                                    }
                                }
                            }
                        }

                        //face de baixo (lime)
                        if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(1, 0, 0) &&
                           this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(0, 1, 0)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(60, 190, 255, 0)),
                                               pontosTransformados);
                        }

                        //face de cima (quasi-red)
                        if (this.referencia.referenciado(0, 0, 1) && this.referencia.referenciado(1, 0, 1) &&
                           this.referencia.referenciado(1, 1, 1) && this.referencia.referenciado(0, 1, 1)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(60, 250, 10, 0)),
                                              pontosTransformados);
                        }

                        //face da frente esquerda (cyan)
                        if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(1, 0, 0) &&
                           this.referencia.referenciado(1, 0, 1) && this.referencia.referenciado(0, 0, 1)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(90, 0, 255, 255)),
                                              pontosTransformados);
                        }

                        //face da frente direita (yellow)
                        if (this.referencia.referenciado(0, 0, 0) && this.referencia.referenciado(0, 1, 0) &&
                           this.referencia.referenciado(0, 1, 1) && this.referencia.referenciado(0, 0, 1)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[0, 0, 0].X, 
                                                               pictureBox1.Height - pontos[0, 0, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),
                                                                new Point(pontos[0, 0, 1].X, 
                                                               pictureBox1.Height - pontos[0, 0, 1].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 255, 0)),
                                              pontosTransformados);
                        }

                        //face da trás esquerda (lily)
                        if (this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(1, 0, 0) &&
                           this.referencia.referenciado(1, 0, 1) && this.referencia.referenciado(1, 1, 1)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[1, 0, 0].X, 
                                                               pictureBox1.Height - pontos[1, 0, 0].Y),
                                                                new Point(pontos[1, 0, 1].X, 
                                                               pictureBox1.Height - pontos[1, 0, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 0, 255)),
                                              pontosTransformados);
                        }

                        //face da trás direita (orange)
                        if (this.referencia.referenciado(1, 1, 0) && this.referencia.referenciado(0, 1, 0) &&
                           this.referencia.referenciado(0, 1, 1) && this.referencia.referenciado(1, 1, 1)) {

                            Point[] pontosTransformados = new Point[] { new Point(pontos[1, 1, 0].X, 
                                                               pictureBox1.Height - pontos[1, 1, 0].Y),
                                                                new Point(pontos[0, 1, 0].X, 
                                                               pictureBox1.Height - pontos[0, 1, 0].Y),
                                                                new Point(pontos[0, 1, 1].X, 
                                                               pictureBox1.Height - pontos[0, 1, 1].Y),
                                                                new Point(pontos[1, 1, 1].X, 
                                                               pictureBox1.Height - pontos[1, 1, 1].Y),};

                            graf.FillPolygon(new SolidBrush(Color.FromArgb(90, 255, 153, 0)),
                                              pontosTransformados);
                        }
                    }

                    //renderizar pontos de interesse
                    if (this.visualizar[1]) {
                        List<Point> pontos = this.interesse.interesses();
                        List<int> planos = this.interesse.interesses(true);
                        Color cor = Color.Gold;

                        for (int i = 0; i < pontos.Count; i++) {

                            switch (planos[i] % 10) {
                                case 0:
                                    cor = Color.Black;
                                    break;
                                case 1:
                                    cor = Color.Brown;
                                    break;
                                case 2:
                                    cor = Color.Green;
                                    break;
                                case 3:
                                    cor = Color.DarkKhaki;
                                    break;
                                case 4:
                                    cor = Color.Chocolate;
                                    break;
                                case 5:
                                    cor = Color.Orange;
                                    break;
                                case 6:
                                    cor = Color.Yellow;
                                    break;
                                case 7:
                                    cor = Color.Beige;
                                    break;
                                case 8:
                                    cor = Color.Fuchsia;
                                    break;
                                case 9:
                                    cor = Color.Gray;
                                    break;
                            }

                            Pen caneta = new Pen(cor, 3);

                            graf.DrawLine(caneta,
                                           pontos[i].X - 5,
                                           pictureBox1.Height - pontos[i].Y - 5,
                                           pontos[i].X + 5,
                                           pictureBox1.Height - pontos[i].Y + 5);

                            graf.DrawLine(caneta,
                                           pontos[i].X + 5,
                                           pictureBox1.Height - pontos[i].Y - 5,
                                           pontos[i].X - 5,
                                           pictureBox1.Height - pontos[i].Y + 5);
                        }
                    }

                    imagem.Save(this.saveFileDialog3.FileName, System.Drawing.Imaging.ImageFormat.Png);

                    MessageBox.Show(this, "Tela salva com sucesso!", "TCC - Aviso");
                }
            }
            else {
                MessageBox.Show(this, "Nenhuma imagem aberta para ser salva", "TCC - Erro");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.salvarTelaToolStripMenuItem_Click(sender, e);
        }
    }
}
