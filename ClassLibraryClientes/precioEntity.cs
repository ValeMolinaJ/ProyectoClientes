using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryClientes
{
    public class precioEntity
    {
        private int id;
        private string nombre;
        private int precio;
        Datos data = new Datos();

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Precio { get => precio; set => precio = value; }

        public precioEntity()
        {

        }
        public precioEntity(int id, string nombre, int precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }
        public DataSet listadoPrecios()
        {
            return data.listado("SELECT * FROM PRECIO");
        }

        public int guardar(precioEntity precio)
        {
            return data.ejecutar("INSERT INTO PRECIO(id, nombre, precio) values('" + precio.id + "','" + precio.nombre + "'," +
                "'" + precio.precio + "')");
        }
    }
}
