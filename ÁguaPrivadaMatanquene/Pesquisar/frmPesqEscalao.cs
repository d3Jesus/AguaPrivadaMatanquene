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

namespace ÁguaPrivadaMatanquene.Pesquisar
{
    public partial class frmPesqEscalao : Form
    {
        public int codigo = 0;

        public frmPesqEscalao()
        {
            InitializeComponent();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALEscalao DALobj = new DALEscalao(cx);
            dgvDados.DataSource = DALobj.LocalizarNome(txtPesquisar.Text);

            if (dgvDados.Rows.Count == 0)
            {
                mensagem.Visible = true;
                mensagem.Text = "Cliente não encontrado, verifique o código ou o nome e tenta de novo";
            }
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        private void frmPesqEscalao_Load(object sender, EventArgs e)
        {
            txtPesquisar_TextChanged(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 60;
            dgvDados.Columns[1].HeaderText = "Espécie";
            dgvDados.Columns[1].Width = 250;
            dgvDados.Columns[2].HeaderText = "Quantidade";
            dgvDados.Columns[2].Width = 60;
            dgvDados.Columns[3].HeaderText = "Valor Unitário";
            dgvDados.Columns[3].Width = 100;
            dgvDados.Columns[4].HeaderText = "IVA";
            dgvDados.Columns[4].Width = 200;

            dgvDados.Columns[0].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
