using Sistematico.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistematico.poco
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set; }
        public Marcas Marca { get; set; }
        public Modelos Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
