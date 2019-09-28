using System;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Text;

public class Ciudad
{


    //Metodo para listar los Ciudades 
    public static DataTable ObtenerLista()
    {
        try
        {
            //Recuperar el objeto para consultas a la base de datos
            BaseDatos bd = Conexion.bd;

            //Definir cadena de consulta
            String strSQL = "EXEC spListarCiudades";

            //Retornar el resultado de la consulta
            return bd.Consultar(strSQL);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al listar Ciudades:\n" + ex.Message);
        }
    }
}