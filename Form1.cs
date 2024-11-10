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
using System.IO;

namespace Triangle_vorm
{
    public partial class Form1 : Form
    {
        Button startBtn;
        ListView listView;
        TextBox textBox1, textBox2, textBox3;
        Label label1,label2,label3;
        PictureBox pictureBox;

        public Form1()
        {
            Width = 800;
            Height = 400;
            Text = "Töö kolmnurgaga";

            startBtn = new Button();
            startBtn.Text = "Käivita";
            startBtn.Size = new Size(100, 60);
            startBtn.Location = new Point(600,40);
            startBtn.BackColor = Color.CornflowerBlue;
            startBtn.Font = new Font("Arial",15,FontStyle.Bold);
            startBtn.Cursor = Cursors.Hand;
            startBtn.FlatAppearance.BorderColor = Color.Aqua;
            startBtn.FlatAppearance.BorderSize = 4;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Click += Run_button_click;
            startBtn.MouseHover += OpenSecondFormBtn_Click;
            Controls.Add(startBtn);

            listView = new ListView();
            listView.Size = new Size(350,200);
            listView.Location = new Point(50,30);
            listView.View = View.Details;
            listView.Columns.Add("Väli", 175 ,(int)HorizontalAlignment.Left);
            listView.Columns.Add("Väärtus", 175 ,(int)HorizontalAlignment.Left);

            Controls.Add(listView);
            
            label1 = new Label();
            label1.Text = "Külg a";
            label1.Size = new Size(50,17);
            label1.Location = new Point(50, 230);
            Controls.Add(label1);

            textBox1 = new TextBox();
            textBox1.Size = new Size(100, 40);
            textBox1.Location = new Point(50,250);
            Controls.Add(textBox1);

            label2 = new Label();
            label2.Text = "Külg b";
            label2.Size = new Size(50, 17);
            label2.Location = new Point(50, 270);
            Controls.Add(label2);

            textBox2 = new TextBox();
            textBox2.Size = new Size(100, 40);
            textBox2.Location = new Point(50, 290);
            Controls.Add(textBox2);

            label3 = new Label();
            label3.Text = "Külg c";
            label3.Size = new Size(50, 17);
            label3.Location = new Point(50, 310);
            Controls.Add(label3);

            textBox3 = new TextBox();
            textBox3.Size = new Size(100, 40);
            textBox3.Location = new Point(50, 330);
            Controls.Add(textBox3);

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(200, 200); 
            pictureBox.Location = new Point(450, 140); 
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; 
            Controls.Add(pictureBox);

        }

        private void OpenSecondFormBtn_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }
        private void Run_button_click(object sender, EventArgs e)
        {
            double a, b, c;
            bool inputA = double.TryParse(textBox1.Text, out a);
            bool inputB = double.TryParse(textBox2.Text, out b);
            bool inputC = double.TryParse(textBox3.Text, out c);

            // Clear the ListView before adding new items
            listView.Items.Clear();

            listView.Items.Add("Külg a");
            listView.Items.Add("Külg b");
            listView.Items.Add("Külg c");
            listView.Items.Add("Perimeeter");
            listView.Items.Add("Pindala");
            listView.Items.Add("On olemas?");
            listView.Items.Add("Nurk A");
            listView.Items.Add("Nurk B");
            listView.Items.Add("Nurk C");
            listView.Items.Add("Kolmnurga tüüp");

            if (inputA && inputB && inputC)
            {
                if (a <= 0)
                {
                    MessageBox.Show("Külg a peab olema positiivne väärtus.");
                    return;
                }

                if (b <= 0)
                {
                    MessageBox.Show("Külg b peab olema positiivne väärtus.");
                    return;
                }

                if (c <= 0)
                {
                    MessageBox.Show("Külg c peab olema positiivne väärtus.");
                    return;
                }

                Triangle triangle = new Triangle(a, b, c);

                triangle.CalculateNurgCos();

                listView.Items[0].SubItems.Add(triangle.GetSetA.ToString());
                listView.Items[1].SubItems.Add(triangle.GetSetB.ToString());
                listView.Items[2].SubItems.Add(triangle.GetSetC.ToString());

                listView.Items[3].SubItems.Add(triangle.Perimeter().ToString());
                listView.Items[4].SubItems.Add(triangle.Surface().ToString());

                if (triangle.ExistTrtiangle)
                {
                    listView.Items[5].SubItems.Add("On olemas");
                    SaveTriangleToXml(triangle);
                }
                else
                {
                    listView.Items[5].SubItems.Add("Ei ole olemas");
                }

                listView.Items[6].SubItems.Add(triangle.outputNurgA());
                listView.Items[7].SubItems.Add(triangle.outputNurgB());
                listView.Items[8].SubItems.Add(triangle.outputNurgC());

                listView.Items[9].SubItems.Add(triangle.TriangleType);

                if (triangle.TriangleType.Contains("Võrdkülgne"))
                {
                    pictureBox.Image = Image.FromFile(@"Võrdkülgne.png");
                }
                else if (triangle.TriangleType.Contains("Võrdhaarane"))
                {
                    pictureBox.Image = Image.FromFile(@"Võrdhaarane.png");
                }
                else if (triangle.TriangleType.Contains("Erikülgne"))
                {
                    pictureBox.Image = Image.FromFile(@"Erikülgne.gif");
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Palun sisestage numbrid.");
            }
        }

        private void SaveTriangleToXml(Triangle triangle)
        {
            string filePath = "kolmnurgad.xml";

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

            triangleElement.SetAttribute("KülgA", triangle.GetSetA.ToString());
            triangleElement.SetAttribute("KülgB", triangle.GetSetB.ToString());
            triangleElement.SetAttribute("KülgC", triangle.GetSetC.ToString());
            triangleElement.SetAttribute("Perimeeter", triangle.Perimeter().ToString());
            triangleElement.SetAttribute("Pindala", triangle.Surface().ToString());
            triangleElement.SetAttribute("NurkA", triangle.outputNurgA().ToString());
            triangleElement.SetAttribute("NurkB", triangle.outputNurgB().ToString());
            triangleElement.SetAttribute("NurkC", triangle.outputNurgC().ToString());
            triangleElement.SetAttribute("KolmnurgaTüüp", triangle.TriangleType);

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

        //    writer.WriteAttributeString("KülgA", triangle.GetSetA.ToString());
        //    writer.WriteAttributeString("KülgB", triangle.GetSetB.ToString());
        //    writer.WriteAttributeString("KülgC", triangle.GetSetC.ToString());
        //    writer.WriteAttributeString("Perimeeter", triangle.Perimeter().ToString());
        //    writer.WriteAttributeString("Pindala", triangle.Surface().ToString());
        //    writer.WriteAttributeString("NurkA", triangle.outputNurgA().ToString());
        //    writer.WriteAttributeString("NurkB", triangle.outputNurgB().ToString());
        //    writer.WriteAttributeString("NurkC", triangle.outputNurgC().ToString());
        //    writer.WriteAttributeString("KolmnurgaTüüp", triangle.TriangleType);

        //    writer.WriteEndElement();
        //    writer.WriteEndElement();

        //    writer.Flush();

        //    writer.Close();

        //}
    }
}
