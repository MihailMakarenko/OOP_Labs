/*свойство типа int c методами get и set для получения информации (get) и изменения (set) 
    года рождения в закрытом поле типа DateTime, в котором хранится дата рождения.*/

using System;

namespace ConsoleApp1
{
    public class Person
    {
        public Person(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Person()
        {
            Random random = new Random();
            FirstName = "defaultFirstName" + random.Next().ToString();
            LastName = "defaultLastName" + random.Next().ToString();
            Birthday = DateTime.Now;
        }
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (value < DateTime.Now)
                {
                    _birthday = value;
                }
            }
        }

        public override string ToString()
        {
            string person = $"Человек:\nИмя: {_firstName}\nФамилия: {_lastName}\nДата рождения: {_birthday}";
            return person;
        }

        public virtual string ToShortString()
        {
            Object obj = new object();
            Console.WriteLine(obj.Equals);
            string person = $"Человек:\nИмя: {_firstName}\nФамилия: {_lastName}";
            return person;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Person person = (Person)obj;
            if (person.FirstName == _firstName &&
                person.LastName == _lastName &&
                person.Birthday == _birthday)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            if (person1.Equals(person2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Person person1, Person person2)
        {
            if (person1 == person2)
            {
                return false;
            }
            return true;
        }

        public virtual object DeepCopy()
        {
            return new Person(_firstName,_lastName,_birthday);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() / 2;
        }
    }
}
