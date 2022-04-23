using System;

namespace ConsoleApp4
{
    class Money
    {
        // Поля для номинала купюры и количества купюр
        private int first, second;
        // Конструктор для создания экземпляра класса с заданными значениями полей
        public Money(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
        // Метод для вывода номинала и количества купюр
        public void Show()
        {
            Console.WriteLine($"Номинал купюры = {first}\nКоличество купюр = {second}");
        }
        // Метод, показывающий хватит ли данных денег на покупку определенного товара
        public string IsEnoughMoney(int n)
        {
            if (n <= first * second)
            return "Enough";
            else 
                return "Not Enough";
        }
        // Метод, определяющий какое количество определенного товара можно купить на имеющиеся деньги
        public int HowManyItemsCanBuy(int n)
        {
            return (first * second) / n;
        }
        // Свойства для получения и установления значений полей
        public int First
        {
            get { return first; }
            set { first = value; }
        }
        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        // Свойство, выполняющее вычисление суммы денег
        public int SumOfMoney
        {
            get
            {
                return first * second;
            }
        }
        // Индексатор, позволяющий по индексам обращаться к полям first, second
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return first;
                    case 1:
                        return second;
                    default:
                        throw new Exception("Error");
                }
            }
        }
        // Перегруженные унарные операции, увеличивающие (уменьшающие) значения полей на 1
        public static Money operator ++(Money obj)
        {
            obj.first++;
            obj.second++;
            return obj;
        }
        public static Money operator --(Money obj)
        {
            obj.first--;
            obj.second--;
            return obj;
        }
       
        // Бинарная операция, увеличивающая поле second на скалярную величину
        public static Money operator +(Money obj, int scalar)
        {
            obj.second += scalar;
            return obj;
        }
        class Program
        {
            static void Main()
            {
                Money m = new Money(200, 5);
                m.Show();
                Console.WriteLine("Хватит ли денег для покупки товара? \n{0}", m.IsEnoughMoney(1000));
                Console.WriteLine("Сколько штук товара можно купить на имеющиеся деньги = {0}", m.HowManyItemsCanBuy(1000));
                Console.WriteLine("Изменим значения полей с помощью свойств");
                m.First = 500;
                m.Second = 2;
                Console.WriteLine($"И выведем новые значения:\nНоминал купюры = {m.First}\nКоличество купюр = {m.Second}");
                Console.WriteLine("Выводим имеющуюся у нас сумму денег с помощью метода:\n{0} rub", m.SumOfMoney);
                Console.WriteLine($"Вывод значений полей с помощью индексатора:\nНоминал купюры = {m[0]}\nКоличество купюр = {m[1]}");
                m++;
                Console.WriteLine("Вывод значений полей после унарной операции инкремента");
                m.Show();
                m--;
                Console.WriteLine("Вывод значений полей после унарной операции декремента");
                m.Show();
                Console.WriteLine("Увеличим количество купюр на скаляр с помощью бинарного оператора");
                m += 5;
                Console.WriteLine($"Результат увеличения выводим на экран:\nКоличество купюр = {m.Second}");
            }
        }
    }
}
