using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap sursa;
        Bitmap destinatie;
        private void Form1_Load(object sender, EventArgs e)
        {
            sursa = new Bitmap(@"C:\Users\bianc\Desktop\tomandjerry.jpg");
            pictureBox1.Image = sursa;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Old = sursa.GetPixel(i, j);
                    int t = (Old.R + Old.G + Old.B) / 3;
                    Color New = Color.FromArgb(t, t, t);
                    destinatie.SetPixel(i, j, New);
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 130;

            destinatie = new Bitmap(sursa.Width, sursa.Height);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Old = sursa.GetPixel(i, j);
                    int nr = Old.R - k;
                    if (nr < 0) nr = 0;
                    int ng = Old.G - k;
                    if (ng < 0) ng = 0;
                    int nb = Old.B - k;
                    if (nb < 0) nb = 0;
                    Color New = Color.FromArgb(nr, ng, nb);
                    destinatie.SetPixel(i, j, New);
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 50;
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color Old = sursa.GetPixel(i, j);
                    int nr = Old.R + k;
                    if (nr > 255) nr = 255;
                    int ng = Old.G + k;
                    if (ng > 255) ng = 255;
                    int nb = Old.B + k;
                    if (nb > 255) nb = 255;
                    Color New = Color.FromArgb(nr, ng, nb);
                    destinatie.SetPixel(i, j, New);
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k = 50;
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    int nr, ng, nb;
                    nr = 0;
                    ng = 0;
                    nb = 0;
                    Color Old = sursa.GetPixel(i, j);
                    int t = (Old.R + Old.G + Old.B )/3;
                    if (t < 127)
                    {
                       
                        nr = Old.R - k;
                        if (nr < 0) nr = 0;
                        ng = Old.G - k;
                        if (ng < 0) ng = 0;
                        nb = Old.B - k;
                        if (nb < 0) nb = 0;
                    }
                    else
                    {
                        nr = Old.R + k;
                        if (nr > 255) nr = 255;
                        ng = Old.G + k;
                        if (ng > 255) ng = 255;
                        nb = Old.B + k;
                        if (nb > 255) nb = 255;
                    }
                    Color New = Color.FromArgb(nr, ng, nb);
                    destinatie.SetPixel(i, j, New);
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int k = 50;
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    int nr, ng, nb;
                    nr = 0;
                    ng = 0;
                    nb = 0;
                    Color Old = sursa.GetPixel(i, j);
                    nr = (Old.R + k) % 255;
                    ng = (Old.G + k) % 255;
                    nb = (Old.B + k) % 255;
                    Color New = Color.FromArgb(nr, ng, nb);
                    destinatie.SetPixel(i, j, New);
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ZOOM
            destinatie = new Bitmap(sursa.Width * 2 - 1, sursa.Height * 2 - 1);
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                { 
                    Color Old = sursa.GetPixel(i, j);
                    
                    destinatie.SetPixel(i * 2, j * 2, Old);
                }
            }
            for (int i = 0; i < destinatie.Width; i+=2)
            {
                for (int j = 1; j < destinatie.Height; j+=2)
                {
                    Color t1 = destinatie.GetPixel(i, j - 1);
                    Color t2 = destinatie.GetPixel(i, j + 1);
                    int r = (t1.R + t2.R) / 2;
                    int g = (t1.G + t2.G) / 2;
                    int b = (t1.B + t2.B) / 2;
                    destinatie.SetPixel(i, j, Color.FromArgb(r,g,b));
                }
            }
            for (int i = 1; i < destinatie.Width; i+=2)
            {
                for (int j = 0; j < destinatie.Height; j++)
                {
                    Color t1 = destinatie.GetPixel(i - 1, j);
                    Color t2 = destinatie.GetPixel(i + 1, j);
                    int r = (t1.R + t2.R) / 2;
                    int g = (t1.G + t2.G) / 2;
                    int b = (t1.B + t2.B) / 2;
                    destinatie.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Image = destinatie;
        }
    }
}
