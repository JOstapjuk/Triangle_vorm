using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle_vorm
{
    public partial class Form1 : Form
    {
        Button startBtn;
        ListView listView;
        TextBox textBox1;
        TextBox textBox2;
        TextBox textBox3;
        //TextBox textBox4;
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

            //textBox4 = new TextBox();
            //textBox4.Size = new Size(100, 40);
            //textBox4.Location = new Point(170, 300);
            //Controls.Add(textBox4);
        }

        private void Run_button_click(object sender, EventArgs e)
        {
            double a, b, c;
            if (double.TryParse(textBox1.Text, out a) &&
                double.TryParse(textBox2.Text, out b) &&
                double.TryParse(textBox3.Text, out c))
            {
                Triangle triangle = new Triangle(a, b, c);

                triangle.CalculateNurgCos(); 

                listView.Items.Clear();

                listView.Items.Add("Pool a");
                listView.Items.Add("Pool b");
                listView.Items.Add("Pool c");
                listView.Items.Add("Perimeeter");
                listView.Items.Add("Pindala");
                listView.Items.Add("On olemas?");
                listView.Items.Add("Nurk A");
                listView.Items.Add("Nurk B");
                listView.Items.Add("Nurk C");
                listView.Items.Add("Kolmnurga tüüp");

                listView.Items[0].SubItems.Add(triangle.GetSetA.ToString());
                listView.Items[1].SubItems.Add(triangle.GetSetB.ToString());
                listView.Items[2].SubItems.Add(triangle.GetSetC.ToString());

                listView.Items[3].SubItems.Add(triangle.Perimeter().ToString());
                listView.Items[4].SubItems.Add(triangle.Surface().ToString());

                if (triangle.ExistTrtiangle)
                {
                    listView.Items[5].SubItems.Add("On olemas");
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
    }
}
