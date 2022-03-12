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
    public partial class frmUsuario : Form
    {
        public string operacao;
        public int id;

        // conexao
        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmUsuario()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtCod.ResetText();
            cboNomeFunc.ResetText();
            txtSenha.ResetText();
            cboSituacao.ResetText();
            cboCargo.ResetText();
            txtNomeUs.ResetText();
        }

        public void novo()
        {
            btnAdd.Enabled = false;
            btnPesquisar.Enabled = false;
            btnGuardar.Enabled = true;
            btnAddF.Enabled = true;
            btnBuscar.Enabled = true;

            cboNomeFunc.Enabled = true;
            txtNomeUs.Enabled = true;
            txtSenha.Enabled = true;
            cboCargo.Enabled = true;
            cboSituacao.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.operacao = "adicionar";
            novo();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.operacao = "pesquisar";
            DALUsuario DALobj = new DALUsuario(cx);
            DALFuncionario fun = new DALFuncionario(cx);
            frmPesqUsuario f = new frmPesqUsuario();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloUsuario modelo = DALobj.CarregaModeloUsuario(f.codigo);
                string nomeFuncionario = fun.CarregaNomeFuncionario(modelo.IdFuncionario);

                txtCod.Text = Convert.ToString(modelo.IdUsuario);
                txtNomeUs.Text = modelo.NomeUsuario;
                cboNomeFunc.Text = nomeFuncionario;
                txtSenha.Text = modelo.Senha;
                cboCargo.Text = modelo.Cargo;
                cboSituacao.Text = modelo.Situacao;

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
            if (cboNomeFunc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o nome do funcionário");
                cboNomeFunc.Focus();
                return;
            }

            if (txtNomeUs.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o nome de usuário");
                txtNomeUs.Focus();
                return;
            }

            if (txtSenha.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite a senha do usuário");
                txtSenha.Focus();
                return;
            }

            if (cboCargo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o cargo do usuário");
                cboCargo.Focus();
                return;
            }

            if (cboSituacao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o estado do usuário");
                cboSituacao.Focus();
                return;
            }

            DALUsuario DALobj = new DALUsuario(cx);
            // insere e altera
            try
            {
                ModeloUsuario mdC = new ModeloUsuario();

                mdC.IdFuncionario = Convert.ToInt32(cboNomeFunc.SelectedValue);
                mdC.NomeUsuario = txtNomeUs.Text;
                mdC.Senha = txtSenha.Text;
                mdC.Cargo = cboCargo.Text;
                mdC.Situacao = cboSituacao.Text;

                if (this.operacao == "adicionar") // insirir
                {
                    DALobj.Incluir(mdC); // insere na tabela Usuario
                    MessageBox.Show("Cadastro efetuado com sucesso. Código nº " + mdC.IdUsuario.ToString());
                    // pega o codigo do Usuario
                    this.id = Convert.ToInt32(mdC.IdUsuario);
                }
                else // alterar
                {
                    mdC.IdUsuario = Convert.ToInt32(txtCod.Text);
                    DALobj.Alterar(mdC); // altera na tabela Usuario
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
            DALUsuario DALobj = new DALUsuario(cx);
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

            cboNomeFunc.Enabled = false;
            txtNomeUs.Enabled = false;
            txtSenha.Enabled = false;
            cboCargo.Enabled = false;
            cboSituacao.Enabled = false;
            limpar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            DALFuncionario DALobj = new DALFuncionario(cx);
            cboNomeFunc.DataSource = DALobj.ApresentarFunc();
            cboNomeFunc.DisplayMember = "nome";
            cboNomeFunc.ValueMember = "idFuncionario";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DALFuncionario DALobj = new DALFuncionario(cx);
            frmPesqFuncionario f = new frmPesqFuncionario();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloFuncionario modelo = DALobj.CarregaModeloFuncionario(f.codigo);

                cboNomeFunc.Text = Convert.ToString(modelo.Nome);

                btnAdd.Enabled = false;
                btnPesquisar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            else
            {
                this.limpar();
            }
            f.Dispose();
        }

        private void btnAddF_Click(object sender, EventArgs e)
        {
            DALFuncionario DALobj = new DALFuncionario(cx);
            frmCasFuncionario f = new frmCasFuncionario();
            f.ShowDialog();
            if (f.id != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloFuncionario modelo = DALobj.CarregaModeloFuncionario(f.id);

                cboNomeFunc.Text = Convert.ToString(modelo.Nome);

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
    }
}
