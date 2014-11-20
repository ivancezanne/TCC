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
    public partial class PromptPontosInteresse : Form
    {
        public PromptPontosInteresse(List<Point> pontos, List<int> planos)
        {
            InitializeComponent();

            string texto = "";

            if(pontos.Count > 0){
                for (int i = 0; i < pontos.Count; i++){
                    texto = "(" + pontos[i].X + ", " + pontos[i].Y + ")" + " :: " + planos[i];

                    Label l = new Label();
                    l.Size = new System.Drawing.Size(this.panel1.Width, 20);
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.Name = "label" + i;
                    l.Text = texto;
                    l.Location = new Point(0, i * 20);

                    this.panel1.Controls.Add(l);
                    }
            }
            else{
                texto = "Nenhum ponto assinalado!";

                Label l = new Label();
                l.Size = new System.Drawing.Size(this.panel1.Width, 20);
                l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                l.Name = "labelUnico";
                l.Text = texto;
                l.Location = new Point(0, 0);

                this.panel1.Controls.Add(l);
            }

            int b = (this.Size.Width - this.button1.Width) / 2;
            this.button1.Location = new Point(b, this.button1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
