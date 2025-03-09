using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Vehiculos
    {

            CD_Conexion db_conexion = new CD_Conexion();

            public DataTable MtMostrar()
            {
                string QryMostrar = "usp_vehiculos_select";
                SqlDataAdapter adapter = new SqlDataAdapter(QryMostrar, db_conexion.MtdAbrirConexion());
                DataTable dtMostrar = new DataTable();
                adapter.Fill(dtMostrar);
                db_conexion.MtdCerrarConexion();
                return dtMostrar;
            }

            public void MtInsertar(string marca, string modelo, int año, decimal precio, string estado)
            {

                string usp_Insertar = "usp_vehiculos_insertar";
                SqlCommand cmd_Query = new SqlCommand(usp_Insertar, db_conexion.MtdAbrirConexion());

                cmd_Query.CommandType = CommandType.StoredProcedure;
                cmd_Query.Parameters.AddWithValue("@Marca", marca);
                cmd_Query.Parameters.AddWithValue("@Modelo", modelo);
                cmd_Query.Parameters.AddWithValue("@Año", año);
                cmd_Query.Parameters.AddWithValue("@Precio", precio);
                cmd_Query.Parameters.AddWithValue("@Estado", estado);

                cmd_Query.ExecuteNonQuery();

                db_conexion.MtdCerrarConexion();

            }

            public void MtUpdate(int vehiculoId, string marca, string modelo, int año, decimal precio, string estado)
            {

                string usp_Insertar = "usp_vehiculos_update";
                SqlCommand cmd_Query = new SqlCommand(usp_Insertar, db_conexion.MtdAbrirConexion());

                cmd_Query.CommandType = CommandType.StoredProcedure;
                cmd_Query.Parameters.AddWithValue("@Marca", marca);
                cmd_Query.Parameters.AddWithValue("@Modelo", modelo);
                cmd_Query.Parameters.AddWithValue("@Año", año);
                cmd_Query.Parameters.AddWithValue("@Precio", precio);
                cmd_Query.Parameters.AddWithValue("@Estado", estado);
                cmd_Query.Parameters.AddWithValue("@VehiculoID", vehiculoId);

                cmd_Query.ExecuteNonQuery();

                db_conexion.MtdCerrarConexion();

            }

            public void MtDelete(int vehiculosID)
            {
                string usp_Insertar = "usp_vehiculos_delete";
                SqlCommand cmd_Query = new SqlCommand(usp_Insertar, db_conexion.MtdAbrirConexion());

                cmd_Query.CommandType = CommandType.StoredProcedure;
                cmd_Query.Parameters.AddWithValue("@VehiculoID", vehiculosID);
                cmd_Query.ExecuteNonQuery();

                db_conexion.MtdCerrarConexion();

            }

        }
    }
