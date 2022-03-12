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
    public class DALFuncionario
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALFuncionario(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloFuncionario modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblFuncionario (nome, sexo, dataNascimento, estadoCivil, contacto, endereco)" +
                " values (@nome, @sexo, @dataNascimento, @estadoCivil, @contacto, @endereco); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            cmd.Parameters.AddWithValue("@sexo", modelo.Sexo);
            cmd.Parameters.AddWithValue("@endereco", modelo.Endereco);
            cmd.Parameters.AddWithValue("@contacto", modelo.Contacto);
            cmd.Parameters.AddWithValue("@estadoCivil", modelo.EstadoCivil);
            cmd.Parameters.AddWithValue("@dataNascimento", modelo.DataNasc);
            conexao.Conectar();
            modelo.IdFuncionario = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloFuncionario modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblFuncionario SET nome = (@nome), sexo = (@sexo), dataNascimento = (@dataNascimento)," +
                " estadoCivil = (@estadoCivil), contacto = (@contacto), endereco =(@endereco) WHERE idFuncionario = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            cmd.Parameters.AddWithValue("@sexo", modelo.Sexo);
            cmd.Parameters.AddWithValue("@endereco", modelo.Endereco);
            cmd.Parameters.AddWithValue("@contacto", modelo.Contacto);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdFuncionario);
            cmd.Parameters.AddWithValue("@estadoCivil", modelo.EstadoCivil);
            cmd.Parameters.AddWithValue("@dataNascimento", modelo.DataNasc);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblFuncionario WHERE idFuncionario = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // busca na tabela
        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idFuncionario, nome, sexo, dataNascimento, estadoCivil," +
                " contacto FROM tblFuncionario WHERE nome LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela
        public DataTable ApresentarFunc()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT f.idFuncionario, f.nome FROM tblFuncionario f INNER"+
                " JOIN tblUsuario u ON f.idFuncionario <> u.idFuncionario", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela
        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idFuncionario, nome, sexo, dataNascimento, estadoCivil," +
                " contacto FROM tblFuncionario WHERE idFuncionario = '%" + Convert.ToInt32(valor) + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // verifica a existencia do cliente
        public int VerificaFuncionario(string nome)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblFuncionario WHERE nome = @nome";
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

        public ModeloFuncionario CarregaModeloFuncionario(int codigo)
        {
            ModeloFuncionario modelo = new ModeloFuncionario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblFuncionario where idFuncionario = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdFuncionario = Convert.ToInt32(registo["idFuncionario"]);
                modelo.Nome = Convert.ToString(registo["nome"]);
                modelo.Sexo = Convert.ToString(registo["sexo"]);
                modelo.Endereco = Convert.ToString(registo["endereco"]);
                modelo.Contacto = Convert.ToString(registo["contacto"]);
                modelo.DataNasc = Convert.ToDateTime(registo["dataNascimento"]);
                modelo.EstadoCivil = Convert.ToString(registo["estadoCivil"]);
            }
            conexao.Desconectar();
            return modelo;
        }

        // retorna o nome do cliente
        public string CarregaNomeFuncionario(int id)
        {
            string nome = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblFuncionario WHERE idFuncionario = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                nome = Convert.ToString(registo["nome"]);
            }
            conexao.Desconectar();
            return nome;
        }
    }
}
