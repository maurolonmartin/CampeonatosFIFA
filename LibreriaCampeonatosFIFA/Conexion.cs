using System;
using System.Configuration;

public class Conexion
{
    public static BaseDatos bd;

    public static bool Establecer()
    {
        try
        {
            //Verificar que no existe el objeto para operar base de datos
            if (bd == null)
            {
                //Verificar que haya al menos 1 cadena de conexion
                if (ConfigurationManager.ConnectionStrings.Count > 0)
                {
                    bd = new BaseDatos();
                    bd.CadenaConexion = ConfigurationManager.ConnectionStrings[1].ConnectionString;
                    return bd.Conectar();
                }
                else
                    return false;
            }
            else
                return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al acceder la base de datos\n" + ex.Message);
        }
    }

}
