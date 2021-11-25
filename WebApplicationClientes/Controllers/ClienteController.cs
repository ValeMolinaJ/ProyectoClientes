using ClassLibraryClientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationClientes.Models;

namespace WebApplicationClientes.Controllers
{
    public class ClienteController : ApiController
    {
        //Método para traer datos.
        [HttpGet]
        [Route("api/v1/clientes")]
        public respuesta listar(string rut="")
        {
            respuesta resp = new respuesta();
            try
            {
                List<clientes> listado = new List<clientes>();
                clienteEntity clienteData = new clienteEntity();
                DataSet data = rut =="" ? clienteData.listadoClientes() : clienteData.listadoClientes(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    clientes item = new clientes();
                    item.rut = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    listado.Add(item);
                }
                //operación correcta
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else
                
                    resp.data = "No se encontro cliente";
                    return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;

            }
        }
        //[HttpGet]
        //[Route("api/v1/clientes")]
        //public List<clientes> listar(string rut)
        //{
        //    List<clientes> listado = new List<clientes>();
        //    clienteEntity clienteData = new clienteEntity();
        //    DataSet data = clienteData.listadoClientes(rut);
        //    for (int i = 0; i < data.Tables[0].Rows.Count; i++)
        //    {
        //        clientes item = new clientes();
        //        item.rut = data.Tables[0].Rows[i].ItemArray[1].ToString();
        //        item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
        //        item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
        //        item.telefono = data.Tables[0].Rows[i].ItemArray[3].ToString();
        //        listado.Add(item);
        //    }
        //    return listado;
        //}

        //Método para insertar datos.
        [HttpPost]
        [Route("api/v1/setcliente")]
        public respuesta guardar(clientes cliente)
        {
            respuesta resp = new respuesta();
            try
            {
            clienteEntity cli = new clienteEntity(cliente.rut, cliente.nombre, cliente.apellido, cliente.telefono);
            int estado = cli.guardar();
            if (estado ==1)
            {
                resp.error = false;
                resp.mensaje ="Cliente ingresado";
                resp.data = cliente;
            }
            else
            {
                resp.error = true;
                resp.mensaje = "No se realiso el ingreso";
                resp.data = null;
            }
            return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        //Método para eliminar datos.
        [HttpDelete]
        [Route("api/v1/deletecliente")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {
                clienteEntity cli = new clienteEntity();
                cli.Rut = rut;
                int estado = cli.eliminar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cliente eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la eliminación";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
}
