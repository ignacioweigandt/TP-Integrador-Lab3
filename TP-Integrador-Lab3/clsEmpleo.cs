using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace TP_Integrador_Lab3
{
    internal class clsEmpleo
    {
        string rutaArchivo;
        string cadenaConexion;

        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectoBD;


        public string estadoConexion;

        public clsEmpleo()
        {
            rutaArchivo = "EMPLEO.accdb";
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
            estadoConexion = "CERRADO";

            ConectarBD();
        }

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
                estadoConexion = "ABIERTO";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }

        public void CargarEmpleados(TreeView TvEmpleados)
        {
            string query = "SELECT CODIGO, NOMBRE, APELLIDO, DIRECCION, CIUDAD, TELEFONO, FECHA_NAC FROM DATOS_PERSONALES";
            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un nodo para cada fila
                            TreeNode nodo = new TreeNode(reader["NOMBRE"].ToString() + " " + reader["APELLIDO"].ToString());

                            // Agregar subnodos si es necesario
                            nodo.Nodes.Add("Código: " + reader["CODIGO"].ToString());
                            nodo.Nodes.Add("Dirección: " + reader["DIRECCION"].ToString());
                            // Agregar más nodos según tus necesidades

                            // Agregar el nodo al TreeView
                            TvEmpleados.Nodes.Add(nodo);
                        }
                    }
                }
            }
        }
    
    }
}
