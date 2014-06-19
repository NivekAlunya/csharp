using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    class Program
    {
        struct Client {
            public string name;
            public int age;
            public DateTime dob;
        }
        static void Main(string[] args)
        {
            Client client;
            client.name = "Ray Ray";
            client.age = 20;
            client = createClient();
            displayClient(client);
            Console.ReadKey();
        }
        static Client createClient()
        {
            Client client;
            Console.Write("\nName : ");
            client.name = Console.ReadLine();
            Console.Write("\nDOB : ");
            client.dob = DateTime.Parse(Console.ReadLine());
            client.age = DateTime.Now.Year - client.dob.Year;
            return client;
        }
        static void displayClient(Client client)
        {
            Console.WriteLine(client.name + " is " + client.age + " year" +(client.age>1?"s" : "")  + " old. He's born the " + client.dob);

        }
    }
}
