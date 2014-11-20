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
    public partial class PromptRemocaoReferencia : Form
    {

        private Boolean[,,] marcados;

        public PromptRemocaoReferencia( Point[,,] p)
        {
            InitializeComponent();

            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 2; j++) {
                    for (int k = 0; k < 2; k++) {
                        CheckBox chkbx = (CheckBox)this.Controls.Find("checkBox" + ((i * 4 + j * 2 + k) + 1), false)[0];
                        
                        if (p[i, j, k].X + p[i, j, k].Y < 0){
                            chkbx.Text = "(" + i + ", " + j + ", " + k + ") -> não referenciado";
                        }
                        else{
                            chkbx.Text = "(" + i + ", " + j + ", " + k + ") -> (" + p[i, j, k].X + ", " + p[i, j, k].Y + ")";
                        }
                    }
                }
            }

            this.marcados = new Boolean[2, 2, 2]{{{false, false}, {false, false}},
                                                 {{false, false}, {false, false}}};
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++ ) {
                CheckBox chkbx = (CheckBox)this.Controls.Find("checkBox" + (i + 1), false)[0];

                if(chkbx.Checked){
                    this.marcados[(i / 4) % 2, (i / 2) % 2, i % 2] = true; 
                }
                else{
                    this.marcados[(i / 4) % 2, (i / 2) % 2, i % 2] = false;
                }
            }

            this.Close();
        }

        public Boolean[,,] remocoes() {
            return this.marcados;
        }
    }
}
