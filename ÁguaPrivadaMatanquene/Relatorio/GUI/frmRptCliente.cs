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
    public partial class frmRptCliente : Form
    {
        public frmRptCliente()
        {
            InitializeComponent();
        }

        private void frmRptCliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'matanqueneDataSet.clienteDetails' table. You can move, or remove it, as needed.
            this.clienteDetailsTableAdapter.Fill(this.matanqueneDataSet.clienteDetails);
            using (MatanqueneEntities db = new MatanqueneEntities())
            {
                clienteDetailsBindingSource.DataSource = db.clienteDetails().ToList();
                this.reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }
    }
}
