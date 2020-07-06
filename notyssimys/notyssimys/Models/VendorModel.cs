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
    public class VendorModel : Offer
    {
        public static readonly string type = "vendor.model";

        private readonly string name_url = "url";
        private readonly string name_price = "price";
        private readonly string name_currencyId = "currencyId";
        private readonly string name_categoryId = "categoryId";
        private readonly string name_picture = "picture";
        private readonly string name_delivery = "delivery";
        private readonly string name_localDeliveryCost = "local_delivery_cost";
        private readonly string name_typePrefix = "typePrefix";
        private readonly string name_vendor = "vendor";
        private readonly string name_vendorCode = "vendorCode";
        private readonly string name_model = "model";
        private readonly string name_description = "description";
        private readonly string name_manufacturerWarranty = "manufacturer_warranty";
        private readonly string name_countryOfOrigin = "country_of_origin";

        private readonly string name_InsertVendorModel = "sp_InsertVendorModel";

        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool Delivery { get; set; }
        public int LocalDeliveryCost { get; set; }
        public string TypePrefix { get; set; }
        public string Vendor { get; set; }
        public string VendorCode { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public bool ManufacturerWarranty { get; set; }
        public string CountryOfOrigin { get; set; }

        public VendorModel(XmlNode node)
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
            TypePrefix = node[name_typePrefix].InnerText;
            Vendor = node[name_vendor].InnerText;
            VendorCode = node[name_vendorCode].InnerText;
            Model = node[name_model].InnerText;
            Description = node[name_description].InnerText;
            ManufacturerWarranty = Convert.ToBoolean(node[name_manufacturerWarranty].InnerText);
            CountryOfOrigin = node[name_countryOfOrigin].InnerText;
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
                cmd.Parameters.Add("@" + name_localDeliveryCost, SqlDbType.Int).Value = LocalDeliveryCost;
                cmd.Parameters.Add("@" + name_typePrefix, SqlDbType.NVarChar).Value = TypePrefix;
                cmd.Parameters.Add("@" + name_vendor, SqlDbType.NVarChar).Value = Vendor;
                cmd.Parameters.Add("@" + name_vendorCode, SqlDbType.NVarChar).Value = VendorCode;
                cmd.Parameters.Add("@" + name_model, SqlDbType.NVarChar).Value = Model;
                cmd.Parameters.Add("@" + name_description, SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@" + name_manufacturerWarranty, SqlDbType.Bit).Value = ManufacturerWarranty;
                cmd.Parameters.Add("@" + name_countryOfOrigin, SqlDbType.NVarChar).Value = CountryOfOrigin;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
