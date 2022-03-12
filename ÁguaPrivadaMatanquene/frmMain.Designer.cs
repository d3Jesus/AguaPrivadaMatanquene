namespace ÁguaPrivadaMatanquene
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDock = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNomeUs = new System.Windows.Forms.Label();
            this.lblUsu = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnFacturacao = new System.Windows.Forms.Button();
            this.btnPagamento = new System.Windows.Forms.Button();
            this.btnInstalacao = new System.Windows.Forms.Button();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnEscalao = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarSessãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalãoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.instalaçðesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.pnlDock.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.btnMin);
            this.pnlTop.Controls.Add(this.btnMax);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(817, 28);
            this.pnlTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Água Privada Matanquene ";
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.DarkBlue;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(727, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 28);
            this.btnMin.TabIndex = 0;
            this.btnMin.Text = "_";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.DarkBlue;
            this.btnMax.Enabled = false;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.ForeColor = System.Drawing.Color.White;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(757, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(30, 28);
            this.btnMax.TabIndex = 0;
            this.btnMax.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.DarkBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(787, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlDock
            // 
            this.pnlDock.Controls.Add(this.panel1);
            this.pnlDock.Controls.Add(this.pictureBox1);
            this.pnlDock.Controls.Add(this.pnlLeft);
            this.pnlDock.Controls.Add(this.menuStrip1);
            this.pnlDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDock.Location = new System.Drawing.Point(0, 28);
            this.pnlDock.Name = "pnlDock";
            this.pnlDock.Size = new System.Drawing.Size(817, 493);
            this.pnlDock.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNomeUs);
            this.panel1.Controls.Add(this.lblUsu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(155, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 33);
            this.panel1.TabIndex = 3;
            // 
            // lblNomeUs
            // 
            this.lblNomeUs.AutoSize = true;
            this.lblNomeUs.Font = new System.Drawing.Font("Bell MT", 13F);
            this.lblNomeUs.Location = new System.Drawing.Point(128, 2);
            this.lblNomeUs.Name = "lblNomeUs";
            this.lblNomeUs.Size = new System.Drawing.Size(69, 22);
            this.lblNomeUs.TabIndex = 0;
            this.lblNomeUs.Text = "Usuário";
            // 
            // lblUsu
            // 
            this.lblUsu.AutoSize = true;
            this.lblUsu.Font = new System.Drawing.Font("Bell MT", 13F);
            this.lblUsu.Location = new System.Drawing.Point(3, 2);
            this.lblUsu.Name = "lblUsu";
            this.lblUsu.Size = new System.Drawing.Size(119, 22);
            this.lblUsu.TabIndex = 0;
            this.lblUsu.Text = "Logado Como:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(155, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 432);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlLeft.Controls.Add(this.btnFacturacao);
            this.pnlLeft.Controls.Add(this.btnPagamento);
            this.pnlLeft.Controls.Add(this.btnInstalacao);
            this.pnlLeft.Controls.Add(this.btnFuncionario);
            this.pnlLeft.Controls.Add(this.btnEscalao);
            this.pnlLeft.Controls.Add(this.btnUsuario);
            this.pnlLeft.Controls.Add(this.btnCliente);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 27);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(155, 466);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnFacturacao
            // 
            this.btnFacturacao.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFacturacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnFacturacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacao.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacao.ForeColor = System.Drawing.Color.White;
            this.btnFacturacao.Location = new System.Drawing.Point(0, 195);
            this.btnFacturacao.Name = "btnFacturacao";
            this.btnFacturacao.Size = new System.Drawing.Size(154, 45);
            this.btnFacturacao.TabIndex = 2;
            this.btnFacturacao.Text = "Facturação";
            this.btnFacturacao.UseVisualStyleBackColor = false;
            this.btnFacturacao.Click += new System.EventHandler(this.btnFacturacao_Click);
            // 
            // btnPagamento
            // 
            this.btnPagamento.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPagamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagamento.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagamento.ForeColor = System.Drawing.Color.White;
            this.btnPagamento.Location = new System.Drawing.Point(0, 243);
            this.btnPagamento.Name = "btnPagamento";
            this.btnPagamento.Size = new System.Drawing.Size(154, 45);
            this.btnPagamento.TabIndex = 2;
            this.btnPagamento.Text = "Pagamento";
            this.btnPagamento.UseVisualStyleBackColor = false;
            this.btnPagamento.Click += new System.EventHandler(this.btnPagamento_Click);
            // 
            // btnInstalacao
            // 
            this.btnInstalacao.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnInstalacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnInstalacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstalacao.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstalacao.ForeColor = System.Drawing.Color.White;
            this.btnInstalacao.Location = new System.Drawing.Point(0, 147);
            this.btnInstalacao.Name = "btnInstalacao";
            this.btnInstalacao.Size = new System.Drawing.Size(154, 45);
            this.btnInstalacao.TabIndex = 1;
            this.btnInstalacao.Text = "Instalação";
            this.btnInstalacao.UseVisualStyleBackColor = false;
            this.btnInstalacao.Click += new System.EventHandler(this.btnInstalacao_Click);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFuncionario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuncionario.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncionario.ForeColor = System.Drawing.Color.White;
            this.btnFuncionario.Location = new System.Drawing.Point(0, 99);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(154, 45);
            this.btnFuncionario.TabIndex = 1;
            this.btnFuncionario.Text = "Funcionário";
            this.btnFuncionario.UseVisualStyleBackColor = false;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            // 
            // btnEscalao
            // 
            this.btnEscalao.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEscalao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnEscalao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscalao.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscalao.ForeColor = System.Drawing.Color.White;
            this.btnEscalao.Location = new System.Drawing.Point(0, 3);
            this.btnEscalao.Name = "btnEscalao";
            this.btnEscalao.Size = new System.Drawing.Size(154, 45);
            this.btnEscalao.TabIndex = 0;
            this.btnEscalao.Text = "Escalão";
            this.btnEscalao.UseVisualStyleBackColor = false;
            this.btnEscalao.Click += new System.EventHandler(this.btnEscalao_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Location = new System.Drawing.Point(0, 291);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(154, 45);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuário";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(111)))), ((int)(((byte)(255)))));
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.Location = new System.Drawing.Point(0, 51);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(154, 45);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Bell MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.consultaToolStripMenuItem,
            this.relatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.usuárioToolStripMenuItem,
            this.mudarUsuárioToolStripMenuItem,
            this.terminarSessãoToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ficheiroToolStripMenuItem.Image")));
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clienteToolStripMenuItem.Image")));
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuárioToolStripMenuItem.Image")));
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.usuárioToolStripMenuItem.Text = "Usuário";
            this.usuárioToolStripMenuItem.Click += new System.EventHandler(this.usuárioToolStripMenuItem_Click);
            // 
            // mudarUsuárioToolStripMenuItem
            // 
            this.mudarUsuárioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mudarUsuárioToolStripMenuItem.Image")));
            this.mudarUsuárioToolStripMenuItem.Name = "mudarUsuárioToolStripMenuItem";
            this.mudarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.mudarUsuárioToolStripMenuItem.Text = "Mudar Usuário";
            this.mudarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.mudarUsuárioToolStripMenuItem_Click);
            // 
            // terminarSessãoToolStripMenuItem
            // 
            this.terminarSessãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("terminarSessãoToolStripMenuItem.Image")));
            this.terminarSessãoToolStripMenuItem.Name = "terminarSessãoToolStripMenuItem";
            this.terminarSessãoToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.terminarSessãoToolStripMenuItem.Text = "Sair";
            this.terminarSessãoToolStripMenuItem.Click += new System.EventHandler(this.terminarSessãoToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalãoToolStripMenuItem1,
            this.clienteToolStripMenuItem1,
            this.funcionárioToolStripMenuItem,
            this.instalaçðesToolStripMenuItem,
            this.usuárioToolStripMenuItem1});
            this.consultaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultaToolStripMenuItem.Image")));
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(92, 23);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(153, 24);
            this.clienteToolStripMenuItem1.Text = "Cliente";
            this.clienteToolStripMenuItem1.Click += new System.EventHandler(this.clienteToolStripMenuItem1_Click);
            // 
            // funcionárioToolStripMenuItem
            // 
            this.funcionárioToolStripMenuItem.Name = "funcionárioToolStripMenuItem";
            this.funcionárioToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.funcionárioToolStripMenuItem.Text = "Funcionário";
            this.funcionárioToolStripMenuItem.Click += new System.EventHandler(this.funcionárioToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem1
            // 
            this.usuárioToolStripMenuItem1.Name = "usuárioToolStripMenuItem1";
            this.usuárioToolStripMenuItem1.Size = new System.Drawing.Size(153, 24);
            this.usuárioToolStripMenuItem1.Text = "Usuário";
            this.usuárioToolStripMenuItem1.Click += new System.EventHandler(this.usuárioToolStripMenuItem1_Click);
            // 
            // relatToolStripMenuItem
            // 
            this.relatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.escalãoToolStripMenuItem});
            this.relatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("relatToolStripMenuItem.Image")));
            this.relatToolStripMenuItem.Name = "relatToolStripMenuItem";
            this.relatToolStripMenuItem.Size = new System.Drawing.Size(93, 23);
            this.relatToolStripMenuItem.Text = "Relatório";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // escalãoToolStripMenuItem
            // 
            this.escalãoToolStripMenuItem.Name = "escalãoToolStripMenuItem";
            this.escalãoToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.escalãoToolStripMenuItem.Text = "Escalão";
            this.escalãoToolStripMenuItem.Click += new System.EventHandler(this.escalãoToolStripMenuItem_Click);
            // 
            // escalãoToolStripMenuItem1
            // 
            this.escalãoToolStripMenuItem1.Name = "escalãoToolStripMenuItem1";
            this.escalãoToolStripMenuItem1.Size = new System.Drawing.Size(153, 24);
            this.escalãoToolStripMenuItem1.Text = "Escalão";
            this.escalãoToolStripMenuItem1.Click += new System.EventHandler(this.escalãoToolStripMenuItem1_Click);
            // 
            // instalaçðesToolStripMenuItem
            // 
            this.instalaçðesToolStripMenuItem.Name = "instalaçðesToolStripMenuItem";
            this.instalaçðesToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.instalaçðesToolStripMenuItem.Text = "Instalações";
            this.instalaçðesToolStripMenuItem.Click += new System.EventHandler(this.instalaçðesToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 521);
            this.Controls.Add(this.pnlDock);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Água Privada Matanquene ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlDock.ResumeLayout(false);
            this.pnlDock.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Panel pnlDock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarSessãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem relatToolStripMenuItem;
        private System.Windows.Forms.Label lblNomeUs;
        private System.Windows.Forms.Label lblUsu;
        private System.Windows.Forms.Button btnPagamento;
        private System.Windows.Forms.Button btnInstalacao;
        private System.Windows.Forms.Button btnEscalao;
        private System.Windows.Forms.ToolStripMenuItem funcionárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalãoToolStripMenuItem;
        private System.Windows.Forms.Button btnFacturacao;
        private System.Windows.Forms.ToolStripMenuItem escalãoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem instalaçðesToolStripMenuItem;
    }
}

