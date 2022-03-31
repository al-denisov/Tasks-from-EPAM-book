using System;

namespace Prac1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите объем куба ");
            string a = Console.ReadLine();
            int x = int.Parse(a);
            Console.WriteLine("Ребро куба равно {0}", Math.Cbrt(x));
            Console.ReadLine();
        }
    }
}
