using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using HtmlAgilityPack;

namespace IP_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void XmlReaderIP(string ipQuery)
        {
            XmlTextReader reader = new XmlTextReader("http://ip-api.com/xml/" + ipQuery);
            string lon, lat = "0";
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "status")
                    {
                        reader.Read();
                        txStatus.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "country")
                    {
                        reader.Read();
                        txCountry.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "countryCode")
                    {
                        reader.Read();
                        txCountryCode.Text = reader.Value.ToString();
                        picCountryFlag.ImageLocation = "https://countryflagsapi.com/png/" + reader.Value.ToString();
                    }
                    if (reader.Name == "region")
                    {
                        reader.Read();
                        txRegion.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "city")
                    {
                        reader.Read();
                        txCity.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "lat")
                    {
                        reader.Read();
                        txLat.Text = reader.Value.ToString();
                        lat = reader.Value.ToString();
                    }
                    if (reader.Name == "lon")
                    {
                        reader.Read();
                        txLon.Text = reader.Value.ToString();
                        lon = reader.Value.ToString();
                        picMap.ImageLocation = "https://cache.ip-api.com/" + lon + "," + lat + ",10";
                    }
                    if (reader.Name == "org")
                    {
                        reader.Read();
                        txOrg.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "as")
                    {
                        reader.Read();
                        txAs.Text = reader.Value.ToString();
                    }
                    if (reader.Name == "query")
                    {
                        reader.Read();
                        txQuery.Text = reader.Value.ToString();
                    }
                }
            }
            reader.Close();
        }
        private void btnBilgiler_Click(object sender, EventArgs e)
        {
            XmlReaderIP(txİpQuery.Text);
        }

        private void picMap_MouseEnter(object sender, EventArgs e)
        {
            picMap.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void picMap_MouseLeave(object sender, EventArgs e)
        {
            picMap.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnMyIp_Click(object sender, EventArgs e)
        {
            XmlReaderIP("");
            txİpQuery.Text = txQuery.Text;
        }
    }
}
