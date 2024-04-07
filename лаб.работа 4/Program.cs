using System;
using System.Collections.Generic;
using System.Linq;

// Интерфейс для представления задачи
interface ITask
{
    string Name { get; set; }
    string Description { get; set; }
    bool IsCompleted { get; set; }
    void DisplayTaskInfo();
}

// Класс, представляющий задачу
class Task : ITask
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string name, string description)
    {
        Name = name;
        Description = description;
        IsCompleted = false;
    }

    public void DisplayTaskInfo()
    {
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Статус: {(IsCompleted ? "Выполнено" : "Не выполнено")}");
    }
}

// Интерфейс для управления задачами
interface ITaskManager
{
    void AddTask(ITask task);
    void RemoveTask(ITask task);
    void DisplayAllTasks();
    void MarkTaskAsCompleted(ITask task);
}

// Класс для управления задачами
class TaskManager : ITaskManager
{
    private List<ITask> tasks;

    public TaskManager()
    {
        tasks = new List<ITask>();
    }

    public void AddTask(ITask task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(ITask task)
    {
        tasks.Remove(task);
    }

    public void DisplayAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        Console.WriteLine("Список задач:");
        foreach (var task in tasks)
        {
            task.DisplayTaskInfo();
            Console.WriteLine();
        }
    }

    public void MarkTaskAsCompleted(ITask task)
    {
        task.IsCompleted = true;
        Console.WriteLine($"Задача '{task.Name}' отмечена как выполненная.");
    }

    // Метод для поиска задачи по ее названию
    public ITask FindTaskByName(string name)
    {
        return tasks.FirstOrDefault(task => task.Name == name);
    }
}

// Главный класс программы
class Program
{
    static void Main(string[] args)
    {
        ITaskManager taskManager = new TaskManager(); // Создаем экземпляр класса для управления задачами

        while (true)
        {
            // Выводим меню пользователю
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить новую задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Отметить задачу как выполненную");
            Console.WriteLine("4. Просмотреть список всех задач");
            Console.WriteLine("5. Выход");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Введите корректное число.");
                continue;
            }

            // Обрабатываем выбор пользователя
            switch (choice)
            {
                case 1: // Добавить новую задачу
                    Console.WriteLine("Введите название задачи:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите описание задачи:");
                    string description = Console.ReadLine();
                    taskManager.AddTask(new Task(name, description));
                    Console.WriteLine("Задача добавлена.");
                    break;
                case 2: // Удалить задачу
                    Console.WriteLine("Введите название задачи для удаления:");
                    string taskNameToRemove = Console.ReadLine();
                    ITask taskToRemove = ((TaskManager)taskManager).FindTaskByName(taskNameToRemove);
                    if (taskToRemove != null)
                    {
                        taskManager.RemoveTask(taskToRemove);
                        Console.WriteLine("Задача удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Задача не найдена.");
                    }
                    break;
                case 3: // Отметить задачу как выполненную
                    Console.WriteLine("Введите название задачи для отметки как выполненной:");
                    string taskNameToComplete = Console.ReadLine();
                    ITask taskToComplete = ((TaskManager)taskManager).FindTaskByName(taskNameToComplete);
                    if (taskToComplete != null)
                    {
                        taskManager.MarkTaskAsCompleted(taskToComplete);
                    }
                    else
                    {
                        Console.WriteLine("Задача не найдена.");
                    }
                    break;
                case 4: // Просмотреть список всех задач
                    taskManager.DisplayAllTasks();
                    break;
                case 5: // Выход из программы
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}