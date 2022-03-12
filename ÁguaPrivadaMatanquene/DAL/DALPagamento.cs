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
    public class DALPagamento
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloPagamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblPagamento (idFactura, idRecibo, dataPagamento, tipoPagamento, nrCheque, valorTotal)" +
                " values (@idFactura, @idRecibo, @dataPagamento, @tipoPagamento, @nrCheque, @valorTotal); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@idFactura", modelo.IdFactura);
            cmd.Parameters.AddWithValue("@idRecibo", modelo.IdRecibo);
            cmd.Parameters.AddWithValue("@dataPagamento", modelo.DataPag);
            cmd.Parameters.AddWithValue("@tipoPagamento", modelo.TipoPag);
            cmd.Parameters.AddWithValue("@nrCheque", modelo.ChequeNr);
            cmd.Parameters.AddWithValue("@valorTotal", modelo.ValorTotal);
            conexao.Conectar();
            modelo.IdPagamento = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblPagamento WHERE idPagamento = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
    }
}
