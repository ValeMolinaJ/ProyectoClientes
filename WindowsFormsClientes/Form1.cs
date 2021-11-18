using ClassLibraryClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClientes
{
    public partial class Form1 : Form
    {
        clienteEntity cliente = new clienteEntity();
        precioEntity precio = new precioEntity();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cliente.Rut = txtRut.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            int x = cliente.guardar(cliente);
            if (x == 1)
            {
                MessageBox.Show("Cliente Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en Guardado", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            precio.Id = int.Parse (txtId.Text);
            precio.Nombre = txtNombreP.Text;
            precio.Precio = int.Parse (txtPrecio.Text);
         
            int x = precio.guardar(precio);
            if (x == 1)
            {
                MessageBox.Show("Precio Guardado", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error en Guardado", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
