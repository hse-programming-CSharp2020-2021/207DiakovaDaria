using System;
using System.Collections.Generic;

namespace Task3
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        string name;
        string lastName;
        int age;
        public bool IsOld { private set; get; }
        public string Name
        {
            set
            { // only latin simbols and spaces
              // not longer 30 simbols 
                if (name.Length > 30 && IsCorrectName(value))
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        bool IsCorrectName(string name)
        {
            foreach (char ch in name)
            {
                if (ch != 32 || (ch < 65 && ch > 87) || (ch < 97 && ch > 122))
                {
                    return false;
                }
            }
            return true;
        }
        public string LastName
        {
            set
            { // only latin simbols and spaces
              // not longer 40 simbols
                if (name.Length > 40 && IsCorrectName(value))
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        public int Age
        {
            set
            { 
                if (value > 0 && value <= 40)
                {
                    age = value;
                }
            }
            get { return age; }
        }
        public Passenger(string name, string surName, int age)
        {
            Name = name;
            LastName = surName;
            Age = age;
            if (age >= 65)
            {
                IsOld = true;
            }    
        }
        public override string ToString()
        {
            return $"{Name} {LastName} {Age}";
        }
    }
    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        public bool IsNewBorn { get; }
        public int NumberOfChildren { get; }
        public PassengerWithChildren(bool isNewBorn, int numberOfChildren, string name, string surName, int age) : base(name, surName, age)
        {
            Name = name;
            LastName = surName;
            Age = age;
            NumberOfChildren = numberOfChildren;
            IsNewBorn = isNewBorn;
        }
        public override string ToString()
        {
            return $"Passenger with children {Name} {LastName} age: {Age} number of children: {NumberOfChildren}";
        }
    }
    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.Age > 65 || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            if (priorityQueue.Count <= 3)
            {
                foreach (var passenger in priorityQueue)
                {
                    priorityQueue.Dequeue();
                }
                foreach (var passenger in ordinaryQueue)
                {
                    ordinaryQueue.Dequeue();
                }
            }
            else
            {
                foreach (var passenger in priorityQueue)
                {
                    priorityQueue.Dequeue();
                    ordinaryQueue.Dequeue();
                }
                if (ordinaryQueue.Count != 0)
                {
                    foreach (var passenger in ordinaryQueue)
                    {
                        ordinaryQueue.Dequeue();
                    }
                }
            }
        }
    }

    class MainClass
    {
        public static string NameGenerate()
        {
            Random rnd = new Random();
            string name = "";
            int nick_length = rnd.Next(1, 16);
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < nick_length; i++)
            {
                name += chars[rnd.Next(chars.Length)];
            }
            return name;
        }
        public static void Main()
        {
            Random rnd = new Random();
            PassengerQueue queue = new PassengerQueue();

            for (int i = 0; i < rnd.Next(0, 200); i++)
            {
                Passenger passenger;

                if (Convert.ToBoolean(rnd.Next(0, 2)))
                    passenger = new PassengerWithChildren(Convert.ToBoolean(rnd.Next(0, 2)), rnd.Next(1, 41),
                        NameGenerate(), NameGenerate(), rnd.Next(18, 105));

                else passenger = new Passenger(NameGenerate(), NameGenerate(), rnd.Next(18, 105));

                queue.AddToQueue(passenger);
            }

            queue.StartServingQueue();
        }
    }
}