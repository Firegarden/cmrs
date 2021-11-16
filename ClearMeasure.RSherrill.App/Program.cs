using System;


namespace ClearMeasure.RSherrill.App
{
   
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Running");

            static bool fizzPredicate(int x) { return (x == 5); }
            static bool buzzPredicate(int x) { return (x == 6); }

            var fizzBuzz = new FizzBuzz();
            var fizzBuzzFile = fizzBuzz.GenerateFizzBuzzFile(fizzPredicate, buzzPredicate, 10);            
            System.IO.File.Delete(fizzBuzzFile);

            Console.WriteLine("Finished Running");
        }

    }

}
