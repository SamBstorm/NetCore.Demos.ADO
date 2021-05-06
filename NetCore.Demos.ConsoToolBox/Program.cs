using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tools.Connections.Database;

namespace NetCore.Demos.ConsoToolBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection(SqlClientFactory.Instance, @"Server=DESKTOP-LGURCCO\BSTORMFORMATION;Database=Asp.Exo.DB;Trusted_Connection=True;");
            Command command = new Command("SP_AspUser_GetAll", true);
            DataTable dt = connection.GetDataTable(command);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["LastName"]} {row["FirstName"]} : {row["Mail"]}");
            }

            command = new Command("SELECT * FROM [UserRight] WHERE Id < @IdMax");
            command.AddParameter("IdMax", 3);
            IEnumerable<UserRight> urs = connection.ExecuteReader(command, convert);
            foreach (UserRight ur in urs)
            {
                Console.WriteLine($"{ur.Id} - {ur.Right}");
            }
        }

        static UserRight convert(IDataRecord reader)
        {
            return new UserRight()
            {
                Id = (int)reader["Id"],
                Right = (string)reader[nameof(UserRight.Right)]
            };
        }
    }
}
