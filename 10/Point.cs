using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Point
    {
        // Поля для координат
        public int x, y;
        // Конструктор для создания экземпляра класса с нулевыми координатами
        public Point()
        {
            x = 0;
            y = 0;
        }
        /* Конструктор для создания экземпляра класса с заданными координатами
         * (this используется для ссылки на поля класса)*/
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // Метод для вывода на экран координат точки
        public void Show()
        {
            Console.WriteLine($"Координаты точки: ({x}, {y})");
        }
        // Метод для вычисления расстояния от начала координат до точки
        public double Distance()
        {
            return Math.Sqrt(x * x + y * y);
        }
        // Метод, позволяющий переместить точку плоскости на вектор 
        public void Transition(int a, int b)
        {
            x += a;
            y += b;
        }
        // Свойства, позволяющие получить и установить координаты точек x, y
        public int X
        {
            get { return x; }
            set { x = value;}
        }
        public int Y
        {
            get { return y; } 
            set { y = value;}
        }
        // Свойства, реализующие умножение координат точки на скаляр
        public int ScalarX
        {
            set { x *= value; }
        }
        public int ScalarY
        {
            set { y *= value; }
        }
        // Индексатор для обращения к полям x, y
        public int this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return x;
                }
      
                if (i == 1)
                {
                    return y;   
                }
	          throw new Exception("Error");
            }
            set
            {
                if (i == 0)
                {
                    x = value;
                }
                else
                {
                    if (i == 1)
                    {
                        y = value;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
        }
        // Перегруженные унарные операции, увеличивающие значения полей x, y на 1
      public static Point operator ++(Point obj)
        {
            obj.x += 1;
            obj.y += 1;
            return obj;
        }
      public static Point operator --(Point obj)
        {
            obj.x -= 1;
            obj.y -= 1;
            return obj;
        }
        // Перегруженные логические операции для проверки совпадения значений полей x и y
        public static bool operator true(Point obj)
        {
            if (obj.x == obj.y)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Point obj)
        {
            if (obj.x != obj.y)
            {
                return false;
            }
            return true;
        }
        // Перегруженная бинарная операция для добавления скаляра к значениям x и y 
        public static Point operator +(Point obj, int scalar)
        {
            obj.x += scalar;
            obj.y += scalar;
            return obj;
        }
    }
    class Program
    {
        static void Main()
        {
            Point p = new Point(10,12);
            p.Show();
            Console.WriteLine($"Расстояние от начала координат до точки = {p.Distance()}");
            p.Transition(1,3);
            Console.WriteLine("Переместили точку плоскости на вектор");
            p.Show();
            Console.WriteLine("Вернем значения координат с помощью свойств для установления координат");
            p.X = 10;
            p.Y = 12;
            Console.WriteLine("И выведем на экран с помощью свойств для получения координат");
            Console.WriteLine($"Исходные координаты - ({p.X},{p.Y})");
            p.ScalarX = 2;
            p.ScalarY = 2;
            Console.WriteLine($"Умножаем координаты на заданный скаляр и выводим с помощью индексатора значения x и y - ({p[0]},{p[1]})");
            Console.WriteLine("Увеличение координат на +1 с помощью унарной операции:");
            ++p;
            p.Show();
            Console.WriteLine("Уменьшение координат на -1 с помощью унарной операции:");      
            --p;
            p.Show();
            Console.WriteLine("Проверка совпадения значений x и y:\n{0}",p.x == p.y);
            Console.WriteLine("Добавляем скаляр к значениям через x и y через бинарную операцию:");
            p = p + 5;
            p.Show();
        }
    }
}
