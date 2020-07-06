using notyssimys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace notyssimys
{
    class Program
    {
        static void Main(string[] args)
        {
            string URLString = @"http://partner.market.yandex.ru/pages/help/YML.xml";
            string xmlStr;
            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(URLString);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            XmlNodeList xnList = xmlDoc.SelectNodes("//shop/offers/offer");
            foreach (XmlNode node in xnList)
            {
                InsertToDB(node);
            }
        }

        static void InsertToDB(XmlNode node)
        {
            string type = node.Attributes[Offer.name_type].Value;
            if (type == VendorModel.type)
            {
                VendorModel vendorModel = new VendorModel(node);
                vendorModel.InsertToDb();
            }
            else if (type == Book.type)
            {
                Book book = new Book(node);
                book.InsertToDb();
            }
            else if (type == Audiobook.type)
            {
                Audiobook audiobook = new Audiobook(node);
                audiobook.InsertToDb();
            }
            else if (type == ArtistTitle.type)
            {
                ArtistTitle artistTitle = new ArtistTitle(node);
                artistTitle.InsertToDb();
            } else
            if (type == Tour.type)
            {
                Tour tour = new Tour(node);
                tour.InsertToDb();
            } else if (type == EventTicket.type)
            {
                EventTicket eventTicket = new EventTicket(node);
                eventTicket.InsertToDb();
            }
        }
    }
}
