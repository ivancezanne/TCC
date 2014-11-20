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
    public partial class PromptPontosReferencia : Form
    {
        public PromptPontosReferencia(Point[,,] pontos)
        {
            InitializeComponent();

            //imprime referências nos labels
            for(int x = 0; x < 2; x++){
                for(int y = 0; y < 2; y++){
                    for(int z = 0; z < 2; z++){
                        String xs = string.Format("{0:0.00}", x).Replace(',', '.');
                        String ys = string.Format("{0:0.00}", y).Replace(',', '.');
                        String zs = string.Format("{0:0.00}", z).Replace(',', '.');

                        String us = pontos[x, y, z].X != -1 && pontos[x, y, z].Y != -1 ? string.Format("{0:0}", pontos[x, y, z].X) : "não referenciado";
                        String vs = pontos[x, y, z].X != -1 && pontos[x, y, z].Y != -1 ? string.Format("{0:0}", pontos[x, y, z].Y) : "";

                        String texto = "(" + xs + ", " + ys + ", " + zs + ")" + "          " + "(" + us + ", " + vs + ")";

                        switch(x * 4 + y * 2 + z){
                            case 0:
                                this.label1.Text = texto;
                            break;
                            case 1:
                                this.label2.Text = texto;
                            break;
                            case 2:
                                this.label3.Text = texto;
                            break;
                            case 3:
                                this.label4.Text = texto;
                            break;
                            case 4:
                                this.label5.Text = texto;
                            break;
                            case 5:
                                this.label6.Text = texto;
                            break;
                            case 6:
                                this.label7.Text = texto;
                            break;
                            case 7:
                                this.label8.Text = texto;
                            break;
                        }
                    }
                }
            }

            int l = (this.Size.Width - this.button1.Width) / 2;
            this.button1.Location = new Point(l, this.button1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
