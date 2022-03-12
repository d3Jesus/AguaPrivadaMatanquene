using ÁguaPrivadaMatanquene.Modelos;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.DAL
{
    public class DALUsuario
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloUsuario modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblUsuario (idFuncionario, nomeUsuario, senha, cargo, situacao)" +
                " values (@idFuncionario, @nomeUsuario, @senha, @cargo, @situacao); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@idFuncionario", modelo.IdFuncionario);
            cmd.Parameters.AddWithValue("@nomeUsuario", modelo.NomeUsuario);
            cmd.Parameters.AddWithValue("@senha", modelo.Senha);
            cmd.Parameters.AddWithValue("@cargo", modelo.Cargo);
            cmd.Parameters.AddWithValue("@situacao", modelo.Situacao);
            conexao.Conectar();
            modelo.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloUsuario modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblUsuario SET idFuncionario = (@idFuncionario), nomeUsuario = (@nomeUsuario), senha = (@senha)," +
                " cargo = (@cargo), situacao = (@situacao) WHERE idUsuario = @codigo;";
            cmd.Parameters.AddWithValue("@idFuncionario", modelo.IdFuncionario);
            cmd.Parameters.AddWithValue("@nomeUsuario", modelo.NomeUsuario);
            cmd.Parameters.AddWithValue("@senha", modelo.Senha);
            cmd.Parameters.AddWithValue("@cargo", modelo.Cargo);
            cmd.Parameters.AddWithValue("@situacao", modelo.Situacao);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdUsuario);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblUsuario WHERE idUsuario = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // busca na tabela
        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idUsuario, idFuncionario, nomeUsuario, senha, cargo, situacao" +
                " FROM tblUsuario WHERE idFuncionario LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela
        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idUsuario, idFuncionario, nomeUsuario, senha, cargo, situacao" +
                " FROM tblUsuario WHERE idUsuario = '%" + Convert.ToInt32(valor) + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // verifica a existencia do cliente
        public int VerificaUsuario(string nome)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblUsuario WHERE nomeUsuario = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToInt32(registo["idUsuario"]);
            }
            conexao.Desconectar();
            return r;
        }

        // verifica a existencia do cliente
        public int IdFuncionario(string nome)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblUsuario WHERE nomeUsuario = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToInt32(registo["idFuncionario"]);
            }
            conexao.Desconectar();
            return r;
        }

        public ModeloUsuario CarregaModeloUsuario(int codigo)
        {
            ModeloUsuario modelo = new ModeloUsuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblUsuario where idUsuario = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdUsuario = Convert.ToInt32(registo["idUsuario"]);
                modelo.IdFuncionario = Convert.ToInt32(registo["idFuncionario"]);
                modelo.NomeUsuario = Convert.ToString(registo["nomeUsuario"]);
                modelo.Senha = Convert.ToString(registo["senha"]);
                modelo.Cargo = Convert.ToString(registo["cargo"]);
                modelo.Situacao = Convert.ToString(registo["situacao"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
