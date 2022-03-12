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
    public partial class frmCasFuncionario : Form
    {
        public string operacao;
        public int id;

        // conexao
        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmCasFuncionario()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtCod.ResetText();
            txtNome.ResetText();
            txtBairro.ResetText();
            cboSexo.ResetText();
            txtContacto.ResetText();
            dtDataNasc.ResetText();
            cboEstCiv.ResetText();
        }

        public void novo()
        {
            btnAdd.Enabled = false;
            btnPesquisar.Enabled = false;
            btnGuardar.Enabled = true;

            txtBairro.Enabled = true;
            txtNome.Enabled = true;
            txtContacto.Enabled = true;
            cboSexo.Enabled = true;
            cboEstCiv.Enabled = true;
            dtDataNasc.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.operacao = "adicionar";
            novo();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.operacao = "pesquisar";
            DALFuncionario DALobj = new DALFuncionario(cx);
            frmPesqFuncionario f = new frmPesqFuncionario();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloFuncionario modelo = DALobj.CarregaModeloFuncionario(f.codigo);

                txtCod.Text = Convert.ToString(modelo.IdFuncionario);
                txtNome.Text = modelo.Nome;
                cboSexo.Text = modelo.Sexo;
                txtBairro.Text = modelo.Endereco;
                txtContacto.Text = modelo.Contacto;
                cboEstCiv.Text = modelo.EstadoCivil;
                dtDataNasc.Text = Convert.ToString(modelo.DataNasc);

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o nome do funcionário");
                txtNome.Focus();
                return;
            }

            if (cboSexo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o sexo do funcionário");
                cboSexo.Focus();
                return;
            }

            if (cboEstCiv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o estado civil do funcionário");
                cboEstCiv.Focus();
                return;
            }

            if (txtBairro.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o endereço do funcionário");
                txtBairro.Focus();
                return;
            }

            if (txtContacto.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o contacto do funcionário");
                txtContacto.Focus();
                return;
            }

            DALFuncionario DALobj = new DALFuncionario(cx);
            // insere e altera
            try
            {
                ModeloFuncionario mdC = new ModeloFuncionario();

                mdC.Nome = txtNome.Text;
                mdC.Sexo = cboSexo.Text;
                mdC.Endereco = txtBairro.Text;
                mdC.Contacto = txtContacto.Text;
                mdC.EstadoCivil = cboEstCiv.Text;
                mdC.DataNasc = Convert.ToDateTime(dtDataNasc.Text);

                if (this.operacao == "adicionar") // insirir
                {
                    DALobj.Incluir(mdC); // insere na tabela Funcionario
                    MessageBox.Show("Cadastro efetuado com sucesso. Código nº " + mdC.IdFuncionario.ToString());
                    // pega o codigo do Funcionario
                    this.id = Convert.ToInt32(mdC.IdFuncionario);
                }
                else // alterar
                {
                    mdC.IdFuncionario = Convert.ToInt32(txtCod.Text);
                    DALobj.Alterar(mdC); // altera na tabela Funcionario
                    MessageBox.Show("Registo alterado.");
                }
                btnCancelar_Click(sender, e);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
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
                    btnCancelar_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registo, o mesmo está sendo utilizado em outro local.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnPesquisar.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnApagar.Enabled = false;

            txtBairro.Enabled = false;
            txtNome.Enabled = false;
            txtContacto.Enabled = false;
            cboSexo.Enabled = false;
            cboEstCiv.Enabled = false;
            dtDataNasc.Enabled = false;
            limpar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
