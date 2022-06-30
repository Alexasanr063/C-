using System;
using System.Collections;
using System.IO;

using System.Xml.Serialization;

namespace SampleNamespace;

class Program
{
    public static void Main(string[] arg)
    {
        Animal PersonAnimal = new Animal();

        System.Console.Write("Ввидете имя:  ");
        PersonAnimal.name = Console.ReadLine();

        System.Console.Write("Ввидете логин:  ");
        PersonAnimal.login = Console.ReadLine();

        System.Console.Write("Ввидете возраст:  ");
        PersonAnimal.age = Console.ReadLine();

        System.Console.Write("Ввидете хобби:");
        PersonAnimal.delts = Console.ReadLine();


        PersonAnimal.peoples = PersonAnimal.delts.Split(',');

        string[] myIntArray = new string[3];
        myIntArray[0] = PersonAnimal.name;
        myIntArray[1] = PersonAnimal.login;
        myIntArray[2] = PersonAnimal.age;

        string[] myNewPerson = myIntArray.Concat(PersonAnimal.peoples).ToArray();

        XmlSerializer xml = new XmlSerializer(typeof(string[]));
        using (FileStream file = new FileStream("lena.bodinia", FileMode.OpenOrCreate))
        {
            xml.Serialize(file, myNewPerson);
            System.Console.WriteLine("Сериализация успешна бро");
        }

        using (FileStream file = new FileStream("lena.bodinia", FileMode.OpenOrCreate))
        {
            string[] newMyAll = xml.Deserialize(file) as string[] ?? new string[0];
            System.Console.WriteLine("Десериализация успешна бро");

            System.Console.WriteLine($"Пользователь: {newMyAll[0]} с логином: {newMyAll[1]}. Его возраст: {newMyAll[2]}. Хобби:");
            for (int i = 3; i < newMyAll.Length; i++)
            {
                System.Console.WriteLine(newMyAll[i]);
            }
        }
    }
}