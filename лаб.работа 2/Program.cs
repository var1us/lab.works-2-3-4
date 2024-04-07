using System;

namespace CalculatorApp
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль!");
                return double.NaN;
            }
            else
            {
                return (double)a / b;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Выход");

                choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= 4)
                {
                    Console.WriteLine("Введите первое число:");
                    int num1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите второе число:");
                    int num2 = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Результат сложения: {calculator.Add(num1, num2)}");
                            break;
                        case 2:
                            Console.WriteLine($"Результат вычитания: {calculator.Subtract(num1, num2)}");
                            break;
                        case 3:
                            Console.WriteLine($"Результат умножения: {calculator.Multiply(num1, num2)}");
                            break;
                        case 4:
                            Console.WriteLine($"Результат деления: {calculator.Divide(num1, num2)}");
                            break;
                    }
                }
                else if (choice != 5)
                {
                    Console.WriteLine("Некорректный выбор операции!");
                }

                Console.WriteLine();
            }
        }
    }
}