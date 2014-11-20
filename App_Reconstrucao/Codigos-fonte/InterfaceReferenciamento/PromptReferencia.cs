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
    public partial class PromptReferencia : Form
    {

        private int x, y, z; 
        private int tipo;        

        public PromptReferencia()
        {
            InitializeComponent();

            x = y = z = -1;

            this.tipo = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.x = this.radioButton3.Checked ? 0 : 1;
            this.y = this.radioButton5.Checked ? 0 : 1;
            this.z = this.radioButton7.Checked ? 0 : 1;

            this.tipo = this.radioButton1.Checked ? 1 : 2;

            this.Close();
        }

        public int[] valores() {
            return new int[3] {x, y, z};
        }

        public int qualTipo(){
            return this.tipo;
        }

        public int idPlano(){
            return Convert.ToInt32(this.numericUpDown1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = new Size(240, 350);

            this.button1.Location = new Point(95, 285);

            this.groupBox6.Visible = false;
            this.numericUpDown1.Visible = false;

            this.groupBox2.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = new Size(240, 209);

            this.button1.Location = new Point(95, 145);

            this.groupBox6.Visible = true;
            this.numericUpDown1.Visible = true;

            this.groupBox2.Visible = false;
        }
    }
}
