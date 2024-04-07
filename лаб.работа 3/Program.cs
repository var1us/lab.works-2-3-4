using System;
using System.Collections.Generic;
using System.IO;

namespace CollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выбор типа коллекции
            Console.WriteLine("Выберите тип коллекции (1 - List, 2 - Dictionary):");
            int choice = Convert.ToInt32(Console.ReadLine());
            IDictionary<int, string> collection = null;

            switch (choice)
            {
                case 1:
                    collection = new Dictionary<int, string>(); // Создаем новый Dictionary
                    break;
                case 2:
                    collection = new Dictionary<int, string>(); // Создаем новый Dictionary
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Используется Dictionary по умолчанию.");
                    collection = new Dictionary<int, string>(); // Используем Dictionary по умолчанию
                    break;
            }

            // Основной цикл приложения
            while (true)
            {
                // Отображение доступных действий
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Редактировать элемент");
                Console.WriteLine("4. Просмотреть элементы");
                Console.WriteLine("5. Сохранить коллекцию в файл");
                Console.WriteLine("6. Загрузить коллекцию из файла");
                Console.WriteLine("7. Выход");

                int action = Convert.ToInt32(Console.ReadLine()); // Считываем действие пользователя

                // Обработка выбранного действия
                switch (action)
                {
                    case 1: // Добавление элемента
                        Console.WriteLine("Введите ключ:");
                        int key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите значение:");
                        string value = Console.ReadLine();
                        collection.Add(key, value);
                        break;
                    case 2: // Удаление элемента
                        Console.WriteLine("Введите ключ элемента для удаления:");
                        int keyToRemove = Convert.ToInt32(Console.ReadLine());
                        collection.Remove(keyToRemove);
                        break;
                    case 3: // Редактирование элемента
                        Console.WriteLine("Введите ключ элемента для редактирования:");
                        int keyToEdit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите новое значение:");
                        string newValue = Console.ReadLine();
                        collection[keyToEdit] = newValue;
                        break;
                    case 4: // Просмотр элементов
                        Console.WriteLine("Элементы в коллекции:");
                        foreach (var item in collection)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        break;
                    case 5: // Сохранение в файл
                        Console.WriteLine("Введите имя файла для сохранения:");
                        string fileNameToSave = Console.ReadLine();
                        SaveToFile(collection, fileNameToSave);
                        break;
                    case 6: // Загрузка из файла
                        Console.WriteLine("Введите имя файла для загрузки:");
                        string fileNameToLoad = Console.ReadLine();
                        collection = LoadFromFile(fileNameToLoad);
                        break;
                    case 7: // Выход из программы
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        // Сохранение коллекции в файл
        static void SaveToFile(IDictionary<int, string> collection, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var item in collection)
                {
                    writer.WriteLine($"{item.Key},{item.Value}");
                }
            }
            Console.WriteLine("Коллекция успешно сохранена в файл.");
        }

        // Загрузка коллекции из файла
        static IDictionary<int, string> LoadFromFile(string fileName)
        {
            Dictionary<int, string> loadedCollection = new Dictionary<int, string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int key = Convert.ToInt32(parts[0]);
                    string value = parts[1];
                    loadedCollection.Add(key, value);
                }
            }
            Console.WriteLine("Коллекция успешно загружена из файла.");
            return loadedCollection;
        }
    }
}
