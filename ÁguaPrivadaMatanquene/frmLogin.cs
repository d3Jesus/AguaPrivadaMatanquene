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

namespace ÁguaPrivadaMatanquene
{
    public partial class frmLogin : Form
    {
        public int resultado;
        public string cargo;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DALConexao conexao = new DALConexao(DadosDaConexao.StringDeConexao);

            try
            {
                DALLogin DALobj = new DALLogin(conexao);
                txtNome.Enabled = false;
                txtSenha.Enabled = false;

                string u = txtNome.Text; // campo de nome
                string pss = txtSenha.Text; // campo de senha
                resultado = DALobj.VerificaUsuario(u, pss); // pega o id do funcionario
                string sit = DALobj.VerificaEstado(u);
                if (resultado == 0) // verifica se existe usuario
                {
                    // se nao existir == tambem serve para os campos
                    MessageBox.Show("Usuário ou palavra passe incorrecto, verifique e tente de novo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Text = ""; // limpa o campo de senha
                    txtNome.Enabled = true;
                    txtSenha.Enabled = true;
                    txtSenha.Focus(); // coloca o cursor no campo da senha
                }
                else // caso contrario
                {
                    if (sit.Equals("Inactivo"))
                    {
                        // se nao existir == tambem serve para os campos
                        MessageBox.Show("Lamento mas este usuário encontra-se inactivo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNome.Text = ""; // limpa o campo do nome de usuário
                        txtSenha.Text = ""; // limpa o campo de senha
                        txtNome.Enabled = true;
                        txtSenha.Enabled = true;
                        txtNome.Focus(); // coloca o cursor no campo do nome
                    }
                    else
                    {
                        cargo = DALobj.CarregaTipoDeUsuario(resultado);// pega o cargo do funcionário
                        frmMain p = new frmMain(u, cargo); // cria uma instancia para o formulário principal com os paramereos nome e cargo
                        p.ShowDialog(); // abre o formulario principal ou inicial
                        this.Close(); // fecha a janela de login
                        this.Dispose(); // limpa a memoria usada pela janela de login
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
