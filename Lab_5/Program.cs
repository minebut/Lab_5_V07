/*Варіант No7. Створити клас, що містить як дані члени: одновимірний масив
структур Машина і його розмір (дотримуватися принципу інкапсуляції). Клас
містить відкриті властивості для доступу до закритих полів. Забезпечити
індексований доступ до об'єкта з цілочисельним параметром. У головній функції
додатка проілюструвати роботу класу.*/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    public class Program
    {
        static Garage garage = new Garage(2);

        public static void Main(string[] args)
        {
            int selectedIndex = 0; 

            string[] menuItems = {
            "Add car",
            "Remove car",
            "Show all cars",
            "Show car by index",
            "Exit"
        };

            while (true)
            {
                Console.Clear();
                DisplayMenu(menuItems, selectedIndex);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= menuItems.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuItems.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    MenuOption(selectedIndex);
                }
            }
        }
        public static void DisplayMenu(string[] menuItems, int selectedIndex)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"---> {menuItems[i]}<---");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuItems[i]}");
                }
            }
        }

        public static void MenuOption(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    AddCar();
                    break;
                case 1:
                    RemoveCar();
                    break;
                case 2:
                    ShowCars();
                    break;
                case 3:
                    ShowCarIndex();
                    break;
                case 4:
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public static void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Add new car");

            Console.Write("Make: ");
            string make = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year;
            bool validYear = int.TryParse(Console.ReadLine(), out year);

            if (!validYear)
            {
                Console.WriteLine("Invalid year format. No car added:");
                Console.ReadKey();
                return;
            }

            Car newCar = new Car(make, model, year);
            garage.AddCar(newCar);
            Console.WriteLine("The car has been successfully added:");
            Console.ReadKey();
        }

        public static void RemoveCar()
        {
            Console.Clear();
            Console.Write("Enter the index of the machine you want to delete (from 1 to " + garage.Size + "): ");
            int index;
            bool validIndex = int.TryParse(Console.ReadLine(), out index);

            if (validIndex && index >= 1 && index <= garage.Size)
            {
                garage.RemoveCar(index - 1);
                Console.WriteLine("Car deleted:");
            }
            else
            {
                Console.WriteLine("Wrong index:");
            }
            Console.ReadKey();
        }

        public static void ShowCars()
        {
            Console.Clear();
            Console.WriteLine("\nCars in your garage:");
            garage.ShowCars();
            Console.ReadKey();
        }


        public static void ShowCarIndex()
        {
            Console.Clear();
            Console.Write("Enter the index of the machine you want to delete (from 1 to " + garage.Size + "): ");
            int index;
            bool validIndex = int.TryParse(Console.ReadLine(), out index);

            if (validIndex && index >= 1 && index <= garage.Size)
            {
                Car car = garage[index - 1];
                Console.WriteLine($"Information about the car [{car}] by index [{index}]:");
            }
            else
            {
                Console.WriteLine("Wrong index");
            }
            Console.ReadKey();
        }
    }
}