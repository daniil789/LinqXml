using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqXml
{
    class Program
    {
        //LinqXml11. Дан XML-документ.Найти все различные имена его элементов и вывести каждое 
        //найденное имя вместе с числом его вхождений в документ.Имена элементов выводить
        //в порядке их первого вхождения.
        //Указание.Использовать метод GroupBy.

        static void Main(string[] args)
        {
            Console.WriteLine(XDocument.Load("doc.xml"));

            Task11();
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }

            Task22();
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }

            Task33();
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }
        }

        static void Task11()
        {
            Console.WriteLine("LinqXml11.Дан XML-документ. Найти все различные имена его  элементов  и  вывести  каждое  найденное  имя  вместе  с числом его вхождений в документ. Имена элементов выво-дить впорядке их первого вхождения. Указание. Использовать метод GroupBy. \n");
            var doc = XDocument.Load("doc.xml");
            var result = doc.Descendants()
                            .GroupBy(e => e.Name.LocalName)
                            .Select(j => new { elemName = j.Key, count = j.Count() });
            foreach (var elem in result)
                Console.WriteLine($"{elem.elemName} { elem.count}");
        }

        static void Task22()
        {
            Console.WriteLine("LinqXml22.Дан XML-документ и строка S. В строке записано имя одного из некорневых элементов исходного документа. Удалить из документа все элементы с именем");
            var doc = XDocument.Load("doc.xml");
            string s = Console.ReadLine();
            doc.Root.Descendants(s).Remove();
            doc.Save("task22.xml");

            Console.WriteLine(XDocument.Load("task22.xml"));
        }

        static void Task33()
        {
            string fileName ="doc.xml";
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Where(el => el.HasAttributes))
            {
                e.ReplaceAttributes(new XElement("attr", e.Attributes()));
            }
            doc.Save("task33.xml");

            Console.WriteLine(XDocument.Load("task33.xml"));
        }
    }
}
