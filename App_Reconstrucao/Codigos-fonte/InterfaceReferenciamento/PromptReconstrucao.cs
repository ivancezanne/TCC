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
    public partial class PromptReconstrucao : Form
    {
        
        private Boolean confirmar;

        public PromptReconstrucao()
        {
            this.confirmar = false;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.confirmar = true;

            this.Close();
        }

        public int tolerancia(){
            return Convert.ToInt32(this.numericUpDown1.Value);
        }

        public double incremento(){
            return Convert.ToDouble(this.numericUpDown2.Value);
        }

        public int criterio(){
            int retorno = -1;
            if(this.radioButton1.Checked){
                retorno = 0;
            }
            else{
                if(this.radioButton2.Checked){
                    retorno = 1;
                }
                else{
                    retorno = 2;
                }
            }

            return retorno;
        }

        public Boolean ok(){
            return this.confirmar;
        }
    }
}
