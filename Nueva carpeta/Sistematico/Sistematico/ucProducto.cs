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
    public partial class ucProducto : UserControl
    {
        public Producto Producto { get; set; }
        public ucProducto()
        {
            InitializeComponent();
        }

        private void ucProducto_Load(object sender, EventArgs e)
        {
            pbImagenProducto.Image = Image.FromFile(Producto.Imagen);
            lblID.Text = lblID.Text +" "+ Producto.Id;
            lblNombre.Text = lblNombre.Text +" "+Producto.Nombre;
            lblMarca.Text = lblMarca.Text +" "+ Producto.Marca.ToString();
            lblModelo.Text = lblModelo.Text +" "+ Producto.Modelo.ToString();
            lblExistencia.Text = lblExistencia.Text +" "+ Producto.Existencia;
            lblDescripcion.Text = lblDescripcion.Text +" "+ Producto.Descripcion;
        }
    }
}
