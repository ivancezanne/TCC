namespace InterfaceReferenciamento
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirImagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoDeReferênciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivosDePontosDeInteresseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referênciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verReferênciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarPontoDeReferênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPontosDeInteresseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarPontoDeInteresseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarCalibraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarReconstruçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaDeReferênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontosDeInteresseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aproximaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarTelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Imagens (*.png, *.jpg)|*.png;*.jpg";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.referênciasToolStripMenuItem,
            this.interessesToolStripMenuItem,
            this.calibraçãoToolStripMenuItem,
            this.visualizarToolStripMenuItem,
            this.telaToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirImagemToolStripMenuItem,
            this.arquivoDeReferênciasToolStripMenuItem,
            this.arquivosDePontosDeInteresseToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirImagemToolStripMenuItem
            // 
            this.abrirImagemToolStripMenuItem.Name = "abrirImagemToolStripMenuItem";
            this.abrirImagemToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.abrirImagemToolStripMenuItem.Text = "Abrir imagem";
            this.abrirImagemToolStripMenuItem.Click += new System.EventHandler(this.abrirImagemToolStripMenuItem_Click);
            // 
            // arquivoDeReferênciasToolStripMenuItem
            // 
            this.arquivoDeReferênciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarToolStripMenuItem,
            this.salvarToolStripMenuItem});
            this.arquivoDeReferênciasToolStripMenuItem.Name = "arquivoDeReferênciasToolStripMenuItem";
            this.arquivoDeReferênciasToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.arquivoDeReferênciasToolStripMenuItem.Text = "Arquivo de referências";
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.carregarToolStripMenuItem.Text = "Carregar";
            this.carregarToolStripMenuItem.Click += new System.EventHandler(this.carregarToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // arquivosDePontosDeInteresseToolStripMenuItem
            // 
            this.arquivosDePontosDeInteresseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarToolStripMenuItem1,
            this.salvarToolStripMenuItem1});
            this.arquivosDePontosDeInteresseToolStripMenuItem.Name = "arquivosDePontosDeInteresseToolStripMenuItem";
            this.arquivosDePontosDeInteresseToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.arquivosDePontosDeInteresseToolStripMenuItem.Text = "Arquivos de pontos de interesse";
            // 
            // carregarToolStripMenuItem1
            // 
            this.carregarToolStripMenuItem1.Name = "carregarToolStripMenuItem1";
            this.carregarToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.carregarToolStripMenuItem1.Text = "Carregar";
            this.carregarToolStripMenuItem1.Click += new System.EventHandler(this.carregarToolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem1
            // 
            this.salvarToolStripMenuItem1.Name = "salvarToolStripMenuItem1";
            this.salvarToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.salvarToolStripMenuItem1.Text = "Salvar";
            this.salvarToolStripMenuItem1.Click += new System.EventHandler(this.salvarToolStripMenuItem1_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // referênciasToolStripMenuItem
            // 
            this.referênciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verReferênciasToolStripMenuItem,
            this.apagarPontoDeReferênciaToolStripMenuItem});
            this.referênciasToolStripMenuItem.Name = "referênciasToolStripMenuItem";
            this.referênciasToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.referênciasToolStripMenuItem.Text = "Referências";
            // 
            // verReferênciasToolStripMenuItem
            // 
            this.verReferênciasToolStripMenuItem.Name = "verReferênciasToolStripMenuItem";
            this.verReferênciasToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.verReferênciasToolStripMenuItem.Text = "Ver referências";
            this.verReferênciasToolStripMenuItem.Click += new System.EventHandler(this.verReferênciasToolStripMenuItem_Click);
            // 
            // apagarPontoDeReferênciaToolStripMenuItem
            // 
            this.apagarPontoDeReferênciaToolStripMenuItem.Name = "apagarPontoDeReferênciaToolStripMenuItem";
            this.apagarPontoDeReferênciaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.apagarPontoDeReferênciaToolStripMenuItem.Text = "Apagar ponto de referência";
            this.apagarPontoDeReferênciaToolStripMenuItem.Click += new System.EventHandler(this.apagarPontoDeReferênciaToolStripMenuItem_Click);
            // 
            // interessesToolStripMenuItem
            // 
            this.interessesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPontosDeInteresseToolStripMenuItem,
            this.apagarPontoDeInteresseToolStripMenuItem});
            this.interessesToolStripMenuItem.Name = "interessesToolStripMenuItem";
            this.interessesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.interessesToolStripMenuItem.Text = "Interesses";
            // 
            // verPontosDeInteresseToolStripMenuItem
            // 
            this.verPontosDeInteresseToolStripMenuItem.Name = "verPontosDeInteresseToolStripMenuItem";
            this.verPontosDeInteresseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.verPontosDeInteresseToolStripMenuItem.Text = "Ver pontos de interesse";
            this.verPontosDeInteresseToolStripMenuItem.Click += new System.EventHandler(this.verPontosDeInteresseToolStripMenuItem_Click);
            // 
            // apagarPontoDeInteresseToolStripMenuItem
            // 
            this.apagarPontoDeInteresseToolStripMenuItem.Name = "apagarPontoDeInteresseToolStripMenuItem";
            this.apagarPontoDeInteresseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.apagarPontoDeInteresseToolStripMenuItem.Text = "Apagar ponto de interesse";
            this.apagarPontoDeInteresseToolStripMenuItem.Click += new System.EventHandler(this.apagarPontoDeInteresseToolStripMenuItem_Click);
            // 
            // calibraçãoToolStripMenuItem
            // 
            this.calibraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executarCalibraçãoToolStripMenuItem,
            this.executarReconstruçãoToolStripMenuItem});
            this.calibraçãoToolStripMenuItem.Name = "calibraçãoToolStripMenuItem";
            this.calibraçãoToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.calibraçãoToolStripMenuItem.Text = "Processos";
            // 
            // executarCalibraçãoToolStripMenuItem
            // 
            this.executarCalibraçãoToolStripMenuItem.Name = "executarCalibraçãoToolStripMenuItem";
            this.executarCalibraçãoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.executarCalibraçãoToolStripMenuItem.Text = "Executar calibração";
            this.executarCalibraçãoToolStripMenuItem.Click += new System.EventHandler(this.executarCalibraçãoToolStripMenuItem_Click);
            // 
            // executarReconstruçãoToolStripMenuItem
            // 
            this.executarReconstruçãoToolStripMenuItem.Name = "executarReconstruçãoToolStripMenuItem";
            this.executarReconstruçãoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.executarReconstruçãoToolStripMenuItem.Text = "Executar reconstrução";
            this.executarReconstruçãoToolStripMenuItem.Click += new System.EventHandler(this.executarReconstruçãoToolStripMenuItem_Click);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaDeReferênciaToolStripMenuItem,
            this.pontosDeInteresseToolStripMenuItem,
            this.aproximaçãoToolStripMenuItem});
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // sistemaDeReferênciaToolStripMenuItem
            // 
            this.sistemaDeReferênciaToolStripMenuItem.Checked = true;
            this.sistemaDeReferênciaToolStripMenuItem.CheckOnClick = true;
            this.sistemaDeReferênciaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sistemaDeReferênciaToolStripMenuItem.Name = "sistemaDeReferênciaToolStripMenuItem";
            this.sistemaDeReferênciaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sistemaDeReferênciaToolStripMenuItem.Text = "Sistema de referência";
            this.sistemaDeReferênciaToolStripMenuItem.Click += new System.EventHandler(this.sistemaDeReferênciaToolStripMenuItem_Click);
            // 
            // pontosDeInteresseToolStripMenuItem
            // 
            this.pontosDeInteresseToolStripMenuItem.Checked = true;
            this.pontosDeInteresseToolStripMenuItem.CheckOnClick = true;
            this.pontosDeInteresseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pontosDeInteresseToolStripMenuItem.Name = "pontosDeInteresseToolStripMenuItem";
            this.pontosDeInteresseToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pontosDeInteresseToolStripMenuItem.Text = "Pontos de interesse";
            this.pontosDeInteresseToolStripMenuItem.Click += new System.EventHandler(this.pontosDeInteresseToolStripMenuItem_Click);
            // 
            // aproximaçãoToolStripMenuItem
            // 
            this.aproximaçãoToolStripMenuItem.CheckOnClick = true;
            this.aproximaçãoToolStripMenuItem.Name = "aproximaçãoToolStripMenuItem";
            this.aproximaçãoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.aproximaçãoToolStripMenuItem.Text = "Aproximação";
            this.aproximaçãoToolStripMenuItem.Click += new System.EventHandler(this.aproximaçãoToolStripMenuItem_Click);
            // 
            // telaToolStripMenuItem
            // 
            this.telaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarTelaToolStripMenuItem});
            this.telaToolStripMenuItem.Name = "telaToolStripMenuItem";
            this.telaToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.telaToolStripMenuItem.Text = "Tela";
            // 
            // salvarTelaToolStripMenuItem
            // 
            this.salvarTelaToolStripMenuItem.Name = "salvarTelaToolStripMenuItem";
            this.salvarTelaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarTelaToolStripMenuItem.Text = "Salvar tela";
            this.salvarTelaToolStripMenuItem.Click += new System.EventHandler(this.salvarTelaToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "Arquivos TCC (*.tcc)|*.tcc";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 8;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Arquivos TCC (*.tcc)|*.tcc";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Arquivos PLY (*.ply)|*.ply";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(462, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Carregar projeto";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Salvar tela";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Calibrar câmera";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Reconstruir";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // saveFileDialog3
            // 
            this.saveFileDialog3.Filter = "Imagens PNG (*.png)|*.png";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(462, 222);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 260);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TCC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirImagemToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem referênciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verReferênciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarPontoDeReferênciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarCalibraçãoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaDeReferênciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aproximaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoDeReferênciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem pontosDeInteresseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivosDePontosDeInteresseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem interessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apagarPontoDeInteresseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPontosDeInteresseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarReconstruçãoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem telaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarTelaToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
    }
}

