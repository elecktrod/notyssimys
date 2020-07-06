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
    public class Tour : Offer
    {
        public static readonly string type = "tour";

        private readonly string name_url = "url";
        private readonly string name_price = "price";
        private readonly string name_currencyId = "currencyId";
        private readonly string name_categoryId = "categoryId";
        private readonly string name_picture = "picture";
        private readonly string name_delivery = "delivery";
        private readonly string name_localDeliveryCost = "local_delivery_cost";
        private readonly string name_worldRegion = "worldRegion";
        private readonly string name_country = "country";
        private readonly string name_region = "region";
        private readonly string name_days = "days";
        private readonly string name_dataTour = "dataTour";
        private readonly string name_name = "name";
        private readonly string name_hotelStars = "hotel_stars";
        private readonly string name_room = "room";
        private readonly string name_meal = "meal";
        private readonly string name_included = "included";
        private readonly string name_transport = "transport";
        private readonly string name_description = "description";

        private readonly string name_InsertTour = "sp_InsertTour";

        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool Delivery { get; set; }
        public int LocalDeliveryCost { get; set; }
        public string WorldRegion { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int Days { get; set; }
        public string DataTourFrom { get; set; }
        public string DataTourTo { get; set; }
        public string Name { get; set; }
        public string HotelStars { get; set; }
        public string Room { get; set; }
        public string Meal { get; set; }
        public string Included { get; set; }
        public string Transport { get; set; }
        public string Description { get; set; }

        public Tour(XmlNode node)
        {
            Id = int.Parse(node.Attributes[name_id].InnerText);
            Type = node.Attributes[name_type].InnerText;
            Bid = int.Parse(node.Attributes[name_bid].InnerText);
            if(node.Attributes[name_cbid] != null)
                Cid = int.Parse(node.Attributes[name_cbid].InnerText);
            Available = Convert.ToBoolean(node.Attributes[name_available].InnerText);

            Url = node[name_url].InnerText;
            Price = int.Parse(node[name_price].InnerText);
            CurrencyId = node[name_currencyId].InnerText;
            CategoryId = int.Parse(node[name_categoryId].InnerText);
            Picture = node[name_picture].InnerText;
            Delivery = Convert.ToBoolean(node[name_delivery].InnerText);
            LocalDeliveryCost = int.Parse(node[name_localDeliveryCost].InnerText);
            WorldRegion = node[name_worldRegion].InnerText;
            Country = node[name_country].InnerText;
            Region = node[name_region].InnerText;
            Days = int.Parse(node[name_days].InnerText);
            XmlNodeList dataList = node.SelectNodes(name_dataTour);
            DataTourFrom = dataList[0].InnerText;
            DataTourTo = dataList[0].InnerText;
            Name = node[name_name].InnerText;
            HotelStars = node[name_hotelStars].InnerText;
            Room = node[name_room].InnerText;
            Meal = node[name_meal].InnerText;
            Included = node[name_included].InnerText;
            Transport = node[name_transport].InnerText;
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
                cmd.Parameters.Add("@" + name_worldRegion, SqlDbType.NVarChar).Value = WorldRegion;
                cmd.Parameters.Add("@" + name_country, SqlDbType.NVarChar).Value = Country;
                cmd.Parameters.Add("@" + name_region, SqlDbType.NVarChar).Value = Region;
                cmd.Parameters.Add("@" + name_days, SqlDbType.Int).Value = Days;
                cmd.Parameters.Add("@" + name_dataTour + "From", SqlDbType.Date).Value = DataTourFrom;
                cmd.Parameters.Add("@" + name_dataTour + "To", SqlDbType.Date).Value = DataTourTo;
                cmd.Parameters.Add("@" + name_name, SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@" + name_hotelStars, SqlDbType.NVarChar).Value = HotelStars;
                cmd.Parameters.Add("@" + name_room, SqlDbType.NVarChar).Value = Room;
                cmd.Parameters.Add("@" + name_meal, SqlDbType.NVarChar).Value = Meal;
                cmd.Parameters.Add("@" + name_included, SqlDbType.NVarChar).Value = Included;
                cmd.Parameters.Add("@" + name_transport, SqlDbType.NVarChar).Value = Transport;
                cmd.Parameters.Add("@" + name_description, SqlDbType.NVarChar).Value = Description;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
