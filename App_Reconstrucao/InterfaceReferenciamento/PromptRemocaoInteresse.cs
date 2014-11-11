using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InterfaceReferenciamento
{
    public partial class PromptRemocaoInteresse : Form
    {
        
        private int[,] selecionados;
        private int nPontos;
        private List<Point> valoresPontos;

        public PromptRemocaoInteresse(List<Point> pontos, List<int> planos)
        {
            InitializeComponent();

            string texto = "";
            CheckBox cb;
            for (int i = 0; i < pontos.Count; i++){
                texto = "(" + pontos[i].X + ", " + pontos[i].Y + ")" + " :: " + planos[i];
                cb = new CheckBox();
                cb.Name = "checkbox" + i;
                cb.Text = texto;
                cb.Location = new Point(0, i * 20);
                this.panel1.Controls.Add(cb);
            }

            this.selecionados = new int[pontos.Count, 2];

            this.nPontos = pontos.Count;

            this.valoresPontos = pontos;
        }

        public int[,] remocoes() {
            for(int i = 0; i < nPontos; i++){
                CheckBox cb = (CheckBox)this.panel1.Controls.Find("checkbox" + i,false)[0];

                if(cb.Checked){
                    this.selecionados[i, 0] = this.valoresPontos[i].X;
                    this.selecionados[i, 1] = this.valoresPontos[i].Y;
                }
                else{
                    this.selecionados[i, 0] = -1;
                    this.selecionados[i, 1] = -1;
                }
            }

            return this.selecionados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
