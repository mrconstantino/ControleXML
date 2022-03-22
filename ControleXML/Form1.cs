using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ControleXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            XmlDocument DadosXml = new XmlDocument();

            DadosXml.LoadXml(rtbXML.Text);

            //if (DadosXml.DocumentElement.OuterXml.Contains("Signature"))
            //{
            //    MessageBox.Show("Signature encontrada.");
            //}

            //string IdEventoEnvio = DadosXml.DocumentElement.Attributes.Item(0).Value;
            //string NomeEventoPrincipal = DadosXml.DocumentElement.Name;
            //string NomeEvento = DadosXml.DocumentElement.FirstChild.Name;

            //string XMLTexto = DadosXml.OuterXml;

            //XmlElement Elementos = DadosXml.DocumentElement;

            string NomeElemento = string.Empty;

            using (var srXml = new StringReader(DadosXml.LastChild.OuterXml))
            using (var readerXml = XmlReader.Create(srXml))
            {
                while (readerXml.Read())
                {
                    if (readerXml.NodeType == XmlNodeType.Element)
                    {
                        NomeElemento = readerXml.Name;
                    }

                    if (readerXml.NodeType == XmlNodeType.Text)
                    {
                        dtgXML.Rows.Add(NomeElemento, readerXml.Value);
                    }
                }
            }
        }

        //private XmlDocument RemovaAtributosDesnecessarios(XmlDocument DadosXML)
        //{
        //    XmlElement XMLElement;

        //    XMLElement = DadosXML.DocumentElement;

        //    XMLElement.RemoveAttribute("xmlns:xsd");
        //    XMLElement.RemoveAttribute("xmlns:xsi");
        //    XMLElement.RemoveAttribute("xmlns:xsi");

        //    DadosXML.LoadXml(XMLElement.OuterXml);

        //    return DadosXML;
        //}
    }
}
