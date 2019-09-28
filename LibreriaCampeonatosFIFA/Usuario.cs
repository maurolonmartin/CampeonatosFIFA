using System;
using System.Data;

public class Usuario
{

    public static String ValidarAcceso(String u, String c)
    {
        String r = "";
        if (Conexion.Establecer())
        {
            String strSQL = "EXEC spValidarAcceso '"+u+"', '"+c+"'";
            DataTable tbl=Conexion.bd.Consultar(strSQL);
            //Si la consulta devuelve registros, el acceso es válido
            if (tbl != null && tbl.Rows.Count > 0)
            {
                r = tbl.Rows[0]["Nombre"].ToString();
            }
        }

        return r;
    }

}

