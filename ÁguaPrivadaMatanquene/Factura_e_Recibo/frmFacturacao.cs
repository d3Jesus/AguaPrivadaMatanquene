using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÁguaPrivadaMatanquene.Factura_e_Recibo
{
    public partial class frmFacturacao : Form
    {
        public int factura, cliente;
        public frmFacturacao()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<facturacao_Result> listP = facturacaoBindingSource.DataSource as List<facturacao_Result>;
            if (listP != null)
            {
                using (frmFactura p = new frmFactura(listP, factura, cliente))
                {
                    p.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lista vazia");
            }
        }

        private void frmFacturacao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'matanqueneDataSet.factura' table. You can move, or remove it, as needed.
            this.facturaTableAdapter.Fill(this.matanqueneDataSet.factura);
            
            using (MatanqueneEntities db = new MatanqueneEntities())
            {
                facturacaoBindingSource.DataSource = db.facturacao(cliente).ToList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnImprimir.Enabled = true;
            factura = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
            cliente = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[1].Value);
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
