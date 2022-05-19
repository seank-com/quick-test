using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Element
    {
        public Element(string id, long value1, long value2)
        {
            this.Id = id;
            this.Value1 = value1;
            this.Value2 = value2;
        }

        public string Id;
        public long Value1;
        public long Value2;
    }

    class Program
    {
        static void Prune1(Dictionary<string, Element> list) 
        {
            var top100 = list.Values.OrderBy(element => -element.Value1).Take(100).ToList();
            list.Clear();

            foreach (Element element in top100) 
            {
                list.Add(element.Id, element);
            }
        }
        static void Prune2(Dictionary<string, Element> list) 
        {
            var top100 = list.Values.OrderBy(element => -element.Value2).Take(100).ToList();
            list.Clear();

            foreach (Element element in top100) 
            {
                list.Add(element.Id, element);
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Element> result = new Dictionary<string, Element>();

            for(int i = 0; i < 2000000; i += 1) 
            {
                string id = Guid.NewGuid().ToString();
                result.Add(id, new Element(id, i, 0));

                if (result.Count > 200)
                {
                    Prune1(result);
                    Console.WriteLine($"processed {i} elements");
                }
            }

            Prune1(result);
            var list1 = result.Values.ToList();

            for(int j = 0; j < 2000000; j += 1) 
            {
                string id = Guid.NewGuid().ToString();
                result.Add(id, new Element(id, 0, j));

                if (result.Count > 200)
                {
                    Prune2(result);
                    Console.WriteLine($"processed {j} elements");
                }
            }
            Prune2(result);

            foreach(var element in list1) {
                if (result.ContainsKey(element.Id))
                {
                    result[element.Id].Value1 = element.Value1;
                }
                else
                {
                    result.Add(element.Id, element);
                }
            }

            Console.WriteLine($"result contains {result.Count()} elements");

            foreach (var item in result.Values.ToList()) {
                Console.WriteLine($"id={item.Id},v1={item.Value1},v2={item.Value2}");
            }
        }
    }
}
