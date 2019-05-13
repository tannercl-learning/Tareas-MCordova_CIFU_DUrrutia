using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Rendimiento de busqueda");

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "SQL_core02_des",
                UserID = "usr_core",
                Password = "AO.2016",
                InitialCatalog = "NET_PRU"
            };

            using (var sqlConn = new SqlConnection(builder.ConnectionString))
            {

                try
                {
                    Console.WriteLine("\nBusqueda por select string :");
                    Console.WriteLine("========================\n");
                    sqlConn.Open();
                    var query = new StringBuilder();
                    {
                        //query.Append("DECLARE @antes DATETIME, @despues DATETIME ");
                        //query.Append("SET @antes = GETDATE() ");

                        query.Append("SELECT * FROM [NET_PRU].[dbo].[RUT_cliente] where rut_dv = '007914889-K'");

                        //query.Append("SELECT * ");
                        //query.Append(" ");
                        //query.Append("where rut_dv = '007914889-K'");

                        //query.Append("SET @despues = GETDATE() ");
                        //query.Append("SELECT DATEDIFF(ms,@antes,@despues) ");
                    }
                    string sql = query.ToString();

                    using (var command = new SqlCommand(sql, sqlConn))
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();

                        //var elapsedMs = watch.ElapsedMilliseconds / 1000;
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de inicio de ejecución: {0} milisegundos", elapsedMs);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}", reader.GetString(0));
                            }
                        }
                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000;
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de termino de ejecución: {0} milisegundos", elapsedMs);

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }

                try
                {
                    Console.WriteLine("\nBusqueda por select numero :");
                    Console.WriteLine("=============================\n");

                    //sqlConn.Open();

                    var query = new StringBuilder();
                    {
                        //query.Append("DECLARE @antes DATETIME, @despues DATETIME ");
                        //query.Append("SET @antes = GETDATE() ");
                        query.Append("SELECT * ");
                        query.Append("FROM [NET_PRU].[dbo].[RUT_cliente] ");

                        query.Append("where rut_sdv = 7921178");

                        //query.Append("SET @despues = GETDATE() ");
                        //query.Append("SELECT DATEDIFF(ms,@antes,@despues) ");
                    }
                    string sql = query.ToString();

                    using (var command = new SqlCommand(sql, sqlConn))
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();

                        //var elapsedMs = watch.ElapsedMilliseconds / 1000;
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de inicio de ejecución: {0} milisegundos", elapsedMs);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0}", reader.GetString(0));
                            }
                        }
                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000;
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de termino de ejecución: {0} milisegundos", elapsedMs);

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }

                try
                {
                    Console.WriteLine("\nBusqueda por select string por SP :");
                    Console.WriteLine("=====================================\n");

                    var query = new StringBuilder();

                    //using (SqlConnection sql = new SqlConnection(query.ToString() ))
                    using (var command = new SqlCommand(query.ToString(), sqlConn))
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();

                        //var elapsedMs = watch.ElapsedMilliseconds / 1000;
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de inicio de ejecución: {0} milisegundos", elapsedMs);

                        using (var cmd = new SqlCommand("SP_busca_rut_dv", sqlConn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@s_rut_dv", "007914889-K");

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                Console.WriteLine("{0}", reader.GetString(0));
                            }
                            //sql.Close

                        }

                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000;
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de termino de ejecución: {0} milisegundos", elapsedMs);

                        //cmd.Dispose();
                        sqlConn.Close();
                        //sqlConn.Dispose();

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }

               

                try
                {
                    Console.WriteLine("\nBusqueda por select numerico por SP :");
                    Console.WriteLine("=======================================\n");

                    sqlConn.Open();

                    var query = new StringBuilder();

                    //using (SqlConnection sql = new SqlConnection(query.ToString() ))
                    using (var command = new SqlCommand(query.ToString(), sqlConn))
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();

                        //var elapsedMs = watch.ElapsedMilliseconds / 1000;
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de inicio de ejecución: {0} milisegundos", elapsedMs);

                        using (var cmd = new SqlCommand("SP_busca_rut_sdv", sqlConn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@s_rut_sdv", 7921178);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                Console.WriteLine("{0}", reader.GetInt32(0) );
                            }
                            //sql.Close

                        }

                        watch.Stop();
                        //elapsedMs = watch.ElapsedMilliseconds / 1000;
                        elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Tiempo de termino de ejecución: {0} milisegundos", elapsedMs);

                        sqlConn.Close();

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }


                Console.WriteLine("\nEnter cualquier tecla para finalizar.");
                Console.ReadLine();

            }
        }
    }
}

