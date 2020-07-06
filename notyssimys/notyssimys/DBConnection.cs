using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notyssimys
{
    public static class DBConnection
    {
        static private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\notyssimys\Notyssimys.mdf;Integrated Security=True;Connect Timeout=30";

        static public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
