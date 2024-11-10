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

namespace Triangle_vorm
{
    public partial class Form2 : Form
    {
        private TextBox sideAInput, heightInput;
        private Button calculateBtn;
        private ListView resultList;
        private Label sideALabel, heightLabel;

        public Form2()
        {
            Width = 400;
            Height = 350;
            Text = "Töö kolmnurgaga kõrgus ja külg";

            sideALabel = new Label();
            sideALabel.Text = "Külg:";
            sideALabel.Location = new Point(20, 20);
            sideALabel.Size = new Size(50, 17);
            Controls.Add(sideALabel);

            sideAInput = new TextBox();
            sideAInput.Location = new Point(80, 20);
            sideAInput.Width = 100;
            Controls.Add(sideAInput);

            heightLabel = new Label();
            heightLabel.Text = "Kõrgus:";
            heightLabel.Location = new Point(20, 60);
            heightLabel.Size = new Size(50, 17);
            Controls.Add(heightLabel);

            heightInput = new TextBox();
            heightInput.Location = new Point(80, 60);
            heightInput.Width = 100;
            Controls.Add(heightInput);

            calculateBtn = new Button();
            calculateBtn.Text = "Arvuta";
            calculateBtn.Location = new Point(80, 100);
            calculateBtn.Width = 100;
            calculateBtn.Click += CalculateBtn_Click;
            Controls.Add(calculateBtn);

            resultList = new ListView();
            resultList.Size = new Size(300, 100);
            resultList.Location = new Point(20, 150);
            resultList.View = View.Details;
            resultList.Columns.Add("Väli", 150);
            resultList.Columns.Add("Väärtus", 150);
            Controls.Add(resultList);
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            double side = 0, height = 0;
            bool inputSide = double.TryParse(sideAInput.Text, out side);
            bool inputHeight = double.TryParse(heightInput.Text, out height);

            resultList.Items.Clear();

            resultList.Items.Add("Külg");
            resultList.Items.Add("Kõrgus");
            resultList.Items.Add("Pindala");


            if (inputSide && inputHeight)
            {
                if (side <= 0)
                {
                    MessageBox.Show("Külg peab olema positiivne väärtus.");
                    return;
                }

                if (height <= 0)
                {
                    MessageBox.Show("Kõrgus peab olema positiivne väärtus.");
                    return;
                }

                Triangle triangle = new Triangle(side, height);

                resultList.Items[0].SubItems.Add(side.ToString());
                resultList.Items[1].SubItems.Add(height.ToString());
                resultList.Items[2].SubItems.Add(triangle.CalculateSurfaceHeight().ToString());

                if (side > 0 && height > 0)
                {
                    SaveTriangleToXml(triangle);
                }
            }
            else
            {
                MessageBox.Show("Palun sisestage külg ja kõrgus");
                return;
            }
        }
        private void SaveTriangleToXml(Triangle triangle)
        {
            string filePath = Path.Combine(Application.StartupPath, "kolmnurgad.xml");

            XmlDocument xmlDoc = new XmlDocument();

            if (!File.Exists(filePath))
            {
                XmlElement root = xmlDoc.CreateElement("Triangles");
                xmlDoc.AppendChild(root);
            }
            else
            {
                try
                {
                    xmlDoc.Load(filePath);
                }
                catch (XmlException)
                {
                    XmlElement root = xmlDoc.CreateElement("Triangles");
                    xmlDoc.AppendChild(root);
                }
            }

            XmlElement triangleElement = xmlDoc.CreateElement("Triangle");

            triangleElement.SetAttribute("Külg", triangle.GetSetA.ToString());
            triangleElement.SetAttribute("Kõrgus", triangle.GetSetH.ToString());
            triangleElement.SetAttribute("Pindala", triangle.CalculateSurfaceHeight().ToString());

            xmlDoc.DocumentElement.PrependChild(triangleElement);

            xmlDoc.Save(filePath);     
        }

        //private void SaveTriangleToXml(Triangle triangle)
        //{
        //    string filePath = "kolmnurgad.xml";

        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.Indent = true;

        //    XmlWriter writer = XmlWriter.Create(filePath, settings);

        //    writer.WriteStartDocument();
        //    writer.WriteStartElement("Triangles");

        //    writer.WriteStartElement("Triangle");

        //    writer.WriteAttributeString("Külg", triangle.GetSetA.ToString());
        //    writer.WriteAttributeString("Kõrgus", triangle.GetSetH.ToString());
        //    writer.WriteAttributeString("Pindala", triangle.CalculateSurfaceHeight().ToString());

        //    writer.WriteEndElement();
        //    writer.WriteEndElement();

        //    writer.Flush();

        //    writer.Close();

        //}
    }
}
