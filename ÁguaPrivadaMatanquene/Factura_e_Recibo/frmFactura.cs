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
    public partial class frmFactura : Form
    {
        List<facturacao_Result> list;
        public int fact, cli;
        public frmFactura(List<facturacao_Result> list, int factura, int cliente)
        {
            InitializeComponent();
            this.list = list;
            this.fact = factura;
            this.cli = cliente;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            using (MatanqueneEntities db = new MatanqueneEntities())
            {
                facturacaoBindingSource.DataSource = db.facturacao(cli).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] r = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("nrFact", fact.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("cliente", cli.ToString())
                };
                reportViewer1.LocalReport.SetParameters(r);
                reportViewer1.RefreshReport();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
