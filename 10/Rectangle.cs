using System;

namespace ConsoleApp3
{
    class Rectangle
    {
        // Поля для длины сторон прямоугольника
        private int a, b;
        // Конструктор для создания экземпляра класса с заданными длинами сторон
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        // Метод для вывода длины сторон прямоугольника
        public void Show()
        {
            Console.WriteLine($"Длины сторон прямоугольника:\nA = {a}\nB = {b}");
        }
        // Метод для вычисления периметра прямоугольника
        public int CalcPerimeter()
        {
            return 2 * a + 2 * b;
        }
        // Метод для вычисления площади прямоугольника
        public double CalcArea()
        {
            return a * b;
        }
        // Свойства для получения и установления длины сторон прямоугольника
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
       
        // Свойство, проверяющее является ли прямоугольник квадратом
        public bool IsSquare
        {
            get
            {
                if (a == b)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        // Индексатор, позволяющий по индексам обращаться к полям a, b
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    default:
                        throw new Exception("Error");
                }
            }
        }
        // Перегруженные унарные операции, увеличивающие (уменьшающие) значения полей на 1
        public static Rectangle operator ++(Rectangle obj)
        {
            obj.a++;
            obj.b++;
            return obj;
        }
        public static Rectangle operator --(Rectangle obj)
        {
            obj.a--;
            obj.b--;
            return obj;
        }
        // Перегруженные логические операции, проверяющие является ли прямоугольник квадратом
        public static bool operator true(Rectangle obj)
        {
            return obj.IsSquare;
        }
        public static bool operator false(Rectangle obj)
        {
            return obj.IsSquare;
        }
        // Бинарная операция, умножающая поля a, b на скаляр
        public static Rectangle operator *(Rectangle obj, int scalar)
        {
            obj.a *= scalar;
            obj.b *= scalar;
            return obj;
        }
        class Program
        {
            static void Main()
            {
                Rectangle r = new Rectangle(4,6);
                r.Show();
                Console.WriteLine("Периметр данного прямоугольника = {0}", r.CalcPerimeter());
                Console.WriteLine("Площадь данного прямоугольника = {0}", r.CalcArea());
                Console.WriteLine("Изменим значения длины сторон с помощью свойств");
                r.A = 2;
                r.B = 2;
                Console.WriteLine($"И выведем новые значения прямоугольника\nA = {r.A}\nB = {r.B}");
                Console.WriteLine("Проверяем является ли прямоугольник квадратом:{0}", r.IsSquare);
                Console.WriteLine($"Вывод длин сторон прямоугольника с помощью индексатора:\nA = {r[0]}\nB = {r[1]}");
                r++;
                Console.WriteLine("Вывод длин сторон прямоугольника после унарной операции инкремента");
                r.Show();
                r--;
                Console.WriteLine("Вывод длин сторон прямоугольника после унарной операции декремента");
                r.Show();
                Console.WriteLine("Умножим стороны прямоугольника на скаляр с помощью бинарного оператора");
                r *= 5;
                Console.WriteLine($"Результат умножения сторон прямоугольника на скаляр:\nA = {r.A}\nB = {r.B}");
            }
        }
    }
}
