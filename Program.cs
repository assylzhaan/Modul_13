using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul13HW
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }

        public Client(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }
    }

    class Program
    {
        static Queue<Client> clientQueue = new Queue<Client>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Встать в очередь");
                Console.WriteLine("2. Обслужить следующего клиента");
                Console.WriteLine("3. Выйти из программы");
                Console.Write("Выберите Ваши действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnqueueClient();
                        break;
                    case "2":
                        ServeNextClient();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ошибка ! Выберите пожалуйста действие!");
                        break;
                }
            }
        }

        static void EnqueueClient()
        {
            Console.Write("Введите Имя: ");
            string name = Console.ReadLine();

            Console.Write("Выберите действие  ");
            string serviceType = Console.ReadLine();

            int clientId = clientQueue.Count + 1;
            Client newClient = new Client(clientId, name, serviceType);

            clientQueue.Enqueue(newClient);

            Console.WriteLine($"Клиент {newClient.Name} добавлен,текущее число клиентов: {clientQueue.Count}");
            DisplayQueue();
        }

        static void ServeNextClient()
        {
            if (clientQueue.Count > 0)
            {
                Client nextClient = clientQueue.Dequeue();
                Console.WriteLine($"Клиент {nextClient.Name} обслужен. Текущее число клиентов:{clientQueue.Count}");
            }
            else
            {
                Console.WriteLine("Нет очереди!!!");
            }

            DisplayQueue();
        }

        static void DisplayQueue()
        {
            if (clientQueue.Count > 0)
            {
                Console.WriteLine("Текущее число  клиентов:");
                foreach (var client in clientQueue)
                {
                    Console.WriteLine($"ID: {client.Id}, Имя: {client.Name}, Тип обслуживания: {client.ServiceType}");
                }
            }
            else
            {
                Console.WriteLine("Нет очереди!!!");
            }
        }
    }

}
