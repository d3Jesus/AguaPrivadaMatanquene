using ÁguaPrivadaMatanquene.DAL;
using ÁguaPrivadaMatanquene.Modelos;
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
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
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

            if (txtNomeUs.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite o nome de usuário");
                txtNomeUs.Focus();
                return;
            }

            if (txtSenha.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, digite a senha");
                txtSenha.Focus();
                return;
            }

            // conexao
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

            DALFuncionario DALFunc = new DALFuncionario(cx);
            DALUsuario DALUsu = new DALUsuario(cx);
            ModeloFuncionario mdC = new ModeloFuncionario();
            ModeloUsuario md = new ModeloUsuario();

            // funcionario
            mdC.Nome = txtNome.Text;
            mdC.Sexo = cboSexo.Text;
            mdC.Endereco = txtBairro.Text;
            mdC.Contacto = txtContacto.Text;
            mdC.EstadoCivil = cboEstCiv.Text;
            mdC.DataNasc = Convert.ToDateTime(dtDataNasc.Text);
            DALFunc.Incluir(mdC); // insere na tabela Funcionario

            // usuario
            md.IdFuncionario = mdC.IdFuncionario;
            md.NomeUsuario = txtNomeUs.Text;
            md.Senha = txtSenha.Text;
            md.Cargo = "Administrador";
            md.Situacao = "Activo";            
            DALUsu.Incluir(md); // insere na tabela Usuario

            MessageBox.Show("O sistema está pronto para ser usado...");
            Application.Restart();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            MessageBox.Show("O sistema estará pronto a ser usado depois de preencher os dados do ADMINISTRADOR!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
