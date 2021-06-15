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
    public partial class FrmCatalogo : Form
    {
        public List<Producto> Productos { get; set; }
        public FrmCatalogo()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.Productos = Productos;
            frmProducto.dgvP = dgvCatalogo;
            _ = frmProducto.ShowDialog();


        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCatalogo.Rows.Count == 0)
            {
                return;
            }
            int index = dgvCatalogo.CurrentCell.RowIndex;
           Productos.RemoveAt(index);

            dgvCatalogo.DataSource = null;
            dgvCatalogo.DataSource = Productos;
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
             if ( dgvCatalogo== null)
            {
                return;
            }
            List<Producto> filtro = new List<Producto>();
            string clave = txtFiltrar.Text;
            foreach (Producto p in Productos)
            {
                if ((p.Id + "").ToUpper().Contains(clave) || p.Nombre.ToUpper().Contains(clave) || (p.Existencia + "").ToUpper().Contains(clave) 
                        || (p.Precio + "").ToUpper().Contains(clave)|| p.Descripcion.ToUpper().Contains(clave) || p.Imagen.ToUpper().Contains(clave))
                {
                    filtro.Add(p);
                }
                if (filtro.Count > 0)
                {
                    dgvCatalogo.DataSource = null;
                    dgvCatalogo.DataSource = filtro;
                }
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(dgvCatalogo.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la tabla");
                return;
            }
            if(dgvCatalogo.CurrentCell.RowIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una fila de la tabla");
                return;
            }
            int index = dgvCatalogo.CurrentCell.RowIndex;
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.Productos = Productos;
            frmProducto.dgvP = dgvCatalogo;
            frmProducto.LoadProducto(index);
            frmProducto.editable = true;
            _ = frmProducto.ShowDialog();
        }
    }
}
