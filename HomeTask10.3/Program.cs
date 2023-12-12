using HomeTask10._3;
using System.Text.Json;
using System.Xml.Serialization;


string json;
using (StreamReader str = new StreamReader(@"data.json"))
    json = str.ReadToEnd();

List<Person> deserializedObject = JsonSerializer.Deserialize<List<Person>>(json)!;


XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
using (StringWriter stringWriter = new StringWriter())
{
    serializer.Serialize(stringWriter, deserializedObject);
    string xml = stringWriter.ToString();
    File.AppendAllText(@"people.xml", xml);


    XmlSerializer deserializer = new XmlSerializer(typeof(List<Person>));
    using (StringReader stringReader = new StringReader(xml))
    {
        List<Person> persons = deserializer.Deserialize(stringReader) as List<Person>;

        Console.WriteLine("Выберите код операции, которую хотели бы совершить:\n" +
                  "1 - Найти сотрудника по имени\n" +
                  "2 - Найти сотрудника по языку программирования \n" +
                  "3 - Выйти из меню поиска");
        while (true)
        {
            bool IsSuccessChoice = int.TryParse(Console.ReadLine(), out int choice);
            if (IsSuccessChoice)
            {
                if (choice == 1)
                {
                    Console.Write("Введите имя и фамилию сотрудника: ");
                    string empl = Console.ReadLine();
                    if (string.IsNullOrEmpty(empl))
                    {
                        throw new ArgumentNullException(nameof(empl));
                    }
                    var selectedPeople = persons.Where(p => p.name == empl);
                    foreach (Person person in selectedPeople)
                        Console.WriteLine(person.ToString());
                    continue;
                }

                else if (choice == 2)
                {
                    Console.Write("Введите язык программирования: ");
                    string language = Console.ReadLine();
                    if (string.IsNullOrEmpty(language))
                    {
                        throw new ArgumentNullException(nameof(language));
                    }
                    var selectedPeople = from person in persons
                                         from lang in person.languages
                                         where lang == language
                                         select person;
                    foreach (Person person in selectedPeople)
                        Console.WriteLine(person.ToString());
                    continue;
                }

                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный код операции!");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Неверная команда!");
                continue;
            }
        }
    }
}



