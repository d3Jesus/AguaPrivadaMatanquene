/* @author 89-117-114-97-110-32-100-101-32-74-101-115-117-115-32-69-67 */
using ÁguaPrivadaMatanquene.Cadastro;
using ÁguaPrivadaMatanquene.Consulta;
using ÁguaPrivadaMatanquene.DAL;
using ÁguaPrivadaMatanquene.Factura_e_Recibo;
using ÁguaPrivadaMatanquene.Relatorio.GUI;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÁguaPrivadaMatanquene
{
    public partial class frmMain : Form
    {
        public string usuario, cargo;
        public int idFunc;
        public frmMain(string usuario, string cargo)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.cargo = cargo;
            this.lblNomeUs.Text = usuario;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            terminarSessãoToolStripMenuItem_Click(sender, e);
        }

        private void terminarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está prestes a sair do sistema! Deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d.ToString() == "Yes")
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCasCliente c = new frmCasCliente();
            c.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmUsuario u = new frmUsuario();
            u.ShowDialog();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmCasFuncionario f = new frmCasFuncionario();
            f.ShowDialog();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUsuario_Click(sender, e);
        }

        private void mudarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();

            frmLogin l = new frmLogin();
            l.ShowDialog();
            l.Dispose();
        }

        private void btnInstalacao_Click(object sender, EventArgs e)
        {
            frmCasInstalacao i = new frmCasInstalacao(usuario);
            i.ShowDialog();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            frmCasPagamento p = new frmCasPagamento();
            p.ShowDialog();
        }

        private void btnEscalao_Click(object sender, EventArgs e)
        {
            frmCasEscalao es = new frmCasEscalao();
            es.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Close();
            f.Dispose();
            if(cargo.Equals("Contabilista"))
            {
                btnUsuario.Enabled = false;
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALUsuario dlf = new DALUsuario(cx);
            DALFactura dl = new DALFactura(cx);

            idFunc = dlf.IdFuncionario(usuario);

            DateTime dt = DateTime.Now;
            // insere os dados na tabela de factura para a facturação 
            // sempre no dia 26 de cada mes
            if(dt.Day == 9)
            {
                dl.Incluir();
            }
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsCliente c = new frmConsCliente();
            c.ShowDialog();
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsUsu u = new frmConsUsu();
            u.ShowDialog();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsFunc f = new frmConsFunc();
            f.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCliente rc = new frmRptCliente();
            rc.ShowDialog();
        }

        private void btnFacturacao_Click(object sender, EventArgs e)
        {
            frmFacturacao f = new frmFacturacao();
            f.ShowDialog();
        }

        private void instalaçðesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsInstalacao i = new frmConsInstalacao();
            i.ShowDialog();
        }

        private void escalãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsEscalao es = new frmConsEscalao();
            es.ShowDialog();
        }

        private void escalãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptEscalao re = new frmRptEscalao();
            re.ShowDialog();
        }
    }
}
