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
        TextBox textBox4;

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
            Controls.Add(startBtn);

            listView = new ListView();
            listView.Size = new Size(350,200);
            listView.Location = new Point(50,30);
            Controls.Add(listView);
            
            textBox1 = new TextBox();
            textBox1.Size = new Size(100, 40);
            textBox1.Location = new Point(50,250);
            Controls.Add(textBox1);

            textBox2 = new TextBox();
            textBox2.Size = new Size(100, 40);
            textBox2.Location = new Point(50, 300);
            Controls.Add(textBox2);

            textBox3 = new TextBox();
            textBox3.Size = new Size(100, 40);
            textBox3.Location = new Point(170, 250);
            Controls.Add(textBox3);

            textBox4 = new TextBox();
            textBox4.Size = new Size(100, 40);
            textBox4.Location = new Point(170, 300);
            Controls.Add(textBox4);
        }
    }
}
