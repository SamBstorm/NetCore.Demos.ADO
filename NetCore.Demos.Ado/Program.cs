using System;
using System.Data.SqlClient;

namespace NetCore.Demos.Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Démos Disposable
            //using (Disposable d = new Disposable())
            //{
            //    Console.WriteLine($"Le type de d est {d.GetType()}");
            //} 
            #endregion

            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-LGURCCO\BSTORMFORMATION;Database=Asp.Exo.DB;Trusted_Connection=True;"))
            {
                Console.WriteLine(connection.State);
                connection.Open();
                Console.WriteLine(connection.State);
                #region ExecuteReader (Récupération d'informations tabulaires)
                //using (SqlCommand command = new SqlCommand())
                //{
                //    //SqlCommand command = new SqlCommand("SELECT * FROM AspUser", connection);
                //    command.CommandText = "SELECT * FROM AspUser";
                //    command.Connection = connection;
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            Console.WriteLine($"Id : {reader[0]} | LastName {reader["LastName"]}");
                //        }
                //    }
                //} 
                #endregion
                #region ExecuteScalar (Récupération d'une seule et unique information)
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT LastName FROM AspUser WHERE Id = 1";
                    command.Connection = connection;
                    string ln = (string)command.ExecuteScalar();
                    Console.WriteLine(ln);
                } 
                #endregion
                Console.WriteLine(connection.State);
            }
            //Console.WriteLine(connection.State);  //connection étant déclarer dans le using(...){}, celui-ci n'est plus existant.
        }
    }
}
