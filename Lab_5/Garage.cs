using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
public struct Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public override string ToString()
    {
        return $"Year[{Year}] Make[{Make}] Model[{Model}]";
    }
}

public class Garage
{
    private Car[] cars;// масив машин
    private int size;   // кількість машин в гаражі

    public int Size
    {
        get { return size; }// отримання кількості машин
    }


    public Garage(int initialCapacity)// конструктор, що ініціалізує масив
    {
        cars = new Car[initialCapacity];
        size = 0;
    }

    public void AddCar(Car newCar)
    {

        if (size == cars.Length)// якщо гараж заповнений, розширюємо масив
        {
            Array.Resize(ref cars, cars.Length + 1);
        }
        cars[size] = newCar;
        size++;
    }

    public void RemoveCar(int index)
    {
        GarageEmpty();
        if (index >= 0 && index < size)
        {
            for (int i = index; i < size - 1; i++)
            {
                cars[i] = cars[i + 1];
            }
            size--;
            Array.Resize(ref cars, size); // Опціонально можна змінити розмір масиву
        }
        else
        {
            Console.WriteLine("Wrong index");
        }

    }


    public Car this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
            {
                return cars[index];
            }
            throw new IndexOutOfRangeException("Invalid index");//
        }
    }

    public void ShowCars()
    {
        GarageEmpty();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
            }
        
    }
    public void GarageEmpty()
    {
        if (size == 0)
        {
            Console.WriteLine("Garage Empty");
        }

    }
}