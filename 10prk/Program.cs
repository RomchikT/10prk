using System;
using System.IO;

namespace _10prk
{
    class Program
    {
        static void Main()
        {
            bool isExitSelected = false;
            int selectedOption = 1;

            while (!isExitSelected)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine($" {(selectedOption == 1 ? "→" : " ")} 1. Авторизоваться");
                Console.WriteLine($" {(selectedOption == 2 ? "→" : " ")} 2. Зарегистрироваться");
                Console.WriteLine($" {(selectedOption == 3 ? "→" : " ")} 3. Выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + 4) % 4;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % 4;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedOption)
                        {
                            case 1:
                                avtoriz();
                                break;

                            case 2:
                                registracia();
                                break;

                            case 3:
                                Console.WriteLine("Выход из программы...");
                                isExitSelected = true;
                                break;
                        }
                        break;
                }

                Console.WriteLine();
            }
        }

        static void registracia()
        {
            Console.WriteLine("Регистрация пользователя");

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Console.WriteLine("Выберите должность:");
            Console.WriteLine("1. Администратор");
            Console.WriteLine("2. Менеджер персонала");
            Console.WriteLine("3. Склад-менеджер");
            Console.WriteLine("4. Кассир");
            Console.WriteLine("5. Бухгалтер");
            Console.Write("Введите номер должности: ");
            int positionNumber = int.Parse(Console.ReadLine());

            string position;
            switch (positionNumber)
            {
                case 1:
                    position = "Администратор";
                    break;
                case 2:
                    position = "Менеджер персонала";
                    break;
                case 3:
                    position = "Склад-менеджер";
                    break;
                case 4:
                    position = "Кассир";
                    break;
                case 5:
                    position = "Бухгалтер";
                    break;
                default:
                    position = "Неизвестная должность";
                    break;
            }

            string userEntry = $"{login},{password},{position}";
            File.AppendAllText("C:\\Users\\roma\\source\\repos\\10prk\\10prk\\js\\danie.js", userEntry + Environment.NewLine);

              Console.WriteLine("Регистрация успешно завершена.");
        }

        static void avtoriz()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = ReadPassword();

            string[] lines = File.ReadAllLines("C:\\Users\\roma\\source\\repos\\10prk\\10prk\\js\\danie.js");

            bool isAuthenticated = false;
            foreach (string line in lines)
            {
                string[] credentials = line.Split(',');
                if (credentials.Length == 3 && credentials[0].Trim() == login && credentials[1].Trim() == password)
                {
                    isAuthenticated = true;
                    break;
                }
            }

            if (isAuthenticated)
            {
                Console.WriteLine("Авторизация успешна!");
            }
            else
            {
                Console.WriteLine("Неправильный логин или пароль.");
            }
        }

        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}