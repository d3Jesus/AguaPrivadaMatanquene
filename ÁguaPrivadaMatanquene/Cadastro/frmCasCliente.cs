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
    public partial class frmCasCliente : Form
    {
        public string operacao;
        public int id;

        // conexao
        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmCasCliente()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtCod.ResetText();
            txtNome.ResetText();
            txtProv.ResetText();
            txtBairro.ResetText();
            cboSexo.ResetText();
            txtContacto.ResetText();
            dtData.ResetText();
            cboEstCiv.ResetText();
            txtQt.ResetText();
            txtRua.ResetText();
        }

        public void novo()
        {
            btnAdd.Enabled = false; // btn novo
            btnPesquisar.Enabled = false; 
            btnGuardar.Enabled = true;

            txtBairro.Enabled = true;
            txtNome.Enabled = true;
            txtContacto.Enabled = true;
            txtProv.Enabled = true;
            cboSexo.Enabled = true;
            cboEstCiv.Enabled = true;
            txtRua.Enabled = true;
            txtQt.Enabled = true;
            dtData.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o nome do cliente");
                txtNome.Focus();
                return;
            }

            if (cboSexo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o sexo do cliente");
                cboSexo.Focus();
                return;
            }

            if (cboEstCiv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o estado civil do cliente");
                cboEstCiv.Focus();
                return;
            }

            if (txtProv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite a província do cliente");
                txtProv.Focus();
                return;
            }

            if (txtBairro.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o bairro do cliente");
                txtBairro.Focus();
                return;
            }

            if (txtQt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o quarteirão  do cliente");
                txtQt.Focus();
                return;
            }

            if (txtRua.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite a rua do cliente");
                txtRua.Focus();
                return;
            }

            if (txtContacto.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o contacto do cliente");
                txtContacto.Focus();
                return;
            }

            DALCliente DALobj = new DALCliente(cx);
            // insere e altera
            try
            {
                ModeloCliente mdC = new ModeloCliente();

                mdC.Nome = txtNome.Text;
                mdC.Sexo = cboSexo.Text;
                mdC.DataNasc = Convert.ToDateTime(dtData.Text);
                mdC.Provincia = txtProv.Text;
                mdC.Bairro = txtBairro.Text;
                mdC.Quarteirao = Convert.ToInt32(txtQt.Text);
                mdC.Rua = txtRua.Text;
                mdC.EstadoCivil = cboEstCiv.Text;
                mdC.Contacto = txtContacto.Text;

                if (this.operacao == "adicionar") // insirir
                {
                    DALobj.Incluir(mdC); // insere na tabela cliente
                    MessageBox.Show("Cadastro efetuado com sucesso. Código nº " + mdC.IdCliente.ToString());
                    // pega o codigo do cliente
                    this.id = Convert.ToInt32(mdC.IdCliente);
                }
                else // alterar
                {
                    mdC.IdCliente = Convert.ToInt32(txtCod.Text);
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
            DALCliente DALobj = new DALCliente(cx);
            frmPesqCliente f = new frmPesqCliente();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloCliente modelo = DALobj.CarregaModeloCliente(f.codigo);
                
                txtCod.Text = Convert.ToString(modelo.IdCliente);
                txtNome.Text = modelo.Nome;
                cboSexo.Text = modelo.Sexo;
                txtProv.Text = modelo.Provincia;
                txtBairro.Text = modelo.Bairro;
                txtContacto.Text = modelo.Contacto;
                cboEstCiv.Text = modelo.EstadoCivil;
                txtQt.Text = modelo.Quarteirao.ToString();
                txtRua.Text = modelo.Rua;

                btnAdd.Enabled = false; // btn novo
                btnPesquisar.Enabled = false;
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
            btnGuardar.Enabled = true;
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
            txtProv.Enabled = false;
            cboSexo.Enabled = false;
            dtData.Enabled = false;
            cboEstCiv.Enabled = false;
            txtQt.Enabled = false;
            txtRua.Enabled = false;
            limpar();
        }
    }
}
