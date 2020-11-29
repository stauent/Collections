using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public interface IMonkey
    {
        int Age { get; set; }
        string Name { get; set; }
        int HaveBirthday();
        
    }

    public class Monkey : IMonkey
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int HaveBirthday()
        {
            return (++Age);
        }
        public override string ToString()
        {
            return ($"My name is {Name}, I am a {this.GetType().Name} and I'm {Age} years old");
        }
    }

    public class MontherMonkey<T>: Monkey where T: class, IMonkey, new()
    {
        protected List<T> Children { get; set; } = new List<T>();
        public T GiveBirth(string Name)
        {
            T newMonkey = new T { Name = Name, Age = 0 };
            Children.Add(newMonkey);
            return (newMonkey);
        }
    }


    public class EnumerableMontherMonkey<T> :  MontherMonkey<T>, IEnumerable<T> where T : class, IMonkey, new() 
    {
        // This method implements the GetEnumerator method. It allows
        // an instance of the class to be used in a foreach statement.
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Children.Count; ++index)
            {
                yield return Children[index];
            }

            // You could also use this code instead
            //return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
