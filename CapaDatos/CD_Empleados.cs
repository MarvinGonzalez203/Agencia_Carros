using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Empleados
    {
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtdMostrarEmpleados()
        {
            string QryMostrarEmpleados = "usp_empleados_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarEmpleados, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarEmpleados = new DataTable();
            adapter.Fill(dtMostrarEmpleados);
            db_conexion.MtdCerrarConexion();
            return dtMostrarEmpleados;
        }

        public void MtdAgregarEmpleados(string Nombre, String Apellido, String FechaNacimiento, String FechaContratacion, String DepartamentoID, String PuestoTrabajo, String Salario, String Estado)
        {

            string Usp_Crear = "usp_empleados_crear";
            SqlCommand cmd_InsertarEmpleados = new SqlCommand(Usp_Crear, db_conexion.MtdAbrirConexion());

            cmd_InsertarEmpleados.CommandType = CommandType.StoredProcedure;

            cmd_InsertarEmpleados.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@Apellido", Apellido);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@FechaContratacio", FechaContratacion);
            cmd_InsertarEmpleados.Parameters.AddWithValue("DepartamentoID", DepartamentoID);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@PuestoTrabajo", PuestoTrabajo);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@Salario", Salario);
            cmd_InsertarEmpleados.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarEmpleados.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();


        }




    }
}
