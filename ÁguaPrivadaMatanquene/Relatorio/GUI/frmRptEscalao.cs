using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÁguaPrivadaMatanquene.Relatorio.GUI
{
    public partial class frmRptEscalao : Form
    {
        public frmRptEscalao()
        {
            InitializeComponent();
        }

        private void frmRptEscalao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'matanqueneDataSet.escalaoDetails' table. You can move, or remove it, as needed.
            this.escalaoDetailsTableAdapter.Fill(this.matanqueneDataSet.escalaoDetails);
            using (MatanqueneEntities db = new MatanqueneEntities())
            {
                escalaoDetailsBindingSource.DataSource = db.escalaoDetails().ToList();
                this.reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
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
