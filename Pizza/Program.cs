using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace Pizza
{
    class Pizza
    {
        public string [] Toppings { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllText("pizzas.json");
            var parsed = JsonConvert.DeserializeObject<Pizza[]>(data);
            var result = parsed
                       .Select(x => string.Join(",", x.Toppings.OrderBy(y => y)))
                       .GroupBy(x => x)
                       .OrderByDescending(x => x.Count())
                       .Take(20)
                       .ToList();
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item.Key));
            }          
        }
    }
}
