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
    public class Audiobook : Offer
    {
        public static readonly string type = "audiobook";

        private readonly string name_url = "url";
        private readonly string name_price = "price";
        private readonly string name_currencyId = "currencyId";
        private readonly string name_categoryId = "categoryId";
        private readonly string name_picture = "picture";
        private readonly string name_author = "author";
        private readonly string name_name = "name";
        private readonly string name_publisher = "publisher";
        private readonly string name_year = "year";
        private readonly string name_ISBN = "ISBN";
        private readonly string name_language = "language";
        private readonly string name_performedBy = "performed_by";
        private readonly string name_performanceType = "performance_type";
        private readonly string name_storage = "storage";
        private readonly string name_format = "format";
        private readonly string name_recordingLength = "recording_length";
        private readonly string name_description = "description";
        private readonly string name_downloadable = "downloadable";

        private readonly string name_InsertVendorModel = "sp_InsertAudioBook";

        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string PerformedBy { get; set; }
        public string PerformanceType { get; set; }
        public string Storage { get; set; }
        public string Format { get; set; }
        public string RecordingLength { get; set; }
        public string Description { get; set; }
        public bool Downloadable { get; set; }

        public Audiobook(XmlNode node)
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
            Author = node[name_author].InnerText;
            Name = node[name_name].InnerText;
            Publisher = node[name_publisher].InnerText;
            Year = int.Parse(node[name_year].InnerText);
            ISBN = node[name_ISBN].InnerText;
            Language = node[name_language].InnerText;
            PerformedBy = node[name_performedBy].InnerText;
            PerformanceType = node[name_performanceType].InnerText;
            Storage = node[name_storage].InnerText;
            Format = node[name_format].InnerText;
            RecordingLength = node[name_recordingLength].InnerText;
            Description = node[name_description].InnerText;
            Downloadable = Convert.ToBoolean(node[name_downloadable].InnerText);
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
                cmd.Parameters.Add("@" + name_author, SqlDbType.NVarChar).Value = Author;
                cmd.Parameters.Add("@" + name_name, SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@" + name_publisher, SqlDbType.NVarChar).Value = Publisher;
                cmd.Parameters.Add("@" + name_year, SqlDbType.Int).Value = Year;
                cmd.Parameters.Add("@" + name_ISBN, SqlDbType.NVarChar).Value = ISBN;
                cmd.Parameters.Add("@" + name_language, SqlDbType.NVarChar).Value = Language;
                cmd.Parameters.Add("@" + name_performedBy, SqlDbType.NVarChar).Value = PerformedBy;
                cmd.Parameters.Add("@" + name_performanceType, SqlDbType.NVarChar).Value = PerformanceType;
                cmd.Parameters.Add("@" + name_storage, SqlDbType.NVarChar).Value = Storage;
                cmd.Parameters.Add("@" + name_format, SqlDbType.NVarChar).Value = Format;
                cmd.Parameters.Add("@" + name_recordingLength, SqlDbType.NVarChar).Value = RecordingLength;
                cmd.Parameters.Add("@" + name_description, SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@" + name_downloadable, SqlDbType.Bit).Value = Downloadable;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
