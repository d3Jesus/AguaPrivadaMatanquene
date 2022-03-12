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
    public class DALEscalao
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALEscalao(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloEscalao modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblEscalao (especie, quantidade, valorUn, IVA)" +
                " values (@especie, @quantidade, @valorUn, @IVA); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@especie", modelo.Especie);
            cmd.Parameters.AddWithValue("@quantidade", modelo.Quantidade);
            cmd.Parameters.AddWithValue("@valorUn", modelo.ValorUn);
            cmd.Parameters.AddWithValue("@IVA", modelo.IVA);
            conexao.Conectar();
            modelo.IdEscalao = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloEscalao modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblEscalao SET especie = (@especie), quantidade = (@quantidade)," +
                " valorUn = (@valorUn), IVA = (@IVA) WHERE idEscalao = @codigo;";
            cmd.Parameters.AddWithValue("@especie", modelo.Especie);
            cmd.Parameters.AddWithValue("@quantidade", modelo.Quantidade);
            cmd.Parameters.AddWithValue("@valorUn", modelo.ValorUn);
            cmd.Parameters.AddWithValue("@IVA", modelo.IVA);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdEscalao);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblEscalao WHERE idEscalao = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // busca na tabela usando o codigo
        public DataTable LocalizarCod(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idEscalao, especie, quantidade, valorUn, IVA" +
                " FROM tblEscalao WHERE idEscalao LIKE '" + Convert.ToInt32(valor) + "'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // busca na tabela usando o nome
        public DataTable LocalizarNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idEscalao, especie, quantidade, valorUn, IVA" +
                " FROM tblEscalao WHERE especie LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        // verifica a existencia do cliente
        public int VerificaEscalao(string nome)
        {
            int r = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblEscalao WHERE especie = @nome";
            cmd.Parameters.AddWithValue("@nome", nome);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToInt32(registo["idEscalao"]);
            }
            conexao.Desconectar();
            return r;
        }

        // fornece o nome ou especie do escala
        public string NomeEscalao(int id)
        {
            string r = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select e.especie from tblFactura f inner join tblInstalacao i on"+
                " f.idInstalacao = i.idInstalacao inner join tblEscalao e on i.idEscalao = e.idEscalao where f.idFactura = @id ";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                r = Convert.ToString(registo["especie"]);
            }
            conexao.Desconectar();
            return r;
        }

        public ModeloEscalao CarregaModeloEscalao(int codigo)
        {
            ModeloEscalao modelo = new ModeloEscalao();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblEscalao where idEscalao = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdEscalao = Convert.ToInt32(registo["idEscalao"]);
                modelo.Especie = Convert.ToString(registo["especie"]);
                modelo.Quantidade = Convert.ToInt32(registo["quantidade"]);
                modelo.ValorUn = Convert.ToDouble(registo["valorUn"]);
                modelo.IVA = Convert.ToDouble(registo["IVA"]);
            }
            conexao.Desconectar();
            return modelo;
        }

        // retorna o nome do cliente
        public string CarregaNomeEscalao(int id)
        {
            string nome = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT * FROM tblEscalao WHERE idEscalao = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                nome = Convert.ToString(registo["especie"]);
            }
            conexao.Desconectar();
            return nome;
        }
    }
}
