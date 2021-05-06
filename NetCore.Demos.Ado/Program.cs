using System;
using System.Data;
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
                try
                {
                connection.Open();
                
                    Console.WriteLine(connection.State);
                    #region Ordre DRL
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
                    //using (SqlCommand command = new SqlCommand())
                    //{
                    //    command.CommandText = "SELECT LastName FROM AspUser WHERE Id = 1";
                    //    command.Connection = connection;
                    //    string ln = (string)command.ExecuteScalar();
                    //    Console.WriteLine(ln);
                    //}
                    #endregion
                    #endregion
                    #region Ordre DML (ExecuteNonQuery)
                    #region Insert With Parameter
                    //string newRight = "t');--";

                    //using (SqlCommand command = new SqlCommand("INSERT INTO [UserRight]([Right]) VALUES (@newRight)", connection))
                    //{
                    //    SqlParameter param_newRight = new SqlParameter();
                    //    param_newRight.ParameterName = "newRight";
                    //    param_newRight.Value = newRight;
                    //    command.Parameters.Add(param_newRight);
                    //    int nb_row = command.ExecuteNonQuery();
                    //    if (nb_row > 0)
                    //    {
                    //        Console.WriteLine($"On a insérer {nb_row} ligne(s).");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine($"Aucune ligne n'a été insérer, peut-être y a-t-il une erreur?");
                    //    }
                    //} 
                    #endregion
                    #region Delete With Parameter
                    //using (SqlCommand cmd = connection.CreateCommand())
                    //{
                    //    cmd.CommandText = "DELETE FROM UserRight WHERE [Right] = @param";
                    //    //cmd.Parameters.Add(new SqlParameter("param", "t');--"));
                    //    SqlParameter param = cmd.CreateParameter();
                    //    param.ParameterName = "param";
                    //    param.Value = "t');--";
                    //    cmd.Parameters.Add(param);
                    //    cmd.ExecuteNonQuery();
                    //}


                    #endregion
                    #region Update With Parameter
                    //using (SqlCommand command = connection.CreateCommand())
                    //{
                    //    command.CommandText = "UPDATE [UserRight] SET [Right] = @param WHERE [Right] = @param2";
                    //    SqlParameter param = command.CreateParameter();
                    //    param.ParameterName = "param";
                    //    param.Value = "SA";
                    //    command.Parameters.Add(param);
                    //    command.Parameters.AddWithValue("param2", "SupAdmin");
                    //    command.ExecuteNonQuery();

                    //}
                    #endregion
                    #endregion
                    #region StoredProcedure
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        //command.CommandText = "EXECUTE SP_AspUser_Insert @fn @ln @pwd @mail"; // A NE PAS FAIRE!!!!
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SP_AspUser_Insert";
                        SqlParameter mail = command.CreateParameter();
                        mail.ParameterName = "mail";
                        mail.Value = "sam@fait.rir";
                        command.Parameters.Add(mail);
                        command.Parameters.AddWithValue("password", "Test1234=");
                        command.Parameters.AddWithValue("lastname", "Legrain");
                        command.Parameters.AddWithValue("firstname", "Samuel");
                        command.Parameters.AddWithValue("birthdate", new DateTime(1987,9,27));
                        command.Parameters.AddWithValue("regnational", "87092712345");
                        command.Parameters.AddWithValue("bio", "Formateur BStorm");
                        int new_id = (int)command.ExecuteScalar();
                        Console.WriteLine($"Le nouvel utilisateur a pour ID : {new_id}");
                    }
                    #endregion
                    Console.WriteLine(connection.State);
                }
                catch (SqlException sql_error)
                {
                    //Console.WriteLine(sql_error.Message);
                    throw sql_error;
                }
            }
            //Console.WriteLine(connection.State);  //connection étant déclarer dans le using(...){}, celui-ci n'est plus existant.
        }
    }
}
