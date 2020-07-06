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
    public class EventTicket : Offer
    {
        public static readonly string type = "event-ticket";

        private readonly string name_url = "url";
        private readonly string name_price = "price";
        private readonly string name_currencyId = "currencyId";
        private readonly string name_categoryId = "categoryId";
        private readonly string name_picture = "picture";
        private readonly string name_delivery = "delivery";
        private readonly string name_localDeliveryCost = "local_delivery_cost";
        private readonly string name_name = "name";
        private readonly string name_place = "place";
        private readonly string name_hall = "hall";
        private readonly string name_hallPart = "hall_part";
        private readonly string name_date = "date";
        private readonly string name_isPremiere = "is_premiere";
        private readonly string name_isKids = "is_kids";
        private readonly string name_description = "description";

        private readonly string name_InsertTour = "sp_InsertEventTicket";

        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool Delivery { get; set; }
        public int LocalDeliveryCost { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Hall { get; set; }
        public string HallPart { get; set; }
        public string Date { get; set; }
        public int IsPremiere { get; set; }
        public int IsKids { get; set; }
        public string Description { get; set; }

        public EventTicket(XmlNode node)
        {
            Id = int.Parse(node.Attributes[name_id].InnerText);
            Type = node.Attributes[name_type].InnerText;
            Bid = int.Parse(node.Attributes[name_bid].InnerText);
            if (node.Attributes[name_cbid] != null)
                Cid = int.Parse(node.Attributes[name_cbid].InnerText);
            Available = Convert.ToBoolean(node.Attributes[name_available].InnerText);

            Url = node[name_url].InnerText;
            Price = int.Parse(node[name_price].InnerText);
            CurrencyId = node[name_currencyId].InnerText;
            CategoryId = int.Parse(node[name_categoryId].InnerText);
            Picture = node[name_picture].InnerText;
            Delivery = Convert.ToBoolean(node[name_delivery].InnerText);
            LocalDeliveryCost = int.Parse(node[name_localDeliveryCost].InnerText);
            Name = node[name_name].InnerText;
            Place = node[name_place].InnerText;
            Hall = node[name_hall].InnerText;
            HallPart = node[name_hallPart].InnerText;
            Date = node[name_date].InnerText;
            IsPremiere = int.Parse(node[name_isPremiere].InnerText);
            IsKids = int.Parse(node[name_isKids].InnerText);
            Description = node[name_description].InnerText;
        }

        public override void InsertToDb()
        {
            base.InsertToDb();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(name_InsertTour, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + name_id, SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@" + name_url, SqlDbType.NVarChar).Value = Url;
                cmd.Parameters.Add("@" + name_price, SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@" + name_currencyId, SqlDbType.NVarChar).Value = CurrencyId;
                cmd.Parameters.Add("@" + name_categoryId, SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@" + name_picture, SqlDbType.NVarChar).Value = Picture;
                cmd.Parameters.Add("@" + name_delivery, SqlDbType.Bit).Value = Delivery;
                cmd.Parameters.Add("@" + name_localDeliveryCost, SqlDbType.Int).Value = LocalDeliveryCost;
                cmd.Parameters.Add("@" + name_name, SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@" + name_place, SqlDbType.NVarChar).Value = Place;
                cmd.Parameters.Add("@" + name_hall, SqlDbType.NVarChar).Value = Hall;
                cmd.Parameters.Add("@" + name_hallPart, SqlDbType.NVarChar).Value = HallPart;
                cmd.Parameters.Add("@" + name_date, SqlDbType.DateTime).Value = Date;
                cmd.Parameters.Add("@" + name_isPremiere, SqlDbType.Int).Value = IsPremiere;
                cmd.Parameters.Add("@" + name_isKids, SqlDbType.Int).Value = IsKids;
                cmd.Parameters.Add("@" + name_description, SqlDbType.NVarChar).Value = Description;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
