using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace notyssimys.Models
{
    public abstract class Offer
    {
        public static readonly string name_id = "id";
        public static readonly string name_type = "type";
        public static readonly string name_bid = "bid";
        public static readonly string name_cbid = "cbid";
        public static readonly string name_available = "available";

        private readonly string name_InsertOffer = "sp_InsertOffer";

        public int Id { get; set; }
        public string Type { get; set; }
        public int Bid { get; set; }
        public int Cid { get; set; }
        public bool Available { get; set; }

        public virtual void InsertToDb()
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(name_InsertOffer, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + name_id, SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@"+ name_type, SqlDbType.NVarChar).Value = Type;
                cmd.Parameters.Add("@" + name_bid, SqlDbType.Int).Value = Bid;
                cmd.Parameters.Add("@" + name_cbid, SqlDbType.Int).Value = Cid;
                cmd.Parameters.Add("@" + name_available, SqlDbType.Bit).Value = Available;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
