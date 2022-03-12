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
    public class DALFactura
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALFactura(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblFactura SELECT i.idInstalacao, c.idCliente, "+
                " CONVERT(DATE, DATEADD(MONTH,1,GETDATE()), 104) AS [MM/DD/YYYY], e.IVA, "+
                " (e.quantidade*e.valorUn) + (e.quantidade*e.valorUn*e.IVA/100),'Em Débito' "+
                " FROM tblInstalacao i INNER JOIN tblCliente c" +
                " on i.idCliente = c.idCliente INNER JOIN tblEscalao e on i.idEscalao = e.idEscalao";
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // altera os dados
        public void Alterar(ModeloFactura modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblFactura SET estado = (@estado) WHERE idFactura = @codigo;";
            cmd.Parameters.AddWithValue("@estado", modelo.Estado);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdFactura);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblFactura WHERE idFactura = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // pesquisa na tabela
        public DataTable Localizar(int valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT idInstalacao, IVA, valorTotal, estado FROM tblFactura" +
                " WHERE idFactura = '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable LocalizarFactPag(int valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT top 6 data, valorTotal, estado, idFactura, idCliente" +
                " FROM tblFactura WHERE idCliente = '" + valor + "'"+
                " and estado = 'Em Débito' order by data desc", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloFactura CarregaModeloFactura(int codigo)
        {
            ModeloFactura modelo = new ModeloFactura();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "SELECT top 6 data, valorTotal, idFactura, idCliente, IVA" +
                " FROM tblFactura WHERE idFactura = @codigo and estado = 'Em Débito' order by data desc";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdFactura = Convert.ToInt32(registo["idFactura"]);
                modelo.IdCliente = Convert.ToInt32(registo["idCliente"]);
                modelo.Data = Convert.ToDateTime(registo["data"]);
                modelo.IVA = Convert.ToDouble(registo["IVA"]);
                modelo.ValorTot = Convert.ToDouble(registo["valorTotal"]);                
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
