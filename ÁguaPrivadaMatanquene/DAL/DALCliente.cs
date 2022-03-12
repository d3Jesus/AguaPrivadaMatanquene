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
    public class DALCliente
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALCliente(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblCliente (nome, sexo, dataNascimento, provincia, bairro, quarteirao,"+
                " rua, estadoCivil, contacto) values (@nome, @sexo, @dataNascimento, @provincia, @bairro, @quarteirao," +
                " @rua, @estadoCivil, @contacto); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            cmd.Parameters.AddWithValue("@sexo", modelo.Sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", modelo.DataNasc);
            cmd.Parameters.AddWithValue("@provincia", modelo.Provincia);
            cmd.Parameters.AddWithValue("@bairro", modelo.Bairro);
            cmd.Parameters.AddWithValue("@quarteirao", modelo.Quarteirao);
            cmd.Parameters.AddWithValue("@rua", modelo.Rua);
            cmd.Parameters.AddWithValue("@estadoCivil", modelo.EstadoCivil);
            cmd.Parameters.AddWithValue("@contacto", modelo.Contacto);
            conexao.Conectar();
            modelo.IdCliente = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblCliente SET nome = (@nome), sexo = (@sexo), dataNascimento = (@dataNascimento),"+
                " provincia = (@provincia), bairro =(@bairro), quarteirao = (@quarteirao), rua = (@rua)," +
                " estadoCivil = (@estadoCivil), contacto = (@contacto) WHERE idCliente = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            cmd.Parameters.AddWithValue("@sexo", modelo.Sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", modelo.DataNasc);
            cmd.Parameters.AddWithValue("@provincia", modelo.Provincia);
            cmd.Parameters.AddWithValue("@bairro", modelo.Bairro);
            cmd.Parameters.AddWithValue("@quarteirao", modelo.Quarteirao);
            cmd.Parameters.AddWithValue("@rua", modelo.Rua);
            cmd.Parameters.AddWithValue("@estadoCivil", modelo.EstadoCivil);
            cmd.Parameters.AddWithValue("@contacto", modelo.Contacto);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdCliente);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblCliente WHERE idCliente = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // busca na tabela usando o codigo
        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idCliente, nome, sexo, provincia, bairro, contacto" +
                " FROM tblCliente WHERE idCliente = '" + Convert.ToInt32(valor) + "'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela usando o nome
        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idCliente, nome, sexo, provincia, bairro, contacto"+
                " FROM tblCliente WHERE nome LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // verifica a existencia do cliente
        public string VerificaCliente(int nome)
        {
            string r = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblCliente WHERE idCliente = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToString(registo["nome"]);
            }
            conexao.Desconectar();
            return r;
        }

        public ModeloCliente CarregaModeloCliente(int codigo)
        {
            ModeloCliente modelo = new ModeloCliente();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblCliente where idCliente = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdCliente = Convert.ToInt32(registo["idCliente"]);
                modelo.Nome = Convert.ToString(registo["nome"]);
                modelo.Sexo = Convert.ToString(registo["sexo"]);
                modelo.DataNasc = Convert.ToDateTime(registo["dataNascimento"]);
                modelo.Provincia = Convert.ToString(registo["provincia"]);
                modelo.Bairro = Convert.ToString(registo["bairro"]);
                modelo.Quarteirao = Convert.ToInt32(registo["quarteirao"]);
                modelo.Rua = Convert.ToString(registo["rua"]);
                modelo.EstadoCivil = Convert.ToString(registo["estadoCivil"]);
                modelo.Contacto = Convert.ToString(registo["contacto"]);
            }
            conexao.Desconectar();
            return modelo;
        }

        // retorna o nome do cliente
        public string CarregaNomeCliente(int id)
        {
            string nome = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblCliente WHERE idCliente = @id";
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
