using ÁguaPrivadaMatanquene.DAL;
using ÁguaPrivadaMatanquene.Modelos;
using ÁguaPrivadaMatanquene.Pesquisar;
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

namespace ÁguaPrivadaMatanquene.Cadastro
{
    public partial class frmCasEscalao : Form
    {
        public string operacao;
        public int id;

        // conexao
        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmCasEscalao()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtCod.ResetText();
            txtEspecie.ResetText();
            txtQuantidade.ResetText();
            txtValUn.ResetText();
            txtIVA.ResetText();
        }

        public void novo()
        {
            btnAdd.Enabled = false;
            btnPesquisar.Enabled = false;
            btnGuardar.Enabled = true;

            txtEspecie.Enabled = true;
            txtQuantidade.Enabled = true;
            txtValUn.Enabled = true;
            txtIVA.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEspecie.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite a espécie do escalão");
                txtEspecie.Focus();
                return;
            }

            if (txtQuantidade.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, informe a quantidade");
                txtQuantidade.Focus();
                return;
            }

            if (txtValUn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o valor unitário");
                txtValUn.Focus();
                return;
            }

            if (txtIVA.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o valor de IVA");
                txtIVA.Focus();
                return;
            }

            DALEscalao DALobj = new DALEscalao(cx);
            // insere e altera
            try
            {
                ModeloEscalao mdC = new ModeloEscalao();

                mdC.Especie = txtEspecie.Text;
                mdC.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                mdC.ValorUn = Convert.ToDouble(txtValUn.Text);
                mdC.IVA = Convert.ToDouble(txtIVA.Text);
                if (this.operacao == "adicionar") // insirir
                {
                    DALobj.Incluir(mdC); // insere na tabela cliente
                    MessageBox.Show("Cadastro efetuado com sucesso. Código nº " + mdC.IdEscalao.ToString());
                    // pega o codigo do cliente
                    this.id = Convert.ToInt32(mdC.IdEscalao);
                }
                else // alterar
                {
                    mdC.IdEscalao = Convert.ToInt32(txtCod.Text);
                    DALobj.Alterar(mdC); // altera na tabela cliente
                    MessageBox.Show("Registo alterado.");
                    
                }
                btnCancelar_Click(sender, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.operacao = "adicionar";
            novo();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.operacao = "pesquisar";
            DALEscalao DALobj = new DALEscalao(cx);
            frmPesqEscalao f = new frmPesqEscalao();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloEscalao modelo = DALobj.CarregaModeloEscalao(f.codigo);

                txtCod.Text = Convert.ToString(modelo.IdEscalao);
                txtEspecie.Text = modelo.Especie;
                txtQuantidade.Text = modelo.Quantidade.ToString();
                txtValUn.Text = modelo.ValorUn.ToString();
                txtIVA.Text = modelo.IVA.ToString();
                btnAdd.Enabled = false;
                btnPesquisar.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = true;
                btnApagar.Enabled = true;
            }
            else
            {
                this.limpar();
            }
            f.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            novo();
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DALCliente DALobj = new DALCliente(cx);
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registo?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    DALobj.Excluir(Convert.ToInt32(txtCod.Text));
                    this.limpar();
                    this.novo();
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registo, o mesmo está sendo utilizado em outro local.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                novo();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnPesquisar.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnApagar.Enabled = false;

            txtEspecie.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValUn.Enabled = false;
            txtIVA.Enabled = false;
            limpar();
        }
    }
}
