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
    public partial class frmConsEscalao : Form
    {
        public frmConsEscalao()
        {
            InitializeComponent();
        }

        private void frmConsEscalao_Load(object sender, EventArgs e)
        {
            txtPesquisar_TextChanged(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].HeaderText = "Espécie";
            dgvDados.Columns[1].Width = 250;
            dgvDados.Columns[2].HeaderText = "Quantidade";
            dgvDados.Columns[2].Width = 150;
            dgvDados.Columns[3].HeaderText = "Valor Unitário";
            dgvDados.Columns[3].Width = 150;
            dgvDados.Columns[4].HeaderText = "IVA";
            dgvDados.Columns[4].Width = 160;

            dgvDados.Columns[0].Visible = false;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALEscalao DALobj = new DALEscalao(cx);
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
                mensagem.Text = "Escalão não encontrado, verifique o código ou o nome e tenta de novo";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
