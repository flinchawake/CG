using System.Globalization;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Mandelbrot(double xMin, double xMax, double yMin, double yMax)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Создаем циклы обхода всех пикселей
            for (int x = 0; x < pictureBox1.Width; x++) // По оси X
            {
                for (int y = 0; y < pictureBox1.Height; y++) // По оси Y
                {
                    // Нормализуем координаты x, y
                    double a = (double)(x - (pictureBox1.Width / xMax)) / (double)(pictureBox1.Width / yMax);
                    double b = (double)(y - (pictureBox1.Width / xMin)) / (double)(pictureBox1.Width / yMin);

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break; // Выходим когда точка НЕ принадлежит множеству
                    } while (it < 100); // Выходим когда точка принадлежит множеству
                    bmp.SetPixel(x, y, it < 100 ? Color.FromArgb(it * 2, it, it * 2) : Color.FromArgb(255, 255, 255));
                }
                pictureBox1.Image = bmp;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Построение
        {
            double X0 = Convert.ToDouble(textBox4.Text, CultureInfo.InvariantCulture);
            double XN = Convert.ToDouble(textBox3.Text, CultureInfo.InvariantCulture);
            double Y0 = Convert.ToDouble(textBox2.Text, CultureInfo.InvariantCulture);
            double YN = Convert.ToDouble(textBox1.Text, CultureInfo.InvariantCulture);
            Mandelbrot(X0, XN, Y0, YN);
        }

        private void button2_Click(object sender, EventArgs e) // Вариант
        {
            textBox4.Text = "-2.0";
            textBox3.Text = "0.8";
            textBox2.Text = "-1.0";
            textBox1.Text = "1.0";
        }

        private void button3_Click(object sender, EventArgs e) // Тест
        {
            textBox4.Text = "4.0";
            textBox3.Text = "2.0";
            textBox2.Text = "4.0";
            textBox1.Text = "4.0";
        }
    }
}