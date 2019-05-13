using System;
using System.Data.SqlClient;

namespace ConsoleApp2.dbconexion
{
    public static class conexion
    {
        public static bool ConsultaAdoNet()
        {
            using (SqlConnection sqlConn = new SqlConnection("Data Source = SQL_core02_des; Initial Catalog = NET_PRU; Persist Security Info = True; User ID = usr_core; Password = AO.2016"))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("select count(1) from RUT_cliente", sqlConn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
            return true;
        }
    }
}