using Elevator;
using Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private const string _quit = "q";

        private static void Main(string[] args)
        {
            IManager manager = new Manager.Manager(new PublicElevator(int.Parse(ConfigurationManager.AppSettings["MaxFloor"])));
            var input = string.Empty;

            while (input != _quit)
            {
                Console.Write("Enter floor: ");
                input = Console.ReadLine();
                int floor;
                if (int.TryParse(input, out floor))
                    manager.ButtonPressed(floor);
                else if (input == _quit)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an invalid key, Please try again");
            }
        }
                
    }
}
