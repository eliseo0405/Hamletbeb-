using Sistematico.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistematico
{
    public partial class FrmMdi : Form
    {
        List<Producto> productos;
        public FrmMdi()
        {
            InitializeComponent();
            productos = new List<Producto>();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatalogo frmCatalogo = new FrmCatalogo();
            frmCatalogo.Productos = productos;
            frmCatalogo.MdiParent = this;
            frmCatalogo.Show();
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmView frmView = new FrmView();
            frmView.Productos = productos;
            frmView.MdiParent = this;
            frmView.Show();
        }
    }
}
