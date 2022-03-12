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
    public partial class frmRecibo : Form
    {
        List<DEBITO_Result> list;
        public double iva, tot;
        public string esc;
        public int cli;

        public frmRecibo(int cliente, double iva, string escalao, double total)
        {
            InitializeComponent();
            this.cli = cliente;
            this.iva = iva;
            this.esc = escalao;
            this.tot = total;
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'matanqueneDataSet.DEBITO' table. You can move, or remove it, as needed.
            //this.dEBITOTableAdapter.Fill(this.matanqueneDataSet.DEBITO);
            using (MatanqueneEntities db = new MatanqueneEntities())
            {
                dEBITOBindingSource.DataSource = db.DEBITO(cli).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] r = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("prtCliente", cli.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("prtEscalao", esc.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("prtIVA", iva.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("prtTotal", tot.ToString())
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
    }
}
