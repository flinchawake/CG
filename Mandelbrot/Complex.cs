namespace Mandelbrot
{
    class Complex
    {
        public double a; // Действительное число
        public double b; // Мнимая часть

        public Complex(double a, double b) // Конструктор класса
        {
            this.a = a;
            this.b = b;
        }

        // Методы
        public void Square() // Возведение в квадрат
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double Magnitude() // Вычисление модуля
        {
            return Math.Sqrt((a * a) + (b * b)); // Корень из суммы квадратов действительной и мнимой части
        }

        public void Add(Complex c) // Сложение
        {
            a += c.a;
            b += c.b;
        }

    }
}
