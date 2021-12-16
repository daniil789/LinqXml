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
            var doc = XDocument.Load("test.xml");
            var result = doc.Descendants()
                            .GroupBy(e => e.Name.LocalName)
                            .Select(j => new { elemName = j.Key, count = j.Count() });
            foreach (var elem in result)
                Console.WriteLine(elem.elemName, elem.count);
        }
    }
}
