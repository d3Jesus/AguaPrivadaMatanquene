using ÁguaPrivadaMatanquene.Modelos;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁguaPrivadaMatanquene.DAL
{
    public class DALLogin
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALLogin(DALConexao cx)
        {
            this.conexao = cx;
        }

        public int VerificaUsuario(string nome, string senha)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblUsuario WHERE nomeUsuario = @nome COLLATE Latin1_General_CS_AS" +
                " and senha = @senha COLLATE Latin1_General_CS_AS";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
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

        // retorna o estado
        public string VerificaEstado(string nome)
        {
            string r = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblUsuario WHERE nomeUsuario = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToString(registo["situacao"]);
            }
            conexao.Desconectar();
            return r;
        }

        public int VerificaNomeDeUsuario(string nome)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblUsuario WHERE nomeUsuario = @nome COLLATE Latin1_General_CS_AS";
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

        // pega o tipo de usuario
        public string CarregaTipoDeUsuario(int id)
        {
            string tp = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblUsuario where idUsuario = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", id);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                tp = Convert.ToString(registo["cargo"]);
            }
            conexao.Desconectar();
            return tp;
        }

        public ModeloLogin CarregaModeloLogin()
        {
            ModeloLogin modelo = new ModeloLogin();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblUsuario";
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdLogin = Convert.ToInt32(registo["idUsuario"]);
                modelo.TipoDeUsuario = Convert.ToString(registo["cargo"]);
                modelo.Usuario = Convert.ToString(registo["nomeUsuario"]);
                modelo.Senha = Convert.ToString(registo["senha"]);
                modelo.EstadoUsuario = Convert.ToString(registo["situacao"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
