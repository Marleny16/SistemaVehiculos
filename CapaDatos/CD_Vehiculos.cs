using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class CD_Vehiculos
    {
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtdMostrarVehiculos()
        {
            string QryMostrarVehiculos = "usp_vehiculos_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarVehiculos, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarVehiculos = new DataTable();
            adapter.Fill(dtMostrarVehiculos);
            db_conexion.MtdCerrarConexion();
            return dtMostrarVehiculos;
        }

        public void MtdAgregarVehiculos(string Marca, string Modelo, string Año, string Precio, string Estado)
        {
            string Usp_crear = "usp_vehiculos_crear";
            SqlCommand cmd_InsertarVehiculos = new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarVehiculos.CommandType = CommandType.StoredProcedure;
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Marca", Marca);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Año", Año);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Precio", Precio);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarVehiculos.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizarVehiculos(int VehiculoID, string Marca, string Modelo, string Año, string Precio, string Estado)

        {
            string usp_actualizar = "usp_vehiculos_editar";
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@VehiculoID", VehiculoID);
            cmdUspActualizar.Parameters.AddWithValue("@Marca", Marca);
            cmdUspActualizar.Parameters.AddWithValue("@Modelo", Modelo);
            cmdUspActualizar.Parameters.AddWithValue("@Año", Año);
            cmdUspActualizar.Parameters.AddWithValue("@Precio", Precio);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }


        public void MtdEliminarVehiculos(int VehiculoID)
        {
            string usp_eliminar = "usp_vehiculos_eliminar";
             SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
             cmdUspEliminar.CommandType = CommandType.StoredProcedure;
             cmdUspEliminar.Parameters.AddWithValue("@VehiculoID", VehiculoID);

             cmdUspEliminar.ExecuteNonQuery();

             db_conexion.MtdCerrarConexion();

            /*int vCantidadRegistrosEliminados = 0;

            string vUspEliminarVehiculos = "usp_vehiculos_eliminar";
            SqlCommand commEliminarVehiculos = new SqlCommand(vUspEliminarVehiculos, db_conexion.MtdAbrirConexion());
            commEliminarVehiculos.CommandType = CommandType.StoredProcedure;

            commEliminarVehiculos.Parameters.AddWithValue("@VehiculoID", VehiculoID);

            vCantidadRegistrosEliminados = commEliminarVehiculos.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;*/
        }



    }
}
