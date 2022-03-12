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
    public partial class frmCasInstalacao : Form
    {
        public string operacao, usu;
        public int id;

        // conexao
        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmCasInstalacao(string usuario)
        {
            InitializeComponent();
            this.usu = usuario;
        }

        public void limpar()
        {
            txtCod.ResetText();
            cboCliente.ResetText();
            cboEscalao.ResetText();
            txtContador.ResetText();
            txtLocal.ResetText();
        }

        public void novo()
        {
            btnAdd.Enabled = false;
            btnPesquisar.Enabled = false;
            btnGuardar.Enabled = true;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            cboCliente.Enabled = true;
            cboEscalao.Enabled = true;
            txtContador.Enabled = true;
            txtLocal.Enabled = true;
            btnBuscarCliente.Enabled = true;
            btnBuscarEscalao.Enabled = true;
            btnAddCliente.Enabled = true;
            btnAddEscalao.Enabled = true;
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            DALCliente DALobj = new DALCliente(cx);
            frmCasCliente f = new frmCasCliente();
            f.ShowDialog();
            if (f.id != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloCliente modelo = DALobj.CarregaModeloCliente(f.id);

                cboCliente.Text = Convert.ToString(modelo.Nome);

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

        private void btnAddEscalao_Click(object sender, EventArgs e)
        {
            DALEscalao DALobj = new DALEscalao(cx);
            frmCasEscalao f = new frmCasEscalao();
            f.ShowDialog();
            if (f.id != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloEscalao modelo = DALobj.CarregaModeloEscalao(f.id);

                cboEscalao.Text = Convert.ToString(modelo.Especie);

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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            DALCliente DALobj = new DALCliente(cx);
            frmPesqCliente f = new frmPesqCliente();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloCliente modelo = DALobj.CarregaModeloCliente(f.codigo);

                cboCliente.Text = Convert.ToString(modelo.Nome);

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

        private void btnBuscarEscalao_Click(object sender, EventArgs e)
        {
            DALEscalao DALobj = new DALEscalao(cx);
            frmPesqEscalao f = new frmPesqEscalao();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloEscalao modelo = DALobj.CarregaModeloEscalao(f.codigo);

                cboEscalao.Text = Convert.ToString(modelo.Especie);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.operacao = "adicionar";
            novo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o cliente na lista");
                cboCliente.Focus();
                return;
            }

            if (cboEscalao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, selecione o escalão na lista");
                cboEscalao.Focus();
                return;
            }

            if (txtContador.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o nº do contador");
                txtContador.Focus();
                return;
            }

            if (txtLocal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o local de abastecimento");
                txtLocal.Focus();
                return;
            }

            DALInstalacao DALobj = new DALInstalacao(cx);
            // insere e altera
            try
            {
                DALUsuario du = new DALUsuario(cx);
                ModeloInstalacao mdC = new ModeloInstalacao();

                mdC.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                mdC.IdEscalao = Convert.ToInt32(cboEscalao.SelectedValue);
                mdC.IdFuncionario = du.IdFuncionario(usu);
                mdC.Data = DateTime.Now;
                mdC.Contador = Convert.ToInt32(txtContador.Text);
                mdC.LocalAbastecimento = txtLocal.Text;
                if (this.operacao == "adicionar") // insirir
                {
                    DALobj.Incluir(mdC); // insere na tabela cliente
                    MessageBox.Show("Cadastro efetuado com sucesso. Código nº " + mdC.IdInstalacao.ToString());
                    // pega o codigo do cliente
                    this.id = Convert.ToInt32(mdC.IdInstalacao);
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.operacao = "pesquisar";
            DALInstalacao DALobj = new DALInstalacao(cx);
            frmPesqInstalacao f = new frmPesqInstalacao();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                ModeloInstalacao modelo = DALobj.CarregaModeloInstalacao(f.codigo);

                txtCod.Text = Convert.ToString(modelo.IdInstalacao);
                cboCliente.Text = modelo.IdCliente.ToString();
                cboEscalao.Text = modelo.IdEscalao.ToString();
                txtContador.Text = modelo.Contador.ToString();
                txtLocal.Text = modelo.LocalAbastecimento;

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
            DALInstalacao DALobj = new DALInstalacao(cx);
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

            cboCliente.Enabled = false;
            cboEscalao.Enabled = false;
            txtContador.Enabled = false;
            txtLocal.Enabled = false;
            btnAddEscalao.Enabled = false;
            btnAddCliente.Enabled = false;
            btnBuscarEscalao.Enabled = false;
            btnBuscarCliente.Enabled = false;
            limpar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmCasInstalacao_Load(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            DALCliente cc = new DALCliente(cx);
            DALEscalao ee = new DALEscalao(cx);

            cboCliente.DataSource = cc.LocalizarNome("");
            cboCliente.DisplayMember = "nome";
            cboCliente.ValueMember = "idCliente";

            cboEscalao.DataSource = ee.LocalizarNome("");
            cboEscalao.DisplayMember = "especie";
            cboEscalao.ValueMember = "idEscalao";
        }
    }
}
