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
    public partial class FrmView : Form
    {
        public List<Producto> Productos { get; set; }
        private ucProducto ucontrolP;
        public FrmView()
        {
            InitializeComponent();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            if (Productos == null)
            {
                return;
            }
            foreach(Producto pr in Productos)
            {
                ucontrolP = new ucProducto();
                ucontrolP.Producto = pr;
                this.flowLayoutPanel1.Controls.Add(ucontrolP);
            }
        }
    }
}
