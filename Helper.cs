using System.Configuration;

namespace FTPDescargaArchivos
{
    public static class Helper
    {
        /// <summary>
        /// Regresa la conexion a base de datos
        /// </summary>
        /// <returns></returns>
        public static string Connection()
        {
            return ConfigurationManager.ConnectionStrings["WSFConnectionString"].ToString();
        }
    }
}
