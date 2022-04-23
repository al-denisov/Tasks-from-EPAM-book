using System;

namespace ConsoleApp2
{
    class Triangle
    {
        // Поля для длины сторон треугольника
        private int a, b, c;
        // Конструктор для создания экземпляра класса с заданными длинами сторон
        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        // Метод для вывода длины сторон треугольника
        public void Show()
        {
            Console.WriteLine($"Длины сторон треугольника:\nA = {a}\nB = {b}\nC = {c}");
        }
        // Метод для вычисления периметра треугольника
        public int CalcPerimeter()
        {
            return a + b + c;
        }
        // Метод для вычисления площади треугольника
        public double CalcArea()
        {
            double p = CalcPerimeter() / 2;
            return Math.Sqrt((p * (p - a) * (p - b) * (p -c)));
        }
        // Свойства для получения и установления длины сторон треугольника
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int C
        {
            get { return c; }
            set { c = value; }
        }
        // Свойство, проверяющее существование треугольника с заданными длинами сторон
        public bool IsExist
        {
            get
            {
                if (a + b > c && b + c > a && c + a > b)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        // Индексатор, позволяющий по индексам обращаться к полям a, b, c
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return a;
                    case 2:
                        return b;
                    case 3:
                        return c;
                    default:
                        throw new Exception("Error");
                }
            }
        }
        // Перегруженные унарные операции, увеличивающие (уменьшающие) значения полей на 1
        public static Triangle operator ++(Triangle obj)
        {
            obj.a++;
            obj.b++;    
            obj.c++;
            return obj;
        }
        public static Triangle operator --(Triangle obj)
        {
            obj.a--;
            obj.b--;
            obj.c--;
            return obj;
        }
        // Перегруженные логические операции, проверяющие существование треугольника с заданными сторонами
        public static bool operator true(Triangle obj)
        {
            return obj.IsExist;
        }
        public static bool operator false(Triangle obj)
        {
            return obj.IsExist;
        }
        // Бинарная операция, умножающая поля a, b, c на скаляр
        public static Triangle operator *(Triangle obj, int scalar)
        {
            obj.a *= scalar;
            obj.b *= scalar;
            obj.c *= scalar;
            return obj;
        }
        class Program
        {
            static void Main()
            {
                Triangle t = new Triangle(3, 4, 5);
                t.Show();
                Console.WriteLine("Периметр данного треугольника = {0}", t.CalcPerimeter());
                Console.WriteLine("Площадь данного треугольника = {0}", t.CalcArea());
                Console.WriteLine("Изменим значения длины сторон с помощью свойств");
                t.A = 2;
                t.B = 2;
                t.C = 3;
                Console.WriteLine($"И выведем новые значения треугольника\nA = {t.A}\nB = {t.B}\nC = {t.C}");
                Console.WriteLine("Проверка существования треугольника с заданными длинами сторон:{0}", t.IsExist);
                Console.WriteLine($"Вывод длин сторон треугольника с помощью индексатора:\nA = {t[1]}\nB = {t[2]}\nC = {t[3]}");
                t++;
                Console.WriteLine("Вывод длин сторон треугольника после унарной операции инкремента");
                t.Show();
                t--;
                Console.WriteLine("Вывод длин сторон треугольника после унарной операции декремента");
                t.Show();
                Console.WriteLine("Умножим стороны треугольника на скаляр с помощью бинарного оператора");
                t *= 5;
                Console.WriteLine($"Результат умножения сторон треугольника на скаляр:\nA = {t.A}\nB = {t.B}\nC = {t.C}");
            }
        }
    }
}
