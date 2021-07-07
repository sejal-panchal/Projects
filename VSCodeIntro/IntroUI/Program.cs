using System;
using IntroLibrary;

namespace IntroUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel p = new PersonModel{ FirstName="sejal",LastName="panchal",Age=36};
            System.Console.WriteLine($"{p.FirstName} {p.LastName} her age is {p.Age}.");
            Console.WriteLine("Hello World!");
            Console.WriteLine("This is a test ");
        }
    }
}
