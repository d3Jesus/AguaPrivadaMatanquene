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
    public class DALInstalacao
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALInstalacao(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloInstalacao modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblInstalacao (idCliente, idFuncionario, idEscalao, data, contador, localAbastecimento)" +
                " values (@idCliente, @idFuncionario, @idEscalao, @data, @contador, @localAbastecimento); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@idCliente", modelo.IdCliente);
            cmd.Parameters.AddWithValue("@idFuncionario", modelo.IdFuncionario);
            cmd.Parameters.AddWithValue("@idEscalao", modelo.IdEscalao);
            cmd.Parameters.AddWithValue("@data", modelo.Data);
            cmd.Parameters.AddWithValue("@contador", modelo.Contador);
            cmd.Parameters.AddWithValue("@localAbastecimento", modelo.LocalAbastecimento);
            conexao.Conectar();
            modelo.IdInstalacao = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloInstalacao modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblInstalacao SET idEscalao = (@idEscalao), contador = (@contador) WHERE idInstalacao = @codigo;";
            cmd.Parameters.AddWithValue("@idEscalao", modelo.IdEscalao);
            cmd.Parameters.AddWithValue("@contador", modelo.Contador);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdInstalacao);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblInstalacao WHERE idInstalacao = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // busca na tabela usando o codigo do cliente
        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT i.idInstalacao, c.nome, f.nome, e.especie," +
                " i.contador, i.localAbastecimento from tblInstalacao i inner join tblCliente c" +
                " on i.idCliente = c.idCliente inner join tblEscalao e on i.idEscalao = e.idEscalao" +
                " inner join tblFuncionario f on i.idFuncionario = f.idFuncionario"+
                " WHERE idCliente = '" + Convert.ToInt32(valor) + "'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela usando o nome do cliente
        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT i.idInstalacao, c.nome, f.nome, e.especie," +
                " i.contador, i.localAbastecimento from tblInstalacao i inner join tblCliente c" +
                " on i.idCliente = c.idCliente inner join tblEscalao e on i.idEscalao = e.idEscalao" +
                " inner join tblFuncionario f on i.idFuncionario = f.idFuncionario WHERE c.nome LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela usando o nome do cliente
        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT i.idInstalacao, c.nome, f.nome, e.especie," +
                " i.contador, i.localAbastecimento from tblInstalacao i inner join tblCliente c" +
                " on i.idCliente = c.idCliente inner join tblEscalao e on i.idEscalao = e.idEscalao" +
                " inner join tblFuncionario f on i.idFuncionario = f.idFuncionario", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloInstalacao CarregaModeloInstalacao(int codigo)
        {
            ModeloInstalacao modelo = new ModeloInstalacao();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblInstalacao WHERE idInstalacao = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdInstalacao = Convert.ToInt32(registo["idInstalacao"]);
                modelo.IdCliente = Convert.ToInt32(registo["idCliente"]);
                modelo.IdFuncionario = Convert.ToInt32(registo["idFuncionario"]);
                modelo.IdEscalao = Convert.ToInt32(registo["idEscalao"]);
                modelo.Data = Convert.ToDateTime(registo["data"]);
                modelo.Contador = Convert.ToInt32(registo["contador"]);
                modelo.LocalAbastecimento = Convert.ToString(registo["localAbastecimento"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
