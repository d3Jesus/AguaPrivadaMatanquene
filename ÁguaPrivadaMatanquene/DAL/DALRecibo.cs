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
    public class DALRecibo
    {
        private DALConexao conexao; // representa a conexao

        // construtor
        public DALRecibo(DALConexao cx)
        {
            this.conexao = cx;
        }

        // insere na tabela
        public void Incluir(ModeloRecibo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO tblRecibo (nrFatura, IVA, dataPag, valorPago) " +
                "values (@nrFatura, @IVA, @dataPag, @valorPago); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nrFatura", modelo.NrFactura);
            cmd.Parameters.AddWithValue("@IVA", modelo.IVA);
            cmd.Parameters.AddWithValue("@dataPag", modelo.Data);
            cmd.Parameters.AddWithValue("@valorPago", modelo.ValorPag);
            conexao.Conectar();
            modelo.IdRecibo = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        // atualiza o id da fatura
        public void AlterarFatura(ModeloRecibo modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE tblRecibo SET nrFatura = @nrFatura WHERE idlRecibo = @codigo;";
            cmd.Parameters.AddWithValue("@nrFatura", modelo.NrFactura);
            cmd.Parameters.AddWithValue("@codigo", modelo.IdRecibo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // exclui dados
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM tblRecibo WHERE idRecibo = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        // pesquisa na tabela
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT c.idRecibo, c.nome, c.sexo, c.dataNascimento, c.estadoCivil, " +
                "c.tipoDocumento, c.nrDocumento, c.nuit, c.telefone, c.moradaId, m.cidade, m.bairro, m.rua, m.casaNr FROM tblRecibo c," +
                "tblMorada m  WHERE c.moradaId = m.idMorada and nome like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloRecibo CarregaModeloRecibo(int codigo)
        {
            ModeloRecibo modelo = new ModeloRecibo();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tblRecibo where idRecibo = @codigo ";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registo = cmd.ExecuteReader();
            if (registo.HasRows)
            {
                registo.Read();
                modelo.IdRecibo = Convert.ToInt32(registo["idRecibo"]);
                modelo.NrFactura = Convert.ToInt32(registo["nrFatura"]);
                modelo.IVA = Convert.ToInt32(registo["IVA"]);
                modelo.Data = Convert.ToDateTime(registo["dataPag"]);
                modelo.ValorPag = Convert.ToDouble(registo["valorPago"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
