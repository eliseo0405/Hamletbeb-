using Sistematico.enums;
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
    public partial class FrmProducto : Form
    {
        
        public List<Producto> Productos { get; set; }
        public Boolean editable = false;
        private int RowIndex = -1;
        public DataGridView dgvP;
        //public FrmCatalogo frmCatalogo = new FrmCatalogo();
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cmbMarca.Items.AddRange(Enum.GetValues(typeof(Marcas))
                                        .Cast<object>()
                                       .ToArray());
            cmbMarca.SelectedIndex = 0;
            cmbModelo.Items.AddRange(Enum.GetValues(typeof(Modelos))
                                        .Cast<object>()
                                       .ToArray());
            cmbModelo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            if (Productos.Count==0)
            {
                id = 1;
            }
            else
            {
                id = Productos.Last<Producto>().Id + 1;
            }
            string nombre = txtNombre.Text;
            int indexMarca = cmbMarca.SelectedIndex;
            Marcas marca = (Marcas)Enum.GetValues(typeof(Marcas)).GetValue(indexMarca);
            int indexModelo = cmbModelo.SelectedIndex;
            Modelos modelo = (Modelos)Enum.GetValues(typeof(Modelos)).GetValue(indexModelo);
            string descripcion = txtDescripcion.Text;
            string imagen = txtImagen.Text;
            ValidateProducto(nombre, out int existencia, out decimal precio, descripcion, imagen);

            Producto p = new Producto {
                Id = id,
                Nombre = nombre,
                Existencia = existencia,
                Marca = marca,
                Modelo= modelo,
                Precio= precio,
                Descripcion= descripcion,
                Imagen=imagen,
            };
            if(editable && RowIndex != -1)
            {
                Producto pr = Productos.ElementAt(RowIndex);
                pr.Nombre = txtNombre.Text;
                pr.Existencia = existencia;
                pr.Marca = marca;
                pr.Modelo = modelo;
                pr.Precio = precio;
                pr.Descripcion = descripcion;
                pr.Imagen = imagen;
                RowIndex = -1;

                MessageBox.Show("Producto actualizado satisfactoriamente");
            }
            else
            {
                Productos.Add(p);
                MessageBox.Show("Producto agregado satisfactoriamente");
            }
            dgvP.DataSource = null;
            dgvP.DataSource = Productos;
            dgvP.Refresh();
            Close();
        }

        private void ValidateProducto(string nombre, out int existencia, out decimal precio, string descripcion,string imagen)
        {
            
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es requerido!");
            }
            if (!int.TryParse(txtExistencia.Text, out int exi))
            {
                throw new ArgumentException($"El valor \"{txtExistencia.Text}\" es invalido!");
            }
            existencia= exi;
            if (!decimal.TryParse(txtPrecio.Text, out decimal p))
            {
                throw new ArgumentException($"El valor \"{txtPrecio.Text}\" es invalido!");
            }
            precio= p;
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descri´pcion es requerida!");
            }
            if (string.IsNullOrWhiteSpace(imagen))
            {
                throw new ArgumentException("La imagen es requerida!");
            }

           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            if (Imagen.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = Imagen.FileName;
            }
        }

        public void LoadProducto(int i)
        {
            Producto p = Productos.ElementAt(i);
            txtNombre.Text = p.Nombre;
            txtExistencia.Text = p.Existencia + "";
            //cmbModelo.SelectedIndex = 0;
            //cmbMarca.SelectedIndex = 0;
            txtPrecio.Text = p.Precio + "";
            txtDescripcion.Text = p.Descripcion;
            txtImagen.Text = p.Imagen;
            RowIndex = i;
        }
    }
}
