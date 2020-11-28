using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few animals that we'll work with
            Cat Fluffy = new Cat("Fluffy", 5);
            Cat Snowball = new Cat("Snowball", 9);
            Dog Rover = new Dog("Rover", 2);
            Dog Trigger = new Dog("Trigger", 16);

            // Traditional way to create a collection of objects that is type-safe is to use an array.
            // Only objects that are derived from "Animal" are allowed in the array. Compiler will complain otherwise.
            // But duplicates are possible!
            Console.WriteLine("\r\n\r\nArray example--------------------------------------------------------------------------------------------------");
            Animal[] ArrayOfAnimals = new Animal[] { Fluffy , Snowball, Rover, Trigger, Rover, Trigger };

            // Find a specific object in the array is slow because objects in the array are searched sequencially
            Animal[] ArrayOlderThan2 = new Animal[ArrayOfAnimals.Length];
            for(int i = 0; i < ArrayOfAnimals.Length; ++i)
            {
                if (ArrayOfAnimals[i].Age > 2)
                    ArrayOlderThan2[i] = ArrayOfAnimals[i];
                else
                    ArrayOlderThan2[i] = null;
            }
            foreach (Animal a in ArrayOlderThan2)
            {
                if(a != null)
                    Console.WriteLine($"Array: {a}");
            }

            // A generic way to create a collection of objects that is type-safe is to use an List<T>.
            // Only objects that are derived from "Animal" are allowed in the List<Animal>. Compiler will complain otherwise.
            // But duplicates are possible! Advantage over array is that we can dynamically add more objects to the list over time.
            Console.WriteLine("\r\n\r\nList examples--------------------------------------------------------------------------------------------------");
            List<Animal> ListOfAnimals = new List<Animal> { Fluffy, Snowball, Rover, Trigger, Rover, Trigger};

            // Find a specific object in the List<T> is slow because objects in the List<T> are searched sequencially
            List<Animal> ListOlderThan2 = new List<Animal>();
            foreach(Animal a in ListOfAnimals)
            {
                if (a.Age > 2)
                    ListOlderThan2.Add(a);
            }
            foreach (Animal a in ListOlderThan2)
            {
                Console.WriteLine($"List: {a}");
            }


            // A Hashtable produces a structure which facilitates quick lookup.
            // The Hashtable class represents a collection of key-and-value pairs that are organized based on the hash code of the key.
            // The key is used to access the items in the collection. 
            // DUPLICATES are NOT allowed!
            Console.WriteLine("\r\n\r\nHashtable example--------------------------------------------------------------------------------------------------");
            Hashtable HashOfAnimals = new Hashtable() {
                { Fluffy.Name, Fluffy},
                { Snowball.Name, Snowball},
                { Rover.Name, Rover},
                { Trigger.Name, Trigger}
            };

            List<Animal> HashOlderThan2 = new List<Animal>();
            foreach(Animal animal in HashOfAnimals.Values.Cast<Animal>())
            {
                if (animal.Age > 2)
                    HashOlderThan2.Add(animal);
            }
            foreach (Animal a in HashOlderThan2)
            {
                Console.WriteLine($"Hash: {a}");
            }

            // A Hashtable is NOT type-safe unless you specifically take action to ensure that only elements
            // of a specific type are added.
            Console.WriteLine("\r\n\r\nNot type-safe hastable --------------------------------------------------------------------------------------------");
            HashOfAnimals = new Hashtable() {
                { Fluffy.Name, Fluffy},
                { Snowball.Name, Snowball},
                { Rover.Name, Rover},
                { Trigger.Name, Trigger},
                {1, Fluffy },
                {2, Fluffy },
                {3, 24 },
                {4, "Hello" }
            };

            // Notice that because elements of a hashtable are arranged based on a hash
            // of the key, there is no guarantee of the order in which you'll encounter
            // each element as you sequentially move through elements.
            foreach (DictionaryEntry element in HashOfAnimals)
            {
                Console.WriteLine($"Key:{element.Key} Type:{element.Value.GetType().ToString()} Value:{element.Value}");
            }

            // Because the Hashtable is not type-safe, you CAN'T cast all values to a specific type because 
            // there is no guranatee that they are. We have cat's dogs, strings and integers in the latest Hashtable! 
            Console.WriteLine("\r\n\r\nNot all elements are the same type, produces casting error---------------------------------------------------------");
            try
            {
                HashOlderThan2 = new List<Animal>();
                foreach (Animal animal in HashOfAnimals.Values.Cast<Animal>())
                {
                    // Not using LINQ becaue it hasn't been introduced in class yet
                    if (animal.Age > 2)
                        HashOlderThan2.Add(animal);
                }
            }
            catch (Exception Err)
            {
                Console.WriteLine(Err.Message);
            }

            // You can find any specific element in the Hashtable by using the key. Notice that you MUST cast the returned
            // value because there is no guarantee of the type of any element in the Hashtable.
            Animal found = (Animal)HashOfAnimals["Fluffy"];
            Console.WriteLine($"found:{found}");

            // A Hashset<T> is a type-safe version of the Hashtable. Duplicates are NOT allowed and are silently rejected 
            // so that only unique values remain in the Hashset.
            Console.WriteLine("\r\n\r\nHashset example--------------------------------------------------------------------------------------------------");
            HashSet<Animal> HashsetOfAnimals = new HashSet<Animal> { Fluffy, Snowball, Trigger, Trigger, Trigger };
            List<Animal> HashsetOlderThan2 = new List<Animal>();
            foreach (Animal animal in HashsetOfAnimals)
            {
                if (animal.Age > 2)
                    HashsetOlderThan2.Add(animal);
            }
            foreach (Animal a in HashOlderThan2)
            {
                Console.WriteLine($"Hashset: {a}");
            }

            // There is no "key" in a Hashset because a hash code is produced from the entire value
            // and that hash code is used to store the value. The only thing you can do to find a
            // particular element is to iterate over the collection or use the "Contains" method.
            // iterate 
            if (HashsetOfAnimals.Contains(Fluffy))
                Console.WriteLine($"The hashset contains element {Fluffy.Name}");
            else
                Console.WriteLine($"The hashset DOES NOT contain element {Fluffy.Name}");

            if (HashsetOfAnimals.Contains(Rover))
                Console.WriteLine($"The hashset contains element {Rover.Name}");
            else
                Console.WriteLine($"The hashset DOES NOT contain element {Rover.Name}");

            // A generic Dictionary<K,V> is stored as a collection of KeyValuePair<K,V> objects.
            // Where K specifies the type of the key and V specifies the element value.
            // A Dictionary does NOT allow duplicates and will throw an exception if you try.
            Console.WriteLine("\r\n\r\nDictionary example--------------------------------------------------------------------------------------------------");
            Dictionary<string, Animal> DictionaryOfAnimals = new Dictionary<string, Animal>
            {
                { Fluffy.Name, Fluffy},
                { Snowball.Name, Snowball},
                { Rover.Name, Rover},
                { Trigger.Name, Trigger}
            };

            List<KeyValuePair<string, Animal>> DictionaryOlderThan2 = new List<KeyValuePair<string, Animal>>();
            foreach (KeyValuePair<string, Animal> animal in DictionaryOfAnimals)
            {
                if (animal.Value.Age > 2)
                    DictionaryOlderThan2.Add(animal);
            }
            foreach (KeyValuePair<string, Animal> a in DictionaryOlderThan2)
            {
                Console.WriteLine($"Dictionary: {a}");
            }

            // You can find an element value in the Dictionary by using its key
            found = DictionaryOfAnimals["Fluffy"];
            Console.WriteLine($"found:{found}");


            Console.WriteLine("\r\n\r\nforeach is syntactic sugar for GetEnumerator==========================");
            // What does foreach actually do?
            // Almost every program you write will have some need to iterate over a collection.
            // The foreach statement isn't magic, though. It relies on two generic interfaces 
            // defined in the .NET core library in order to generate the code necessary to 
            // iterate a collection: IEnumerable<T> and IEnumerator<T>. When you indicate that
            // your class implements IEnumerable<T>, the compiler knows that your class has implemented
            // the GetEnumerator() method.
            // The IEnumerable interface contains only 1 method:
            //          IEnumerator<T> GetEnumerator();
            // When the compiler detects the iterator (foreach), it automatically calls GetEnumerator() on the 
            // object being iterated over, and generates the Current, MoveNext, and Dispose 
            // methods of the IEnumerator or IEnumerator<T> interface. This is how it is able to traverse
            // over every element in your collection. To read more about iterators:
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
            // Hence, the following 2 blocks of code are IDENTICAL!!!!
            foreach (Animal a in ListOfAnimals)
            {
                Console.WriteLine($"List: {a}");
            }
            Console.WriteLine("\r\n==========================");

            // When you reach a foreach block for any collection, this is what the compiler is doing for you.
            // Notice that it doesn't matter what type of collection you have, you "GetEnumerator" and then
            // walk through the elements using "MoveNext".
            IEnumerator<Animal> enumerator = ListOfAnimals.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Animal a = enumerator.Current;
                Console.WriteLine($"List Enumerator: {a}");
            }

            Console.WriteLine("\r\n==========================");
            IEnumerator<Animal> enumerator1 = HashsetOfAnimals.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Animal a = enumerator1.Current;
                Console.WriteLine($"Hashset Enumerator: {a}");
            }

            Console.WriteLine("\r\n==========================");
            IEnumerator<KeyValuePair<string, Animal>> enumerator2 = DictionaryOfAnimals.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Animal a = enumerator2.Current.Value;
                Console.WriteLine($"Dictionary Enumerator: {a}");
            }

            Console.WriteLine("\r\n==========================");
            IEnumerator enumerator3 = ArrayOfAnimals.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                Animal a = (Animal)enumerator3.Current;
                Console.WriteLine($"Array Enumerator: {a}");
            }

            Console.WriteLine("\r\nNon generic collection==========================");
            DaysOfTheWeekCollection days = new DaysOfTheWeekCollection();
            foreach(string day in days)
            {
                foreach (string day2 in days)
                {
                    if (day2 == "Wed")
                        break;
                    Console.WriteLine($"Inner: {day2}");
                }
                Console.WriteLine($"Outter: {day}");
            }


            IEnumerator nonGeneric = days.GetEnumerator();
            while (nonGeneric.MoveNext())
            {
                string day = (string)nonGeneric.Current;
                Console.WriteLine($"Non generic day: {day}");
            }

            Console.WriteLine("\r\nCustom Generic Collection==========================");
            Random r = new Random();
            GenericStack<int> myStack = new GenericStack<int>();
            for (int x = 0; x < 100; ++x)
                myStack.Push(r.Next(0, 500));

            List<int> poppedValues = new List<int>();
            while (true)
            {
                try
                {
                    poppedValues.Add(myStack.Pop());
                }
                catch (Exception Err)
                {
                    Console.WriteLine($"{Err.Message}");
                    break;
                }
            }


            Console.WriteLine("\r\nSimple iterators==========================");
            SimpleMath simple = new SimpleMath(poppedValues);
            foreach (int n in simple.EvenNumbers())
            {
                Console.WriteLine($"Even number {n}");
            }
            foreach (int n in simple.OddNumbers())
            {
                Console.WriteLine($"Odd number {n}");
            }



            //----------------- Speed test ------------------------------------------
            List<SpeedTest> speed = new List<SpeedTest>();
            RunSpeedTests.ArrayIntSpeedTest(speed);
            RunSpeedTests.ListIntSpeedTest(speed);
            RunSpeedTests.DictionaryIntSpeedTest(speed);
            RunSpeedTests.HashtableIntSpeedTest(speed);

            // Display results of tests
            Console.WriteLine("\r\n\r\nRunning speed tests ==============================");
            List<SpeedTest> orderedWinners = speed.OrderBy(x => x.TestNumber).ThenBy(x => x.TotalTicks).ToList();
            foreach (SpeedTest s in orderedWinners)
            {
                double ave = Math.Round(s.TotalTicks / (double)(RunSpeedTests.maxElements), 3);
                Console.WriteLine($"{s.TestType} took {s.TotalTicks} ticks, average ticks per action {ave}");
            }
            Console.ReadKey();
        }
    }

    public enum TypeOfAnimal
    {
        Cat,
        Dog
    }

    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TypeOfAnimal AnimalType { get; set; }

        public Animal(string Name, int Age, TypeOfAnimal AnimalType)
        {
            this.Name = Name;
            this.Age = Age;
            this.AnimalType = AnimalType;
        }

        public override string ToString()
        {
            return ($"{Name} is a {AnimalType} that is {Age} years old");
        }
    }

    public class Cat: Animal
    {
        public Cat(string Name, int Age): base(Name, Age, TypeOfAnimal.Cat)
        { }
    }

    public class Dog : Animal
    {
        public Dog(string Name, int Age) : base(Name, Age, TypeOfAnimal.Dog)
        { }
    }


}
