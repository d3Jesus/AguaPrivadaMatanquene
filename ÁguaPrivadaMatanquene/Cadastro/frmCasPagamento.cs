using ÁguaPrivadaMatanquene.DAL;
using ÁguaPrivadaMatanquene.Factura_e_Recibo;
using ÁguaPrivadaMatanquene.Modelos;
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

namespace ÁguaPrivadaMatanquene.Cadastro
{
    public partial class frmCasPagamento : Form
    {
        public string operacao, escalao;
        public int id, factura, cliente;
        public double iva, total;

        DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);

        public frmCasPagamento()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.operacao = "adicionar";
            btnAdd.Enabled = false;
            btnGuardar.Enabled = true;
            txtCod.Enabled = true;
            cboFormasPag.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DALFactura DALobj = new DALFactura(cx);
            string fact = txtCod.Text;
            if (fact.Equals(""))
            {
                MessageBox.Show("Número da Factura Necessária...");
                txtCod.Focus();
                return;
            }
            else
            {
                ModeloFactura m = DALobj.CarregaModeloFactura(Convert.ToInt32(fact));
                dgvDados.DataSource = DALobj.LocalizarFactPag(m.IdCliente);
                dgvDados.Columns[0].HeaderText = "Mês/Ano";
                dgvDados.Columns[0].Width = 200;
                dgvDados.Columns[1].HeaderText = "Valor";
                dgvDados.Columns[1].Width = 200;
                dgvDados.Columns[2].HeaderText = "Estado";
                dgvDados.Columns[2].Width = 200;
                dgvDados.Columns[3].HeaderText = "Factura";
                dgvDados.Columns[3].Width = 200;
                dgvDados.Columns[4].HeaderText = "Cliente";
                dgvDados.Columns[4].Width = 200;
                dgvDados.Columns[3].Visible = false;
                dgvDados.Columns[4].Visible = false;

                // multa
                DateTime dt = DateTime.Now; // data actual do sistema
                DateTime data = Convert.ToDateTime(dgvDados.Rows[0].Cells[0].Value); // data da factura
                double multa = Convert.ToDouble(dgvDados.Rows[0].Cells[1].Value); // valor a pagar

                // data.Month --> mes da factura
                // dt.Month --> mes do sistema
                if (data.Month < dt.Month)
                {
                    if (dt.Day > 10)
                    {
                        multa = (multa * 10 / 100); // 10% do valor a pagar
                    }
                    else
                    {
                        multa = 0;
                    } 
                }
                txtMulta.Text = multa.ToString();

                double valor = 0;
                valor = multa + Convert.ToDouble(dgvDados.Rows[0].Cells[1].Value);

                if (dgvDados.RowCount == 0)
                {
                    MessageBox.Show("Nenhum pagamento em falta para esse cliente!");
                }

                txtIva.Text = m.IVA.ToString();

                txtTotal.Text = valor.ToString();
                txtAPagar.Text = m.ValorTot.ToString();
                DALCliente dlc = new DALCliente(cx);
                ModeloFactura f = DALobj.CarregaModeloFactura(Convert.ToInt32(fact));
                string nome = dlc.VerificaCliente(f.IdCliente);
                txtCliente.Text = nome;
                cliente = f.IdCliente;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DALPagamento DALobj = new DALPagamento(cx);
            DALRecibo DALobjr = new DALRecibo(cx);
            DALEscalao DALobje = new DALEscalao(cx);
            // insere e altera
            try
            {
                factura = Convert.ToInt32(txtCod.Text);
                iva = Convert.ToDouble(txtIva.Text);
                escalao = DALobje.NomeEscalao(factura);
                total = Convert.ToDouble(txtTotal.Text);
                // insere na tabela dos recibos
                ModeloRecibo r = new ModeloRecibo();
                r.NrFactura = factura;
                r.IVA = Convert.ToDouble(txtIva.Text);
                r.Data = DateTime.Now;
                r.ValorPag = Convert.ToDouble(txtTotal.Text);
                DALobjr.Incluir(r);

                // insere na tabela dos pagamentos
                ModeloPagamento mdC = new ModeloPagamento();
                mdC.IdFactura = factura;
                mdC.IdRecibo = Convert.ToInt32(r.IdRecibo);
                mdC.DataPag = DateTime.Now;
                mdC.TipoPag = cboFormasPag.Text;
                if(cboFormasPag.Text.Equals("Cheque"))
                {
                    mdC.ChequeNr = Convert.ToInt32(txtNrCheque.Text);
                }
                else
                {
                    mdC.ChequeNr = 0;
                }
                mdC.ValorTotal = Convert.ToDouble(txtTotal.Text);
                DALobj.Incluir(mdC);

                // alterar estado da factura
                DALFactura DALf = new DALFactura(cx);
                ModeloFactura mdf = new ModeloFactura();
                mdf.IdFactura = factura;
                mdf.Estado = "Liquidada";
                DALf.Alterar(mdf);

                MessageBox.Show("Pagamento efetuado com sucesso. Código nº " + mdC.IdPagamento.ToString());
                // pega o codigo do cliente
                this.id = Convert.ToInt32(mdC.IdPagamento);
                btnCancelar_Click(sender, e);
                
                // RECIBO
                using (frmRecibo p = new frmRecibo(cliente, iva, escalao, total))
                {
                    p.ShowDialog();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // limpa
            txtCliente.ResetText();
            txtCod.ResetText();
            txtAPagar.ResetText();
            txtIva.ResetText();
            txtMulta.ResetText();
            txtNrCheque.ResetText();
            txtTotal.ResetText();
            cboFormasPag.ResetText();
            dgvDados.ResetText();

            // desabilitar
            txtNrCheque.Enabled = false;
            txtCod.Enabled = false;
            cboFormasPag.Enabled = false;
            btnGuardar.Enabled = false;

            //habilitar
            btnAdd.Enabled = true;
            btnPesquisar.Enabled = true;
        }

        private void cboFormasPag_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboFormasPag.Text.Equals("Cheque"))
            {
                txtNrCheque.Enabled = true;
            }
            else
            {
                txtNrCheque.Enabled = false;
            }
        }

        private void frmCasPagamento_Load(object sender, EventArgs e)
        {
            cboFormasPag.Text = "Numerário";
        }

        // caso queira pagar somente para um mes
        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // valor total
            //double valor = 0;
            //valor = Convert.ToDouble(dgvDados.Rows[e.RowIndex].Cells[1].Value);
            //valor = valor + Convert.ToDouble(txtMulta.Text);
            //txtTotal.Text = valor.ToString();
            //// factura
            //factura = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[3].Value);
            //MessageBox.Show(factura.ToString());
        }
    }
}
