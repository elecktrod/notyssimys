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
    public class ArtistTitle : Offer
    {
        public static readonly string type = "artist.title";

        private readonly string name_url = "url";
        private readonly string name_price = "price";
        private readonly string name_currencyId = "currencyId";
        private readonly string name_categoryId = "categoryId";
        private readonly string name_picture = "picture";
        private readonly string name_delivery = "delivery";
        private readonly string name_artist = "artist";
        private readonly string name_title = "title";
        private readonly string name_year = "year";
        private readonly string name_media = "media";
        private readonly string name_description = "description";

        private readonly string name_InsertVendorModel = "sp_InsertArtistTitle";

        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool Delivery { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Media { get; set; }
        public string Description { get; set; }

        public ArtistTitle(XmlNode node)
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
            Artist = "";
            if (node.Attributes[name_artist] != null)
                Artist = node[name_artist].InnerText;
            Title = node[name_title].InnerText;
            Year = int.Parse(node[name_year].InnerText);
            Media = node[name_media].InnerText;
            Description = node[name_description].InnerText;
        }

        public override void InsertToDb()
        {
            base.InsertToDb();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(name_InsertVendorModel, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + name_id, SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@" + name_url, SqlDbType.NVarChar).Value = Url;
                cmd.Parameters.Add("@" + name_price, SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@" + name_currencyId, SqlDbType.NVarChar).Value = CurrencyId;
                cmd.Parameters.Add("@" + name_categoryId, SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@" + name_picture, SqlDbType.NVarChar).Value = Picture;
                cmd.Parameters.Add("@" + name_delivery, SqlDbType.Bit).Value = Delivery;
                cmd.Parameters.Add("@" + name_artist, SqlDbType.NVarChar).Value = Artist;
                cmd.Parameters.Add("@" + name_title, SqlDbType.NVarChar).Value = Title;
                cmd.Parameters.Add("@" + name_year, SqlDbType.Int).Value = Year;
                cmd.Parameters.Add("@" + name_media, SqlDbType.NVarChar).Value = Media;
                cmd.Parameters.Add("@" + name_description, SqlDbType.NVarChar).Value = Description;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
