using ÁguaPrivadaMatanquene.DAL;
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

namespace ÁguaPrivadaMatanquene.Consulta
{
    public partial class frmConsUsu : Form
    {
        public frmConsUsu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALUsuario DALobj = new DALUsuario(cx);
            if (rbCod.Checked == true && txtPesquisar.Text.Trim().Length > 0)
            {
                dgvDados.DataSource = DALobj.LocalizarCod(txtPesquisar.Text);
            }
            else
            {
                dgvDados.DataSource = DALobj.LocalizarNome(txtPesquisar.Text);
            }

            if (dgvDados.Rows.Count == 0)
            {
                mensagem.Visible = true;
                mensagem.Text = "Usuário não encontrado, verifique o código ou o nome e tenta de novo";
            }
        }

        private void frmConsUsu_Load(object sender, EventArgs e)
        {
            txtPesquisar_TextChanged(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 60;
            dgvDados.Columns[1].HeaderText = "Nome Funcionário";
            dgvDados.Columns[1].Width = 250;
            dgvDados.Columns[2].HeaderText = "Nome Usuário";
            dgvDados.Columns[2].Width = 100;
            dgvDados.Columns[3].HeaderText = "Senha";
            dgvDados.Columns[3].Width = 100;
            dgvDados.Columns[4].HeaderText = "Cargo";
            dgvDados.Columns[4].Width = 200;
            dgvDados.Columns[5].HeaderText = "Situação";
            dgvDados.Columns[5].Width = 120;

            dgvDados.Columns[0].Visible = false;
        }
    }
}
