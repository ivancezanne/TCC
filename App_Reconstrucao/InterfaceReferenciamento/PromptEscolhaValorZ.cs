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
    public partial class PromptEscolhaValorZ : Form
    {
        
        private int selecionado;
        private int nValoresZ;

        public PromptEscolhaValorZ(List<double> valoresZ, double proximoAnterior, double proximoMedia, int idPlano)
        {
            InitializeComponent();

            this.selecionado = -1;
            this.nValoresZ = valoresZ.Count;

            this.Text = "Coordenada Z para o plano " + idPlano;

            this.label1.Text = "Defina a coordenada Z para o plano " + idPlano;

            if(valoresZ.Count == 1){
                this.label1.Text += " (sim, só tem um valor!)";
            }

            string texto = "";
            RadioButton rb;
            for (int i = 0; i < valoresZ.Count; i++) {
                rb = new RadioButton();

                texto = "" + valoresZ[i];
                if(valoresZ[i] == proximoAnterior){
                    texto += " (mais próximo ao anterior)";
                    rb.Font = new Font(rb.Font.Name, rb.Font.Size, FontStyle.Bold);
                }
                if (valoresZ[i] == proximoMedia) {
                    texto += " (mais próximo à media)";
                    rb.Font = new Font(rb.Font.Name, rb.Font.Size, FontStyle.Bold);
                }

                
                rb.Name = "radiobutton" + i;
                rb.AutoSize = true;
                rb.Text = texto;
                rb.Location = new Point(0, i * 25);
                this.panel1.Controls.Add(rb);
            }
        }

        public int indexValorZ(){
            return this.selecionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < nValoresZ; i++) {
                RadioButton rb = (RadioButton)this.panel1.Controls.Find("radiobutton" + i, false)[0];

                if(rb.Checked) {
                    this.selecionado = i;
                }
            }

            this.Close();
        }
    }
}
